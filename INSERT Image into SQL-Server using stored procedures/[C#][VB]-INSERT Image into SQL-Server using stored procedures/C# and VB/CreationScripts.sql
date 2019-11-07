--
-- This file contains several scripts to create the database table and stored procedures
-- needed by the projects in the solution.
--
-- Highlight a script in SQL-Server Management Studio or here and execute the script, repeat
-- until all scripts have executed without error.
--
-- Make sure to select the database in script one for the stored procedures else they 
-- fail to create or are created in the incorrect database.
--


/*
	Create database table script.
*/
--USE YOUR DATABASE
--GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImageData](
	[ImageID] [INT] IDENTITY(1,1) NOT NULL,
	[ImageData] [IMAGE] NULL,
	[Description] [NVARCHAR](MAX) NULL,
 CONSTRAINT [PK_ImageData] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
--- End creation of database table



/*
	Create stored procedure in the database above to read all image primary keys
*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[ReadAllImageIDs] AS 
SELECT ImageID FROM ImageData 

GO
--- End creation of stored procedure


/*
	Create stored procedure in the database above to read all records
*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[ReadAllRecords] AS 
SELECT ImageID, ImageData,[Description] FROM ImageData 


GO
--- End creation of stored procedure


/*
	Create stored procedure for returning an image by primary key
*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[ReadImage] @imgId INT AS 
SELECT ImageData, Description FROM ImageData 
WHERE ImageID=@imgId 
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--- End creation of stored procedure


/*
	Create stored procedure for saving a single image
	to the database table.
*/
CREATE PROC [dbo].[SaveImage]
    @img IMAGE ,
	@description NVARCHAR(MAX),
    @new_identity INT OUTPUT
AS
    BEGIN
        INSERT  INTO dbo.ImageData ( ImageData, [Description]) VALUES  ( @img, @description );
        SELECT  @new_identity = SCOPE_IDENTITY();
        SELECT  @new_identity AS id;
        RETURN;
    END;
GO

------------------------------------------------------------------------------
-- If playing around and want to reset the table data use , be forewarned there are no warnings,
-- executing this will remove all data and reset the primary key.
--
-- TRUNCATE TABLE [dbo].[ImageData]
--





