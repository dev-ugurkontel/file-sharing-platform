USE [master]
GO
/****** Object:  Database [ProjectServer]    Script Date: 16.04.2021 14:54:06 ******/
CREATE DATABASE [ProjectServer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectServer', FILENAME = N'C:\Users\ugurk\ProjectServer.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectServer_log', FILENAME = N'C:\Users\ugurk\ProjectServer_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProjectServer] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectServer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectServer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectServer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectServer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectServer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectServer] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectServer] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ProjectServer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectServer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectServer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectServer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectServer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectServer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectServer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectServer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectServer] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProjectServer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectServer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectServer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectServer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectServer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectServer] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ProjectServer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectServer] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectServer] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectServer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectServer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectServer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectServer] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectServer] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectServer] SET QUERY_STORE = OFF
GO
USE [ProjectServer]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ProjectServer]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 16.04.2021 14:54:06 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileUser]    Script Date: 16.04.2021 14:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[FileId] [int] NOT NULL,
	[IsOwner] [bit] NOT NULL,
 CONSTRAINT [PK_FileUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefreshTokens]    Script Date: 16.04.2021 14:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshTokens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[Token] [nvarchar](max) NULL,
	[JwtId] [nvarchar](max) NULL,
	[IsUsed] [bit] NOT NULL,
	[IsRevorked] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ExpiryDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RefreshTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 16.04.2021 14:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 16.04.2021 14:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SharedFiles]    Script Date: 16.04.2021 14:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SharedFiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecordNo] [varchar](30) NOT NULL,
	[FileName] [varchar](150) NOT NULL,
	[FilePath] [varchar](150) NOT NULL,
	[FileExt] [varchar](50) NOT NULL,
	[FileMime] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL,
	[ShareState] [tinyint] NOT NULL,
	[SharingDate] [datetime] NOT NULL,
 CONSTRAINT [PK_SharedFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16.04.2021 14:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_FileUser_FileId]    Script Date: 16.04.2021 14:54:06 ******/
CREATE NONCLUSTERED INDEX [IX_FileUser_FileId] ON [dbo].[FileUser]
(
	[FileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FileUser_UserId]    Script Date: 16.04.2021 14:54:06 ******/
CREATE NONCLUSTERED INDEX [IX_FileUser_UserId] ON [dbo].[FileUser]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RefreshTokens_UserId]    Script Date: 16.04.2021 14:54:06 ******/
CREATE NONCLUSTERED INDEX [IX_RefreshTokens_UserId] ON [dbo].[RefreshTokens]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FileUser]  WITH CHECK ADD  CONSTRAINT [FK_FileUser_SharedFiles_FileId] FOREIGN KEY([FileId])
REFERENCES [dbo].[SharedFiles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FileUser] CHECK CONSTRAINT [FK_FileUser_SharedFiles_FileId]
GO
ALTER TABLE [dbo].[FileUser]  WITH CHECK ADD  CONSTRAINT [FK_FileUser_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FileUser] CHECK CONSTRAINT [FK_FileUser_Users_UserId]
GO
ALTER TABLE [dbo].[RefreshTokens]  WITH CHECK ADD  CONSTRAINT [FK_RefreshTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[RefreshTokens] CHECK CONSTRAINT [FK_RefreshTokens_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [ProjectServer] SET  READ_WRITE 
GO
