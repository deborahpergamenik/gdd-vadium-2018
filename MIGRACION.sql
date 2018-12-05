USE GD2C2018
GO

-------------------------------DROP PROCEDURES-------------------

IF OBJECT_ID('VADIUM.MayorCantLocalidadesNoVendidos') IS NOT NULL
DROP PROCEDURE VADIUM.MayorCantLocalidadesNoVendidos;
GO
IF OBJECT_ID('VADIUM.ClientesPuntosVencidos') IS NOT NULL
DROP PROCEDURE VADIUM.ClientesPuntosVencidos;
GO
IF OBJECT_ID('VADIUM.ClientesMayorCompras') IS NOT NULL
DROP PROCEDURE VADIUM.ClientesMayorCompras;
GO
IF OBJECT_ID('VADIUM.puntajeCliente') IS NOT NULL
DROP PROCEDURE VADIUM.puntajeCliente;
GO
IF OBJECT_ID('VADIUM.CanjearPremio') IS NOT NULL
DROP PROCEDURE VADIUM.CanjearPremio;
GO
IF OBJECT_ID('VADIUM.InsertGrado') IS NOT NULL
DROP PROCEDURE VADIUM.InsertGrado;
GO
IF OBJECT_ID('VADIUM.UpdateGrado') IS NOT NULL
DROP PROCEDURE VADIUM.UpdateGrado;
GO
IF OBJECT_ID('VADIUM.removeGrado') IS NOT NULL
DROP PROCEDURE VADIUM.removeGrado;
GO
IF OBJECT_ID('VADIUM.PR_DATOS_INSERT_DATOS_INICIALES') IS NOT NULL
DROP PROCEDURE VADIUM.PR_DATOS_INSERT_DATOS_INICIALES;
GO
IF OBJECT_ID('VADIUM.PR_MIGRACION') IS NOT NULL
DROP PROCEDURE VADIUM.PR_MIGRACION;
GO
------------------------------DROP TRIGGERS ---------------------------------
IF OBJECT_ID('VADIUM.TriggerNuevaEmpresa') IS NOT NULL
DROP TRIGGER VADIUM.TriggerNuevaEmpresa
GO
IF OBJECT_ID('VADIUM.TriggerNuevoCliente') IS NOT NULL
DROP TRIGGER VADIUM.TriggerNuevoCliente
GO
IF OBJECT_ID('VADIUM.TR_NuevaEmpresa') IS NOT NULL
DROP TRIGGER VADIUM.TR_NuevaEmpresa
GO
IF OBJECT_ID('VADIUM.TR_NuevoCliente') IS NOT NULL
DROP TRIGGER VADIUM.TR_NuevoCliente
GO

-----------------------DROP TABLES-------------------------------
IF OBJECT_ID('VADIUM.ROL_POR_FUNCIONALIDAD') IS NOT NULL
DROP TABLE [VADIUM].ROL_POR_FUNCIONALIDAD
GO
IF OBJECT_ID('VADIUM.ROL_POR_USUARIO') IS NOT NULL
DROP TABLE [VADIUM].ROL_POR_USUARIO
GO
IF OBJECT_ID('VADIUM.ROL') IS NOT NULL
DROP TABLE [VADIUM].ROL
GO
IF OBJECT_ID('VADIUM.FUNCIONALIDAD') IS NOT NULL
DROP TABLE [VADIUM].FUNCIONALIDAD
GO

IF OBJECT_ID('VADIUM.ITEMFACTURA') IS NOT NULL
DROP TABLE [VADIUM].ITEMFACTURA
GO
IF OBJECT_ID('VADIUM.FACTURA') IS NOT NULL
DROP TABLE [VADIUM].FACTURA
GO


IF OBJECT_ID('VADIUM.UBICACION') IS NOT NULL
DROP TABLE [VADIUM].UBICACION
GO
IF OBJECT_ID('VADIUM.TIPOUBICACION') IS NOT NULL
DROP TABLE [VADIUM].TIPOUBICACION
GO

IF OBJECT_ID('VADIUM.PUBLICACION') IS NOT NULL
DROP TABLE [VADIUM].PUBLICACION
GO

IF OBJECT_ID('VADIUM.ESTADO') IS NOT NULL
DROP TABLE [VADIUM].ESTADO
GO
IF OBJECT_ID('VADIUM.RUBRO') IS NOT NULL
DROP TABLE [VADIUM].RUBRO
GO
IF OBJECT_ID('VADIUM.GRADO') IS NOT NULL
DROP TABLE [VADIUM].GRADO
GO







IF OBJECT_ID('VADIUM.PREMIO_POR_CLIENTE') IS NOT NULL
DROP TABLE [VADIUM].PREMIO_POR_CLIENTE
GO
IF OBJECT_ID('VADIUM.PREMIO') IS NOT NULL
DROP TABLE [VADIUM].PREMIO
GO


IF OBJECT_ID('VADIUM.TARJETADECREDITO') IS NOT NULL
DROP TABLE [VADIUM].TARJETADECREDITO
GO

IF OBJECT_ID('VADIUM.EMPRESA') IS NOT NULL
DROP TABLE [VADIUM].EMPRESA
GO

IF OBJECT_ID('VADIUM.CLIENTE') IS NOT NULL
DROP TABLE [VADIUM].CLIENTE
GO

IF OBJECT_ID('VADIUM.USUARIO') IS NOT NULL
DROP TABLE [VADIUM].USUARIO
GO

IF OBJECT_ID('VADIUM.DIRECCION') IS NOT NULL
DROP TABLE VADIUM.DIRECCION
GO


-----------------------DROP SCHEMA--------------------------------
IF SCHEMA_ID('VADIUM') IS NOT NULL
	DROP SCHEMA [VADIUM]
GO

-----------------------------CREACION SCHEMA --------------------------------
CREATE SCHEMA [VADIUM]
GO
------------------------------CRATE TABLES---------------------------------
CREATE TABLE [VADIUM].ROL(
	rol_id int PRIMARY KEY,
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
	tipoDocumento nvarchar(50),
	numeroDocumento numeric(18,0),
	CUIL nvarchar(20),
	fechaNacimiento datetime,
	fechaCreacion datetime,
	tarjetaCredito numeric(18,0),
	mail nvarchar(255),
	telefono nvarchar(255),
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
	rubro_id int PRIMARY KEY IDENTITY(1,1),
	descripcion nvarchar(255),
)
GO
CREATE TABLE [VADIUM].GRADO( 
	grado_id int PRIMARY KEY,
	comision numeric(18,2),
	descripcion nvarchar(255)
)
CREATE TABLE [VADIUM].ESTADO(
	codigo int PRIMARY KEY IDENTITY(1,1),
	descripcion nvarchar(255)
)
GO
CREATE TABLE [VADIUM].PUBLICACION(
	codigoEspectaculo numeric(18,0) PRIMARY KEY ,
	descripcion nvarchar(255),
	fecha datetime, 
	fechaVencimiento datetime,
	estado_id int,
	direccion nvarchar(255),
	rubro_id int,
	grado_id int,
	empresa_id int
)
GO

CREATE TABLE [VADIUM].TIPOUBICACION(
	codigoTipoUbicacion numeric(18,0) PRIMARY KEY ,
	descripcion nvarchar(255)
)
GO
CREATE TABLE [VADIUM].UBICACION(
	ubicacion_id int PRIMARY KEY IDENTITY(1,1),
	fila nvarchar(3),
	asiento numeric(18,0),
	sinNumerar bit, 
	precio numeric(18,0),
	codigoTipoUbicacion numeric(18,0),
	codigoEspectaculo numeric(18,0)

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
CREATE TABLE [VADIUM].PREMIO(
 premioId int PRIMARY KEY IDENTITY(1,1),
 descripcion varchar(255),
 puntos numeric(18,0),
 stock int, 
 fechaVencimiento datetime
)
CREATE TABLE [VADIUM].PREMIO_POR_CLIENTE(
 premioId int,
 cliente_id int,
 puntos int,
 fecha datetime,
)
GO
----------------------------TRIGGERS-------------------------------

    -----------EMPRESA-------
CREATE TRIGGER [VADIUM].TR_NuevaEmpresa
ON VADIUM.EMPRESA
INSTEAD OF INSERT
AS
BEGIN
	BEGIN TRY
		INSERT INTO VADIUM.USUARIO(usuario_username, usuario_password, usuario_activo, usuario_intentosLogin, primera_vez)
		SELECT I.mail,  HashBytes('SHA2_256',I.cuit), 1,0, 1
		FROM inserted I
		WHERE I.mail NOT IN(SELECT us2.usuario_username FROM VADIUM.USUARIO us2 )

		INSERT INTO VADIUM.ROL_POR_USUARIO(rol_id,usuario_id)
		SELECT 2, us.usuario_id
		FROM inserted I JOIN USUARIO us ON (us.usuario_username = I.mail)
		WHERE NOT EXISTS(SELECT 2 FROM VADIUM.ROL_POR_USUARIO rolUser WHERE rolUser.rol_id = 1 AND rolUser.usuario_id = us.usuario_id)


		INSERT INTO VADIUM.EMPRESA(razonSocial, cuit, mail,  fechaCreacion, usuario_id, direccion_id)
		SELECT ins.razonSocial, ins.cuit, ins.mail, ins.fechaCreacion, 
			(SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_username = ins.mail), ins.direccion_id
		FROM inserted ins
	END TRY
	BEGIN CATCH
	  SELECT 'ERROR', ERROR_MESSAGE()
	END CATCH
END
GO
   -----CLIENTE--------
CREATE TRIGGER [VADIUM].TR_NuevoCliente
ON VADIUM.CLIENTE
INSTEAD OF INSERT
AS
BEGIN
	BEGIN TRY
		INSERT INTO VADIUM.USUARIO(usuario_username, usuario_password, usuario_activo, usuario_intentosLogin, primera_vez)
		SELECT I.mail,  HashBytes('SHA2_256',I.mail), 1,0, 1
		FROM inserted I
		GROUP BY I.mail
		HAVING I.mail NOT IN(SELECT us2.usuario_username FROM VADIUM.USUARIO us2 )
		

		INSERT INTO VADIUM.ROL_POR_USUARIO(rol_id,usuario_id)
		SELECT 1, us.usuario_id
		FROM inserted I JOIN VADIUM.USUARIO us ON (us.usuario_username = I.mail)
		WHERE NOT EXISTS(SELECT 1 FROM VADIUM.ROL_POR_USUARIO rolUser WHERE rolUser.rol_id = 2 AND rolUser.usuario_id = us.usuario_id)
		GROUP BY us.usuario_id,us.usuario_username, i.mail


		INSERT INTO VADIUM.CLIENTE(numeroDocumento, tipoDocumento, apellido, nombre, fechaNacimiento, mail,  usuario_id, direccion_id )
		SELECT ins.numeroDocumento, ins.tipoDocumento, ins.apellido, ins.nombre,ins.fechaNacimiento, ins.mail, 
		(SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_username = ins.mail), ins.direccion_id
		FROM inserted ins

	END TRY
	BEGIN CATCH
	  SELECT 'ERROR', ERROR_MESSAGE()
	END CATCH
END
GO



----------------------------FUNCIONALIDADES-------------------------
CREATE PROCEDURE [VADIUM].PR_DATOS_INSERT_DATOS_INICIALES
AS
BEGIN
	INSERT INTO [VADIUM].FUNCIONALIDAD(funcionalidad_descripcion) VALUES('Comprar')

	-- ROL 
	INSERT INTO [VADIUM].ROL (rol_id,rol_nombre,rol_habilitado) values(0,'Administrador',1)
	INSERT INTO [VADIUM].ROL (rol_id,rol_nombre,rol_habilitado) values(1,'Cliente',1)
	INSERT INTO [VADIUM].ROL (rol_id,rol_nombre,rol_habilitado) values(2,'Empresa',1)

		-- USUARIO
	DECLARE @userId int
	INSERT INTO VADIUM.USUARIO(usuario_username, usuario_password, usuario_activo, usuario_intentosLogin, primera_vez)
	VALUES('admin', HashBytes('SHA2_256','admin'), 1, 0,1)
	SELECT @userId =  SCOPE_IDENTITY()

	INSERT INTO VADIUM.ROL_POR_USUARIO(rol_id,usuario_id) VALUES(1,@userId)
	INSERT INTO VADIUM.ROL_POR_USUARIO(rol_id,usuario_id) VALUES(2,@userId)
	INSERT INTO VADIUM.ROL_POR_USUARIO(rol_id,usuario_id) VALUES(3,@userId)
	
	-- GRADO 
	INSERT INTO [VADIUM].GRADO(grado_id, comision,descripcion) values(0,5,'BAJO')
	INSERT INTO [VADIUM].GRADO(grado_id, comision,descripcion) values(1,10,'MEDIO')
	INSERT INTO [VADIUM].GRADO(grado_id, comision,descripcion) values(2,15,'ALTO')

	-- PREMIOS
	INSERT INTO [VADIUM].PREMIO (puntos, descripcion, stock, fechaVencimiento) VALUES (100, ' voucher entrada gratis', 10, convert(datetime,'18-06-19 10:34:09 PM',5))
	INSERT INTO [VADIUM].PREMIO (puntos, descripcion,stock, fechaVencimiento) VALUES (50, ' voucher 50% descuento en entradas', 10 ,convert(datetime,'31-12-18 10:34:09 PM',5))
END
GO

------------------------------MIGRACION------------------------------

CREATE PROCEDURE [VADIUM].PR_MIGRACION
AS
BEGIN
	------ TIPO UBICACION ------------
	INSERT INTO [VADIUM].TIPOUBICACION(codigoTipoUbicacion, descripcion)
	SELECT  m.Ubicacion_Tipo_Codigo , m.Ubicacion_Tipo_Descripcion
	FROM gd_esquema.Maestra m
	GROUP BY Ubicacion_Tipo_Codigo, Ubicacion_Tipo_Descripcion
	HAVING m.Ubicacion_Tipo_Codigo IS NOT NULL
	-------DIRECCIONES CLIENTE----
	INSERT INTO [VADIUM].DIRECCION(calle, nro_calle, piso, depto, cod_postal)
	SELECT  m.Cli_Dom_Calle, m.Cli_Nro_Calle, m.Cli_Piso, m.Cli_Depto, m.Cli_Cod_Postal
	FROM gd_esquema.Maestra m
	GROUP BY m.Cli_Dom_Calle, m.Cli_Nro_Calle, m.Cli_Piso, m.Cli_Depto, m.Cli_Cod_Postal	
	HAVING m.Cli_Dom_Calle IS NOT NULL
	-------Cliente------
	INSERT INTO [VADIUM].Cliente (numeroDocumento, tipoDocumento, apellido, nombre, fechaNacimiento, mail, direccion_id )
	SELECT  m.Cli_Dni,'DNI' ,m.Cli_Apeliido, m.Cli_Nombre, m.Cli_Fecha_Nac, m.Cli_Mail,
	(SELECT TOP 1 dir.direccion_id FROM DIRECCION dir 
						 WHERE dir.calle= m.Cli_Dom_Calle AND dir.nro_calle = m.Cli_Nro_Calle AND 
									dir.piso =m.Cli_Piso AND dir.depto=m.Cli_Depto AND dir.cod_postal = m.Cli_Cod_Postal)

	FROM gd_esquema.Maestra m
	GROUP BY m.Cli_Mail, m.Cli_Dni, m.Cli_Apeliido, m.Cli_Nombre, m.Cli_Fecha_Nac, m.Cli_Dom_Calle, m.Cli_Nro_Calle, m.Cli_Piso, m.Cli_Depto, m.Cli_Cod_Postal
	HAVING m.Cli_Mail IS NOT NULL
	-------DIRECCIONES EMPRESA----
	INSERT INTO [VADIUM].DIRECCION(calle, nro_calle, piso, depto, cod_postal)
	SELECT  m.Espec_Empresa_Dom_Calle, m.Espec_Empresa_Nro_Calle, m.Espec_Empresa_Piso, m.Espec_Empresa_Depto, m.Espec_Empresa_Cod_Postal
	FROM gd_esquema.Maestra m
	GROUP BY m.Espec_Empresa_Dom_Calle, m.Espec_Empresa_Nro_Calle, m.Espec_Empresa_Piso, m.Espec_Empresa_Depto, m.Espec_Empresa_Cod_Postal	
	HAVING m.Espec_Empresa_Dom_Calle IS NOT NULL
	-------EMPRESA------
	INSERT INTO [VADIUM].EMPRESA(razonSocial, cuit, mail, fechaCreacion, direccion_id )
	SELECT  m.Espec_Empresa_Razon_Social, m.Espec_Empresa_Cuit, m.Espec_Empresa_Mail, m.Espec_Empresa_Fecha_Creacion,
			(SELECT TOP 1 dir.direccion_id FROM DIRECCION dir 
						  WHERE dir.calle= m.Espec_Empresa_Dom_Calle AND dir.nro_calle = m.Espec_Empresa_Nro_Calle AND
						    dir.piso =m.Espec_Empresa_Piso AND dir.depto=m.Espec_Empresa_Depto AND 
							dir.cod_postal = m.Espec_Empresa_Cod_Postal)
	FROM gd_esquema.Maestra m
	GROUP BY m.Espec_Empresa_Razon_Social, m.Espec_Empresa_Cuit, m.Espec_Empresa_Mail, m.Espec_Empresa_Fecha_Creacion, m.Espec_Empresa_Dom_Calle, m.Espec_Empresa_Nro_Calle, m.Espec_Empresa_Piso, m.Espec_Empresa_Depto, m.Espec_Empresa_Cod_Postal	
	HAVING m.Espec_Empresa_Razon_Social IS NOT NULL

	------RUBRO--------
	INSERT INTO [VADIUM].RUBRO(descripcion)
	SELECT m.Espectaculo_Rubro_Descripcion
	FROM gd_esquema.Maestra m 
	GROUP BY m.Espectaculo_Rubro_Descripcion
	HAVING m.Espectaculo_Rubro_Descripcion IS NOT NULL
	------ESTADO--------
	INSERT INTO [VADIUM].ESTADO(descripcion)
	SELECT m.Espectaculo_Estado
	FROM gd_esquema.Maestra m 
	GROUP BY m.Espectaculo_Estado
	HAVING m.Espectaculo_Estado IS NOT NULL
	------PUBLICACION-----
		INSERT INTO [VADIUM].PUBLICACION(codigoEspectaculo, descripcion, fecha, fechaVencimiento, empresa_id, rubro_id, estado_id, grado_id)
		SELECT m.Espectaculo_Cod, m.Espectaculo_Descripcion, m.Espectaculo_Fecha, m.Espectaculo_Fecha_Venc, 
				(SELECT TOP 1 emp.empresa_id FROM EMPRESA emp WHERE emp.mail = m.Espec_Empresa_Mail), 
				(SELECT TOP 1 ru.rubro_id FROM RUBRO ru WHERE ru.descripcion = m.Espectaculo_Rubro_Descripcion),
				(SELECT TOP 1 es.codigo FROM ESTADO es WHERE es.descripcion = m.Espectaculo_Estado),
				 0
		FROM gd_esquema.Maestra m 
		GROUP BY m.Espectaculo_Cod, m.Espectaculo_Descripcion, m.Espectaculo_Fecha, m.Espectaculo_Fecha_Venc, m.Espec_Empresa_Mail, m.Espectaculo_Rubro_Descripcion, Espectaculo_Estado
	HAVING m.Espectaculo_Cod IS NOT NULL
 ----------- UBICACION--------
	INSERT INTO [VADIUM].UBICACION(fila, asiento, sinNumerar, precio, codigoTipoUbicacion, codigoEspectaculo)
		SELECT m.Ubicacion_Fila, m.Ubicacion_Asiento, m.Ubicacion_Sin_numerar, m.Ubicacion_Precio, 
				(SELECT TOP 1 tipou.codigoTipoUbicacion FROM TIPOUBICACION tipou WHERE tipou.codigoTipoUbicacion = m.Ubicacion_Tipo_Codigo),
				(SELECT TOP 1 publi.codigoEspectaculo FROM PUBLICACION publi WHERE publi.codigoEspectaculo = m.Espectaculo_Cod)
	
		FROM gd_esquema.Maestra m 
		GROUP BY m.Ubicacion_Fila, m.Ubicacion_Asiento, m.Ubicacion_Sin_numerar, m.Ubicacion_Precio, m.Ubicacion_Tipo_Codigo, m.Espectaculo_Cod
		HAVING m.Ubicacion_Fila IS NOT NULL
	---------FACTURA--------
	INSERT INTO [VADIUM].FACTURA(factura_nro, fecha, total, descripcion)
		SELECT m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, m.Forma_Pago_Desc
		FROM gd_esquema.Maestra m 
		GROUP BY m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, m.Forma_Pago_Desc
		HAVING m.Factura_Nro IS NOT NULL
		---------ITEMFACTURA--------
	INSERT INTO [VADIUM].ITEMFACTURA(monto, cantidad, descripcion, factura_nro,ubicacion_id, cliente_id)
		SELECT m.Item_Factura_Monto, m.Item_Factura_Cantidad, m.Item_Factura_Descripcion, 
		(SELECT TOP 1 fac.factura_nro FROM FACTURA fac WHERE fac.factura_nro = m.Factura_Nro),
		(SELECT TOP 1 ubi.ubicacion_id FROM UBICACION ubi 
			WHERE ubi.fila = m.Ubicacion_Fila AND ubi.asiento =m.Ubicacion_Asiento AND ubi.sinNumerar = m.Ubicacion_Sin_numerar AND
								 ubi.codigoTipoUbicacion = m.Ubicacion_Tipo_Codigo AND ubi.codigoEspectaculo = m.Espectaculo_Cod),
		(SELECT TOP 1 cli.cliente_id  FROM CLIENTE cli WHERE cli.mail = m.Cli_Mail)
		FROM gd_esquema.Maestra m 
		GROUP BY m.Item_Factura_Monto, m.Item_Factura_Cantidad, m.Item_Factura_Descripcion, m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, m.Forma_Pago_Desc, m.Ubicacion_Fila,m.Ubicacion_Asiento,m.Ubicacion_Sin_numerar,m.Ubicacion_Tipo_Codigo,m.Espectaculo_Cod, m.Cli_Mail
		HAVING m.Factura_Nro IS NOT NULL AND m.Cli_Mail IS NOT NULL
END
GO

--------------------------------FKS------------------------------

ALTER TABLE [VADIUM].ROL_POR_USUARIO ADD FOREIGN KEY (rol_id) REFERENCES [VADIUM].ROL
ALTER TABLE [VADIUM].ROL_POR_USUARIO ADD FOREIGN KEY (usuario_id) REFERENCES [VADIUM].USUARIO
ALTER TABLE [VADIUM].ROL_POR_FUNCIONALIDAD ADD FOREIGN KEY (rol_id) REFERENCES [VADIUM].ROL
ALTER TABLE [VADIUM].ROL_POR_FUNCIONALIDAD ADD FOREIGN KEY (funcionalidad_id) REFERENCES [VADIUM].FUNCIONALIDAD
ALTER TABLE [VADIUM].CLIENTE ADD FOREIGN KEY (usuario_id) REFERENCES [VADIUM].USUARIO
ALTER TABLE [VADIUM].CLIENTE ADD FOREIGN KEY (direccion_id) REFERENCES [VADIUM].DIRECCION
ALTER TABLE [VADIUM].TARJETADECREDITO ADD FOREIGN KEY (cliente_id) REFERENCES [VADIUM].CLIENTE
ALTER TABLE [VADIUM].EMPRESA ADD FOREIGN KEY (usuario_id) REFERENCES [VADIUM].USUARIO
ALTER TABLE [VADIUM].EMPRESA ADD FOREIGN KEY (direccion_id) REFERENCES [VADIUM].DIRECCION

ALTER TABLE [VADIUM].PUBLICACION ADD FOREIGN KEY (estado_id) REFERENCES [VADIUM].ESTADO
ALTER TABLE [VADIUM].PUBLICACION ADD FOREIGN KEY (rubro_id) REFERENCES [VADIUM].RUBRO
ALTER TABLE [VADIUM].PUBLICACION ADD FOREIGN KEY (grado_id) REFERENCES [VADIUM].GRADO
ALTER TABLE [VADIUM].PUBLICACION ADD FOREIGN KEY (empresa_id) REFERENCES [VADIUM].EMPRESA

ALTER TABLE [VADIUM].UBICACION ADD FOREIGN KEY (codigoTipoUbicacion) REFERENCES [VADIUM].TIPOUBICACION
ALTER TABLE [VADIUM].UBICACION ADD FOREIGN KEY (codigoEspectaculo) REFERENCES [VADIUM].PUBLICACION

ALTER TABLE [VADIUM].ITEMFACTURA ADD FOREIGN KEY (factura_nro) REFERENCES [VADIUM].FACTURA
ALTER TABLE [VADIUM].ITEMFACTURA ADD FOREIGN KEY (cliente_id) REFERENCES [VADIUM].CLIENTE
ALTER TABLE [VADIUM].ITEMFACTURA ADD FOREIGN KEY (ubicacion_id) REFERENCES [VADIUM].UBICACION

ALTER TABLE [VADIUM].PREMIO_POR_CLIENTE ADD FOREIGN KEY (cliente_id) REFERENCES [VADIUM].CLIENTE
ALTER TABLE [VADIUM].PREMIO_POR_CLIENTE ADD FOREIGN KEY (premioId) REFERENCES [VADIUM].PREMIO
GO


------------------------------Estadisticas------------------------------
CREATE PROCEDURE [VADIUM].MayorCantLocalidadesNoVendidos @year int, @month int, @grado int

AS
BEGIN
SELECT TOP 5 emp.razonSocial , COUNT(*) as cantidad
FROM VADIUM.EMPRESA emp JOIN VADIUM.PUBLICACION pub ON(emp.empresa_id = pub.empresa_id )
						JOIN VADIUM.UBICACION ubi ON (pub.codigoEspectaculo = ubi.codigoEspectaculo)

	WHERE ubicacion_id NOT IN (SELECT ubicacion_id FROM VADIUM.ITEMFACTURA item) AND
			 (@year is null or year(pub.fecha) =  @year) AND
			 (@month is null or (month(pub.fecha) > @month AND month(pub.fecha) < (@month + 2) )) AND
			 (@grado is null or pub.grado_id = @grado)
	GROUP BY emp.empresa_id, emp.razonSocial
	ORDER BY COUNT(*) DESC

END
GO


CREATE PROCEDURE [VADIUM].ClientesPuntosVencidos @year int, @month int

AS
BEGIN
SELECT TOP 5 cli.mail , SUM(item.monto) as cantidad
FROM VADIUM.CLIENTE cli  JOIN VADIUM.ITEMFACTURA item on (cli.cliente_id = item.cliente_id)
						JOIN VADIUM.FACTURA fact on (item.factura_nro = fact.factura_nro)
	WHERE    (@year is null or year(fact.fecha) =  @year -1) AND
			 (@month is null or (month(fact.fecha) > @month AND month(fact.fecha) < (@month + 2) )) 
			 
	GROUP BY cli.cliente_id, cli.mail
	ORDER BY SUM(item.monto) DESC

END
GO

CREATE PROCEDURE [VADIUM].ClientesMayorCompras @year int, @month int

AS
BEGIN
SELECT TOP 5 cli.mail, COUNT(DISTINCT pub.empresa_id)
FROM VADIUM.CLIENTE cli  JOIN VADIUM.ITEMFACTURA item on (cli.cliente_id = item.cliente_id)
					     JOIN VADIUM.FACTURA fact on (item.factura_nro = fact.factura_nro)
						 JOIN VADIUM.UBICACION ubi on (item.ubicacion_id = ubi.ubicacion_id)
						 JOIN VADIUM.PUBLICACION pub on (ubi.codigoEspectaculo = pub.codigoEspectaculo)

	WHERE    (@year is null or year(fact.fecha) =  @year) AND
			 (@month is null or (month(fact.fecha) > @month AND month(fact.fecha) < (@month + 2) )) 
			 
	GROUP BY cli.mail
	ORDER BY COUNT(DISTINCT pub.empresa_id) DESC

END
GO


------------------- Canje de puntos ----------------------------------

CREATE PROCEDURE [VADIUM].puntajeCliente  @cliente int, @fechaActual datetime

AS
BEGIN


SELECT sum(item.monto) as puntos
FROM VADIUM.ITEMFACTURA item JOIN VADIUM.FACTURA fact ON (item.factura_nro = fact.factura_nro)
	WHERE dateadd(yy,1, fact.fecha) > @fechaActual AND item.cliente_id = @cliente
group by item.cliente_id
END
GO

CREATE PROCEDURE [VADIUM].CanjearPremio  @id_Cliente int, @premioId int ,  @fechaActual datetime

AS
BEGIN

DECLARE @puntos int

SELECT TOP 1 @puntos = puntos from VADIUM.PREMIO pr WHERE pr.premioId = @premioId

INSERT INTO VADIUM.PREMIO_POR_CLIENTE(cliente_id, fecha, premioId,puntos) VALUES (@id_Cliente,@premioId, @fechaActual, @puntos )



END
GO

---------------GRADO DE PUBLICACION-----------------------------------
CREATE PROCEDURE [VADIUM].InsertGrado  @comision numeric(18,0), @descripcion nvarchar(255)
AS
BEGIN

	if (SELECT COUNT(*) FROM VADIUM.GRADO gr WHERE gr.descripcion = @descripcion) = 0
		BEGIN
			INSERT INTO GRADO (comision, descripcion) VALUES (@comision, @descripcion)
		END
	ELSE 
		BEGIN
			RAISERROR('El grado ya existe',1,1);
		END

END 
GO
CREATE PROCEDURE [VADIUM].UpdateGrado  @gradoId int, @comision numeric(18,0), @descripcion nvarchar(255)
AS
BEGIN TRY
			UPDATE  VADIUM.GRADO   SET comision = @comision,  descripcion = @descripcion WHERE grado_id = @gradoId

END TRY
  BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO 

CREATE PROCEDURE [VADIUM].removeGrado  @gradoId int
AS
BEGIN TRY 
			DELETE FROM  VADIUM.GRADO WHERE grado_id = @gradoId

END TRY
  BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO


--------ejecutar datos iniciales y migracion---------------------------
EXECUTE VADIUM.PR_DATOS_INSERT_DATOS_INICIALES;
EXECUTE VADIUM.PR_MIGRACION;