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
	[devuelta] [bit] NULL,
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

---------------------------------------------------------------------------------------------------------------
  
/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Alquiler de pelicula  
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_alquilar_pelicula] @cod_pelicula    INT,  
                                             @cod_usuario     INT,  
                                             @precio_alquiler NUMERIC(18, 2)  
AS  
    UPDATE tPelicula  
    SET    cant_disponibles_alquiler = cant_disponibles_alquiler - 1  
    WHERE  cod_pelicula = @cod_pelicula  
  
    INSERT INTO [dbo].[tPeliculaAlquiler]  
                ([cod_usuario],  
                 [cod_pelicula],  
                 [precio_alquiler],  
                 [fecha_alquiler],  
                 [devuelta])  
    VALUES      ( @cod_usuario,  
                  @cod_pelicula,  
                  @precio_alquiler,  
                  Getdate(),  
                  0)   
GO

/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Alta de generos  
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_tgenero_a] @cod_genero INT out,  
                                      @txt_desc   VARCHAR(500)  
AS  
    INSERT INTO [dbo].[tGenero]  
                ([txt_desc])  
    VALUES      (@txt_desc)  
  
    SET @cod_genero = @@IDENTITY   
GO

/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Alta de generos a peliculas  
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_tgeneropelicula_a] @cod_pelicula INT,  
                                              @cod_genero   INT  
AS  
    IF NOT EXISTS (SELECT *  
                   FROM   tGeneroPelicula  
                   WHERE  cod_pelicula = @cod_pelicula  
                          AND cod_genero = @cod_genero)  
      BEGIN  
          INSERT INTO [dbo].[tGeneroPelicula]  
                      ([cod_pelicula],  
                       [cod_genero])  
          VALUES      (@cod_pelicula,  
                       @cod_genero)  
      END   
GO

/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Alta de peliculas  
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_tpelicula_a] @cod_pelicula              INT out,  
                                       @txt_desc                  VARCHAR(500),  
                                       @cant_disponibles_alquiler INT,  
                                       @cant_disponibles_venta    INT,  
                                       @precio_alquiler           NUMERIC(18, 2),  
                                       @precio_venta              NUMERIC(18, 2)  
AS  
    INSERT INTO [dbo].[tPelicula]  
                ([txt_desc],  
                 [cant_disponibles_alquiler],  
                 [cant_disponibles_venta],  
                 [precio_alquiler],  
                 [precio_venta])  
    VALUES      (@txt_desc,  
                 @cant_disponibles_alquiler,  
                 @cant_disponibles_venta,  
                 @precio_alquiler,  
                 @precio_venta )  
  
    SET @cod_pelicula = @@IDENTITY   
GO

/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Borrado lógico de peliculas  
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_tpelicula_b] @cod_pelicula INT  
AS  
    UPDATE [dbo].[tPelicula]  
    SET    [cant_disponibles_alquiler] = 0,  
           [cant_disponibles_venta] = 0  
    WHERE  cod_pelicula = @cod_pelicula  
GO

/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Modificación de peliculas  
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_tpelicula_m] @cod_pelicula              INT,  
                                        @txt_desc                  VARCHAR(500),  
                                        @cant_disponibles_alquiler INT,  
                                        @cant_disponibles_venta    INT,  
                                        @precio_alquiler           NUMERIC(18, 2),  
                                        @precio_venta              NUMERIC(18, 2)  
AS  
    UPDATE [dbo].[tPelicula]  
    SET    [txt_desc] = @txt_desc,  
           [cant_disponibles_alquiler] = @cant_disponibles_alquiler,  
           [cant_disponibles_venta] = @cant_disponibles_venta,  
           [precio_alquiler] = @precio_alquiler,  
           [precio_venta] = @precio_venta  
    WHERE  cod_pelicula = @cod_pelicula  
GO

/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Listado de peliculas alquiladas por un usuario  
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_tpeliculas_alquilada_por_usuario] @cod_usuario INT  
AS  
    SELECT tPelicula.cod_pelicula,  
           tPelicula.txt_desc,  
           tPeliculaAlquiler.precio_alquiler,  
           tPeliculaAlquiler.fecha_alquiler,  
           tPeliculaAlquiler.devuelta  
    FROM   tPeliculaAlquiler  
           INNER JOIN tPelicula  
                   ON tPeliculaAlquiler.cod_pelicula = tPelicula.cod_pelicula  
           INNER JOIN tUsers  
                   ON tPeliculaAlquiler.cod_usuario = tUsers.cod_usuario  
    WHERE  tPeliculaAlquiler.cod_usuario = @cod_usuario   

GO

/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Peliculas en stock para alquilar  
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_tpeliculas_alquiler_en_stock]  
AS  
    SELECT *  
    FROM   tPelicula  
    WHERE  cant_disponibles_alquiler > 0   
GO

/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Estadistica de alquiler de peliculas  
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_tpeliculas_alquiler_estadistica]  
AS  
    SELECT tPelicula.cod_pelicula,  
           tPelicula.txt_desc,  
           Count(1)                               AS cantidad_alquiladas,  
           Sum(tPeliculaAlquiler.precio_alquiler) AS total_recaudado  
    FROM   tPeliculaAlquiler  
           INNER JOIN tPelicula  
                   ON tPeliculaAlquiler.cod_pelicula = tPelicula.cod_pelicula  
    GROUP  BY tPelicula.cod_pelicula,  
              tPelicula.txt_desc
GO

  
/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Devolver pelicula alquilada  
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_tpeliculas_devolver] @cod_pelicula INT,  
                                               @cod_usuario  INT  
AS  
    UPDATE tPelicula  
    SET    cant_disponibles_alquiler = cant_disponibles_alquiler + 1  
    WHERE  cod_pelicula = @cod_pelicula  
  
    UPDATE tPeliculaAlquiler  
    SET    devuelta = 1  
    WHERE  cod_pelicula = @cod_pelicula  
           AND cod_usuario = @cod_usuario   
GO

/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Listado de peliculas con sus usuarios sin devolver  
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_tpeliculas_sin_devolver]  
AS  
    SELECT tPelicula.cod_pelicula,  
           tPelicula.txt_desc,  
           tUsers.cod_usuario,  
           tUsers.txt_nombre,  
           tUsers.txt_apellido  
    FROM   tPeliculaAlquiler  
           INNER JOIN tPelicula  
                   ON tPeliculaAlquiler.cod_pelicula = tPelicula.cod_pelicula  
           INNER JOIN tUsers  
                   ON tPeliculaAlquiler.cod_usuario = tUsers.cod_usuario  
    WHERE  tPeliculaAlquiler.devuelta = 0   
GO

/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Peliculas en stock para vender  
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_tpeliculas_venta_en_stock]  
AS  
    SELECT *  
    FROM   tPelicula  
    WHERE  cant_disponibles_venta > 0   
GO

/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Alta de usuario validando documento              
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_tusers_a] @cod_usuario     INT out,  
                                     @txt_user     VARCHAR(50),  
                                     @txt_password VARCHAR(50),  
                                     @txt_nombre   VARCHAR(200),  
                                     @txt_apellido VARCHAR(200),  
                                     @nro_doc      VARCHAR(50),  
                                     @cod_rol      INT,  
                                     @sn_activo    INT  
AS  
    IF EXISTS (SELECT *  
               FROM   tUsers  
               WHERE  nro_doc = @nro_doc)  
      BEGIN  
          RAISERROR('No se puede insertar el registro, documento ya existente',16,1)  
      END  
    ELSE  
      BEGIN  
          INSERT INTO [dbo].[tUsers]  
                      ([txt_user],  
                       [txt_password],  
                       [txt_nombre],  
                       [txt_apellido],  
                       [nro_doc],  
                       [cod_rol],  
                       [sn_activo])  
          VALUES      (@txt_user,  
                       @txt_password,  
                       @txt_nombre,  
                       @txt_apellido,  
                       @nro_doc,  
                       @cod_rol,  
                       @sn_activo)  
      END    
	  set @cod_usuario = @@IDENTITY
GO

/*--------------------------------------------------------------------------------------------------------------------                
-- Autor: Gian                
-- Fecha de creación: 27/08/2022    
-- Descripción: Venta de pelicula  
--                
-- Modificaciones:                
-- Descripción:                
-- Autor:                
-- Fecha:                
--                
----------------------------------------------------------------------------------------------------------------------*/  
CREATE PROCEDURE [dbo].[Sp_venta_pelicula] @cod_pelicula INT,  
                                           @cod_usuario  INT,  
                                           @precio_venta NUMERIC(18, 2)  
AS  
    UPDATE tPelicula  
    SET    cant_disponibles_venta = cant_disponibles_venta - 1  
    WHERE  cod_pelicula = @cod_pelicula  
  
    INSERT INTO [dbo].[tPeliculaVenta]  
                ([cod_usuario],  
                 [cod_pelicula],  
                 [precio_venta],  
                 [fecha_venta])  
    VALUES      ( @cod_usuario,  
                  @cod_pelicula,  
                  @precio_venta,  
                  Getdate())   
GO