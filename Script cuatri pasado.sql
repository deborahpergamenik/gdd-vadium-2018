USE [GD1C2017]
GO

-------------------------------DROP PROCEDURES-------------------
IF OBJECT_ID('LOSNOOBS.EXISTE_TURNO') IS NOT NULL
DROP PROCEDURE LOSNOOBS.EXISTE_TURNO;
GO
IF OBJECT_ID('LOSNOOBS.PR_FILTRAR_VIAJE_SIN_FACTURA') IS NOT NULL
DROP PROCEDURE LOSNOOBS.PR_FILTRAR_VIAJE_SIN_FACTURA;
GO

IF OBJECT_ID('LOSNOOBS.PR_DETALLE_VIAJE_SIN_FACTURA') IS NOT NULL
DROP PROCEDURE LOSNOOBS.PR_DETALLE_VIAJE_SIN_FACTURA;
GO

IF OBJECT_ID('LOSNOOBS.PR_PRECIOS_VIAJE') IS NOT NULL
DROP PROCEDURE LOSNOOBS.PR_PRECIOS_VIAJE;
GO
IF OBJECT_ID('LOSNOOBS.PR_BLOQUEAR_USUARIO') IS NOT NULL
DROP PROCEDURE LOSNOOBS.PR_BLOQUEAR_USUARIO;
GO

IF OBJECT_ID('LOSNOOBS.PR_USUARIO_LOGUEADO') IS NOT NULL
DROP PROCEDURE LOSNOOBS.PR_USUARIO_LOGUEADO;
GO

IF OBJECT_ID('LOSNOOBS.SP_Create_Rol') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[SP_Create_Rol]
GO

IF OBJECT_ID('LOSNOOBS.SP_Update_Rol') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[SP_Update_Rol]
GO

IF OBJECT_ID('LOSNOOBS.SP_Update_Funcionalidad_Por_Rol') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[SP_Update_Funcionalidad_Por_Rol]
GO

IF OBJECT_ID('LOSNOOBS.PR_INHABILITAR_ROL') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_INHABILITAR_ROL]
GO

IF OBJECT_ID('LOSNOOBS.SP_Get_Funcionalidades_Rol') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[SP_Get_Funcionalidades_Rol]
GO

IF OBJECT_ID('LOSNOOBS.PR_Get_Funcionalidades') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_Get_Funcionalidades]
GO

IF OBJECT_ID('LOSNOOBS.PR_Get_Roles') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_Get_Roles]
GO

IF OBJECT_ID('LOSNOOBS.PR_DATOS_INSERT_DATOS_INICIALES') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_DATOS_INSERT_DATOS_INICIALES]
GO

IF OBJECT_ID('LOSNOOBS.PR_MIGRACION') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_MIGRACION]
GO

IF OBJECT_ID('LOSNOOBS.PR_LOGIN') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_LOGIN]
GO

IF OBJECT_ID('LOSNOOBS.SP_Get_Usuario_Rol') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[SP_Get_Usuario_Rol]
GO

IF OBJECT_ID('LOSNOOBS.PR_INSERTAR_MODIFICAR_CLIENTE') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].PR_INSERTAR_MODIFICAR_CLIENTE
GO

IF OBJECT_ID('LOSNOOBS.PR_BAJA_CLIENTE') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_BAJA_CLIENTE]
GO

IF OBJECT_ID('LOSNOOBS.PR_LISTADO_SELECCION_ABM_CLIENTE') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_LISTADO_SELECCION_ABM_CLIENTE]
GO

IF OBJECT_ID('LOSNOOBS.PR_MARCAS_AUTOS') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_MARCAS_AUTOS]
GO

IF OBJECT_ID('LOSNOOBS.PR_ALTA_AUTOMOVIL') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_ALTA_AUTOMOVIL]
GO

IF OBJECT_ID('LOSNOOBS.PR_ALTA_CLIENTE') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_ALTA_CLIENTE]
GO

IF OBJECT_ID('LOSNOOBS.PR_ALTA_MODIFICACION_AUTOMOVIL') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_ALTA_MODIFICACION_AUTOMOVIL]
GO

IF OBJECT_ID('LOSNOOBS.PR_BAJA_AUTOMOVIL') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_BAJA_AUTOMOVIL]
GO

IF OBJECT_ID('LOSNOOBS.SELECCION_ABM_AUTOMOVIL') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[SELECCION_ABM_AUTOMOVIL]
GO

IF OBJECT_ID('LOSNOOBS.PR_PISA_OTRO_RANGO') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_PISA_OTRO_RANGO]
GO

IF OBJECT_ID('LOSNOOBS.PR_PISA_RANGO_DIFERENTE') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_PISA_RANGO_DIFERENTE]
GO

IF OBJECT_ID('LOSNOOBS.PR_INSERTAR_TURNO') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_INSERTAR_TURNO]
GO

IF OBJECT_ID('LOSNOOBS.EXISTE_TURNO') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[EXISTE_TURNO]
GO

IF OBJECT_ID('LOSNOOBS.PR_UPDATE_TURNO') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_UPDATE_TURNO]
GO

IF OBJECT_ID('LOSNOOBS.PR_GET_TURNO') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_GET_TURNO]
GO

IF OBJECT_ID('LOSNOOBS.PR_LISTADO_SELECCION_ABM_CHOFER') IS NOT NULL
DROP PROCEDURE [LOSNOOBS]. [PR_LISTADO_SELECCION_ABM_CHOFER]
GO

IF OBJECT_ID('LOSNOOBS.PR_INSERTAR_MODIFICAR_CHOFER') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_INSERTAR_MODIFICAR_CHOFER]
GO

IF OBJECT_ID('LOSNOOBS.PR_BAJA_CHOFER') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_BAJA_CHOFER]
GO

IF OBJECT_ID('LOSNOOBS.F_PISA_VIAJE') IS NOT NULL
DROP FUNCTION [LOSNOOBS].[F_PISA_VIAJE]
GO

IF OBJECT_ID('LOSNOOBS.PR_REGISTRO_VIAJE') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_REGISTRO_VIAJE]
GO

IF OBJECT_ID('LOSNOOBS.PR_SELECT_LIST_CHOFERAUTO') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_SELECT_LIST_CHOFERAUTO]
GO

IF OBJECT_ID('LOSNOOBS.PR_FILTRAR_VIAJES') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_FILTRAR_VIAJES]
GO

IF OBJECT_ID('LOSNOOBS.PR_CREAR_RENDICION') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_CREAR_RENDICION]
GO

IF OBJECT_ID('LOSNOOBS.PR_CREAR_FACTURA') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_CREAR_FACTURA]
GO

IF OBJECT_ID('LOSNOOBS.PR_LISTADO_ESTADISTICO') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_LISTADO_ESTADISTICO]
GO

IF OBJECT_ID('LOSNOOBS.PR_GET_AUTO_CHOFER') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_GET_AUTO_CHOFER]
GO

IF OBJECT_ID('LOSNOOBS.PR_GET_AUTO_CHOFER') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_GET_AUTO_CHOFER]
GO

IF OBJECT_ID('LOSNOOBS.PR_GET_TURNOS') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_GET_TURNOS]
GO

IF OBJECT_ID('LOSNOOBS.PR_GET_AUTOS') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].[PR_GET_AUTOS]
GO

IF OBJECT_ID('LOSNOOBS.PR_BUSCAR_CHOFER_POR_DNI') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].PR_BUSCAR_CHOFER_POR_DNI
GO


IF OBJECT_ID('LOSNOOBS.PR_BUSCAR_CLIENTE_POR_DNI') IS NOT NULL
DROP PROCEDURE [LOSNOOBS].PR_BUSCAR_CLIENTE_POR_DNI
GO

IF OBJECT_ID('[LOSNOOBS].LISTADO_SELECCION_ABM_AUTOMOVIL') IS NOT NULL 
DROP PROCEDURE [LOSNOOBS].LISTADO_SELECCION_ABM_AUTOMOVIL
GO

IF OBJECT_ID('[LOSNOOBS].PR_GET_CHOFER_FILTRO') IS NOT NULL 
DROP PROCEDURE [LOSNOOBS].PR_GET_CHOFER_FILTRO
GO

IF OBJECT_ID('[LOSNOOBS].PR_GET_CHOFERES_HABILITADOS') IS NOT NULL 
DROP PROCEDURE [LOSNOOBS].PR_GET_CHOFERES_HABILITADOS
GO

IF OBJECT_ID('[LOSNOOBS].PR_GET_CLIENTE_FILTRO') IS NOT NULL 
DROP PROCEDURE [LOSNOOBS].PR_GET_CLIENTE_FILTRO
GO

IF OBJECT_ID('[LOSNOOBS].PR_GET_CLIENTES_HABILITADOS') IS NOT NULL 
DROP PROCEDURE [LOSNOOBS].PR_GET_CLIENTES_HABILITADOS
GO

IF OBJECT_ID('[LOSNOOBS].PR_GET_MARCAS') IS NOT NULL 
DROP PROCEDURE [LOSNOOBS].PR_GET_MARCAS
GO

IF OBJECT_ID('[LOSNOOBS].PR_INSERTAR_CHOFER') IS NOT NULL 
DROP PROCEDURE [LOSNOOBS].PR_INSERTAR_CHOFER
GO

IF OBJECT_ID('[LOSNOOBS].PR_MODIFICACION_CLIENTE') IS NOT NULL 
DROP PROCEDURE [LOSNOOBS].PR_MODIFICACION_CLIENTE
GO

IF OBJECT_ID('[LOSNOOBS].PR_MODIFICAR_AUTOMOVIL') IS NOT NULL 
DROP PROCEDURE [LOSNOOBS].PR_MODIFICAR_AUTOMOVIL
GO

IF OBJECT_ID('[LOSNOOBS].PR_MODIFICAR_CHOFER') IS NOT NULL 
DROP PROCEDURE [LOSNOOBS].PR_MODIFICAR_CHOFER
GO

------------------------------DROP TRIGGERS ---------------------------------
IF OBJECT_ID('LOSNOOBS.TR_CLIENTE_USUARIO') IS NOT NULL
DROP TRIGGER LOSNOOBS.TR_CLIENTE_USUARIO
GO

IF OBJECT_ID('LOSNOOBS.TR_CHOFER_USUARIO') IS NOT NULL
DROP TRIGGER LOSNOOBS.TR_CHOFER_USUARIO
GO
------------------------------DROP DE TABLAS------------------------------
IF OBJECT_ID('LOSNOOBS.ROL_POR_FUNCIONALIDAD') IS NOT NULL
DROP TABLE [LOSNOOBS].ROL_POR_FUNCIONALIDAD
GO

IF OBJECT_ID('LOSNOOBS.ROL_POR_USUARIO') IS NOT NULL
DROP TABLE [LOSNOOBS].ROL_POR_USUARIO
GO

IF OBJECT_ID('LOSNOOBS.ROL') IS NOT NULL
DROP TABLE [LOSNOOBS].ROL
GO

IF OBJECT_ID('LOSNOOBS.VIAJE') IS NOT NULL
DROP TABLE [LOSNOOBS].VIAJE
GO

IF OBJECT_ID('LOSNOOBS.RENDICION') IS NOT NULL
DROP TABLE [LOSNOOBS].RENDICION
GO

IF OBJECT_ID('LOSNOOBS.AUTOMOVIL') IS NOT NULL
DROP TABLE [LOSNOOBS].AUTOMOVIL
GO

IF OBJECT_ID('LOSNOOBS.PAGO') IS NOT NULL
DROP TABLE [LOSNOOBS].PAGO
GO

IF OBJECT_ID('LOSNOOBS.TURNO') IS NOT NULL
DROP TABLE [LOSNOOBS].TURNO
GO

IF OBJECT_ID('LOSNOOBS.FUNCIONALIDAD') IS NOT NULL
DROP TABLE [LOSNOOBS].FUNCIONALIDAD
GO

IF OBJECT_ID('LOSNOOBS.CHOFER') IS NOT NULL
DROP TABLE [LOSNOOBS].CHOFER
GO

IF OBJECT_ID('LOSNOOBS.FACTURACION') IS NOT NULL
DROP TABLE [LOSNOOBS].FACTURACION
GO

IF OBJECT_ID('LOSNOOBS.CLIENTE') IS NOT NULL
DROP TABLE [LOSNOOBS].CLIENTE
GO

IF OBJECT_ID('LOSNOOBS.USUARIO') IS NOT NULL
DROP TABLE [LOSNOOBS].USUARIO
GO

------------------------------DROP SCHEMA------------------------------------
IF SCHEMA_ID('LOSNOOBS') IS NOT NULL
	DROP SCHEMA [LOSNOOBS]
GO

-----------------------------CREACION SCHEMA --------------------------------
CREATE SCHEMA [LOSNOOBS]
GO
------------------------------CREACION DE TABLAS------------------------------

CREATE TABLE [LOSNOOBS].ROL(
	rol_id int PRIMARY KEY IDENTITY(1,1),
	rol_habilitado bit DEFAULT 1, 
	rol_nombre nvarchar(255) UNIQUE not null
)
GO

CREATE TABLE [LOSNOOBS].USUARIO(
	usuario_id int PRIMARY KEY IDENTITY(1,1),
	usuario_username nvarchar(255) NOT NULL UNIQUE,
	usuario_password binary(32) NOT NULL,
	usuario_intentosLogin int default 0,
	usuario_activo BIT
)
GO

CREATE TABLE [LOSNOOBS].ROL_POR_USUARIO(
	rol_id int,
	usuario_id int,
	PRIMARY KEY (rol_id, usuario_id)
)
GO

CREATE TABLE [LOSNOOBS].FUNCIONALIDAD(
	funcionalidad_id int PRIMARY KEY IDENTITY (1,1),
	funcionalidad_descripcion nvarchar(255)
)
GO

CREATE TABLE [LOSNOOBS].ROL_POR_FUNCIONALIDAD(
	rol_id int,
	funcionalidad_id int,
	PRIMARY KEY(rol_id, funcionalidad_id)	
)
GO

CREATE TABLE [LOSNOOBS].CHOFER(
	chofer_apellido nvarchar(255) NOT NULL ,
	chofer_nombre nvarchar(255) NOT NULL ,
	chofer_direccion nvarchar(255) NOT NULL,
	chofer_dni bigint NOT NULL,
	chofer_habilitado bit DEFAULT 1,
	chofer_id int PRIMARY KEY IDENTITY (1,1),
	chofer_mail varchar(50) NOT NULL ,
	chofer_telefono nvarchar(11) NOT NULL UNIQUE,
	chofer_fechaNacimiento datetime NOT NULL,
	usuario_id INTEGER UNIQUE,
	borrado BIT DEFAULT 0
)
GO

CREATE TABLE [LOSNOOBS].CLIENTE (
	cliente_apellido nvarchar(255) NOT NULL ,
	cliente_nombre nvarchar(255) NOT NULL ,
	cliente_direccion nvarchar(255) NOT NULL,
	cliente_dni bigint NOT NULL,
	cliente_habilitado bit DEFAULT 1,
	cliente_id int PRIMARY KEY IDENTITY (1,1),
	cliente_mail varchar(50) NOT NULL ,
	cliente_telefono nvarchar(11) NOT NULL UNIQUE,
	cliente_fechaNacimiento datetime NOT NULL,
	usuario_id INTEGER UNIQUE,
	borrado BIT DEFAULT 0
)
GO

create TABLE [LOSNOOBS].VIAJE(
	viaje_id int PRIMARY KEY IDENTITY (1,1), 
	viaje_auto int NOT NULL,
	viaje_chofer int NOT NULL,
	viaje_cliente int NOT NULL,
	viaje_fyh_inicio datetime,
	viaje_fyh_fin datetime,
	viaje_cantidadKM int NOT NULL,
	viaje_turno int,
	viaje_factura int NULL,
	/*CONSTRAINT [UQ_fechas_duplicadas_chofer] UNIQUE NONCLUSTERED
    (
        viaje_fyh_inicio, viaje_chofer
    ),
	CONSTRAINT [UQ_fechas_duplicadas_cliente] UNIQUE NONCLUSTERED
    (
        viaje_fyh_inicio, viaje_cliente
    ),
	CONSTRAINT [UQ_fechas_duplicadas_fin_chofer] UNIQUE NONCLUSTERED
    (
        viaje_fyh_fin, viaje_chofer
    ),
	CONSTRAINT [UQ_fechas_duplicadas_fin_cliente] UNIQUE NONCLUSTERED
    (
        viaje_fyh_fin, viaje_cliente
    )
	*/
)
GO
	
CREATE TABLE [LOSNOOBS].TURNO(
	turno_id int PRIMARY KEY IDENTITY (1,1),
	turno_habilitado bit DEFAULT 1,
	turno_horaInicio numeric(18,0) NOT NULL,
	turno_horaFin numeric(18,0) NOT NULL,
	turno_precio_base numeric(18,2),
	turno_valor_km numeric(18,2),
	turno_descripcion nvarchar(255) NOT NULL UNIQUE,
)
GO

CREATE TABLE [LOSNOOBS].AUTOMOVIL(
	auto_id int PRIMARY KEY IDENTITY (1,1),
	auto_turno int NOT NULL,
	auto_chofer int NOT NULL,
	auto_modelo nvarchar(255) NOT NULL,
	auto_patente nvarchar(255) NOT NULL UNIQUE,
	auto_marca nvarchar(255) NOT NULL,
	auto_habilitado bit DEFAULT 1,
	auto_licencia nvarchar(255),
	auto_rodado nvarchar(255),
	borrado bit DEFAULT 0,
	CONSTRAINT [UQ_autos_turno_habilitado_borrado] UNIQUE NONCLUSTERED
    (
        auto_chofer, auto_habilitado, auto_turno, borrado
    )
)
GO

CREATE TABLE [LOSNOOBS].PAGO(
	pago_id int PRIMARY KEY IDENTITY (1,1),
	pago_chofer int,
	pago_turno int,
	pago_fecha datetime,
	pago_importe numeric(18,2)
)
GO

CREATE TABLE [LOSNOOBS].RENDICION(
	rendicion_id INT PRIMARY KEY IDENTITY (1,1),
	rendicion_pago INT,
	rendicion_viaje INT,
	rendicion_importe numeric(18,2),
	porcentaje INT
)
GO

CREATE TABLE [LOSNOOBS].FACTURACION(
	factura_id int PRIMARY KEY IDENTITY (1,1),
	external_factura_id int UNIQUE,
	factura_fecha_inicio datetime,
	factura_fecha_fin datetime,
	factura_importe numeric(18,2) NOT NULL,
	factura_cliente int NOT NULL,
)
GO

------------------------------TRIGGERS------------------------------

CREATE TRIGGER LOSNOOBS.TR_CLIENTE_USUARIO
ON LOSNOOBS.CLIENTE
INSTEAD OF INSERT
AS
BEGIN TRY
	INSERT INTO LOSNOOBS.USUARIO (usuario_username, usuario_password, usuario_activo, usuario_intentosLogin)
	SELECT I.cliente_telefono, HashBytes('SHA2_256',convert(varchar(255),I.cliente_telefono)), 1, 0
	FROM inserted I 
	WHERE I.cliente_telefono NOT IN(SELECT U2.usuario_username FROM LOSNOOBS.USUARIO U2)
	
	INSERT INTO LOSNOOBS.ROL_POR_USUARIO (rol_id,usuario_id)
	SELECT 2, U.usuario_id 
	FROM inserted I JOIN LOSNOOBS.USUARIO U ON(U.usuario_username = I.cliente_telefono) 
	WHERE NOT EXISTS (SELECT 1 FROM LOSNOOBS.ROL_POR_USUARIO RU WHERE RU.rol_id = 2 AND RU.usuario_id = U.usuario_id)
	
	INSERT INTO LOSNOOBS.CLIENTE(cliente_apellido,cliente_direccion,cliente_dni,cliente_fechaNacimiento,cliente_habilitado,cliente_mail,cliente_nombre,cliente_telefono,usuario_id)
	SELECT cliente_apellido,cliente_direccion,cliente_dni,cliente_fechaNacimiento,cliente_habilitado,cliente_mail,cliente_nombre,cliente_telefono,(SELECT usuario_id FROM LOSNOOBS.USUARIO WHERE usuario_username = I.cliente_telefono) FROM inserted I
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE TRIGGER LOSNOOBS.TR_CHOFER_USUARIO
ON LOSNOOBS.CHOFER
INSTEAD OF INSERT
AS
BEGIN TRY
	INSERT INTO LOSNOOBS.USUARIO(usuario_username, usuario_password, usuario_activo, usuario_intentosLogin)
	SELECT I.chofer_telefono,HashBytes('SHA2_256',convert(varchar(255),I.chofer_telefono)),1,0 FROM inserted I WHERE I.chofer_telefono NOT IN(SELECT U2.usuario_username FROM LOSNOOBS.USUARIO U2)
	
	INSERT INTO LOSNOOBS.ROL_POR_USUARIO(rol_id,usuario_id)
	SELECT 3,U.usuario_id FROM inserted I JOIN LOSNOOBS.USUARIO U ON(U.usuario_username = I.chofer_telefono) WHERE NOT EXISTS (SELECT 1 FROM LOSNOOBS.ROL_POR_USUARIO RU WHERE RU.rol_id = 3 AND RU.usuario_id = U.usuario_id)
	
	INSERT INTO LOSNOOBS.CHOFER(chofer_apellido,chofer_direccion,chofer_dni,chofer_fechaNacimiento,chofer_habilitado,chofer_mail,chofer_nombre,chofer_telefono,usuario_id)
	SELECT chofer_apellido,chofer_direccion,chofer_dni,chofer_fechaNacimiento,chofer_habilitado,chofer_mail,chofer_nombre,chofer_telefono,(SELECT usuario_id FROM LOSNOOBS.USUARIO WHERE usuario_username = I.chofer_telefono) FROM inserted I
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

------------------------------ABM ROL------------------------------

CREATE PROCEDURE [LOSNOOBS].[SP_Create_Rol]
  @nombre_rol VARCHAR(255),
  @habilitado BIT
AS
  BEGIN TRY
    INSERT INTO LOSNOOBS.ROL (rol_habilitado, rol_nombre) VALUES(@habilitado, @nombre_rol);

	SELECT SCOPE_IDENTITY();
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].[SP_Update_Rol]
  @ID NVARCHAR(255),
  @habilitado BIT,
  @nuevo_nombre VARCHAR(255)
AS
  BEGIN TRY
	 UPDATE LOSNOOBS.ROL SET rol_habilitado = @habilitado, rol_nombre = @nuevo_nombre WHERE rol_id = @ID
	  IF(@habilitado = 0 )
		DELETE FROM LOSNOOBS.ROL_POR_USUARIO WHERE rol_id = @ID
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
 GO
 
CREATE PROCEDURE [LOSNOOBS].[SP_Update_Funcionalidad_Por_Rol]
  @ID_Rol INTEGER,
  @funcionalidad_nombre VARCHAR(255),
  @habilitado bit
AS
  BEGIN TRY
    DECLARE @ID_Funcionalidad NUMERIC(18)
    DECLARE @ID_Rol_Aux NUMERIC(18)
    DECLARE @ID_Funcionalidad_Aux NUMERIC(18)

    SELECT @ID_Funcionalidad = funcionalidad_id FROM [LOSNOOBS].FUNCIONALIDAD WHERE funcionalidad_descripcion = @funcionalidad_nombre

    SELECT @ID_Rol_Aux = rol_id, @ID_Funcionalidad_Aux = funcionalidad_id FROM LOSNOOBS.ROL_POR_FUNCIONALIDAD WHERE rol_id = @ID_Rol AND funcionalidad_id = @ID_Funcionalidad

    IF @ID_Rol_Aux IS NOT NULL AND @ID_Funcionalidad_Aux IS NOT NULL
	BEGIN
	  IF(@habilitado = 0)
		 DELETE FROM [LOSNOOBS].ROL_POR_FUNCIONALIDAD WHERE funcionalidad_id = @ID_Funcionalidad_Aux AND rol_id = @ID_Rol_Aux
    END
	ELSE IF @habilitado = 1
      INSERT INTO [LOSNOOBS].[ROL_POR_FUNCIONALIDAD](funcionalidad_id, rol_id) VALUES (@ID_Funcionalidad, @ID_Rol)
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_INHABILITAR_ROL @ID_ROL INT
AS
DECLARE @NOMBRE_ROL NVARCHAR(50)
BEGIN TRY
	UPDATE [LOSNOOBS].ROL SET rol_habilitado = 0 WHERE rol_id = @ID_ROL

	DELETE FROM [LOSNOOBS].ROL_POR_USUARIO WHERE rol_id = @ID_ROL
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].[SP_Get_Funcionalidades_Rol]
  @nombre_rol VARCHAR(255)
AS
  BEGIN TRY
    SELECT f.funcionalidad_descripcion AS Funcionalidad FROM [LOSNOOBS].ROL_POR_FUNCIONALIDAD AS rf
      INNER JOIN [LOSNOOBS].FUNCIONALIDAD AS f
      ON f.funcionalidad_id = rf.funcionalidad_id
      INNER JOIN [LOSNOOBS].ROL AS r
      ON rf.rol_id = r.rol_id
        WHERE r.rol_nombre = @nombre_rol
    ORDER BY Funcionalidad
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].[PR_Get_Funcionalidades]
AS
  BEGIN TRY
	SELECT F.funcionalidad_descripcion AS Funcionalidades FROM [LOSNOOBS].FUNCIONALIDAD F
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].[PR_Get_Roles]
AS
  BEGIN TRY
	SELECT R.rol_id ID, R.rol_nombre Rol,R.rol_habilitado Habilitado FROM [LOSNOOBS].ROL R
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO


------------------------------FUNCIONALIDADES------------------------------

CREATE PROCEDURE [LOSNOOBS].PR_DATOS_INSERT_DATOS_INICIALES
AS
BEGIN
	INSERT INTO [LOSNOOBS].FUNCIONALIDAD(funcionalidad_descripcion) VALUES('Btn_Automovil')
	INSERT INTO [LOSNOOBS].FUNCIONALIDAD(funcionalidad_descripcion) VALUES('Btn_Chofer')
	INSERT INTO [LOSNOOBS].FUNCIONALIDAD(funcionalidad_descripcion) VALUES('Btn_ABM_Cliente')
	INSERT INTO [LOSNOOBS].FUNCIONALIDAD(funcionalidad_descripcion) VALUES('Btn_Facturacion')
	INSERT INTO [LOSNOOBS].FUNCIONALIDAD(funcionalidad_descripcion) VALUES('Btn_Listado')
	INSERT INTO [LOSNOOBS].FUNCIONALIDAD(funcionalidad_descripcion) VALUES('Btn_Registro_Viajes')
	INSERT INTO [LOSNOOBS].FUNCIONALIDAD(funcionalidad_descripcion) VALUES('Btn_Rendicion_Viajes')
	INSERT INTO [LOSNOOBS].FUNCIONALIDAD(funcionalidad_descripcion) VALUES('Btn_Rol')
	INSERT INTO [LOSNOOBS].FUNCIONALIDAD(funcionalidad_descripcion) VALUES('Btn_Turno')

	-- ROL 
	INSERT INTO [LOSNOOBS].ROL (rol_nombre) values('Administrador')
	INSERT INTO [LOSNOOBS].ROL (rol_nombre) values('Cliente')
	INSERT INTO [LOSNOOBS].ROL (rol_nombre) values('Chofer')

	-- USUARIO
	INSERT INTO LOSNOOBS.USUARIO(usuario_username, usuario_password, usuario_activo)
	VALUES('admin', HashBytes('SHA2_256','w23e'), 1)
	INSERT INTO LOSNOOBS.ROL_POR_USUARIO VALUES(1,1)
	INSERT INTO LOSNOOBS.ROL_POR_USUARIO VALUES(2,1)
	INSERT INTO LOSNOOBS.ROL_POR_USUARIO VALUES(3,1)
	
	EXECUTE [LOSNOOBS].[SP_Update_Funcionalidad_Por_Rol] 1,'Btn_Automovil',1
	EXECUTE [LOSNOOBS].[SP_Update_Funcionalidad_Por_Rol] 1,'Btn_Chofer',1
	EXECUTE [LOSNOOBS].[SP_Update_Funcionalidad_Por_Rol] 1,'Btn_ABM_Cliente',1
	EXECUTE [LOSNOOBS].[SP_Update_Funcionalidad_Por_Rol] 1,'Btn_Listado',1
	EXECUTE [LOSNOOBS].[SP_Update_Funcionalidad_Por_Rol] 1,'Btn_Registro_Viajes',1
	EXECUTE [LOSNOOBS].[SP_Update_Funcionalidad_Por_Rol] 1,'Btn_Rendicion_Viajes',1
	EXECUTE [LOSNOOBS].[SP_Update_Funcionalidad_Por_Rol] 1,'Btn_Facturacion',1
	EXECUTE [LOSNOOBS].[SP_Update_Funcionalidad_Por_Rol] 1,'Btn_Rol',1
	EXECUTE [LOSNOOBS].[SP_Update_Funcionalidad_Por_Rol] 1,'Btn_Turno',1
END
GO	

------------------------------MIGRACION------------------------------

CREATE PROCEDURE [LOSNOOBS].PR_MIGRACION
AS
BEGIN
	-- CHOFER
	INSERT INTO [LOSNOOBS].CHOFER (chofer_apellido,chofer_nombre,chofer_direccion,chofer_dni,chofer_mail,chofer_telefono,chofer_fechaNacimiento)
		SELECT DISTINCT m.Chofer_Apellido,m.Chofer_Nombre,m.Chofer_Direccion,m.Chofer_Dni, m.Chofer_Mail,m.Chofer_Telefono, m.Chofer_Fecha_Nac
		FROM gd_esquema.Maestra m 
		GROUP BY m.Chofer_Nombre, m.Chofer_Apellido, m.Chofer_Dni, m.Chofer_Direccion,m.Chofer_Mail, m.Chofer_Telefono, m.Chofer_Fecha_Nac
	-- TURNOS
	INSERT INTO [LOSNOOBS].TURNO(turno_descripcion, turno_horaInicio, turno_horaFin,turno_precio_base, turno_valor_km) 
		SELECT m.Turno_Descripcion, m.Turno_Hora_Inicio,m.Turno_Hora_Fin, m.Turno_Precio_Base, m.Turno_Valor_Kilometro
		from gd_esquema.Maestra m 
		group by m.Turno_Descripcion, m.Turno_Hora_Inicio, m.Turno_Hora_Fin, m.Turno_Precio_Base, m.Turno_Valor_Kilometro

	-- CLIENTE
	INSERT INTO [LOSNOOBS].CLIENTE(cliente_nombre, cliente_apellido, cliente_dni,cliente_telefono, cliente_direccion,cliente_mail,cliente_fechaNacimiento) 
		SELECT m.Cliente_Nombre, m.Cliente_Apellido, m.Cliente_Dni, m.Cliente_Telefono, m.Cliente_Direccion,m.Cliente_Mail,m.Cliente_Fecha_Nac
		from gd_esquema.Maestra m 
		group by m.Cliente_Nombre, m.Cliente_Apellido, m.Cliente_Dni, m.Cliente_Telefono, m.Cliente_Direccion,m.Cliente_Mail,m.Cliente_Fecha_Nac
	-- AUTOMOVIL
	INSERT INTO [LOSNOOBS].AUTOMOVIL(auto_modelo,auto_patente,auto_marca,auto_habilitado,auto_licencia,auto_rodado,auto_turno,auto_chofer)
		SELECT DISTINCT m.Auto_Modelo,m.Auto_Patente,m.Auto_Marca,1,m.Auto_Licencia,m.Auto_Rodado,1,CH.chofer_id
		FROM gd_esquema.Maestra m JOIN LOSNOOBS.CHOFER CH ON(CH.chofer_dni = m.Chofer_Dni)

	-- FACTURACION
	INSERT INTO [LOSNOOBS].FACTURACION(factura_fecha_inicio, factura_fecha_fin, external_factura_id, factura_cliente,factura_importe) 
	SELECT DISTINCT m.Factura_Fecha_Inicio, m.Factura_Fecha_Fin, m.Factura_Nro,C.cliente_id,(SELECT SUM(M2.Turno_Precio_Base + M2.Viaje_Cant_Kilometros * M2.Turno_Valor_Kilometro) FROM gd_esquema.Maestra M2 WHERE M2.Factura_Nro = m.Factura_Nro AND M2.Viaje_Fecha >=m.Factura_Fecha_Inicio AND M2.Viaje_Fecha < m.Factura_Fecha_Fin)
	from gd_esquema.Maestra m JOIN LOSNOOBS.CLIENTE C ON(C.cliente_dni=m.Cliente_Dni)
	WHERE m.Factura_Nro IS NOT NULL
	
	--VIAJE
	INSERT INTO LOSNOOBS.VIAJE(viaje_auto,viaje_chofer,viaje_cliente,viaje_fyh_inicio,viaje_fyh_fin,viaje_cantidadKM,viaje_turno,viaje_factura)
	SELECT A.auto_id,CH.chofer_id,C.cliente_id,M.Viaje_Fecha,M.Viaje_Fecha,M.Viaje_Cant_Kilometros,T.turno_id,F.factura_id FROM gd_esquema.Maestra M 
	JOIN LOSNOOBS.AUTOMOVIL A ON(M.Auto_Patente = A.auto_patente)
	JOIN LOSNOOBS.CHOFER CH ON(CH.chofer_dni = M.Chofer_Dni)
	JOIN LOSNOOBS.CLIENTE C ON(C.cliente_dni = M.Cliente_Dni)
	JOIN LOSNOOBS.TURNO T ON(T.turno_descripcion = M.Turno_Descripcion)
	JOIN LOSNOOBS.FACTURACION F ON(M.Factura_Nro = F.external_factura_id);

	--PAGO
	INSERT INTO LOSNOOBS.PAGO (pago_chofer, pago_turno, pago_fecha, pago_importe)
	SELECT CH.chofer_id,T.turno_id,CONVERT(date, M.Rendicion_Fecha),SUM(M.Rendicion_Importe) FROM gd_esquema.Maestra M JOIN LOSNOOBS.TURNO T ON(T.turno_descripcion = M.Turno_Descripcion) JOIN LOSNOOBS.CHOFER CH ON(CH.chofer_dni = M.Chofer_Dni) WHERE M.Rendicion_Fecha IS NOT NULL GROUP BY CONVERT(date, M.Rendicion_Fecha),CH.chofer_id,T.turno_id,M.Rendicion_Nro ORDER BY 2,4
	
	--RENDICION
	INSERT INTO LOSNOOBS.RENDICION(rendicion_pago,rendicion_viaje,rendicion_importe,porcentaje)
	SELECT  P.pago_id ,(SELECT TOP 1 V.viaje_id FROM LOSNOOBS.VIAJE V WHERE V.viaje_turno = P.pago_turno AND V.viaje_chofer =P.pago_chofer AND V.viaje_auto =A.auto_id AND V.viaje_cliente =C.cliente_id AND V.viaje_fyh_inicio = M.Viaje_Fecha AND V.viaje_fyh_fin = M.Viaje_Fecha AND V.viaje_cantidadKM = M.Viaje_Cant_Kilometros),M.Rendicion_Importe,CAST(ROUND((100/(((SELECT TOP 1 V.viaje_cantidadKM FROM LOSNOOBS.VIAJE V WHERE V.viaje_turno = P.pago_turno AND V.viaje_chofer =P.pago_chofer AND V.viaje_auto =A.auto_id AND V.viaje_cliente =C.cliente_id AND V.viaje_fyh_inicio = M.Viaje_Fecha AND V.viaje_fyh_fin = M.Viaje_Fecha AND V.viaje_cantidadKM = M.Viaje_Cant_Kilometros) * T.turno_valor_km +T.turno_precio_base))*M.Rendicion_Importe),0)AS INT)
	FROM gd_esquema.Maestra M 
	JOIN LOSNOOBS.AUTOMOVIL A ON(M.Auto_Patente = A.auto_patente)
	JOIN LOSNOOBS.CHOFER CH ON(CH.chofer_dni = M.Chofer_Dni)
	JOIN LOSNOOBS.CLIENTE C ON(C.cliente_dni = M.Cliente_Dni)
	JOIN LOSNOOBS.TURNO T ON(T.turno_descripcion = M.Turno_Descripcion)
	JOIN LOSNOOBS.PAGO P ON(P.pago_fecha = CONVERT(DATE,M.Viaje_Fecha) AND P.pago_turno = T.turno_id AND P.pago_chofer = CH.chofer_id)
	WHERE M.Rendicion_Nro IS NOT NULL
END
GO

------------------------------FKS------------------------------

ALTER TABLE [LOSNOOBS].ROL_POR_USUARIO ADD FOREIGN KEY (rol_id) REFERENCES [LOSNOOBS].ROL
ALTER TABLE [LOSNOOBS].ROL_POR_USUARIO ADD FOREIGN KEY (usuario_id) REFERENCES [LOSNOOBS].USUARIO
ALTER TABLE [LOSNOOBS].ROL_POR_FUNCIONALIDAD ADD FOREIGN KEY (rol_id) REFERENCES [LOSNOOBS].ROL
ALTER TABLE [LOSNOOBS].ROL_POR_FUNCIONALIDAD ADD FOREIGN KEY (funcionalidad_id) REFERENCES [LOSNOOBS].FUNCIONALIDAD
ALTER TABLE [LOSNOOBS].VIAJE ADD FOREIGN KEY (viaje_cliente) REFERENCES [LOSNOOBS].CLIENTE
ALTER TABLE [LOSNOOBS].VIAJE ADD FOREIGN KEY (viaje_auto) REFERENCES [LOSNOOBS].AUTOMOVIL
ALTER TABLE [LOSNOOBS].VIAJE ADD FOREIGN KEY (viaje_chofer) REFERENCES [LOSNOOBS].AUTOMOVIL
ALTER TABLE [LOSNOOBS].VIAJE ADD FOREIGN KEY (viaje_factura) REFERENCES [LOSNOOBS].FACTURACION
ALTER TABLE [LOSNOOBS].VIAJE ADD FOREIGN KEY (viaje_turno) REFERENCES [LOSNOOBS].TURNO
ALTER TABLE [LOSNOOBS].AUTOMOVIL ADD FOREIGN KEY (auto_chofer) REFERENCES [LOSNOOBS].CHOFER
ALTER TABLE [LOSNOOBS].AUTOMOVIL ADD FOREIGN KEY (auto_turno) REFERENCES [LOSNOOBS].TURNO
ALTER TABLE [LOSNOOBS].PAGO ADD FOREIGN KEY (pago_turno) REFERENCES [LOSNOOBS].TURNO
ALTER TABLE [LOSNOOBS].PAGO ADD FOREIGN KEY (pago_chofer) REFERENCES [LOSNOOBS].CHOFER
ALTER TABLE [LOSNOOBS].FACTURACION ADD FOREIGN KEY (factura_cliente) REFERENCES [LOSNOOBS].CLIENTE
ALTER TABLE [LOSNOOBS].CLIENTE ADD FOREIGN KEY (usuario_id) REFERENCES [LOSNOOBS].USUARIO
ALTER TABLE [LOSNOOBS].CHOFER ADD FOREIGN KEY (usuario_id) REFERENCES [LOSNOOBS].USUARIO
GO
------------------------------LOGIN------------------------------

CREATE PROCEDURE [LOSNOOBS].PR_LOGIN @USERNAME NVARCHAR(255),@PASSWORD VARCHAR(255)
AS
BEGIN TRY
	IF (EXISTS(SELECT 1 FROM USUARIO WHERE usuario_username = @USERNAME))
	BEGIN
		UPDATE USUARIO SET usuario_intentosLogin = usuario_intentosLogin + 1 WHERE usuario_username = @USERNAME;

		SELECT	U.usuario_password Password, 
				U.usuario_username Username, 
				U.usuario_activo Activo, 
				U.usuario_id Id, 
				U.usuario_intentosLogin Intentos,  
				(CASE WHEN U.usuario_password = HashBytes('SHA2_256', @PASSWORD) THEN 1 ELSE 0 END) PasswordMatched
		FROM [LOSNOOBS].USUARIO U WHERE usuario_username = @USERNAME;
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_USUARIO_LOGUEADO @USERNAME NVARCHAR(255)
AS
BEGIN TRY
	IF (EXISTS(SELECT 1 FROM USUARIO WHERE usuario_username = @USERNAME))
	BEGIN
		UPDATE USUARIO SET usuario_intentosLogin = 0, usuario_activo = 1 WHERE usuario_username = @USERNAME;
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_BLOQUEAR_USUARIO @USERNAME NVARCHAR(255)
AS
BEGIN TRY
	IF (EXISTS(SELECT 1 FROM USUARIO WHERE usuario_username = @USERNAME))
	BEGIN
		UPDATE USUARIO SET usuario_intentosLogin = 0, usuario_activo = 0 WHERE usuario_username = @USERNAME;
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].[SP_Get_Usuario_Rol]
  @idUsuario INT
AS
  BEGIN TRY
    SELECT R.rol_nombre Nombre, RU.rol_id ID FROM [LOSNOOBS].ROL_POR_USUARIO RU
    INNER JOIN [LOSNOOBS].ROL R
        ON RU.rol_id = R.rol_id
    WHERE RU.usuario_id = @idUsuario
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

------------------------------ABM CLIENTE------------------------------
CREATE PROCEDURE [LOSNOOBS].PR_BUSCAR_CLIENTE_POR_DNI @DNI BIGINT
AS
BEGIN TRY
	SELECT *
	FROM [LOSNOOBS].CLIENTE C
	WHERE C.cliente_dni = @DNI
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_INSERTAR_MODIFICAR_CLIENTE @NOMBRE NVARCHAR (255),@APELLIDO NVARCHAR (255),@DNI BIGINT,@DIRECCION NVARCHAR (255),@TELEFONO NVARCHAR (255),@MAIL NVARCHAR (255),@FECHANAC DATETIME,@HABILITADO BIT
AS
BEGIN TRY
	IF(NOT EXISTS(SELECT 1 FROM CLIENTE WHERE CLIENTE.cliente_dni = @DNI)) --NUEVO CLIENTE
		INSERT INTO [LOSNOOBS].CLIENTE(cliente_nombre,cliente_apellido,cliente_dni,cliente_direccion,cliente_telefono,cliente_mail,cliente_fechaNacimiento,cliente_habilitado) VALUES(@NOMBRE ,@APELLIDO ,@DNI,@DIRECCION,@TELEFONO,@MAIL,@FECHANAC,@HABILITADO)
	ELSE
		UPDATE [LOSNOOBS].CLIENTE SET cliente_apellido = @APELLIDO,cliente_direccion = @DIRECCION,cliente_dni = @DNI,cliente_fechaNacimiento = @FECHANAC,cliente_mail = @MAIL,cliente_nombre = @NOMBRE,cliente_telefono = @TELEFONO,cliente_habilitado = @HABILITADO WHERE cliente_dni = @DNI
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_BAJA_CLIENTE @DNI BIGINT
AS
BEGIN TRY
	UPDATE [LOSNOOBS].CLIENTE SET borrado = 1 WHERE CLIENTE.cliente_dni = @DNI
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO 

CREATE	 PROCEDURE [LOSNOOBS].PR_LISTADO_SELECCION_ABM_CLIENTE @NOMBRE NVARCHAR(255),@APELLIDO NVARCHAR(255),@DNI BIGINT
AS
BEGIN TRY
	SELECT *, cliente_nombre + ' ' + cliente_apellido NombreCompleto
	FROM [LOSNOOBS].CLIENTE c 
	WHERE
	(@NOMBRE = '' OR @NOMBRE is null OR  lower(c.cliente_nombre) LIKE '%' + lower(@NOMBRE) + '%') AND
	(@APELLIDO = '' OR @APELLIDO is null OR lower(c.cliente_apellido) LIKE '%' + lower(@APELLIDO) + '%') AND
	(@DNI = '' OR @DNI is null OR c.cliente_dni = @DNI) AND borrado = 0;
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

------------------------------ABM AUTOMOVIL------------------------------

CREATE PROCEDURE [LOSNOOBS].PR_MARCAS_AUTOS @IDCHOFER INTEGER
AS
BEGIN TRY
	SELECT DISTINCT A.auto_marca FROM [LOSNOOBS].AUTOMOVIL A WHERE (@IDCHOFER = '' OR @IDCHOFER is null OR A.auto_chofer = @IDCHOFER);
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_ALTA_MODIFICACION_AUTOMOVIL @MARCA NVARCHAR(255),@MODELO NVARCHAR(255),@PATENTE NVARCHAR(255),@IDTURNO INTEGER, @IDCHOFER INTEGER, @HABILITADO BIT
AS
BEGIN TRY
	IF(EXISTS (SELECT 1 FROM [LOSNOOBS].AUTOMOVIL A WHERE A.auto_patente = @PATENTE))
		UPDATE [LOSNOOBS].AUTOMOVIL SET auto_marca = @MARCA,auto_modelo = @MODELO, auto_patente = @PATENTE,auto_turno = @IDTURNO,auto_chofer = @IDCHOFER, auto_habilitado = @HABILITADO WHERE auto_patente = @PATENTE
	ELSE
		INSERT INTO [LOSNOOBS].AUTOMOVIL(auto_marca,auto_modelo,auto_patente,auto_turno,auto_chofer, auto_habilitado) VALUES(@MARCA,@MODELO,@PATENTE,@IDTURNO,@IDCHOFER, @HABILITADO)
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_BAJA_AUTOMOVIL @PATENTE NVARCHAR(255)
AS
BEGIN TRY
	UPDATE [LOSNOOBS].AUTOMOVIL SET borrado = 1 WHERE auto_patente = @PATENTE
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].LISTADO_SELECCION_ABM_AUTOMOVIL @MARCA NVARCHAR(255),@MODELO NVARCHAR(255),@PATENTE NVARCHAR(255),@IDCHOFER INTEGER, @HABILITADO BIT, @IDTURNO INTEGER
AS
BEGIN TRY
	SELECT *
	FROM [LOSNOOBS].AUTOMOVIL A
	WHERE
	(@MARCA = '' OR @MARCA is null OR lower(A.auto_marca) = lower(@MARCA)) AND
	(@MODELO = '' OR @MODELO is null OR lower(A.auto_modelo) LIKE '%' + lower(@MODELO) + '%') AND
	(@PATENTE = '' OR @PATENTE is null OR lower(A.auto_patente) LIKE '%' + lower(@PATENTE) + '%') AND
	(@IDCHOFER = '' OR @IDCHOFER is null OR A.auto_chofer = @IDCHOFER) AND
	A.borrado = 0 AND 
	(@HABILITADO = '' OR @HABILITADO is null OR A.auto_habilitado = @HABILITADO) AND
	(@IDTURNO = '' OR @IDTURNO is null OR A.auto_turno = @IDTURNO);
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

------------------------------ABM TURNO------------------------------

CREATE PROCEDURE [LOSNOOBS].PR_PISA_OTRO_RANGO (@HORAINICIO INTEGER,@HORAFIN INTEGER)
AS
BEGIN TRY
	DECLARE turno CURSOR FOR SELECT T.turno_horaInicio,T.turno_horaFin FROM [LOSNOOBS].TURNO T
	DECLARE @SUBFECHAINICIO INTEGER,@SUBFECHAFIN INTEGER
	OPEN turno
	FETCH NEXT FROM turno INTO @SUBFECHAINICIO, @SUBFECHAFIN
	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		IF(((@HORAINICIO < @SUBFECHAFIN) AND (@HORAINICIO > @SUBFECHAINICIO)) OR((@HORAFIN < @SUBFECHAFIN) AND (@HORAFIN > @SUBFECHAINICIO)))
			  SELECT 'ERROR', ERROR_MESSAGE()
		FETCH NEXT FROM turno INTO @SUBFECHAINICIO, @SUBFECHAFIN
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_PISA_RANGO_DIFERENTE (@HORAINICIO INTEGER,@HORAFIN INTEGER,@DESCRIPCION VARCHAR(255))
AS
BEGIN TRY
	DECLARE turno CURSOR FOR SELECT T.turno_horaInicio,T.turno_horaFin FROM [LOSNOOBS].TURNO T WHERE T.turno_descripcion <>@DESCRIPCION
	DECLARE @SUBFECHAINICIO INTEGER,@SUBFECHAFIN INTEGER
	OPEN turno
	FETCH NEXT FROM turno INTO @SUBFECHAINICIO, @SUBFECHAFIN
	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		IF(((@HORAINICIO < @SUBFECHAFIN) AND (@HORAINICIO > @SUBFECHAINICIO)) OR((@HORAFIN < @SUBFECHAFIN) AND (@HORAFIN > @SUBFECHAINICIO)))
			  SELECT 'ERROR', ERROR_MESSAGE()
		FETCH NEXT FROM turno INTO @SUBFECHAINICIO, @SUBFECHAFIN
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_INSERTAR_TURNO @NOMBRE VARCHAR(255),@PRECIO_BASE numeric(18 ,2), @VALOR_KM numeric(18, 2),@HORA_DESDE INTEGER,@HORA_HASTA INTEGER
AS
BEGIN TRY
	IF(NOT EXISTS(SELECT 1 FROM LOSNOOBS.TURNO T WHERE T.turno_descripcion = @NOMBRE))
		INSERT INTO LOSNOOBS.TURNO(turno_descripcion,turno_precio_base,turno_valor_km,turno_horaInicio,turno_horaFin,turno_habilitado) VALUES(@NOMBRE,@PRECIO_BASE,@VALOR_KM,@HORA_DESDE,@HORA_HASTA,1)
	ELSE
		SELECT 'ERROR', ERROR_MESSAGE()
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].EXISTE_TURNO @NOMBRE VARCHAR(255)
AS
BEGIN TRY
	IF(NOT EXISTS(SELECT 1 FROM LOSNOOBS.TURNO T WHERE T.turno_descripcion = @NOMBRE))
		SELECT 'ERROR', ERROR_MESSAGE()
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_UPDATE_TURNO @NOMBRE VARCHAR(255),@PRECIO_BASE NUMERIC(18, 2), @VALOR_KM NUMERIC(18, 2),@HORA_DESDE INTEGER,@HORA_HASTA INTEGER,@HABILITADO BIT
AS
BEGIN TRY
	IF(EXISTS(SELECT 1 FROM LOSNOOBS.TURNO T WHERE T.turno_descripcion = @NOMBRE))
		UPDATE LOSNOOBS.TURNO SET turno_descripcion = @NOMBRE ,turno_precio_base =@PRECIO_BASE,turno_valor_km = @VALOR_KM,turno_horaInicio=@HORA_DESDE,turno_horaFin=@HORA_HASTA,turno_habilitado=@HABILITADO WHERE turno_descripcion = @NOMBRE
	ELSE
		SELECT 'ERROR', ERROR_MESSAGE()
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_GET_TURNO @DESCRIPCION NVARCHAR(255)
AS
BEGIN TRY
	SELECT T.turno_descripcion DESCRIPCION,T.turno_habilitado Habilitado,T.turno_horaInicio H_Inicio,T.turno_horaFin H_Fin,T.turno_precio_base Precio_Base,T.turno_valor_km Valor_KM FROM [LOSNOOBS].TURNO T WHERE T.turno_descripcion LIKE @DESCRIPCION
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

------------------------------ABM CHOFER------------------------------

CREATE PROCEDURE [LOSNOOBS].PR_BUSCAR_CHOFER_POR_DNI @DNI BIGINT
AS
BEGIN TRY
	SELECT *
	FROM [LOSNOOBS].CHOFER C
	WHERE C.chofer_dni = @DNI
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_LISTADO_SELECCION_ABM_CHOFER @NOMBRE NVARCHAR(255),@APELLIDO NVARCHAR(255),@DNI BIGINT
AS
BEGIN TRY
	SELECT *, chofer_nombre + ' ' + chofer_apellido as NombreCompleto
	FROM [LOSNOOBS].CHOFER C
	WHERE
	(@NOMBRE = '' OR @NOMBRE is null OR  lower(C.chofer_nombre) LIKE '%' + lower(@NOMBRE) + '%') AND
	(@APELLIDO = '' OR @APELLIDO is null OR lower(C.chofer_apellido) LIKE '%' + lower(@APELLIDO) + '%') AND
	(@DNI = '' OR @DNI is null OR C.chofer_dni = @DNI) 
	AND borrado = 0;
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_INSERTAR_MODIFICAR_CHOFER @NOMBRE NVARCHAR (255),@APELLIDO NVARCHAR (255),@DNI BIGINT,@DIRECCION NVARCHAR (255),@TELEFONO NVARCHAR (255),@MAIL NVARCHAR (255),@FECHANAC DATETIME,@HABILITADO BIT
AS
BEGIN TRY
	IF(NOT EXISTS(SELECT 1 FROM CHOFER WHERE CHOFER.chofer_dni = @DNI)) --NUEVO CHOFER
		INSERT INTO [LOSNOOBS].CHOFER(chofer_nombre,chofer_apellido,chofer_dni,chofer_direccion,chofer_telefono,chofer_mail,chofer_fechaNacimiento,chofer_habilitado) VALUES(@NOMBRE ,@APELLIDO ,@DNI,@DIRECCION,@TELEFONO,@MAIL,@FECHANAC,@HABILITADO)
	ELSE
		UPDATE [LOSNOOBS].CHOFER SET chofer_apellido = @APELLIDO,chofer_direccion = @DIRECCION,chofer_dni = @DNI,chofer_fechaNacimiento = @FECHANAC,chofer_mail = @MAIL,chofer_nombre = @NOMBRE,chofer_telefono = @TELEFONO,chofer_habilitado = @HABILITADO WHERE chofer_dni = @DNI
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_BAJA_CHOFER @DNI BIGINT
AS
BEGIN TRY
	UPDATE [LOSNOOBS].CHOFER SET borrado = 1 WHERE CHOFER.chofer_dni = @DNI
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO 
------------------------------REGISTRO VIAJE------------------------------

CREATE FUNCTION [LOSNOOBS].F_PISA_VIAJE (@FECHAINICIO DATETIME,@FECHAFIN DATETIME,@IDCLIENTE INTEGER)
RETURNS BIT
AS
BEGIN
	DECLARE turno CURSOR FOR SELECT V.viaje_fyh_inicio,V.viaje_fyh_fin FROM[LOSNOOBS].VIAJE V WHERE V.viaje_cliente = @IDCLIENTE
	DECLARE @SUBFECHAINICIO DATETIME,@SUBFECHAFIN DATETIME
	OPEN turno
	FETCH NEXT FROM turno INTO @SUBFECHAINICIO, @SUBFECHAFIN
	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		IF(((@FECHAINICIO < @SUBFECHAFIN) AND (@FECHAINICIO >= @SUBFECHAINICIO)) OR((@FECHAFIN <= @SUBFECHAFIN) AND (@FECHAFIN > @SUBFECHAINICIO)))
		BEGIN
			CLOSE turno
			DEALLOCATE turno
			RETURN 1
		END
		FETCH NEXT FROM turno INTO @SUBFECHAINICIO, @SUBFECHAFIN
	END
	CLOSE turno
	DEALLOCATE turno
	RETURN 0
END
GO

CREATE PROCEDURE [LOSNOOBS].PR_REGISTRO_VIAJE @IDCHOFER INTEGER,@IDAUTO INTEGER,@IDTURNO INTEGER,@CANTKM INTEGER,@IDCLIENTE INTEGER,@FECHAHORAINICIO DATETIME,@FECHAHORAFIN DATETIME
AS
BEGIN TRY
	IF([LOSNOOBS].F_PISA_VIAJE(@FECHAHORAINICIO,@FECHAHORAFIN,@IDCLIENTE) = 0)
	BEGIN
		INSERT INTO [LOSNOOBS].VIAJE(viaje_chofer,viaje_auto,viaje_turno,viaje_cantidadKM,viaje_cliente,viaje_fyh_inicio,viaje_fyh_fin) VALUES (@IDCHOFER,@IDAUTO,@IDTURNO,@CANTKM,@IDCLIENTE,@FECHAHORAINICIO,@FECHAHORAFIN)
		RETURN 0
	END
	ELSE
		SELECT -1
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_SELECT_LIST_CHOFERAUTO
AS
BEGIN TRY
	SELECT C.chofer_id IDCHOFER,A.auto_id IDAUTO,C.chofer_dni DNI,C.chofer_apellido APELLIDO,C.chofer_nombre NOMBRE, A.auto_marca MARCA,A.auto_modelo MODELO,A.auto_patente PATENTE FROM [LOSNOOBS].CHOFER C JOIN [LOSNOOBS].AUTOMOVIL A ON(A.auto_chofer = C.chofer_id) 
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_FILTRAR_VIAJES @IDCHOFER INTEGER,@FECHA DATE, @IDTURNO INTEGER
AS
BEGIN TRY
	SELECT *
	FROM [LOSNOOBS].VIAJE v
	WHERE 
	(@IDCHOFER = '' OR @IDCHOFER is null OR v.viaje_chofer = @IDCHOFER) AND
	(@FECHA = '' OR @FECHA is null OR @FECHA BETWEEN CAST(v.viaje_fyh_inicio AS date) AND CAST(v.viaje_fyh_fin as date)) AND
	(@IDTURNO = '' OR @IDTURNO is null OR v.viaje_turno = @IDTURNO);
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

------------------------------RENDICION------------------------------
CREATE PROCEDURE LOSNOOBS.PR_PRECIOS_VIAJE @FECHA DATE, @IDCHOFER INTEGER, @IDTURNO INTEGER
AS
BEGIN
	SELECT	isnull(SUM(v.viaje_cantidadKM), 0) * (SELECT (turno_precio_base/CASE WHEN SUM(v.viaje_cantidadKM) = 0 THEN 1 ELSE SUM(v.viaje_cantidadKM) END) + turno_valor_km FROM LOSNOOBS.TURNO WHERE turno_id = @IDTURNO) as TOTAL
	FROM [LOSNOOBS].VIAJE v
	WHERE 
	v.viaje_chofer = @IDCHOFER AND
	 @FECHA BETWEEN CAST(v.viaje_fyh_inicio AS date) AND CAST(v.viaje_fyh_fin as date) AND
	v.viaje_turno = @IDTURNO
	GROUP BY v.viaje_chofer
END
GO

CREATE PROCEDURE LOSNOOBS.PR_CREAR_RENDICION(@IDCHOFER INT, @IDTURNO INT, @FECHA DATE, @TOTAL DECIMAL(12,2), @PORCENTAJE decimal(12,2))
AS
DECLARE @IDPAGO INTEGER
BEGIN
	IF(EXISTS (SELECT 1 FROM LOSNOOBS.VIAJE V 
					JOIN LOSNOOBS.TURNO T ON(T.turno_id = V.viaje_turno) 
				WHERE	V.viaje_turno = @IDTURNO AND 
						@FECHA BETWEEN CAST(V.viaje_fyh_inicio AS date) AND CAST(V.viaje_fyh_fin as date) AND 
						V.viaje_chofer = @IDCHOFER AND 
						NOT EXISTS (SELECT 1 FROM LOSNOOBS.RENDICION R WHERE R.rendicion_viaje = V.viaje_id)))
		BEGIN
			INSERT INTO LOSNOOBS.PAGO(pago_chofer,pago_turno,pago_fecha,pago_importe) VALUES(@IDCHOFER, @IDTURNO, @FECHA, @TOTAL)
			SET @IDPAGO = SCOPE_IDENTITY();
			INSERT INTO LOSNOOBS.RENDICION(rendicion_pago, rendicion_viaje, rendicion_importe, porcentaje)

			SELECT @IDPAGO, V.viaje_id, ((T.turno_precio_base + T.turno_valor_km * V.viaje_cantidadKM) * @PORCENTAJE), @PORCENTAJE
			FROM LOSNOOBS.VIAJE V 
				JOIN LOSNOOBS.TURNO T ON(T.turno_id = V.viaje_turno) 
			WHERE	T.turno_id = @IDTURNO AND 
					convert(date,V.viaje_fyh_inicio) = @FECHA AND 
					V.viaje_chofer = @IDCHOFER AND 
					NOT EXISTS (SELECT 1 FROM LOSNOOBS.RENDICION R WHERE R.rendicion_viaje = V.viaje_id) 
		END
	ELSE
		SELECT 'ERROR', 'Ya se creó una rendicion de estos viajes.'
END
GO
------------------------------FACTURACION CLIENTE------------------------------
CREATE PROCEDURE LOSNOOBS.PR_CREAR_FACTURA (@FECHAH NVARCHAR(255), @FECHAINICIO NVARCHAR(255) , @FECHAFIN NVARCHAR(255) ,@IDCLIENTE INT, @IMPORTE decimal(18,2) )
AS 
DECLARE @IDFACTURA INT 
BEGIN TRY
	IF((SELECT C.cliente_habilitado FROM LOSNOOBS.CLIENTE C WHERE C.cliente_id = @IDCLIENTE)= 1) 
	BEGIN
		IF(NOT EXISTS (SELECT 1 FROM LOSNOOBS.VIAJE V JOIN LOSNOOBS.CLIENTE C ON(C.cliente_id = V.viaje_cliente) JOIN LOSNOOBS.USUARIO U ON(C.usuario_id = U.usuario_id) WHERE C.cliente_id = @IDCLIENTE AND V.viaje_factura IS NULL AND V.viaje_fyh_inicio<= CONVERT(DATETIME,@FECHAH,120) ))
			 SELECT '0', ERROR_MESSAGE()
		ELSE
		BEGIN
			INSERT INTO LOSNOOBS.FACTURACION(factura_fecha_inicio,factura_fecha_fin,factura_cliente,factura_importe) 
			VALUES(CONVERT(DATETIME,@FECHAINICIO,120),CONVERT(DATETIME,@FECHAFIN,120),@IDCLIENTE,@IMPORTE)
			SET @IDFACTURA = (SELECT MAX(F.factura_id) FROM LOSNOOBS.FACTURACION F)
			
			UPDATE LOSNOOBS.VIAJE SET viaje_factura = @IDFACTURA WHERE viaje_cliente = @IDCLIENTE AND viaje_factura IS NULL AND viaje_fyh_inicio<CONVERT(DATETIME,@FECHAH,120)
			SELECT @FECHAINICIO INICIO,@IDCLIENTE IDCLIENTE,@IMPORTE IMPORTE,V.viaje_fyh_inicio [FECHA INICIO],V.viaje_fyh_fin[FECHA FIN],V.viaje_cantidadKM KMS,
			(SELECT T.turno_precio_base + T.turno_valor_km * V.viaje_cantidadKM FROM LOSNOOBS.TURNO T WHERE T.turno_id = V.viaje_turno) IMPORTE 
			FROM LOSNOOBS.VIAJE V WHERE V.viaje_cliente = @IDCLIENTE AND V.viaje_factura = @IDFACTURA AND V.viaje_fyh_inicio<CONVERT(DATETIME,@FECHAH,120)
			ORDER BY V.viaje_fyh_inicio ASC
		END
	END
	ELSE
		SELECT 'DESHABILITADO', ERROR_MESSAGE()
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_DETALLE_VIAJE_SIN_FACTURA (@IDCLIENTE INTEGER)
AS
BEGIN TRY
	SELECT VIAJE.viaje_cliente as Cliente, MIN(VIAJE.viaje_fyh_inicio) as FechaInicio, MAX(VIAJE.viaje_fyh_fin) as FechaFin, SUM(RENDICION.rendicion_importe) as ImporteTotal
	FROM LOSNOOBS.VIAJE 
	INNER JOIN LOSNOOBS.RENDICION ON RENDICION.rendicion_viaje = VIAJE.viaje_id
	WHERE VIAJE.viaje_factura is null 
	AND VIAJE.viaje_cliente = @IDCLIENTE
	GROUP BY VIAJE.viaje_cliente;
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].PR_FILTRAR_VIAJE_SIN_FACTURA (@IDCLIENTE INTEGER)
AS
BEGIN TRY
	SELECT VIAJE.*
	FROM VIAJE 
	INNER JOIN LOSNOOBS.RENDICION ON RENDICION.rendicion_viaje = VIAJE.viaje_id
	WHERE VIAJE.viaje_factura is null 
	AND VIAJE.viaje_cliente = @IDCLIENTE;
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
------------------------------LISTADO ESTADISTICO------------------------------

CREATE PROCEDURE [LOSNOOBS].[PR_LISTADO_ESTADISTICO] @TIPO INTEGER,@TRIMESTRE INTEGER,@ANIO INTEGER
AS
BEGIN TRY
	IF @TIPO = 1
	BEGIN
		SELECT TOP 5 C.chofer_nombre Nombre,C.chofer_apellido Apellido ,SUM(P.pago_importe) Recaudacion FROM [LOSNOOBS].CHOFER C JOIN [LOSNOOBS].PAGO P ON(P.pago_chofer = C.chofer_id) 
		WHERE	YEAR(P.pago_fecha) = @ANIO AND
				MONTH(P.pago_fecha) BETWEEN (@TRIMESTRE * 3 - 2)  AND @TRIMESTRE * 3

		GROUP BY C.chofer_id,C.chofer_nombre,C.chofer_apellido ORDER BY 3 DESC
	END
	IF @TIPO = 2
	BEGIN
		SELECT TOP 5 C.chofer_nombre Nombre,C.chofer_apellido Apellido, MAX(V.viaje_cantidadKM) [Kms recorridos] 
		FROM [LOSNOOBS].CHOFER C JOIN [LOSNOOBS].VIAJE V ON(V.viaje_chofer = C.chofer_id) 
		WHERE YEAR(V.viaje_fyh_inicio) = @ANIO AND 
			MONTH(V.viaje_fyh_inicio) BETWEEN (@TRIMESTRE * 3 - 2)  AND @TRIMESTRE * 3
		GROUP BY C.chofer_id, C.chofer_nombre, C.chofer_apellido ORDER BY 3 DESC
	END
	IF @TIPO = 3
	BEGIN
		SELECT TOP 5 C.cliente_nombre [Nombre cliente],C.cliente_apellido [Apellido cliente], SUM(F.factura_importe) Consumo 
		FROM [LOSNOOBS].CLIENTE C JOIN [LOSNOOBS].FACTURACION F ON(F.factura_cliente = C.cliente_id) 
		WHERE YEAR(F.factura_fecha_inicio) = @ANIO AND 
		MONTH(F.factura_fecha_inicio) BETWEEN (@TRIMESTRE * 3 - 2)  AND @TRIMESTRE * 3
		GROUP BY C.cliente_id,C.cliente_nombre,C.cliente_apellido ORDER BY 3 DESC
	END
	IF @TIPO = 4
	BEGIN
		SELECT TOP 5 C.cliente_nombre [Nombre cliente],C.cliente_apellido [Apellido cliente], 
		(SELECT TOP 1 COUNT(V2.viaje_auto) Usos FROM [LOSNOOBS].VIAJE V2 
		WHERE V2.viaje_cliente = V.viaje_cliente AND 
		YEAR(V2.viaje_fyh_inicio) = @ANIO 
		AND 
		MONTH(V2.viaje_fyh_inicio) BETWEEN (@TRIMESTRE * 3 - 2)  AND @TRIMESTRE * 3 
		GROUP BY V2.viaje_auto ORDER BY 1 DESC) Usos
		,(
			SELECT TOP 1  CONCAT(CONCAT(A.auto_marca,' '),A.auto_modelo) Auto FROM [LOSNOOBS].VIAJE V2 JOIN LOSNOOBS.AUTOMOVIL A ON(V2.viaje_auto = A.auto_id) 
		
			WHERE V2.viaje_cliente = V.viaje_cliente AND YEAR(V2.viaje_fyh_inicio) = @ANIO AND 
			MONTH(V2.viaje_fyh_inicio) BETWEEN (@TRIMESTRE * 3 - 2)  AND @TRIMESTRE * 3 
			GROUP BY V2.viaje_auto,A.auto_marca,A.auto_modelo ORDER BY 1 DESC) Automovil
			FROM [LOSNOOBS].CLIENTE C JOIN [LOSNOOBS].VIAJE V ON(V.viaje_cliente = C.cliente_id
		) GROUP BY V.viaje_cliente,C.cliente_nombre,C.cliente_apellido ORDER BY 3 DESC
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].[PR_GET_AUTO_CHOFER]
@idUsuario INTEGER
AS
BEGIN TRY
	SELECT CONCAT(CONCAT(A.auto_marca,' '), A.auto_modelo) Nombre,A.auto_id ID FROM [LOSNOOBS].AUTOMOVIL A JOIN [LOSNOOBS].CHOFER C ON(C.chofer_id = A.auto_chofer) WHERE A.auto_chofer = @idUsuario AND A.auto_habilitado = 1 AND C.chofer_habilitado = 1
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [LOSNOOBS].[PR_GET_TURNOS]
AS
BEGIN TRY
	SELECT DISTINCT T.turno_descripcion Nombre,T.turno_id ID FROM [LOSNOOBS].TURNO T
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

EXECUTE LOSNOOBS.PR_DATOS_INSERT_DATOS_INICIALES;
EXECUTE LOSNOOBS.PR_MIGRACION;


