CREATE DATABASE SampleDatabase;
GO

CREATE TABLE dbo.Company
(
	CompanyID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	RegistryNumber NVARCHAR(50) NOT NULL,
	Name NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE dbo.Person
(
	PersonID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL
);
GO

INSERT INTO dbo.Person(FirstName, LastName) VALUES('Mickey', 'Mouse');
INSERT INTO dbo.Person(FirstName, LastName) VALUES('Minney', 'Mouse');
INSERT INTO dbo.Person(FirstName, LastName) VALUES('Donald', 'Duck');
GO

INSERT INTO dbo.Company(RegistryNumber, Name) VALUES('788594', 'Toy Store');
INSERT INTO dbo.Company(RegistryNumber, Name) VALUES('788943', 'Car Shop');
INSERT INTO dbo.Company(RegistryNumber, Name) VALUES('788894', 'Drink House');
GO