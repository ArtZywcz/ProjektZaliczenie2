USE [master]
GO
/****** Object:  Database [MountainHut]    Script Date: 15/07/2020 23:36:28 ******/
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
/****** Object:  Table [dbo].[Employees]    Script Date: 15/07/2020 23:36:29 ******/
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
/****** Object:  Table [dbo].[Reservations]    Script Date: 15/07/2020 23:36:29 ******/
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
/****** Object:  Table [dbo].[Rooms]    Script Date: 15/07/2020 23:36:29 ******/
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
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [Name], [Surname], [EmployeeLogin], [EmployeePassword], [BirthDate], [EmploymendDate], [PhoneNumber], [Email], [Priviliges]) VALUES (1, N'Adam', N'Abacki', N'adas14', N'password', CAST(N'1996-10-04' AS Date), CAST(N'2000-01-01' AS Date), N'88607059', N'artzywcz@interia.eu', 7)
INSERT [dbo].[Employees] ([EmployeeID], [Name], [Surname], [EmployeeLogin], [EmployeePassword], [BirthDate], [EmploymendDate], [PhoneNumber], [Email], [Priviliges]) VALUES (2, N'Barbara', N'Babacka', N'xxxbasiaxxx', N'12345678', CAST(N'2000-01-01' AS Date), CAST(N'2012-12-12' AS Date), N'68468479', N'basiabe@gmail.com', 3)
INSERT [dbo].[Employees] ([EmployeeID], [Name], [Surname], [EmployeeLogin], [EmployeePassword], [BirthDate], [EmploymendDate], [PhoneNumber], [Email], [Priviliges]) VALUES (3, N'Cyprian', N'Cabacki', N'cyprek69', N'p@$$w0rd', CAST(N'1969-06-09' AS Date), CAST(N'2020-10-06' AS Date), N'+2019656779', N'cyprek@wp.pl', 1)
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([ReservationID], [Date], [Name], [Surname], [RoomID], [SlotsQuantity], [PhoneNumber], [EmployeeID]) VALUES (1, CAST(N'2020-06-16' AS Date), N'Dariusz', N'Dabacki', 1, 8, N'123456789', 1)
INSERT [dbo].[Reservations] ([ReservationID], [Date], [Name], [Surname], [RoomID], [SlotsQuantity], [PhoneNumber], [EmployeeID]) VALUES (2, CAST(N'2020-06-16' AS Date), N'Ewelina', N'Ebacka', 4, 4, N'987654321', 1)
INSERT [dbo].[Reservations] ([ReservationID], [Date], [Name], [Surname], [RoomID], [SlotsQuantity], [PhoneNumber], [EmployeeID]) VALUES (3, CAST(N'2020-06-16' AS Date), N'Filip', N'Fabacki', 4, 2, N'456789142', 1)
INSERT [dbo].[Reservations] ([ReservationID], [Date], [Name], [Surname], [RoomID], [SlotsQuantity], [PhoneNumber], [EmployeeID]) VALUES (4, CAST(N'2020-06-16' AS Date), N'Grzegorz', N'Gabacki', 4, 1, N'325214569', 2)
INSERT [dbo].[Reservations] ([ReservationID], [Date], [Name], [Surname], [RoomID], [SlotsQuantity], [PhoneNumber], [EmployeeID]) VALUES (5, CAST(N'2020-06-16' AS Date), N'Henryk', N'Habacki', 11, 2, N'987522525', 2)
SET IDENTITY_INSERT [dbo].[Reservations] OFF
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (1, 8, 42, 0)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (2, 5, 48, 0)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (3, 6, 45, 0)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (4, 12, 42, 0)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (5, 16, 42, 0)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (6, 3, 70, 1)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (7, 4, 65, 1)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (8, 4, 65, 1)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (9, 4, 55, 0)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (10, 3, 70, 1)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (11, 2, 75, 1)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (12, 2, 70, 0)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (13, 2, 70, 0)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (14, 4, 55, 0)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (15, 2, 70, 1)
INSERT [dbo].[Rooms] ([RoomID], [MaxCapacity], [Price], [HasBathroom]) VALUES (16, 2, 65, 0)
SET IDENTITY_INSERT [dbo].[Rooms] OFF
ALTER TABLE [dbo].[Rooms] ADD  CONSTRAINT [DF_Rooms_HasBathroom]  DEFAULT ((0)) FOR [HasBathroom]
GO
USE [master]
GO
ALTER DATABASE [MountainHut] SET  READ_WRITE 
GO
