if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Funcionalidades_Roles')
    drop table Funcionalidades_Roles;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Funcionalidades')
    drop table Funcionalidades;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Roles_Usuarios')
    drop table Roles_Usuarios;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Roles')
    drop table Roles;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Usuarios_Hoteles')
    drop table Usuarios_Hoteles;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Reservas_Canceladas')
    drop table Reservas_Canceladas;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Reservas')
    drop table Reservas;

if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Usuarios')
    drop table Usuarios;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Empleados')
    drop table Empleados;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Clientes')
	drop table Clientes;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Habitaciones')
    drop table Habitaciones;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Tipos_Habitaciones')
    drop table Tipos_Habitaciones;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Regimenes_Hoteles')
    drop table Regimenes_Hoteles;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Bajas_por_hotel')
    drop table Bajas_por_hotel;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Hoteles')
    drop table Hoteles;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Regimenes')
    drop table Regimenes;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Items')
    drop table Items;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Facturas')
    drop table Facturas;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Consumibles')
    drop table Consumibles;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Habitaciones_Reservas')
    drop table Habitaciones_Reservas;


CREATE TABLE Hoteles (
	id_hotel integer PRIMARY KEY identity(1,1),
	ciudad varchar(30),
	calle varchar(60),
	nro_calle integer,
	cant_estrellas tinyint,
	recarga_estrella smallint,
	estado_hotel tinyint DEFAULT 1 
)

CREATE TABLE Bajas_por_hotel(
	id_baja_hotel integer PRIMARY KEY identity(1,1),
	fk_hotel integer REFERENCES Hoteles(id_hotel),
	fecha_inicio DATETIME,
	fecha_fin DATETIME,
	motivo varchar(100)
)

CREATE TABLE Tipos_Habitaciones(
  id_tipo_habitacion int PRIMARY KEY,
  descripcion varchar(60),
  porcentual decimal(4,2)
)


CREATE TABLE Habitaciones (
	id_habitacion integer PRIMARY KEY identity(1,1),
	fk_hotel integer REFERENCES Hoteles(id_hotel),
	nro_habitacion int,
	piso tinyint,
	frente char(1),
	tipo_habitacion int REFERENCES Tipos_Habitaciones(id_tipo_habitacion),
	estado_habitacion tinyint DEFAULT 1 
)


CREATE TABLE Regimenes(
  id_regimen tinyint PRIMARY KEY identity(1,1),
  descripcion varchar(60),
  precio decimal(6,2),
)

CREATE TABLE Regimenes_Hoteles (
    fk_hotel integer references Hoteles(id_hotel),
	fk_regimen tinyint references Regimenes(id_regimen),
	primary key (fk_hotel,fk_regimen)
)

CREATE TABLE Clientes (
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

CREATE TABLE Facturas (
    id_factura INTEGER PRIMARY KEY,
    fecha DATETIME,
    total_factura INTEGER,
    forma_pago VARCHAR(30),
    detalle_forma_pago VARCHAR(120),
    fk_reserva integer
)

CREATE TABLE Consumibles(
    id_consumible INTEGER PRIMARY KEY,
    descripcion VARCHAR(60),
    precio INTEGER
)

CREATE TABLE Items(
    fk_factura INTEGER,
    nro_item INTEGER IDENTITY(1,1),
    fk_consumible INTEGER,
    cantidad_prod INTEGER,
    monto_item INTEGER,
    primary key (fk_factura,nro_item),
    foreign key (fk_consumible) references Consumibles (id_consumible),
    foreign key (fk_factura) references Facturas (id_factura)
)

CREATE TABLE Reservas (
  id_reserva integer PRIMARY KEY,
  fecha_inicio datetime,
  cant_noches_reserva tinyint,
  cant_noches_estadia tinyint,
  fk_usuario_reserva integer,
  fk_usuario_ultima_modificacion integer,
  fk_regimen tinyint references Regimenes(id_regimen),
  fk_cliente integer references Clientes(id_cliente),
  estado_reserva tinyint DEFAULT 0
)

CREATE TABLE Reservas_Canceladas (
	fk_reserva integer PRIMARY KEY REFERENCES Reservas(id_reserva),
	motivo varchar(120),
	fecha_cancelacion datetime
)

CREATE TABLE Habitaciones_Reservas (
  fk_habitacion integer,
  fk_reserva integer,
  PRIMARY KEY (fk_habitacion,fk_reserva)
)

CREATE TABLE Empleados (
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

CREATE TABLE Roles (
	id_rol tinyint PRIMARY KEY identity(1,1),
	nombre varchar(30),
	descripcion varchar(90),
	estado_rol tinyint DEFAULT 1
 ) 


CREATE TABLE Usuarios (
	id_usuario integer PRIMARY KEY identity(1,1),
	usr_name varchar(30) NOT NULL UNIQUE,
	pssword varchar(30) NOT NULL,
	fk_empleado smallint REFERENCES Empleados(id_empleado),
	estado_usr tinyint DEFAULT 1
 )


CREATE TABLE Roles_Usuarios (
   fk_rol tinyint references Roles (id_rol),
   fk_usuario integer references Usuarios (id_usuario)
)



 CREATE TABLE Usuarios_Hoteles (
   fk_hotel integer references Hoteles(id_hotel),
   fk_usuario integer references Usuarios(id_usuario)
)

CREATE TABLE Funcionalidades (
	id_funcion smallint PRIMARY KEY identity(1,1),
	nombre varchar(30),
	descripicion varchar(120),
	estado_func tinyint DEFAULT 1
)

CREATE TABLE Funcionalidades_Roles (
  fk_rol tinyint references Roles(id_rol),
  fk_funcion smallint references Funcionalidades(id_funcion)
)

	/* Migración de datos */
INSERT INTO Roles(nombre,descripcion) VALUES ('Administrador General','Administra todos los aspectos de la aplicación')
INSERT INTO Roles(nombre,descripcion) VALUES ('Recepcionista','Poseé funcionalidades de atención al público')
INSERT INTO Roles(nombre,descripcion) VALUES ('Guest','Permite realizar reservas')

INSERT INTO Usuarios(usr_name, pssword) VALUES('admin','w23e') /*El pssword debe ir con SHA256*/
INSERT INTO Usuarios(usr_name, pssword) VALUES('guest','guest')

INSERT INTO Roles_Usuarios(fk_usuario, fk_rol) VALUES(1,1)
INSERT INTO Roles_Usuarios(fk_usuario, fk_rol) VALUES(2,3)

INSERT INTO Funcionalidades(nombre, descripicion) VALUES('Gestionar roles','Permite operaciones de alta, baja, y modificaciones de ROLES')
INSERT INTO Funcionalidades(nombre, descripicion) VALUES('Gestionar usuarios','Permite operaciones de alta, baja, y modificaciones de USUARIOS')
INSERT INTO Funcionalidades(nombre, descripicion) VALUES('Gestionar clientes','Permite operaciones de alta, baja, y modificaciones de CLIENTES')
INSERT INTO Funcionalidades(nombre, descripicion) VALUES('Gestionar hoteles','Permite operaciones de alta, baja, y modificaciones de HOTELES')
INSERT INTO Funcionalidades(nombre, descripicion) VALUES('Gestionar habitaciones','Permite operaciones de alta, baja, y modificaciones de HABITACIONES')
INSERT INTO Funcionalidades(nombre, descripicion) VALUES('Gestionar reservas','Permite operaciones de alta, baja, y modificaciones de RESERVAS')
INSERT INTO Funcionalidades(nombre, descripicion) VALUES('Gestionar consumibles','Permite operaciones de alta, baja, y modificaciones de CONSUMIBLES')
INSERT INTO Funcionalidades(nombre, descripicion) VALUES('Facturación','Permite registrar facturas')
INSERT INTO Funcionalidades(nombre, descripicion) VALUES('Listado estadístico','Permite acceder a datos estadísticos, y emitir informes')

INSERT INTO Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,1)
INSERT INTO Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,2)
INSERT INTO Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,3)
INSERT INTO Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,4)
INSERT INTO Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,5)
INSERT INTO Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,6)
INSERT INTO Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,7)
INSERT INTO Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,8)
INSERT INTO Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(1,9)
INSERT INTO Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(2,3)
INSERT INTO Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(2,6)
INSERT INTO Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(2,8)
INSERT INTO Funcionalidades_Roles(fk_rol, fk_funcion) VALUES(3,6)


INSERT INTO Hoteles(ciudad,calle,nro_calle,cant_estrellas,recarga_estrella)
	SELECT DISTINCT Hotel_Ciudad,Hotel_Calle,Hotel_Nro_Calle,Hotel_CantEstrella,Hotel_Recarga_Estrella
	FROM gd_esquema.Maestra ORDER BY Hotel_Ciudad;

INSERT INTO Tipos_Habitaciones
	SELECT DISTINCT Habitacion_Tipo_Codigo,Habitacion_Tipo_Descripcion,Habitacion_Tipo_Porcentual
	FROM gd_esquema.Maestra

INSERT INTO Habitaciones(fk_hotel,nro_habitacion,frente,piso,tipo_habitacion)
	SELECT DISTINCT h.id_hotel, m.Habitacion_Numero, m.Habitacion_Frente, m.Habitacion_Piso, m.Habitacion_Tipo_Codigo
	FROM gd_esquema.Maestra m JOIN Hoteles h ON 
	  ((h.ciudad = m.Hotel_Ciudad) AND
		(h.calle = m.Hotel_Calle) AND
		(h.nro_calle = m.Hotel_Nro_Calle))
    

INSERT INTO Regimenes(descripcion,precio)
  SELECT DISTINCT Regimen_Descripcion,Regimen_Precio FROM gd_esquema.Maestra;


INSERT INTO Regimenes_Hoteles
	SELECT DISTINCT h.id_hotel,r.id_regimen
	FROM gd_esquema.Maestra m JOIN Regimenes r ON (r.descripcion = m.Regimen_Descripcion) AND (r.precio = m.Regimen_Precio)
		JOIN Hoteles h ON ( (h.ciudad = m.Hotel_Ciudad) AND
		(h.calle = m.Hotel_Calle) AND
		(h.nro_calle = m.Hotel_Nro_Calle) )
	ORDER BY 1

INSERT INTO Clientes (nombre,apellido,mail,dom_Calle,nro_Calle,piso,depto,fecha_Nac,nacionalidad,pasaporte_Nro) 
	(SELECT DISTINCT Cliente_Nombre, Cliente_Apellido, 
	Cliente_Mail, Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso, Cliente_Depto, 
	Cliente_Fecha_Nac, Cliente_Nacionalidad, Cliente_Pasaporte_Nro 
	FROM gd_esquema.Maestra)

INSERT INTO Facturas (id_factura,fecha,total_factura,fk_reserva,forma_pago,detalle_forma_pago)
	(SELECT DISTINCT Factura_Nro, Factura_Fecha, Factura_Total, Reserva_Codigo,'Efectivo','Pago en efectivo'
	 FROM gd_esquema.Maestra WHERE(Factura_Nro IS NOT NULL))

INSERT INTO Consumibles (id_consumible, descripcion, precio)
	(SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
	 FROM gd_esquema.Maestra 
	 WHERE(Consumible_Codigo IS NOT NULL))

INSERT INTO Items (cantidad_prod,monto_item, fk_factura, fk_consumible)
	(SELECT DISTINCT Item_Factura_Cantidad, Item_Factura_Monto, Factura_Nro, Consumible_Codigo
	 FROM gd_esquema.Maestra WHERE (Factura_Nro IS NOT NULL AND Consumible_Codigo IS NOT NULL))

INSERT INTO Reservas (id_reserva,fecha_inicio,cant_noches_reserva,fk_regimen,fk_cliente)
	SELECT m.Reserva_Codigo, m.Reserva_Fecha_Inicio, m.Reserva_Cant_Noches, r.id_regimen, c.id_cliente
	FROM gd_esquema.Maestra m JOIN Regimenes r ON (m.Regimen_Descripcion = r.descripcion) AND (m.Regimen_Precio = r.precio)
							  JOIN Clientes c ON (m.Cliente_Fecha_Nac = c.fecha_Nac) AND (m.Cliente_Pasaporte_Nro = c.pasaporte_Nro)
	WHERE m.Estadia_Fecha_Inicio is null

INSERT INTO Habitaciones_Reservas (fk_habitacion,fk_reserva)
	SELECT ha.id_habitacion, m.Reserva_Codigo
	FROM Hoteles ho JOIN gd_esquema.Maestra m ON (ho.calle=m.Hotel_Calle AND ho.ciudad=m.Hotel_Ciudad AND ho.nro_calle=m.Hotel_Nro_Calle AND ho.cant_estrellas=m.Hotel_CantEstrella)
				   JOIN Habitaciones ha ON (ha.fk_hotel = ho.id_hotel AND ha.frente=m.Habitacion_Frente AND ha.nro_habitacion=m.Habitacion_Numero AND ha.piso=m.Habitacion_Piso AND ha.tipo_habitacion=m.Habitacion_Tipo_Codigo)
	WHERE m.Estadia_Fecha_Inicio IS NULL



/* Creación de Procedimientos */


/*------------------------------------ABM CLIENTE--------------------------------------------------*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'altaCliente'))
DROP PROCEDURE altaCliente

GO
CREATE PROCEDURE altaCliente (@Nombre VARCHAR(60), @Apellido VARCHAR(60), @Mail VARCHAR(255), @Dom_Calle VARCHAR(90), @Nro_Calle INTEGER, @Piso TINYINT, @Depto VARCHAR(5), @Fecha_Nac DATETIME, @Nacionalidad VARCHAR(60), @Pasaporte_Nro INTEGER)
AS
BEGIN

	DECLARE @UserId INT
	DECLARE @PersonalDataId INT
	
	SELECT * FROM Clientes C WHERE C.pasaporte_Nro=@Pasaporte_Nro OR C.mail=@Mail
	IF (@@ROWCOUNT >0)
	BEGIN
		RETURN @@ROWCOUNT
	END

	INSERT INTO Clientes (nombre,apellido,mail,dom_Calle,nro_Calle,piso,depto,fecha_Nac,nacionalidad,pasaporte_Nro)
	VALUES (@Nombre, @Apellido, @Mail, @Dom_Calle, @Nro_Calle, @Piso, @Depto, @Fecha_Nac, @Nacionalidad, @Pasaporte_Nro)
END
GO
/*-----------------------------------ABM CLIENTE FIN----------------------------------------------------*/

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'procInconsistenciasClientes' AND type = 'P')
 DROP PROCEDURE procInconsistenciasClientes


GO
CREATE PROC procInconsistenciasClientes
AS
BEGIN
	UPDATE Clientes SET inconsistente = 1
		WHERE	pasaporte_Nro IN (SELECT c.pasaporte_Nro
								FROM Clientes c
								GROUP BY c.pasaporte_Nro
								HAVING COUNT(c.mail)>1 )
				OR mail IN		(SELECT c.mail
								FROM Clientes c
								GROUP BY c.mail
								HAVING COUNT(c.pasaporte_Nro)>1 )
END;
GO

EXECUTE procInconsistenciasClientes


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




IF EXISTS (SELECT name FROM sysobjects WHERE name = 'procEstadoReserva' AND type = 'P')
 DROP PROCEDURE procEstadoReserva

GO
CREATE PROCEDURE procEstadoReserva
 AS
   BEGIN
	   UPDATE Reservas 
		SET	estado_reserva= 5,   /*Efectivizada*/
			cant_noches_estadia = (	select m.Estadia_Cant_Noches
									from gd_esquema.Maestra m
									where m.Reserva_Codigo = id_reserva AND
									m.Estadia_Fecha_Inicio IS NOT NULL AND
									m.Factura_Nro IS NULL)
		  WHERE id_reserva IN 
			  (SELECT r.id_reserva FROM Facturas f JOIN Reservas r ON (r.id_reserva=f.fk_reserva)
							)
	  UPDATE Reservas
		SET estado_reserva = 4 /* Cancelada por No-Show*/
		 WHERE id_reserva NOT IN
			  (SELECT r.id_reserva FROM Facturas f JOIN Reservas r ON (r.id_reserva=f.fk_reserva))
   END;	        
 GO
 
EXECUTE procEstadoReserva


/*TOP 5 Reservas canceladas*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'top5HotelesReservasCanceladas'))
DROP procedure top5HotelesReservasCanceladas

GO
CREATE PROCEDURE top5HotelesReservasCanceladas(@año int,@inicioTri int,@finTri int)
 AS
  BEGIN
SELECT TOP 5 ho.id_hotel'Id',COUNT(r.id_reserva)'Reservas canceladas' 
  FROM Hoteles ho JOIN Habitaciones ha ON (ho.id_hotel=ha.fk_hotel)
                  JOIN Habitaciones_Reservas hr ON (ha.id_habitacion=hr.fk_habitacion)
                  JOIN Reservas r ON (r.id_reserva=hr.fk_reserva)
    WHERE (r.estado_reserva IN (2,3,4)) AND (YEAR(r.fecha_inicio)=@año) AND (MONTH(r.fecha_inicio) BETWEEN @inicioTri AND @finTri)
      GROUP BY ho.id_hotel
		ORDER BY 2 DESC

  END
  GO
     
 /* TOP 5 Consumibles Facturados*/   

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'top5HotelesConsumiblesFacturados'))
DROP procedure top5HotelesConsumiblesFacturados

GO
CREATE PROCEDURE top5HotelesConsumiblesFacturados(@año int,@inicioTri int,@finTri int)
 AS
  BEGIN
SELECT TOP 5 ho.id_hotel'Id',SUM(i.cantidad_prod)'Consumibles facturados'
  FROM Hoteles ho JOIN Habitaciones ha ON (ho.id_hotel=ha.fk_hotel)
                  JOIN Habitaciones_Reservas hr ON (ha.id_habitacion=hr.fk_habitacion)
                  JOIN Reservas r ON (r.id_reserva=hr.fk_reserva)
                  JOIN Facturas f ON (f.fk_reserva=r.id_reserva)
                  JOIN Items i ON (i.fk_factura=f.id_factura)
                  JOIN Consumibles c ON (i.fk_consumible=c.id_consumible)
    WHERE ( (YEAR(f.fecha)=@año) AND (MONTH(f.fecha) BETWEEN @inicioTri AND @finTri))
	GROUP BY ho.id_hotel
		ORDER BY 2 DESC
  END	
GO

/* TOP 5 Hoteles fuera de Servicio */


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'top5HotelesFueraDeServicio'))
DROP procedure top5HotelesFueraDeServicio

GO
CREATE PROCEDURE top5HotelesFueraDeServicio (@año int, @inicioTri int, @finTri int)
AS

 BEGIN
SELECT TOP 5 b.fk_hotel'Id',SUM(DATEDIFF(day,b.fecha_fin,b.fecha_inicio))'Días fuera de servicio'
   FROM Bajas_por_hotel b
    WHERE ( (YEAR(b.fecha_inicio)=YEAR(b.fecha_fin)) AND (MONTH(b.fecha_inicio) >= @inicioTri AND MONTH(b.fecha_fin)<= @finTri) )
    
    GROUP BY b.fk_hotel
		ORDER BY 2 DESC
  END
GO  		
		

 /* TOP 5 Habitaciones más ocupadas */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'top5HabitacionesMasOcupadas'))
DROP procedure top5HabitacionesMasOcupadas

GO
CREATE PROCEDURE top5HabitacionesMasOcupadas (@año int,@inicioTri int, @finTri int)
AS
BEGIN
SELECT TOP 5 ha.id_habitacion'Id', ha.fk_hotel'Id de hotel',SUM(r.cant_noches_estadia)'Días ocupada'
  FROM Reservas r JOIN Habitaciones_Reservas hr ON (r.id_reserva=hr.fk_reserva)
                  JOIN Habitaciones ha ON (ha.id_habitacion=hr.fk_habitacion)
    WHERE ( (YEAR(r.fecha_inicio)=@año) AND (MONTH(r.fecha_inicio) BETWEEN @inicioTri AND @finTri) )
    GROUP BY ha.id_habitacion,ha.fk_hotel
		ORDER BY 3 DESC
 END
 GO	

/* TOP 5 Clientes mejores puntuados*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'top5ClientesMejoresPuntuados'))
DROP procedure top5ClientesMejoresPuntuados

GO
CREATE PROCEDURE top5ClientesMejoresPuntuados (@año int,@inicioTri int, @finTri int)
AS
BEGIN

SELECT TOP 5 cl.id_cliente'Id',cl.nombre'Nombre',cl.apellido'Apellido',SUM( ((re.precio*r.cant_noches_estadia)/10)+((i.cantidad_prod*c.precio)/5) )'Puntos'
  FROM Clientes cl JOIN Reservas r ON (r.fk_cliente=cl.id_cliente)
				   JOIN Regimenes re ON (r.fk_regimen=re.id_regimen)
				   JOIN Facturas f ON (r.id_reserva=f.fk_reserva)
				   JOIN Items i ON (i.fk_factura=f.id_factura)
				   JOIN Consumibles c ON (c.id_consumible=i.fk_consumible)
	WHERE ( (YEAR(f.fecha)=@año) AND (MONTH(f.fecha) BETWEEN @inicioTri AND @finTri) )
	
	GROUP BY cl.id_cliente,cl.nombre,cl.apellido
		ORDER BY 4 DESC

 END
 GO 