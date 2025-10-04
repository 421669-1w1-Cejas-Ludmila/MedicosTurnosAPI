USE [master]
GO
/****** Object:  Database [db_turnos]    Script Date: 10/1/2025 8:22:45 AM ******/
CREATE DATABASE [db_turnos]
GO
ALTER DATABASE [db_turnos] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_turnos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_turnos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_turnos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_turnos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_turnos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_turnos] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_turnos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_turnos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_turnos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_turnos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_turnos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_turnos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_turnos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_turnos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_turnos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_turnos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_turnos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_turnos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_turnos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_turnos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_turnos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_turnos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_turnos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_turnos] SET RECOVERY FULL 
GO
ALTER DATABASE [db_turnos] SET  MULTI_USER 
GO
ALTER DATABASE [db_turnos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_turnos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_turnos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_turnos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_turnos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_turnos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_turnos', N'ON'
GO
ALTER DATABASE [db_turnos] SET QUERY_STORE = ON
GO
ALTER DATABASE [db_turnos] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [db_turnos]
GO
/****** Object:  Table [dbo].[T_DETALLES_TURNO]    Script Date: 10/1/2025 8:22:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_DETALLES_TURNO](
	[id_turno] [int] NOT NULL,
	[matricula] [int] NOT NULL,
	[motivo_consulta] [varchar](200) NULL,
	[fecha] [varchar](10) NOT NULL,
	[hora] [varchar](10) NOT NULL,
 CONSTRAINT [PK_T_DETALLES_TURNO] PRIMARY KEY CLUSTERED 
(
	[id_turno] ASC,
	[matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_MEDICOS]    Script Date: 10/1/2025 8:22:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_MEDICOS](
	[matricula] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[especialidad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_MEDICOS] PRIMARY KEY CLUSTERED 
(
	[matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TURNOS]    Script Date: 10/1/2025 8:22:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TURNOS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[paciente] [varchar](100) NOT NULL,
	[estado] [varchar](20) NOT NULL,
 CONSTRAINT [PK_T_TURNOS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_DETALLES_TURNO] ([id_turno], [matricula], [motivo_consulta], [fecha], [hora]) VALUES (3, 1001, N'Chequeo cardiológico', N'2025-10-05', N'09:30')
GO
INSERT [dbo].[T_DETALLES_TURNO] ([id_turno], [matricula], [motivo_consulta], [fecha], [hora]) VALUES (4, 1002, N'Control pediátrico', N'2025-10-05', N'10:15')
GO
INSERT [dbo].[T_DETALLES_TURNO] ([id_turno], [matricula], [motivo_consulta], [fecha], [hora]) VALUES (5, 1003, N'Consulta dermatológica', N'2025-10-06', N'11:00')
GO
INSERT [dbo].[T_DETALLES_TURNO] ([id_turno], [matricula], [motivo_consulta], [fecha], [hora]) VALUES (6, 1004, N'Dolor en pierna', N'2025-10-06', N'14:00')
GO
INSERT [dbo].[T_DETALLES_TURNO] ([id_turno], [matricula], [motivo_consulta], [fecha], [hora]) VALUES (7, 1005, N'Problemas de visión', N'2025-10-07', N'08:45')
GO
INSERT [dbo].[T_DETALLES_TURNO] ([id_turno], [matricula], [motivo_consulta], [fecha], [hora]) VALUES (8, 1001, N'Chequeo post operatorio', N'2025-10-07', N'15:30')
GO
INSERT [dbo].[T_DETALLES_TURNO] ([id_turno], [matricula], [motivo_consulta], [fecha], [hora]) VALUES (9, 1002, N'Revisión pediátrica', N'2025-10-08', N'09:00')
GO
INSERT [dbo].[T_MEDICOS] ([matricula], [nombre], [apellido], [especialidad]) VALUES (1001, N'Ana', N'García', N'Cardiología')
GO
INSERT [dbo].[T_MEDICOS] ([matricula], [nombre], [apellido], [especialidad]) VALUES (1002, N'Luis', N'Martínez', N'Pediatría')
GO
INSERT [dbo].[T_MEDICOS] ([matricula], [nombre], [apellido], [especialidad]) VALUES (1003, N'Carolina', N'Fernández', N'Dermatología')
GO
INSERT [dbo].[T_MEDICOS] ([matricula], [nombre], [apellido], [especialidad]) VALUES (1004, N'Jorge', N'Sánchez', N'Traumatología')
GO
INSERT [dbo].[T_MEDICOS] ([matricula], [nombre], [apellido], [especialidad]) VALUES (1005, N'María', N'López', N'Oftalmología')
GO
SET IDENTITY_INSERT [dbo].[T_TURNOS] ON 
GO
INSERT [dbo].[T_TURNOS] ([id], [paciente], [estado]) VALUES (3, N'Juan Pérez', N'Pendiente')
GO
INSERT [dbo].[T_TURNOS] ([id], [paciente], [estado]) VALUES (4, N'Laura Gómez', N'Confirmado')
GO
INSERT [dbo].[T_TURNOS] ([id], [paciente], [estado]) VALUES (5, N'Carlos Rodríguez', N'Cancelado')
GO
INSERT [dbo].[T_TURNOS] ([id], [paciente], [estado]) VALUES (6, N'Marta Díaz', N'En Curso')
GO
INSERT [dbo].[T_TURNOS] ([id], [paciente], [estado]) VALUES (7, N'Sofía Torres', N'Pendiente')
GO
INSERT [dbo].[T_TURNOS] ([id], [paciente], [estado]) VALUES (8, N'Diego Fernández', N'Confirmado')
GO
INSERT [dbo].[T_TURNOS] ([id], [paciente], [estado]) VALUES (9, N'Paula Ramírez', N'En Curso')
GO
INSERT [dbo].[T_TURNOS] ([id], [paciente], [estado]) VALUES (10, N'Fernando Morales', N'Pendiente')
GO
SET IDENTITY_INSERT [dbo].[T_TURNOS] OFF
GO
ALTER TABLE [dbo].[T_DETALLES_TURNO]  WITH CHECK ADD  CONSTRAINT [FK_T_DETALLES_TURNO_T_MEDICOS] FOREIGN KEY([matricula])
REFERENCES [dbo].[T_MEDICOS] ([matricula])
GO
ALTER TABLE [dbo].[T_DETALLES_TURNO] CHECK CONSTRAINT [FK_T_DETALLES_TURNO_T_MEDICOS]
GO
ALTER TABLE [dbo].[T_DETALLES_TURNO]  WITH CHECK ADD  CONSTRAINT [FK_T_DETALLES_TURNO_T_TURNOS] FOREIGN KEY([id_turno])
REFERENCES [dbo].[T_TURNOS] ([id])
GO
ALTER TABLE [dbo].[T_DETALLES_TURNO] CHECK CONSTRAINT [FK_T_DETALLES_TURNO_T_TURNOS]
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_MAESTRO]    Script Date: 10/1/2025 8:22:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_MAESTRO] 
	@paciente varchar(100), 
	@id int output
AS
BEGIN
	INSERT INTO T_TURNOS (paciente) VALUES(@paciente);
	SET @id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_MEDICOS]    Script Date: 10/1/2025 8:22:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_MEDICOS]
AS
BEGIN
	
	SELECT * from T_MEDICOS ORDER BY 4;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONTAR_TURNOS]    Script Date: 10/1/2025 8:22:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONTAR_TURNOS]
    @fecha VARCHAR(10),
    @hora VARCHAR(8),
    @matricula int, 
    @ctd_turnos INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT @ctd_turnos = COUNT(*)
    FROM T_DETALLES_TURNO t
    WHERE t.fecha = @fecha AND t.hora = @hora AND t.matricula = @matricula;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLES]    Script Date: 10/1/2025 8:22:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLES] 
	@id_turno int,
	@matricula int, 
	@motivo varchar(200),
	@fecha varchar(10),
	@hora varchar(10)
AS
BEGIN
	INSERT INTO T_DETALLES_TURNO(id_turno,matricula, motivo_consulta, fecha, hora)
    VALUES (@id_turno,@matricula, @motivo, @fecha, @hora);
  
END
GO
USE [master]
GO
ALTER DATABASE [db_turnos] SET  READ_WRITE 
GO
