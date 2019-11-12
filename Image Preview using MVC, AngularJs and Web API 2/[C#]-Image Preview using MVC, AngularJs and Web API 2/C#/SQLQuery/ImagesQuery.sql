-- =============================================                                
-- Author      : Shanu                                
-- Create date : 2015-05-15                                  
-- Description : To Create Database,Table and Sample Insert Query                             
-- Latest                                
-- Modifier    : Shanu                                
-- Modify date : 2015-05-15                            
-- =============================================
--Script to create DB,Table and sample Insert data
USE MASTER
GO
-- 1) Check for the Database Exists .If the database is exist then drop and create new DB
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'ImageDB' )
DROP DATABASE DynamicProject
GO

CREATE DATABASE ImageDB
GO

USE ImageDB
GO

-- 1) //////////// ItemMasters

IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'ImageDetails' )
DROP TABLE ImageDetails
GO

CREATE TABLE [dbo].[ImageDetails](
	[ImageID] INT IDENTITY PRIMARY KEY,
	[Image_Path] [varchar](100) NOT NULL,	
	[Description] [varchar](200) NOT NULL)
 

INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('1.jpg','Afreen')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('2.jpg','Purple Tulip')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('3.jpg','Afreen')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('4.jpg','Tulip')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('5.jpg','Tulip')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('6.jpg','Flowers')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('7.jpg','Flowers')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('8.jpg','Flowers')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('9.jpg','Flowers')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('10.jpg','Flowers')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('11.jpg','Afraz&Afreen')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('12.jpg','LoveLock')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('13.jpg','Rose')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('14.jpg','Yellow Rose')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('15.jpg','Red rose')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('16.jpg','Cherry blossom')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('17.jpg','Afreen')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('18.jpg','fish Market')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('19.jpg','Afraz')

                 
select * from [ImageDetails]

