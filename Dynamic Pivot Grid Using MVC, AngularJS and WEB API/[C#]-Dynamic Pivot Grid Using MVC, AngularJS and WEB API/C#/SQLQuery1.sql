-- =============================================                              
-- Author      : Shanu                                
-- Create date : 2015-11-20                              
-- Description : To Create Database,Table and Sample Insert Query                            
-- Latest                               
-- Modifier    : Shanu                               
-- Modify date : 2015-11-20                            
-- =============================================
--Script to create DB,Table and sample Insert data
USE MASTER;
-- 1) Check for the Database Exists .If the database is exist then drop and create new DB
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'ToysDB' )
BEGIN
ALTER DATABASE ToysDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE ToysDB ;
END


CREATE DATABASE ToysDB
GO

USE ToysDB
GO

-- 1) //////////// ToysDetails table

-- Create Table  ToysDetails ,This table will be used to store the details like Toys Information

IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'ToysSalesDetails' )
DROP TABLE ToysSalesDetails
GO

CREATE TABLE ToysSalesDetails
(
   Toy_ID int  identity(1,1),
   Toy_Type VARCHAR(100)  NOT NULL,
   Toy_Name VARCHAR(100)  NOT NULL, 
   Toy_Price int  NOT NULL,
   Image_Name VARCHAR(100)  NOT NULL,
   SalesDate DateTime  NOT NULL,
   AddedBy VARCHAR(100)  NOT NULL,
CONSTRAINT [PK_ToysSalesDetails] PRIMARY KEY CLUSTERED     
(    
  [Toy_ID] ASC    
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]    
) ON [PRIMARY]  

GO

--delete from ToysSalesDetails
-- Insert the sample records to the ToysDetails Table
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Spiderman',1650,'ASpiderman.png',getdate(),'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Spiderman',1250,'ASpiderman.png',getdate()-6,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Superman',1450,'ASuperman.png',getdate(),'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Superman',850,'ASuperman.png',getdate()-4,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Thor',1350,'AThor.png',getdate(),'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Thor',950,'AThor.png',getdate()-8,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Wolverine',1250,'AWolverine.png',getdate(),'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Wolverine',450,'AWolverine.png',getdate()-3,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','CaptainAmerica',1100,'ACaptainAmerica.png',getdate(),'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Spiderman',250,'ASpiderman.png',getdate()-120,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Spiderman',1950,'ASpiderman.png',getdate()-40,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Superman',1750,'ASuperman.png',getdate()-40,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Thor',900,'AThor.png',getdate()-100,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Thor',850,'AThor.png',getdate()-50,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Wolverine',250,'AWolverine.png',getdate()-80,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','CaptainAmerica',800,'ACaptainAmerica.png',getdate()-60,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Superman',1950,'ASuperman.png',getdate()-80,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Thor',1250,'AThor.png',getdate()-30,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Action','Wolverine',850,'AWolverine.png',getdate()-20,'Shanu')

Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Animal','Lion',1250,'Lion.png',getdate(),'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Animal','Lion',950,'Lion.png',getdate()-4,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Animal','Tiger',1900,'Tiger.png',getdate(),'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Animal','Tiger',600,'Tiger.png',getdate()-2,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Animal','Panda',650,'Panda.png',getdate(),'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Animal','Panda',1450,'Panda.png',getdate()-1,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Animal','Dog',200,'Dog.png',getdate(),'Shanu')

Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Animal','Lion',450,'Lion.png',getdate()-20,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Animal','Tiger',400,'Tiger.png',getdate()-90,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Animal','Panda',550,'Panda.png',getdate()-120,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Animal','Dog',1200,'Dog.png',getdate()-60,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Animal','Lion',450,'Lion.png',getdate()-90,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Animal','Tiger',400,'Tiger.png',getdate()-30,'Shanu')


Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Bird','Owl',600,'BOwl.png',getdate(),'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Bird','Greenbird',180,'BGreenbird.png',getdate(),'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Bird','Thunderbird',550,'BThunderbird-v2.png',getdate(),'Shanu')

Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Bird','Owl',600,'BOwl.png',getdate()-50,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Bird','Greenbird',180,'BGreenbird.png',getdate()-90,'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Bird','Thunderbird',550,'BThunderbird-v2.png',getdate()-120,'Shanu')

Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Car','SingleSeater',1600,'CSingleSeater.png',getdate(),'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Car','Mercedes',2400,'CMercedes.png',getdate(),'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Car','FordGT',1550,'CFordGT.png',getdate(),'Shanu')
Insert into ToysSalesDetails(Toy_Type,Toy_Name,Toy_Price,Image_Name,SalesDate,AddedBy) values('Car','Bus',700,'CBus.png',getdate(),'Shanu')

select *,
SUBSTRING('JAN FEB MAR APR MAY JUN JUL AUG SEP OCT NOV DEC ', (DATENAME(month, SalesDate)  * 4) - 3, 3) as 'Month'
 from ToysSalesDetails 
  Where YEAR(SalesDate)=YEAR(getdate())
  Order by Toy_Type,Toy_Name,Image_Name,SalesDate

-- 1) END //


-- 1) Stored procedure to Select ToysSalesDetails
-- Author      : Shanu                                                             
-- Create date : 2015-11-20                                                              
-- Description : Toy Sales Details                                              
-- Tables used :  ToysSalesDetails                                                              
-- Modifier    : Shanu                                                               
-- Modify date : 2015-11-20                                                                  
-- =============================================  
-- exec USP_ToySales_Select '',''
-- =============================================                                                          
CREATE PROCEDURE [dbo].[USP_ToySales_Select]                                            
   (                          
     @Toy_Type           VARCHAR(100)     = '',
     @Toy_Name               VARCHAR(100)     = ''  
      )                                                      
AS                                                              
BEGIN      
         select  Toy_Type as ToyType
				,Toy_Name as ToyName
				,Image_Name as ImageName
				,Toy_Price as Price
				,AddedBy as 'User'
				,DATENAME(month, SalesDate) as 'Month'
				
		 FROM ToysSalesDetails 
		  Where   
					Toy_Type like  @Toy_Type +'%'
				AND Toy_Name like @Toy_Name +'%'
				AND YEAR(SalesDate)=YEAR(getdate())
		  ORDER BY
			  Toy_Type,Toy_Name,SalesDate
         
END