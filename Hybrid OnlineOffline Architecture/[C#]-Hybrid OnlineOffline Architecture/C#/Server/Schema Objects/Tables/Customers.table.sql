CREATE TABLE [dbo].[Customers] (
    [ID]     INT        IDENTITY NOT NULL,
    [Name]   NVARCHAR(50) NOT NULL,
    [Region] INT        NOT NULL, 
    [TimeStamp] DATETIME NOT NULL DEFAULT GETDATE() 
);
GO

CREATE TRIGGER [dbo].[Customers_TimeStamp]
    ON [dbo].[Customers]
    AFTER UPDATE
    AS
    BEGIN
    IF NOT(UPDATE([TimeStamp]))
        BEGIN
            UPDATE  dbo.Customers
            SET     [TimeStamp] = GETDATE()
            WHERE   ID IN (SELECT ID FROM inserted)
       END
    END