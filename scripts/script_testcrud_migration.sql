USE [TestCrud]
GO

/****** Object:  Table [dbo].[tRol]    Script Date: 27/08/2022 11:24:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tRol]') AND type in (N'U'))
DROP TABLE [dbo].[tRol]
GO

/****** Object:  Table [dbo].[tRol]    Script Date: 27/08/2022 11:24:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tRol](
	[cod_rol] [int] IDENTITY(1,1) NOT NULL,
	[txt_desc] [varchar](500) NULL,
	[sn_activo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[tUsers] DROP CONSTRAINT [fk_user_rol]
GO

/****** Object:  Table [dbo].[tUsers]    Script Date: 27/08/2022 11:25:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tUsers]') AND type in (N'U'))
DROP TABLE [dbo].[tUsers]
GO

/****** Object:  Table [dbo].[tUsers]    Script Date: 27/08/2022 11:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tUsers](
	[cod_usuario] [int] IDENTITY(1,1) NOT NULL,
	[txt_user] [varchar](50) NULL,
	[txt_password] [varchar](50) NULL,
	[txt_nombre] [varchar](200) NULL,
	[txt_apellido] [varchar](200) NULL,
	[nro_doc] [varchar](50) NULL,
	[cod_rol] [int] NULL,
	[sn_activo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tUsers]  WITH CHECK ADD  CONSTRAINT [fk_user_rol] FOREIGN KEY([cod_rol])
REFERENCES [dbo].[tRol] ([cod_rol])
GO

ALTER TABLE [dbo].[tUsers] CHECK CONSTRAINT [fk_user_rol]
GO

INSERT INTO [trol] ([txt_desc],[sn_activo])VALUES('Administrador',1)
INSERT INTO [trol] ([txt_desc],[sn_activo])VALUES('Cliente',1)

INSERT INTO [tusers] ([txt_user],[txt_password],[txt_nombre],[txt_apellido],[nro_doc],[cod_rol],[sn_activo])VALUES('Admin','PassAdmin123','Administrador','Test','1234321',1,1)
INSERT INTO [tusers] ([txt_user],[txt_password],[txt_nombre],[txt_apellido],[nro_doc],[cod_rol],[sn_activo])VALUES('userTest','Test1','Ariel','ApellidoConA','12312321',2,1)
INSERT INTO [tusers] ([txt_user],[txt_password],[txt_nombre],[txt_apellido],[nro_doc],[cod_rol],[sn_activo])VALUES('userTest2','Test2','Bernardo','ApellidoConB','12312322',2,1)
INSERT INTO [tusers] ([txt_user],[txt_password],[txt_nombre],[txt_apellido],[nro_doc],[cod_rol],[sn_activo])VALUES('userTest3','Test3','Carlos','ApellidoConC','12312323',2,-1)