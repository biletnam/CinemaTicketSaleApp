USE [master]
GO
/****** Object:  Database [MasterCinema]    Script Date: 15.08.2016 22:15:38 ******/
CREATE DATABASE [MasterCinema]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MasterCinema', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MasterCinema.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MasterCinema_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MasterCinema_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MasterCinema] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MasterCinema].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MasterCinema] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MasterCinema] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MasterCinema] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MasterCinema] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MasterCinema] SET ARITHABORT OFF 
GO
ALTER DATABASE [MasterCinema] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MasterCinema] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MasterCinema] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MasterCinema] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MasterCinema] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MasterCinema] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MasterCinema] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MasterCinema] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MasterCinema] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MasterCinema] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MasterCinema] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MasterCinema] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MasterCinema] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MasterCinema] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MasterCinema] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MasterCinema] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MasterCinema] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MasterCinema] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MasterCinema] SET  MULTI_USER 
GO
ALTER DATABASE [MasterCinema] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MasterCinema] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MasterCinema] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MasterCinema] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MasterCinema] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MasterCinema', N'ON'
GO
USE [MasterCinema]
GO
/****** Object:  Table [dbo].[AudienceType]    Script Date: 15.08.2016 22:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AudienceType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_AudienceType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 15.08.2016 22:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[NationalityNumber] [char](11) NOT NULL,
	[GenderID] [int] NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[TitleID] [int] NOT NULL,
	[PhoneNumber] [char](20) NULL,
	[Username] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Employee] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 15.08.2016 22:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Movie]    Script Date: 15.08.2016 22:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movie](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](60) NOT NULL,
	[ReleaseDate] [date] NULL,
	[Duration] [smallint] NOT NULL,
	[Poster] [varbinary](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Movie_MovieGenre]    Script Date: 15.08.2016 22:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_MovieGenre](
	[MovieID] [int] NOT NULL,
	[MovieGenreID] [int] NOT NULL,
 CONSTRAINT [PK_Movie_MovieGenre] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC,
	[MovieGenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MovieGenre]    Script Date: 15.08.2016 22:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieGenre](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_MovieGenre] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MovieTheater]    Script Date: 15.08.2016 22:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieTheater](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[SeatingCapacity] [tinyint] NOT NULL,
 CONSTRAINT [PK_MovieTheater] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Session]    Script Date: 15.08.2016 22:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Time] [time](4) NOT NULL,
	[MovieID] [int] NOT NULL,
	[MovieTheatreID] [int] NOT NULL,
 CONSTRAINT [PK_Session_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Session_Ticket]    Script Date: 15.08.2016 22:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session_Ticket](
	[SessionID] [int] NOT NULL,
	[TicketID] [int] NOT NULL,
 CONSTRAINT [PK_Session_Ticket] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC,
	[TicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 15.08.2016 22:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AudienceTypeID] [int] NOT NULL,
	[SessionID] [int] NOT NULL,
	[SellerID] [int] NOT NULL,
	[SeatNumber] [smallint] NULL,
	[Price] [tinyint] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Title]    Script Date: 15.08.2016 22:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Title](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Title] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Employees]    Script Date: 15.08.2016 22:15:38 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Employees] ON [dbo].[Employee]
(
	[NationalityNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Gender] FOREIGN KEY([GenderID])
REFERENCES [dbo].[Gender] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Gender]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Title] FOREIGN KEY([TitleID])
REFERENCES [dbo].[Title] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Title]
GO
ALTER TABLE [dbo].[Movie_MovieGenre]  WITH CHECK ADD  CONSTRAINT [FK_Movie_MovieGenre_TO_Movie] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movie] ([ID])
GO
ALTER TABLE [dbo].[Movie_MovieGenre] CHECK CONSTRAINT [FK_Movie_MovieGenre_TO_Movie]
GO
ALTER TABLE [dbo].[Movie_MovieGenre]  WITH CHECK ADD  CONSTRAINT [FK_Movie_MovieGenre_TO_MovieGenre] FOREIGN KEY([MovieGenreID])
REFERENCES [dbo].[MovieGenre] ([ID])
GO
ALTER TABLE [dbo].[Movie_MovieGenre] CHECK CONSTRAINT [FK_Movie_MovieGenre_TO_MovieGenre]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Movie] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movie] ([ID])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Movie]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_MovieTheater] FOREIGN KEY([MovieTheatreID])
REFERENCES [dbo].[MovieTheater] ([ID])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_MovieTheater]
GO
ALTER TABLE [dbo].[Session_Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Session_Ticket_TO_Session] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Session] ([ID])
GO
ALTER TABLE [dbo].[Session_Ticket] CHECK CONSTRAINT [FK_Session_Ticket_TO_Session]
GO
ALTER TABLE [dbo].[Session_Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Session_Ticket_TO_Ticket] FOREIGN KEY([TicketID])
REFERENCES [dbo].[Ticket] ([ID])
GO
ALTER TABLE [dbo].[Session_Ticket] CHECK CONSTRAINT [FK_Session_Ticket_TO_Ticket]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_AudienceType] FOREIGN KEY([AudienceTypeID])
REFERENCES [dbo].[AudienceType] ([ID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_AudienceType]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Employee] FOREIGN KEY([SellerID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Employee]
GO
USE [master]
GO
ALTER DATABASE [MasterCinema] SET  READ_WRITE 
GO
