USE [master]
GO
/****** Object:  Database [tp2_net]    Script Date: 08/11/2021 20:56:58 ******/
CREATE DATABASE [tp2_net]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'tp2_net', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\tp2_net.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'tp2_net_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\tp2_net_log.ldf' , SIZE = 3840KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [tp2_net] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tp2_net].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tp2_net] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tp2_net] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tp2_net] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tp2_net] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tp2_net] SET ARITHABORT OFF 
GO
ALTER DATABASE [tp2_net] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [tp2_net] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tp2_net] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tp2_net] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tp2_net] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [tp2_net] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tp2_net] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tp2_net] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tp2_net] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tp2_net] SET  DISABLE_BROKER 
GO
ALTER DATABASE [tp2_net] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tp2_net] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [tp2_net] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [tp2_net] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [tp2_net] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tp2_net] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [tp2_net] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [tp2_net] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [tp2_net] SET  MULTI_USER 
GO
ALTER DATABASE [tp2_net] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [tp2_net] SET DB_CHAINING OFF 
GO
ALTER DATABASE [tp2_net] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [tp2_net] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [tp2_net] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [tp2_net] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'tp2_net', N'ON'
GO
ALTER DATABASE [tp2_net] SET QUERY_STORE = OFF
GO
USE [tp2_net]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 08/11/2021 20:56:58 ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [net]    Script Date: 08/11/2021 20:56:58 ******/
CREATE USER [net] FOR LOGIN [net] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_datareader] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_owner] ADD MEMBER [net]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [net]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [net]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [net]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [net]
GO
ALTER ROLE [db_datareader] ADD MEMBER [net]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [net]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [net]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [net]
GO
/****** Object:  Table [dbo].[alumnos_inscripciones]    Script Date: 08/11/2021 20:56:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alumnos_inscripciones](
	[id_inscripcion] [int] IDENTITY(1,1) NOT NULL,
	[id_alumno] [int] NOT NULL,
	[id_curso] [int] NOT NULL,
	[condicion] [varchar](50) NOT NULL,
	[nota] [int] NULL,
 CONSTRAINT [PK_alumnos_inscripciones] PRIMARY KEY CLUSTERED 
(
	[id_inscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comisiones]    Script Date: 08/11/2021 20:56:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comisiones](
	[id_comision] [int] IDENTITY(1,1) NOT NULL,
	[desc_comision] [varchar](50) NOT NULL,
	[anio_especialidad] [int] NOT NULL,
	[id_plan] [int] NOT NULL,
 CONSTRAINT [PK_comisiones] PRIMARY KEY CLUSTERED 
(
	[id_comision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cursos]    Script Date: 08/11/2021 20:56:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cursos](
	[id_curso] [int] IDENTITY(1,1) NOT NULL,
	[id_materia] [int] NOT NULL,
	[id_comision] [int] NOT NULL,
	[anio_calendario] [int] NOT NULL,
	[cupo] [int] NOT NULL,
 CONSTRAINT [PK_cursos] PRIMARY KEY CLUSTERED 
(
	[id_curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[docentes_cursos]    Script Date: 08/11/2021 20:56:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[docentes_cursos](
	[id_dictado] [int] IDENTITY(1,1) NOT NULL,
	[id_curso] [int] NOT NULL,
	[id_docente] [int] NOT NULL,
	[cargo] [int] NOT NULL,
 CONSTRAINT [PK_docentes_cursos] PRIMARY KEY CLUSTERED 
(
	[id_dictado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[especialidades]    Script Date: 08/11/2021 20:56:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[especialidades](
	[id_especialidad] [int] IDENTITY(1,1) NOT NULL,
	[desc_especialidad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_especialidades] PRIMARY KEY CLUSTERED 
(
	[id_especialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materias]    Script Date: 08/11/2021 20:56:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materias](
	[id_materia] [int] IDENTITY(1,1) NOT NULL,
	[desc_materia] [varchar](50) NOT NULL,
	[hs_semanales] [int] NOT NULL,
	[hs_totales] [int] NOT NULL,
	[id_plan] [int] NOT NULL,
 CONSTRAINT [PK_materias] PRIMARY KEY CLUSTERED 
(
	[id_materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[modulos]    Script Date: 08/11/2021 20:56:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[modulos](
	[id_modulo] [int] IDENTITY(1,1) NOT NULL,
	[desc_modulo] [varchar](50) NULL,
	[ejecuta] [varchar](50) NULL,
 CONSTRAINT [PK_modulos] PRIMARY KEY CLUSTERED 
(
	[id_modulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[modulos_usuarios]    Script Date: 08/11/2021 20:56:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[modulos_usuarios](
	[id_modulo_usuario] [int] IDENTITY(1,1) NOT NULL,
	[id_modulo] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[alta] [bit] NULL,
	[baja] [bit] NULL,
	[modificacion] [bit] NULL,
	[consulta] [bit] NULL,
 CONSTRAINT [PK_modulos_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_modulo_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personas]    Script Date: 08/11/2021 20:56:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personas](
	[id_persona] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[fecha_nac] [datetime] NOT NULL,
	[legajo] [int] NULL,
	[tipo_persona] [int] NOT NULL,
	[id_plan] [int] NOT NULL,
 CONSTRAINT [PK_personas] PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[planes]    Script Date: 08/11/2021 20:56:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[planes](
	[id_plan] [int] IDENTITY(1,1) NOT NULL,
	[desc_plan] [varchar](50) NOT NULL,
	[id_especialidad] [int] NOT NULL,
 CONSTRAINT [PK_planes] PRIMARY KEY CLUSTERED 
(
	[id_plan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 08/11/2021 20:56:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](50) NOT NULL,
	[clave] [varchar](50) NOT NULL,
	[habilitado] [bit] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[email] [varchar](50) NULL,
	[cambia_clave] [bit] NULL,
	[id_persona] [int] NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[alumnos_inscripciones]  WITH CHECK ADD  CONSTRAINT [FK_alumnos_inscripciones_cursos] FOREIGN KEY([id_curso])
REFERENCES [dbo].[cursos] ([id_curso])
GO
ALTER TABLE [dbo].[alumnos_inscripciones] CHECK CONSTRAINT [FK_alumnos_inscripciones_cursos]
GO
ALTER TABLE [dbo].[alumnos_inscripciones]  WITH CHECK ADD  CONSTRAINT [FK_alumnos_inscripciones_personas] FOREIGN KEY([id_alumno])
REFERENCES [dbo].[personas] ([id_persona])
GO
ALTER TABLE [dbo].[alumnos_inscripciones] CHECK CONSTRAINT [FK_alumnos_inscripciones_personas]
GO
ALTER TABLE [dbo].[comisiones]  WITH CHECK ADD  CONSTRAINT [FK_comisiones_planes] FOREIGN KEY([id_plan])
REFERENCES [dbo].[planes] ([id_plan])
GO
ALTER TABLE [dbo].[comisiones] CHECK CONSTRAINT [FK_comisiones_planes]
GO
ALTER TABLE [dbo].[cursos]  WITH CHECK ADD  CONSTRAINT [FK_cursos_comisiones] FOREIGN KEY([id_comision])
REFERENCES [dbo].[comisiones] ([id_comision])
GO
ALTER TABLE [dbo].[cursos] CHECK CONSTRAINT [FK_cursos_comisiones]
GO
ALTER TABLE [dbo].[cursos]  WITH CHECK ADD  CONSTRAINT [FK_cursos_materias] FOREIGN KEY([id_materia])
REFERENCES [dbo].[materias] ([id_materia])
GO
ALTER TABLE [dbo].[cursos] CHECK CONSTRAINT [FK_cursos_materias]
GO
ALTER TABLE [dbo].[docentes_cursos]  WITH CHECK ADD  CONSTRAINT [FK_docentes_cursos_cursos] FOREIGN KEY([id_curso])
REFERENCES [dbo].[cursos] ([id_curso])
GO
ALTER TABLE [dbo].[docentes_cursos] CHECK CONSTRAINT [FK_docentes_cursos_cursos]
GO
ALTER TABLE [dbo].[docentes_cursos]  WITH CHECK ADD  CONSTRAINT [FK_docentes_cursos_personas] FOREIGN KEY([id_docente])
REFERENCES [dbo].[personas] ([id_persona])
GO
ALTER TABLE [dbo].[docentes_cursos] CHECK CONSTRAINT [FK_docentes_cursos_personas]
GO
ALTER TABLE [dbo].[materias]  WITH CHECK ADD  CONSTRAINT [FK_materias_planes] FOREIGN KEY([id_plan])
REFERENCES [dbo].[planes] ([id_plan])
GO
ALTER TABLE [dbo].[materias] CHECK CONSTRAINT [FK_materias_planes]
GO
ALTER TABLE [dbo].[modulos_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_modulos_usuarios_modulos] FOREIGN KEY([id_modulo])
REFERENCES [dbo].[modulos] ([id_modulo])
GO
ALTER TABLE [dbo].[modulos_usuarios] CHECK CONSTRAINT [FK_modulos_usuarios_modulos]
GO
ALTER TABLE [dbo].[modulos_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_modulos_usuarios_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[modulos_usuarios] CHECK CONSTRAINT [FK_modulos_usuarios_usuarios]
GO
ALTER TABLE [dbo].[personas]  WITH CHECK ADD  CONSTRAINT [FK_personas_planes] FOREIGN KEY([id_plan])
REFERENCES [dbo].[planes] ([id_plan])
GO
ALTER TABLE [dbo].[personas] CHECK CONSTRAINT [FK_personas_planes]
GO
ALTER TABLE [dbo].[planes]  WITH CHECK ADD  CONSTRAINT [FK_planes_especialidades] FOREIGN KEY([id_especialidad])
REFERENCES [dbo].[especialidades] ([id_especialidad])
GO
ALTER TABLE [dbo].[planes] CHECK CONSTRAINT [FK_planes_especialidades]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_personas] FOREIGN KEY([id_persona])
REFERENCES [dbo].[personas] ([id_persona])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_personas]
GO
USE [master]
GO
ALTER DATABASE [tp2_net] SET  READ_WRITE 
GO
