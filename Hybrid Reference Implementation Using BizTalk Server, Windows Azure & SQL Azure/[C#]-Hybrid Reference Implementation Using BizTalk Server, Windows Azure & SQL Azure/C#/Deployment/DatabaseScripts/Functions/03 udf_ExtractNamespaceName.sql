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
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udf_ExtractNamespaceName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[udf_ExtractNamespaceName]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION udf_ExtractNamespaceName
(
	@Value nvarchar(255)
)
RETURNS nvarchar(255)
AS
BEGIN
	DECLARE @DelimPos int
	
	IF LEN(COALESCE(@Value, '')) > 0 BEGIN
		SET @DelimPos = CHARINDEX(':', @Value)
		
		IF @DelimPos > 0 AND @DelimPos < LEN(@Value) RETURN SUBSTRING(@Value, @DelimPos + 1 , LEN(@Value) - @DelimPos)
	END
	
	RETURN NULL
END
GO

