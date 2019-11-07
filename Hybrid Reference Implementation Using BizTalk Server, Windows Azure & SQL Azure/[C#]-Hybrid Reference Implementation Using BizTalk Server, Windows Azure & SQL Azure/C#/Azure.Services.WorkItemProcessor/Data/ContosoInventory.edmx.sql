
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/15/2011 09:50:39
-- Generated from EDMX file: C:\Users\jamespo\Documents\Now\Work\Tech Ready\DataIntegrationFunctionalTestApplication\ContosoInventory.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ContosoInventory];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_InventoryData_DTOProductData_DTO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InventoryData_DTO] DROP CONSTRAINT [FK_InventoryData_DTOProductData_DTO];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[InventoryData_DTO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InventoryData_DTO];
GO
IF OBJECT_ID(N'[dbo].[UOMTypesData_DTO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UOMTypesData_DTO];
GO
IF OBJECT_ID(N'[dbo].[ProductData_DTO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductData_DTO];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'InventoryData_DTO'
CREATE TABLE [dbo].[InventoryData_DTO] (
    [INV_InventoryId] int IDENTITY(1,1) NOT NULL,
    [INV_AvailableQuantity] int  NOT NULL,
    [INV_LastUpdatedTime] datetime  NOT NULL,
    [PR_ProductDataObj_PR_ProductID] int  NOT NULL,
    [PRUOM_ProductUOMObj_UOM_UOM_Id] int  NOT NULL
);
GO

-- Creating table 'UOMTypesData_DTO'
CREATE TABLE [dbo].[UOMTypesData_DTO] (
    [UOM_UOM_Id] int IDENTITY(1,1) NOT NULL,
    [UOM_UOM_Code] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductData_DTO'
CREATE TABLE [dbo].[ProductData_DTO] (
    [PR_ProductID] int IDENTITY(1,1) NOT NULL,
    [PR_ManufacturerPartNum] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [INV_InventoryId] in table 'InventoryData_DTO'
ALTER TABLE [dbo].[InventoryData_DTO]
ADD CONSTRAINT [PK_InventoryData_DTO]
    PRIMARY KEY CLUSTERED ([INV_InventoryId] ASC);
GO

-- Creating primary key on [UOM_UOM_Id] in table 'UOMTypesData_DTO'
ALTER TABLE [dbo].[UOMTypesData_DTO]
ADD CONSTRAINT [PK_UOMTypesData_DTO]
    PRIMARY KEY CLUSTERED ([UOM_UOM_Id] ASC);
GO

-- Creating primary key on [PR_ProductID] in table 'ProductData_DTO'
ALTER TABLE [dbo].[ProductData_DTO]
ADD CONSTRAINT [PK_ProductData_DTO]
    PRIMARY KEY CLUSTERED ([PR_ProductID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PR_ProductDataObj_PR_ProductID] in table 'InventoryData_DTO'
ALTER TABLE [dbo].[InventoryData_DTO]
ADD CONSTRAINT [FK_InventoryData_DTOProductData_DTO]
    FOREIGN KEY ([PR_ProductDataObj_PR_ProductID])
    REFERENCES [dbo].[ProductData_DTO]
        ([PR_ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InventoryData_DTOProductData_DTO'
CREATE INDEX [IX_FK_InventoryData_DTOProductData_DTO]
ON [dbo].[InventoryData_DTO]
    ([PR_ProductDataObj_PR_ProductID]);
GO

-- Creating foreign key on [PRUOM_ProductUOMObj_UOM_UOM_Id] in table 'InventoryData_DTO'
ALTER TABLE [dbo].[InventoryData_DTO]
ADD CONSTRAINT [FK_InventoryData_DTOUOMTypesData_DTO]
    FOREIGN KEY ([PRUOM_ProductUOMObj_UOM_UOM_Id])
    REFERENCES [dbo].[UOMTypesData_DTO]
        ([UOM_UOM_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InventoryData_DTOUOMTypesData_DTO'
CREATE INDEX [IX_FK_InventoryData_DTOUOMTypesData_DTO]
ON [dbo].[InventoryData_DTO]
    ([PRUOM_ProductUOMObj_UOM_UOM_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------