USE [TestCrud]
GO

/****** Object:  Table [dbo].[tPeliculaAlquiler]    Script Date: 27/8/2022 12:02:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tPeliculaAlquiler](
	[cod_pelicula_alquiler] [int] IDENTITY(1,1) NOT NULL,
	[cod_usuario] [int] NOT NULL,
	[cod_pelicula] [int] NOT NULL,
	[precio_alquiler] [numeric](18, 2) NULL,
	[fecha_alquiler] [smalldatetime] NULL,
 CONSTRAINT [PK_tPeliculaAlquiler] PRIMARY KEY CLUSTERED 
(
	[cod_pelicula_alquiler] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tPeliculaAlquiler]  WITH CHECK ADD  CONSTRAINT [FK_tPeliculaAlquiler_tPeliculaAlquiler] FOREIGN KEY([cod_pelicula])
REFERENCES [dbo].[tPelicula] ([cod_pelicula])
GO

ALTER TABLE [dbo].[tPeliculaAlquiler] CHECK CONSTRAINT [FK_tPeliculaAlquiler_tPeliculaAlquiler]
GO

ALTER TABLE [dbo].[tPeliculaAlquiler]  WITH CHECK ADD  CONSTRAINT [FK_tPeliculaAlquiler_tUsers] FOREIGN KEY([cod_usuario])
REFERENCES [dbo].[tUsers] ([cod_usuario])
GO

ALTER TABLE [dbo].[tPeliculaAlquiler] CHECK CONSTRAINT [FK_tPeliculaAlquiler_tUsers]
GO



CREATE TABLE [dbo].[tPeliculaVenta](
	[cod_pelicula_venta] [int] IDENTITY(1,1) NOT NULL,
	[cod_usuario] [int] NOT NULL,
	[cod_pelicula] [int] NOT NULL,
	[precio_venta] [numeric](18, 2) NULL,
	[fecha_venta] [smalldatetime] NULL,
 CONSTRAINT [PK_tPeliculaVenta] PRIMARY KEY CLUSTERED 
(
	[cod_pelicula_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tPeliculaVenta]  WITH CHECK ADD  CONSTRAINT [FK_tPeliculaVenta_tPelicula] FOREIGN KEY([cod_pelicula])
REFERENCES [dbo].[tPelicula] ([cod_pelicula])
GO

ALTER TABLE [dbo].[tPeliculaVenta] CHECK CONSTRAINT [FK_tPeliculaVenta_tPelicula]
GO

ALTER TABLE [dbo].[tPeliculaVenta]  WITH CHECK ADD  CONSTRAINT [FK_tPeliculaVenta_tUsers] FOREIGN KEY([cod_usuario])
REFERENCES [dbo].[tUsers] ([cod_usuario])
GO

ALTER TABLE [dbo].[tPeliculaVenta] CHECK CONSTRAINT [FK_tPeliculaVenta_tUsers]
GO
