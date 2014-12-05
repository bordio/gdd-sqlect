USE GD2C2014

BEGIN TRANSACTION;
  /* Creamos el esquema */
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'SQLECT')  
EXEC sys.sp_executesql N'CREATE SCHEMA [SQLECT] AUTHORIZATION [gd]'
COMMIT;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Funcionalidades_Roles') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Funcionalidades_Roles

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Funcionalidades') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Funcionalidades

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Roles_Usuarios') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Roles_Usuarios

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Roles') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Roles

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Usuarios_Hoteles') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Usuarios_Hoteles

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Reservas_Canceladas') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Reservas_Canceladas

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Consumibles_Estadias_Habitaciones') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Consumibles_Estadias_Habitaciones

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Regimenes_Hoteles') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Regimenes_Hoteles

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Bajas_por_hotel') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Bajas_por_hotel

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Items') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Items

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Facturas') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Facturas

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Estadias') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Estadias

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Habitaciones_Reservas') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Habitaciones_Reservas

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Reservas') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Reservas

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Regimenes') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Regimenes

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Clientes') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Clientes

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Habitaciones') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Habitaciones

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Tipos_Habitaciones') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Tipos_Habitaciones

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Hoteles') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Hoteles

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Usuarios') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Usuarios

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Empleados') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Empleados

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Consumibles') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Consumibles

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Paises') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Paises


/* Creamos las tablas */

CREATE TABLE SQLECT.Paises(
	id_pais integer PRIMARY KEY identity(1,1),
	nombrePais varchar(50)
)

CREATE TABLE SQLECT.Hoteles (
	id_hotel integer PRIMARY KEY identity(1,1),
	nombre varchar(60),
	mail varchar(255),
	fecha_creacion datetime,
	fk_pais integer REFERENCES SQLECT.Paises (id_pais) DEFAULT 1,	ciudad varchar(30),
	calle varchar(60),
	nro_calle integer,
	cant_estrellas tinyint,
	recarga_estrella smallint
)

CREATE TABLE SQLECT.Bajas_por_hotel(
	id_baja_hotel integer PRIMARY KEY identity(1,1),
	fk_hotel integer REFERENCES SQLECT.Hoteles(id_hotel),
	fecha_inicio DATETIME,
	fecha_fin DATETIME,
	motivo text
)

CREATE TABLE SQLECT.Tipos_Habitaciones(
	id_tipo_habitacion int PRIMARY KEY,
	descripcion varchar(60),
	porcentual decimal(4,2)
)


CREATE TABLE SQLECT.Habitaciones (
	id_habitacion integer PRIMARY KEY identity(1,1),
	fk_hotel integer REFERENCES SQLECT.Hoteles(id_hotel),
	nro_habitacion int,
	piso tinyint,
	frente char(1),
	tipo_habitacion int REFERENCES SQLECT.Tipos_Habitaciones(id_tipo_habitacion),
	descripcion text,
	estado_habitacion tinyint DEFAULT 1 
)


CREATE TABLE SQLECT.Regimenes(
    id_regimen tinyint PRIMARY KEY identity(1,1),
    descripcion varchar(60),
    precio decimal(6,2),
)

CREATE TABLE SQLECT.Regimenes_Hoteles (
    fk_hotel integer references SQLECT.Hoteles(id_hotel),
	fk_regimen tinyint references SQLECT.Regimenes(id_regimen),
	primary key (fk_hotel,fk_regimen)
)

CREATE TABLE SQLECT.Clientes (
    id_cliente INTEGER PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(60),
    apellido VARCHAR(60),
    mail VARCHAR(255),
    telefono integer,
    dom_Calle VARCHAR(90),
    nro_Calle INTEGER,
    piso TINYINT,
    depto VARCHAR(5),
    localidad VARCHAR(60),
    fk_paisOrigen INTEGER,
    fecha_Nac DATETIME,
    nacionalidad VARCHAR(60),
    tipoDocumento VARCHAR(30),
    documento_Nro INTEGER,
    inconsistente TINYINT DEFAULT 0,
    habilitado TINYINT DEFAULT 1,
    foreign key (fk_paisOrigen) references SQLECT.Paises (id_pais)
)

CREATE TABLE SQLECT.Empleados (
	id_empleado smallint identity(1,1) PRIMARY KEY,
	dni_tipo char(4),
	dni_nro integer,
	nombre varchar(30),
	apellido varchar(60),
	email varchar(255),
	telefono integer,
	direccion varchar(90),
	fecha_nacimiento datetime
)


CREATE TABLE SQLECT.Usuarios (
	id_usuario integer PRIMARY KEY identity(1,1),
	usr_name varchar(30) NOT NULL UNIQUE,
	pssword char(64) NOT NULL,
	fk_empleado smallint REFERENCES SQLECT.Empleados(id_empleado),
	estado_usr tinyint DEFAULT 1
 )

CREATE TABLE SQLECT.Reservas (
    id_reserva integer PRIMARY KEY,
    fecha_inicio datetime,
    cant_noches_reserva tinyint,
    cant_noches_estadia tinyint,
    fk_usuario_reserva integer REFERENCES SQLECT.Usuarios (id_usuario),
    fk_usuario_ultima_modificacion integer REFERENCES SQLECT.Usuarios (id_usuario),
    fk_regimen tinyint references SQLECT.Regimenes(id_regimen),
    fk_cliente integer references SQLECT.Clientes(id_cliente),
    estado_reserva tinyint DEFAULT 0,
    fecha_reserva datetime DEFAULT NULL,
    codigo_reserva varchar(9) DEFAULT NULL,
    cantidad_huespedes int DEFAULT 1
)

CREATE TABLE SQLECT.Estadias (
    id_estadia integer PRIMARY KEY identity(1,1),
    fk_reserva integer REFERENCES SQLECT.Reservas(id_reserva),
	fecha_inicio datetime,
	fecha_fin datetime DEFAULT NULL,
	cant_noches tinyint,
	fk_usuario_checkin int DEFAULT NULL REFERENCES SQLECT.Usuarios (id_usuario),
	fk_usuario_checkout int DEFAULT NULL REFERENCES SQLECT.Usuarios (id_usuario)
)

CREATE TABLE SQLECT.Facturas (
    id_factura INTEGER PRIMARY KEY,
    fecha DATETIME,
    total_factura decimal(8,2),
    forma_pago VARCHAR(30),
    detalle_forma_pago VARCHAR(120),
    fk_estadia integer REFERENCES SQLECT.Estadias (id_estadia),
)

CREATE TABLE SQLECT.Consumibles(
    id_consumible INTEGER PRIMARY KEY,
    descripcion VARCHAR(60),
    precio decimal(6,2)
)

CREATE TABLE SQLECT.Items(
    fk_factura INTEGER,
    nro_item INTEGER IDENTITY(1,1),
    fk_consumible INTEGER,
    cantidad_prod INTEGER,
    monto_item decimal(8,2),
    descripcion VARCHAR(30) DEFAULT 'Estadía',
    primary key (fk_factura,nro_item),
    foreign key (fk_consumible) references SQLECT.Consumibles (id_consumible),
    foreign key (fk_factura) references SQLECT.Facturas (id_factura)
)

CREATE TABLE SQLECT.Reservas_Canceladas (
	fk_reserva integer PRIMARY KEY REFERENCES SQLECT.Reservas(id_reserva),
	motivo varchar(120),
	fecha_cancelacion datetime
)

CREATE TABLE SQLECT.Habitaciones_Reservas (
    fk_habitacion integer REFERENCES SQLECT.Habitaciones (id_habitacion),
    fk_reserva integer REFERENCES SQLECT.Reservas (id_reserva),
    estado_ocupacion char(1) DEFAULT 'O' CHECK (estado_ocupacion IN ('D','O')), /*O: Ocupada o Por ocupar; D: Desocupada*/
    PRIMARY KEY (fk_habitacion,fk_reserva)
)

CREATE TABLE SQLECT.Consumibles_Estadias_Habitaciones(
	fk_consumible integer REFERENCES SQLECT.Consumibles (id_consumible),
	fk_estadia integer REFERENCES SQLECT.Estadias (id_estadia),
	fk_habitacion integer REFERENCES SQLECT.Habitaciones (id_habitacion),
	cantidad integer,
	PRIMARY KEY(fk_consumible,fk_estadia,fk_habitacion)

)

CREATE TABLE SQLECT.Roles (
	id_rol tinyint PRIMARY KEY identity(1,1),
	nombre varchar(30),
	descripcion varchar(90),
	estado_rol tinyint DEFAULT 1
 ) 


CREATE TABLE SQLECT.Roles_Usuarios (
    fk_rol tinyint references SQLECT.Roles (id_rol),
    fk_usuario integer references SQLECT.Usuarios (id_usuario),
    cantidadDeIntentos tinyint DEFAULT 0,
	
)


 CREATE TABLE SQLECT.Usuarios_Hoteles (
    fk_hotel integer references SQLECT.Hoteles(id_hotel),
    fk_usuario integer references SQLECT.Usuarios(id_usuario)
)

CREATE TABLE SQLECT.Funcionalidades (
	id_funcion smallint PRIMARY KEY identity(1,1),
	nombre varchar(30),
	descripcion varchar(120),
	estado_func tinyint DEFAULT 1
)

CREATE TABLE SQLECT.Funcionalidades_Roles (
    fk_rol tinyint references SQLECT.Roles(id_rol),
    fk_funcion smallint references SQLECT.Funcionalidades(id_funcion)
)


	/* Migración de datos */
INSERT INTO SQLECT.Paises(nombrePais) VALUES('ARGENTINA')
INSERT INTO SQLECT.Paises(nombrePais) VALUES('URUGUAY')
INSERT INTO SQLECT.Paises(nombrePais) VALUES('CHILE')
INSERT INTO SQLECT.Paises(nombrePais) VALUES('BOLIVIA')
INSERT INTO SQLECT.Paises(nombrePais) VALUES('PARAGUAY')

INSERT INTO SQLECT.Roles(nombre,descripcion) VALUES ('Administrador General','Administra todos los aspectos de la aplicación')
INSERT INTO SQLECT.Roles(nombre,descripcion) VALUES ('Recepcionista','Poseé funcionalidades de atención al público')
INSERT INTO SQLECT.Roles(nombre,descripcion) VALUES	('Administrador','Gestiona el/los hotel/es que tiene a cargo')
INSERT INTO SQLECT.Roles(nombre,descripcion) VALUES ('Guest','Puede realizar y modificar reservas ')


INSERT INTO SQLECT.Usuarios(usr_name, pssword) VALUES('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7') /*Pass hasheada */
INSERT INTO SQLECT.Usuarios(usr_name, pssword) VALUES('guest','84983c60f7daadc1cb8698621f802c0d9f9a3c3c295c810748fb048115c186ec')
INSERT INTO SQLECT.Roles_Usuarios(fk_rol,fk_usuario) VALUES (1,1)
INSERT INTO SQLECT.Roles_Usuarios(fk_rol,fk_usuario) VALUES	(4,2)

INSERT INTO SQLECT.Funcionalidades(nombre, descripcion) VALUES('Gestionar roles','Permite operaciones de alta, baja, y modificaciones de ROLES')
INSERT INTO SQLECT.Funcionalidades(nombre, descripcion) VALUES('Gestionar usuarios','Permite operaciones de alta, baja, y modificaciones de USUARIOS')
INSERT INTO SQLECT.Funcionalidades(nombre, descripcion) VALUES('Gestionar clientes','Permite operaciones de alta, baja, y modificaciones de CLIENTES')
INSERT INTO SQLECT.Funcionalidades(nombre, descripcion) VALUES('Gestionar hoteles','Permite operaciones de alta, baja, y modificaciones de HOTELES')
INSERT INTO SQLECT.Funcionalidades(nombre, descripcion) VALUES('Gestionar habitaciones','Permite operaciones de alta, baja, y modificaciones de HABITACIONES')
INSERT INTO SQLECT.Funcionalidades(nombre, descripcion) VALUES('Generar/modificar reservas','Permite operaciones de alta y modificaciones de RESERVAS')
INSERT INTO SQLECT.Funcionalidades(nombre, descripcion) VALUES('Cancelar reservas', 'Permite cancelaciones de reservas')
INSERT INTO SQLECT.Funcionalidades(nombre, descripcion) VALUES('Gestionar consumibles','Permite operaciones de alta, baja, y modificaciones de CONSUMIBLES')
INSERT INTO SQLECT.Funcionalidades(nombre, descripcion) VALUES('Gestionar estadías','Permite el registro del check-in y check-out de las estadías')
INSERT INTO SQLECT.Funcionalidades(nombre, descripcion) VALUES('Facturación','Permite registrar facturas')
INSERT INTO SQLECT.Funcionalidades(nombre, descripcion) VALUES('Listado estadístico','Permite acceder a datos estadísticos, y emitir informes')


INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,1) /*Funcionalidades del Administrador General*/
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,2)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,3)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,4)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,5)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,6)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,7)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,8)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,9)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,10)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,11)

																		/*Funcionalidades del Recepcionista*/
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(2,3)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(2,6)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(2,7)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(2,8)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(2,9)

																		/*Funcionalidades del Administrador*/
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(3,3)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(3,4)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(3,5)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(3,6)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(3,7)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(3,8)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(3,9)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(3,10)
																	    /*Funcionalidades del Guest*/
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(4,6)


INSERT INTO SQLECT.Hoteles(ciudad,calle,nro_calle,cant_estrellas,recarga_estrella)
	SELECT DISTINCT Hotel_Ciudad,Hotel_Calle,Hotel_Nro_Calle,Hotel_CantEstrella,Hotel_Recarga_Estrella
	FROM gd_esquema.Maestra ORDER BY Hotel_Ciudad;

INSERT INTO SQLECT.Usuarios_Hoteles (fk_hotel,fk_usuario) /*Asignamos todos los hoteles al Administrador General*/
 (SELECT id_hotel,1 FROM SQLECT.Hoteles)

INSERT INTO SQLECT.Tipos_Habitaciones
	SELECT DISTINCT Habitacion_Tipo_Codigo,Habitacion_Tipo_Descripcion,Habitacion_Tipo_Porcentual
	FROM gd_esquema.Maestra

INSERT INTO SQLECT.Habitaciones(fk_hotel,nro_habitacion,frente,piso,tipo_habitacion)
	SELECT DISTINCT h.id_hotel, m.Habitacion_Numero, m.Habitacion_Frente, m.Habitacion_Piso, m.Habitacion_Tipo_Codigo
	FROM gd_esquema.Maestra m JOIN SQLECT.Hoteles h ON 
	  ((h.ciudad = m.Hotel_Ciudad) AND
		(h.calle = m.Hotel_Calle) AND
		(h.nro_calle = m.Hotel_Nro_Calle))
    

INSERT INTO SQLECT.Regimenes(descripcion,precio)
  SELECT DISTINCT Regimen_Descripcion,Regimen_Precio FROM gd_esquema.Maestra;


INSERT INTO SQLECT.Regimenes_Hoteles
	SELECT DISTINCT h.id_hotel,r.id_regimen
	FROM gd_esquema.Maestra m JOIN SQLECT.Regimenes r ON (r.descripcion = m.Regimen_Descripcion) AND (r.precio = m.Regimen_Precio)
		JOIN SQLECT.Hoteles h ON ( (h.ciudad = m.Hotel_Ciudad) AND
		(h.calle = m.Hotel_Calle) AND
		(h.nro_calle = m.Hotel_Nro_Calle) )
	ORDER BY 1

INSERT INTO SQLECT.Clientes (nombre,apellido,mail,dom_Calle,nro_Calle,piso,depto,fecha_Nac,nacionalidad,documento_Nro) 
	(SELECT DISTINCT Cliente_Nombre, Cliente_Apellido, 
	Cliente_Mail, Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso, Cliente_Depto, 
	Cliente_Fecha_Nac, Cliente_Nacionalidad, Cliente_Pasaporte_Nro 
	FROM gd_esquema.Maestra)

UPDATE SQLECT.Clientes SET tipoDocumento = 'PASAPORTE'

INSERT INTO SQLECT.Reservas (id_reserva,fecha_inicio,cant_noches_reserva,fk_regimen,fk_cliente)
	SELECT m.Reserva_Codigo, m.Reserva_Fecha_Inicio, m.Reserva_Cant_Noches, r.id_regimen, c.id_cliente
	FROM gd_esquema.Maestra m JOIN SQLECT.Regimenes r ON (m.Regimen_Descripcion = r.descripcion) AND (m.Regimen_Precio = r.precio)
							  JOIN SQLECT.Clientes c ON (m.Cliente_Fecha_Nac = c.fecha_Nac) AND (m.Cliente_Pasaporte_Nro = c.documento_Nro)
	WHERE m.Estadia_Fecha_Inicio is null

INSERT INTO SQLECT.Estadias(fk_reserva,fecha_inicio,fecha_fin,cant_noches)
 (SELECT DISTINCT Reserva_Codigo,Estadia_Fecha_Inicio,DATEADD(DAY,Estadia_Cant_Noches-1,Estadia_Fecha_Inicio),Estadia_Cant_Noches
     FROM gd_esquema.Maestra
      WHERE Estadia_Fecha_Inicio IS NOT NULL)

INSERT INTO SQLECT.Facturas (id_factura,fecha,total_factura,fk_estadia,forma_pago,detalle_forma_pago)
	(SELECT DISTINCT Factura_Nro, Factura_Fecha, Factura_Total, id_estadia,'Efectivo','Pago en efectivo'
	 FROM gd_esquema.Maestra JOIN SQLECT.Estadias ON (Reserva_Codigo=fk_reserva)
	  WHERE(Factura_Nro IS NOT NULL))

INSERT INTO SQLECT.Consumibles (id_consumible, descripcion, precio)
	(SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
	 FROM gd_esquema.Maestra 
	 WHERE(Consumible_Codigo IS NOT NULL))

INSERT INTO SQLECT.Items (cantidad_prod,monto_item, fk_factura, fk_consumible)
	(SELECT DISTINCT Item_Factura_Cantidad, Item_Factura_Monto, Factura_Nro, Consumible_Codigo
	 FROM gd_esquema.Maestra WHERE Factura_Nro IS NOT NULL)

INSERT INTO SQLECT.Habitaciones_Reservas (fk_habitacion,fk_reserva)
	(SELECT ha.id_habitacion, m.Reserva_Codigo
	FROM SQLECT.Hoteles ho JOIN gd_esquema.Maestra m ON (ho.calle=m.Hotel_Calle AND ho.ciudad=m.Hotel_Ciudad AND ho.nro_calle=m.Hotel_Nro_Calle AND ho.cant_estrellas=m.Hotel_CantEstrella)
				   JOIN SQLECT.Habitaciones ha ON (ha.fk_hotel = ho.id_hotel AND ha.frente=m.Habitacion_Frente AND ha.nro_habitacion=m.Habitacion_Numero AND ha.piso=m.Habitacion_Piso AND ha.tipo_habitacion=m.Habitacion_Tipo_Codigo)
	WHERE m.Estadia_Fecha_Inicio IS NULL)

INSERT INTO SQLECT.Consumibles_Estadias_Habitaciones(fk_estadia,fk_habitacion,fk_consumible,cantidad)
 (SELECT DISTINCT e.id_estadia,hr.fk_habitacion,m.Consumible_Codigo,m.Item_Factura_Cantidad
   FROM gd_esquema.Maestra m JOIN SQLECT.Estadias e ON (e.fk_reserva=m.Reserva_Codigo)
							 JOIN SQLECT.Habitaciones_Reservas hr ON (e.fk_reserva=hr.fk_reserva)							
	   WHERE m.Consumible_Codigo IS NOT NULL )

/*INSERT INTO SQLECT.Consumibles_Estadias_Habitaciones(fk_consumible,fk_estadia)
 (SELECT DISTINCT m.Consumible_Codigo,e.id_estadia
   FROM gd_esquema.Maestra m JOIN SQLECT.Estadias e ON (m.Reserva_Codigo=e.fk_reserva)
							 JOIN SQLECT.Hoteles h ON (h.calle =m.Hotel_Calle AND h.nro_calle=m.Hotel_Nro_Calle AND h.ciudad=m.Hotel_Ciudad)
							 JOIN SQLECT.Habitaciones ha ON (h.id_hotel=ha.fk_hotel)
							
    WHERE m.Consumible_Codigo IS NOT NULL )*/


/* Creación de Procedimientos */         


/*------------------------------------ABM CLIENTE--------------------------------------------------------------------------------------*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.altaCliente'))
DROP PROCEDURE SQLECT.altaCliente

GO
CREATE PROCEDURE SQLECT.altaCliente (@Nombre VARCHAR(60), @Apellido VARCHAR(60), @Mail VARCHAR(255), @Dom_Calle VARCHAR(90), @Nro_Calle INTEGER = null, @Piso TINYINT = null, @Depto VARCHAR(5), @Fecha_Nac DATETIME, @Nacionalidad VARCHAR(60), @Documento_Nro INTEGER,@idReserva int, @tipodocumento VARCHAR(30),@telefono INTEGER = null, @localidad VARCHAR(60), @Pais VARCHAR(50))
AS
BEGIN

	DECLARE @UserId INT
	DECLARE @PersonalDataId INT
	DECLARE @idCliente INT
	DECLARE @idPais INT
	
	SELECT * FROM SQLECT.Clientes C WHERE (C.documento_Nro=@Documento_Nro AND C.tipoDocumento=@tipodocumento) OR C.mail=@Mail
	IF (@@ROWCOUNT >0)
	BEGIN
		RETURN @@ROWCOUNT
	END
	
	SET @idPais = (SELECT id_pais FROM SQLECT.Paises where nombrePais = @Pais) /*podria ser una vista*/

	INSERT INTO SQLECT.Clientes (nombre,apellido,mail,telefono,dom_Calle,nro_Calle,piso,depto,localidad,fk_paisOrigen,fecha_Nac,nacionalidad,documento_Nro,tipoDocumento)
	VALUES (@Nombre, @Apellido, @Mail, @telefono,@Dom_Calle, @Nro_Calle, @Piso, @Depto, @localidad, @idPais ,@Fecha_Nac, @Nacionalidad, @Documento_Nro, @tipodocumento)

SET @idCliente = SCOPE_IDENTITY();
  IF (@idReserva<>0)
	BEGIN
		UPDATE SQLECT.Reservas SET fk_cliente=@idCliente
			WHERE id_reserva=@idReserva
	END

END
GO

/*---------------MODIFICACIONES--------------------------------*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.modificacionCliente'))
DROP PROCEDURE SQLECT.modificacionCliente
GO
CREATE PROCEDURE SQLECT.modificacionCliente (@idCliente INTEGER, @Nombre VARCHAR(60), @Apellido VARCHAR(60), @Mail VARCHAR(255), @Dom_Calle VARCHAR(90), @Nro_Calle INTEGER = null, @Piso TINYINT = null, @Depto VARCHAR(5), @Fecha_Nac DATETIME, @Nacionalidad VARCHAR(60), @Documento_Nro INTEGER, @tipodocumento VARCHAR(30),@telefono INTEGER = null, @localidad VARCHAR(60), @Pais VARCHAR(50))

AS
BEGIN

	DECLARE @idPais INT
	SET @idPais = (SELECT id_pais FROM SQLECT.Paises where nombrePais = @Pais) /*podria ser una vista*/
	
	UPDATE SQLECT.Clientes
	SET nombre=@Nombre, apellido=@Apellido, mail=@Mail, telefono=@telefono, dom_Calle=@Dom_Calle, nro_Calle=@Nro_Calle, piso=@Piso, depto=@Depto, localidad=@localidad, fk_paisOrigen=@idPais,fecha_Nac=@Fecha_Nac, nacionalidad=@Nacionalidad, documento_Nro=@Documento_Nro, tipoDocumento=@tipodocumento
	WHERE id_Cliente=@idCliente
END
GO
/*---------------BAJA LOGICA (Deshabilitar)--------------------*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.inhabilitarCliente'))
DROP PROCEDURE SQLECT.inhabilitarCliente
GO
CREATE PROCEDURE SQLECT.inhabilitarCliente (@Mail VARCHAR(255),@Documento_Nro INTEGER, @tipodocumento VARCHAR(30))
AS
BEGIN
	UPDATE SQLECT.Clientes
	SET habilitado=0
	WHERE mail=@Mail AND documento_Nro=@Documento_Nro AND tipoDocumento=@tipodocumento
END
GO
/*---------------ALTA LOGICA (Habilitar)--------------------*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.habilitarCliente'))
DROP PROCEDURE SQLECT.habilitarCliente
GO
CREATE PROCEDURE SQLECT.habilitarCliente (@Mail VARCHAR(255),@Documento_Nro INTEGER, @tipodocumento VARCHAR(30))
AS
BEGIN
	UPDATE SQLECT.Clientes
	SET habilitado=1
	WHERE mail=@Mail AND documento_Nro=@Documento_Nro AND tipoDocumento=@tipodocumento
END
GO
/*-----------------------------------ABM CLIENTE FIN----------------------------------------------------*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.procInconsistenciasClientes'))
DROP PROCEDURE SQLECT.procInconsistenciasClientes


GO
CREATE PROC SQLECT.procInconsistenciasClientes
AS
BEGIN
	UPDATE SQLECT.Clientes SET inconsistente = 1
		WHERE	documento_Nro IN (SELECT c.documento_Nro
								FROM SQLECT.Clientes c
								GROUP BY c.documento_Nro
								HAVING COUNT(c.mail)>1 )
				OR mail IN		(SELECT c.mail
								FROM SQLECT.Clientes c
								GROUP BY c.mail
								HAVING COUNT(c.documento_Nro)>1 )
END;
GO

EXECUTE SQLECT.procInconsistenciasClientes


/*							
SELECT COUNT(documento_Nro), mail
FROM Clientes
WHERE inconsistente = 1
GROUP BY mail
HAVING COUNT(documento_Nro)>1
ORDER BY COUNT(documento_Nro) DESC 

SELECT COUNT(mail), documento_Nro
FROM Clientes
WHERE inconsistente = 1
GROUP BY documento_Nro
HAVING COUNT(mail)>1
ORDER BY COUNT(mail) DESC 
							


SELECT * from Clientes where inconsistente = 1 order by mail DESC, documento_Nro DESC
*/


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.procEstadoReserva'))
DROP PROCEDURE SQLECT.procEstadoReserva

GO
CREATE PROCEDURE SQLECT.procEstadoReserva
 AS
   BEGIN
	   UPDATE SQLECT.Reservas 
		SET	estado_reserva= 5,   /*Efectivizada*/
			cant_noches_estadia = (	select m.Estadia_Cant_Noches
									from gd_esquema.Maestra m
									where m.Reserva_Codigo = id_reserva AND
									m.Estadia_Fecha_Inicio IS NOT NULL AND
									m.Factura_Nro IS NULL)
		  WHERE id_reserva IN 
			  (SELECT e.fk_reserva FROM SQLECT.Estadias e)
	  
	  UPDATE SQLECT.Reservas
		SET estado_reserva = 4 /* Cancelada por No-Show*/
		 WHERE id_reserva NOT IN
			  (SELECT e.fk_reserva FROM SQLECT.Estadias e)
   END;	        
 GO
 
EXECUTE SQLECT.procEstadoReserva

/*Actualizamos los estados de ocupacion de las habitaciones de cada reserva*/

UPDATE SQLECT.Habitaciones_Reservas SET estado_ocupacion='D'
 WHERE fk_reserva IN (SELECT id_reserva FROM SQLECT.Reservas WHERE estado_reserva IN (2,3,4) )
 
/*Como los hoteles están sin nombre, asumimos como tal su dirección + número de calle*/
BEGIN
IF NOT EXISTS(SELECT DISTINCT nombre FROM SQLECT.Hoteles WHERE nombre<>NULL)
 UPDATE SQLECT.Hoteles SET nombre=calle+' '+ CAST(nro_calle as varchar)
 END
 
/*Actualizo las descripciones de los Items*/
BEGIN
 UPDATE SQLECT.Items SET descripcion='Consumible'
  WHERE fk_consumible IS NOT NULL
END
  
 
/*TOP 5 Reservas canceladas*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.top5HotelesReservasCanceladas'))
DROP PROCEDURE SQLECT.top5HotelesReservasCanceladas

GO
CREATE PROCEDURE SQLECT.top5HotelesReservasCanceladas(@año int,@inicioTri int,@finTri int)
 AS
  BEGIN
SELECT TOP 5 ho.nombre 'Nombre',ho.id_hotel'Id',COUNT(r.id_reserva)'Reservas canceladas' 
  FROM SQLECT.Hoteles ho JOIN SQLECT.Habitaciones ha ON (ho.id_hotel=ha.fk_hotel)
                  JOIN SQLECT.Habitaciones_Reservas hr ON (ha.id_habitacion=hr.fk_habitacion)
                  JOIN SQLECT.Reservas r ON (r.id_reserva=hr.fk_reserva)
    WHERE (r.estado_reserva IN (2,3,4)) AND (YEAR(r.fecha_inicio)=@año) AND (MONTH(r.fecha_inicio) BETWEEN @inicioTri AND @finTri)
      GROUP BY ho.id_hotel,ho.nombre
		ORDER BY 3 DESC

  END
  GO
     
 /* TOP 5 Consumibles Facturados*/   

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.top5HotelesConsumiblesFacturados'))
DROP PROCEDURE SQLECT.top5HotelesConsumiblesFacturados

GO
CREATE PROCEDURE SQLECT.top5HotelesConsumiblesFacturados(@año int,@inicioTri int,@finTri int)
 AS
  BEGIN
SELECT TOP 5 ho.nombre,ho.id_hotel'Id',SUM(i.cantidad_prod)'Consumibles facturados'
  FROM SQLECT.Hoteles ho JOIN SQLECT.Habitaciones ha ON (ho.id_hotel=ha.fk_hotel)
                  JOIN SQLECT.Habitaciones_Reservas hr ON (ha.id_habitacion=hr.fk_habitacion)
                  JOIN SQLECT.Estadias e ON (e.fk_reserva=hr.fk_reserva)
                  JOIN SQLECT.Facturas f ON (f.fk_estadia=e.id_estadia)
                  JOIN SQLECT.Items i ON (i.fk_factura=f.id_factura)
                  JOIN SQLECT.Consumibles c ON (i.fk_consumible=c.id_consumible)
    WHERE ( (YEAR(f.fecha)=@año) AND (MONTH(f.fecha) BETWEEN @inicioTri AND @finTri))
	GROUP BY ho.id_hotel,ho.nombre
		ORDER BY 3 DESC
  END	
GO

/* TOP 5 Hoteles fuera de Servicio */


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.top5HotelesFueraDeServicio'))
DROP PROCEDURE SQLECT.top5HotelesFueraDeServicio

GO
CREATE PROCEDURE SQLECT.top5HotelesFueraDeServicio (@año int, @inicioTri int, @finTri int)
AS

 BEGIN
SELECT TOP 5 h.nombre,b.fk_hotel'Id',SUM(DATEDIFF(day,b.fecha_fin,b.fecha_inicio))'Días fuera de servicio'
   FROM SQLECT.Bajas_por_hotel b JOIN SQLECT.Hoteles h ON (h.id_hotel=b.fk_hotel)
    WHERE ( (YEAR(b.fecha_inicio)=YEAR(b.fecha_fin)) AND (MONTH(b.fecha_inicio) >= @inicioTri AND MONTH(b.fecha_fin)<= @finTri) )
    
    GROUP BY b.fk_hotel,h.nombre
		ORDER BY 3 DESC
  END
GO  		
		

 /* TOP 5 Habitaciones más ocupadas */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.top5HabitacionesMasOcupadas'))
DROP PROCEDURE SQLECT.top5HabitacionesMasOcupadas

GO
CREATE PROCEDURE SQLECT.top5HabitacionesMasOcupadas (@año int,@inicioTri int, @finTri int)
AS
BEGIN
SELECT TOP 5 ha.nro_habitacion'Habitacion', ho.nombre'Hotel',SUM(r.cant_noches_estadia)'Días ocupada'
  FROM SQLECT.Reservas r JOIN SQLECT.Habitaciones_Reservas hr ON (r.id_reserva=hr.fk_reserva)
						 JOIN SQLECT.Habitaciones ha ON (ha.id_habitacion=hr.fk_habitacion)
						 JOIN SQLECT.Hoteles ho ON (ho.id_hotel=ha.fk_hotel)
    WHERE ( (YEAR(r.fecha_inicio)=@año) AND (MONTH(r.fecha_inicio) BETWEEN @inicioTri AND @finTri) )
    GROUP BY ha.nro_habitacion,ho.nombre
		ORDER BY 3 DESC
 END
 GO	

/* TOP 5 Clientes mejores puntuados*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.top5ClientesMejoresPuntuados'))
DROP PROCEDURE SQLECT.top5ClientesMejoresPuntuados

GO
CREATE PROCEDURE SQLECT.top5ClientesMejoresPuntuados (@año int,@inicioTri int, @finTri int)
AS
BEGIN

SELECT TOP 5 cl.id_cliente'Id',cl.nombre'Nombre',cl.apellido'Apellido',SUM( ((re.precio*r.cant_noches_estadia)/10)+((i.cantidad_prod*c.precio)/5) )'Puntos'
  FROM SQLECT.Clientes cl JOIN SQLECT.Reservas r ON (r.fk_cliente=cl.id_cliente)
				   JOIN SQLECT.Regimenes re ON (r.fk_regimen=re.id_regimen)
				   JOIN SQLECT.Estadias e ON (e.fk_reserva=r.id_reserva)
				   JOIN SQLECT.Facturas f ON (e.id_estadia=f.fk_estadia)
				   JOIN SQLECT.Items i ON (i.fk_factura=f.id_factura)
				   JOIN SQLECT.Consumibles c ON (c.id_consumible=i.fk_consumible)
	WHERE ( (YEAR(f.fecha)=@año) AND (MONTH(f.fecha) BETWEEN @inicioTri AND @finTri) )
	
	GROUP BY cl.id_cliente,cl.nombre,cl.apellido
		ORDER BY 4 DESC

 END
 GO 
 
 /*Login - Compruebo si se loguea correctamente*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.validarExistenciaDeUsuarioYRol'))
DROP PROCEDURE SQLECT.validarExistenciaDeUsuarioYRol

GO
CREATE PROCEDURE SQLECT.validarExistenciaDeUsuarioYRol (@usuario varchar(30),@rol varchar(30))
AS
BEGIN
 SELECT * FROM SQLECT.Usuarios u JOIN SQLECT.Roles_Usuarios ru ON (u.id_usuario=ru.fk_usuario)
								 JOIN SQLECT.Roles r ON (r.id_rol=ru.fk_rol)
 WHERE u.usr_name=@usuario AND r.nombre=@rol
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.validarUsuarioLogin'))
DROP PROCEDURE SQLECT.validarUsuarioLogin

GO
CREATE PROCEDURE SQLECT.validarUsuarioLogin (@usuario varchar(30),@password char(64),@rol varchar(30))
AS
BEGIN
 SELECT * FROM SQLECT.Usuarios u JOIN SQLECT.Roles_Usuarios ru ON (u.id_usuario=ru.fk_usuario)
								 JOIN SQLECT.Roles r ON (r.id_rol=ru.fk_rol)
		WHERE r.nombre=@rol AND u.usr_name=@usuario AND u.pssword=@password AND u.estado_usr=1 AND r.estado_rol=1 AND ru.cantidadDeIntentos<3
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.validarPassword'))
DROP PROCEDURE SQLECT.validarPassword

GO
CREATE PROCEDURE SQLECT.validarPassword(@usuario varchar(30), @password char(64))
AS
BEGIN
 SELECT u.id_usuario FROM SQLECT.Usuarios u WHERE u.usr_name=@usuario AND u.pssword=@password
 END
 GO
 
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.modificarPassword'))
DROP PROCEDURE SQLECT.modificarPassword

GO
CREATE PROCEDURE SQLECT.modificarPassword(@usuario varchar(30),@passwordNueva char(64))
AS
BEGIN
UPDATE SQLECT.Usuarios  SET pssword=@passwordNueva WHERE usr_name=@usuario
END
GO 


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerIDUsuario'))
DROP PROCEDURE SQLECT.obtenerIDUsuario

GO
CREATE PROCEDURE SQLECT.obtenerIDUsuario (@usuario varchar(30))
AS
BEGIN 
 SELECT u.id_usuario FROM SQLECT.Usuarios u WHERE u.usr_name=@usuario
 END
 GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerIDHotel'))
DROP PROCEDURE  SQLECT.obtenerIDHotel

GO
CREATE PROCEDURE SQLECT.obtenerIDHotel(@hotel varchar(60))
AS
BEGIN
 SELECT id_hotel FROM SQLECT.Hoteles WHERE nombre=@hotel
 END
 GO
 
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerNombreHotel'))
DROP PROCEDURE SQLECT.obtenerNombreHotel  

GO
CREATE PROCEDURE SQLECT.obtenerNombreHotel (@idHotel int)
AS
BEGIN
SELECT nombre FROM SQLECT.Hoteles WHERE id_hotel=@idHotel
END
GO
 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.verificarIntentos'))
DROP PROCEDURE SQLECT.verificarIntentos

GO
CREATE PROCEDURE SQLECT.verificarIntentos (@usuario varchar(30),@rol varchar(30))
AS
BEGIN
SELECT ru.cantidadDeIntentos 
	FROM SQLECT.Roles_Usuarios ru JOIN SQLECT.Roles r ON (ru.fk_rol=r.id_rol)
								  JOIN SQLECT.Usuarios u ON (u.id_usuario=ru.fk_rol)
WHERE u.usr_name=@usuario AND r.nombre=@rol
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.actualizarIntentosFallidos'))
DROP PROCEDURE SQLECT.actualizarIntentosFallidos

GO
CREATE PROCEDURE SQLECT.actualizarIntentosFallidos (@usuario varchar(30),@rol varchar(30))
AS
BEGIN 
UPDATE SQLECT.Roles_Usuarios SET cantidadDeIntentos=cantidadDeIntentos+1
 WHERE fk_usuario IN (SELECT u.id_usuario FROM SQLECT.Usuarios u JOIN SQLECT.Roles_Usuarios ru ON (ru.fk_usuario=u.id_usuario)
																 JOIN SQLECT.Roles r ON (r.id_rol=ru.fk_rol)
									WHERE u.usr_name=@usuario AND r.nombre=@rol)
	AND fk_rol IN (SELECT r.id_rol FROM SQLECT.Usuarios u JOIN SQLECT.Roles_Usuarios ru ON (ru.fk_usuario=u.id_usuario)
																 JOIN SQLECT.Roles r ON (r.id_rol=ru.fk_rol)
									WHERE u.usr_name=@usuario AND r.nombre=@rol)
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.inhabilitarUsuario'))
DROP PROCEDURE SQLECT.inhabilitarUsuario

GO
CREATE PROCEDURE SQLECT.inhabilitarUsuario (@usuario varchar(30) ,@rol varchar(30))
AS
BEGIN
UPDATE SQLECT.Usuarios SET estado_usr=0
WHERE usr_name=@usuario

/* WHERE fk_usuario IN (SELECT u.id_usuario FROM SQLECT.Usuarios u JOIN SQLECT.Roles_Usuarios ru ON (ru.fk_usuario=u.id_usuario)
																 JOIN SQLECT.Roles r ON (r.id_rol=ru.fk_rol)
									WHERE u.usr_name=@usuario AND r.nombre=@rol)
	AND fk_rol IN (SELECT r.id_rol FROM SQLECT.Usuarios u JOIN SQLECT.Roles_Usuarios ru ON (ru.fk_usuario=u.id_usuario)
																 JOIN SQLECT.Roles r ON (r.id_rol=ru.fk_rol)
									WHERE u.usr_name=@usuario AND r.nombre=@rol)
END
GO*/ --Posible alternativa.
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.resetearCantidadDeIntentos'))
DROP PROCEDURE SQLECT.resetearCantidadDeIntentos

GO
CREATE PROCEDURE SQLECT.resetearCantidadDeIntentos (@usuario varchar(30) ,@rol varchar(30))
AS
BEGIN
UPDATE SQLECT.Roles_Usuarios SET cantidadDeIntentos=0
 WHERE fk_usuario IN (SELECT u.id_usuario FROM SQLECT.Usuarios u JOIN SQLECT.Roles_Usuarios ru ON (ru.fk_usuario=u.id_usuario)
																 JOIN SQLECT.Roles r ON (r.id_rol=ru.fk_rol)
									WHERE u.usr_name=@usuario AND r.nombre=@rol)
	AND fk_rol IN (SELECT r.id_rol FROM SQLECT.Usuarios u JOIN SQLECT.Roles_Usuarios ru ON (ru.fk_usuario=u.id_usuario)
																 JOIN SQLECT.Roles r ON (r.id_rol=ru.fk_rol)
									WHERE u.usr_name=@usuario AND r.nombre=@rol)
END
GO


/* ABM Hoteles */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.Reservas_Hoteles_Vista'))
DROP VIEW SQLECT.Reservas_Hoteles_Vista

GO

CREATE VIEW SQLECT.Reservas_Hoteles_Vista AS (
SELECT res.id_reserva, hab.fk_hotel 'id_hotel'
FROM SQLECT.Habitaciones hab, SQLECT.Habitaciones_Reservas habres, SQLECT.Reservas res
WHERE (hab.id_habitacion = habres.fk_habitacion) AND (habres.fk_reserva = res.id_reserva))

GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.altaHotel'))
DROP PROCEDURE SQLECT.altaHotel

GO
CREATE PROCEDURE SQLECT.altaHotel (@nombre VARCHAR(60), @email VARCHAR(255),
									 @cant_estrellas INT, @fecha_creacion DATETIME = null, @pais VARCHAR(100),
									 @ciudad VARCHAR(100), @calle VARCHAR(100), @nro_calle INT,
									 @all_inclusive INT, @all_inclusive_moderado INT, @pension_completa INT, @media_pension INT, @id_usuario INT)
AS
BEGIN

	DECLARE @HotelId INT
	DECLARE @PaisId INT
	
	SET @PaisId = (SELECT id_pais FROM SQLECT.Paises WHERE nombrePais=@pais)
	
	INSERT INTO SQLECT.Hoteles (nombre, mail, fecha_creacion, ciudad, calle, nro_calle, cant_estrellas, recarga_estrella, fk_pais)
	VALUES (@nombre, @email, @fecha_creacion, @ciudad, @calle, @nro_calle, @cant_estrellas, 10, @PaisId)
	
	SET @HotelId = SCOPE_IDENTITY()
	
	IF (@all_inclusive=	1) INSERT INTO SQLECT.Regimenes_Hoteles(fk_hotel,fk_regimen) VALUES (@HotelId,3)
	IF (@all_inclusive_moderado=1) INSERT INTO SQLECT.Regimenes_Hoteles(fk_hotel,fk_regimen) VALUES (@HotelId,4)
	IF (@pension_completa=1) INSERT INTO SQLECT.Regimenes_Hoteles(fk_hotel,fk_regimen) VALUES (@HotelId,1)
	IF (@media_pension=1) INSERT INTO SQLECT.Regimenes_Hoteles(fk_hotel,fk_regimen) VALUES (@HotelId,2)
	
	INSERT INTO SQLECT.Usuarios_Hoteles(fk_hotel,fk_usuario) VALUES (@HotelId,@id_usuario)
	
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.bajaHotel'))
DROP PROCEDURE SQLECT.bajaHotel

GO
CREATE PROCEDURE SQLECT.bajaHotel (@id_hotel INT, @desde DATETIME, @hasta DATETIME, @motivo TEXT)
AS
BEGIN

	INSERT INTO SQLECT.Bajas_por_hotel(fk_hotel, fecha_inicio, fecha_fin, motivo) VALUES (@id_hotel,@desde,@hasta,@motivo)
END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.funcPuedoQuitarRegimen'))
DROP FUNCTION SQLECT.funcPuedoQuitarRegimen

GO
CREATE FUNCTION SQLECT.funcPuedoQuitarRegimen (@id_hotel INT, @regimen VARCHAR(60), @fecha DATETIME)
RETURNS INT
AS
BEGIN

DECLARE @idReg INT
DECLARE @ret INT

SET @idReg = (SELECT id_regimen FROM SQLECT.Regimenes WHERE descripcion = @regimen)

IF EXISTS
(SELECT * FROM SQLECT.Reservas res, SQLECT.Reservas_Hoteles_Vista rhv
 WHERE (fk_regimen = @idReg) AND (rhv.id_hotel = @id_hotel) AND (rhv.id_reserva = res.id_reserva)
 AND DATEADD(day,cant_noches_reserva,fecha_inicio) > @fecha AND estado_reserva IN (0,1,5))
 BEGIN
	SET @ret = 0
 END
ELSE
 BEGIN
	SET @ret = 1	
 END
RETURN @ret
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.modificacionHotel'))
DROP PROCEDURE SQLECT.modificacionHotel

GO
CREATE PROCEDURE SQLECT.modificacionHotel (@id_hotel INT, @nombre VARCHAR(60), @email VARCHAR(255),
									 @cant_estrellas INT, @fecha_creacion DATETIME = null, @pais VARCHAR(100),
									 @ciudad VARCHAR(100), @calle VARCHAR(100), @nro_calle INT, 
									 @all_inclusive INT, @all_inclusive_moderado INT, @pension_completa INT, @media_pension INT)
AS
BEGIN

	DECLARE @PaisID INT
	
	SET @PaisID = (SELECT id_pais FROM Paises WHERE nombrePais=@pais)

	UPDATE SQLECT.Hoteles SET nombre = @nombre, mail = @email, fecha_creacion = @fecha_creacion,
	 ciudad = @ciudad, calle = @calle, nro_calle = @nro_calle, cant_estrellas = @cant_estrellas, fk_pais = @PaisID
	 WHERE id_hotel=@id_hotel
	
	IF (@all_inclusive=0) DELETE FROM SQLECT.Regimenes_Hoteles WHERE fk_hotel=@id_hotel AND fk_regimen=3
	ELSE 
		BEGIN
			IF NOT EXISTS(SELECT fk_hotel,fk_regimen FROM SQLECT.Regimenes_Hoteles WHERE fk_hotel=@id_hotel AND fk_regimen=3)
				INSERT INTO SQLECT.Regimenes_Hoteles(fk_hotel,fk_regimen) VALUES (@id_hotel,3)
		END;
	IF (@all_inclusive_moderado=0) DELETE FROM SQLECT.Regimenes_Hoteles WHERE fk_hotel=@id_hotel AND fk_regimen=4
	ELSE 
		BEGIN
			IF NOT EXISTS(SELECT fk_hotel,fk_regimen FROM SQLECT.Regimenes_Hoteles WHERE fk_hotel=@id_hotel AND fk_regimen=4)
				INSERT INTO SQLECT.Regimenes_Hoteles(fk_hotel,fk_regimen) VALUES (@id_hotel,4)
		END;
	IF (@pension_completa=0) DELETE FROM SQLECT.Regimenes_Hoteles WHERE fk_hotel=@id_hotel AND fk_regimen=1
	ELSE
		BEGIN
			IF NOT EXISTS(SELECT fk_hotel,fk_regimen FROM SQLECT.Regimenes_Hoteles WHERE fk_hotel=@id_hotel AND fk_regimen=1)
				 INSERT INTO SQLECT.Regimenes_Hoteles(fk_hotel,fk_regimen) VALUES (@id_hotel,1)
		END;
	IF (@media_pension=0) DELETE FROM SQLECT.Regimenes_Hoteles WHERE fk_hotel=@id_hotel AND fk_regimen=2
	ELSE
		BEGIN
			IF NOT EXISTS(SELECT fk_hotel,fk_regimen FROM SQLECT.Regimenes_Hoteles WHERE fk_hotel=@id_hotel AND fk_regimen=2)
				 INSERT INTO SQLECT.Regimenes_Hoteles(fk_hotel,fk_regimen) VALUES (@id_hotel,2)
		END;
END

GO


/* ABM de Habitaciones */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.Habitaciones_Vista'))
DROP VIEW SQLECT.Habitaciones_Vista

GO

CREATE VIEW SQLECT.Habitaciones_Vista AS 
(SELECT ho.id_hotel, th.id_tipo_habitacion, hab.id_habitacion, ho.nombre "hotel", hab.nro_habitacion, hab.piso, hab.frente, th.descripcion "tipo_habitacion", CASE hab.estado_habitacion WHEN 1 THEN 'SI' ELSE 'NO' END "activado"
FROM SQLECT.Habitaciones hab, SQLECT.Hoteles ho, SQLECT.Tipos_Habitaciones th
WHERE (hab.fk_hotel = ho.id_hotel) AND (hab.tipo_habitacion = th.id_tipo_habitacion))

GO

/* Alta habitacion */
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.altaHabitacion'))
DROP PROCEDURE SQLECT.altaHabitacion

GO
CREATE PROCEDURE SQLECT.altaHabitacion (@nro_habitacion INT, @fk_hotel INT,
									 @piso INT, @frente CHAR, @tipo_habitacion INT, @descripcion TEXT)
AS
BEGIN
	
	INSERT INTO SQLECT.Habitaciones (nro_habitacion, fk_hotel, piso, frente, tipo_habitacion, descripcion)
	VALUES (@nro_habitacion, @fk_hotel, @piso, @frente, @tipo_habitacion, @descripcion)
	
END
GO

/* Modificacion habitacion */
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.modificacionHabitacion'))
DROP PROCEDURE SQLECT.modificacionHabitacion

GO
CREATE PROCEDURE SQLECT.modificacionHabitacion (@id_habitacion INT,@nro_habitacion INT, @fk_hotel INT,
									 @piso INT, @frente CHAR, @descripcion TEXT)
AS
BEGIN
	
	UPDATE SQLECT.Habitaciones SET nro_habitacion=@nro_habitacion, fk_hotel=@fk_hotel, piso=@piso, frente=@frente, descripcion=@descripcion
	WHERE id_habitacion=@id_habitacion
	
END
GO

/* Baja temporal de habitacion */
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.actualizacionEstadoHabitacion'))
DROP PROCEDURE SQLECT.actualizacionEstadoHabitacion

GO
CREATE PROCEDURE SQLECT.actualizacionEstadoHabitacion (@id_habitacion INT, @estado_habitacion INT)
AS
BEGIN
	
	UPDATE SQLECT.Habitaciones SET estado_habitacion=@estado_habitacion WHERE id_habitacion=@id_habitacion
	
END
GO

/* --- FIN ABM HABITACIONES ---*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.buscarHotelesDisponibles'))
DROP PROCEDURE SQLECT.buscarHotelesDisponibles

GO
CREATE PROCEDURE SQLECT.buscarHotelesDisponibles (@usuario varchar(30),@fechaDelSistema varchar(9))
AS
BEGIN
SELECT DISTINCT h.nombre FROM SQLECT.Usuarios_Hoteles uh LEFT JOIN SQLECT.Bajas_por_hotel bh ON (uh.fk_hotel=bh.fk_hotel)
															  JOIN SQLECT.Usuarios u ON (uh.fk_usuario=u.id_usuario)
												              JOIN SQLECT.Hoteles h ON (h.id_hotel=uh.fk_hotel)
 WHERE u.usr_name=@usuario AND ( ( (@fechaDelSistema NOT BETWEEN bh.fecha_inicio AND bh.fecha_fin) AND (@fechaDelSistema NOT BETWEEN bh.fecha_inicio AND bh.fecha_fin) AND (@fechaDelSistema>bh.fecha_fin OR @fechaDelSistema<bh.fecha_inicio) ) OR (bh.fecha_inicio IS NULL AND bh.fecha_fin IS NULL) )
END
GO

/*Listado de funcionalidades de un rol*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.listarFuncionalidades'))
DROP PROCEDURE SQLECT.listarFuncionalidades

GO
CREATE PROCEDURE SQLECT.listarFuncionalidades(@nombreRol varchar(30))
AS
BEGIN
SELECT f.nombre,f.descripcion 
   FROM SQLECT.Funcionalidades f JOIN SQLECT.Funcionalidades_Roles fr ON (f.id_funcion=fr.fk_funcion) 
								 JOIN SQLECT.Roles r ON (r.id_rol=fr.fk_rol) 
   WHERE r.nombre=@nombreRol AND f.estado_func=1
END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.altaUsuario'))
DROP PROCEDURE SQLECT.altaUsuario

GO
CREATE PROCEDURE SQLECT.altaUsuario(@username varchar(30), @password varchar(64),@rol varchar(30),@nombre varchar(30),@apellido varchar(60),@tipoDoc char(4), @numeroDoc int, @mail varchar(255),@telefono int,@direccion varchar(90),@fechaNacimiento datetime,@hotelDesempeño varchar(60))
AS
BEGIN

DECLARE @fkDeEmpleado int,@fkDeUsuario int, @fkDeRol tinyint, @fkDeHotel int

INSERT INTO SQLECT.Empleados (dni_tipo,dni_nro,nombre,apellido,email,telefono,direccion,fecha_nacimiento)
                      VALUES (@tipoDoc,@numeroDoc,@nombre,@apellido,@mail,@telefono,@direccion,@fechaNacimiento)
SET @fkDeEmpleado = SCOPE_IDENTITY();

INSERT INTO SQLECT.Usuarios (usr_name,pssword) VALUES (@username,@password)
SET @fkDeUsuario = SCOPE_IDENTITY();

UPDATE SQLECT.Usuarios SET fk_empleado = @fkDeEmpleado
 WHERE id_usuario=@fkDeUsuario
 
SET @fkDeRol = (SELECT r.id_rol FROM SQLECT.Roles r WHERE r.nombre=@rol)
INSERT INTO SQLECT.Roles_Usuarios (fk_usuario,fk_rol) VALUES (@fkDeUsuario,@fkDeRol)

SET @fkDeHotel = (SELECT id_hotel FROM SQLECT.Hoteles WHERE nombre=@hotelDesempeño)
IF NOT EXISTS (SELECT * FROM SQLECT.Usuarios_Hoteles WHERE fk_hotel=@fkDeHotel AND fk_usuario=@fkDeUsuario)
  INSERT INTO SQLECT.Usuarios_Hoteles(fk_usuario,fk_hotel) VALUES (@fkDeUsuario,@fkDeHotel)

END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.darDeBajaUsuario'))
DROP PROCEDURE SQLECT.darDeBajaUsuario

GO
CREATE PROCEDURE SQLECT.darDeBajaUsuario(@usuario varchar(30))
AS
BEGIN
DECLARE @id_usuario int
 
 UPDATE SQLECT.Usuarios SET estado_usr=0 WHERE usr_name=@usuario
 
 SET @id_usuario= (SELECT id_usuario FROM SQLECT.Usuarios WHERE usr_name=@usuario)
 DELETE FROM SQLECT.Usuarios_Hoteles WHERE fk_usuario=@id_usuario
 
 DELETE FROM SQLECT.Roles_Usuarios WHERE fk_usuario=@id_usuario
 
END
 GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.chequearUsuarioConHotelAsignado'))
DROP PROCEDURE  SQLECT.chequearUsuarioConHotelAsignado
 
 GO
 CREATE PROCEDURE  SQLECT.chequearUsuarioConHotelAsignado (@usuario varchar(30),@nombreHotel varchar(60))
 AS
 BEGIN
 SELECT h.nombre FROM SQLECT.Usuarios u JOIN SQLECT.Usuarios_Hoteles uh ON (u.id_usuario=uh.fk_usuario)
                                        JOIN SQLECT.Hoteles h ON (h.id_hotel=uh.fk_hotel)
       WHERE h.nombre=@nombreHotel AND u.usr_name=@usuario
  END
  GO
  
 IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.modificarDatosDelUsuario'))
DROP PROCEDURE  SQLECT.modificarDatosDelUsuario

GO
CREATE PROCEDURE SQLECT.modificarDatosDelUsuario(@username varchar(30),@nombre varchar(30),@apellido varchar(60),@tipoDoc char(4),@numeroDoc int,@mail varchar(255),@telefono int,@direccion varchar(90),@fechaNacimiento datetime)
AS
BEGIN

DECLARE @id_empleado int,@fkPosibleDeEmpleado int

SET @id_empleado = (SELECT fk_empleado FROM SQLECT.Usuarios WHERE usr_name=@username)

 IF (@id_empleado IS NOT NULL)
BEGIN

UPDATE SQLECT.Empleados SET nombre=@nombre,apellido=@apellido,dni_tipo=@tipoDoc,dni_nro=@numeroDoc,email=@mail,telefono=@telefono,direccion=@direccion,fecha_nacimiento=@fechaNacimiento
 WHERE id_empleado=@id_empleado
END
 ELSE
 
  BEGIN
INSERT INTO SQLECT.Empleados(nombre,apellido,dni_tipo,dni_nro,email,telefono,direccion,fecha_nacimiento) VALUES (@nombre,@apellido,@tipoDoc,@numeroDoc,@mail,@telefono,@direccion,@fechaNacimiento)
SET @fkPosibleDeEmpleado=SCOPE_IDENTITY();
UPDATE SQLECT.Usuarios SET fk_empleado=@fkPosibleDeEmpleado WHERE usr_name=@username
  END

 END
GO

 IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.quitarHotelDeUsuario'))
DROP PROCEDURE  SQLECT.quitarHotelDeUsuario

GO
CREATE PROCEDURE SQLECT.quitarHotelDeUsuario(@username varchar(30),@nombreHotel varchar(60))
AS
BEGIN
DECLARE @id_usuaio int, @id_hotel int

SET @id_usuaio=(SELECT id_usuario FROM SQLECT.Usuarios WHERE usr_name=@username)
SET @id_hotel =(SELECT id_hotel FROM SQLECT.Hoteles WHERE nombre=@nombreHotel)

DELETE FROM SQLECT.Usuarios_Hoteles
 WHERE fk_hotel=@id_hotel AND fk_usuario=@id_usuaio
 END
 GO


 IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.agregarHotelAlUsuario'))
DROP PROCEDURE  SQLECT.agregarHotelAlUsuario

GO
CREATE PROCEDURE SQLECT.agregarHotelAlUsuario(@username varchar(30),@nombreHotel varchar(60))
AS
BEGIN

DECLARE @id_usuaio int, @id_hotel int
SET @id_usuaio=(SELECT id_usuario FROM SQLECT.Usuarios WHERE usr_name=@username)
SET @id_hotel =(SELECT id_hotel FROM SQLECT.Hoteles WHERE nombre=@nombreHotel)

IF NOT EXISTS(SELECT fk_usuario,fk_hotel FROM SQLECT.Usuarios_Hoteles WHERE fk_usuario=@id_usuaio AND fk_hotel=@id_hotel)
 INSERT INTO SQLECT.Usuarios_Hoteles(fk_hotel,fk_usuario) VALUES (@id_hotel,@id_usuaio)
 
END
GO

 IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.quitarRolDelUsuario'))
DROP PROCEDURE  SQLECT.quitarRolDelUsuario

GO
CREATE PROCEDURE SQLECT.quitarRolDelUsuario (@username varchar(30),@rol varchar(30))
AS
BEGIN
DECLARE @id_usuaio int,@id_rol int

SET @id_usuaio=(SELECT id_usuario FROM SQLECT.Usuarios WHERE usr_name=@username)
SET @id_rol= (SELECT id_rol FROM SQLECT.Roles WHERE nombre=@rol)

DELETE FROM SQLECT.Roles_Usuarios WHERE fk_rol=@id_rol AND fk_usuario=@id_usuaio
END
GO

 IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.agregarRolAlUsuario'))
DROP PROCEDURE SQLECT.agregarRolAlUsuario

GO
CREATE PROCEDURE SQLECT.agregarRolAlUsuario(@username varchar(30),@nombreRol varchar(30))
AS
BEGIN

DECLARE @id_usuaio int, @id_rol int
SET @id_usuaio=(SELECT id_usuario FROM SQLECT.Usuarios WHERE usr_name=@username)
SET @id_rol =(SELECT id_rol FROM SQLECT.Roles WHERE nombre=@nombreRol)

IF NOT EXISTS (SELECT * FROM SQLECT.Roles_Usuarios WHERE fk_rol=@id_rol AND fk_usuario=@id_usuaio)
 INSERT INTO SQLECT.Roles_Usuarios(fk_usuario,fk_rol) VALUES (@id_usuaio,@id_rol)
 
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerMaximasHabitacionesDisponibles'))
DROP PROCEDURE SQLECT.obtenerMaximasHabitacionesDisponibles

GO
CREATE PROCEDURE SQLECT.obtenerMaximasHabitacionesDisponibles(@fechaDesde datetime, @fechaHasta datetime,@idHotel int)
AS
BEGIN
      
SELECT h.tipo_habitacion 'Tipo', COUNT(DISTINCT h.id_habitacion) 'Cant.' FROM SQLECT.Habitaciones h LEFT JOIN SQLECT.Bajas_por_hotel bh ON (h.fk_hotel=bh.fk_hotel)
      WHERE id_habitacion NOT IN
		(
			SELECT DISTINCT h.id_habitacion FROM SQLECT.Habitaciones h
				JOIN SQLECT.Habitaciones_Reservas hr ON (h.id_habitacion=hr.fk_habitacion)
				JOIN SQLECT.Hoteles ho ON (h.fk_hotel=ho.id_hotel)
				JOIN SQLECT.Reservas r ON (r.id_reserva=hr.fk_reserva)
				
				WHERE	ho.id_hotel=@idHotel AND
						hr.estado_ocupacion='O' AND
						(	
							( fecha_inicio<=@fechaDesde and @fechaDesde<=DATEADD(day,r.cant_noches_reserva-1,r.fecha_inicio)) OR
							( fecha_inicio<=@fechaHasta and @fechaHasta<=DATEADD(day,r.cant_noches_reserva-1,r.fecha_inicio)) OR
							( @fechaDesde<=fecha_inicio and @fechaHasta>=DATEADD(day,r.cant_noches_reserva-1,r.fecha_inicio))
							
							
						) 
		) AND h.fk_hotel = @idHotel AND estado_habitacion=1 AND ( ( (@fechaDesde NOT BETWEEN bh.fecha_inicio AND bh.fecha_fin) AND (@fechaHasta NOT BETWEEN bh.fecha_inicio AND bh.fecha_fin) AND (@fechaDesde>bh.fecha_fin OR @fechaHasta<bh.fecha_inicio) ) OR (bh.fecha_inicio IS NULL AND bh.fecha_fin IS NULL) )
	 GROUP BY tipo_habitacion
	ORDER BY 1
END
GO	

/*( @fechaDesde<r.fecha_inicio and r.fecha_inicio<@fechaHasta) OR
  ( @fechaDesde<DATEADD(day,r.cant_noches_reserva,r.fecha_inicio) and DATEADD(day,r.cant_noches_reserva,r.fecha_inicio)<=@fechaHasta)*/

/*select h.fk_hotel, h.id_habitacion, t.descripcion, r.fecha_inicio 'desde', DATEADD(day,r.cant_noches_reserva,r.fecha_inicio) 'hasta', r.estado_reserva from SQLECT.Habitaciones h, SQLECT.Habitaciones_Reservas hr, SQLECT.Reservas r, SQLECT.Tipos_Habitaciones t
where h.id_habitacion = hr.fk_habitacion and hr.fk_reserva = r.id_reserva and h.id_habitacion = 55 and h.tipo_habitacion = t.id_tipo_habitacion
order by 2 DESC


exec SQLECT.obtenerMaximasHabitacionesDisponibles '2013-03-18T12:23:45', '2013-03-18T12:23:45', 11
       
*/		
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerPreciosDeHabitaciones'))
DROP PROCEDURE SQLECT.obtenerPreciosDeHabitaciones	

GO
CREATE PROCEDURE SQLECT.obtenerPreciosDeHabitaciones(@tipoRegimen varchar(60),@idHotel int)
AS
BEGIN

DECLARE @precioRegimen int,@adicionalHotel int
SET @adicionalHotel = ( SELECT (cant_estrellas*recarga_estrella) FROM SQLECT.Hoteles WHERE id_hotel=@idHotel)
SET @precioRegimen = (SELECT precio FROM SQLECT.Regimenes WHERE descripcion=@tipoRegimen)

SELECT descripcion, (@precioRegimen*(id_tipo_habitacion-1000)*porcentual)+@adicionalHotel 'Precio de la habitación por noche' FROM SQLECT.Tipos_Habitaciones
 ORDER BY id_tipo_habitacion
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.mostrarHabitacionesDisponibles'))
DROP PROCEDURE SQLECT.mostrarHabitacionesDisponibles

GO
CREATE PROCEDURE SQLECT.mostrarHabitacionesDisponibles(@fechaDesde datetime, @fechaHasta datetime,@idHotel int)
AS

BEGIN

SELECT DISTINCT hot.nombre'Hotel',tipHab.descripcion'Tipo Habitacion',ha.nro_habitacion'Numero',ha.piso'Piso',ha.frente'Frente' FROM SQLECT.Habitaciones ha LEFT JOIN SQLECT.Bajas_por_hotel bh ON (ha.fk_hotel=bh.fk_hotel) JOIN SQLECT.Hoteles hot ON (hot.id_hotel=ha.fk_hotel) JOIN SQLECT.Tipos_Habitaciones tipHab ON (ha.tipo_habitacion=tipHab.id_tipo_habitacion)
      WHERE id_habitacion NOT IN
		(
			SELECT DISTINCT h.id_habitacion FROM SQLECT.Habitaciones h
				JOIN SQLECT.Habitaciones_Reservas hr ON (h.id_habitacion=hr.fk_habitacion)
				JOIN SQLECT.Hoteles ho ON (h.fk_hotel=ho.id_hotel)
				JOIN SQLECT.Reservas r ON (r.id_reserva=hr.fk_reserva)
				
				WHERE	ho.id_hotel=@idHotel AND 
						hr.estado_ocupacion='O' AND
						(	
							( fecha_inicio<=@fechaDesde and @fechaDesde<=DATEADD(day,r.cant_noches_reserva-1,r.fecha_inicio)) OR
							( fecha_inicio<=@fechaHasta and @fechaHasta<=DATEADD(day,r.cant_noches_reserva-1,r.fecha_inicio)) OR
							( @fechaDesde<=fecha_inicio and @fechaHasta>=DATEADD(day,r.cant_noches_reserva-1,r.fecha_inicio))
						) )
		 AND ha.fk_hotel = @idHotel AND ha.estado_habitacion=1 AND ( ( (@fechaDesde NOT BETWEEN bh.fecha_inicio AND bh.fecha_fin) AND (@fechaHasta NOT BETWEEN bh.fecha_inicio AND bh.fecha_fin) AND (@fechaDesde>bh.fecha_fin OR @fechaHasta<bh.fecha_inicio) ) OR (bh.fecha_inicio IS NULL AND bh.fecha_fin IS NULL) )
	ORDER BY 1
END
GO	


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.realizarReserva'))
DROP PROCEDURE SQLECT.realizarReserva

GO
CREATE PROCEDURE SQLECT.realizarReserva(@fechaInicio datetime, @cantidadNoches int, @usuario varchar(30),@tipoRegimen varchar(60),@idHotel int,@cantHuespedes int,@fechaDelSistema varchar(9) )
AS
BEGIN TRANSACTION

DECLARE @idUsuario int,@idRegimen int
SET @idUsuario = (SELECT id_usuario FROM SQLECT.Usuarios WHERE usr_name=@usuario)
SET @idRegimen = (SELECT id_regimen FROM SQLECT.Regimenes WHERE descripcion=@tipoRegimen)
INSERT INTO SQLECT.Reservas(id_reserva,fecha_inicio,cant_noches_reserva,fk_usuario_reserva,fk_usuario_ultima_modificacion,fk_regimen,fecha_reserva,cantidad_huespedes) VALUES (SQLECT.obtenerIdSiguiente(),@fechaInicio,@cantidadNoches,@idUsuario,@idUsuario,@idRegimen,@fechaDelSistema,@cantHuespedes)

COMMIT TRANSACTION
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.reservarHabitacion'))
DROP PROCEDURE SQLECT.reservarHabitacion

GO
CREATE PROCEDURE SQLECT.reservarHabitacion(@idHotel int, @numeroHabitacion int, @idReserva int,@fechaDesde datetime, @cantNoches int)
AS
BEGIN TRANSACTION
 DECLARE @idHabitacion int,@fechaHasta datetime
 SET @idHabitacion = (SELECT id_habitacion FROM SQLECT.Habitaciones WHERE nro_habitacion=@numeroHabitacion AND fk_hotel=@idHotel)
 INSERT INTO SQLECT.Habitaciones_Reservas(fk_habitacion,fk_reserva) VALUES (@idHabitacion,@idReserva)
  
  SET @fechaHasta = DATEADD(DAY,@cantNoches,@fechaDesde)
  
UPDATE SQLECT.Habitaciones_Reservas SET estado_ocupacion='O'
 WHERE fk_habitacion=@idHabitacion AND ( fk_reserva IN ( SELECT id_reserva FROM SQLECT.Reservas r JOIN SQLECT.Habitaciones_Reservas hr ON (hr.fk_reserva=r.id_reserva)
                                                           WHERE hr.fk_habitacion=@idHabitacion AND( ( @fechaDesde<r.fecha_inicio and r.fecha_inicio<@fechaHasta) OR
																									  ( ( @fechaDesde<DATEADD(day,r.cant_noches_reserva,r.fecha_inicio) and DATEADD(day,r.cant_noches_reserva,r.fecha_inicio)<@fechaHasta)) 
																									    OR ( @fechaDesde>DATEADD(day,r.cant_noches_reserva,r.fecha_inicio) AND hr.estado_ocupacion='D') ) AND r.estado_reserva IN (2,3,4) )
                                       )                   
  
COMMIT TRANSACTION
GO
  
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerIdSiguiente'))
DROP FUNCTION SQLECT.obtenerIdSiguiente

GO
CREATE FUNCTION SQLECT.obtenerIdSiguiente()
RETURNS int
AS
BEGIN
DECLARE @idSiguiente int
SET @idSiguiente = (SELECT TOP 1 id_reserva FROM SQLECT.Reservas
					    ORDER BY id_reserva DESC) + 1
 
 RETURN @idSiguiente
 
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerIdFacturaSiguiente'))
DROP FUNCTION SQLECT.obtenerIdFacturaSiguiente

GO
CREATE FUNCTION SQLECT.obtenerIdFacturaSiguiente()
RETURNS int
AS
BEGIN
DECLARE @idFacturaSiguiente int
SET @idFacturaSiguiente = (SELECT TOP 1 id_factura FROM SQLECT.Facturas
                              ORDER BY id_factura DESC) + 1
 RETURN @idFacturaSiguiente
END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerIdReserva'))
DROP PROCEDURE SQLECT.obtenerIdReserva

GO
CREATE PROCEDURE SQLECT.obtenerIdReserva
AS
BEGIN
SELECT TOP 1 id_reserva FROM SQLECT.Reservas 
 ORDER BY id_reserva DESC
END
GO
 
 
 /*SELECT * FROM SQLECT.Habitaciones_Reservas
  WHERE fk_habitacion IN (201,276,320)
   ORDER BY 2 DESC
   
   SELECT * FROM SQLECT.Reservas
    where id_reserva=110741
    
    SELECT * FROM SQLECT.Reservas
     ORDER BY 1 DESC
     
     SELECT * FROM SQLECT.Habitaciones_Reservas
      WHERE fk_habitacion IN (SELECT hr.fk_habitacion FROM SQLECT.Habitaciones_Reservas hr
                                WHERE fk_reserva=110742)
         ORDER BY fk_reserva DESC*/
 
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.verificarExistenciaCodigoReserva'))
DROP PROCEDURE SQLECT.verificarExistenciaCodigoReserva

GO    
CREATE PROCEDURE SQLECT.verificarExistenciaCodigoReserva(@codigoReserva varchar(9))
AS
BEGIN
SELECT codigo_reserva FROM SQLECT.Reservas 
  WHERE codigo_reserva=@codigoReserva
  
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.adjuntarCodigoALaReserva'))
DROP PROCEDURE SQLECT.adjuntarCodigoALaReserva

GO
CREATE PROCEDURE SQLECT.adjuntarCodigoALaReserva(@idReserva int, @codigoReserva varchar(9))
AS
BEGIN
UPDATE SQLECT.Reservas SET codigo_reserva=@codigoReserva
 WHERE id_reserva=@idReserva
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.adjuntarClienteALaReserva'))
DROP PROCEDURE SQLECT.adjuntarClienteALaReserva

GO
CREATE PROCEDURE SQLECT.adjuntarClienteALaReserva(@email varchar(255),@documento_nro int,@idReserva int)
AS
BEGIN
DECLARE @idCliente int
SET @idCliente= (SELECT id_cliente FROM SQLECT.Clientes WHERE mail=@email AND documento_Nro=@documento_nro)

UPDATE SQLECT.Reservas SET fk_cliente=@idCliente
 WHERE id_reserva=@idReserva

END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerCodigoReserva'))
DROP PROCEDURE SQLECT.obtenerCodigoReserva

GO
CREATE PROCEDURE SQLECT.obtenerCodigoReserva(@idReserva int)
AS
BEGIN
SELECT codigo_reserva FROM SQLECT.Reservas
 WHERE id_reserva=@idReserva
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.correspondeReservaAlHotel'))
DROP PROCEDURE SQLECT.correspondeReservaAlHotel

GO
CREATE PROCEDURE SQLECT.correspondeReservaAlHotel(@codigoReserva varchar(9), @idHotel int)
AS
BEGIN
SELECT DISTINCT r.codigo_reserva FROM SQLECT.Reservas r JOIN SQLECT.Habitaciones_Reservas hr ON (r.id_reserva=hr.fk_reserva) 
														JOIN SQLECT.Habitaciones h ON (hr.fk_habitacion=h.id_habitacion)
	 WHERE r.codigo_reserva=@codigoReserva AND h.fk_hotel=@idHotel
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.chequearHabilitacionDeCancelacion'))
DROP PROCEDURE SQLECT.chequearHabilitacionDeCancelacion

GO
CREATE PROCEDURE SQLECT.chequearHabilitacionDeCancelacion(@codigoReserva varchar(9),@fechaActual varchar(9))
AS
BEGIN
SELECT id_reserva FROM SQLECT.Reservas 
 WHERE codigo_reserva=@codigoReserva AND DATEDIFF(DAY,@fechaActual,fecha_inicio)>=1 AND estado_reserva NOT IN(2,3,4)
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.cancelarReserva'))
DROP PROCEDURE SQLECT.cancelarReserva

GO
CREATE PROCEDURE SQLECT.cancelarReserva(@codigoReserva varchar(9),@usuario varchar(30),@nombreRol varchar(30),@motivo varchar(120))
AS
BEGIN

DECLARE @canceladaPor int,@idUsuario int,@idReserva int,@fechaDesde datetime
SET @idUsuario = (SELECT id_usuario FROM SQLECT.Usuarios WHERE usr_name=@usuario)
SET @idReserva = (SELECT id_reserva FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva)
SET @fechaDesde = (SELECT fecha_inicio FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva)

BEGIN TRANSACTION
  BEGIN
	IF(@nombreRol='Recepcionista')
	 SET @canceladaPor=2
    ELSE
     SET @canceladaPor=3
   END
   
UPDATE SQLECT.Reservas SET estado_reserva=@canceladaPor,cant_noches_estadia=NULL,fk_usuario_ultima_modificacion=@idUsuario
 WHERE codigo_reserva=@codigoReserva
 
INSERT INTO SQLECT.Reservas_Canceladas(fk_reserva,motivo) VALUES (@idReserva,@motivo)

UPDATE SQLECT.Habitaciones_Reservas SET estado_ocupacion='D'
 WHERE fk_reserva=@idReserva

COMMIT TRANSACTION
END
GO
/*
SELECT * FROM SQLECT.Reservas
 ORDER BY 1 DESC
 
SELECT * FROM SQLECT.Habitaciones_Reservas
 ORDER BY fk_reserva DESC
 
 SELECT * FROM SQLECT.Habitaciones
  ORDER BY 1 
 
 SELECT * FROM SQLECT.Clientes
  ORDER BY id_cliente DESC
  
 SELECT * FROM SQLECT.Reservas_Canceladas*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerHabitacionesActualesDeReserva'))
DROP PROCEDURE SQLECT.obtenerHabitacionesActualesDeReserva

GO
CREATE PROCEDURE SQLECT.obtenerHabitacionesActualesDeReserva(@codigoReserva varchar(9))
AS
BEGIN

SELECT DISTINCT hot.nombre'Hotel',tipHab.descripcion'Tipo Habitacion',ha.nro_habitacion'Numero',ha.piso'Piso',ha.frente'Frente' 
	FROM SQLECT.Habitaciones ha JOIN SQLECT.Hoteles hot ON (hot.id_hotel=ha.fk_hotel) 
								JOIN SQLECT.Tipos_Habitaciones tipHab ON (ha.tipo_habitacion=tipHab.id_tipo_habitacion)
								JOIN SQLECT.Habitaciones_Reservas hr ON (hr.fk_habitacion=ha.id_habitacion)
								JOIN SQLECT.Reservas r ON (r.id_reserva=hr.fk_reserva)
	WHERE r.codigo_reserva=@codigoReserva AND hr.estado_ocupacion='O'
END
GO

/*IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerHabitacionesDiponiblesMasActuales'))
DROP PROCEDURE SQLECT.obtenerHabitacionesDiponiblesMasActuales

GO
CREATE PROCEDURE SQLECT.obtenerHabitacionesDiponiblesMasActuales(@idHotel int, @fechaDesde datetime,@fechaHasta datetime, @codigoReserva varchar(9))
AS
BEGIN
SELECT DISTINCT hot.nombre'Hotel',tipHab.descripcion'Tipo Habitacion',ha.nro_habitacion'Numero',ha.piso'Piso',ha.frente'Frente' FROM SQLECT.Habitaciones ha JOIN SQLECT.Hoteles hot ON (hot.id_hotel=ha.fk_hotel) JOIN SQLECT.Tipos_Habitaciones tipHab ON (ha.tipo_habitacion=tipHab.id_tipo_habitacion)
      WHERE id_habitacion NOT IN
		(
			SELECT DISTINCT h.id_habitacion FROM SQLECT.Habitaciones h
				JOIN SQLECT.Habitaciones_Reservas hr ON (h.id_habitacion=hr.fk_habitacion)
				JOIN SQLECT.Hoteles ho ON (h.fk_hotel=ho.id_hotel)
				JOIN SQLECT.Reservas r ON (r.id_reserva=hr.fk_reserva)
				
				WHERE	ho.id_hotel=@idHotel AND 
						hr.estado_ocupacion='O' AND
						(	
							( fecha_inicio<=@fechaDesde and @fechaDesde<=DATEADD(day,r.cant_noches_reserva-1,r.fecha_inicio)) OR
							( fecha_inicio<=@fechaHasta and @fechaHasta<=DATEADD(day,r.cant_noches_reserva-1,r.fecha_inicio)) OR
							( @fechaDesde<=fecha_inicio and @fechaHasta>=DATEADD(day,r.cant_noches_reserva-1,r.fecha_inicio)) 
														
						) 
						
						)
		 AND ha.fk_hotel = @idHotel AND ha.estado_habitacion=1
	ORDER BY 1
    	
END
GO*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.modificarReserva'))
DROP PROCEDURE SQLECT.modificarReserva

GO
CREATE PROCEDURE SQLECT.modificarReserva(@codigoReserva varchar(9),@usuario varchar(30),@cantHuespedes int, @regimen varchar(60),@fechaDesde datetime,@fechaHasta datetime)
AS
BEGIN
DECLARE @idUsuario int, @idRegimen int
SET @idUsuario = (SELECT id_usuario FROM SQLECT.Usuarios WHERE usr_name=@usuario)
SET @idRegimen = (SELECT id_regimen FROM SQLECT.Regimenes WHERE descripcion=@regimen)

BEGIN TRANSACTION
UPDATE SQLECT.Reservas SET estado_reserva=1,fk_usuario_ultima_modificacion=@idUsuario,fk_regimen=@idRegimen,cantidad_huespedes=@cantHuespedes,fecha_inicio=@fechaDesde,cant_noches_reserva=DATEDIFF(DAY,@fechaDesde,@fechaHasta)+1
 WHERE codigo_reserva=@codigoReserva
COMMIT TRANSACTION
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.desocuparHabitacionesDeReserva'))
DROP PROCEDURE SQLECT.desocuparHabitacionesDeReserva

GO
CREATE PROCEDURE SQLECT.desocuparHabitacionesDeReserva(@codigoReserva varchar(9))
AS
BEGIN
UPDATE SQLECT.Habitaciones_Reservas SET estado_ocupacion='D'
 WHERE fk_reserva IN (SELECT id_reserva FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva)
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.modificarHabitacionDeReserva'))
DROP PROCEDURE SQLECT.modificarHabitacionDeReserva

GO
CREATE PROCEDURE SQLECT.modificarHabitacionDeReserva(@codigoReserva varchar(9),@numeroHabitacion int,@idHotel int)
AS
BEGIN
DECLARE @idHabitacion int,@idReserva int
SET @idHabitacion = (SELECT id_habitacion FROM SQLECT.Habitaciones WHERE nro_habitacion=@numeroHabitacion AND fk_hotel=@idHotel)
SET @idReserva = (SELECT id_reserva FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva)

IF NOT EXISTS(SELECT * FROM SQLECT.Habitaciones_Reservas WHERE fk_reserva=@idReserva AND fk_habitacion=@idHabitacion)
 INSERT INTO SQLECT.Habitaciones_Reservas(fk_habitacion,fk_reserva,estado_ocupacion) VALUES (@idHabitacion,@idReserva,'O')
ELSE
 BEGIN
    UPDATE SQLECT.Habitaciones_Reservas SET estado_ocupacion='O'
    WHERE fk_reserva=@idReserva AND fk_habitacion=@idHabitacion
  END

END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.chequearFechaDeIngreso'))
DROP PROCEDURE SQLECT.chequearFechaDeIngreso

GO
CREATE PROCEDURE SQLECT.chequearFechaDeIngreso(@codigoReserva varchar(9),@fechaDelSistema varchar(9))
AS
BEGIN

SELECT estado_reserva FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva AND ( DATEPART(YEAR,fecha_inicio)=DATEPART(YEAR,@fechaDelSistema) AND DATEPART(MONTH,fecha_inicio)=DATEPART(MONTH,@fechaDelSistema) AND DATEPART(DAY,fecha_inicio)=DATEPART(DAY,@fechaDelSistema) )
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.cancelarReservaPorNoShow'))
DROP PROCEDURE SQLECT.cancelarReservaPorNoShow

GO
CREATE PROCEDURE SQLECT.cancelarReservaPorNoShow(@codigoReserva varchar(9),@fechaDelSistema varchar(9))
AS
BEGIN

DECLARE @idReserva int
 SET @idReserva= (SELECT id_reserva FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva)
 
 BEGIN TRANSACTION
  UPDATE SQLECT.Reservas SET estado_reserva=4
   WHERE codigo_reserva=@codigoReserva
  
  UPDATE SQLECT.Habitaciones_Reservas SET estado_ocupacion='D'
   WHERE fk_reserva=@idReserva
   
  INSERT INTO SQLECT.Reservas_Canceladas(fecha_cancelacion,fk_reserva,motivo) VALUES (@fechaDelSistema,@idReserva,'No se presentó en fecha')
  
  COMMIT TRANSACTION
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.realizarCheckIn'))
DROP PROCEDURE SQLECT.realizarCheckIn

GO
CREATE PROCEDURE SQLECT.realizarCheckIn(@codigoReserva varchar(9), @usuario varchar(30),@fechaDelSistema varchar(9))
AS
BEGIN

DECLARE @idReserva int,@idUsuario int
 SET @idUsuario=(SELECT id_usuario FROM SQLECT.Usuarios WHERE usr_name=@usuario)
 SET @idReserva=(SELECT id_reserva FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva)
  
  BEGIN TRANSACTION
   UPDATE SQLECT.Reservas SET estado_reserva=5,cant_noches_estadia=cant_noches_reserva
    WHERE codigo_reserva=@codigoReserva
    
   INSERT INTO SQLECT.Estadias(fk_reserva,fecha_inicio,fk_usuario_checkin,cant_noches) VALUES(@idReserva,@fechaDelSistema,@idUsuario,1)
   
  COMMIT TRANSACTION
  
END
GO

/*SELECT r.id_reserva,r.fecha_inicio,r.cant_noches_reserva FROM SQLECT.Reservas r JOIN SQLECT.Habitaciones_Reservas hr on (hr.fk_reserva=r.id_reserva)
								JOIN SQLECT.Habitaciones h ON (hr.fk_habitacion=h.id_habitacion)
						WHERE h.fk_hotel=1 AND r.estado_reserva=5
 ORDER BY 1 DESC
 
UPDATE SQLECT.Reservas SET codigo_reserva=11111111
 WHERE id_reserva=57989
 
 UPDATE SQLECT.Reservas SET codigo_reserva=22222222
 WHERE id_reserva=57648
 
  UPDATE SQLECT.Reservas SET codigo_reserva=33333333
 WHERE id_reserva=58320
 
 
 
 SELECT * FROM SQLECT.Estadias
  ORDER BY 1 DESC*/
	  
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.chequearFechaDeEgreso'))
DROP PROCEDURE SQLECT.chequearFechaDeEgreso	  

GO
CREATE PROCEDURE SQLECT.chequearFechaDeEgreso(@codigoReserva varchar(9),@fechaDelSistema varchar(9))
AS
BEGIN

SELECT estado_reserva FROM SQLECT.Reservas 
  WHERE codigo_reserva=@codigoReserva AND ( @fechaDelSistema BETWEEN fecha_inicio AND DATEADD(DAY,cant_noches_reserva,fecha_inicio) ) 
  END
  GO
  
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.realizarCheckOut'))
DROP PROCEDURE SQLECT.realizarCheckOut	  

GO
CREATE PROCEDURE SQLECT.realizarCheckOut(@codigoReserva varchar(9),@usuario varchar(30),@fechaDelSistema varchar(9))
AS
BEGIN

DECLARE @idReserva int,@idUsuario int
 SET @idUsuario=(SELECT id_usuario FROM SQLECT.Usuarios WHERE usr_name=@usuario)
 SET @idReserva=(SELECT id_reserva FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva)
 
 BEGIN TRANSACTION
   UPDATE SQLECT.Habitaciones_Reservas SET estado_ocupacion='D'
	WHERE fk_reserva=@idReserva

IF NOT EXISTS(SELECT fecha_fin FROM SQLECT.Estadias WHERE fk_reserva=@idReserva AND fecha_fin IS NOT NULL)	  
   BEGIN   
   UPDATE SQLECT.Estadias SET fecha_fin=@fechaDelSistema,cant_noches=DATEDIFF(DAY,fecha_inicio,@fechaDelSistema),fk_usuario_checkout=@idUsuario
    WHERE fk_reserva=@idReserva
    END
    
   UPDATE SQLECT.Reservas SET cant_noches_estadia= DATEDIFF(DAY,fecha_inicio,@fechaDelSistema)
    WHERE id_reserva=@idReserva
 
 COMMIT TRANSACTION
 
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.chequearRealizacionDeCheckIn'))
DROP PROCEDURE SQLECT.chequearRealizacionDeCheckIn

GO
CREATE PROCEDURE SQLECT.chequearRealizacionDeCheckIn(@codigoReserva varchar(9))
AS
BEGIN

DECLARE @idReserva int
SET @idReserva=(SELECT id_reserva FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva)

SELECT fecha_inicio FROM SQLECT.Estadias WHERE fk_reserva=@idReserva AND fecha_inicio IS NOT NULL

END
GO 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.chequearRealizacionDeCheckOut'))
DROP PROCEDURE SQLECT.chequearRealizacionDeCheckOut

GO
CREATE PROCEDURE SQLECT.chequearRealizacionDeCheckOut(@codigoReserva varchar(9))
AS
BEGIN

DECLARE @idReserva int
SET @idReserva=(SELECT id_reserva FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva)

SELECT fecha_fin FROM SQLECT.Estadias WHERE fk_reserva=@idReserva AND fecha_fin IS NOT NULL

END
GO 

/*SELECT h.nro_habitacion,c.descripcion,ceh.cantidad FROM SQLECT.Consumibles_Estadias_Habitaciones ceh JOIN SQLECT.Consumibles c ON (ceh.fk_consumible=c.id_consumible)
																	        				         JOIN SQLECT.Habitaciones h ON (ceh.fk_habitacion=h.id_habitacion)
																	        				         WHERE nro_habitacion=36 ORDER BY descripcion 
	
UPDATE SQLECT.Reservas SET codigo_reserva=11111111
 WHERE id_reserva=48640		
 
 SELECT * FROM SQLECT.Consumibles_Estadias_Habitaciones c JOIN SQLECT.Estadias ON (c.fk_estadia= id_estadia)
  ORDER BY fk_reserva DESC	
  
  SELECT * FROM SQLECT.Consumibles	  */
  
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.verificarHabitacionDeReserva'))
DROP PROCEDURE SQLECT.verificarHabitacionDeReserva	

GO
CREATE PROCEDURE SQLECT.verificarHabitacionDeReserva(@codigoReserva varchar(9),@numeroHabitacion int)
AS
BEGIN
SELECT h.nro_habitacion FROM SQLECT.Reservas r JOIN SQLECT.Habitaciones_Reservas hr ON (r.id_reserva=hr.fk_reserva)
											   JOIN SQLECT.Habitaciones h ON (hr.fk_habitacion=h.id_habitacion)
		WHERE r.codigo_reserva=@codigoReserva AND h.nro_habitacion=@numeroHabitacion
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.registrarConsumible'))
DROP PROCEDURE SQLECT.registrarConsumible	

GO
CREATE PROCEDURE SQLECT.registrarConsumible(@codigoReserva varchar(9),@numeroHabitacion int,@consumible varchar(60),@cantidadConsumida int)
AS
BEGIN
DECLARE @idConsumible int,@idHabitacion int,@idEstadia int
SET @idEstadia=(SELECT e.id_estadia FROM SQLECT.Reservas r JOIN SQLECT.Estadias e ON (r.id_reserva=e.fk_reserva) WHERE r.codigo_reserva=@codigoReserva)
SET @idConsumible=(SELECT id_consumible FROM SQLECT.Consumibles WHERE descripcion=@consumible)
SET @idHabitacion=(SELECT DISTINCT h.id_habitacion FROM SQLECT.Habitaciones h JOIN SQLECT.Habitaciones_Reservas hr ON (hr.fk_habitacion=h.id_habitacion)
                                                                              JOIN SQLECT.Reservas r ON (hr.fk_reserva=r.id_reserva)
                     WHERE r.codigo_reserva=@codigoReserva AND h.nro_habitacion=@numeroHabitacion)

IF EXISTS(SELECT * FROM SQLECT.Consumibles_Estadias_Habitaciones 
				WHERE fk_estadia=@idEstadia AND fk_habitacion=@idHabitacion AND fk_consumible=@idConsumible)
	BEGIN
	 UPDATE SQLECT.Consumibles_Estadias_Habitaciones SET cantidad=cantidad+@cantidadConsumida
	   WHERE fk_estadia=@idEstadia AND fk_consumible=@idConsumible
	 END
  ELSE
    BEGIN
      INSERT INTO SQLECT.Consumibles_Estadias_Habitaciones(fk_estadia,fk_habitacion,fk_consumible,cantidad) VALUES (@idEstadia,@idHabitacion,@idConsumible,@cantidadConsumida)
     END
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.modificarConsumible'))
DROP PROCEDURE SQLECT.modificarConsumible	

GO
CREATE PROCEDURE SQLECT.modificarConsumible(@codigoReserva varchar(9),@numeroHabitacion int,@consumible varchar(60),@cantidadConsumida int)
AS
BEGIN
DECLARE @idConsumible int,@idHabitacion int,@idEstadia int 
SET @idEstadia=(SELECT e.id_estadia FROM SQLECT.Reservas r JOIN SQLECT.Estadias e ON (r.id_reserva=e.fk_reserva) WHERE r.codigo_reserva=@codigoReserva)
SET @idConsumible=(SELECT id_consumible FROM SQLECT.Consumibles WHERE descripcion=@consumible)
SET @idHabitacion=(SELECT DISTINCT h.id_habitacion FROM SQLECT.Habitaciones h JOIN SQLECT.Habitaciones_Reservas hr ON (hr.fk_habitacion=h.id_habitacion)
                                                                              JOIN SQLECT.Reservas r ON (hr.fk_reserva=r.id_reserva)
                     WHERE r.codigo_reserva=@codigoReserva AND h.nro_habitacion=@numeroHabitacion)

IF EXISTS(SELECT * FROM SQLECT.Consumibles_Estadias_Habitaciones 
				WHERE fk_estadia=@idEstadia AND fk_habitacion=@idHabitacion AND fk_consumible=@idConsumible)
	UPDATE SQLECT.Consumibles_Estadias_Habitaciones SET cantidad=@cantidadConsumida
	  WHERE fk_estadia=@idEstadia AND fk_habitacion=@idHabitacion AND fk_consumible=@idConsumible
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.eliminarConsumible'))
DROP PROCEDURE SQLECT.eliminarConsumible	

GO
CREATE PROCEDURE SQLECT.eliminarConsumible(@codigoReserva varchar(9),@numeroHabitacion int,@consumible varchar(60))
AS
BEGIN

DECLARE @idConsumible int,@idHabitacion int,@idEstadia int 
SET @idEstadia=(SELECT e.id_estadia FROM SQLECT.Reservas r JOIN SQLECT.Estadias e ON (r.id_reserva=e.fk_reserva) WHERE r.codigo_reserva=@codigoReserva)
SET @idConsumible=(SELECT id_consumible FROM SQLECT.Consumibles WHERE descripcion=@consumible)
SET @idHabitacion=(SELECT DISTINCT h.id_habitacion FROM SQLECT.Habitaciones h JOIN SQLECT.Habitaciones_Reservas hr ON (hr.fk_habitacion=h.id_habitacion)
                                                                              JOIN SQLECT.Reservas r ON (hr.fk_reserva=r.id_reserva)
                     WHERE r.codigo_reserva=@codigoReserva AND h.nro_habitacion=@numeroHabitacion)
                     
DELETE FROM SQLECT.Consumibles_Estadias_Habitaciones
 WHERE fk_estadia=@idEstadia AND fk_habitacion=@idHabitacion AND fk_consumible=@idConsumible
END
GO

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.descontarConsumiblesPorRegimen'))
DROP PROCEDURE SQLECT.descontarConsumiblesPorRegimen

GO
CREATE PROCEDURE SQLECT.descontarConsumiblesPorRegimen(@codigoReserva varchar(9))
AS
BEGIN

IF EXISTS(SELECT fk_regimen FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva AND fk_regimen=3)
 BEGIN
  DECLARE @idFactura int,@idReserva int,@descuentoPorRegimen decimal(8,2)
  SET @idReserva=(SELECT id_reserva FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva)
  SET @idFactura = (SELECT f.id_factura FROM SQLECT.Facturas f JOIN SQLECT.Estadias e ON (f.fk_estadia = e.id_estadia)
											WHERE e.fk_reserva=@idReserva)
  SET @descuentoPorRegimen=(SELECT SUM(monto_item) FROM SQLECT.Items WHERE fk_factura=@idFactura AND (fk_consumible IS NOT NULL) AND (monto_item IS NOT NULL) GROUP BY fk_factura)
  
  INSERT INTO SQLECT.Items(fk_factura,fk_consumible,descripcion,cantidad_prod,monto_item) VALUES (@idFactura,NULL,'Descuento/régimen de estadía',0,@descuentoPorRegimen )
 
  UPDATE SQLECT.Facturas SET total_factura=total_factura-@descuentoPorRegimen
   WHERE id_factura=@idFactura
 
  END
END
GO

              
/*
SELECT * FROM SQLECT.Reservas r JOIN SQLECT.Clientes c ON (r.fk_cliente = c.id_cliente)

UPDATE SQLECT.Reservas SET codigo_reserva=22222222
 WHERE id_reserva=32047
  
  SELECT * FROM SQLECT.Habitaciones_Reservas JOIN SQLECT.Habitaciones ON (fk_habitacion=id_habitacion)
   WHERE fk_reserva=32047
   
   SELECT * FROM SQLECT.Habitaciones_Reservas
    WHERE fk_reserva=32047
   
    SELECT * FROM SQLECT.Reservas
     WHERE codigo_reserva IS NOT NULL
    
    SELECT * FROM SQLECT.Reservas JOIN SQLECT.Estadias e ON (e.fk_reserva=id_reserva)
								  JOIN SQLECT.Facturas ON (fk_estadia=id_estadia)
								  JOIN SQLECT.Habitaciones_Reservas hr ON (hr.fk_reserva=id_reserva)
								  JOIN SQLECT.Habitaciones ha ON (ha.id_habitacion=hr.fk_habitacion)
     WHERE fk_regimen=1
     
     SELECT * FROM SQLECT.Regimenes
     SELECT * FROM SQLECT.Tipos_Habitaciones
     
     SELECT * FROM SQLECT.Facturas
      WHERE id_factura=2416367
 


SELECT * FROM SQLECT.Estadias*/


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.generarFactura'))
DROP PROCEDURE SQLECT.generarFactura

GO
CREATE PROCEDURE SQLECT.generarFactura(@codigoReserva varchar(9),@idHotel int,@fechaDelSistema varchar(9))
AS

/*IF NOT EXISTS(SELECT * FROM SQLECT.Reservas r JOIN SQLECT.Estadias e ON(e.fk_reserva=r.id_reserva)
										      JOIN SQLECT.Facturas f ON (f.fk_estadia=e.id_estadia)
					WHERE codigo_reserva=@codigoReserva)*/
BEGIN

DECLARE @idEstadia int,@idReserva int,@idRegimen int,@nochesEfectivas int, @nochesFaltantes int,@precioRegimen decimal(6,2),@montoEstadia decimal(8,2),@recargoHotel int,@idFactura int
SET @idEstadia = (SELECT id_estadia FROM SQLECT.Estadias JOIN SQLECT.Reservas ON (fk_reserva=id_reserva)
                    WHERE codigo_reserva=@codigoReserva)
SET @idRegimen = (SELECT fk_regimen FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva)
SET @precioRegimen= (SELECT precio FROM SQLECT.Regimenes WHERE id_regimen=@idRegimen)
SET @nochesEfectivas = (SELECT cant_noches FROM SQLECT.Estadias WHERE id_estadia=@idEstadia)
SET @nochesFaltantes = (SELECT (cant_noches_reserva-@nochesEfectivas) FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva)
SET @idReserva = (SELECT id_reserva FROM SQLECT.Reservas WHERE codigo_reserva=@codigoReserva)
SET @recargoHotel = (SELECT (cant_estrellas*recarga_estrella) FROM SQLECT.Hoteles WHERE id_hotel=@idHotel)

SET @montoEstadia = (SELECT SUM((@precioRegimen*(ha.tipo_habitacion-1000)*t.porcentual)+@recargoHotel) FROM SQLECT.Habitaciones_Reservas hr JOIN SQLECT.Habitaciones ha ON (ha.id_habitacion=hr.fk_habitacion)
																												JOIN SQLECT.Tipos_Habitaciones t ON (t.id_tipo_habitacion=ha.tipo_habitacion)
                             WHERE hr.fk_reserva=@idReserva
                             GROUP BY hr.fk_reserva)

IF NOT EXISTS(SELECT id_factura FROM SQLECT.Facturas WHERE fk_estadia=@idEstadia)
BEGIN
 DECLARE @totalFactura decimal(8,2)
 
  SET @idFactura=SQLECT.obtenerIdFacturaSiguiente()
   
   INSERT INTO SQLECT.Facturas(id_factura,fecha,fk_estadia,total_factura,forma_pago,detalle_forma_pago) VALUES (@idFactura,@fechaDelSistema,@idEstadia,0,'','')
   
   INSERT INTO SQLECT.Items(fk_factura,fk_consumible,descripcion,cantidad_prod,monto_item) VALUES(@idFactura,NULL,'Estadía',1,@montoEstadia)
   INSERT INTO SQLECT.Items(fk_factura,fk_consumible,descripcion,cantidad_prod,monto_item) 
    (SELECT @idFactura,c.id_consumible,c.descripcion,ce.cantidad,(ce.cantidad*c.precio) FROM SQLECT.Consumibles_Estadias_Habitaciones ce JOIN SQLECT.Consumibles c ON (ce.fk_consumible=c.id_consumible) 
       WHERE ce.fk_estadia=@idEstadia AND ce.cantidad>0)
       
    SET @totalFactura= (SELECT SUM(monto_item) FROM SQLECT.Items WHERE fk_factura=@idFactura AND monto_item IS NOT NULL
								GROUP BY fk_factura	)   
    
    UPDATE SQLECT.Facturas SET total_factura=@totalFactura
     WHERE id_factura=@idFactura 
       
   IF(@nochesFaltantes>0)
    BEGIN
     INSERT INTO SQLECT.Items(fk_factura,fk_consumible,descripcion,cantidad_prod,monto_item) VALUES(@idFactura,NULL,'Noches no efectivizadas',@nochesFaltantes,NULL)
     END
   
END

END
GO
  
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerDetallesFactura'))
DROP PROCEDURE SQLECT.obtenerDetallesFactura

GO
CREATE PROCEDURE SQLECT.obtenerDetallesFactura(@codigoReserva varchar(9))
AS
BEGIN

DECLARE @idFactura int
SET @idFactura= (SELECT f.id_factura FROM SQLECT.Reservas r JOIN SQLECT.Estadias e ON (r.id_reserva=e.fk_reserva)
															JOIN SQLECT.Facturas f ON (f.fk_estadia=e.id_estadia)
							WHERE r.codigo_reserva=@codigoReserva)
SELECT descripcion'Descripción',cantidad_prod'Cantidad',monto_item'Monto' FROM SQLECT.Items
 WHERE fk_factura=@idFactura
END
GO



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerNumeroFactura'))
DROP PROCEDURE SQLECT.obtenerNumeroFactura

GO
CREATE PROCEDURE SQLECT.obtenerNumeroFactura(@codigoReserva varchar(9))
AS
BEGIN
DECLARE @idEstadia int
SET @idEstadia=(SELECT e.id_estadia FROM SQLECT.Reservas r JOIN SQLECT.Estadias e ON (r.id_reserva=e.fk_reserva)
                    WHERE r.codigo_reserva=@codigoReserva)
                    
SELECT id_factura FROM SQLECT.Facturas
  WHERE fk_estadia=@idEstadia
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.obtenerMontoTotalFactura'))
DROP PROCEDURE SQLECT.obtenerMontoTotalFactura

GO
CREATE PROCEDURE SQLECT.obtenerMontoTotalFactura(@codigoReserva varchar(9))
AS
BEGIN
DECLARE @idEstadia int
SET @idEstadia=(SELECT e.id_estadia FROM SQLECT.Reservas r JOIN SQLECT.Estadias e ON (r.id_reserva=e.fk_reserva)
                    WHERE r.codigo_reserva=@codigoReserva)

SELECT total_factura FROM SQLECT.Facturas
 WHERE fk_estadia=@idEstadia
 
END
GO  

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.registrarFormaDePago'))
DROP PROCEDURE SQLECT.registrarFormaDePago

GO
CREATE PROCEDURE SQLECT.registrarFormaDePago(@codigoReserva varchar(9),@formaDePago varchar(30),@detalles varchar(120))
AS
BEGIN
DECLARE @idFactura int
SET @idFactura=(SELECT f.id_factura FROM SQLECT.Reservas r JOIN SQLECT.Estadias e ON (r.id_reserva=e.fk_reserva)
											  JOIN SQLECT.Facturas f ON (f.fk_estadia=e.id_estadia)
							WHERE r.codigo_reserva=@codigoReserva)  

UPDATE SQLECT.Facturas SET forma_pago=@formaDePago,detalle_forma_pago=@detalles
 WHERE id_factura=@idFactura

END
GO


/* ABM Roles */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.altaRol'))
DROP PROCEDURE SQLECT.altaRol

GO
CREATE PROCEDURE SQLECT.altaRol (@nombre VARCHAR(30), @descrip VARCHAR(90), @gestRol INT, @gestUsr INT, @gestCli INT,
								@gestHotel INT, @gestHab INT, @gestRes INT, @cancelRes INT, @gestConsu INT, @gestEstad INT,
								@gestFactu INT, @listados INT) AS
BEGIN

	DECLARE @RolId INT
	
	INSERT INTO SQLECT.Roles(nombre, descripcion, estado_rol)
	VALUES (@nombre, @descrip, 1)
	
	SET @RolId = SCOPE_IDENTITY()
	
	IF (@gestRol = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,1)
	IF (@gestUsr = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,2)
	IF (@gestCli = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,3)
	IF (@gestHotel = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,4)
	IF (@gestHab = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,5)
	IF (@gestRes = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,6)
	IF (@cancelRes = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,7)
	IF (@gestConsu = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,8)
	IF (@gestEstad = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,9)
	IF (@gestFactu = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,10)
	IF (@listados = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,11)
	
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.modifRol'))
DROP PROCEDURE SQLECT.modifRol

GO
CREATE PROCEDURE SQLECT.modifRol (@nombre VARCHAR(30), @descrip VARCHAR(90), @gestRol INT, @gestUsr INT, @gestCli INT,
								@gestHotel INT, @gestHab INT, @gestRes INT, @cancelRes INT, @gestConsu INT, @gestEstad INT,
								@gestFactu INT, @listados INT, @RolId INT) AS
BEGIN
	
	UPDATE SQLECT.Roles
	SET nombre = @nombre, descripcion = @descrip, estado_rol = 1
	WHERE id_rol = @RolId
	
	DELETE FROM SQLECT.Funcionalidades_Roles WHERE fk_rol = @RolId
	
	IF (@gestRol = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,1)
	IF (@gestUsr = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,2)
	IF (@gestCli = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,3)
	IF (@gestHotel = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,4)
	IF (@gestHab = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,5)
	IF (@gestRes = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,6)
	IF (@cancelRes = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,7)
	IF (@gestConsu = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,8)
	IF (@gestEstad = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,9)
	IF (@gestFactu = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,10)
	IF (@listados = 1) INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol,fk_funcion) VALUES (@RolId,11)
	
END
GO
GO
