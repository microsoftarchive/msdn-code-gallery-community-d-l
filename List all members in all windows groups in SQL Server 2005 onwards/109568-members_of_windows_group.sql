SET NOEXEC OFF
GO
DECLARE @dbUserName VARCHAR(MAX)
DECLARE @userSID VARBINARY(200), @insertSQL1 VARCHAR(MAX)
DECLARE @gName VARCHAR(200),
@userName VARCHAR(100),
@isMember BIT,
@serverRole VARCHAR(100)

IF OBJECT_ID('tempdb..#allPer') IS NOT NULL
DROP TABLE #allPer

CREATE TABLE #allPer
(
account_name NVARCHAR(100) NULL 
,type	nvarchar(25) NULL 	 
,privilege	nvarchar(25) NULL 	     
,mapped_login_name	nvarchar(100) NULL     	     
,permission_path nvarchar(100) NULL 
 )

DECLARE curName CURSOR 
FOR 
SELECT TOP 10 name FROM sys.server_principals WHERE type_desc='WINDOWS_GROUP' AND NAME NOT IN ('list unwanted groups')

OPEN curName 
      
      FETCH NEXT FROM curName INTO @gName
      
      WHILE @@FETCH_STATUS = 0
      BEGIN  
      PRINT @gName
      INSERT INTO #allPer
      EXEC master..xp_logininfo @gName, 'members'

       FETCH NEXT FROM curName INTO @gName
      END

      
CLOSE curName 
DEALLOCATE curName 

SELECT * FROM #allPer

