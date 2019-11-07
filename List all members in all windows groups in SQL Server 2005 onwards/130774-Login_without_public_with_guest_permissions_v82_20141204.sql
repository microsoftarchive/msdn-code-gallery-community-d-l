/*
Give the login for which you want to find the permissions
if the given login is sysadmin for sql login
This script is working fine for finding the access through
groups or individuals
To find the all logins and permisisons on particular DB
@userName = NULL

To find the all logins and permisisons on ALL DB
@userName = NULL AND disable name for sys.databases

*/

SET NOCOUNT ON 
SET NOEXEC OFF 
GO

DECLARE 
@userName VARCHAR(100),
@SeePermissions int

IF OBJECT_ID('tempdb..#allDBs') IS NOT NULL
DROP TABLE #allDBs

CREATE TABLE #allDBs
(
dbName VARCHAR(MAX) NULL 
)

/*************************************************************************************
GIVE the SERVER LOGIN (WINDWOS USER OR GROUP OR SQ LLOGIN) to find the permissions
*************************************************************************************/
--=============================================
SET @userName = 'dev0' --NULL --'sjm\adm_veerab01'      -- retrive all logins permissions per the cuurent database
SET @SeePermissions = 1					-- 0 - print stmt 1 - display the permissions
--=============================================

INSERT INTO #allDBs
SELECT name 
FROM sys.databases 
WHERE 
state_desc = 'ONLINE'
--and name NOT IN ('master','model','msdb','tempdb')
--and name in ('Brahma') 
ORDER BY name --DESC

DECLARE 
@dbUserName VARCHAR(200),
@userSID VARBINARY(200), 
@insertSQL1 VARCHAR(200),
@gName VARCHAR(200),
@isMember BIT,
@serverRole VARCHAR(1000),
@grpName VARCHAR(4000),
@groupUserType VARCHAR(10),
@printstmt NVARCHAR(MAX),
@serverprint NVARCHAR(MAX),
@rowcount int,
@error int,
@serverroledef varchar(max),
@newcolumn varchar(max),
@serverLoginExec varchar(max),
@databaseUserExec varchar(max),
@predatabaseUserExec varchar(max),
@dbName varchar(500),
@SQLString nvarchar(MAX),
@ParmDefinition nvarchar(MAX),
@dbPerCount VARCHAR(MAX),
@dboUserName VARCHAR(200), 
@assignedRole VARCHAR(200), 
@loginName VARCHAR(200), 
@loginSID VARBINARY(200);

declare 
@cr char(1), 
@lf char(1)
set @cr = char(13)
set @lf = char(10)

declare 
@len int, 
@cr_index int, 
@lf_index int,
@crlf_index int, 
@has_cr_and_lf bit,
@left nvarchar(4000), 
@reverse nvarchar(4000)
set @len = 4000

SET @dbPerCount = ''


--store the no of permissions per user per db
IF OBJECT_ID('tempdb..#perDBUser') IS NOT NULL
DROP TABLE #perDBUser

CREATE TABLE #perDBUser
(
noOfexec INT NULL,
userName VARCHAR(200) NULL,
principalName VARCHAR(200) NULL,
dbName VARCHAR(200) NULL
)


IF OBJECT_ID('tempdb..#allPer') IS NOT NULL
DROP TABLE #allPer

CREATE TABLE #allPer
(
actual_user NVARCHAR(100) NULL 
,principal_name	nvarchar(256) NULL 	     
,principal_type_desc	nvarchar(120) NULL 	 
,database_name	nvarchar(256) NULL 	     
,class_desc	nvarchar(120) NULL     	     
,object_name	nvarchar(256) NULL 	     	 
,permission_name	nvarchar(256) NULL 	 
,permission_state char(2) NULL     
,permission_state_desc	nvarchar(120) NULL 
,role_name	sysname NULL 
 )

 IF OBJECT_ID('tempdb..#loginInfo') IS NOT NULL
DROP TABLE #loginInfo

CREATE TABLE #loginInfo
(
account_name NVARCHAR(100) NULL 
,type	nvarchar(25) NULL 	 
,privilege	nvarchar(25) NULL 	     
,mapped_login_name	nvarchar(100) NULL     	     
,permission_path nvarchar(100) NULL 
 )

 IF OBJECT_ID('tempdb..#serverlogins') IS NOT NULL
DROP TABLE #serverlogins

create table #serverlogins
(
RequestedUser	varchar(500) null,
name			sysname,
type_desc		nvarchar(120),
[public]		varchar(3),
sysadmin		varchar(3),
securityadmin	varchar(3),
serveradmin		varchar(3),
setupadmin		varchar(3),
processadmin	varchar(3),
diskadmin		varchar(3),
dbcreator		varchar(3),
ControlServer	varchar(3))

IF EXISTS(SELECT * FROM sys.server_principals WHERE name=coalesce(@userName, name) AND type_desc='SQL_LOGIN')
BEGIN
INSERT INTO #loginInfo
SELECT name, NULL, NULL, NULL, NULL 
FROM sys.server_principals 
WHERE name=coalesce(@userName, name) AND type_desc='SQL_LOGIN'
END
ELSE
BEGIN
BEGIN TRY
INSERT INTO #loginInfo
EXEC master..xp_logininfo @userName, 'all'
SELECT @rowcount = @@ROWCOUNT, @error = @@ERROR
END TRY
BEGIN CATCH
IF CHARINDEX('\',@userName,0) = 0
PRINT @userName + ' IS NOT VALID SQL LOGIN'
ELSE
PRINT @userName + ' IS NOT VALID WINDOWS LOGIN or GROUP' + CHAR(10) + 'ERROR: ' + ERROR_MESSAGE()
SET	NOEXEC ON 
END CATCH 
END

IF @userName = ''
BEGIN 
PRINT '-- ' + 'empty string for @userName'
SET NOEXEC ON 
END
ELSE IF EXISTS(SELECT TOP 1 * FROM #loginInfo WHERE privilege='admin' AND permission_path IS NULL)
BEGIN
PRINT '-- ' + @userName + ' user is member of *SYSADMIN* server role'
END 
ELSE IF EXISTS(SELECT * FROM #loginInfo WHERE privilege='admin' AND permission_path IS NOT NULL)
BEGIN
SELECT @grpName= COALESCE(@grpName + ''', ''', '') + permission_path FROM #loginInfo WHERE privilege='admin' AND permission_path IS NOT NULL
PRINT '-- ' + @userName + ' user is member of *SYSADMIN* server role through ''' + @grpName + ''' group(s)'
END
ELSE IF EXISTS(SELECT * FROM #loginInfo WHERE privilege='user' AND permission_path IS NOT NULL)
BEGIN
SELECT @grpName= COALESCE(@grpName + ''', ''' ,'') + permission_path + CHAR(10) FROM #loginInfo WHERE privilege='user' AND permission_path IS NOT NULL
PRINT '-- ' + @userName + ' user is WINDOWS USER and member of ''' + @grpName + ''' group(s)'
END
ELSE IF EXISTS(SELECT * FROM #loginInfo WHERE privilege='user' AND type='user' AND permission_path IS NULL)
BEGIN
PRINT '-- ' + @userName + ' user is WINDOWS USER' 
END
ELSE IF EXISTS(SELECT * FROM #loginInfo WHERE privilege='user' AND type='group' AND permission_path IS NULL)
BEGIN
PRINT '-- ' + @userName + ' user is WINDOWS GROUP' 
END
ELSE IF (@error = 0 )
BEGIN
PRINT '-- ' + @userName + ' - may be INVALID Domain Account OR It Doesn''t have SQL Access'
END
ELSE
BEGIN
PRINT '-- ' + @userName + ' is SQL USER'
END

---LOGIN PERMISSION DETAILS 
select @serverRole= coalesce(@serverRole+',','') + quotename(name) 
from sys.server_principals 
where type_desc='server_role'

select @serverroledef= coalesce(@serverroledef + CHAR(10), '') + 'CASE WHEN [' + name + ']=1 THEN ''YES'' ELSE ''N'' END AS ''' + name + ''','
from sys.server_principals 
where type_desc='server_role'

set @serverLoginExec = (';WITH CTE_Role (RequestedUser,name,role,type_desc)
AS
(SELECT ''' + ISNULL(@userName,'NULL') + ''' as RequestedUser, PRN.name,
srvrole.name AS [role] , 
PRN.Type_Desc 
FROM sys.server_role_members membership 
INNER JOIN (SELECT * FROM sys.server_principals  WHERE type_desc=''SERVER_ROLE'') srvrole 
ON srvrole.principal_id= membership.Role_principal_id 
RIGHT JOIN sys.server_principals  PRN 
ON PRN.Principal_id= membership.member_principal_id 
where PRN.name in (''' + ISNULL(@userName,'NULL') + ''', '''+ ISNULL(@grpName,'') + ''')
OR PRN.name = coalesce(''' + ISNULL(@userName, 'NULL') + ''', PRN.name)
UNION ALL
SELECT ''***Certificate***'' as RequestedUser, p.[name], ''ControlServer'', p.type_desc AS loginType 
FROM sys.server_principals p
  JOIN sys.server_permissions sp
   ON p.principal_id = sp.grantee_principal_id WHERE sp.class = 100
  AND sp.[type] = ''CL''
  AND state = ''G'')
SELECT 
RequestedUser,
name,
type_desc ,' + @serverroledef + '
CASE WHEN [ControlServer] =1 THEN ''YES'' ELSE ''N'' END AS ''ControlServer'' 
FROM CTE_Role
PIVOT(
COUNT(role) FOR role IN (' + @serverRole + ', [ControlServer])
) AS pvt WHERE type_desc NOT IN (''SERVER_ROLE'') 
ORDER BY name, type_desc;')

set @serverLoginExec = REPLACE(@serverLoginExec,'''NULL''','NULL')

--ADDING NEW COLUMNS TO TEMP TABLE
select @newcolumn = coalesce(@newcolumn + CHAR(10), '') +
'ALTER TABLE #serverlogins ADD [' + sp.name + '] varchar(3)'
from sys.server_principals sp
left outer join tempdb.INFORMATION_SCHEMA.COLUMNS tc
on (sp.name = tc.COLUMN_NAME and tc.TABLE_NAME =  OBJECT_NAME(object_id('tempdb..#serverlogins'),2)) 
where 
sp.type_desc='server_role'
and tc.COLUMN_NAME is null

exec(@newcolumn)

--Print (@serverLoginExec)
insert into #serverlogins
exec(@serverLoginExec)


IF (@SeePermissions = 1)
BEGIN
SELECT * FROM #serverlogins
--select * from #loginInfo
END

IF EXISTS (SELECT PRN.name FROM sys.server_principals  PRN
join #serverlogins lg
ON PRN.name = lg.name 
WHERE PRN.Type_Desc IN (
'SQL_LOGIN',
'WINDOWS_LOGIN',
'WINDOWS_GROUP'
) 
AND PRN.[name] NOT LIKE '##%'
AND PRN.[name] NOT LIKE 'NT%')
BEGIN
--Print server logins with permissions
SET @serverprint = CHAR(10) + '--====================================--' + CHAR(10) 
SET @serverprint = @serverprint + '--SERVER LOGINS SCRIPT--'  + CHAR(10)
SET @serverprint = @serverprint + '--====================================--' + CHAR(10)

SELECT
@serverprint = COALESCE(@serverprint, '') +
CASE
	WHEN PRN.Type_Desc IN ('WINDOWS_LOGIN','WINDOWS_GROUP') THEN 'IF NOT EXISTS (SELECT * FROM master.sys.server_principals WHERE [name] = ''' + PRN.[name] + ''')
		CREATE LOGIN [' + PRN.name + '] FROM WINDOWS WITH DEFAULT_DATABASE=[' + PRN.default_database_name + ']' + CHAR(10)
	WHEN PRN.Type_Desc = 'SQL_LOGIN' THEN 'IF NOT EXISTS (SELECT * FROM master.sys.server_principals WHERE [name] = ''' + PRN.[name] + ''')
		CREATE LOGIN [' + PRN.name + '] WITH PASSWORD =' + CONVERT(VARCHAR(MAX),LOGINPROPERTY(PRN.name,'PASSWORDHASH'),1) + ' HASHED, DEFAULT_DATABASE = [' + PRN.default_database_name + ']' + CHAR(10)
END
FROM sys.server_principals  PRN
join #serverlogins lg
ON PRN.name = lg.name
WHERE PRN.Type_Desc IN (
'SQL_LOGIN',
'WINDOWS_LOGIN',
'WINDOWS_GROUP'
) 
AND PRN.[name] NOT LIKE '##%'
AND PRN.[name] NOT LIKE 'NT%'


IF @@rowcount = 0 
SET @serverprint = @serverprint + '---No server Logins to create' + CHAR(10)

SET @serverprint = @serverprint + '--====================================--' + CHAR(10) 
SET @serverprint = @serverprint + '--DISABLE LOGINS SCRIPT--'  + CHAR(10)
SET @serverprint = @serverprint + '--====================================--' + CHAR(10)
SELECT @serverprint = COALESCE(@serverprint, '') + 'ALTER LOGIN [' + PRN.[name] + '] DISABLE' 
from master.sys.server_principals PRN
join #serverlogins lg
ON PRN.name = lg.name 
WHERE PRN.Type_Desc IN (
'SQL_LOGIN',
'WINDOWS_LOGIN',
'WINDOWS_GROUP'
) 
AND PRN.[name] NOT LIKE '##%'
AND PRN.[name] NOT LIKE 'NT%'
and is_disabled = 1
IF @@rowcount = 0 
SET @serverprint = @serverprint + '---No logins to disable'

SET @serverprint = @serverprint + CHAR(10) + '--====================================--' + CHAR(10) 
SET @serverprint = @serverprint + '--ASSIGN ROLES SCRIPT--'  + CHAR(10)
SET @serverprint = @serverprint + '--====================================--' + CHAR(10)
select @serverprint = COALESCE(@serverprint, '') +
'EXEC master..sp_addsrvrolemember @loginame = N''' + l.name + ''', @rolename = N''' + r.name + '''
'
from master.sys.server_role_members rm
join master.sys.server_principals r on r.principal_id = rm.role_principal_id
join master.sys.server_principals l on l.principal_id = rm.member_principal_id
join #serverlogins lg
ON l.name = lg.name
where 
l.Type_Desc IN (
'SQL_LOGIN',
'WINDOWS_LOGIN',
'WINDOWS_GROUP'
) 
AND l.[name] NOT LIKE '##%'
AND l.[name] NOT LIKE 'NT%'
--AND l.[name] = coalesce(@userName, l.name)
IF @@rowcount = 0 
SET @serverprint = @serverprint + '---No server roles to assign'
END

--FOREACH DB CURSOR
DECLARE db_cursor CURSOR static read_only FOR  
SELECT dbName 
FROM #allDBs

OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @dbName   

WHILE @@FETCH_STATUS = 0   
BEGIN   

DECLARE curName CURSOR 
FOR 
SELECT permission_path FROM #loginInfo WHERE permission_path IS NOT NULL
UNION 
SELECT account_name FROM #loginInfo WHERE permission_path IS NULL
UNION
SELECT name FROM #serverlogins WHERE type_desc NOT IN ( 'CERTIFICATE_MAPPED_LOGIN')

OPEN curName 
      
      FETCH NEXT FROM curName INTO @gName
      
      WHILE @@FETCH_STATUS = 0
      BEGIN  
		BEGIN TRY 
				 --PRINT '--inside cursor curname this is user: ' + @gName 
				 SET @insertSQL1 = @gName
				 SET @SQLString = 'SELECT @userSID_OUT=dp.sid, @dbUserName_OUT = dp.name FROM 
					[' + @dbName + '].sys.database_principals dp
					INNER JOIN sys.server_principals sp
					ON sp.sid = dp.sid
					WHERE sp.name = @insertSQL1'
				SET @ParmDefinition = N'@insertSQL1 varchar(200), @userSID_OUT VARBINARY(200) OUTPUT, @dbUserName_OUT VARCHAR(200) OUTPUT';
				EXECUTE sp_executesql @SQLString, @ParmDefinition, @insertSQL1 = @insertSQL1, @userSID_OUT = @userSID OUTPUT, @dbUserName_OUT =@dbUserName OUTPUT;
				--PRINT '--inside cursor curname-userid ' + master.sys.fn_varbintohexstr(@userSID)
				--PRINT '--inside cursor curname-dbusername ' + @dbUserName
				IF @userSID IS NOT NULL
			BEGIN	
					--IF @userName <> @gName
					--PRINT '--Requested Login ' + @userName + ' is a member of ' + @gName 
					--ELSE
					--PRINT '--Requested Login ' + @userName
					--PRINT '--Requested Login is user or group ' + @gName
					--PRINT '--Requested Login DB UserName ' + @dbUserName
					--PRINT '-- ' +  master.sys.fn_varbintohexstr(@userSID)

					SET @databaseUserExec ='USE [' + @dbName + ']' + CHAR(10) +					
					';WITH    perms_cte as
					(
							select  ''' + @dbName + ''' AS database_name,
									USER_NAME(p.grantee_principal_id) AS principal_name,
									dp.principal_id,
									dp.type_desc AS principal_type_desc,
									p.class_desc,
									OBJECT_NAME(p.major_id) AS object_name,
									p.permission_name,
									p.state AS permission_state,
									p.state_desc AS permission_state_desc
							from    [' + @dbName + '].sys.database_permissions p
							inner   JOIN [' + @dbName + '].sys.database_principals dp
							on     p.grantee_principal_id = dp.principal_id
							LEFT OUTER JOIN [' + @dbName + '].sys.objects o
							ON o.name = OBJECT_NAME(p.major_id)
							WHERE dp.sid = ' + master.sys.fn_varbintohexstr(@userSID) + ' or dp.name = ''guest''
							UNION ALL
							select  ''' + @dbName + ''' AS database_name,
									USER_NAME(p.grantee_principal_id) AS principal_name,
									dp.principal_id,
									dp.type_desc AS principal_type_desc,
									p.class_desc,
									NULL AS object_name,
									p.permission_name,
									p.state AS permission_state,
									p.state_desc AS permission_state_desc
							from    [' + @dbName + '].sys.database_permissions p
							inner   JOIN [' + @dbName + '].sys.database_principals dp
							on     p.grantee_principal_id = dp.principal_id							
							WHERE p.major_id = 0 and (dp.sid = ' + master.sys.fn_varbintohexstr(@userSID) + ' or dp.name = ''guest'')
					)
					--users
					SELECT coalesce(' + ISNULL(+ '''' + @userName + '''','NULL') + ', p.principal_name) ActulUser ,p.principal_name,  p.principal_type_desc, p.database_name, p.class_desc, p.[object_name], p.permission_name, p.permission_state, p.permission_state_desc, cast(NULL as sysname) as role_name
					FROM    perms_cte p
					--WHERE   principal_type_desc <> ''DATABASE_ROLE''
					UNION
					--role members
					SELECT coalesce(' + ISNULL(+ '''' + @userName + '''','NULL') + ', rm.member_principal_name) ActulUser, rm.member_principal_name, rm.principal_type_desc, rm.database_name, p.class_desc, p.object_name, p.permission_name,  p.permission_state, p.permission_state_desc,rm.role_name
					FROM    perms_cte p
					right outer JOIN (
						select ''' + @dbName + ''' AS database_name, role_principal_id, dp.type_desc as principal_type_desc, member_principal_id,user_name(member_principal_id) as member_principal_name,user_name(role_principal_id) as role_name--,*
						from    [' + @dbName + '].sys.database_role_members rm
						INNER   JOIN [' + @dbName + '].sys.database_principals dp
						ON     rm.member_principal_id = dp.principal_id
						WHERE dp.sid = ' + master.sys.fn_varbintohexstr(@userSID) + ' or dp.name = ''guest''
					) rm
					ON     rm.role_principal_id = p.principal_id
					order by 1'	
					
					SET @databaseUserExec = REPLACE(@databaseUserExec, '@userName', ISNULL(@userName,@gName))
					--PRINT (@databaseuserexec)
					--TRUNCATE TABLE #allPer
					INSERT INTO #allPer
					EXEC (@databaseUserExec)

					INSERT INTO #perDBUser (noOfexec, userName, dbName)				
					SELECT @@rowcount, @gName, @dbName

					UPDATE #perDBUser
					SET principalName = principal_name
					FROM #allPer
					WHERE #allPer.actual_user = @gName
			END	

		END TRY			 
		BEGIN CATCH
		IF ERROR_NUMBER()=15406
		PRINT 'this is gruop and can''t test directly what PERMISSIONS'
		ELSE 
		BEGIN
			PRINT	'	ErrorNumber: ' + CONVERT(VARCHAR,ERROR_NUMBER()) +
					'	ErrorSeverity: ' + CONVERT(VARCHAR,ERROR_SEVERITY()) + 
					'	ErrorState: ' + CONVERT(VARCHAR,ERROR_STATE()) +
					'	ErrorProcedure: ' + CONVERT(VARCHAR(100),ISNULL(ERROR_PROCEDURE(),'NULL')) +
					'	ErrorLine: ' + CONVERT(VARCHAR,ERROR_LINE()) + 
					'	ErrorMessage: ' + ERROR_MESSAGE()
				END 
		END CATCH
			SET @userSID = NULL	
            FETCH NEXT FROM curName INTO @gName
      END
      
CLOSE curName 
DEALLOCATE curName 

IF (@SeePermissions = 1) and EXISTS(SELECT 1 FROM #allPer)
SELECT * FROM #allPer --where principal_name = coalesce(@userName,principal_name) 

IF EXISTS(SELECT 1 FROM #allPer where database_name = @dbName)
BEGIN
SET @printstmt = CHAR(10) + 'USE ' + QUOTENAME(@dbName) + CHAR(10) 
						+ '--====================================--' + CHAR(10) 
SET @printstmt = @printstmt + '--DATABASE USERS SCRIPT--'  + CHAR(10)
SELECT @printstmt = @printstmt + '--DB OWNER: ' + ISNULL(suser_sname(owner_sid),NULL) from sys.databases where name = @dbName
SET @printstmt = @printstmt + CHAR(10) + '--====================================--' + CHAR(10)

SELECT @printstmt = COALESCE(@printstmt, '') + 'IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE [name] = ''' + principal_name + ''')
		CREATE USER [' + principal_name + '] FOR LOGIN [' + principal_name + ']' + CHAR(10)
FROM (SELECT DISTINCT principal_name
FROM #allPer
WHERE --lg.type_desc NOT IN ( 'CERTIFICATE_MAPPED_LOGIN')
principal_name NOT IN ('dbo','public')) dbuser

IF @@rowcount = 0 
BEGIN
SET @printstmt = @printstmt + '---No database users to create' + CHAR(10)
SET @SQLString = 'select
                   @dboUserName_OUT = u.name
                  ,@assignedRole_OUT = case when (r.principal_id is null) then ''public''
				else r.name 
			end 
                  ,@loginName_OUT = l.name
                  --,l.default_database_name
                  --,u.default_schema_name
                  --,u.principal_id
                  ,@loginSID_OUT = u.sid
         from [' + @dbName + '].sys.database_principals u
         left join ([' + @dbName + '].sys.database_role_members m join [' + @dbName + '].sys.database_principals r on m.role_principal_id = r.principal_id) on m.member_principal_id = u.principal_id
         left join sys.server_principals l on u.sid = l.sid
         where u.name = ''dbo'' -- u.type <> ''R'''
SET @ParmDefinition = N'@dboUserName_OUT VARCHAR(200) OUTPUT, @assignedRole_OUT VARCHAR(200) OUTPUT, @loginName_OUT VARCHAR(200) OUTPUT, @loginSID_OUT VARBINARY(200) OUTPUT';
EXECUTE sp_executesql @SQLString, @ParmDefinition, @dboUserName_OUT = @dboUserName OUTPUT, @assignedRole_OUT =@assignedRole OUTPUT, @loginName_OUT = @loginName OUTPUT, @loginSID_OUT = @loginSID OUTPUT ; 

SET @printstmt = @printstmt + '-- ' + @userName + ' is assigned to dbo 
-- Assigned Role - ' +  @assignedRole + CHAR(10)
END
ELSE
SET @printstmt = @printstmt + CHAR(10)

--DATABASE PERMISSIONS SCRIPT
SELECT @printstmt = COALESCE(@printstmt, '') + CASE 
			WHEN perm.permission_state = 'W'  
							THEN 'GRANT ' + perm.permission_name + ' TO ' + QUOTENAME(perm.principal_name) + ' WITH GRANT OPTION'
			ELSE perm.permission_state_desc + ' ' + perm.permission_name + ' TO ' + QUOTENAME(perm.principal_name) 
		  END + CHAR(10)
FROM	#allPer perm
WHERE (perm.class_desc = 'DATABASE') AND perm.object_name IS NULL AND perm.principal_name <> 'dbo'
SET @printstmt = @printstmt + CHAR(10) + '--====================================--' + CHAR(10) 
SET @printstmt = @printstmt + '--DATABASE ROLES AND PERMISSIONS SCRIPT--'  + CHAR(10)
SET @printstmt = @printstmt + '--====================================--' + CHAR(10)

--ROLES SCRIPT
SELECT DISTINCT @printstmt = COALESCE(@printstmt, '') + CASE 
			WHEN perm.class_desc IS NULL AND perm.object_name IS NULL AND perm.permission_state_desc IS NULL AND perm.role_name IS NOT NULL
							THEN 'EXEC sp_addrolemember @rolename = ''' + perm.role_name  + ''', @membername = ''' + perm.principal_name + ''''
			ELSE ''
		  END + CHAR(10)
FROM	#allPer perm
WHERE perm.class_desc IS NULL AND perm.object_name IS NULL AND perm.permission_state_desc IS NULL AND perm.role_name IS NOT NULL AND perm.principal_name <> 'dbo'
IF @@rowcount = 0 
SET @printstmt = @printstmt + CHAR(10) + '--No database user connect permissions script' + CHAR(10) + CHAR(10)
ELSE
SET @printstmt = @printstmt + CHAR(10)

--OBJECT PERMISSIONS SCRIPT 
SELECT	@printstmt = COALESCE(@printstmt, '') + CASE 
			WHEN perm.permission_state = 'W'
							THEN 'GRANT ' + perm.permission_name + ' ON OBJECT :: ' + QUOTENAME(perm.object_name) + ' TO ' + QUOTENAME(perm.principal_name) + ' WITH GRANT OPTION'			
			ELSE perm.permission_state_desc + ' ' + perm.permission_name + ' ON OBJECT :: ' + QUOTENAME(perm.object_name) + ' TO ' + QUOTENAME(perm.principal_name)
		  END + CHAR(10)
FROM	#allPer perm
WHERE perm.class_desc = 'OBJECT_OR_COLUMN' AND perm.object_name IS NOT NULL
IF @@rowcount = 0 
SET @printstmt = @printstmt + '--No database object level permissions script' + CHAR(10)
ELSE
SET @printstmt = @printstmt + CHAR(10)

while ( len( @printstmt ) > @len )
begin
   set @left = left( @printstmt, @len )
   set @reverse = reverse( @left )
   set @cr_index = @len - charindex( @cr, @reverse ) + 1
   set @lf_index = @len - charindex( @lf, @reverse ) + 1
   set @crlf_index = case when @cr_index < @lf_index then @cr_index else @lf_index end
   set @has_cr_and_lf = case when @cr_index < @len and @lf_index < @len then 1 else 0 end
   print left( @printstmt, @crlf_index - 1 )
   set @printstmt = right( @printstmt, len( @printstmt ) - @crlf_index - @has_cr_and_lf )
end

print @printstmt

END
	   TRUNCATE TABLE #allPer
       FETCH NEXT FROM db_cursor INTO @dbName   
END

CLOSE db_cursor   
DEALLOCATE db_cursor

while ( len( @serverprint ) > @len )
begin
   set @left = left( @serverprint, @len )
   set @reverse = reverse( @left )
   set @cr_index = @len - charindex( @cr, @reverse ) + 1
   set @lf_index = @len - charindex( @lf, @reverse ) + 1
   set @crlf_index = case when @cr_index < @lf_index then @cr_index else @lf_index end
   set @has_cr_and_lf = case when @cr_index < @len and @lf_index < @len then 1 else 0 end
   print left( @serverprint, @crlf_index - 1 )
   set @serverprint = right( @serverprint, len( @serverprint ) - @crlf_index - @has_cr_and_lf )
end

print @serverprint


select @dbPerCount =
coalesce(@dbPerCount + CHAR(10), '') + '--' + b.dbName  from #perDBUser a
right join #allDBs b
ON a.dbName = b.dbName
WHERE a.dbName IS NULL

IF @dbPerCount <> '' AND @userName  IS NOT NULL
BEGIN
PRINT CHAR(10) + CHAR(10) + '--****************************************--'
PRINT '--user account was not created in the following DBs 
--User may not have access OR access through dbo either user is db_owner of database 
--or SYSADMIN or access through guest--' 
PRINT '-------------------------------------------------' + @dbPerCount
PRINT '--****************************************--'
END