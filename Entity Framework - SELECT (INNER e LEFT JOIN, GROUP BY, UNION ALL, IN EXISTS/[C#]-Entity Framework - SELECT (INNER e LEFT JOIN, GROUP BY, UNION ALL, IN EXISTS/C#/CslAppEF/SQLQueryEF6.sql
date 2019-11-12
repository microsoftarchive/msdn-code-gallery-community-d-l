USE [master]
GO

/****** Object:  Database [EFramework]    Script Date: 07/03/2014 15:31:20 ******/
CREATE DATABASE [EFramework]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EFramework', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\EFramework.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EFramework_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\EFramework_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [EFramework] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EFramework].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [EFramework] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [EFramework] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [EFramework] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [EFramework] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [EFramework] SET ARITHABORT OFF 
GO

ALTER DATABASE [EFramework] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [EFramework] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [EFramework] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [EFramework] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [EFramework] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [EFramework] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [EFramework] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [EFramework] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [EFramework] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [EFramework] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [EFramework] SET  DISABLE_BROKER 
GO

ALTER DATABASE [EFramework] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [EFramework] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [EFramework] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [EFramework] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [EFramework] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [EFramework] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [EFramework] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [EFramework] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [EFramework] SET  MULTI_USER 
GO

ALTER DATABASE [EFramework] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [EFramework] SET DB_CHAINING OFF 
GO

ALTER DATABASE [EFramework] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [EFramework] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [EFramework] SET  READ_WRITE 
GO


USE [EFramework]
GO

/****** Object:  Table [dbo].[Pessoa]    Script Date: 07/03/2014 15:31:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pessoa](
	[PessoaId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[DataNascimento] [datetime] NULL,
 CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED 
(
	[PessoaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [EFramework]
GO

/****** Object:  Table [dbo].[TbA]    Script Date: 07/03/2014 15:31:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TbA](
	[Id] [int] NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TbA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [EFramework]
GO

/****** Object:  Table [dbo].[TbB]    Script Date: 07/03/2014 15:31:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TbB](
	[Id] [int] NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TbB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [EFramework]
GO

/****** Object:  Table [dbo].[Telefone]    Script Date: 07/03/2014 15:32:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Telefone](
	[TelefoneId] [int] IDENTITY(1,1) NOT NULL,
	[PessoaId] [int] NULL,
	[Ddd] [nvarchar](3) NOT NULL,
	[Numero] [nvarchar](14) NOT NULL,
 CONSTRAINT [PK_Telefone] PRIMARY KEY CLUSTERED 
(
	[TelefoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Telefone]  WITH CHECK ADD  CONSTRAINT [FK_Telefone_Pessoa] FOREIGN KEY([PessoaId])
REFERENCES [dbo].[Pessoa] ([PessoaId])
GO

ALTER TABLE [dbo].[Telefone] CHECK CONSTRAINT [FK_Telefone_Pessoa]
GO





