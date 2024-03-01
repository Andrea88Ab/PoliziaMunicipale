USE [master]
GO
/****** Object:  Database [PoliziaMunicipale]    Script Date: 01/03/2024 16:49:25 ******/
CREATE DATABASE [PoliziaMunicipale]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PoliziaMunicipale', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PoliziaMunicipale.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PoliziaMunicipale_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PoliziaMunicipale_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PoliziaMunicipale] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PoliziaMunicipale].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PoliziaMunicipale] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET ARITHABORT OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PoliziaMunicipale] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PoliziaMunicipale] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PoliziaMunicipale] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PoliziaMunicipale] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PoliziaMunicipale] SET  MULTI_USER 
GO
ALTER DATABASE [PoliziaMunicipale] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PoliziaMunicipale] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PoliziaMunicipale] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PoliziaMunicipale] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PoliziaMunicipale] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PoliziaMunicipale] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PoliziaMunicipale] SET QUERY_STORE = ON
GO
ALTER DATABASE [PoliziaMunicipale] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PoliziaMunicipale]
GO
/****** Object:  Table [dbo].[ANAGRAFICA]    Script Date: 01/03/2024 16:49:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ANAGRAFICA](
	[idAnagrafica] [int] IDENTITY(1,1) NOT NULL,
	[cognome] [nvarchar](max) NOT NULL,
	[nome] [nvarchar](max) NOT NULL,
	[indirizzo] [nvarchar](max) NOT NULL,
	[citta] [nvarchar](max) NOT NULL,
	[CAP] [int] NOT NULL,
	[CF] [char](16) NOT NULL,
 CONSTRAINT [PK__ANAGRAFI__FFDE8391EA08E602] PRIMARY KEY CLUSTERED 
(
	[idAnagrafica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__ANAGRAFI__32149A798140005E] UNIQUE NONCLUSTERED 
(
	[CF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPOVIOLAZIONE]    Script Date: 01/03/2024 16:49:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPOVIOLAZIONE](
	[idViolazione] [int] IDENTITY(1,1) NOT NULL,
	[descrizione] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK__TIPOVIOL__75080923D5EF654A] PRIMARY KEY CLUSTERED 
(
	[idViolazione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VERBALE]    Script Date: 01/03/2024 16:49:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VERBALE](
	[idVerbale] [int] IDENTITY(1,1) NOT NULL,
	[dataViolazione] [date] NOT NULL,
	[indirizzoViolazione] [nvarchar](max) NOT NULL,
	[nominativoAgente] [nvarchar](max) NOT NULL,
	[dataTrascrizioneVerbale] [datetime] NOT NULL,
	[importo] [money] NOT NULL,
	[decurtamentoPunti] [int] NOT NULL,
	[idAnagrafica] [int] NOT NULL,
	[idViolazione] [int] NOT NULL,
 CONSTRAINT [PK__VERBALE__A0FAF453E6678721] PRIMARY KEY CLUSTERED 
(
	[idVerbale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[VERBALE]  WITH CHECK ADD  CONSTRAINT [FK_Anagrafica_Verbale] FOREIGN KEY([idAnagrafica])
REFERENCES [dbo].[ANAGRAFICA] ([idAnagrafica])
GO
ALTER TABLE [dbo].[VERBALE] CHECK CONSTRAINT [FK_Anagrafica_Verbale]
GO
ALTER TABLE [dbo].[VERBALE]  WITH CHECK ADD  CONSTRAINT [FK_TipoViolazione_Verbale] FOREIGN KEY([idViolazione])
REFERENCES [dbo].[TIPOVIOLAZIONE] ([idViolazione])
GO
ALTER TABLE [dbo].[VERBALE] CHECK CONSTRAINT [FK_TipoViolazione_Verbale]
GO
/****** Object:  StoredProcedure [dbo].[DettagliPerData]    Script Date: 01/03/2024 16:49:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DettagliPerData] @Data date

AS
BEGIN
	SELECT dataViolazione, Importo, decurtamentoPunti FROM VERBALE
	WHERE dataViolazione = @Data
END
GO
/****** Object:  StoredProcedure [dbo].[EliminaVerbale]    Script Date: 01/03/2024 16:49:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminaVerbale] @id int

AS
BEGIN

	DELETE FROM VERBALE
	WHERE idVerbale = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ListaVerbaliPerAnno]    Script Date: 01/03/2024 16:49:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListaVerbaliPerAnno] @Anno int

AS
BEGIN
	SELECT cognome, nome, indirizzo, dataViolazione, importo, decurtamentoPunti FROM VERBALE
	INNER JOIN ANAGRAFICA
	ON ANAGRAFICA.idAnagrafica = VERBALE.idAnagrafica
	WHERE YEAR(dataViolazione) = @Anno
END
GO
/****** Object:  StoredProcedure [dbo].[PuntiDecurtatiPerAnno]    Script Date: 01/03/2024 16:49:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PuntiDecurtatiPerAnno] @Anno int

AS
BEGIN
	SELECT year(dataViolazione) as Year, SUM(decurtamentoPunti) as TotPuntiPersi FROM VERBALE
	GROUP BY year(dataViolazione)
	HAVING YEAR(dataViolazione) = @Anno
END
GO
/****** Object:  StoredProcedure [dbo].[PuntiDecurtatiPerData]    Script Date: 01/03/2024 16:49:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PuntiDecurtatiPerData] @Data date
	
AS
BEGIN
	SELECT dataViolazione, SUM(decurtamentoPunti) as TotPuntiPersi FROM VERBALE
	GROUP BY dataViolazione
	HAVING dataViolazione = @Data
END
GO
USE [master]
GO
ALTER DATABASE [PoliziaMunicipale] SET  READ_WRITE 
GO
