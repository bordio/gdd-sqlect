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

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Reservas') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Reservas

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Usuarios') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Usuarios

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Empleados') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Empleados

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Clientes') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Clientes

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Habitaciones') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Habitaciones

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Tipos_Habitaciones') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Tipos_Habitaciones

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Regimenes_Hoteles') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Regimenes_Hoteles

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Bajas_por_hotel') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Bajas_por_hotel

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Hoteles') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Hoteles

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Regimenes') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Regimenes

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Items') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Items

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Facturas') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Facturas

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Consumibles') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Consumibles

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SQLECT.Habitaciones_Reservas') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SQLECT.Habitaciones_Reservas






/* Creamos las tablas */
CREATE TABLE SQLECT.Hoteles (
	id_hotel integer PRIMARY KEY identity(1,1),
	nombre varchar(60),
	mail varchar(255),
	fecha_creacion datetime,
	pais varchar(50),
	ciudad varchar(30),
	calle varchar(60),
	nro_calle integer,
	cant_estrellas tinyint,
	recarga_estrella smallint,
	estado_hotel tinyint DEFAULT 1 
)

CREATE TABLE SQLECT.Bajas_por_hotel(
	id_baja_hotel integer PRIMARY KEY identity(1,1),
	fk_hotel integer REFERENCES SQLECT.Hoteles(id_hotel),
	fecha_inicio DATETIME,
	fecha_fin DATETIME,
	motivo varchar(100)
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
    dom_Calle VARCHAR(90),
    nro_Calle INTEGER,
    piso TINYINT,
    depto VARCHAR(5),
    fecha_Nac DATETIME,
    nacionalidad VARCHAR(60),
    pasaporte_Nro INTEGER,
    inconsistente TINYINT DEFAULT 0,
    habilitado TINYINT DEFAULT 1
)

CREATE TABLE SQLECT.Facturas (
    id_factura INTEGER PRIMARY KEY,
    fecha DATETIME,
    total_factura INTEGER,
    forma_pago VARCHAR(30),
    detalle_forma_pago VARCHAR(120),
    fk_reserva integer
)

CREATE TABLE SQLECT.Consumibles(
    id_consumible INTEGER PRIMARY KEY,
    descripcion VARCHAR(60),
    precio INTEGER
)

CREATE TABLE SQLECT.Items(
    fk_factura INTEGER,
    nro_item INTEGER IDENTITY(1,1),
    fk_consumible INTEGER,
    cantidad_prod INTEGER,
    monto_item INTEGER,
    primary key (fk_factura,nro_item),
    foreign key (fk_consumible) references SQLECT.Consumibles (id_consumible),
    foreign key (fk_factura) references SQLECT.Facturas (id_factura)
)

CREATE TABLE SQLECT.Reservas (
  id_reserva integer PRIMARY KEY,
  fecha_inicio datetime,
  cant_noches_reserva tinyint,
  cant_noches_estadia tinyint,
  fk_usuario_reserva integer,
  fk_usuario_ultima_modificacion integer,
  fk_regimen tinyint references SQLECT.Regimenes(id_regimen),
  fk_cliente integer references SQLECT.Clientes(id_cliente),
  estado_reserva tinyint DEFAULT 0
)

CREATE TABLE SQLECT.Reservas_Canceladas (
	fk_reserva integer PRIMARY KEY REFERENCES SQLECT.Reservas(id_reserva),
	motivo varchar(120),
	fecha_cancelacion datetime
)

CREATE TABLE SQLECT.Habitaciones_Reservas (
  fk_habitacion integer,
  fk_reserva integer,
  PRIMARY KEY (fk_habitacion,fk_reserva)
)

CREATE TABLE SQLECT.Empleados (
	id_empleado smallint identity(1,1) PRIMARY KEY,
	dni_tipo tinyint,
	dni_nro integer,
	nombre varchar(30),
	apellido varchar(60),
	email varchar(255),
	telefono integer,
	direccion varchar(90),
	fecha_nacimiento datetime,
	fk_hotel integer
)

CREATE TABLE SQLECT.Roles (
	id_rol tinyint PRIMARY KEY identity(1,1),
	nombre varchar(30),
	descripcion varchar(90),
	estado_rol tinyint DEFAULT 1
 ) 


CREATE TABLE SQLECT.Usuarios (
	id_usuario integer PRIMARY KEY identity(1,1),
	usr_name varchar(30) NOT NULL UNIQUE,
	pssword varchar(30) NOT NULL,
	fk_empleado smallint REFERENCES SQLECT.Empleados(id_empleado),
	estado_usr tinyint DEFAULT 1
 )


CREATE TABLE SQLECT.Roles_Usuarios (
   fk_rol tinyint references SQLECT.Roles (id_rol),
   fk_usuario integer references SQLECT.Usuarios (id_usuario)
)



 CREATE TABLE SQLECT.Usuarios_Hoteles (
   fk_hotel integer references SQLECT.Hoteles(id_hotel),
   fk_usuario integer references SQLECT.Usuarios(id_usuario)
)

CREATE TABLE SQLECT.Funcionalidades (
	id_funcion smallint PRIMARY KEY identity(1,1),
	nombre varchar(30),
	descripicion varchar(120),
	estado_func tinyint DEFAULT 1
)

CREATE TABLE SQLECT.Funcionalidades_Roles (
  fk_rol tinyint references SQLECT.Roles(id_rol),
  fk_funcion smallint references SQLECT.Funcionalidades(id_funcion)
)

	/* Migración de datos */
INSERT INTO SQLECT.Roles(nombre,descripcion) VALUES ('Administrador General','Administra todos los aspectos de la aplicación')
INSERT INTO SQLECT.Roles(nombre,descripcion) VALUES ('Recepcionista','Poseé funcionalidades de atención al público')
INSERT INTO SQLECT.Roles(nombre,descripcion) VALUES ('Guest','Permite realizar reservas')

INSERT INTO SQLECT.Usuarios(usr_name, pssword) VALUES('admin','w23e') /*El pssword debe ir con SHA256*/
INSERT INTO SQLECT.Usuarios(usr_name, pssword) VALUES('guest','guest')

INSERT INTO SQLECT.Roles_Usuarios(fk_usuario, fk_rol) VALUES(1,1)
INSERT INTO SQLECT.Roles_Usuarios(fk_usuario, fk_rol) VALUES(2,3)

INSERT INTO SQLECT.Funcionalidades(nombre, descripicion) VALUES('Gestionar roles','Permite operaciones de alta, baja, y modificaciones de ROLES')
INSERT INTO SQLECT.Funcionalidades(nombre, descripicion) VALUES('Gestionar usuarios','Permite operaciones de alta, baja, y modificaciones de USUARIOS')
INSERT INTO SQLECT.Funcionalidades(nombre, descripicion) VALUES('Gestionar clientes','Permite operaciones de alta, baja, y modificaciones de CLIENTES')
INSERT INTO SQLECT.Funcionalidades(nombre, descripicion) VALUES('Gestionar hoteles','Permite operaciones de alta, baja, y modificaciones de HOTELES')
INSERT INTO SQLECT.Funcionalidades(nombre, descripicion) VALUES('Gestionar habitaciones','Permite operaciones de alta, baja, y modificaciones de HABITACIONES')
INSERT INTO SQLECT.Funcionalidades(nombre, descripicion) VALUES('Gestionar reservas','Permite operaciones de alta, baja, y modificaciones de RESERVAS')
INSERT INTO SQLECT.Funcionalidades(nombre, descripicion) VALUES('Gestionar consumibles','Permite operaciones de alta, baja, y modificaciones de CONSUMIBLES')
INSERT INTO SQLECT.Funcionalidades(nombre, descripicion) VALUES('Facturación','Permite registrar facturas')
INSERT INTO SQLECT.Funcionalidades(nombre, descripicion) VALUES('Listado estadístico','Permite acceder a datos estadísticos, y emitir informes')

INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,1)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,2)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,3)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,4)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,5)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,6)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,7)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,8)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,9)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(2,3)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(2,6)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(2,8)
INSERT INTO SQLECT.Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(3,6)


INSERT INTO SQLECT.Hoteles(ciudad,calle,nro_calle,cant_estrellas,recarga_estrella)
	SELECT DISTINCT Hotel_Ciudad,Hotel_Calle,Hotel_Nro_Calle,Hotel_CantEstrella,Hotel_Recarga_Estrella
	FROM gd_esquema.Maestra ORDER BY Hotel_Ciudad;

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

INSERT INTO SQLECT.Clientes (nombre,apellido,mail,dom_Calle,nro_Calle,piso,depto,fecha_Nac,nacionalidad,pasaporte_Nro) 
	(SELECT DISTINCT Cliente_Nombre, Cliente_Apellido, 
	Cliente_Mail, Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso, Cliente_Depto, 
	Cliente_Fecha_Nac, Cliente_Nacionalidad, Cliente_Pasaporte_Nro 
	FROM gd_esquema.Maestra)

INSERT INTO SQLECT.Facturas (id_factura,fecha,total_factura,fk_reserva,forma_pago,detalle_forma_pago)
	(SELECT DISTINCT Factura_Nro, Factura_Fecha, Factura_Total, Reserva_Codigo,'Efectivo','Pago en efectivo'
	 FROM gd_esquema.Maestra WHERE(Factura_Nro IS NOT NULL))

INSERT INTO SQLECT.Consumibles (id_consumible, descripcion, precio)
	(SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
	 FROM gd_esquema.Maestra 
	 WHERE(Consumible_Codigo IS NOT NULL))

INSERT INTO SQLECT.Items (cantidad_prod,monto_item, fk_factura, fk_consumible)
	(SELECT DISTINCT Item_Factura_Cantidad, Item_Factura_Monto, Factura_Nro, Consumible_Codigo
	 FROM gd_esquema.Maestra WHERE (Factura_Nro IS NOT NULL AND Consumible_Codigo IS NOT NULL))

INSERT INTO SQLECT.Reservas (id_reserva,fecha_inicio,cant_noches_reserva,fk_regimen,fk_cliente)
	SELECT m.Reserva_Codigo, m.Reserva_Fecha_Inicio, m.Reserva_Cant_Noches, r.id_regimen, c.id_cliente
	FROM gd_esquema.Maestra m JOIN SQLECT.Regimenes r ON (m.Regimen_Descripcion = r.descripcion) AND (m.Regimen_Precio = r.precio)
							  JOIN SQLECT.Clientes c ON (m.Cliente_Fecha_Nac = c.fecha_Nac) AND (m.Cliente_Pasaporte_Nro = c.pasaporte_Nro)
	WHERE m.Estadia_Fecha_Inicio is null

INSERT INTO SQLECT.Habitaciones_Reservas (fk_habitacion,fk_reserva)
	SELECT ha.id_habitacion, m.Reserva_Codigo
	FROM SQLECT.Hoteles ho JOIN gd_esquema.Maestra m ON (ho.calle=m.Hotel_Calle AND ho.ciudad=m.Hotel_Ciudad AND ho.nro_calle=m.Hotel_Nro_Calle AND ho.cant_estrellas=m.Hotel_CantEstrella)
				   JOIN SQLECT.Habitaciones ha ON (ha.fk_hotel = ho.id_hotel AND ha.frente=m.Habitacion_Frente AND ha.nro_habitacion=m.Habitacion_Numero AND ha.piso=m.Habitacion_Piso AND ha.tipo_habitacion=m.Habitacion_Tipo_Codigo)
	WHERE m.Estadia_Fecha_Inicio IS NULL



/* Creación de Procedimientos */


/*------------------------------------ABM CLIENTE--------------------------------------------------*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.altaCliente'))
DROP PROCEDURE SQLECT.altaCliente

GO
CREATE PROCEDURE SQLECT.altaCliente (@Nombre VARCHAR(60), @Apellido VARCHAR(60), @Mail VARCHAR(255), @Dom_Calle VARCHAR(90), @Nro_Calle INTEGER, @Piso TINYINT, @Depto VARCHAR(5), @Fecha_Nac DATETIME, @Nacionalidad VARCHAR(60), @Pasaporte_Nro INTEGER)
AS
BEGIN

	DECLARE @UserId INT
	DECLARE @PersonalDataId INT
	
	SELECT * FROM SQLECT.Clientes C WHERE C.pasaporte_Nro=@Pasaporte_Nro OR C.mail=@Mail
	IF (@@ROWCOUNT >0)
	BEGIN
		RETURN @@ROWCOUNT
	END

	INSERT INTO SQLECT.Clientes (nombre,apellido,mail,dom_Calle,nro_Calle,piso,depto,fecha_Nac,nacionalidad,pasaporte_Nro)
	VALUES (@Nombre, @Apellido, @Mail, @Dom_Calle, @Nro_Calle, @Piso, @Depto, @Fecha_Nac, @Nacionalidad, @Pasaporte_Nro)
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
		WHERE	pasaporte_Nro IN (SELECT c.pasaporte_Nro
								FROM SQLECT.Clientes c
								GROUP BY c.pasaporte_Nro
								HAVING COUNT(c.mail)>1 )
				OR mail IN		(SELECT c.mail
								FROM SQLECT.Clientes c
								GROUP BY c.mail
								HAVING COUNT(c.pasaporte_Nro)>1 )
END;
GO

EXECUTE SQLECT.procInconsistenciasClientes


/*							
SELECT COUNT(pasaporte_Nro), mail
FROM Clientes
WHERE inconsistente = 1
GROUP BY mail
HAVING COUNT(pasaporte_Nro)>1
ORDER BY COUNT(pasaporte_Nro) DESC 

SELECT COUNT(mail), pasaporte_Nro
FROM Clientes
WHERE inconsistente = 1
GROUP BY pasaporte_Nro
HAVING COUNT(mail)>1
ORDER BY COUNT(mail) DESC 
							


SELECT * from Clientes where inconsistente = 1 order by mail DESC, pasaporte_Nro DESC
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
			  (SELECT r.id_reserva FROM SQLECT.Facturas f JOIN SQLECT.Reservas r ON (r.id_reserva=f.fk_reserva)
							)
	  UPDATE SQLECT.Reservas
		SET estado_reserva = 4 /* Cancelada por No-Show*/
		 WHERE id_reserva NOT IN
			  (SELECT r.id_reserva FROM SQLECT.Facturas f JOIN SQLECT.Reservas r ON (r.id_reserva=f.fk_reserva))
   END;	        
 GO
 
EXECUTE SQLECT.procEstadoReserva


/*TOP 5 Reservas canceladas*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.top5HotelesReservasCanceladas'))
DROP PROCEDURE SQLECT.top5HotelesReservasCanceladas

GO
CREATE PROCEDURE SQLECT.top5HotelesReservasCanceladas(@año int,@inicioTri int,@finTri int)
 AS
  BEGIN
SELECT TOP 5 ho.id_hotel'Id',COUNT(r.id_reserva)'Reservas canceladas' 
  FROM SQLECT.Hoteles ho JOIN SQLECT.Habitaciones ha ON (ho.id_hotel=ha.fk_hotel)
                  JOIN SQLECT.Habitaciones_Reservas hr ON (ha.id_habitacion=hr.fk_habitacion)
                  JOIN SQLECT.Reservas r ON (r.id_reserva=hr.fk_reserva)
    WHERE (r.estado_reserva IN (2,3,4)) AND (YEAR(r.fecha_inicio)=@año) AND (MONTH(r.fecha_inicio) BETWEEN @inicioTri AND @finTri)
      GROUP BY ho.id_hotel
		ORDER BY 2 DESC

  END
  GO
     
 /* TOP 5 Consumibles Facturados*/   

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.top5HotelesConsumiblesFacturados'))
DROP PROCEDURE SQLECT.top5HotelesConsumiblesFacturados

GO
CREATE PROCEDURE SQLECT.top5HotelesConsumiblesFacturados(@año int,@inicioTri int,@finTri int)
 AS
  BEGIN
SELECT TOP 5 ho.id_hotel'Id',SUM(i.cantidad_prod)'Consumibles facturados'
  FROM SQLECT.Hoteles ho JOIN SQLECT.Habitaciones ha ON (ho.id_hotel=ha.fk_hotel)
                  JOIN SQLECT.Habitaciones_Reservas hr ON (ha.id_habitacion=hr.fk_habitacion)
                  JOIN SQLECT.Reservas r ON (r.id_reserva=hr.fk_reserva)
                  JOIN SQLECT.Facturas f ON (f.fk_reserva=r.id_reserva)
                  JOIN SQLECT.Items i ON (i.fk_factura=f.id_factura)
                  JOIN SQLECT.Consumibles c ON (i.fk_consumible=c.id_consumible)
    WHERE ( (YEAR(f.fecha)=@año) AND (MONTH(f.fecha) BETWEEN @inicioTri AND @finTri))
	GROUP BY ho.id_hotel
		ORDER BY 2 DESC
  END	
GO

/* TOP 5 Hoteles fuera de Servicio */


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.SQLECT.top5HotelesFueraDeServicio'))
DROP PROCEDURE SQLECT.top5HotelesFueraDeServicio

GO
CREATE PROCEDURE SQLECT.top5HotelesFueraDeServicio (@año int, @inicioTri int, @finTri int)
AS

 BEGIN
SELECT TOP 5 b.fk_hotel'Id',SUM(DATEDIFF(day,b.fecha_fin,b.fecha_inicio))'Días fuera de servicio'
   FROM SQLECT.Bajas_por_hotel b
    WHERE ( (YEAR(b.fecha_inicio)=YEAR(b.fecha_fin)) AND (MONTH(b.fecha_inicio) >= @inicioTri AND MONTH(b.fecha_fin)<= @finTri) )
    
    GROUP BY b.fk_hotel
		ORDER BY 2 DESC
  END
GO  		
		

 /* TOP 5 Habitaciones más ocupadas */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLECT.top5HabitacionesMasOcupadas'))
DROP PROCEDURE SQLECT.top5HabitacionesMasOcupadas

GO
CREATE PROCEDURE SQLECT.top5HabitacionesMasOcupadas (@año int,@inicioTri int, @finTri int)
AS
BEGIN
SELECT TOP 5 ha.id_habitacion'Id', ha.fk_hotel'Id de hotel',SUM(r.cant_noches_estadia)'Días ocupada'
  FROM SQLECT.Reservas r JOIN SQLECT.Habitaciones_Reservas hr ON (r.id_reserva=hr.fk_reserva)
                  JOIN SQLECT.Habitaciones ha ON (ha.id_habitacion=hr.fk_habitacion)
    WHERE ( (YEAR(r.fecha_inicio)=@año) AND (MONTH(r.fecha_inicio) BETWEEN @inicioTri AND @finTri) )
    GROUP BY ha.id_habitacion,ha.fk_hotel
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
				   JOIN SQLECT.Facturas f ON (r.id_reserva=f.fk_reserva)
				   JOIN SQLECT.Items i ON (i.fk_factura=f.id_factura)
				   JOIN SQLECT.Consumibles c ON (c.id_consumible=i.fk_consumible)
	WHERE ( (YEAR(f.fecha)=@año) AND (MONTH(f.fecha) BETWEEN @inicioTri AND @finTri) )
	
	GROUP BY cl.id_cliente,cl.nombre,cl.apellido
		ORDER BY 4 DESC

 END
 GO 
