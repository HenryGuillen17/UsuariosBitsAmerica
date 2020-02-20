-- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
-- SCRIPT PARA PRUEBA DE SOFTWARE
-- EL software está hecho con el paradigma de desarrollo "CODE FIRST",
-- por lo tanto tiene 2 opciones:
--   - Ejecutar este script
--   - Realizar migración ejecutando el comando "update database"
-- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

USE [UsuarioBitsAmericas]
GO
/****** Object:  Table [dbo].[Ciudades]    Script Date: 19/02/2020 23:33:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudades](
	[CiudadId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ciudades] PRIMARY KEY CLUSTERED 
(
	[CiudadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 19/02/2020 23:33:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[PrimerNombre] [nvarchar](50) NOT NULL,
	[SegundoNombre] [nvarchar](50) NULL,
	[PrimerApellido] [nvarchar](50) NOT NULL,
	[SegundoApellido] [nvarchar](50) NULL,
	[TipoDocumento] [tinyint] NOT NULL,
	[NumeroDocumento] [nvarchar](20) NOT NULL,
	[CorreoElectronico] [nvarchar](50) NOT NULL,
	[DireccionResidencia] [nvarchar](200) NOT NULL,
	[CiudadId] [int] NOT NULL,
	[Telefono] [nvarchar](25) NULL,
	[Celular] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Ciudades_CiudadId] FOREIGN KEY([CiudadId])
REFERENCES [dbo].[Ciudades] ([CiudadId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Ciudades_CiudadId]
GO
