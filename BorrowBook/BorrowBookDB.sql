USE [master]
GO
/****** Object:  Database [BorrowBookDB]    Script Date: 11/11/2014 2:26:54 PM ******/
CREATE DATABASE [BorrowBookDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BorrowBookDB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BorrowBookDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BorrowBookDB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BorrowBookDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BorrowBookDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BorrowBookDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BorrowBookDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BorrowBookDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BorrowBookDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BorrowBookDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BorrowBookDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BorrowBookDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BorrowBookDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BorrowBookDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BorrowBookDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BorrowBookDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BorrowBookDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BorrowBookDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BorrowBookDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BorrowBookDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BorrowBookDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BorrowBookDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BorrowBookDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BorrowBookDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BorrowBookDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BorrowBookDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BorrowBookDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BorrowBookDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BorrowBookDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BorrowBookDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BorrowBookDB] SET  MULTI_USER 
GO
ALTER DATABASE [BorrowBookDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BorrowBookDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BorrowBookDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BorrowBookDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [BorrowBookDB]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 11/11/2014 2:26:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[Publisher] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Borrow]    Script Date: 11/11/2014 2:26:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borrow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[Borrow] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Borrow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Member]    Script Date: 11/11/2014 2:26:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[View_1]    Script Date: 11/11/2014 2:26:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_1]
AS
SELECT        dbo.Member.Number, dbo.Book.Title, dbo.Borrow.Borrow
FROM            dbo.Book INNER JOIN
                         dbo.Borrow ON dbo.Book.Id = dbo.Borrow.BookId INNER JOIN
                         dbo.Member ON dbo.Borrow.MemberId = dbo.Member.Id

GO
ALTER TABLE [dbo].[Borrow]  WITH CHECK ADD  CONSTRAINT [FK_Borrow_Book1] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
GO
ALTER TABLE [dbo].[Borrow] CHECK CONSTRAINT [FK_Borrow_Book1]
GO
ALTER TABLE [dbo].[Borrow]  WITH CHECK ADD  CONSTRAINT [FK_Borrow_Member1] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([Id])
GO
ALTER TABLE [dbo].[Borrow] CHECK CONSTRAINT [FK_Borrow_Member1]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Book"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Borrow"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 148
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Member"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 102
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
USE [master]
GO
ALTER DATABASE [BorrowBookDB] SET  READ_WRITE 
GO
