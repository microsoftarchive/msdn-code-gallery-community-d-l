-- =============================================
-- Script Template
-- =============================================
USE master
DECLARE @database_name nvarchar(100)
SET @database_name = 'EmployeeInfo_SK_5_0'
IF db_id(@database_name) IS NOT NULL
	BEGIN
		Print 'Database exists..deleting!'
		DROP DATABASE EmployeeInfo_SK_5_0
	END
ELSE
	BEGIN
		Print 'Database does not exists..no need to drop..'
	END


