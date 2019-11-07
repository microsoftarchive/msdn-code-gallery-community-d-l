USE [NorthWindAzure]
GO
/****** Object:  Table [dbo].[ContactType]    Script Date: 2/3/2018 4:45:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactType](
	[ContactTypeIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[ContactTitle] [nvarchar](max) NULL,
 CONSTRAINT [PK_ContactType] PRIMARY KEY CLUSTERED 
(
	[ContactTypeIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2/3/2018 4:45:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[ContactName] [nvarchar](30) NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[Phone] [nvarchar](24) NULL,
	[Fax] [nvarchar](24) NULL,
	[ContactTypeIdentifier] [int] NULL,
 CONSTRAINT [PK_Customers_1] PRIMARY KEY CLUSTERED 
(
	[CustomerIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ContactType] ON 

GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (1, N'Accounting Manager')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (2, N'Assistant Sales Agent')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (3, N'Assistant Sales Representative')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (4, N'Marketing Assistant')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (5, N'Marketing Manager')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (6, N'Order Administrator')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (7, N'Owner')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (8, N'Owner/Marketing Assistant')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (9, N'Sales Agent')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (10, N'Sales Associate')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (11, N'Sales Manager')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (12, N'Sales Representative')
GO
SET IDENTITY_INSERT [dbo].[ContactType] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (1, N'Alfreds Futterkiste', N'Maria Anders', N'Obere Str. 57', N'Berlin', NULL, N'12209', N'Germany', N'030-0074321', N'030-0076545', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (2, N'Ana Trujillo Emparedados y helados', N'Ana Trujillo', N'Avda. de la Constitución 2222', N'México D.F.', NULL, N'05021', N'Mexico', N'(5) 555-4729', N'(5) 555-3745', 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (3, N'Antonio Moreno Taquería', N'Antonio Moreno', N'Mataderos  2312', N'México D.F.', NULL, N'05023', N'Mexico', N'(5) 555-3932', NULL, 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (4, N'Around the Horn', N'Thomas Hardy', N'120 Hanover Sq.', N'London', NULL, N'WA1 1DP', N'UK', N'(171) 555-7788', N'(171) 555-6750', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (5, N'Berglunds snabbköp', N'Christina Berglund', N'Berguvsvägen  8', N'Luleå', NULL, N'S-958 22', N'Sweden', N'0921-12 34 65', N'0921-12 34 67', 6)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (6, N'Blauer See Delikatessen', N'Hanna Moos', N'Forsterstr. 57', N'Mannheim', NULL, N'68306', N'Germany', N'0621-08460', N'0621-08924', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (7, N'Blondesddsl père et fils', N'Frédérique Citeaux', N'24, place Kléber', N'Strasbourg', NULL, N'67000', N'France', N'88.60.15.31', N'88.60.15.32', 5)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (8, N'Bólido Comidas preparadas', N'Martín Sommer', N'C/ Araquil, 67', N'Madrid', NULL, N'28023', N'Spain', N'(91) 555 22 82', N'(91) 555 91 99', 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (9, N'Bon app''', N'Laurence Lebihan', N'12, rue des Bouchers', N'Marseille', NULL, N'13008', N'France', N'91.24.45.40', N'91.24.45.41', 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (10, N'B''s Beverages', N'Victoria Ashworth', N'Fauntleroy Circus', N'London', NULL, N'EC2 5NT', N'UK', N'(171) 555-1212', NULL, 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (11, N'Cactus Comidas para llevar', N'Patricio Simpson', N'Cerrito 333', N'Buenos Aires', NULL, N'1010', N'Argentina', N'(1) 135-5555', N'(1) 135-4892', 9)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (12, N'Centro comercial Moctezuma', N'Francisco Chang', N'Sierras de Granada 9993', N'México D.F.', NULL, N'05022', N'Mexico', N'(5) 555-3392', N'(5) 555-7293', 5)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (13, N'Chop-suey Chinese', N'Yang Wang', N'Hauptstr. 29', N'Bern', NULL, N'3012', N'Switzerland', N'0452-076545', NULL, 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (14, N'Consolidated Holdings', N'Elizabeth Brown', N'Berkeley Gardens 12  Brewery', N'London', NULL, N'WX1 6LT', N'UK', N'(171) 555-2282', N'(171) 555-9199', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (15, N'Drachenblut Delikatessen', N'Sven Ottlieb', N'Walserweg 21', N'Aachen', NULL, N'52066', N'Germany', N'0241-039123', N'0241-059428', 6)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (16, N'Du monde entier', N'Janine Labrune', N'67, rue des Cinquante Otages', N'Nantes', NULL, N'44000', N'France', N'40.67.88.88', N'40.67.89.89', 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (17, N'Eastern Connection', N'Ann Devon', N'35 King George', N'London', NULL, N'WX3 6FW', N'UK', N'(171) 555-0297', N'(171) 555-3373', 9)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (18, N'Ernst Handel', N'Roland Mendel', N'Kirchgasse 6', N'Graz', NULL, N'8010', N'Austria', N'7675-3425', N'7675-3426', 11)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (19, N'FISSA Fabrica Inter. Salchichas S.A.', N'Diego Roel', N'C/ Moralzarzal, 86', N'Madrid', NULL, N'28034', N'Spain', N'(91) 555 94 44', N'(91) 555 55 93', 1)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (20, N'Folies gourmandes', N'Martine Rancé', N'184, chaussée de Tournai', N'Lille', NULL, N'59000', N'France', N'20.16.10.16', N'20.16.10.17', 2)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (21, N'Folk och fä HB', N'Maria Larsson', N'Åkergatan 24', N'Bräcke', NULL, N'S-844 67', N'Sweden', N'0695-34 67 21', NULL, 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (22, N'Frankenversand', N'Peter Franken', N'Berliner Platz 43', N'München', NULL, N'80805', N'Germany', N'089-0877310', N'089-0877451', 5)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (23, N'France restauration', N'Carine Schmitt', N'54, rue Royale', N'Nantes', NULL, N'44000', N'France', N'40.32.21.21', N'40.32.21.20', 5)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (24, N'Franchi S.p.A.', N'Paolo Accorti', N'Via Monte Bianco 34', N'Torino', NULL, N'10100', N'Italy', N'011-4988260', N'011-4988261', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (25, N'Furia Bacalhau e Frutos do Mar', N'Lino Rodriguez', N'Jardim das rosas n. 32', N'Lisboa', NULL, N'1675', N'Portugal', N'(1) 354-2534', N'(1) 354-2535', 11)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (26, N'Galería del gastrónomo', N'Eduardo Saavedra', N'Rambla de Cataluña, 23', N'Barcelona', NULL, N'08022', N'Spain', N'(93) 203 4560', N'(93) 203 4561', 5)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (27, N'Godos Cocina Típica', N'José Pedro Freyre', N'C/ Romero, 33', N'Sevilla', NULL, N'41101', N'Spain', N'(95) 555 82 82', NULL, 11)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (28, N'Königlich Essen', N'Philip Cramer', N'Maubelstr. 90', N'Brandenburg', NULL, N'14776', N'Germany', N'0555-09876', NULL, 10)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (29, N'La corne d''abondance', N'Daniel Tonini', N'67, avenue de l''Europe', N'Versailles', NULL, N'78000', N'France', N'30.59.84.10', N'30.59.85.11', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (30, N'La maison d''Asie', N'Annette Roulet', N'1 rue Alsace-Lorraine', N'Toulouse', NULL, N'31000', N'France', N'61.77.61.10', N'61.77.61.11', 11)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (31, N'Lehmanns Marktstand', N'Renate Messner', N'Magazinweg 7', N'Frankfurt a.M.', NULL, N'60528', N'Germany', N'069-0245984', N'069-0245874', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (32, N'Magazzini Alimentari Riuniti', N'Giovanni Rovelli', N'Via Ludovico il Moro 22', N'Bergamo', NULL, N'24100', N'Italy', N'035-640230', N'035-640231', 5)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (33, N'Maison Dewey', N'Catherine Dewey', N'Rue Joseph-Bens 532', N'Bruxelles', NULL, N'B-1180', N'Belgium', N'(02) 201 24 67', N'(02) 201 24 68', 9)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (34, N'Morgenstern Gesundkost', N'Alexander Feuer', N'Heerstr. 22', N'Leipzig', NULL, N'04179', N'Germany', N'0342-023176', NULL, 4)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (35, N'North/South', N'Simon Crowther', N'South House 300 Queensbridge', N'London', NULL, N'SW7 1RZ', N'UK', N'(171) 555-7733', N'(171) 555-2530', 10)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (36, N'Océano Atlántico Ltda.', N'Yvonne Moncada', N'Ing. Gustavo Moncada 8585 Piso 20-A', N'Buenos Aires', NULL, N'1010', N'Argentina', N'(1) 135-5333', N'(1) 135-5535', 9)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (37, N'Ottilies Käseladen', N'Henriette Pfalzheim', N'Mehrheimerstr. 369', N'Köln', NULL, N'50739', N'Germany', N'0221-0644327', N'0221-0765721', 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (38, N'Paris spécialités', N'Marie Bertrand', N'265, boulevard Charonne', N'Paris', NULL, N'75012', N'France', N'(1) 42.34.22.66', N'(1) 42.34.22.77', 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (39, N'Pericles Comidas clásicas', N'Guillermo Fernández', N'Calle Dr. Jorge Cash 321', N'México D.F.', NULL, N'05033', N'Mexico', N'(5) 552-3745', N'(5) 545-3745', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (40, N'Piccolo und mehr', N'Georg Pipps', N'Geislweg 14', N'Salzburg', NULL, N'5020', N'Austria', N'6562-9722', N'6562-9723', 11)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (41, N'Princesa Isabel Vinhos', N'Isabel de Castro', N'Estrada da saúde n. 58', N'Lisboa', NULL, N'1756', N'Portugal', N'(1) 356-5634', NULL, 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (42, N'QUICK Stop', N'Horst Kloss', N'Taucherstraße 10', N'Cunewalde', NULL, N'01307', N'Germany', N'0372-035188', NULL, 1)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (43, N'Rancho grande', N'Sergio Gutiérrez', N'Av. del Libertador 900', N'Buenos Aires', NULL, N'1010', N'Argentina', N'(1) 123-5555', N'(1) 123-5556', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (44, N'Reggiani Caseifici', N'Maurizio Moroni', N'Strada Provinciale 124', N'Reggio Emilia', NULL, N'42100', N'Italy', N'0522-556721', N'0522-556722', 10)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (45, N'Richter Supermarkt', N'Michael Holz', N'Grenzacherweg 237', N'Genève', NULL, N'1203', N'Switzerland', N'0897-034214', NULL, 11)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (46, N'Romero y tomillo', N'Alejandra Camino', N'Gran Vía, 1', N'Madrid', NULL, N'28001', N'Spain', N'(91) 745 6200', N'(91) 745 6210', 1)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (47, N'Santé Gourmet', N'Jonas Bergulfsen', N'Erling Skakkes gate 78', N'Stavern', NULL, N'4110', N'Norway', N'07-98 92 35', N'07-98 92 47', 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (48, N'Seven Seas Imports', N'Hari Kumar', N'90 Wadhurst Rd.', N'London', NULL, N'OX15 4NB', N'UK', N'(171) 555-1717', N'(171) 555-5646', 11)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (49, N'Simons bistro', N'Jytte Petersen', N'Vinbæltet 34', N'Kobenhavn', NULL, N'1734', N'Denmark', N'31 12 34 56', N'31 13 35 57', 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (50, N'Spécialités du monde', N'Dominique Perrier', N'25, rue Lauriston', N'Paris', NULL, N'75016', N'France', N'(1) 47.55.60.10', N'(1) 47.55.60.20', 5)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (51, N'Suprêmes délices', N'Pascale Cartrain', N'Boulevard Tirou, 255', N'Charleroi', NULL, N'B-6000', N'Belgium', N'(071) 23 67 22 20', N'(071) 23 67 22 21', 1)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (52, N'Toms Spezialitäten', N'Karin Josephs', N'Luisenstr. 48', N'Münster', NULL, N'44087', N'Germany', N'0251-031259', N'0251-035695', 5)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (53, N'Tortuga Restaurante', N'Miguel Angel Paolino', N'Avda. Azteca 123', N'México D.F.', NULL, N'05033', N'Mexico', N'(5) 555-2933', NULL, 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (54, N'Vaffeljernet', N'Palle Ibsen', N'Smagsloget 45', N'Århus', NULL, N'8200', N'Denmark', N'86 21 32 43', N'86 22 33 44', 11)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (55, N'Victuailles en stock', N'Mary Saveley', N'2, rue du Commerce', N'Lyon', NULL, N'69004', N'France', N'78.32.54.86', N'78.32.54.87', 9)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (56, N'Vins et alcools Chevalier', N'Paul Henriot', N'59 rue de l''Abbaye', N'Reims', NULL, N'51100', N'France', N'26.47.15.10', N'26.47.15.11', 1)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (57, N'Die Wandernde Kuh', N'Rita Müller', N'Adenauerallee 900', N'Stuttgart', NULL, N'70563', N'Germany', N'0711-020361', N'0711-035428', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (58, N'Wartian Herkku', N'Pirkko Koskitalo', N'Torikatu 38', N'Oulu', NULL, N'90110', N'Finland', N'981-443655', N'981-443655', 1)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (59, N'Wilman Kala', N'Matti Karttunen', N'Keskuskatu 45', N'Helsinki', NULL, N'21240', N'Finland', N'90-224 8858', N'90-224 8858', 8)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (60, N'Wolski  Zajazd', N'Zbyszek Piestrzeniewicz', N'ul. Filtrowa 68', N'Warszawa', NULL, N'01-012', N'Poland', N'(26) 642-7012', N'(26) 642-7012', 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (61, N'Old World Delicatessen', N'Rene Phillips', N'2743 Bering St.', N'Anchorage', N'AK', N'99508', N'USA', N'(907) 555-7584', N'(907) 555-2880', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (62, N'Bottom-Dollar Markets', N'Elizabeth Lincoln', N'23 Tsawassen Blvd.', N'Tsawassen', N'BC', N'T2F 8M4', N'Canada', N'(604) 555-4729', N'(604) 555-3745', 1)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (63, N'Laughing Bacchus Wine Cellars', N'Yoshi Tannamuri', N'1900 Oak St.', N'Vancouver', N'BC', N'V3F 2K1', N'Canada', N'(604) 555-3392', N'(604) 555-7293', 4)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (64, N'Let''s Stop N Shop', N'Jaime Yorres', N'87 Polk St. Suite 5', N'San Francisco', N'CA', N'94117', N'USA', N'(415) 555-5938', NULL, 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (65, N'Hungry Owl All-Night Grocers', N'Patricia McKenna', N'8 Johnstown Road', N'Cork', N'Co. Cork', NULL, N'Ireland', N'2967 542', N'2967 3333', 10)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (66, N'GROSELLA-Restaurante', N'Manuel Pereira', N'5ª Ave. Los Palos Grandes', N'Caracas', N'DF', N'1081', N'Venezuela', N'(2) 283-2951', N'(2) 283-3397', 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (67, N'Save-a-lot Markets', N'Jose Pavarotti', N'187 Suffolk Ln.', N'Boise', N'ID', N'83720', N'USA', N'(208) 555-8097', NULL, 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (68, N'Island Trading', N'Helen Bennett', N'Garden House Crowther Way', N'Cowes', N'Isle of Wight', N'PO31 7PJ', N'UK', N'(198) 555-8888', NULL, 5)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (69, N'LILA-Supermercado', N'Carlos González', N'Carrera 52 con Ave. Bolívar #65-98 Llano Largo', N'Barquisimeto', N'Lara', N'3508', N'Venezuela', N'(9) 331-6954', N'(9) 331-7256', 1)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (70, N'The Cracker Box', N'Liu Wong', N'55 Grizzly Peak Rd.', N'Butte', N'MT', N'59801', N'USA', N'(406) 555-5834', N'(406) 555-8083', 4)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (71, N'Rattlesnake Canyon Grocery', N'Paula Wilson', N'2817 Milton Dr.', N'Albuquerque', N'NM', N'87110', N'USA', N'(505) 555-5939', N'(505) 555-3620', 3)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (72, N'LINO-Delicateses', N'Felipe Izquierdo', N'Ave. 5 de Mayo Porlamar', N'I. de Margarita', N'Nueva Esparta', N'4980', N'Venezuela', N'(8) 34-56-12', N'(8) 34-93-93', 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (73, N'Great Lakes Food Market', N'Howard Snyder', N'2732 Baker Blvd.', N'Eugene', N'OR', N'97403', N'USA', N'(503) 555-7555', NULL, 5)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (74, N'Hungry Coyote Import Store', N'Yoshi Latimer', N'City Center Plaza 516 Main St.', N'Elgin', N'OR', N'97827', N'USA', N'(503) 555-6874', N'(503) 555-2376', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (75, N'Lonesome Pine Restaurant', N'Fran Wilson', N'89 Chiaroscuro Rd.', N'Portland', N'OR', N'97219', N'USA', N'(503) 555-9573', N'(503) 555-9646', 11)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (76, N'The Big Cheese', N'Liz Nixon', N'89 Jefferson Way Suite 2', N'Portland', N'OR', N'97201', N'USA', N'(503) 555-3612', NULL, 5)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (77, N'Mère Paillarde', N'Jean Fresnière', N'43 rue St. Laurent', N'Montréal', N'Québec', N'H1J 1C3', N'Canada', N'(514) 555-8054', N'(514) 555-8055', 4)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (78, N'Hanari Carnes', N'Mario Pontes', N'Rua do Paço, 67', N'Rio de Janeiro', N'RJ', N'05454-876', N'Brazil', N'(21) 555-0091', N'(21) 555-8765', 1)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (79, N'Que Delícia', N'Bernardo Batista', N'Rua da Panificadora, 12', N'Rio de Janeiro', N'RJ', N'02389-673', N'Brazil', N'(21) 555-4252', N'(21) 555-4545', 1)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (80, N'Ricardo Adocicados', N'Janete Limeira', N'Av. Copacabana, 267', N'Rio de Janeiro', N'RJ', N'02389-890', N'Brazil', N'(21) 555-3412', NULL, 2)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (81, N'Comércio Mineiro', N'Pedro Afonso', N'Av. dos Lusíadas, 23', N'Sao Paulo', N'SP', N'05432-043', N'Brazil', N'(11) 555-7647', NULL, 10)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (82, N'Familia Arquibaldo', N'Aria Cruz', N'Rua Orós, 92', N'Sao Paulo', N'SP', N'05442-030', N'Brazil', N'(11) 555-9857', NULL, 4)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (83, N'Gourmet Lanchonetes', N'André Fonseca', N'Av. Brasil, 442', N'Campinas', N'SP', N'04876-786', N'Brazil', N'(11) 555-9482', NULL, 10)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (84, N'Queen Cozinha', N'Lúcia Carvalho', N'Alameda dos Canàrios, 891', N'Sao Paulo', N'SP', N'05487-020', N'Brazil', N'(11) 555-1189', NULL, 4)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (85, N'Tradição Hipermercados', N'Anabela Domingues', N'Av. Inês de Castro, 414', N'Sao Paulo', N'SP', N'05634-030', N'Brazil', N'(11) 555-2167', N'(11) 555-2168', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (86, N'Wellington Importadora', N'Paula Parente', N'Rua do Mercado, 12', N'Resende', N'SP', N'08737-363', N'Brazil', N'(14) 555-8122', NULL, 11)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (87, N'HILARION-Abastos', N'Carlos Hernández', N'Carrera 22 con Ave. Carlos Soublette #8-35', N'San Cristóbal', N'Táchira', N'5022', N'Venezuela', N'(5) 555-1340', N'(5) 555-1948', 12)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (88, N'Lazy K Kountry Store', N'John Steel', N'12 Orchestra Terrace', N'Walla Walla', N'WA', N'99362', N'USA', N'(509) 555-7969', N'(509) 555-6221', 5)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (89, N'Trail''s Head Gourmet Provisioners', N'Helvetius Nagy', N'722 DaVinci Blvd.', N'Kirkland', N'WA', N'98034', N'USA', N'(206) 555-8257', N'(206) 555-2174', 10)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (90, N'White Clover Markets', N'Karl Jablonski', N'305 - 14th Ave. S. Suite 3B', N'Seattle', N'WA', N'98128', N'USA', N'(206) 555-4112', N'(206) 555-4115', 7)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [ContactTypeIdentifier]) VALUES (91, N'Split Rail Beer & Ale', N'Art Braunschweiger', N'P.O. Box 555', N'Lander', N'WY', N'82520', N'USA', N'(307) 555-4680', N'(307) 555-6525', 11)
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_ContactType] FOREIGN KEY([ContactTypeIdentifier])
REFERENCES [dbo].[ContactType] ([ContactTypeIdentifier])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_ContactType]
GO
