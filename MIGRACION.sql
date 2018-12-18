USE GD2C2018
GO

-------------------------------DROP PROCEDURES-------------------
IF OBJECT_ID('VADIUM.QUITAR_FUNCIONALIDAD') IS NOT NULL
DROP PROCEDURE VADIUM.QUITAR_FUNCIONALIDAD;
GO
IF OBJECT_ID('VADIUM.AGREGAR_ROL') IS NOT NULL
DROP PROCEDURE VADIUM.AGREGAR_ROL;
GO
IF OBJECT_ID('VADIUM.AGREGAR_ROL_NUEVO') IS NOT NULL
DROP PROCEDURE VADIUM.AGREGAR_ROL_NUEVO;
GO
IF OBJECT_ID('VADIUM.AGREGAR_ROL_USUARIO') IS NOT NULL
DROP PROCEDURE VADIUM.AGREGAR_ROL_USUARIO;
GO
IF OBJECT_ID('VADIUM.COMPRAR') IS NOT NULL
DROP PROCEDURE VADIUM.COMPRAR;
GO

IF OBJECT_ID('VADIUM.AGREGAR_FUNCIONALIDAD') IS NOT NULL
DROP PROCEDURE VADIUM.AGREGAR_FUNCIONALIDAD;
GO
IF OBJECT_ID('VADIUM.UBICACIONES_NO_VENDIDAS') IS NOT NULL
DROP PROCEDURE VADIUM.UBICACIONES_NO_VENDIDAS;
GO
IF OBJECT_ID('VADIUM.VERIFICAR_USUARIO_PASSWORD') IS NOT NULL
DROP PROCEDURE VADIUM.VERIFICAR_USUARIO_PASSWORD;
GO
IF OBJECT_ID('VADIUM.USUARIO_LOGUEADO') IS NOT NULL
DROP PROCEDURE VADIUM.USUARIO_LOGUEADO;
GO
IF OBJECT_ID('VADIUM.BLOQUEAR') IS NOT NULL
DROP PROCEDURE VADIUM.BLOQUEAR;
GO
IF OBJECT_ID('VADIUM.CAMBIAR_PASSWORD') IS NOT NULL
DROP PROCEDURE VADIUM.CAMBIAR_PASSWORD;
GO
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
IF OBJECT_ID('VADIUM.ObtenerPublicaciones') IS NOT NULL
DROP PROCEDURE VADIUM.ObtenerPublicaciones;
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
IF OBJECT_ID('VADIUM.HistorialCliente') IS NOT NULL
DROP PROCEDURE VADIUM.HistorialCliente;
GO
IF OBJECT_ID('VADIUM.LISTADO_SELECCION_EMPRESA') IS NOT NULL
DROP PROCEDURE VADIUM.LISTADO_SELECCION_EMPRESA;
GO
IF OBJECT_ID('VADIUM.LISTADO_SELECCION_CLIENTE') IS NOT NULL
DROP PROCEDURE VADIUM.LISTADO_SELECCION_CLIENTE;
GO
IF OBJECT_ID('VADIUM.PR_DATOS_INSERT_DATOS_INICIALES') IS NOT NULL
DROP PROCEDURE VADIUM.PR_DATOS_INSERT_DATOS_INICIALES;
GO
IF OBJECT_ID('VADIUM.PR_MIGRACION') IS NOT NULL
DROP PROCEDURE VADIUM.PR_MIGRACION;
GO
IF OBJECT_ID('VADIUM.OBTENER_CLIENTE') IS NOT NULL
DROP PROCEDURE VADIUM.OBTENER_CLIENTE;
GO
------------------------------DROP TRIGGERS ---------------------------------

IF OBJECT_ID('VADIUM.TR_NuevaUbicacion') IS NOT NULL
DROP TRIGGER VADIUM.TR_NuevaUbicacion
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
IF OBJECT_ID('VADIUM.COMPRA') IS NOT NULL
DROP TABLE VADIUM.COMPRA
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
	rol_id int PRIMARY KEY IDENTITY(0,1),
	rol_habilitado bit DEFAULT 1, 
	rol_nombre nvarchar(255) UNIQUE NOT NULL
)
GO

CREATE TABLE [VADIUM].USUARIO(
	usuario_id int PRIMARY KEY IDENTITY(1,1),
	usuario_username nvarchar(255) NOT NULL UNIQUE,
	usuario_password nvarchar(255) NOT NULL,
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

CREATE TABLE [VADIUM].CLIENTE(
	cliente_id int PRIMARY KEY IDENTITY(1,1),
	usuario_id int,
	nombre nvarchar(255),
	apellido nvarchar(255),
	tipoDocumento nvarchar(50),
	numeroDocumento nvarchar(50),
	CUIL nvarchar(20),
	fechaNacimiento datetime,
	fechaCreacion datetime,
	tarjetaCredito nvarchar (255),
	mail nvarchar(255),
	telefono nvarchar(255),
	calle NVARCHAR(255),
	piso NUMERIC(18,0),
	depto NVARCHAR (255),
	cod_postal nvarchar(255),
	localidad nvarchar(255),

) 
GO
CREATE TABLE [VADIUM].TARJETADECREDITO(
	tarjeta_id int PRIMARY KEY IDENTITY(0,1),
	nroTarjeta nvarchar (255),
	banco nvarchar(127),
	codSeguridad nvarchar(3),
	tipo nvarchar(255),
	cliente_id int,
	mesVencimiento nvarchar(10),
	anioVencimiento nvarchar(10),
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
	calle NVARCHAR(255),
	piso NUMERIC(18,0),
	depto NVARCHAR (255),
	cod_postal nvarchar(255),
	localidad nvarchar(255),
	ciudad nvarchar(255)
)
GO
CREATE TABLE [VADIUM].RUBRO(
	rubro_id int PRIMARY KEY IDENTITY(1,1),
	descripcion nvarchar(255),
)
GO
CREATE TABLE [VADIUM].GRADO( 
	grado_id int PRIMARY KEY IDENTITY(1,1),
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
	empresa_id int,
	stock int
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
	codigoEspectaculo numeric(18,0),
	compra_id int,
	
)
GO
CREATE TABLE [VADIUM].COMPRA(
	compra_id int PRIMARY KEY IDENTITY(1,1),
	fecha_compra datetime,
	id_cliente_comprador int,
	cantidad int,
	monto numeric(18,0),
	medio_de_pago nvarchar(30),
)
GO
CREATE TABLE [VADIUM].FACTURA(
	empresa_id int,
	factura_nro int PRIMARY KEY,
	fecha datetime,
	total numeric(18,2),	
)
GO
CREATE TABLE [VADIUM].ITEMFACTURA(
	factura_nro int,
	ubicacion_id int,
	monto numeric(18,2),
	cantidad numeric(18,2),
	descripcion nvarchar(60),
	compra_id int
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
--CREATE TRIGGER [VADIUM].TR_NuevaEmpresa
--ON VADIUM.EMPRESA
--INSTEAD OF INSERT
--AS
--BEGIN
--	BEGIN TRY
--		INSERT INTO VADIUM.USUARIO(usuario_username, usuario_password, usuario_activo, usuario_intentosLogin, primera_vez)
--		SELECT I.mail,  HashBytes('SHA2_256',I.cuit), 1,0, 1
--		FROM inserted I
--		WHERE I.mail NOT IN(SELECT us2.usuario_username FROM VADIUM.USUARIO us2 )

--		INSERT INTO VADIUM.ROL_POR_USUARIO(rol_id,usuario_id)
--		SELECT 2, us.usuario_id
--		FROM inserted I JOIN USUARIO us ON (us.usuario_username = I.mail)
--		WHERE NOT EXISTS(SELECT 2 FROM VADIUM.ROL_POR_USUARIO rolUser WHERE rolUser.rol_id = 1 AND rolUser.usuario_id = us.usuario_id)


--		INSERT INTO VADIUM.EMPRESA(razonSocial, cuit, mail,  fechaCreacion, usuario_id, calle, piso, depto, cod_postal)
--		SELECT ins.razonSocial, ins.cuit, ins.mail, ins.fechaCreacion, 
--			(SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_username = ins.mail), ins.calle, ins.piso, ins.depto, ins.cod_postal
--		FROM inserted ins
--	END TRY
--	BEGIN CATCH
--	  SELECT 'ERROR', ERROR_MESSAGE()
--	END CATCH
--END
--GO
   -----CLIENTE--------
CREATE TRIGGER [VADIUM].TR_NuevaUbicacion
ON VADIUM.UBICACION
AFTER INSERT, update
AS
BEGIN
	BEGIN TRY	
		
		DECLARE @stock int
		DECLARE  @codEspec int

		DECLARE stockEspectaculo CURSOR FOR
		SELECT COUNT(*), codigoEspectaculo
		FROM UBICACION ubi
		WHERE ubi.compra_id IS NULL  AND EXISTS ( SELECT i.codigoEspectaculo FROM inserted i WHERE i.codigoEspectaculo = ubi.codigoEspectaculo)
		group by ubi.codigoEspectaculo
		

		OPEN stockEspectaculo
		FETCH NEXT FROM stockEspectaculo INTO @stock, @codEspec

		WHILE @@FETCH_STATUS = 0
		BEGIN 
				--DECLARE @stockActual INT
				--SELECT @stockActual = p.stock FROM PUBLICACION p WHERE p.codigoEspectaculo = @codEspec
				--SET @stockActual = @stockActual + @stock
				
				--print @stockActual

				UPDATE PUBLICACION SET stock += @stock WHERE codigoEspectaculo =@codEspec


				FETCH NEXT FROM stockEspectaculo INTO @stock, @codEspec
		END
		CLOSE stockEspectaculo  
		DEALLOCATE stockEspectaculo 

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


	-- ROL 
	INSERT INTO [VADIUM].ROL (rol_nombre,rol_habilitado) values('Administrador',1)
	INSERT INTO [VADIUM].ROL (rol_nombre,rol_habilitado) values('Cliente',1)
	INSERT INTO [VADIUM].ROL (rol_nombre,rol_habilitado) values('Empresa',1)


	/* FUNCIONALIDADES */

	INSERT INTO [VADIUM].FUNCIONALIDAD (funcionalidad_descripcion) VALUES ('AdministrarClientes');
	INSERT INTO [VADIUM].FUNCIONALIDAD (funcionalidad_descripcion) VALUES ('AdministrarEmpresas');
	INSERT INTO [VADIUM].FUNCIONALIDAD (funcionalidad_descripcion) VALUES ('AdministrarGrados');
	INSERT INTO [VADIUM].FUNCIONALIDAD (funcionalidad_descripcion) VALUES ('AdministrarRoles');
	INSERT INTO [VADIUM].FUNCIONALIDAD (funcionalidad_descripcion) VALUES ('AdministrarRubros');
	INSERT INTO [VADIUM].FUNCIONALIDAD (funcionalidad_descripcion) VALUES ('AdministrarPuntos');
	INSERT INTO [VADIUM].FUNCIONALIDAD (funcionalidad_descripcion) VALUES ('AdministrarCompras');
	INSERT INTO [VADIUM].FUNCIONALIDAD (funcionalidad_descripcion) VALUES ('EditarPublicacion');
	INSERT INTO [VADIUM].FUNCIONALIDAD (funcionalidad_descripcion) VALUES ('GenerarPublicacion');
	INSERT INTO [VADIUM].FUNCIONALIDAD (funcionalidad_descripcion) VALUES ('RendicionesPorComision');
	INSERT INTO [VADIUM].FUNCIONALIDAD (funcionalidad_descripcion) VALUES ('HistorialClientes');
	INSERT INTO [VADIUM].FUNCIONALIDAD (funcionalidad_descripcion) VALUES ('ListadoEstadistico');
	INSERT INTO [VADIUM].FUNCIONALIDAD (funcionalidad_descripcion) VALUES ('TarjetaDeCredito');

	SET IDENTITY_INSERT VADIUM.USUARIO ON
	INSERT INTO VADIUM.USUARIO(usuario_id,usuario_username,usuario_password,usuario_intentosLogin,usuario_activo,primera_vez) 
	VALUES (0,'admin','8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918',0,1,0); --pass admin en SHA256
	SET IDENTITY_INSERT VADIUM.USUARIO OFF

	--RUBRO
	INSERT INTO [VADIUM].RUBRO(descripcion) values('Ciencia ficcion')
	INSERT INTO [VADIUM].RUBRO(descripcion) values('Comedia')
	INSERT INTO [VADIUM].RUBRO(descripcion) values('Drama')
	-- GRADO 
	INSERT INTO [VADIUM].GRADO(comision,descripcion) values(5,'BAJO')
	INSERT INTO [VADIUM].GRADO(comision,descripcion) values(10,'MEDIO')
	INSERT INTO [VADIUM].GRADO(comision,descripcion) values(15,'ALTO')

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

	-------Cliente------
	INSERT INTO [VADIUM].Cliente (numeroDocumento, tipoDocumento, apellido, nombre, fechaNacimiento, mail, calle, piso, depto, cod_postal )
	SELECT  m.Cli_Dni,'DNI' ,m.Cli_Apeliido, m.Cli_Nombre, m.Cli_Fecha_Nac, m.Cli_Mail,m.Cli_Dom_Calle, m.Cli_Piso, m.Cli_Depto, m.Cli_Cod_Postal

	FROM gd_esquema.Maestra m
	GROUP BY m.Cli_Mail, m.Cli_Dni, m.Cli_Apeliido, m.Cli_Nombre, m.Cli_Fecha_Nac, m.Cli_Dom_Calle, m.Cli_Piso, m.Cli_Depto, m.Cli_Cod_Postal
	HAVING m.Cli_Mail IS NOT NULL

	-------EMPRESA------
	INSERT INTO [VADIUM].EMPRESA(razonSocial, cuit, mail, fechaCreacion, calle, piso, depto, cod_postal )
	SELECT  m.Espec_Empresa_Razon_Social, m.Espec_Empresa_Cuit, m.Espec_Empresa_Mail, m.Espec_Empresa_Fecha_Creacion,
				m.Espec_Empresa_Dom_Calle, m.Espec_Empresa_Piso, m.Espec_Empresa_Depto, m.Espec_Empresa_Cod_Postal
	FROM gd_esquema.Maestra m
	GROUP BY m.Espec_Empresa_Razon_Social, m.Espec_Empresa_Cuit, m.Espec_Empresa_Mail, m.Espec_Empresa_Fecha_Creacion, m.Espec_Empresa_Dom_Calle, m.Espec_Empresa_Piso, m.Espec_Empresa_Depto, m.Espec_Empresa_Cod_Postal	
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
		INSERT INTO [VADIUM].PUBLICACION(codigoEspectaculo, descripcion, fecha, fechaVencimiento, empresa_id, rubro_id, estado_id, grado_id, stock)
		SELECT m.Espectaculo_Cod, m.Espectaculo_Descripcion, m.Espectaculo_Fecha, m.Espectaculo_Fecha_Venc, 
				(SELECT TOP 1 emp.empresa_id FROM EMPRESA emp WHERE emp.mail = m.Espec_Empresa_Mail), 
				(SELECT TOP 1 ru.rubro_id FROM RUBRO ru order by NEWID()),
				(SELECT TOP 1 es.codigo FROM ESTADO es WHERE es.descripcion = m.Espectaculo_Estado),
				(SELECT TOP 1 gr.grado_id FROM VADIUM.GRADO gr order by newid()), 0
		FROM gd_esquema.Maestra m 
		GROUP BY m.Espectaculo_Cod, m.Espectaculo_Descripcion, m.Espectaculo_Fecha, m.Espectaculo_Fecha_Venc, m.Espec_Empresa_Mail, m.Espectaculo_Rubro_Descripcion, Espectaculo_Estado
	HAVING m.Espectaculo_Cod IS NOT NULL
		------COMPRA-----
		INSERT INTO [VADIUM].COMPRA(fecha_compra, id_cliente_comprador, medio_de_pago,cantidad, monto )
		SELECT 
				m.Compra_Fecha, 
				(SELECT TOP 1 cli.cliente_id FROM CLIENTE cli WHERE cli.mail = m.Cli_Mail), 
				m.Forma_Pago_Desc, sum(m.Compra_Cantidad), SUM(m.Ubicacion_Precio)
				
		FROM gd_esquema.Maestra m 
		GROUP BY m.Compra_Fecha, m.Cli_Mail, m.Forma_Pago_Desc, m.Espectaculo_Cod
		HAVING m.Compra_Fecha IS NOT NULL AND m.Forma_Pago_Desc IS NOT NULL
 ----------- UBICACION--------
	INSERT INTO [VADIUM].UBICACION(fila, asiento, sinNumerar, precio, codigoTipoUbicacion, codigoEspectaculo, compra_id)
		SELECT m.Ubicacion_Fila, m.Ubicacion_Asiento, m.Ubicacion_Sin_numerar, m.Ubicacion_Precio, 
				(SELECT TOP 1 tipou.codigoTipoUbicacion FROM TIPOUBICACION tipou WHERE tipou.codigoTipoUbicacion = m.Ubicacion_Tipo_Codigo),
				(SELECT TOP 1 publi.codigoEspectaculo FROM PUBLICACION publi WHERE publi.codigoEspectaculo = m.Espectaculo_Cod),
			    (SELECT TOP 1 com.compra_id FROM COMPRA com WHERE com.fecha_compra = m.Compra_Fecha AND 
						com.id_cliente_comprador = (SELECT TOP 1 cli.cliente_id FROM VADIUM.CLIENTE cli WHERE cli.mail = m.Cli_Mail ) )
				--TODO, como hacemos para migra el id de las compras? pensemos que siempre que hay una factura asociada a una ubicaicon
				--en la tabla maestra es xq hubo una compra

		FROM gd_esquema.Maestra m 
		GROUP BY m.Ubicacion_Fila, m.Ubicacion_Asiento, m.Ubicacion_Sin_numerar, m.Ubicacion_Precio, m.Ubicacion_Tipo_Codigo, m.Espectaculo_Cod, m.Compra_Fecha, m.Cli_Mail
		HAVING m.Ubicacion_Fila IS NOT NULL
		
	---------FACTURA--------
	INSERT INTO [VADIUM].FACTURA(factura_nro, fecha, total, empresa_id)
		SELECT m.Factura_Nro, m.Factura_Fecha, m.Factura_Total,
		(SELECT TOP 1 emp.empresa_id FROM EMPRESA emp WHERE emp.mail = m.Espec_Empresa_Mail)
		FROM gd_esquema.Maestra m 
		GROUP BY m.Factura_Nro, m.Factura_Fecha, m.Factura_Total,Espec_Empresa_Mail
		HAVING m.Factura_Nro IS NOT NULL
		---------ITEMFACTURA--------
	INSERT INTO [VADIUM].ITEMFACTURA(monto, cantidad, descripcion, factura_nro,ubicacion_id)
		SELECT m.Item_Factura_Monto, m.Item_Factura_Cantidad, m.Item_Factura_Descripcion, 
		(SELECT TOP 1 fac.factura_nro FROM FACTURA fac WHERE fac.factura_nro = m.Factura_Nro),
		(SELECT TOP 1 ubi.ubicacion_id FROM UBICACION ubi 
			WHERE ubi.fila = m.Ubicacion_Fila AND ubi.asiento =m.Ubicacion_Asiento AND ubi.sinNumerar = m.Ubicacion_Sin_numerar AND
								 ubi.codigoTipoUbicacion = m.Ubicacion_Tipo_Codigo AND ubi.codigoEspectaculo = m.Espectaculo_Cod)
		
		FROM gd_esquema.Maestra m 
		GROUP BY m.Item_Factura_Monto, m.Item_Factura_Cantidad, m.Item_Factura_Descripcion, m.Factura_Nro, m.Factura_Fecha, m.Factura_Total,
		 m.Forma_Pago_Desc, m.Ubicacion_Fila,m.Ubicacion_Asiento,m.Ubicacion_Sin_numerar,m.Ubicacion_Tipo_Codigo,m.Espectaculo_Cod, m.Cli_Mail, m.Forma_Pago_Desc
		HAVING m.Factura_Nro IS NOT NULL AND m.Cli_Mail IS NOT NULL

		
END
GO

--------------------------------FKS------------------------------

ALTER TABLE [VADIUM].ROL_POR_USUARIO ADD FOREIGN KEY (rol_id) REFERENCES [VADIUM].ROL
ALTER TABLE [VADIUM].ROL_POR_USUARIO ADD FOREIGN KEY (usuario_id) REFERENCES [VADIUM].USUARIO
ALTER TABLE [VADIUM].ROL_POR_FUNCIONALIDAD ADD FOREIGN KEY (rol_id) REFERENCES [VADIUM].ROL
ALTER TABLE [VADIUM].ROL_POR_FUNCIONALIDAD ADD FOREIGN KEY (funcionalidad_id) REFERENCES [VADIUM].FUNCIONALIDAD
ALTER TABLE [VADIUM].CLIENTE ADD FOREIGN KEY (usuario_id) REFERENCES [VADIUM].USUARIO
ALTER TABLE [VADIUM].TARJETADECREDITO ADD FOREIGN KEY (cliente_id) REFERENCES [VADIUM].CLIENTE
ALTER TABLE [VADIUM].EMPRESA ADD FOREIGN KEY (usuario_id) REFERENCES [VADIUM].USUARIO

ALTER TABLE [VADIUM].PUBLICACION ADD FOREIGN KEY (estado_id) REFERENCES [VADIUM].ESTADO
ALTER TABLE [VADIUM].PUBLICACION ADD FOREIGN KEY (rubro_id) REFERENCES [VADIUM].RUBRO
ALTER TABLE [VADIUM].PUBLICACION ADD FOREIGN KEY (grado_id) REFERENCES [VADIUM].GRADO
ALTER TABLE [VADIUM].PUBLICACION ADD FOREIGN KEY (empresa_id) REFERENCES [VADIUM].EMPRESA

ALTER TABLE [VADIUM].UBICACION ADD FOREIGN KEY (codigoTipoUbicacion) REFERENCES [VADIUM].TIPOUBICACION
ALTER TABLE [VADIUM].UBICACION ADD FOREIGN KEY (codigoEspectaculo) REFERENCES [VADIUM].PUBLICACION
ALTER TABLE [VADIUM].UBICACION ADD FOREIGN KEY (compra_id) REFERENCES [VADIUM].COMPRA

ALTER TABLE [VADIUM].ITEMFACTURA ADD FOREIGN KEY (factura_nro) REFERENCES [VADIUM].FACTURA
ALTER TABLE [VADIUM].ITEMFACTURA ADD FOREIGN KEY (ubicacion_id) REFERENCES [VADIUM].UBICACION

ALTER TABLE [VADIUM].PREMIO_POR_CLIENTE ADD FOREIGN KEY (cliente_id) REFERENCES [VADIUM].CLIENTE
ALTER TABLE [VADIUM].PREMIO_POR_CLIENTE ADD FOREIGN KEY (premioId) REFERENCES [VADIUM].PREMIO

ALTER TABLE [VADIUM].COMPRA ADD FOREIGN KEY (id_cliente_comprador) REFERENCES [VADIUM].CLIENTE

ALTER TABLE [VADIUM].FACTURA ADD FOREIGN KEY (empresa_id) REFERENCES [VADIUM].EMPRESA
GO


--------------------------------Estadisticas------------------------------
CREATE PROCEDURE [VADIUM].MayorCantLocalidadesNoVendidos @year int, @month int, @grado int

AS
BEGIN
SELECT TOP 5 emp.razonSocial , COUNT(*) as cantidad
FROM VADIUM.EMPRESA emp JOIN VADIUM.PUBLICACION pub ON(emp.empresa_id = pub.empresa_id )
						JOIN VADIUM.UBICACION ubi ON (pub.codigoEspectaculo = ubi.codigoEspectaculo)
		WHERE ubi.compra_id IS NULL AND
			 (@year is null or year(pub.fecha) =  @year) AND
			 (@month is null or (month(pub.fecha) > @month AND month(pub.fecha) < (@month + 2) )) AND
			 (@grado is null or pub.grado_id = @grado)
	GROUP BY emp.empresa_id, emp.razonSocial
	ORDER BY COUNT(*) DESC

END
GO


--CREATE PROCEDURE [VADIUM].ClientesPuntosVencidos @year int, @month int

--AS
--BEGIN
--SELECT TOP 5 cli.mail , SUM(item.monto) as cantidad
--FROM VADIUM.CLIENTE cli  JOIN VADIUM.COMPRA item on (cli.cliente_id = item.cliente_id)
--						JOIN VADIUM.FACTURA fact on (item.factura_nro = fact.factura_nro)
--	WHERE    (@year is null or year(fact.fecha) =  @year -1) AND
--			 (@month is null or (month(fact.fecha) > @month AND month(fact.fecha) < (@month + 2) )) 
			 
--	GROUP BY cli.cliente_id, cli.mail
--	ORDER BY SUM(item.monto) DESC

--END
--GO

CREATE PROCEDURE [VADIUM].ClientesMayorCompras @year int, @month int

AS
BEGIN
SELECT TOP 5 cli.mail, COUNT(DISTINCT pub.empresa_id)
FROM VADIUM.CLIENTE cli  JOIN VADIUM.COMPRA com on (cli.cliente_id = com.id_cliente_comprador)
						 JOIN VADIUM.UBICACION ubi on (com.compra_id = ubi.compra_id)
						 JOIN VADIUM.PUBLICACION pub on (ubi.codigoEspectaculo = pub.codigoEspectaculo)

	WHERE    (@year is null or year(com.fecha_compra) =  @year) AND
			 (@month is null or (month(com.fecha_compra) > @month AND month(com.fecha_compra) < (@month + 2) )) 
			 
	GROUP BY cli.mail
	ORDER BY COUNT(DISTINCT pub.empresa_id) DESC

END
GO
--------------------------ROLES-----------------------------------

---------------------------LOGIN------------------------------------
CREATE	 PROCEDURE [VADIUM].VERIFICAR_USUARIO_PASSWORD @user nvarchar(255),@pass NVARCHAR(255)
AS
BEGIN TRY
		IF (EXISTS(SELECT 1 FROM USUARIO WHERE usuario_username = @user ))
	BEGIN
		UPDATE USUARIO SET usuario_intentosLogin = usuario_intentosLogin + 1WHERE usuario_username = @user;

		SELECT	U.usuario_password Password, 
				U.usuario_username Username, 
				U.usuario_activo Activo, 
				U.usuario_id Id, 
				U.usuario_intentosLogin Intentos, 
				U.primera_vez primeraVez, 
				 
				(CASE WHEN U.usuario_password = HashBytes('SHA2_256', @pass) THEN 1 ELSE 0 END) PasswordMatched
		FROM [VADIUM].USUARIO U WHERE usuario_username = @user;
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
CREATE PROCEDURE [VADIUM].USUARIO_LOGUEADO @user NVARCHAR(255)
AS
BEGIN TRY
	IF (EXISTS(SELECT 1 FROM USUARIO WHERE usuario_username = @user))
	BEGIN
		UPDATE USUARIO SET usuario_intentosLogin = 0, usuario_activo = 1, primera_vez = 0 WHERE usuario_username = @user;
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [VADIUM].CAMBIAR_PASSWORD @user NVARCHAR(255), @pass NVARCHAR(255)
AS
BEGIN TRY
	IF (EXISTS(SELECT 1 FROM USUARIO WHERE usuario_username = @user))
	BEGIN
		UPDATE USUARIO SET usuario_password = HashBytes('SHA2_256',@pass) WHERE usuario_username = @user;
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
CREATE PROCEDURE [VADIUM].BLOQUEAR @user NVARCHAR(255)
AS
BEGIN TRY
	IF (EXISTS(SELECT 1 FROM USUARIO WHERE usuario_username = @user))
	BEGIN
		UPDATE USUARIO SET usuario_intentosLogin = 0, usuario_activo = 0 WHERE usuario_username = @user;
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
---------------------------CLIENTE -----------------------------------

CREATE	 PROCEDURE [VADIUM].LISTADO_SELECCION_CLIENTE @NOMBRE NVARCHAR(255),@APELLIDO NVARCHAR(255),@DNI NVARCHAR(50), @mail nvarchar(255)
AS
BEGIN TRY
	SELECT *
	FROM [VADIUM].CLIENTE cli 
	WHERE
	(@NOMBRE = '' OR @NOMBRE is null OR  lower(cli.nombre) LIKE '%' + lower(@NOMBRE) + '%') AND
	(@APELLIDO = '' OR @APELLIDO is null OR lower(cli.apellido) LIKE '%' + lower(@APELLIDO) + '%') AND
	(@DNI = '' OR @DNI is null OR lower(cli.numeroDocumento) LIKE '%' + lower(@DNI) + '%') AND
	(@mail = '' OR @mail is null OR lower(cli.mail) LIKE '%' + lower(@mail) + '%');
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
CREATE	 PROCEDURE [VADIUM].OBTENER_CLIENTE @NOMBRE NVARCHAR(255),@APELLIDO NVARCHAR(255),@DNI NVARCHAR(50), @mail nvarchar(255)
AS
BEGIN TRY
	SELECT *
	FROM [VADIUM].CLIENTE cli 
	WHERE
	(@NOMBRE = '' OR @NOMBRE is null OR  lower(cli.nombre) LIKE '%' + lower(@NOMBRE) + '%') AND
	(@APELLIDO = '' OR @APELLIDO is null OR lower(cli.apellido) LIKE '%' + lower(@APELLIDO) + '%') AND
	(@DNI = '' OR @DNI is null OR lower(cli.numeroDocumento) LIKE '%' + lower(@DNI) + '%') AND
	(@mail = '' OR @mail is null OR lower(cli.mail) LIKE '%' + lower(@mail) + '%');
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
CREATE PROCEDURE [VADIUM].HistorialCliente @clienteId int
AS
BEGIN

SELECT pub.descripcion as Espectaculo, ubi.fila, ubi.asiento, tu.descripcion as TipoUbicacion, pub.fecha as FechaEspectaculo, compra.medio_de_pago as medioPago
FROM VADIUM.COMPRA compra JOIN VADIUM.UBICACION ubi ON (compra.compra_id = ubi.compra_id)
							 JOIN VADIUM.TIPOUBICACION tu ON (ubi.codigoTipoUbicacion = tu.codigoTipoUbicacion)
						     JOIN VADIUM.PUBLICACION pub ON (ubi.codigoEspectaculo = pub.codigoEspectaculo)
							 --JOIN VADIUM.FACTURA fac ON (item.factura_nro = fac.factura_nro)

WHERE compra.id_cliente_comprador = @clienteId

END
GO

---------------------------EMPRESA -----------------------------------


CREATE PROCEDURE [VADIUM].LISTADO_SELECCION_EMPRESA @razonSocial NVARCHAR(255),@CUIT NVARCHAR(255),@mail NVARCHAR(255)
AS
BEGIN TRY
	SELECT *
	FROM [VADIUM].EMPRESA emp 
	WHERE
	(@razonSocial = '' OR @razonSocial is null OR  lower(emp.razonSocial) LIKE '%' + lower(@razonSocial) + '%') AND	
	(@mail = '' OR @mail is null OR lower(emp.mail) LIKE '%' + lower(@mail) + '%')AND
	(@CUIT = '' OR @CUIT is null OR lower(emp.cuit) LIKE '%' + lower(@CUIT) + '%' ) ;
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
------------------- Canje de puntos ----------------------------------

--CREATE PROCEDURE [VADIUM].puntajeCliente  @cliente int, @fechaActual datetime

--AS
--BEGIN


--SELECT sum(item.monto) as puntos
--FROM VADIUM.ITEMFACTURA item JOIN VADIUM.FACTURA fact ON (item.factura_nro = fact.factura_nro)
--	WHERE dateadd(yy,1, fact.fecha) > @fechaActual AND item.cliente_id = @cliente
--group by item.cliente_id
--END
--GO

--CREATE PROCEDURE [VADIUM].CanjearPremio  @id_Cliente int, @premioId int ,  @fechaActual datetime

--AS
--BEGIN

--DECLARE @puntos int

--SELECT TOP 1 @puntos = puntos from VADIUM.PREMIO pr WHERE pr.premioId = @premioId

--INSERT INTO VADIUM.PREMIO_POR_CLIENTE(cliente_id, premioId, fecha,puntos) VALUES (@id_Cliente,@premioId, @fechaActual, @puntos )



--END
--GO
----------------Publicaciones--------------------------------------
CREATE PROCEDURE [VADIUM].ObtenerPublicaciones @desde datetime, @hasta datetime, @rubro nvarchar(255), @descripcion nvarchar(255)
AS 
BEGIN
	SELECT pub.codigoEspectaculo, pub.descripcion,pub.fecha, pub.fechaVencimiento, rub.rubro_id, rub.descripcion as rubro_descripcion, 
			pub.direccion as direccionEspectaculo, gr.descripcion as grado_descripcion, gr.comision as comision, gr.grado_id as grado_id,
			pub.empresa_id, es.codigo as estado_id, es.descripcion as estado_descripcion
	FROM VADIUM.PUBLICACION pub JOIN ESTADO es ON (pub.estado_id = es.codigo)
								JOIN RUBRO rub ON (pub.rubro_id = rub.rubro_id)
								JOIN GRADO gr ON (pub.grado_id = gr.grado_id)
								--JOIN EMPRESA emp ON (pub.empresa_id = emp.empresa_id)
	WHERE (@desde IS NULL OR @desde > pub.fecha) AND
		 (@hasta IS NULL OR @hasta < pub.fecha) AND
		 (@rubro = '' OR @rubro is null OR  lower(rub.descripcion) LIKE '%' + lower(@rubro) + '%') AND
		 (@descripcion = '' OR @descripcion is null OR  lower(pub.descripcion) LIKE '%' + lower(@descripcion) + '%') 
END
GO
---------------UBICACIONES------------------------------------------
CREATE PROCEDURE [VADIUM].UBICACIONES_NO_VENDIDAS @publicacion_id int = NULL, @tipoUbicacionId int = NULL
AS
BEGIN
	SELECT ubi.ubicacion_id as Id, ubi.asiento as Asiento, ubi.fila as fila, ubi.sinNumerar as Sin_Numerar, ubi.precio as Precio, tu.descripcion as Tipo_ubicacion
	FROM VADIUM.UBICACION ubi JOIN VADIUM.TIPOUBICACION tu ON (ubi.codigoTipoUbicacion = tu.codigoTipoUbicacion)
	
	WHERE (@publicacion_id IS NULL OR ubi.codigoEspectaculo = @publicacion_id) AND 
		  (@tipoUbicacionId IS NULL OR tu.codigoTipoUbicacion = @tipoUbicacionId) AND 
			ubi.compra_id IS NULL
END
GO
------------------COMPRAR-------------------------------------------
CREATE PROCEDURE [VADIUM].COMPRAR @codCliente int, @FormaPago nvarchar(255), @fecha datetime, @monto numeric(18,0), @cantidad int, @new_identity INT = NULL OUTPUT
AS
BEGIN

	INSERT INTO VADIUM.COMPRA (id_cliente_comprador, medio_de_pago, fecha_compra)
	VALUES(@codCliente, @FormaPago, @fecha)
	SET @new_identity = SCOPE_IDENTITY();

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


	-------------------- SP agregar ROL al USUARIO ------------------------

	CREATE PROCEDURE VADIUM.AGREGAR_ROL_USUARIO(@iduser int, @idrol int) AS
	BEGIN
		INSERT INTO VADIUM.ROL_POR_USUARIO(rol_id,usuario_id)
			VALUES ((SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_id = @iduser),
					(SELECT rol_id FROM VADIUM.ROL WHERE rol_id = @idrol))
	END 
	GO


	-------------------- SP agregar ROL a la base ------------------------

	CREATE PROCEDURE VADIUM.AGREGAR_ROL_NUEVO(@rol_nombre nvarchar(255), @ret numeric (18,0) output)
	AS BEGIN
		INSERT INTO VADIUM.ROL(rol_nombre, rol_habilitado) VALUES (@rol_nombre, 1)
		SET @ret = SCOPE_IDENTITY()
	END
	GO


	--------------------- SP Agregar FUNCIONALIDAD al ROL --------------------------
	CREATE PROCEDURE VADIUM.AGREGAR_FUNCIONALIDAD(@rol nvarchar(255), @funcionalidad nvarchar(255)) AS
	BEGIN
		INSERT INTO VADIUM.ROL_POR_FUNCIONALIDAD(rol_id, funcionalidad_id)
			VALUES ((SELECT rol_id FROM VADIUM.ROL WHERE rol_nombre = @rol),
					(SELECT funcionalidad_id FROM VADIUM.FUNCIONALIDAD WHERE funcionalidad_descripcion = @funcionalidad))
	END
	GO


	--------------------- SP Quitar FUNCIONALIDAD al ROL --------------------------
	CREATE PROCEDURE VADIUM.QUITAR_FUNCIONALIDAD(@rol nvarchar(255), @funcionalidad nvarchar(255)) AS
	BEGIN
		DELETE FROM VADIUM.ROL_POR_FUNCIONALIDAD
			WHERE 
				(SELECT rol_id FROM VADIUM.ROL WHERE rol_nombre = @rol) = VADIUM.ROL_POR_FUNCIONALIDAD.rol_id
				AND
				(SELECT funcionalidad_id FROM VADIUM.FUNCIONALIDAD WHERE funcionalidad_descripcion = @funcionalidad ) = VADIUM.ROL_POR_FUNCIONALIDAD.funcionalidad_id
	END
	GO


--------------Ejecutar datos iniciales y migracion------------------
EXECUTE VADIUM.PR_DATOS_INSERT_DATOS_INICIALES;
EXECUTE VADIUM.PR_MIGRACION;


--------------Asignacion de Funcionalidades-------------------

EXEC VADIUM.AGREGAR_ROL_USUARIO
	@iduser = 0, @idrol = 0;
GO

----- ADMIN ------

EXEC VADIUM.AGREGAR_FUNCIONALIDAD
@rol = 'Administrador', @funcionalidad = 'AdministrarClientes';
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
@rol = 'Administrador', @funcionalidad = 'AdministrarEmpresas';
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
@rol = 'Administrador', @funcionalidad = 'AdministrarGrados';	
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
@rol = 'Administrador', @funcionalidad = 'AdministrarRoles';
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
@rol = 'Administrador', @funcionalidad = 'AdministrarRubros';
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
@rol = 'Administrador', @funcionalidad = 'AdministrarPuntos';
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
@rol = 'Administrador', @funcionalidad = 'AdministrarCompras';		
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
@rol = 'Administrador', @funcionalidad = 'EditarPublicacion';
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
@rol = 'Administrador', @funcionalidad = 'GenerarPublicacion';
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
@rol = 'Administrador', @funcionalidad = 'RendicionesPorComision';
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
@rol = 'Administrador', @funcionalidad = 'HistorialClientes';	
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
@rol = 'Administrador', @funcionalidad = 'ListadoEstadistico';		
			
	


----- Cliente -----

EXEC VADIUM.AGREGAR_FUNCIONALIDAD
	@rol = 'Cliente', @funcionalidad = 'EditarPublicacion';		
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
	@rol = 'Cliente', @funcionalidad = 'GenerarPublicacion';	
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
	@rol = 'Cliente', @funcionalidad = 'HistorialClientes';	
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
	@rol = 'Cliente', @funcionalidad = 'ListadoEstadistico';
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
@rol = 'Cliente', @funcionalidad = 'TarjetaDeCredito';		
		
----- Empresas ----

EXEC VADIUM.AGREGAR_FUNCIONALIDAD
	@rol = 'Empresa', @funcionalidad = 'EditarPublicacion';		
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
	@rol = 'Empresa', @funcionalidad = 'GenerarPublicacion';
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
	@rol = 'Empresa', @funcionalidad = 'HistorialClientes';			
EXEC VADIUM.AGREGAR_FUNCIONALIDAD
	@rol = 'Empresa', @funcionalidad = 'ListadoEstadistico';		