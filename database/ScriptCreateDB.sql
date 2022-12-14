USE [master]
GO
/****** Object:  Database [PruebaDW]    Script Date: 8/31/2022 1:38:59 PM ******/
CREATE DATABASE [PruebaDW]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaDW', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PruebaDW.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PruebaDW_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PruebaDW_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PruebaDW] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaDW].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaDW] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PruebaDW] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PruebaDW] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PruebaDW] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PruebaDW] SET ARITHABORT OFF 
GO
ALTER DATABASE [PruebaDW] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PruebaDW] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PruebaDW] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PruebaDW] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PruebaDW] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PruebaDW] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PruebaDW] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PruebaDW] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PruebaDW] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PruebaDW] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PruebaDW] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PruebaDW] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PruebaDW] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PruebaDW] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PruebaDW] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PruebaDW] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PruebaDW] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PruebaDW] SET RECOVERY FULL 
GO
ALTER DATABASE [PruebaDW] SET  MULTI_USER 
GO
ALTER DATABASE [PruebaDW] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PruebaDW] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PruebaDW] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PruebaDW] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PruebaDW] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PruebaDW] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PruebaDW', N'ON'
GO
ALTER DATABASE [PruebaDW] SET QUERY_STORE = OFF
GO
USE [PruebaDW]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/31/2022 1:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 8/31/2022 1:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Phone] [varchar](10) NOT NULL,
	[IdentificationDocument] [varchar](10) NULL,
	[Adress] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 8/31/2022 1:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[SubTotal] [money] NOT NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 8/31/2022 1:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Num] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 8/31/2022 1:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (7, N'Tecnologia')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (8, N'Celulares y accesorios')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (9, N'Electrodomésticos')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (10, N'Hogar y muebles')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (11, N'Salud')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (12, N'Bebés')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Phone], [IdentificationDocument], [Adress], [Email], [DateOfBirth]) VALUES (6, N'Andrea', N'Rosas', N'3215658545', N'1002554444', N'Calle 50 B', N'andrea@gmail.com', CAST(N'1977-03-22T05:00:00.000' AS DateTime))
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Phone], [IdentificationDocument], [Adress], [Email], [DateOfBirth]) VALUES (7, N'Camilo ', N'Suarez', N'3258964512', N'1205258100', N'Carrera 15 89-96', N'camilo@gmail.com', CAST(N'1995-07-20T05:00:00.000' AS DateTime))
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Phone], [IdentificationDocument], [Adress], [Email], [DateOfBirth]) VALUES (9, N'Alejandra', N'Murillo', N'3203763530', N'1057608099', N'Carrera 11 B # 58 A 14', N'malemurillo15@gmail.com', CAST(N'1999-01-16T05:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceDetails] ON 

INSERT [dbo].[InvoiceDetails] ([Id], [InvoiceId], [ProductId], [Quantity], [SubTotal]) VALUES (6, 3, 5, 1, 2150000.0000)
INSERT [dbo].[InvoiceDetails] ([Id], [InvoiceId], [ProductId], [Quantity], [SubTotal]) VALUES (7, 3, 7, 2, 5000000.0000)
INSERT [dbo].[InvoiceDetails] ([Id], [InvoiceId], [ProductId], [Quantity], [SubTotal]) VALUES (8, 4, 8, 2, 100000.0000)
INSERT [dbo].[InvoiceDetails] ([Id], [InvoiceId], [ProductId], [Quantity], [SubTotal]) VALUES (9, 5, 9, 1, 2200000.0000)
INSERT [dbo].[InvoiceDetails] ([Id], [InvoiceId], [ProductId], [Quantity], [SubTotal]) VALUES (10, 5, 8, 1, 50000.0000)
INSERT [dbo].[InvoiceDetails] ([Id], [InvoiceId], [ProductId], [Quantity], [SubTotal]) VALUES (11, 5, 7, 1, 2500000.0000)
INSERT [dbo].[InvoiceDetails] ([Id], [InvoiceId], [ProductId], [Quantity], [SubTotal]) VALUES (13, 7, 10, 1, 1355000.0000)
SET IDENTITY_INSERT [dbo].[InvoiceDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoices] ON 

INSERT [dbo].[Invoices] ([Id], [CustomerId], [Num], [Date], [Total]) VALUES (3, 9, 1, CAST(N'2000-01-09T13:04:55.183' AS DateTime), 7150000)
INSERT [dbo].[Invoices] ([Id], [CustomerId], [Num], [Date], [Total]) VALUES (4, 9, 2, CAST(N'2000-02-12T13:07:16.707' AS DateTime), 100000)
INSERT [dbo].[Invoices] ([Id], [CustomerId], [Num], [Date], [Total]) VALUES (5, 7, 3, CAST(N'2000-03-05T13:10:42.840' AS DateTime), 4750000)
INSERT [dbo].[Invoices] ([Id], [CustomerId], [Num], [Date], [Total]) VALUES (7, 6, 4, CAST(N'2000-05-23T13:12:37.357' AS DateTime), 1355000)
SET IDENTITY_INSERT [dbo].[Invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Price], [Stock]) VALUES (5, 7, N'Portatil lenovo ', 2150000, 7)
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Price], [Stock]) VALUES (6, 7, N'Smart Band 6 ', 258000, 10)
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Price], [Stock]) VALUES (7, 8, N'Iphone X', 2500000, 18)
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Price], [Stock]) VALUES (8, 8, N'Cargador Iphone', 50000, 100)
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Price], [Stock]) VALUES (9, 9, N'Tv Samsung 55''''', 2200000, 15)
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Price], [Stock]) VALUES (10, 10, N'Comedor', 1355000, 4)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Invoices] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([Id])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Invoices]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Products]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Customers]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
USE [master]
GO
ALTER DATABASE [PruebaDW] SET  READ_WRITE 
GO
