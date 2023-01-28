USE [master]
GO
/****** Object:  Database [ChessDB]    Script Date: 28.01.2023 16:28:19 ******/
CREATE DATABASE [ChessDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChessDB', FILENAME = N'C:\Users\Bartek\ChessDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChessDB_log', FILENAME = N'C:\Users\Bartek\ChessDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ChessDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChessDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChessDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChessDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChessDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChessDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChessDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChessDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ChessDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChessDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChessDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChessDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChessDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChessDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChessDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChessDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChessDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ChessDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChessDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChessDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChessDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChessDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChessDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ChessDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChessDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ChessDB] SET  MULTI_USER 
GO
ALTER DATABASE [ChessDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChessDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChessDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChessDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ChessDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ChessDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ChessDB] SET QUERY_STORE = OFF
GO
USE [ChessDB]
GO
/****** Object:  Schema [Accounts]    Script Date: 28.01.2023 16:28:19 ******/
CREATE SCHEMA [Accounts]
GO
/****** Object:  Schema [chess]    Script Date: 28.01.2023 16:28:19 ******/
CREATE SCHEMA [chess]
GO
/****** Object:  Table [Accounts].[AspNetRoleClaims]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accounts].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Accounts].[AspNetRoles]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accounts].[AspNetRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Accounts].[AspNetUserClaims]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accounts].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Accounts].[AspNetUserLogins]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accounts].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Accounts].[AspNetUserRoles]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accounts].[AspNetUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Accounts].[AspNetUserTokens]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accounts].[AspNetUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Accounts].[Users]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accounts].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[NormalizedUserName] [varchar](30) NOT NULL,
	[Email] [varchar](60) NOT NULL,
	[NormalizedEmail] [varchar](60) NOT NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [varchar](128) NOT NULL,
	[SecurityStamp] [varchar](128) NULL,
	[ConcurrencyStamp] [varchar](128) NULL,
	[PhoneNumber] [varchar](19) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chess].[Captures]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chess].[Captures](
	[Id] [uniqueidentifier] NOT NULL,
	[CaptureSquareName] [varchar](20) NOT NULL,
	[MoveId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Captures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chess].[Castles]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chess].[Castles](
	[Id] [uniqueidentifier] NOT NULL,
	[DepartureSquareName] [varchar](20) NOT NULL,
	[ArrivalSquareName] [varchar](20) NOT NULL,
	[MoveId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Castles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chess].[GameEndings]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chess].[GameEndings](
	[Id] [uniqueidentifier] NOT NULL,
	[StrongName] [varchar](3) NOT NULL,
	[Details] [varchar](30) NOT NULL,
	[DateTimeCreate] [datetime] NOT NULL,
	[WinnerId] [uniqueidentifier] NULL,
	[LoserId] [uniqueidentifier] NULL,
	[GameId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_GameEndings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chess].[Games]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chess].[Games](
	[Id] [uniqueidentifier] NOT NULL,
	[DateTimeCreate] [datetime] NOT NULL,
	[GameSetupId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chess].[GameSetups]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chess].[GameSetups](
	[Id] [uniqueidentifier] NOT NULL,
	[InitialChessBoardState] [varchar](100) NOT NULL,
	[TimeLimit] [int] NULL,
	[TimeIncrement] [int] NOT NULL,
	[GameMode] [int] NOT NULL,
 CONSTRAINT [PK_GameSetups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chess].[GameStates]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chess].[GameStates](
	[Id] [uniqueidentifier] NOT NULL,
	[ChessBoardState] [varchar](100) NOT NULL,
	[CastlingRights] [varchar](4) NULL,
	[EnPassantSquareName] [char](2) NULL,
	[FiftyMoveRuleClock] [int] NOT NULL,
	[CapturedPieces] [varchar](100) NULL,
	[TurnId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_GameStates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chess].[Moves]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chess].[Moves](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[Description] [varchar](20) NOT NULL,
	[DepartureSquareName] [char](2) NOT NULL,
	[ArrivalSquareName] [char](2) NOT NULL,
	[TurnId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Moves] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chess].[Players]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chess].[Players](
	[Id] [uniqueidentifier] NOT NULL,
	[Color] [int] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[GameId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chess].[Promotions]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chess].[Promotions](
	[Id] [uniqueidentifier] NOT NULL,
	[Value] [int] NOT NULL,
	[MoveId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Promotions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chess].[QueueRequests]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chess].[QueueRequests](
	[Id] [uniqueidentifier] NOT NULL,
	[JoinDateTime] [datetime] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[QueueId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_QueueRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chess].[Queues]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chess].[Queues](
	[Id] [uniqueidentifier] NOT NULL,
	[GameSetupId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Queues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chess].[Turns]    Script Date: 28.01.2023 16:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chess].[Turns](
	[Id] [uniqueidentifier] NOT NULL,
	[TurnClock] [int] NOT NULL,
	[Color] [int] NOT NULL,
	[DateTimeFrom] [datetime] NOT NULL,
	[DateTimeTo] [datetime] NULL,
	[GameId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Turns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 28.01.2023 16:28:19 ******/
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
INSERT [Accounts].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1d1d45e0-df1f-4287-3573-08db013e6e5f', N'user', N'USER', N'user@gmail.com', N'USER@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEABlUu6puZWXiSsHpk1Unw+Fw+NuKGoV0j9bg5MVHPn0KGB7zeTdXDqh+bxab8aIwQ==', N'QOX437TM6S7ZCEJV7KPYNXZPT3KLIXSB', N'8bb7dafa-8d30-4cbc-8965-c84d2385569c', NULL, 0, 0, NULL, 1, 0)
INSERT [Accounts].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2ab2a374-4f5a-4c0d-3574-08db013e6e5f', N'user2', N'USER2', N'user2@gmail.com', N'USER2@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAECi5rJ/HYq6DeeADh+1mM+2OlhG3XZrM9i+mOTeahm3e1br/NgzjR2n5aZ434cjvNw==', N'MICSBWYPZVWKKUHLF7OK3U3NCCNUP2KD', N'ff72ea3d-be9c-4e4f-9995-d9a9b4d50bdb', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [chess].[GameSetups] ([Id], [InitialChessBoardState], [TimeLimit], [TimeIncrement], [GameMode]) VALUES (N'94d995f3-aaff-4cdf-adad-494942e03d2f', N'rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR', 15, 5, 2)
INSERT [chess].[GameSetups] ([Id], [InitialChessBoardState], [TimeLimit], [TimeIncrement], [GameMode]) VALUES (N'69c4faf2-6b15-440d-895c-7c2e0bdca8f8', N'rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR', 3, 3, 1)
INSERT [chess].[GameSetups] ([Id], [InitialChessBoardState], [TimeLimit], [TimeIncrement], [GameMode]) VALUES (N'c62ae06c-a67a-4e90-b92a-977a7e699c4a', N'rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR', 1, 2, 0)
INSERT [chess].[GameSetups] ([Id], [InitialChessBoardState], [TimeLimit], [TimeIncrement], [GameMode]) VALUES (N'226a15de-51b7-4413-8c59-b8abde3db5e3', N'rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR', 45, 0, 2)
GO
INSERT [chess].[Queues] ([Id], [GameSetupId]) VALUES (N'4db02e4b-7330-47cf-9107-eaec4d0a6d61', N'94d995f3-aaff-4cdf-adad-494942e03d2f')
INSERT [chess].[Queues] ([Id], [GameSetupId]) VALUES (N'3e875f18-cf43-4948-b12d-390ff430e6a2', N'69c4faf2-6b15-440d-895c-7c2e0bdca8f8')
INSERT [chess].[Queues] ([Id], [GameSetupId]) VALUES (N'49c99bc0-b0e3-4da6-9dc4-abcb2112b539', N'c62ae06c-a67a-4e90-b92a-977a7e699c4a')
INSERT [chess].[Queues] ([Id], [GameSetupId]) VALUES (N'518625c6-ea39-4819-947d-c1ac40da7e8d', N'226a15de-51b7-4413-8c59-b8abde3db5e3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230127202931_InitialCreate', N'7.0.2')
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [Accounts].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 28.01.2023 16:28:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [Accounts].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [Accounts].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [Accounts].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [Accounts].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [Accounts].[Users]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 28.01.2023 16:28:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [Accounts].[Users]
(
	[NormalizedUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Captures_MoveId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Captures_MoveId] ON [chess].[Captures]
(
	[MoveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Castles_MoveId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Castles_MoveId] ON [chess].[Castles]
(
	[MoveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GameEndings_GameId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_GameEndings_GameId] ON [chess].[GameEndings]
(
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GameEndings_LoserId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [IX_GameEndings_LoserId] ON [chess].[GameEndings]
(
	[LoserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GameEndings_WinnerId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [IX_GameEndings_WinnerId] ON [chess].[GameEndings]
(
	[WinnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Games_GameSetupId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [IX_Games_GameSetupId] ON [chess].[Games]
(
	[GameSetupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GameStates_TurnId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_GameStates_TurnId] ON [chess].[GameStates]
(
	[TurnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Moves_TurnId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Moves_TurnId] ON [chess].[Moves]
(
	[TurnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Players_GameId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [IX_Players_GameId] ON [chess].[Players]
(
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Players_UserId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [IX_Players_UserId] ON [chess].[Players]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Promotions_MoveId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Promotions_MoveId] ON [chess].[Promotions]
(
	[MoveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_QueueRequests_QueueId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [IX_QueueRequests_QueueId] ON [chess].[QueueRequests]
(
	[QueueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_QueueRequests_UserId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [IX_QueueRequests_UserId] ON [chess].[QueueRequests]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Queues_GameSetupId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [IX_Queues_GameSetupId] ON [chess].[Queues]
(
	[GameSetupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Turns_GameId]    Script Date: 28.01.2023 16:28:19 ******/
CREATE NONCLUSTERED INDEX [IX_Turns_GameId] ON [chess].[Turns]
(
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [Accounts].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [Accounts].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Accounts].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [Accounts].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [Accounts].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Accounts].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_Users_UserId]
GO
ALTER TABLE [Accounts].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [Accounts].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Accounts].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_Users_UserId]
GO
ALTER TABLE [Accounts].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [Accounts].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Accounts].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [Accounts].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [Accounts].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Accounts].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_Users_UserId]
GO
ALTER TABLE [Accounts].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [Accounts].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Accounts].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_Users_UserId]
GO
ALTER TABLE [chess].[Captures]  WITH CHECK ADD  CONSTRAINT [FK_Captures_Moves_MoveId] FOREIGN KEY([MoveId])
REFERENCES [chess].[Moves] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [chess].[Captures] CHECK CONSTRAINT [FK_Captures_Moves_MoveId]
GO
ALTER TABLE [chess].[Castles]  WITH CHECK ADD  CONSTRAINT [FK_Castles_Moves_MoveId] FOREIGN KEY([MoveId])
REFERENCES [chess].[Moves] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [chess].[Castles] CHECK CONSTRAINT [FK_Castles_Moves_MoveId]
GO
ALTER TABLE [chess].[GameEndings]  WITH CHECK ADD  CONSTRAINT [FK_GameEndings_Games_GameId] FOREIGN KEY([GameId])
REFERENCES [chess].[Games] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [chess].[GameEndings] CHECK CONSTRAINT [FK_GameEndings_Games_GameId]
GO
ALTER TABLE [chess].[GameEndings]  WITH CHECK ADD  CONSTRAINT [FK_GameEndings_Players_LoserId] FOREIGN KEY([LoserId])
REFERENCES [chess].[Players] ([Id])
GO
ALTER TABLE [chess].[GameEndings] CHECK CONSTRAINT [FK_GameEndings_Players_LoserId]
GO
ALTER TABLE [chess].[GameEndings]  WITH CHECK ADD  CONSTRAINT [FK_GameEndings_Players_WinnerId] FOREIGN KEY([WinnerId])
REFERENCES [chess].[Players] ([Id])
GO
ALTER TABLE [chess].[GameEndings] CHECK CONSTRAINT [FK_GameEndings_Players_WinnerId]
GO
ALTER TABLE [chess].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_GameSetups_GameSetupId] FOREIGN KEY([GameSetupId])
REFERENCES [chess].[GameSetups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [chess].[Games] CHECK CONSTRAINT [FK_Games_GameSetups_GameSetupId]
GO
ALTER TABLE [chess].[GameStates]  WITH CHECK ADD  CONSTRAINT [FK_GameStates_Turns_TurnId] FOREIGN KEY([TurnId])
REFERENCES [chess].[Turns] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [chess].[GameStates] CHECK CONSTRAINT [FK_GameStates_Turns_TurnId]
GO
ALTER TABLE [chess].[Moves]  WITH CHECK ADD  CONSTRAINT [FK_Moves_Turns_TurnId] FOREIGN KEY([TurnId])
REFERENCES [chess].[Turns] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [chess].[Moves] CHECK CONSTRAINT [FK_Moves_Turns_TurnId]
GO
ALTER TABLE [chess].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Games_GameId] FOREIGN KEY([GameId])
REFERENCES [chess].[Games] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [chess].[Players] CHECK CONSTRAINT [FK_Players_Games_GameId]
GO
ALTER TABLE [chess].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [Accounts].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [chess].[Players] CHECK CONSTRAINT [FK_Players_Users_UserId]
GO
ALTER TABLE [chess].[Promotions]  WITH CHECK ADD  CONSTRAINT [FK_Promotions_Moves_MoveId] FOREIGN KEY([MoveId])
REFERENCES [chess].[Moves] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [chess].[Promotions] CHECK CONSTRAINT [FK_Promotions_Moves_MoveId]
GO
ALTER TABLE [chess].[QueueRequests]  WITH CHECK ADD  CONSTRAINT [FK_QueueRequests_Queues_QueueId] FOREIGN KEY([QueueId])
REFERENCES [chess].[Queues] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [chess].[QueueRequests] CHECK CONSTRAINT [FK_QueueRequests_Queues_QueueId]
GO
ALTER TABLE [chess].[QueueRequests]  WITH CHECK ADD  CONSTRAINT [FK_QueueRequests_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [Accounts].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [chess].[QueueRequests] CHECK CONSTRAINT [FK_QueueRequests_Users_UserId]
GO
ALTER TABLE [chess].[Queues]  WITH CHECK ADD  CONSTRAINT [FK_Queues_GameSetups_GameSetupId] FOREIGN KEY([GameSetupId])
REFERENCES [chess].[GameSetups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [chess].[Queues] CHECK CONSTRAINT [FK_Queues_GameSetups_GameSetupId]
GO
ALTER TABLE [chess].[Turns]  WITH CHECK ADD  CONSTRAINT [FK_Turns_Games_GameId] FOREIGN KEY([GameId])
REFERENCES [chess].[Games] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [chess].[Turns] CHECK CONSTRAINT [FK_Turns_Games_GameId]
GO
USE [master]
GO
ALTER DATABASE [ChessDB] SET  READ_WRITE 
GO
