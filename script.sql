USE [master]
GO
/****** Object:  Database [DiagnosticCenterBillManagementSystemDB]    Script Date: 10/29/2016 11:55:38 PM ******/
CREATE DATABASE [DiagnosticCenterBillManagementSystemDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DiagnosticCenterBillManagementSystemDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DiagnosticCenterBillManagementSystemDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DiagnosticCenterBillManagementSystemDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DiagnosticCenterBillManagementSystemDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DiagnosticCenterBillManagementSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET  MULTI_USER 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DiagnosticCenterBillManagementSystemDB]
GO
/****** Object:  Table [dbo].[TestRequests]    Script Date: 10/29/2016 11:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestRequests](
	[TestRequestId] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [varchar](50) NULL,
	[MobileNo] [numeric](18, 0) NULL,
	[SelectTest] [int] NULL,
	[Fee] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[Date] [date] NULL,
	[BillNo] [int] NULL,
 CONSTRAINT [PK_TestRequests] PRIMARY KEY CLUSTERED 
(
	[TestRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tests]    Script Date: 10/29/2016 11:55:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tests](
	[TestId] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [varchar](50) NULL,
	[Fee] [decimal](18, 2) NULL,
	[TestType] [varchar](50) NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestType]    Script Date: 10/29/2016 11:55:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestType](
	[TestTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NULL,
 CONSTRAINT [PK_TestType] PRIMARY KEY CLUSTERED 
(
	[TestTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TestRequests] ON 

INSERT [dbo].[TestRequests] ([TestRequestId], [PatientName], [MobileNo], [SelectTest], [Fee], [Total], [Date], [BillNo]) VALUES (1, N'Abul', CAST(1746942801 AS Numeric(18, 0)), 1, CAST(270.00 AS Decimal(18, 2)), CAST(270.00 AS Decimal(18, 2)), CAST(0x033C0B00 AS Date), 1)
INSERT [dbo].[TestRequests] ([TestRequestId], [PatientName], [MobileNo], [SelectTest], [Fee], [Total], [Date], [BillNo]) VALUES (3, N'goga', CAST(987654321 AS Numeric(18, 0)), 3, CAST(320.00 AS Decimal(18, 2)), CAST(590.00 AS Decimal(18, 2)), CAST(0x033C0B00 AS Date), 2)
SET IDENTITY_INSERT [dbo].[TestRequests] OFF
SET IDENTITY_INSERT [dbo].[Tests] ON 

INSERT [dbo].[Tests] ([TestId], [TestName], [Fee], [TestType]) VALUES (2007, N'RBS', CAST(150.00 AS Decimal(18, 2)), N'1')
INSERT [dbo].[Tests] ([TestId], [TestName], [Fee], [TestType]) VALUES (2008, N'Hand X-ray', CAST(200.00 AS Decimal(18, 2)), N'1')
INSERT [dbo].[Tests] ([TestId], [TestName], [Fee], [TestType]) VALUES (2009, N'Feet X-ray', CAST(200.00 AS Decimal(18, 2)), N'1')
INSERT [dbo].[Tests] ([TestId], [TestName], [Fee], [TestType]) VALUES (3006, N'LS Spine', CAST(1100.00 AS Decimal(18, 2)), N'1')
SET IDENTITY_INSERT [dbo].[Tests] OFF
SET IDENTITY_INSERT [dbo].[TestType] ON 

INSERT [dbo].[TestType] ([TestTypeId], [TypeName]) VALUES (3046, N' ')
INSERT [dbo].[TestType] ([TestTypeId], [TypeName]) VALUES (2005, N'ECG')
INSERT [dbo].[TestType] ([TestTypeId], [TypeName]) VALUES (2006, N'X-Ray')
SET IDENTITY_INSERT [dbo].[TestType] OFF
/****** Object:  Index [IX_Table_BillNo]    Script Date: 10/29/2016 11:55:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Table_BillNo] ON [dbo].[TestRequests]
(
	[BillNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Table_TypeName]    Script Date: 10/29/2016 11:55:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Table_TypeName] ON [dbo].[TestType]
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET  READ_WRITE 
GO
