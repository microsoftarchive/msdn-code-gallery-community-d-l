
--GO
--/****** Object:  Database [People1]    Script Date: 2/5/2017 9:42:20 AM ******/
--CREATE DATABASE [People1]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'People1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\People1.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
-- LOG ON 
--( NAME = N'People1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\People1_log.ldf' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
--GO
ALTER DATABASE [People1] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [People1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [People1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [People1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [People1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [People1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [People1] SET ARITHABORT OFF 
GO
ALTER DATABASE [People1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [People1] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [People1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [People1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [People1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [People1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [People1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [People1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [People1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [People1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [People1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [People1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [People1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [People1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [People1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [People1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [People1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [People1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [People1] SET RECOVERY FULL 
GO
ALTER DATABASE [People1] SET  MULTI_USER 
GO
ALTER DATABASE [People1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [People1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [People1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [People1] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [People1]
GO
/****** Object:  FullTextCatalog [Karen1]    Script Date: 2/5/2017 9:42:20 AM ******/
CREATE FULLTEXT CATALOG [Karen1]WITH ACCENT_SENSITIVITY = ON

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/5/2017 9:42:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
	[AccountNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GenderTypes]    Script Date: 2/5/2017 9:42:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenderTypes](
	[GenderIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[Gender] [nvarchar](max) NULL,
 CONSTRAINT [PK_GenderTypes] PRIMARY KEY CLUSTERED 
(
	[GenderIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons1]    Script Date: 2/5/2017 9:42:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons1](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[GenderIdentifier] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

GO
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (1, N'Stefanie', N'Buckley', N'36 West Fabien St.', N'Lincoln', N'Kentucky', N'59898     ', N'QW11112')
GO
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (2, N'Sandy', N'Mc Gee', N'935 Nobel Way', N'Arlington', N'Iowa', N'47471     ', N'QW22225')
GO
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (3, N'Lee Ann', N'Warren', N'91 Hague Parkway', N'Newark', N'Indiana', N'51737     ', N'AR16433')
GO
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (4, N'Karen', N'Forbes', N'50 Cowley Avenue', N'Sacramento', N'New York', N'66301     ', N'YUI10483')
GO
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (5, N'Dennis', N'Nunez', N'48 Old Freeway', N'San Diego', N'Washington', N'07170     ', N'BJI999999')
GO
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (6, N'Myra', N'Zuniga', N'545 New Way', N'Anchorage', N'Delaware', N'43313     ', N'RT876962')
GO
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (7, N'Annie', N'Larson', N'16 Nobel St.', N'Fresno', N'New Jersey', N'01497     ', N'BHH4756')
GO
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (8, N'Herman', N'Anderson', N'361 Milton Way', N'Raleigh', N'Colorado', N'55855     ', N'SGU19483')
GO
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (9, N'Jan', N'Jackson', N'111 Apple St', N'Some City', N'New York', N'66302', N'GYU11111')
GO
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (10, N'Karen', N'Payne', N'11 Coffee Lane', N'Keizer', N'OR', N'97222', N'KPd11142')
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[GenderTypes] ON 

GO
INSERT [dbo].[GenderTypes] ([GenderIdentifier], [Gender]) VALUES (1, N'Female')
GO
INSERT [dbo].[GenderTypes] ([GenderIdentifier], [Gender]) VALUES (2, N'Male')
GO
INSERT [dbo].[GenderTypes] ([GenderIdentifier], [Gender]) VALUES (3, N'Non binary')
GO
SET IDENTITY_INSERT [dbo].[GenderTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Persons1] ON 

GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (1, N'Mary', N'Buckley', 1, 1)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (2, N'Karen', N'Payne', 1, 1)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (3, N'Lee', N'Warren', 1, 1)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (4, N'Regina', N'Forbes', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (5, N'Daniel', N'Kim', 2, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (6, N'Dennis', N'Nunez', 2, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (7, N'Myra', N'Zuniga', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (8, N'Teddy', N'Ingram', 2, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (9, N'Annie', N'Larson', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (10, N'Karen', N'Anderson', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (11, N'Jenifer', N'Livingston', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (12, N'Stefanie', N'Perez', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (13, N'Chastity', N'Garcia', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (14, N'Evelyn', N'Stokes', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (15, N'Jeannie', N'Daniel', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (16, N'Rickey', N'Santos', 2, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (17, N'Bobbie', N'Hurst', 2, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (18, N'Lesley', N'Lawson', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (19, N'Shawna', N'Browning', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (20, N'Theresa', N'Ross', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (21, N'Tasha', N'Hughes', 3, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (22, N'Karla', N'Hale', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (23, N'Otis', N'Holt', 2, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (24, N'Alisa', N'Browning', 3, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (25, N'Peggy', N'Donaldson', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (26, N'Lisa', N'Bentley', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (27, N'Vicky', N'Wiley', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (28, N'Nicolas', N'Spence', 2, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (29, N'Miranda', N'Barnes', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (30, N'Karen', N'Barry', 1, 1)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (31, N'Rosemary', N'Levine', 3, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (32, N'Ernest', N'Gamble', 2, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (33, N'Lindsay', N'Henderson', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (34, N'Lorenzo', N'Adams', 2, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (35, N'Tammie', N'Graves', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (36, N'Kareem', N'Benton', 3, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (37, N'Cesar', N'Vance', 3, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (38, N'Charlene', N'Rocha', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (39, N'Sonja', N'Mac Donald', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (40, N'Gwendolyn', N'Russell', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (41, N'Stephan', N'Hill', 2, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (42, N'Maggie', N'Day', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (43, N'Earnest', N'Walters', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (44, N'Zachary', N'Pratt', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (45, N'Erin', N'Hinton', 3, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (46, N'Rodolfo', N'Collier', 2, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (47, N'Carla', N'Jackson', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (48, N'Norma', N'Robles', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (49, N'Jean', N'Haynes', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (50, N'Tara', N'Pope', 3, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (51, N'Ann', N'Patterson', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (52, N'Nancy', N'Lebow', 3, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (53, N'Joe', N'Hansen', 2, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (54, N'Joe', N'Hansen', 2, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (55, N'Jill', N'Gallagher', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (56, N'Sunshine', N'Miller', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (57, N'Annabelle', N'Huff', 1, 0)
GO
INSERT [dbo].[Persons1] ([id], [FirstName], [LastName], [GenderIdentifier], [IsDeleted]) VALUES (58, N'Pam', N'Gallagher', 3, 0)
GO
SET IDENTITY_INSERT [dbo].[Persons1] OFF
GO
ALTER TABLE [dbo].[Persons1]  WITH CHECK ADD  CONSTRAINT [FK_Persons1_GenderTypes] FOREIGN KEY([GenderIdentifier])
REFERENCES [dbo].[GenderTypes] ([GenderIdentifier])
GO
ALTER TABLE [dbo].[Persons1] CHECK CONSTRAINT [FK_Persons1_GenderTypes]
GO
USE [master]
GO
ALTER DATABASE [People1] SET  READ_WRITE 
GO
