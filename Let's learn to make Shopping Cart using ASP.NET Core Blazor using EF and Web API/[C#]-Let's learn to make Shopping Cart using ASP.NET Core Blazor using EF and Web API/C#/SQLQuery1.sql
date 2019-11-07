-- =============================================  
-- Author : Shanu  
-- Create date : 2017-02-03
-- Description : To Create Database,Table and Sample Insert Query  
-- Latest  
-- Modifier : Shanu  
-- Modify date : 2017-02-03  
-- ============================================= 
--Script to create DB,Table and sample Insert data 
USE MASTER 
GO 
-- 1) Check for the Database Exists .If the database is exist then drop and create new DB 
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'ShoppingDB' ) 
DROP DATABASE ShoppingDB 
GO 
 
CREATE DATABASE ShoppingDB 
GO 
 
USE ShoppingDB 
GO 
 
-- 1) //////////// ItemDetails table 
-- Create Table ItemDetails,This table will be used to store the details like Item Information  
 
IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'ItemDetails' ) 
DROP TABLE ItemDetails 
GO 
 
CREATE TABLE ItemDetails 
( 
Item_ID int identity(1,1), 
Item_Name VARCHAR(100) NOT NULL, 
Item_Price int NOT NULL, 
Image_Name VARCHAR(100) NOT NULL, 
Description VARCHAR(100) NOT NULL, 
AddedBy VARCHAR(100) NOT NULL, 
CONSTRAINT [PK_ItemDetails] PRIMARY KEY CLUSTERED  
(  
[Item_ID] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
 
GO 
 
-- Insert the sample records to the ItemDetails Table 
-- Insert the sample records to the ItemDetails Table 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('Access Point',950,'Images/AccessPoint.png','Access Point for Wifi use','Shanu') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('CD',350,'Images/CD.png','Compact Disk','Afraz') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('Desktop Computer',1400,'Images/DesktopComputer.png','Desktop Computer','Shanu') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('DVD',1390,'Images/DVD.png','Digital Versatile Disc','Raj') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('DVD Player',450,'Images/DVDPlayer.png','DVD Player','Afraz') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('Floppy',1250,'Images/Floppy.png','Floppy','Mak') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('HDD',950,'Images/HDD.png','Hard Disk','Albert') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('MobilePhone',1150,'Images/MobilePhone.png','Mobile Phone','Gowri') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('Mouse',399,'Images/Mouse.png','Mouse','Afraz') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('MP3 Player ',897,'Images/MultimediaPlayer.png','Multi MediaPlayer','Shanu') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('Notebook',750,'Images/Notebook.png','Notebook','Shanu') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('Printer',675,'Images/Printer.png','Printer','Kim') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('RAM',1950,'Images/RAM.png','Random Access Memory','Jack') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('Smart Phone',679,'Images/SmartPhone.png','Smart Phone','Lee') 
Insert into ItemDetails(Item_Name,Item_Price,Image_Name,Description,AddedBy) values('USB',950,'Images/USB.png','USB','Shanu') 
 
select * from ItemDetails



CREATE TABLE ShoppingDetails 
( 
shopId int identity(1,1), 
Item_ID int , 
UserName VARCHAR(100) NOT NULL, 
Qty int NOT NULL, 
TotalAmount int, 
Description VARCHAR(200) NOT NULL, 
shoppingDate DateTime, 
CONSTRAINT [PK_ShoppingDetails] PRIMARY KEY CLUSTERED  
(  
[shopId] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  

select * from ShoppingDetails