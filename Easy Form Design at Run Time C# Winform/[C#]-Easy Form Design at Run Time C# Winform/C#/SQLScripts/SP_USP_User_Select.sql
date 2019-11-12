USE [DynamicProject]
GO
/****** Object:  StoredProcedure [dbo].[USP_Item_Select]    Script Date: 04/16/2015 16:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author      : Shanu                                                                  
-- Create date : 2015-02-05                                                                  
-- Description : To Select Item Master                                                
-- Tables used :  ItemMasters                                                                 
-- Modifier    : Shanu                                                                  
-- Modify date : 2015-02-05                                                                  
-- =============================================                                                                  
-- exec USP_User_Select '',''      
-- =============================================                                                             
Create PROCEDURE [dbo].[USP_User_Select]                                                
   (        
     @USR_ID          VARCHAR(50)     = '',                              
     @User_Name     VARCHAR(50)     = ''
      )                                                          
AS                                                                  
BEGIN                  

   Select [USR_ID],
   [User_Name],
   [Email],
   [Phone],
   [Address]  
   FROM   
    UserMasters   
   WHERE  
    USR_ID like  @USR_ID +'%'  
    AND User_Name like @User_Name +'%'  
   ORDER BY  
    User_Name
  
 
END  