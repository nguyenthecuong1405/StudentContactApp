USE [master]
GO
/****** Object:  Database [StudentContactDB]    Script Date: 05/12/2024 11:29:53 CH ******/
CREATE DATABASE [StudentContactDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentContactDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\StudentContactDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentContactDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\StudentContactDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [StudentContactDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentContactDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentContactDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentContactDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentContactDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentContactDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentContactDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentContactDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentContactDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentContactDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentContactDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentContactDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentContactDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentContactDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentContactDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentContactDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentContactDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentContactDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentContactDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentContactDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentContactDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentContactDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentContactDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentContactDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentContactDB] SET RECOVERY FULL 
GO
ALTER DATABASE [StudentContactDB] SET  MULTI_USER 
GO
ALTER DATABASE [StudentContactDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentContactDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentContactDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentContactDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentContactDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentContactDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'StudentContactDB', N'ON'
GO
ALTER DATABASE [StudentContactDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [StudentContactDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [StudentContactDB]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 05/12/2024 11:29:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[AttendanceID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NULL,
	[Date] [date] NOT NULL,
	[IsPresent] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AttendanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluation]    Script Date: 05/12/2024 11:29:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluation](
	[EvaluationID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[TEvaluation] [nvarchar](max) NOT NULL,
	[PFeedback] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EvaluationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 05/12/2024 11:29:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[NotificationID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[NotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 05/12/2024 11:29:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[Day] [nvarchar](20) NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[Time] [nvarchar](50) NOT NULL,
	[TeacherID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 05/12/2024 11:29:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Class] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 05/12/2024 11:29:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Attendance] ON 

INSERT [dbo].[Attendance] ([AttendanceID], [StudentID], [Date], [IsPresent]) VALUES (1, 1, CAST(N'2024-12-01' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Attendance] OFF
GO
SET IDENTITY_INSERT [dbo].[Evaluation] ON 

INSERT [dbo].[Evaluation] ([EvaluationID], [Name], [TEvaluation], [PFeedback]) VALUES (3, N'nguyen van a', N'trên lớp con hăng hái phát biểu xây dựng bài ', N'cảm ơn cô giáo')
INSERT [dbo].[Evaluation] ([EvaluationID], [Name], [TEvaluation], [PFeedback]) VALUES (4, N'nguyen van b', N'học tập, ghi chép bài đầy đủ  nghe lời giáo viên ', N'cảm ơn cô giáo')
INSERT [dbo].[Evaluation] ([EvaluationID], [Name], [TEvaluation], [PFeedback]) VALUES (5, N'nguyen van c', N'thiếu chú ý trong giờ  ', N'tôi sẽ nhắc nhở cháu')
SET IDENTITY_INSERT [dbo].[Evaluation] OFF
GO
SET IDENTITY_INSERT [dbo].[Notifications] ON 

INSERT [dbo].[Notifications] ([NotificationID], [Title], [Content], [DateCreated]) VALUES (1, N'test', N'test', CAST(N'2024-12-05T13:30:13.347' AS DateTime))
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Content], [DateCreated]) VALUES (3, N'lớp 10A3', N'chiều mai lớp đc nghỉ do giáo viên bận họp', CAST(N'2024-12-05T21:15:33.177' AS DateTime))
SET IDENTITY_INSERT [dbo].[Notifications] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([ScheduleID], [Day], [Subject], [Time], [TeacherID]) VALUES (5, N'Thứ hai', N'Toán', N'7h-9h', 1)
INSERT [dbo].[Schedule] ([ScheduleID], [Day], [Subject], [Time], [TeacherID]) VALUES (6, N'Thứ hai', N'Hóa', N'10h-12h', 3)
INSERT [dbo].[Schedule] ([ScheduleID], [Day], [Subject], [Time], [TeacherID]) VALUES (7, N'Thứ ba', N'Lý', N'1h-3h', 4)
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentID], [FullName], [Class], [DateOfBirth]) VALUES (1, N'Nguy?n Văn A', N'10A1', CAST(N'2007-05-01' AS Date))
INSERT [dbo].[Students] ([StudentID], [FullName], [Class], [DateOfBirth]) VALUES (2, N'Tr?n Th? B', N'10A1', CAST(N'2007-09-15' AS Date))
INSERT [dbo].[Students] ([StudentID], [FullName], [Class], [DateOfBirth]) VALUES (3, N'nguyên văn c', N'10A3', CAST(N'2024-12-04' AS Date))
INSERT [dbo].[Students] ([StudentID], [FullName], [Class], [DateOfBirth]) VALUES (4, N'nguyen van d', N'10a2', CAST(N'2024-11-29' AS Date))
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([TeacherID], [FullName], [Subject], [Phone]) VALUES (1, N'A', N'Toan', N'0987')
INSERT [dbo].[Teachers] ([TeacherID], [FullName], [Subject], [Phone]) VALUES (3, N'B', N'ly', N'09999')
INSERT [dbo].[Teachers] ([TeacherID], [FullName], [Subject], [Phone]) VALUES (4, N'C', N'Hoa', N'09777')
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
ALTER TABLE [dbo].[Notifications] ADD  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teachers] ([TeacherID])
GO
USE [master]
GO
ALTER DATABASE [StudentContactDB] SET  READ_WRITE 
GO
