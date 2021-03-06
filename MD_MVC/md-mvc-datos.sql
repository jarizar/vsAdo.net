USE [master]
GO
CREATE DATABASE [MD_MVC]
GO
ALTER DATABASE [MD_MVC] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MD_MVC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MD_MVC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MD_MVC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MD_MVC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MD_MVC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MD_MVC] SET ARITHABORT OFF 
GO
ALTER DATABASE [MD_MVC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MD_MVC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MD_MVC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MD_MVC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MD_MVC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MD_MVC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MD_MVC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MD_MVC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MD_MVC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MD_MVC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MD_MVC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MD_MVC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MD_MVC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MD_MVC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MD_MVC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MD_MVC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MD_MVC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MD_MVC] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MD_MVC] SET  MULTI_USER 
GO
ALTER DATABASE [MD_MVC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MD_MVC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MD_MVC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MD_MVC] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MD_MVC] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MD_MVC]
GO
/****** Object:  User [IIS APPPOOL\Master_Detail]    Script Date: 5/21/2018 11:43:53 PM ******/
CREATE USER [IIS APPPOOL\Master_Detail] FOR LOGIN [IIS APPPOOL\Master_Detail] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\Master_Detail]
GO
/****** Object:  Schema [Miselaneos]    Script Date: 5/21/2018 11:43:53 PM ******/
CREATE SCHEMA [Miselaneos]
GO
/****** Object:  Schema [Orden]    Script Date: 5/21/2018 11:43:53 PM ******/
CREATE SCHEMA [Orden]
GO
/****** Object:  Schema [Persona]    Script Date: 5/21/2018 11:43:53 PM ******/
CREATE SCHEMA [Persona]
GO
/****** Object:  Schema [Productos]    Script Date: 5/21/2018 11:43:53 PM ******/
CREATE SCHEMA [Productos]
GO
/****** Object:  Table [Miselaneos].[Estatus]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Miselaneos].[Estatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nchar](50) NULL,
	[Id_Estatus] [int] NULL,
 CONSTRAINT [PK_Estatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Orden].[Condiciones]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Orden].[Condiciones](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Condiciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Orden].[Orden]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Orden].[Orden](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Id_Persona] [int] NULL,
	[Id_Tipo] [int] NOT NULL,
	[Id_Condiciones] [tinyint] NOT NULL,
	[Subtotal] [numeric](18, 2) NOT NULL,
	[Descuento] [numeric](18, 2) NOT NULL,
	[Recargo] [numeric](18, 2) NOT NULL,
	[Impuestos] [numeric](18, 2) NOT NULL,
	[Total] [numeric](18, 2) NOT NULL,
	[Id_Estatus] [int] NULL,
	[SecuenciaEditable] [varchar](20) NULL,
	[IdEditable] [varchar](20) NULL,
	[Secuencia_Gobierno] [varchar](20) NULL,
	[Comentario] [varchar](max) NULL,
 CONSTRAINT [PK_Orden] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Orden].[Orden_Detalle]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Orden].[Orden_Detalle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Orden] [int] NOT NULL,
	[Id_Producto] [int] NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Cantidad] [numeric](18, 2) NOT NULL,
	[Precio] [numeric](18, 2) NOT NULL,
	[Impuesto] [numeric](18, 2) NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Orden_Detalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Orden].[Orden_Tipo]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Orden].[Orden_Tipo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Secuencia] [varchar](50) NULL,
 CONSTRAINT [PK_Orden_Tipo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Persona].[Persona]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Persona].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](50) NULL,
	[Apellidos] [nvarchar](50) NULL,
	[Nombre_Completo]  AS (([Nombres]+' ')+[Apellidos]),
	[Documento] [nchar](20) NULL,
	[Titulo] [nchar](10) NULL,
	[Contacto] [nvarchar](50) NULL,
	[Empresa] [nvarchar](200) NULL,
	[Correo] [nvarchar](200) NULL,
	[Comentarios] [varchar](max) NULL,
	[Direccion] [nvarchar](200) NULL,
	[Direccion_De_Envio] [nvarchar](200) NULL,
	[Fecha_Nacimiento] [date] NULL,
	[Fecha] [datetime] NULL,
	[Balance] [numeric](18, 2) NULL,
	[Limite_Credito] [numeric](18, 2) NULL,
	[Id_Tipo_Persona] [tinyint] NOT NULL,
	[Id_Persona] [int] NULL,
	[Id_Estatus] [int] NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Persona].[Persona_Tipo]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Persona].[Persona_Tipo](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[secuencia1] [nchar](20) NULL,
	[secuencia2] [nchar](20) NULL,
	[secuencia3] [nchar](20) NULL,
 CONSTRAINT [PK_Persona_Tipo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Productos].[Producto]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Productos].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Cantidad] [numeric](18, 2) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Precio] [numeric](18, 2) NOT NULL,
	[Costo] [numeric](18, 2) NOT NULL,
	[Id_Impuesto] [tinyint] NOT NULL,
	[Id_Tipo] [tinyint] NOT NULL,
	[Id_Estatus] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Productos].[Producto_Tipo]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Productos].[Producto_Tipo](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Secuencia1] [nchar](10) NULL,
	[Secuencia2] [nchar](10) NULL,
 CONSTRAINT [PK_Producto_Tipo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Productos].[Tasa_Impuesto]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Productos].[Tasa_Impuesto](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Leyenda] [nchar](10) NULL,
	[Tasa] [numeric](4, 2) NOT NULL,
 CONSTRAINT [PK_Tasa_Impuesto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [Orden].[v_Orden]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [Orden].[v_Orden] 
With SchemaBinding
As
SELECT Orden.Id as Orden_Id, Orden.Fecha,
	   Orden.Id_Persona,Persona.Nombre_Completo, Persona_Tipo.Descripcion as Persona_Tipo_descripcion, 
	   Id_Tipo,Tipo_de_orden.Descripcion as Tipo_de_orden_descripcion,
	   Id_Condiciones, Condiciones.Descripcion as Condiciones_Descripcion,
	   Subtotal,Descuento,Recargo,Impuestos,Total,
	   Orden.Id_Estatus, Estatus.Descripcion as Estatus_Descripcion,
	   SecuenciaEditable,IdEditable,Secuencia_Gobierno,
	   Orden.Comentario
  FROM Orden.Orden as Orden Join
	   Persona.Persona as Persona on Orden.Id_Persona = Persona.Id Join
	   Orden.Orden_Tipo as Tipo_de_orden on Tipo_de_orden.Id = Orden.Id_Tipo Join
	   Orden.Condiciones as Condiciones on Condiciones.Id = Orden.Id_Condiciones Join
	   Miselaneos.Estatus as Estatus on Estatus.Id = Orden.Id_Estatus Join
	   Persona.Persona_Tipo as Persona_Tipo on Persona_Tipo.Id = Persona.Id_Tipo_Persona

GO
/****** Object:  View [Orden].[v_Orden_Completa]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [Orden].[v_Orden_Completa] 
With SchemaBinding
As
SELECT Orden.Id as Orden_Id, Orden.Fecha,
	   Orden.Id_Persona,Persona.Nombre_Completo, Persona_Tipo.Descripcion as Persona_Tipo_descripcion, 
	   Id_Tipo,Tipo_de_orden.Descripcion as Tipo_de_orden_descripcion,
	   Id_Condiciones, Condiciones.Descripcion as Condiciones_Descripcion,
	   Subtotal,Descuento,Recargo,Impuestos,Total,
	   Orden.Id_Estatus, Estatus.Descripcion as Estatus_Descripcion,
	   SecuenciaEditable,IdEditable,Secuencia_Gobierno, Orden.Comentario,
	   Detalles.Id_Producto, Detalles.Descripcion as Detalles_Descripcion,
	   Detalles.Cantidad, Detalles.Precio, Detalles.Impuesto, Detalles.Monto	   
  FROM Orden.Orden as Orden Join
	   Persona.Persona as Persona on Orden.Id_Persona = Persona.Id Join
	   Orden.Orden_Tipo as Tipo_de_orden on Tipo_de_orden.Id = Orden.Id_Tipo Join
	   Orden.Condiciones as Condiciones on Condiciones.Id = Orden.Id_Condiciones Join
	   Miselaneos.Estatus as Estatus on Estatus.Id = Orden.Id_Estatus Join
	   Persona.Persona_Tipo as Persona_Tipo on Persona_Tipo.Id = Persona.Id_Tipo_Persona Join
	   Orden.Orden_Detalle as Detalles on Detalles.Id_Orden = Orden.Id

GO
/****** Object:  View [Persona].[v_Persona]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [Persona].[v_Persona]
With SchemaBinding
As
SELECT persona.Id,Nombres,Apellidos,Nombre_Completo,Documento
      ,Titulo,Contacto,Empresa,Correo,Comentarios
      ,Direccion,Direccion_De_Envio,Fecha_Nacimiento
      ,Cast(Fecha as Date) as Fecha,Balance,Limite_Credito,Id_Tipo_Persona, tipo.Descripcion as Tipo_Persona
      ,Id_Persona,persona.Id_Estatus, estatus.Descripcion as Estatus_Descripcion
  FROM Persona.Persona as persona Inner Join
  Persona.Persona_Tipo as tipo On tipo.Id = persona.Id_Tipo_Persona Inner Join
  Miselaneos.Estatus as estatus On estatus.Id = persona.Id_Estatus



GO
/****** Object:  View [Productos].[v_Producto]    Script Date: 5/21/2018 11:43:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [Productos].[v_Producto]
With SchemaBinding
AS
SELECT producto.Id,Codigo,Cantidad,producto.Descripcion,Precio,
	   Costo,Id_Impuesto, Impuestos.Descripcion as Descripcion_Impuesto, 
	   Impuestos.Leyenda, Impuestos.Tasa, Id_Tipo, 
	   tipo.Descripcion as Tipo_Descripcion,
	   producto.Id_Estatus, estatus.Descripcion as Estatus_Descripcion
FROM   Productos.Producto as producto Inner Join
	   Productos.Producto_Tipo as tipo on tipo.Id = producto.Id_Tipo Inner Join
	   Miselaneos.Estatus as estatus on estatus.Id = producto.Id_Estatus Inner Join
	   Productos.Tasa_Impuesto as Impuestos on Impuestos.Id = Producto.Id_Impuesto


GO
SET IDENTITY_INSERT [Miselaneos].[Estatus] ON 

GO
INSERT [Miselaneos].[Estatus] ([Id], [Descripcion], [Id_Estatus]) VALUES (1, N'Activado                                          ', 1)
GO
INSERT [Miselaneos].[Estatus] ([Id], [Descripcion], [Id_Estatus]) VALUES (2, N'Desactivado                                       ', 1)
GO
INSERT [Miselaneos].[Estatus] ([Id], [Descripcion], [Id_Estatus]) VALUES (3, N'En proceso                                        ', 1)
GO
INSERT [Miselaneos].[Estatus] ([Id], [Descripcion], [Id_Estatus]) VALUES (4, N'Procesado                                         ', 1)
GO
INSERT [Miselaneos].[Estatus] ([Id], [Descripcion], [Id_Estatus]) VALUES (5, N'Cancelado                                         ', 1)
GO
INSERT [Miselaneos].[Estatus] ([Id], [Descripcion], [Id_Estatus]) VALUES (6, N'Vigente                                           ', 1)
GO
INSERT [Miselaneos].[Estatus] ([Id], [Descripcion], [Id_Estatus]) VALUES (7, N'Suspendido                                        ', 1)
GO
SET IDENTITY_INSERT [Miselaneos].[Estatus] OFF
GO
SET IDENTITY_INSERT [Orden].[Condiciones] ON 

GO
INSERT [Orden].[Condiciones] ([Id], [Descripcion]) VALUES (1, N'Contado')
GO
INSERT [Orden].[Condiciones] ([Id], [Descripcion]) VALUES (2, N'Crédito')
GO
INSERT [Orden].[Condiciones] ([Id], [Descripcion]) VALUES (3, N'Consignación')
GO
SET IDENTITY_INSERT [Orden].[Condiciones] OFF
GO
SET IDENTITY_INSERT [Orden].[Orden] ON 

GO
INSERT [Orden].[Orden] ([Id], [Fecha], [Id_Persona], [Id_Tipo], [Id_Condiciones], [Subtotal], [Descuento], [Recargo], [Impuestos], [Total], [Id_Estatus], [SecuenciaEditable], [IdEditable], [Secuencia_Gobierno], [Comentario]) VALUES (1, CAST(N'2099-05-21' AS Date), 2, 2, 1, CAST(10.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(1.80 AS Numeric(18, 2)), CAST(11.80 AS Numeric(18, 2)), 6, N'', N'', N'', N'')
GO
INSERT [Orden].[Orden] ([Id], [Fecha], [Id_Persona], [Id_Tipo], [Id_Condiciones], [Subtotal], [Descuento], [Recargo], [Impuestos], [Total], [Id_Estatus], [SecuenciaEditable], [IdEditable], [Secuencia_Gobierno], [Comentario]) VALUES (2, CAST(N'2099-05-21' AS Date), 1, 1, 2, CAST(100.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(16.00 AS Numeric(18, 2)), CAST(116.00 AS Numeric(18, 2)), 1, N'', N'', N'', N'')
GO
INSERT [Orden].[Orden] ([Id], [Fecha], [Id_Persona], [Id_Tipo], [Id_Condiciones], [Subtotal], [Descuento], [Recargo], [Impuestos], [Total], [Id_Estatus], [SecuenciaEditable], [IdEditable], [Secuencia_Gobierno], [Comentario]) VALUES (3, CAST(N'2099-05-21' AS Date), 7, 8, 3, CAST(1000.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(1000.00 AS Numeric(18, 2)), 1, N'', N'', N'', N'Mercancia a Consignación')
GO
INSERT [Orden].[Orden] ([Id], [Fecha], [Id_Persona], [Id_Tipo], [Id_Condiciones], [Subtotal], [Descuento], [Recargo], [Impuestos], [Total], [Id_Estatus], [SecuenciaEditable], [IdEditable], [Secuencia_Gobierno], [Comentario]) VALUES (4, CAST(N'2099-05-21' AS Date), 13, 7, 1, CAST(300.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(240.00 AS Numeric(18, 2)), CAST(540.00 AS Numeric(18, 2)), 1, N'', N'', N'', N'')
GO
INSERT [Orden].[Orden] ([Id], [Fecha], [Id_Persona], [Id_Tipo], [Id_Condiciones], [Subtotal], [Descuento], [Recargo], [Impuestos], [Total], [Id_Estatus], [SecuenciaEditable], [IdEditable], [Secuencia_Gobierno], [Comentario]) VALUES (5, CAST(N'2018-05-21' AS Date), 20, 4, 1, CAST(1000.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(1000.00 AS Numeric(18, 2)), 1, N'', N'', N'', N'')
GO
SET IDENTITY_INSERT [Orden].[Orden] OFF
GO
SET IDENTITY_INSERT [Orden].[Orden_Detalle] ON 

GO
INSERT [Orden].[Orden_Detalle] ([Id], [Id_Orden], [Id_Producto], [Descripcion], [Cantidad], [Precio], [Impuesto], [Monto]) VALUES (1, 1, 1, N'Servicio de Mantenimiento de Sistemas', CAST(1.00 AS Numeric(18, 2)), CAST(10.00 AS Numeric(18, 2)), CAST(1.80 AS Numeric(18, 2)), CAST(11.80 AS Numeric(18, 2)))
GO
INSERT [Orden].[Orden_Detalle] ([Id], [Id_Orden], [Id_Producto], [Descripcion], [Cantidad], [Precio], [Impuesto], [Monto]) VALUES (2, 2, 1, N'Servicio de Mantenimiento de Sistemas', CAST(1.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), CAST(16.00 AS Numeric(18, 2)), CAST(116.00 AS Numeric(18, 2)))
GO
INSERT [Orden].[Orden_Detalle] ([Id], [Id_Orden], [Id_Producto], [Descripcion], [Cantidad], [Precio], [Impuesto], [Monto]) VALUES (3, 3, 10, N'Servicios varios', CAST(1.00 AS Numeric(18, 2)), CAST(1000.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(1000.00 AS Numeric(18, 2)))
GO
INSERT [Orden].[Orden_Detalle] ([Id], [Id_Orden], [Id_Producto], [Descripcion], [Cantidad], [Precio], [Impuesto], [Monto]) VALUES (4, 4, 3, N'Laptop DELL E6510', CAST(1.00 AS Numeric(18, 2)), CAST(300.00 AS Numeric(18, 2)), CAST(240.00 AS Numeric(18, 2)), CAST(540.00 AS Numeric(18, 2)))
GO
INSERT [Orden].[Orden_Detalle] ([Id], [Id_Orden], [Id_Producto], [Descripcion], [Cantidad], [Precio], [Impuesto], [Monto]) VALUES (5, 5, 10, N'Servicios varios', CAST(1.00 AS Numeric(18, 2)), CAST(1000.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(1000.00 AS Numeric(18, 2)))
GO
SET IDENTITY_INSERT [Orden].[Orden_Detalle] OFF
GO
SET IDENTITY_INSERT [Orden].[Orden_Tipo] ON 

GO
INSERT [Orden].[Orden_Tipo] ([Id], [Descripcion], [Secuencia]) VALUES (1, N'Facturas de Venta', N'001')
GO
INSERT [Orden].[Orden_Tipo] ([Id], [Descripcion], [Secuencia]) VALUES (2, N'Facturas De Compra', N'001')
GO
INSERT [Orden].[Orden_Tipo] ([Id], [Descripcion], [Secuencia]) VALUES (3, N'Nota de Crédito a Venta', N'001')
GO
INSERT [Orden].[Orden_Tipo] ([Id], [Descripcion], [Secuencia]) VALUES (4, N'Nota de Crédito a Compra', N'001')
GO
INSERT [Orden].[Orden_Tipo] ([Id], [Descripcion], [Secuencia]) VALUES (5, N'Orden de Compra', N'001')
GO
INSERT [Orden].[Orden_Tipo] ([Id], [Descripcion], [Secuencia]) VALUES (6, N'Orden de Venta', N'001')
GO
INSERT [Orden].[Orden_Tipo] ([Id], [Descripcion], [Secuencia]) VALUES (7, N'Cotización', N'001')
GO
INSERT [Orden].[Orden_Tipo] ([Id], [Descripcion], [Secuencia]) VALUES (8, N'Conduce', N'001')
GO
SET IDENTITY_INSERT [Orden].[Orden_Tipo] OFF
GO
SET IDENTITY_INSERT [Persona].[Persona] ON 

GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (1, N'ALMA LLANERA SRL', N'', N'101557551           ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 3, NULL, 6)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (2, N'BRUGAL & CO., C. POR. A.', N'', N'0000063             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 1, NULL, 1)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (3, N'CLUB FALCONDO', N'', N'403001484           ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 6, NULL, 5)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (4, N'DISTRIBUIDORA EL HIGUEYANO C POR A', N'', N'130253031           ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 1, NULL, 2)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (5, N'GRUPO BALTIUSA SRL', N'', N'131306772           ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 4, NULL, 3)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (6, N'SUPEMERCADO NACIONALES ', N'', N'101019921           ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 1, NULL, 4)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (7, N'TRILOGY', N'', N'101002026           ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 1, NULL, 1)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (8, N'TRANSPORTE ESPINAL SRL', N'', N'102312028           ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 1, NULL, 7)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (9, N'PARADOR EL PINO', N'', N'130306869           ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 2, NULL, 5)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (10, N'ASOCIACION DE FABRICANTES LOCALES', N'', N'430044318           ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 1, NULL, 1)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (11, N'LECHONERA EL BORICUA', N'', N'06800023696         ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 1, NULL, 1)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (12, N'AFADULCE', N'', N'000001805           ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 1, NULL, 1)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (13, N'CONSORCIO CITRICOS DOMINICANOS', N'', N'101164212           ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 1, NULL, 1)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (14, N'ANEUDY', N'PEREZ CABRERA', N'04801118367         ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 2, NULL, 1)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (15, N'CAMILO', N'ROJAS', N'2020036             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 2, NULL, 1)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (16, N'ANTONIO', N'DE JESUS', N'04800509665         ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 2, NULL, 1)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (17, N'ANTONIO', N'ACOSTA', N'1010206             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 2, NULL, 1)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (18, N'AURA', N'PENA', N'0000016             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 2, NULL, 1)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (19, N'ARELIS', N'ESTEVEZ', N'5030018             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 2, NULL, 1)
GO
INSERT [Persona].[Persona] ([Id], [Nombres], [Apellidos], [Documento], [Titulo], [Contacto], [Empresa], [Correo], [Comentarios], [Direccion], [Direccion_De_Envio], [Fecha_Nacimiento], [Fecha], [Balance], [Limite_Credito], [Id_Tipo_Persona], [Id_Persona], [Id_Estatus]) VALUES (20, N'DAMARIS', N'GERMAN', N'2030009             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 2, NULL, 1)
GO
SET IDENTITY_INSERT [Persona].[Persona] OFF
GO
SET IDENTITY_INSERT [Persona].[Persona_Tipo] ON 

GO
INSERT [Persona].[Persona_Tipo] ([Id], [Descripcion], [secuencia1], [secuencia2], [secuencia3]) VALUES (1, N'Cliente', N'                    ', N'                    ', N'                    ')
GO
INSERT [Persona].[Persona_Tipo] ([Id], [Descripcion], [secuencia1], [secuencia2], [secuencia3]) VALUES (2, N'Empleado', N'                    ', N'                    ', N'                    ')
GO
INSERT [Persona].[Persona_Tipo] ([Id], [Descripcion], [secuencia1], [secuencia2], [secuencia3]) VALUES (3, N'Suplidor', N'                    ', N'                    ', N'                    ')
GO
INSERT [Persona].[Persona_Tipo] ([Id], [Descripcion], [secuencia1], [secuencia2], [secuencia3]) VALUES (4, N'Vendedor', N'                    ', N'                    ', N'                    ')
GO
INSERT [Persona].[Persona_Tipo] ([Id], [Descripcion], [secuencia1], [secuencia2], [secuencia3]) VALUES (5, N'Socio', N'                    ', N'                    ', N'                    ')
GO
INSERT [Persona].[Persona_Tipo] ([Id], [Descripcion], [secuencia1], [secuencia2], [secuencia3]) VALUES (6, N'Miembro', N'                    ', N'                    ', N'                    ')
GO
SET IDENTITY_INSERT [Persona].[Persona_Tipo] OFF
GO
SET IDENTITY_INSERT [Productos].[Producto] ON 

GO
INSERT [Productos].[Producto] ([Id], [Codigo], [Cantidad], [Descripcion], [Precio], [Costo], [Id_Impuesto], [Id_Tipo], [Id_Estatus]) VALUES (1, N'0001', CAST(0.00 AS Numeric(18, 2)), N'Servicio de Mantenimiento de Sistemas', CAST(100.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 1, 2, 1)
GO
INSERT [Productos].[Producto] ([Id], [Codigo], [Cantidad], [Descripcion], [Precio], [Costo], [Id_Impuesto], [Id_Tipo], [Id_Estatus]) VALUES (2, N'0002', CAST(0.00 AS Numeric(18, 2)), N'Servicio de Diagnostico para equipo', CAST(200.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 2, 2, 1)
GO
INSERT [Productos].[Producto] ([Id], [Codigo], [Cantidad], [Descripcion], [Precio], [Costo], [Id_Impuesto], [Id_Tipo], [Id_Estatus]) VALUES (3, N'0003', CAST(1.00 AS Numeric(18, 2)), N'Laptop DELL E6510', CAST(300.00 AS Numeric(18, 2)), CAST(300.00 AS Numeric(18, 2)), 3, 1, 1)
GO
INSERT [Productos].[Producto] ([Id], [Codigo], [Cantidad], [Descripcion], [Precio], [Costo], [Id_Impuesto], [Id_Tipo], [Id_Estatus]) VALUES (4, N'0004', CAST(1.00 AS Numeric(18, 2)), N'Laptop ASUS pantalla tactil', CAST(400.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 4, 1, 1)
GO
INSERT [Productos].[Producto] ([Id], [Codigo], [Cantidad], [Descripcion], [Precio], [Costo], [Id_Impuesto], [Id_Tipo], [Id_Estatus]) VALUES (5, N'0005', CAST(1.00 AS Numeric(18, 2)), N'Cargador USB IPhone X', CAST(500.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 5, 1, 1)
GO
INSERT [Productos].[Producto] ([Id], [Codigo], [Cantidad], [Descripcion], [Precio], [Costo], [Id_Impuesto], [Id_Tipo], [Id_Estatus]) VALUES (6, N'0006', CAST(1.00 AS Numeric(18, 2)), N'Cargador USB Wireless IPhone X', CAST(600.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 2, 1, 1)
GO
INSERT [Productos].[Producto] ([Id], [Codigo], [Cantidad], [Descripcion], [Precio], [Costo], [Id_Impuesto], [Id_Tipo], [Id_Estatus]) VALUES (7, N'0007', CAST(1.00 AS Numeric(18, 2)), N'Escritorio para oficina principal', CAST(0.00 AS Numeric(18, 2)), CAST(700.00 AS Numeric(18, 2)), 6, 3, 1)
GO
INSERT [Productos].[Producto] ([Id], [Codigo], [Cantidad], [Descripcion], [Precio], [Costo], [Id_Impuesto], [Id_Tipo], [Id_Estatus]) VALUES (8, N'0008', CAST(0.00 AS Numeric(18, 2)), N'Credenza para oficina principal', CAST(0.00 AS Numeric(18, 2)), CAST(800.00 AS Numeric(18, 2)), 2, 3, 1)
GO
INSERT [Productos].[Producto] ([Id], [Codigo], [Cantidad], [Descripcion], [Precio], [Costo], [Id_Impuesto], [Id_Tipo], [Id_Estatus]) VALUES (9, N'0009', CAST(0.00 AS Numeric(18, 2)), N'Laptop Infinity War Disco SSD 500', CAST(0.00 AS Numeric(18, 2)), CAST(900.00 AS Numeric(18, 2)), 6, 3, 1)
GO
INSERT [Productos].[Producto] ([Id], [Codigo], [Cantidad], [Descripcion], [Precio], [Costo], [Id_Impuesto], [Id_Tipo], [Id_Estatus]) VALUES (10, N'0010', CAST(0.00 AS Numeric(18, 2)), N'Servicios varios', CAST(1000.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 6, 2, 1)
GO
SET IDENTITY_INSERT [Productos].[Producto] OFF
GO
SET IDENTITY_INSERT [Productos].[Producto_Tipo] ON 

GO
INSERT [Productos].[Producto_Tipo] ([Id], [Descripcion], [Secuencia1], [Secuencia2]) VALUES (1, N'Parte de Inventario', N'          ', N'          ')
GO
INSERT [Productos].[Producto_Tipo] ([Id], [Descripcion], [Secuencia1], [Secuencia2]) VALUES (2, N'Servicio', N'          ', N'          ')
GO
INSERT [Productos].[Producto_Tipo] ([Id], [Descripcion], [Secuencia1], [Secuencia2]) VALUES (3, N'Activo Fijo', N'          ', N'          ')
GO
INSERT [Productos].[Producto_Tipo] ([Id], [Descripcion], [Secuencia1], [Secuencia2]) VALUES (4, N'Muebles de Oficina', N'          ', N'          ')
GO
SET IDENTITY_INSERT [Productos].[Producto_Tipo] OFF
GO
SET IDENTITY_INSERT [Productos].[Tasa_Impuesto] ON 

GO
INSERT [Productos].[Tasa_Impuesto] ([Id], [Descripcion], [Leyenda], [Tasa]) VALUES (1, N'Impuestos de 16%', N'T1        ', CAST(16.00 AS Numeric(4, 2)))
GO
INSERT [Productos].[Tasa_Impuesto] ([Id], [Descripcion], [Leyenda], [Tasa]) VALUES (2, N'Impuestos de 18%', N'T2        ', CAST(18.00 AS Numeric(4, 2)))
GO
INSERT [Productos].[Tasa_Impuesto] ([Id], [Descripcion], [Leyenda], [Tasa]) VALUES (3, N'Impuestos de 8%', N'T3        ', CAST(8.00 AS Numeric(4, 2)))
GO
INSERT [Productos].[Tasa_Impuesto] ([Id], [Descripcion], [Leyenda], [Tasa]) VALUES (4, N'Impuestos de 11%', N'T4        ', CAST(11.00 AS Numeric(4, 2)))
GO
INSERT [Productos].[Tasa_Impuesto] ([Id], [Descripcion], [Leyenda], [Tasa]) VALUES (5, N'Impuestos de 13%', N'T5        ', CAST(13.00 AS Numeric(4, 2)))
GO
INSERT [Productos].[Tasa_Impuesto] ([Id], [Descripcion], [Leyenda], [Tasa]) VALUES (6, N'Excento', N'E         ', CAST(0.00 AS Numeric(4, 2)))
GO
SET IDENTITY_INSERT [Productos].[Tasa_Impuesto] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Producto__06370DACC2450C3A]    Script Date: 5/21/2018 11:43:53 PM ******/
ALTER TABLE [Productos].[Producto] ADD UNIQUE NONCLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Persona].[Persona] ADD  CONSTRAINT [DF_Persona_Apellidos]  DEFAULT (N'Nombres + '' '' + Apellidos') FOR [Apellidos]
GO
ALTER TABLE [Persona].[Persona] ADD  CONSTRAINT [DF_Persona_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [Persona].[Persona] ADD  CONSTRAINT [DF_Persona_Balance]  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [Persona].[Persona] ADD  CONSTRAINT [DF_Persona_Limite_Credito]  DEFAULT ((0)) FOR [Limite_Credito]
GO
ALTER TABLE [Productos].[Producto] ADD  CONSTRAINT [DF_Producto_Cantidad]  DEFAULT ((0)) FOR [Cantidad]
GO
ALTER TABLE [Productos].[Producto] ADD  CONSTRAINT [DF_Producto_Precio]  DEFAULT ((0)) FOR [Precio]
GO
ALTER TABLE [Productos].[Producto] ADD  CONSTRAINT [DF_Producto_Costo]  DEFAULT ((0)) FOR [Costo]
GO
ALTER TABLE [Orden].[Orden]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Condiciones] FOREIGN KEY([Id_Condiciones])
REFERENCES [Orden].[Condiciones] ([Id])
GO
ALTER TABLE [Orden].[Orden] CHECK CONSTRAINT [FK_Orden_Condiciones]
GO
ALTER TABLE [Orden].[Orden]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Estatus] FOREIGN KEY([Id_Estatus])
REFERENCES [Miselaneos].[Estatus] ([Id])
GO
ALTER TABLE [Orden].[Orden] CHECK CONSTRAINT [FK_Orden_Estatus]
GO
ALTER TABLE [Orden].[Orden]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Orden_Tipo] FOREIGN KEY([Id_Tipo])
REFERENCES [Orden].[Orden_Tipo] ([Id])
GO
ALTER TABLE [Orden].[Orden] CHECK CONSTRAINT [FK_Orden_Orden_Tipo]
GO
ALTER TABLE [Orden].[Orden_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Detalle_Orden] FOREIGN KEY([Id_Orden])
REFERENCES [Orden].[Orden] ([Id])
GO
ALTER TABLE [Orden].[Orden_Detalle] CHECK CONSTRAINT [FK_Orden_Detalle_Orden]
GO
ALTER TABLE [Orden].[Orden_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Detalle_Producto] FOREIGN KEY([Id_Producto])
REFERENCES [Productos].[Producto] ([Id])
GO
ALTER TABLE [Orden].[Orden_Detalle] CHECK CONSTRAINT [FK_Orden_Detalle_Producto]
GO
ALTER TABLE [Persona].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Estatus] FOREIGN KEY([Id_Estatus])
REFERENCES [Miselaneos].[Estatus] ([Id])
GO
ALTER TABLE [Persona].[Persona] CHECK CONSTRAINT [FK_Persona_Estatus]
GO
ALTER TABLE [Persona].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Persona_Tipo] FOREIGN KEY([Id_Tipo_Persona])
REFERENCES [Persona].[Persona_Tipo] ([Id])
GO
ALTER TABLE [Persona].[Persona] CHECK CONSTRAINT [FK_Persona_Persona_Tipo]
GO
ALTER TABLE [Persona].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Persona3] FOREIGN KEY([Id_Persona])
REFERENCES [Persona].[Persona] ([Id])
GO
ALTER TABLE [Persona].[Persona] CHECK CONSTRAINT [FK_Persona_Persona3]
GO
ALTER TABLE [Productos].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Estatus] FOREIGN KEY([Id_Estatus])
REFERENCES [Miselaneos].[Estatus] ([Id])
GO
ALTER TABLE [Productos].[Producto] CHECK CONSTRAINT [FK_Producto_Estatus]
GO
ALTER TABLE [Productos].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Producto_Tipo] FOREIGN KEY([Id_Tipo])
REFERENCES [Productos].[Producto_Tipo] ([Id])
GO
ALTER TABLE [Productos].[Producto] CHECK CONSTRAINT [FK_Producto_Producto_Tipo]
GO
ALTER TABLE [Productos].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Tasa_Impuesto] FOREIGN KEY([Id_Impuesto])
REFERENCES [Productos].[Tasa_Impuesto] ([Id])
GO
ALTER TABLE [Productos].[Producto] CHECK CONSTRAINT [FK_Producto_Tasa_Impuesto]
GO
USE [master]
GO
ALTER DATABASE [MD_MVC] SET  READ_WRITE 
GO
