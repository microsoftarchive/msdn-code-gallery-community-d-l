-- =============================================                                
-- Author      : Shanu                                
-- Create date : 2015-03-20                                
-- Description : To Create Database,Table and Sample Insert Query                             
-- Latest                                
-- Modifier    : Shanu                                
-- Modify date : 2015-03-20                            
-- =============================================
--Script to create DB,Table and sample Insert data
USE MASTER
GO
-- 1) Check for the Database Exists .If the database is exist then drop and create new DB
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'DynamicProject' )
DROP DATABASE DynamicProject
GO

CREATE DATABASE DynamicProject
GO

USE DynamicProject
GO

-- 1) //////////// ItemMasters

IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'ItemMasters' )
DROP TABLE ItemMasters
GO

CREATE TABLE [dbo].[ItemMasters](
	[Item_Code] [varchar](20) NOT NULL,
	[Item_Name] [varchar](100) NOT NULL,
	[Price] [int] NOT NULL,
	[TAX1] [int] NOT NULL,
	[Discount] [int] NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[IN_DATE] [datetime] NOT NULL,
	[IN_USR_ID] [varchar](20) NOT NULL,
	[UP_DATE] [datetime] NOT NULL,
	[UP_USR_ID] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ItemMasters] PRIMARY KEY CLUSTERED 
(
	[Item_Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT INTO [DynamicProject].[dbo].[ItemMasters]
           ([Item_Code],[Item_Name],[Price],[TAX1],[Discount],[Description],[IN_DATE],[IN_USR_ID],[UP_DATE],[UP_USR_ID])
     VALUES
           ('Item001','Coke',55,1,0,'Coke which need to be cold','2014-12-12 08:18:14.740','USR002','2015-01-17 09:24:48.503','Shanu')
                 
 
INSERT INTO [DynamicProject].[dbo].[ItemMasters]
           ([Item_Code],[Item_Name],[Price],[TAX1],[Discount],[Description],[IN_DATE],[IN_USR_ID],[UP_DATE],[UP_USR_ID])
     VALUES
           ('Item002','Coffee',40,0,2,'Coffe Might be Hot or Cold user choice','2014-12-12 08:18:14.740','USR002','2015-01-17 09:24:48.503','USR001')                
                            
INSERT INTO [DynamicProject].[dbo].[ItemMasters]
           ([Item_Code],[Item_Name],[Price],[TAX1],[Discount],[Description],[IN_DATE],[IN_USR_ID],[UP_DATE],[UP_USR_ID])
     VALUES
           ('Item003','Chicken Burger',87,2,1,'Spicy','2014-12-12 08:18:14.740','USR003','2015-01-17 09:24:48.503','SHANU')                            			
           
INSERT INTO [DynamicProject].[dbo].[ItemMasters]
           ([Item_Code],[Item_Name],[Price],[TAX1],[Discount],[Description],[IN_DATE],[IN_USR_ID],[UP_DATE],[UP_USR_ID])
     VALUES
           ('Item004','Potato Fry',35,3,1,'Hot','2014-12-12 08:18:14.740','Shanu','2015-01-17 09:24:48.503','USR001')           
           
           
           
           
--    2) User Table Creation

IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'UserMasters' )
DROP TABLE UserMasters
GO

CREATE TABLE [dbo].[UserMasters](
	[USR_ID] [varchar](20) NOT NULL,
	[User_Name] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Address] [varchar](300) NOT NULL
 CONSTRAINT [PK_UserMasters] PRIMARY KEY CLUSTERED 
(
	[USR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
             
  INSERT INTO [DynamicProject].[dbo].[UserMasters]
           ([USR_ID],[User_Name],[Email],[Phone],[Address])
     VALUES
           ('USR001','SAHNU','syedshanumcain@gmail.com','01030550000','From India Lives In Korea')                      
           
   select * from UserMasters