--
-- ========================================================================================================================================================================
--  PEER 1 - Setup
-- ========================================================================================================================================================================
--


--
-- Create fresh new database called "peer1"
--
drop database peer1
go
create database peer1
go

CREATE TABLE peer1..orders(order_id int NOT NULL primary key, order_date datetime NULL)
go

CREATE TABLE peer1..order_details(order_id int NOT NULL, order_details_id int NOT NULL primary key, product nvarchar(100) NULL, quantity int NULL)
go


