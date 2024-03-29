USE [master]
GO
/****** Object:  Database [dorm]    Script Date: 25-Mar-24 3:33:14 PM ******/
CREATE DATABASE [dorm]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dorm', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAMDUNG\MSSQL\DATA\dorm.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dorm_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAMDUNG\MSSQL\DATA\dorm_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dorm] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dorm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dorm] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dorm] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dorm] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dorm] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dorm] SET ARITHABORT OFF 
GO
ALTER DATABASE [dorm] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dorm] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dorm] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dorm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dorm] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dorm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dorm] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dorm] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dorm] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dorm] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dorm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dorm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dorm] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dorm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dorm] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dorm] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dorm] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dorm] SET RECOVERY FULL 
GO
ALTER DATABASE [dorm] SET  MULTI_USER 
GO
ALTER DATABASE [dorm] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dorm] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dorm] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dorm] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dorm] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dorm] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dorm', N'ON'
GO
ALTER DATABASE [dorm] SET QUERY_STORE = OFF
GO
USE [dorm]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25-Mar-24 3:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bed]    Script Date: 25-Mar-24 3:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bed](
	[bed_id] [int] IDENTITY(1,1) NOT NULL,
	[room_id] [int] NULL,
	[bed_number] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[bed_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[booking_request]    Script Date: 25-Mar-24 3:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booking_request](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[resident_id] [int] NOT NULL,
	[bed_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dormitory]    Script Date: 25-Mar-24 3:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dormitory](
	[dormitory_id] [int] IDENTITY(1,1) NOT NULL,
	[dormitory_name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[dormitory_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[electricity_bill]    Script Date: 25-Mar-24 3:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[electricity_bill](
	[bill_id] [int] IDENTITY(1,1) NOT NULL,
	[room_id] [int] NULL,
	[month] [int] NOT NULL,
	[year] [int] NOT NULL,
	[amount] [decimal](10, 2) NOT NULL,
	[payment_status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[bill_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[register_token]    Script Date: 25-Mar-24 3:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[register_token](
	[token_id] [int] IDENTITY(1,1) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[gender] [varchar](10) NOT NULL,
	[mail] [varchar](255) NOT NULL,
	[dob] [date] NOT NULL,
	[expire_date] [datetime] NOT NULL,
	[token_code] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[token_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[room]    Script Date: 25-Mar-24 3:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[room](
	[room_id] [int] IDENTITY(1,1) NOT NULL,
	[dormitory_id] [int] NULL,
	[room_number] [varchar](50) NOT NULL,
	[floor] [int] NOT NULL,
	[room_type_id] [int] NULL,
	[availability_status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[room_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[room_allocation]    Script Date: 25-Mar-24 3:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[room_allocation](
	[allocation_id] [int] IDENTITY(1,1) NOT NULL,
	[resident_id] [int] NULL,
	[bed_id] [int] NULL,
	[move_in_date] [date] NOT NULL,
	[move_out_date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[allocation_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[room_type]    Script Date: 25-Mar-24 3:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[room_type](
	[room_type_id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [varchar](255) NOT NULL,
	[max_beds] [int] NOT NULL,
	[price_per_month] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[room_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 25-Mar-24 3:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](255) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[role_id] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[dob] [date] NULL,
	[gender] [varchar](10) NULL,
	[mail] [varchar](255) NULL,
	[student_code] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_role]    Script Date: 25-Mar-24 3:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[water_bill]    Script Date: 25-Mar-24 3:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[water_bill](
	[bill_id] [int] IDENTITY(1,1) NOT NULL,
	[room_id] [int] NULL,
	[month] [int] NOT NULL,
	[year] [int] NOT NULL,
	[amount] [decimal](10, 2) NOT NULL,
	[payment_status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[bill_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[bed]  WITH CHECK ADD FOREIGN KEY([room_id])
REFERENCES [dbo].[room] ([room_id])
GO
ALTER TABLE [dbo].[booking_request]  WITH CHECK ADD  CONSTRAINT [FK_BookingRequest_Bed] FOREIGN KEY([bed_id])
REFERENCES [dbo].[bed] ([bed_id])
GO
ALTER TABLE [dbo].[booking_request] CHECK CONSTRAINT [FK_BookingRequest_Bed]
GO
ALTER TABLE [dbo].[booking_request]  WITH CHECK ADD  CONSTRAINT [FK_BookingRequest_Resident] FOREIGN KEY([resident_id])
REFERENCES [dbo].[user] ([user_id])
GO
ALTER TABLE [dbo].[booking_request] CHECK CONSTRAINT [FK_BookingRequest_Resident]
GO
ALTER TABLE [dbo].[electricity_bill]  WITH CHECK ADD FOREIGN KEY([room_id])
REFERENCES [dbo].[room] ([room_id])
GO
ALTER TABLE [dbo].[room]  WITH CHECK ADD FOREIGN KEY([dormitory_id])
REFERENCES [dbo].[dormitory] ([dormitory_id])
GO
ALTER TABLE [dbo].[room]  WITH CHECK ADD FOREIGN KEY([room_type_id])
REFERENCES [dbo].[room_type] ([room_type_id])
GO
ALTER TABLE [dbo].[room_allocation]  WITH CHECK ADD FOREIGN KEY([bed_id])
REFERENCES [dbo].[bed] ([bed_id])
GO
ALTER TABLE [dbo].[room_allocation]  WITH CHECK ADD FOREIGN KEY([bed_id])
REFERENCES [dbo].[bed] ([bed_id])
GO
ALTER TABLE [dbo].[room_allocation]  WITH CHECK ADD FOREIGN KEY([resident_id])
REFERENCES [dbo].[user] ([user_id])
GO
ALTER TABLE [dbo].[room_allocation]  WITH CHECK ADD FOREIGN KEY([resident_id])
REFERENCES [dbo].[user] ([user_id])
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[user_role] ([role_id])
GO
ALTER TABLE [dbo].[water_bill]  WITH CHECK ADD FOREIGN KEY([room_id])
REFERENCES [dbo].[room] ([room_id])
GO
USE [master]
GO
ALTER DATABASE [dorm] SET  READ_WRITE 
GO
