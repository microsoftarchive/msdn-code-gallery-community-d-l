DECLARE @Customer INT
DECLARE @Order INT
DECLARE @Date datetime
SET @Date = GETDATE()

SET @Customer = 1
WHILE @Customer < 1000
BEGIN
    INSERT INTO Customers (Name, Region) VALUES (CAST (@Customer AS nvarchar(50)), @Customer)
    SET @Order = 1
    WHILE @Order < 100
    BEGIN
        INSERT INTO Orders (CustomerID, Item, Cost, Date) VALUES (@Customer, CAST (@Order AS nvarchar(50)), @Order, @Date)
        SET @Order = @Order + 1
    END
    SET @Customer = @Customer + 1
END