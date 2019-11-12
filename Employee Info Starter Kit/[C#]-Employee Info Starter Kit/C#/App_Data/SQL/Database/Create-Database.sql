-- =============================================
-- Script Template
-- =============================================
USE master
DECLARE @database_name nvarchar(100)
SET @database_name = 'EmployeeInfo_SK_5_0'
IF db_id(@database_name) IS NOT NULL
	BEGIN
		Print 'Database exists..no need to re-create!'
	END
ELSE
	BEGIN
		Print 'Database does not exists..creating the database..'
		CREATE DATABASE EmployeeInfo_SK_5_0
	END
--USE a0010


