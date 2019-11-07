
/****** 
	* Before running this script ensure the path exists
	* You should be able to run this script here inside of Visual Studio.
 ******/
USE [master]
GO

CREATE DATABASE [ExampleDataGridViewComboBox_1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExampleDataGridViewComboBox_1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ExampleDataGridViewComboBox_1.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ExampleDataGridViewComboBox_1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ExampleDataGridViewComboBox_1_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExampleDataGridViewComboBox_1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET RECOVERY FULL 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET  MULTI_USER 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ExampleDataGridViewComboBox_1]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 9/10/2016 5:35:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorId] [int] IDENTITY(1,1) NOT NULL,
	[ColorText] [nvarchar](max) NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Information]    Script Date: 9/10/2016 5:35:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Information](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
 CONSTRAINT [PK_Information] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 9/10/2016 5:35:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ColorId] [int] NULL,
	[FirstName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

GO
INSERT [dbo].[Colors] ([ColorId], [ColorText]) VALUES (1, N'Red')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorText]) VALUES (2, N'Blue')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorText]) VALUES (3, N'Green')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorText]) VALUES (4, N'AntiqueWhite')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorText]) VALUES (5, N'Brown')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorText]) VALUES (6, N'DarkOrchid')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorText]) VALUES (7, N'Black')
GO
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Information] ON 

GO
INSERT [dbo].[Information] ([Id], [Text]) VALUES (1, N'You must had picked red')
GO
INSERT [dbo].[Information] ([Id], [Text]) VALUES (2, N'You must had picked blue')
GO
INSERT [dbo].[Information] ([Id], [Text]) VALUES (3, N'You must had picked green')
GO
INSERT [dbo].[Information] ([Id], [Text]) VALUES (4, N'You must had picked green Antique white')
GO
INSERT [dbo].[Information] ([Id], [Text]) VALUES (5, N'You must had picked brown')
GO
INSERT [dbo].[Information] ([Id], [Text]) VALUES (6, N'You must had picked  dark orchid')
GO
INSERT [dbo].[Information] ([Id], [Text]) VALUES (7, N'You must had picked black')
GO
SET IDENTITY_INSERT [dbo].[Information] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

GO
INSERT [dbo].[Person] ([Id], [ColorId], [FirstName]) VALUES (1, 2, N'Mary')
GO
INSERT [dbo].[Person] ([Id], [ColorId], [FirstName]) VALUES (2, 4, N'Karen')
GO
INSERT [dbo].[Person] ([Id], [ColorId], [FirstName]) VALUES (3, 6, N'Anne')
GO
INSERT [dbo].[Person] ([Id], [ColorId], [FirstName]) VALUES (4, 2, N'John')
GO
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
USE [master]
GO
ALTER DATABASE [ExampleDataGridViewComboBox_1] SET  READ_WRITE 
GO
