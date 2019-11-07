/*==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The PersistenceQueue database object schema and implementation logic.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SqlAzurePersistenceQueue_Enqueue]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_SqlAzurePersistenceQueue_Enqueue]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_SqlAzurePersistenceQueue_Enqueue]
	@QueueItemID uniqueidentifier,
	@QueueItemType varchar(255) = NULL OUTPUT,
	@QueueItemSize bigint = NULL OUTPUT
AS

DECLARE @IsXml bit, @DataChunk varchar(255), @RootNodeName varchar(255), @RootNodeNs varchar(255), @DataChunkXml xml

SELECT @IsXml = 1 FROM app.PersistenceQueue WHERE QueueItemID = @QueueItemID AND QueueItemDataXml IS NOT NULL

IF COALESCE(@IsXml, 0) = 0 BEGIN
	SELECT @DataChunk = SUBSTRING(QueueItemDataRaw, 0, 255) FROM app.PersistenceQueue WHERE QueueItemID = @QueueItemID
	
	-- Check of presence of BOM (0xEF 0xBB 0xBF for UTF-8 or 0xFE 0xFF for UTF-16), skip it if found
	IF ASCII(SUBSTRING(@DataChunk, 1, 1)) = 239 AND ASCII(SUBSTRING(@DataChunk, 2, 1)) = 187 AND ASCII(SUBSTRING(@DataChunk, 3, 1)) = 191
		SET @DataChunk = SUBSTRING(@DataChunk, 4, 255)
	ELSE IF ASCII(SUBSTRING(@DataChunk, 1, 1)) = 254 AND ASCII(SUBSTRING(@DataChunk, 2, 1)) = 255 
		SET @DataChunk = SUBSTRING(@DataChunk, 3, 255)

	-- Skip the XML processing instruction node
	IF LEFT(@DataChunk, 5) = '<?xml' BEGIN
		-- Jump to the content right after XML processing instruction node
		SET @DataChunk = SUBSTRING(@DataChunk, CHARINDEX('>', @DataChunk, 6) + 1, 255)
		-- Skip any whitespaces such as tabs, CR, LF, blanks.
		WHILE ASCII(SUBSTRING(@DataChunk, 1, 1)) <= 32 SET @DataChunk = RIGHT(@DataChunk, LEN(@DataChunk) - 1)
	END
		
	-- Can we find the root XML node based on its openning and closing tags?
	IF LEFT(@DataChunk, 1) = '<' AND CHARINDEX('>', @DataChunk, 2) > 0 BEGIN
		SET @RootNodeName = SUBSTRING(@DataChunk, 2, CHARINDEX('>', @DataChunk, 2) - 2)
		
		BEGIN TRY
			-- Create a tiny XML containing just the root node
			SET @DataChunkXml = '<' + @RootNodeName + ' />'
			SET @RootNodeName = CAST(@DataChunkXml.query('local-name(/*[1])') AS varchar(255))
			SET @RootNodeNs = CAST(@DataChunkXml.query('namespace-uri(/*[1])') AS varchar(255)) 
			
			-- Check if we were able to extract the root node's local name and namespace
			IF LEN(COALESCE(@RootNodeName, '')) > 0 AND LEN(COALESCE(@RootNodeNs, '')) > 0 BEGIN
				SET @IsXml = 1
				SET @QueueItemType = @RootNodeNs + '#' + @RootNodeName
			END
	    END	TRY
		BEGIN CATCH
			SET @IsXml = 0
		END	CATCH
	END
END

UPDATE app.PersistenceQueue
	SET QueueItemStatus = 1 /* Status = Available */,
		@QueueItemSize = CASE WHEN QueueItemDataXml IS NOT NULL THEN DATALENGTH(QueueItemDataXml) ELSE DATALENGTH(QueueItemDataRaw) END,
		QueueItemSize = @QueueItemSize,
		QueueItemDataXml = CASE WHEN @IsXml = 1 THEN QueueItemDataRaw ELSE QueueItemDataXml END,
		QueueItemDataType = CASE WHEN @IsXml = 1 THEN @QueueItemType ELSE QueueItemDataType END,
		QueueItemDataRaw = CASE WHEN @IsXml = 1 THEN NULL ELSE QueueItemDataRaw END,
		QueueItemLastUpdated = GETDATE()
	WHERE QueueItemID = @QueueItemID

