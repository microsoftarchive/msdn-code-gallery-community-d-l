USE [ForumExample]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Team] [nvarchar](max) NULL,
	[Position] [nvarchar](max) NULL,
	[Height] [int] NULL,
	[Weight] [int] NULL,
	[Age] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
TRUNCATE TABLE dbo.Players