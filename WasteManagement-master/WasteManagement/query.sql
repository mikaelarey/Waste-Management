USE [master]
GO
/****** Object:  Database [dbTrasura]    Script Date: 17/08/2021 7:43:27 pm ******/
CREATE DATABASE [dbTrasura]
GO
USE [dbTrasura]
GO
/****** Object:  StoredProcedure [dbo].[CreateDummyBin]    Script Date: 17/08/2021 7:43:27 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROCEDURE [dbo].[CreateDummyBin]
@No INT = 10
AS
BEGIN
TRUNCATE TABLE [tbl_Bin]
  DECLARE @i INT = 0

  WHILE @i < @No
  BEGIN
	INSERT INTO tbl_Bin ([BinID]
      ,[MaxCapacity]
      ,[CurrentCapacity]
      ,[Location]
      ,[CollectorPhone]
      ,[DeploymentDate]) VALUES (CONCAT('STB', FORMAT(@i, '000')), 1, rand(), CONCAT('Bagiuo City ', @i), '09194291969', 'August 8, 2021')
	SET @i += 1
  END

  SELECT TOP 1000 [ID]
      ,[BinID]
      ,[MaxCapacity]
      ,[CurrentCapacity]
      ,[Location]
      ,[CollectorPhone]
      ,[DeploymentDate]
  FROM [dbTrasura].[dbo].[tbl_Bin]
END
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 17/08/2021 7:43:27 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Login]
@Username VARCHAR(255),
@Password VARCHAR(255)
AS
BEGIN
	DECLARE @isExist INT = (SELECT COUNT(*) FROM tbl_user WHERE Username = @Username AND Password = @Password)
	IF @isExist >= 1
	BEGIN
	SELECT *, CONVERT(BIT, 1) isValid FROM tbl_user WHERE Username = @Username AND Password = @Password
		
	END
	ELSE
	BEGIN
		SELECT CONVERT(BIT, 0) isValid
	END
END

GO
/****** Object:  StoredProcedure [dbo].[Register]    Script Date: 17/08/2021 7:43:27 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Register]
@Username VARCHAR(255),
@Password VARCHAR(255),
@Email VARCHAR(255),
@Fname VARCHAR(255),
@Mn VARCHAR(255),
@Lname VARCHAR(255),
@Gender VARCHAR(255),
@Bday DATETIME
AS
BEGIN
	DECLARE @isExist INT = (SELECT COUNT(*) FROM tbl_user WHERE Username = @Username)
	IF @isExist >= 1
	BEGIN
		SELECT CONVERT(BIT, 0) isValid
	END
	ELSE
	BEGIN
		INSERT INTO tbl_user (Username,Password,Email,Fname,mn,Lname,Gender,Bday)
		VALUES
		(@Username,@Password,@Email,@Fname,@mn,@Lname,@Gender,@Bday)
		SELECT CONVERT(BIT, 1) isValid
	END
END

GO
/****** Object:  Table [dbo].[tbl_Bin]    Script Date: 17/08/2021 7:43:27 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Bin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BinID] [varchar](50) NULL,
	[MaxCapacity] [decimal](18, 2) NULL,
	[CurrentCapacity] [decimal](18, 2) NULL,
	[Location] [varchar](255) NULL,
	[CollectorPhone] [varchar](50) NULL,
	[DeploymentDate] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Remarks]    Script Date: 17/08/2021 7:43:27 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Remarks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Remarks] [varchar](max) NULL,
	[encBy] [int] NULL,
	[encDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Schedule]    Script Date: 17/08/2021 7:43:27 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Schedule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Schedule] [datetime] NULL,
	[Day] [varchar](50) NULL,
	[Description] [varchar](max) NULL,
	[encBy] [int] NULL,
	[encDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 17/08/2021 7:43:27 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_user](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Fname] [varchar](255) NULL,
	[Mn] [varchar](255) NULL,
	[Lname] [varchar](255) NULL,
	[Gender] [varchar](255) NULL,
	[Bday] [datetime] NULL,
	[isAdmin] [bit] NULL,
	[encDate] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tbl_Bin] ADD  CONSTRAINT [DF__tbl_Bin__MaxCapa__22AA2996]  DEFAULT ((1)) FOR [MaxCapacity]
GO
ALTER TABLE [dbo].[tbl_Bin] ADD  CONSTRAINT [DF__tbl_Bin__Current__239E4DCF]  DEFAULT ((0)) FOR [CurrentCapacity]
GO
ALTER TABLE [dbo].[tbl_Remarks] ADD  DEFAULT (getdate()) FOR [encDate]
GO
ALTER TABLE [dbo].[tbl_Schedule] ADD  CONSTRAINT [DF__tbl_Sched__encDa__117F9D94]  DEFAULT (getdate()) FOR [encDate]
GO
ALTER TABLE [dbo].[tbl_user] ADD  CONSTRAINT [DF_tbl_user_isAdmin]  DEFAULT ((1)) FOR [isAdmin]
GO
ALTER TABLE [dbo].[tbl_user] ADD  CONSTRAINT [DF__tbl_user__encDat__0F975522]  DEFAULT (getdate()) FOR [encDate]
GO
USE [master]
GO
ALTER DATABASE [dbTrasura] SET  READ_WRITE 
GO
