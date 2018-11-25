USE GD2C2018
GO
-----------------------DROP TABLES-------------------------------
IF OBJECT_ID('VADIUM.ROL') IS NOT NULL
DROP TABLE [VADIUM].ROL
GO
IF OBJECT_ID('VADIUM.USUARIO') IS NOT NULL
DROP TABLE [VADIUM].USUARIO
GO
IF OBJECT_ID('VADIUM.ROL_POR_USUARIO') IS NOT NULL
DROP TABLE [VADIUM].ROL_POR_USUARIO
GO
IF OBJECT_ID('VADIUM.FUNCIONALIDAD') IS NOT NULL
DROP TABLE [VADIUM].FUNCIONALIDAD
GO
IF OBJECT_ID('VADIUM.ROL_POR_FUNCIONALIDAD') IS NOT NULL
DROP TABLE [VADIUM].ROL_POR_FUNCIONALIDAD
GO
IF OBJECT_ID('VADIUM.DIRECCION') IS NOT NULL
DROP TABLE [VADIUM].ROL_POR_FUNCIONALIDAD
GO
IF OBJECT_ID('VADIUM.CLIENTE') IS NOT NULL
DROP TABLE [VADIUM].CLIENTE
GO
IF OBJECT_ID('VADIUM.TARJETADECREDITO') IS NOT NULL
DROP TABLE [VADIUM].TARJETADECREDITO
GO
IF OBJECT_ID('VADIUM.EMPRESA') IS NOT NULL
DROP TABLE [VADIUM].EMPRESA
GO
IF OBJECT_ID('VADIUM.RUBRO') IS NOT NULL
DROP TABLE [VADIUM].RUBRO
GO
IF OBJECT_ID('VADIUM.GRADO') IS NOT NULL
DROP TABLE [VADIUM].GRADO
GO
IF OBJECT_ID('VADIUM.PUBLICACION') IS NOT NULL
DROP TABLE [VADIUM].PUBLICACION
GO
IF OBJECT_ID('VADIUM.TIPOUBICACION') IS NOT NULL
DROP TABLE [VADIUM].TIPOUBICACION
GO

IF OBJECT_ID('VADIUM.ESTADO') IS NOT NULL
DROP TABLE [VADIUM].ESTADO
GO
IF OBJECT_ID('VADIUM.UBICACION') IS NOT NULL
DROP TABLE [VADIUM].UBICACION
GO
IF OBJECT_ID('VADIUM.ITEMFACTURA') IS NOT NULL
DROP TABLE [VADIUM].ITEMFACTURA
GO
IF OBJECT_ID('VADIUM.FACTURA') IS NOT NULL
DROP TABLE [VADIUM].FACTURA
GO
IF OBJECT_ID('VADIUM.PREMIO') IS NOT NULL
DROP TABLE [VADIUM].PREMIO
GO
IF OBJECT_ID('VADIUM.PREMIO_POR_CLIENTE') IS NOT NULL
DROP TABLE [VADIUM].PREMIO_POR_CLIENTE
GO
-----------------------DROP SCHEMA--------------------------------
IF SCHEMA_ID('VADIUM') IS NOT NULL
	DROP SCHEMA [LOSNOOBS]
GO

-----------------------------CREACION SCHEMA --------------------------------
CREATE SCHEMA [VADIUM]
GO
------------------------------CRATE TABLES---------------------------------
CREATE TABLE [VADIUM].ROL(
	rol_id int PRIMARY KEY IDENTITY(1,1),
	rol_habilitado bit DEFAULT 1, 
	rol_nombre nvarchar(255) UNIQUE not null
)
GO

CREATE TABLE [VADIUM].USUARIO(
	usuario_id int PRIMARY KEY IDENTITY(1,1),
	usuario_username nvarchar(255) NOT NULL UNIQUE,
	usuario_password binary(32) NOT NULL,
	usuario_intentosLogin int default 0,
	usuario_activo BIT,
	primera_vez BIT
)
GO

CREATE TABLE [VADIUM].ROL_POR_USUARIO(
	rol_id int,
	usuario_id int,
	PRIMARY KEY (rol_id, usuario_id)
)
GO

CREATE TABLE [VADIUM].FUNCIONALIDAD(
	funcionalidad_id int PRIMARY KEY IDENTITY (1,1),
	funcionalidad_descripcion nvarchar(255)
)
GO

CREATE TABLE [VADIUM].ROL_POR_FUNCIONALIDAD(
	rol_id int,
	funcionalidad_id int,
	PRIMARY KEY(rol_id, funcionalidad_id)	
)
GO
CREATE TABLE [VADIUM].DIRECCION(
	direccion_id int PRIMARY KEY IDENTITY(1,1),
	calle NVARCHAR(255),
	nro_calle NUMERIC(18,0),
	piso NUMERIC(18,0),
	depto NVARCHAR (255),
	cod_postal nvarchar(255),
	localidad nvarchar(255),
	ciudad nvarchar(255)

)
GO
CREATE TABLE [VADIUM].CLIENTE(
	cliente_id int PRIMARY KEY IDENTITY(1,1),
	usuario_id int,
	nombre nvarchar(255),
	apellido nvarchar(255),
	tipoDocumento nvarchar(5),
	numeroDocumento numeric(18,0),
	CUIL nvarchar(20),
	fechaNacimiento datetime,
	fechaCreacion datetime,
	tarjetaCredito nvarchar(20),
	mail nvarchar(255),
	telefono nvarchar(255),
	puntos int,
	direccion_id int

)
GO
CREATE TABLE [VADIUM].TARJETADECREDITO(
	NroTarjeta numeric(18,0) PRIMARY KEY IDENTITY(1,1),
	banco nvarchar(127),
	codSeguridad int,
	tipo nvarchar(255),
	cliente_id int,
	puntos int,
	fechaExpedicion datetime,
	fechaVencimiento datetime,
)
GO
CREATE TABLE [VADIUM].EMPRESA(
	 empresa_id int PRIMARY KEY IDENTITY(1,1),
	 usuario_id int, 
	 fechaCreacion datetime,
	 razonSocial nvarchar(255),
	 cuit nvarchar(255),
	 mail nvarchar(255),
	 telefono nvarchar(255),
	 direccion_id int
)
GO
CREATE TABLE [VADIUM].RUBRO(
	rubro_id int PRIMARY KEY,
	descripcion nvarchar(255),
)
GO
CREATE TABLE [VADIUM].GRADO(
	grado_id int PRIMARY KEY,
	comision numeric(18,2),
	prioridad int
)
CREATE TABLE [VADIUM].ESTADO(
	codigo int PRIMARY KEY IDENTITY(1,1),
	descripcion nvarchar(255)
)
GO
CREATE TABLE [VADIUM].PUBLICACION(
	codigo int PRIMARY KEY,
	descripcion nvarchar(255),
	feach datetime, 
	fechaVencimiento datetime,
	estado_id int,
	direccion nvarchar(255),
	rubro_id int,
	grado_id int,
	empresa_id int
)
GO

CREATE TABLE [VADIUM].TIPOUBICACION(
	codigo int PRIMARY KEY IDENTITY(1,1),
	descripcion nvarchar(255)
)
GO
CREATE TABLE [VADIUM].UBICACION(
	ubicacion_id int PRIMARY KEY IDENTITY(1,1),
	fila nvarchar(3),
	asiento numeric(18,0),
	sinNumerar bit, 
	precio numeric(18,0),
	codigoTipoUbicacion int,
	codigoEspectaculo int

)
GO
CREATE TABLE [VADIUM].FACTURA(
	factura_nro int PRIMARY KEY,
	fecha datetime,
	total numeric(18,2),
	descripcion nvarchar(255)
)
GO
CREATE TABLE [VADIUM].ITEMFACTURA(
	factura_nro int,
	cliente_id int,
	ubicacion_id int,
	monto numeric(18,2),
	cantidad numeric(18,2),
	descripcion nvarchar(60)
)
GO
----------------------------TRIGGERS-------------------------------

    -----------EMPRESA-------
CREATE TRIGGER [VADIUM].TriggerNuevaEmpresa
ON VADIUM.EMPRESA
INSTEAD OF INSERT
AS
BEGIN TRY
	INSERT INTO VADIUM.USUARIO(usuario_username, usuario_password, usuario_activo, usuario_intentosLogin, primera_vez)
	SELECT I.mail,  HashBytes('SHA2_256',I.cuit), 1,0, 1
	FROM inserted I
	WHERE I.mail NOT IN(SELECT users.usuario_username FROM VADIUM.USUARIO users)

	INSERT INTO VADIUM.ROL_POR_USUARIO(rol_id,usuario_id)
	SELECT 2, user.usuario_id
	FROM inserted I JOIN VAIDUM.USUARIO us ON (us.usuario_username = I.mail)
	WHERE NOT EXISTS(SELECT 2 FROM VADIUM.ROL_POR_USUARIO rolUser WHERE rolUser.rol_id = 1 AND rolUser.usuario_id = user.usuario_id)



	INSERT INTO VADIUM.EMPRESA(razonSocial, cuit, mail,  fechaCreacion, usuario_id)
	SELECT ins.razonSocial, ins.cuit, ins.mail, ins.fechaCreacion, (SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_username = I.mail)
	FROM inserted ins
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
   -----CLIENTE--------
CREATE TRIGGER [VADIUM].TriggerNuevoCliente
ON VADIUM.EMPRESA
INSTEAD OF INSERT
AS
BEGIN TRY
	INSERT INTO VADIUM.USUARIO(usuario_username, usuario_password, usuario_activo, usuario_intentosLogin, primera_vez)
	SELECT I.mail,  HashBytes('SHA2_256',I.cuit), 1,0, 1
	FROM inserted I
	WHERE I.mail NOT IN(SELECT users.usuario_username FROM VADIUM.USUARIO users)

	INSERT INTO VADIUM.ROL_POR_USUARIO(rol_id,usuario_id)
	SELECT 1, user.usuario_id
	FROM inserted I JOIN VAIDUM.USUARIO us ON (us.usuario_username = I.mail)
	WHERE NOT EXISTS(SELECT 2 FROM VADIUM.ROL_POR_USUARIO rolUser WHERE rolUser.rol_id = 2 AND rolUser.usuario_id = user.usuario_id)



	INSERT INTO VADIUM.CLIENTE(numeroDocumento, tipoDocumento, apellido, nombre, fechaNacimiento, mail,puntos,  usuario_id )
	SELECT ins.numeroDocumento, ins.tipoDocumento, ins.apellido, ins.nombre,ins.fechaNacimiento, ins.mail, 0, (SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_username = I.mail)
	FROM inserted ins
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO



----------------------------FUNCIONALIDADES-------------------------
CREATE PROCEDURE [VADIUM].PR_DATOS_INSERT_DATOS_INICIALES
AS
BEGIN
	INSERT INTO [VADIUM].FUNCIONALIDAD(funcionalidad_descripcion) VALUES('Comprar')

	-- ROL 
	INSERT INTO [VADIUM].ROL (rol_id,descripcion) values(0,'Administrador')
	INSERT INTO [VADIUM].ROL (rol_id,descripcion) values(1,'Cliente')
	INSERT INTO [VADIUM].ROL (rol_id,descripcion) values(2,'Empresa')

	-- PREMIOS
	INSERT INTO [VADIUM].PREMIO (puntos, PREMIO) VALUES (100, ' voucher entrada gratis')
	INSERT INTO [VADIUM].PREMIO (puntos, PREMIO) VALUES (50, ' voucher 50% descuento en entradas')
END
GO

------------------------------MIGRACION------------------------------

CREATE PROCEDURE [VADIUM].PR_MIGRACION
AS
BEGIN
	------ TIPO UBICACION ------------
	INSERT INTO [VADIUM].TIPOUBICACION(codigo, descripcion)
	SELECT  m.Ubicacion_Tipo_Codigo , m.Ubicacion_Tipo_Descripcion
	FROM gd_esquema.Maestra m
	GROUP BY Ubicacion_Tipo_Codigo, Ubicacion_Tipo_Descripcion
	-------DIRECCIONES EMPRESA----
	INSERT INTO [VADIUM].DIRECCION(calle, nro_calle, piso, depto, cod_postal)
	SELECT  m.Espec_Empresa_Dom_Calle, m.Espec_Empresa_Nro_Calle, m.Espec_Empresa_Piso, m.Espec_Empresa_Depto, m.Espec_Empresa_Cod_Postal
	FROM gd_esquema.Maestra m
	GROUP BY m.Espec_Empresa_Dom_Calle, m.Espec_Empresa_Nro_Calle, m.Espec_Empresa_Piso, m.Espec_Empresa_Depto, m.Espec_Empresa_Cod_Postal	

	-------EMPRESA------
	INSERT INTO [VADIUM].EMPRESA(razonSocial, cuit, mail, fechaCreacion, direccion_id )
	SELECT  m.Espec_Empresa_Razon_Social, m.Espec_Empresa_Cuit, m.Espec_Empresa_Mail, m.Espec_Empresa_Fecha_Creacion,
			(SELECT TOP 1 dir.direccion_id FROM DIRECCION dir 
						WHERE dir.calle+dir.nro_calle+dir.piso+dir.depto+dir.cod_postal = 
							m.Espec_Empresa_Dom_Calle+ m.Espec_Empresa_Nro_Calle+ m.Espec_Empresa_Piso+ m.Espec_Empresa_Depto+ m.Espec_Empresa_Cod_Postal)
	FROM gd_esquema.Maestra m
	GROUP BY m.Espec_Empresa_Razon_Social, m.Espec_Empresa_Cuit, m.Espec_Empresa_Mail, m.Espec_Empresa_Fecha_Creacion, m.Espec_Empresa_Dom_Calle, m.Espec_Empresa_Nro_Calle, m.Espec_Empresa_Piso, m.Espec_Empresa_Depto, m.Espec_Empresa_Cod_Postal	
-------DIRECCIONES CLIENTE----
	INSERT INTO [VADIUM].DIRECCION(calle, nro_calle, piso, depto, cod_postal)
	SELECT  m.Cli_Dom_Calle, m.Cli_Nro_Calle, m.Cli_Piso, m.Cli_Depto, m.Cli_Cod_Postal
	FROM gd_esquema.Maestra m
	GROUP BY m.Cli_Dom_Calle, m.Cli_Nro_Calle, m.Cli_Piso, m.Cli_Depto, m.Cli_Cod_Postal	

	-------Cliente------
	INSERT INTO [VADIUM].Cliente (numeroDocumento, tipoDocumento, apellido, nombre, fechaNacimiento, mail, direccion_id )
	SELECT  m.Cli_Dni,'DNI' ,m.Cli_Apellido, m.Cli_Nombre, m.Cli_Fecha_Nac, m.Cli_Mail,
	(SELECT TOP 1 dir.direccion_id FROM DIRECCION dir 
						WHERE dir.calle+dir.nro_calle+dir.piso+dir.depto+dir.cod_postal = 
							m.Cli_Dom_Calle+ m.Cli_Nro_Calle+ m.Cli_Piso+ m.Cli_Depto+ m.Cli_Cod_Postal)

	FROM gd_esquema.Maestra m
	GROUP BY m.Cli_Dni, m.Cli_Apellido, m.Cli_Nombre, m.Cli_Fecha_Nac, m.Cli_Mail, m.Cli_Dom_Calle, m.Cli_Nro_Calle, m.Cli_Piso, m.Cli_Depto, m.Cli_Cod_Postal
	------RUBRO--------
	INSERT INTO [VAIDUM].RUBRO(descripcion)
	SELECT m.Espectaculo_Rubro_Descripcion
	FROM gd_esquema.Maestra m 
	GROUP BY m.Espectaculo_Rubro_Descripcion
	------ESTADO--------
	INSERT INTO [VAIDUM].ESTADO(descripcion)
	SELECT m.Espectaculo_Estado
	FROM gd_esquema.Maestra m 
	GROUP BY m.Espectaculo_Estado
	------PUBLICACION-----
		INSERT INTO [VAIDUM].PUBLICACION(codigo, descripcion, fecha, fechaVencimiento, empresa_id, rubro_id, estado_id)
		SELECT m.Espectaculo_Cod, m.Espectaculo_Descripcion, m.Espectaculo_Fecha, m.Espectaculo_Fecha_Venc, 
				(SELECT TOP 1 emp.empresa_id FROM EMPRESA emp WHERE emp.mail = m.Espec_Empresa_Mail), 
				(SELECT TOP 1 ru.rubro_id FROM RUBRO ru WHERE ru.descripcion = m.Espectaculo_Rubro_Descripcion),
				(SELECT TOP 1 es.codigo FROM ESTADO es WHERE es.descripcion = m.Espectaculo_Estado)
		FROM gd_esquema.Maestra m 
		GROUP BY m.Espectaculo_Cod, m.Espectaculo_Descripcion, m.Espectaculo_Fecha, m.Espectaculo_Fecha_Venc, m.Espec_Empresa_Mail, m.Espectaculo_Rubro_Descripcion, Espectaculo_Estado
 ----------- UBICACION--------
	INSERT INTO [VAIDUM].UBICACION(fila, asiento, sinNumerar, precio, codigoTipoUbicacion, codigoEspectaculo)
		SELECT m.Ubicacion_Fila, m.Ubicacion_Asiento, m.Ubicacion_Sin_numerar, m.Ubicacion_Precio, 
				(SELECT TOP 1 tipou.codigo FROM TIPOUBICACION tipou WHERE tipou.codigo = m.Ubicacion_Tipo_Codigo),
				(SELECT TOP 1 publi.codigo FROM PUBLICACION publi WHERE publi.codigo = m.Espectaculo_Cod)
	
		FROM gd_esquema.Maestra m 
		GROUP BY m.Ubicacion_Fila, m.Ubicacion_Asiento, m.Ubicacion_Sin_numerar, m.Ubicacion_Precio, m.Ubicacion_Tipo_Codigo, m.Espectaculo_Cod
	---------FACTURA--------
	INSERT INTO [VAIDUM].FACTURA(factura_nro, fecha, total, descripcion)
		SELECT m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, m.Forma_Pago_Desc
		FROM gd_esquema.Maestra m 
		GROUP BY m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, m.Forma_Pago_Desc
		---------ITEMFACTURA--------
	INSERT INTO [VAIDUM].ITEMFACTURA(monto, cantidad, descripcion, factura_nro,ubicacion_id, cliente_id)
		SELECT m.Item_Factura_Monto, m.Item_Factura_Cantidad, m.Item_Factura_Descripcion, 
		(SELECT TOP 1 fac.factura_nro FROM FACTURA fac WHERE fac.factura_nro = m.Factura_Nro),
		(SELECT TOP 1 ubi.ubicacion_id FROM UBICACION ubi 
			WHERE ubi.fila+ubi.asiento+ubi.sinNumerar+ubi.codigoTipoUbicacion+ubi.codigoEspectaculo = 
					m.Ubicacion_Fila+m.Ubicacion_Asiento+ m.Ubicacion_Sin_numerar+m.Ubicacion_Tipo_Codigo+m.Espectaculo_Cod),
		(SELECT TOP 1 cli.cliente_id  FROM CLIENTE cli WHERE cli.mail = m..Cli_Mail)
		FROM gd_esquema.Maestra m 
		GROUP BY m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, m.Forma_Pago_Desc

END
GO
