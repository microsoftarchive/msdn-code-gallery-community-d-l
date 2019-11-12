USE [master]
GO
/****** Object:  Database [msdn_ConnectionProtection]    Script Date: 8/5/2017 12:43:20 PM ******/
CREATE DATABASE [msdn_ConnectionProtection]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'msdn_ConnectionProtection', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\msdn_ConnectionProtection.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'msdn_ConnectionProtection_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\msdn_ConnectionProtection_log.ldf' , SIZE = 3456KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [msdn_ConnectionProtection] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [msdn_ConnectionProtection].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [msdn_ConnectionProtection] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET ARITHABORT OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET  DISABLE_BROKER 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET RECOVERY FULL 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET  MULTI_USER 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [msdn_ConnectionProtection] SET DB_CHAINING OFF 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [msdn_ConnectionProtection] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [msdn_ConnectionProtection]
GO
/****** Object:  Table [dbo].[People]    Script Date: 8/5/2017 12:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Identifier] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
INSERT [dbo].[People] ([Identifier], [FirstName], [LastName]) VALUES (1, N'Stefanie', N'Buckley')
GO
INSERT [dbo].[People] ([Identifier], [FirstName], [LastName]) VALUES (2, N'Sandy', N'Mc Gee')
GO
INSERT [dbo].[People] ([Identifier], [FirstName], [LastName]) VALUES (3, N'Lee', N'Warren')
GO
INSERT [dbo].[People] ([Identifier], [FirstName], [LastName]) VALUES (4, N'Regina', N'Forbes')
GO
INSERT [dbo].[People] ([Identifier], [FirstName], [LastName]) VALUES (5, N'Daniel', N'Kim')
GO
INSERT [dbo].[People] ([Identifier], [FirstName], [LastName]) VALUES (6, N'Dennis', N'Nunez')
GO
INSERT [dbo].[People] ([Identifier], [FirstName], [LastName]) VALUES (7, N'Myra', N'Zuniga')
GO
INSERT [dbo].[People] ([Identifier], [FirstName], [LastName]) VALUES (8, N'Teddy', N'Ingram')
GO
INSERT [dbo].[People] ([Identifier], [FirstName], [LastName]) VALUES (9, N'Annie', N'Larson')
GO
INSERT [dbo].[People] ([Identifier], [FirstName], [LastName]) VALUES (10, N'Herman', N'Anderson')
GO
USE [master]
GO
ALTER DATABASE [msdn_ConnectionProtection] SET  READ_WRITE 
GO
