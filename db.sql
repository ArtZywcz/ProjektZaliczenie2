USE [master]
GO
/****** Object:  Database [MountainHut]    Script Date: 29/06/2020 00:04:30 ******/
CREATE DATABASE [MountainHut]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MountainHut', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MountainHut.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MountainHut_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MountainHut_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MountainHut] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MountainHut].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MountainHut] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MountainHut] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MountainHut] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MountainHut] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MountainHut] SET ARITHABORT OFF 
GO
ALTER DATABASE [MountainHut] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MountainHut] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MountainHut] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MountainHut] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MountainHut] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MountainHut] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MountainHut] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MountainHut] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MountainHut] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MountainHut] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MountainHut] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MountainHut] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MountainHut] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MountainHut] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MountainHut] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MountainHut] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MountainHut] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MountainHut] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MountainHut] SET  MULTI_USER 
GO
ALTER DATABASE [MountainHut] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MountainHut] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MountainHut] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MountainHut] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MountainHut] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MountainHut] SET QUERY_STORE = OFF
GO
USE [MountainHut]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 29/06/2020 00:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Surname] [varchar](32) NOT NULL,
	[EmployeeLogin] [varchar](50) NULL,
	[EmployeePassword] [varchar](50) NULL,
	[BirthDate] [date] NOT NULL,
	[EmploymendDate] [date] NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[Email] [varchar](64) NULL,
	[Priviliges] [smallint] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 29/06/2020 00:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Name] [varchar](64) NULL,
	[Surname] [varchar](64) NOT NULL,
	[RoomID] [int] NOT NULL,
	[SlotsQuantity] [int] NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 29/06/2020 00:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[MaxCapacity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[HasBathroom] [bit] NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Rooms] ADD  CONSTRAINT [DF_Rooms_HasBathroom]  DEFAULT ((0)) FOR [HasBathroom]
GO
USE [master]
GO
ALTER DATABASE [MountainHut] SET  READ_WRITE 
GO
