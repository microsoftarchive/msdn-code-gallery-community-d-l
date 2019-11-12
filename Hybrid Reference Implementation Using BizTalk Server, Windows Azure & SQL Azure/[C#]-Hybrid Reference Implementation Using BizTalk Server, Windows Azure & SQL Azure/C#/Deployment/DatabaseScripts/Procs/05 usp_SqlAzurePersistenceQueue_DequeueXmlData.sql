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
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SqlAzurePersistenceQueue_DequeueXmlData]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_SqlAzurePersistenceQueue_DequeueXmlData]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_SqlAzurePersistenceQueue_DequeueXmlData]
	@QueueItemID uniqueidentifier,
	@Namespace1 nvarchar(255),
	@Namespace2 nvarchar(255) = NULL,
	@Namespace3 nvarchar(255) = NULL,
	@Namespace4 nvarchar(255) = NULL,
	@Namespace5 nvarchar(255) = NULL,
	@Namespace6 nvarchar(255) = NULL,
	@Namespace7 nvarchar(255) = NULL,
	@Namespace8 nvarchar(255) = NULL,
	@Namespace9 nvarchar(255) = NULL,
	@Namespace10 nvarchar(255) = NULL,
	@HeaderXPath1 nvarchar(255) = NULL,
	@HeaderXPath2 nvarchar(255) = NULL,
	@HeaderXPath3 nvarchar(255) = NULL,
	@BodyXPath1 nvarchar(255),
	@BodyXPath2 nvarchar(255) = NULL,
	@BodyXPath3 nvarchar(255) = NULL,
	@FooterXPath1 nvarchar(255) = NULL,
	@FooterXPath2 nvarchar(255) = NULL,
	@FooterXPath3 nvarchar(255) = NULL,
	@Debug bit = 0
AS

SET NOCOUNT ON

DECLARE @QueueItemDataXml xml, @XmlQuery nvarchar(4000), @RootNodeName nvarchar(255), @RootNodeNs nvarchar(255), @WhiteSpace char(2), @SingleQuote char(1), @DoubleQuote char(2)
DECLARE @NamespaceList TABLE (NsName nvarchar(255), NsPrefix nvarchar(255))

SELECT @QueueItemDataXml = QueueItemDataXml FROM app.PersistenceQueue WHERE QueueItemID = @QueueItemID

IF @QueueItemDataXml IS NOT NULL BEGIN
	SELECT @WhiteSpace = char(13) + char(10), @SingleQuote = '''', @DoubleQuote = ''''''
	SET @RootNodeName = CAST(@QueueItemDataXml.query('local-name(/*[1])') AS varchar(255))
	SET @RootNodeNs = COALESCE(CAST(@QueueItemDataXml.query('namespace-uri(/*[1])') AS varchar(255)), '')
	
	SET @XmlQuery = 'declare namespace rootns="' + @RootNodeNs + '";' + @WhiteSpace
	
	INSERT @NamespaceList(NsName, NsPrefix) SELECT [dbo].[udf_ExtractNamespaceName](@Namespace1), [dbo].[udf_ExtractNamespacePrefix](@Namespace1)
	INSERT @NamespaceList(NsName, NsPrefix) SELECT [dbo].[udf_ExtractNamespaceName](@Namespace2), [dbo].[udf_ExtractNamespacePrefix](@Namespace2)
	INSERT @NamespaceList(NsName, NsPrefix) SELECT [dbo].[udf_ExtractNamespaceName](@Namespace3), [dbo].[udf_ExtractNamespacePrefix](@Namespace3)
	INSERT @NamespaceList(NsName, NsPrefix) SELECT [dbo].[udf_ExtractNamespaceName](@Namespace4), [dbo].[udf_ExtractNamespacePrefix](@Namespace4)
	INSERT @NamespaceList(NsName, NsPrefix) SELECT [dbo].[udf_ExtractNamespaceName](@Namespace5), [dbo].[udf_ExtractNamespacePrefix](@Namespace5)
	INSERT @NamespaceList(NsName, NsPrefix) SELECT [dbo].[udf_ExtractNamespaceName](@Namespace6), [dbo].[udf_ExtractNamespacePrefix](@Namespace6)
	INSERT @NamespaceList(NsName, NsPrefix) SELECT [dbo].[udf_ExtractNamespaceName](@Namespace7), [dbo].[udf_ExtractNamespacePrefix](@Namespace7)
	INSERT @NamespaceList(NsName, NsPrefix) SELECT [dbo].[udf_ExtractNamespaceName](@Namespace8), [dbo].[udf_ExtractNamespacePrefix](@Namespace8)
	INSERT @NamespaceList(NsName, NsPrefix) SELECT [dbo].[udf_ExtractNamespaceName](@Namespace9), [dbo].[udf_ExtractNamespacePrefix](@Namespace9)
	INSERT @NamespaceList(NsName, NsPrefix) SELECT [dbo].[udf_ExtractNamespaceName](@Namespace10), [dbo].[udf_ExtractNamespacePrefix](@Namespace10)
	
	SELECT @XmlQuery = @XmlQuery + 'declare' +
		(CASE
			WHEN LEN(COALESCE(NsPrefix, '')) > 0 THEN ' namespace ' + NsPrefix + '='
			ELSE ' default element namespace '
		END) + '"' + NsName + '";' + @WhiteSpace
		FROM @NamespaceList
		WHERE NsName IS NOT NULL
	
	SET @XmlQuery = @XmlQuery + '<rootns:' + @RootNodeName + '>' + @WhiteSpace
	
	IF LEN(COALESCE(@HeaderXPath1, '')) > 0 SET @XmlQuery = @XmlQuery + '{' + REPLACE(@HeaderXPath1, @SingleQuote, @DoubleQuote) + '}' + @WhiteSpace
	IF LEN(COALESCE(@HeaderXPath2, '')) > 0 SET @XmlQuery = @XmlQuery + '{' + REPLACE(@HeaderXPath2, @SingleQuote, @DoubleQuote) + '}' + @WhiteSpace
	IF LEN(COALESCE(@HeaderXPath3, '')) > 0 SET @XmlQuery = @XmlQuery + '{' + REPLACE(@HeaderXPath3, @SingleQuote, @DoubleQuote) + '}' + @WhiteSpace
	
	IF LEN(COALESCE(@BodyXPath1, '')) > 0 SET @XmlQuery = @XmlQuery + '{' + REPLACE(@BodyXPath1, @SingleQuote, @DoubleQuote) + '}' + @WhiteSpace
	IF LEN(COALESCE(@BodyXPath2, '')) > 0 SET @XmlQuery = @XmlQuery + '{' + REPLACE(@BodyXPath2, @SingleQuote, @DoubleQuote) + '}' + @WhiteSpace
	IF LEN(COALESCE(@BodyXPath3, '')) > 0 SET @XmlQuery = @XmlQuery + '{' + REPLACE(@BodyXPath3, @SingleQuote, @DoubleQuote) + '}' + @WhiteSpace
	
	IF LEN(COALESCE(@FooterXPath1, '')) > 0 SET @XmlQuery = @XmlQuery + '{' + REPLACE(@FooterXPath1, @SingleQuote, @DoubleQuote) + '}' + @WhiteSpace
	IF LEN(COALESCE(@FooterXPath2, '')) > 0 SET @XmlQuery = @XmlQuery + '{' + REPLACE(@FooterXPath2, @SingleQuote, @DoubleQuote) + '}' + @WhiteSpace
	IF LEN(COALESCE(@FooterXPath3, '')) > 0 SET @XmlQuery = @XmlQuery + '{' + REPLACE(@FooterXPath3, @SingleQuote, @DoubleQuote) + '}' + @WhiteSpace
	
	SET @XmlQuery = @XmlQuery + '</rootns:' + @RootNodeName + '>'
	SET @XmlQuery = 'SELECT @ItemDataXml.query(''' + @XmlQuery + ''')'
	
	IF @Debug = 1 PRINT @XmlQuery

	-- Use READ UNCOMMITTED level to improve concurrency and reduce the amount of shared locks.
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	
	EXEC sp_executesql @statement = @XmlQuery, @params = N'@ItemDataXml xml', @ItemDataXml = @QueueItemDataXml
END