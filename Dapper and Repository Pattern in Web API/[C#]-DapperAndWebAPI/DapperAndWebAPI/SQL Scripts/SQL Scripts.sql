
--Create Tables
CREATE TABLE [dbo].[NextPosts](
	[PostId] [int] NOT NULL,
	[PostTitle] [nvarchar](500) NULL,
	[ShortPostContent] [ntext] NULL,
	[FullPostContent] [ntext] NULL,
	[MetaKeywords] [nvarchar](255) NULL,
	[MetaDescription] [nvarchar](500) NULL,
	[PostAddedDate] [smalldatetime] NOT NULL,
	[PostUpdatedDate] [smalldatetime] NOT NULL,
	[IsCommented] [bit] NOT NULL,
	[IsShared] [bit] NOT NULL,
	[IsPrivate] [bit] NOT NULL,
	[NumberOfViews] [int] NOT NULL,	
	[PostUrl] [nvarchar](255) NULL,	
	[CategoryId] [int] NOT NULL
	
)

-- Stored Procedure
CREATE PROC [dbo].[usp_GetAllBlogPostByPageIndex](@PageIndex Int, @PageSize INT)
AS
BEGIN
	SELECT * FROM NextPosts ORDER BY PostId OFFSET((@PageIndex-1)*@PageSize) ROWS
	FETCH NEXT @PageSize ROWS ONLY;
END
GO


