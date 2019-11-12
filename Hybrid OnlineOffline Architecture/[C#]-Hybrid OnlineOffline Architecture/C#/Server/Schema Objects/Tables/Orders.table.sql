CREATE TABLE [dbo].[Orders] (
    [ID]         INT        IDENTITY NOT NULL,
    [CustomerID] INT        NOT NULL,
    [Item]       NVARCHAR(50) NOT NULL,
    [Cost]       MONEY      NOT NULL,
    [Date]       DATETIME   NOT NULL, 
    [TimeStamp] DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TRIGGER [dbo].[Orders_TimeStamp]
    ON [dbo].[Orders]
    FOR UPDATE
    AS
    BEGIN
    IF NOT(UPDATE([TimeStamp]))
        BEGIN
            UPDATE  dbo.Orders
            SET     [TimeStamp] = GETDATE()
            WHERE   ID IN (SELECT ID FROM inserted)
       END
    END