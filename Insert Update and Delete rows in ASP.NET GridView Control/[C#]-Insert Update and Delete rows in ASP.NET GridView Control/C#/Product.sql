
/****** Object:  Table [dbo].[Product]    Script Date: 07/07/2012 02:18:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Product](
	[pk_id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [varchar](5) NULL,
	[ProductName] [varchar](50) NULL,
	[ProductPrice] [numeric](8, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[pk_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

