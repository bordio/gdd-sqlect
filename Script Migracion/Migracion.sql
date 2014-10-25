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
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Reservas')
    drop table Reservas;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Usuarios')
    drop table Usuarios;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Clientes')
	drop table Clientes
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Habitaciones')
    drop table Habitaciones;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Tipos_Habitaciones')
    drop table Tipos_Habitaciones;
    
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Regimenes_Hoteles')
    drop table Regimenes_Hoteles;
    
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

if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Inconsistencias')
    drop table Inconsistencias;


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
  descripcion varchar(100),
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
  descripcion varchar(90),
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
  cant_noches integer,
  fk_usuario_reserva integer,
  fk_usuario_ultima_modificacion integer,
  fk_regimen tinyint references Regimenes(id_regimen),
  fk_cliente integer references Clientes(id_cliente),
  estado_reserva tinyint,
  cant_noches_estadia tinyint
)

CREATE TABLE Habitaciones_Reservas (
  fk_habitacion integer,
  fk_reserva integer,
  PRIMARY KEY (fk_habitacion,fk_reserva)
)

CREATE TABLE Roles (
	id_rol tinyint PRIMARY KEY identity(1,1),
	nombre varchar(30),
	descripcion varchar(60),
	estado_rol tinyint DEFAULT 1
 ) 

INSERT INTO Roles(nombre,descripcion) VALUES ('Administrador','Administrador')
INSERT INTO Roles(nombre,descripcion) VALUES ('Recepcionista','Recepcionista')
INSERT INTO Roles(nombre,descripcion) VALUES ('Guest','Guest')

CREATE TABLE Usuarios (
	id_usuario integer PRIMARY KEY identity(1,1),
	usr_name varchar(30) NOT NULL UNIQUE,
	pssword varchar(30) NOT NULL,
	nombre varchar(30),
	apellido varchar(60),
	estado_usr tinyint DEFAULT 1
 )  

CREATE TABLE Roles_Usuarios (
   fk_rol tinyint references Roles (id_rol),
   fk_usuario integer references Usuarios (id_usuario),
   fk_hotel integer references Hoteles(id_hotel)
)

 CREATE TABLE Usuarios_Hoteles (
   fk_hotel integer references Hoteles(id_hotel),
   fk_usuario integer references Usuarios(id_usuario)
)

CREATE TABLE Funcionalidades (
	id_funcion smallint PRIMARY KEY identity(1,1),
	nombre varchar(30),
	descripicion varchar(120),
	estado_func tinyint
)

CREATE TABLE Funcionalidades_Roles (
  fk_funcion smallint references Funcionalidades(id_funcion),
  fk_rol tinyint references Roles(id_rol),
)

CREATE TABLE Inconsistencias(
	id_inconsistencia integer primary key identity(1,1),
	tabla varchar(30),
	fk_registro integer,
	descripcion varchar(90)
)


/*
GO
CREATE TRIGGER trigInsertCli
ON Clientes
INSTEAD OF INSERT
AS
BEGIN
	DECLARE InsertCursor CURSOR FOR
	SELECT nombre,apellido,mail,dom_Calle,nro_Calle,piso,depto,fecha_Nac,nacionalidad,pasaporte_Nro FROM inserted
	DECLARE @nombre varchar(60), @apellido varchar(60), @mail varchar(255),
		@dom_calle varchar(90), @nro_calle integer, @piso tinyint, @depto varchar(5),
		@fecha_nac datetime,@nacionalidad varchar(60),@pasaporte_nro integer 

  OPEN InsertCursor;

  FETCH NEXT FROM InsertCursor INTO @nombre,@apellido,@mail,@dom_calle,@nro_calle,@piso,@depto,@fecha_nac,@nacionalidad,@pasaporte_nro

  WHILE @@FETCH_STATUS = 0
  BEGIN
	DECLARE @es_inconsistente tinyint = 0
	DECLARE @id_ultima_inconsistencia_mail integer = 0
	DECLARE @id_ultima_inconsistencia_pasaporte integer = 0
	DECLARE @id_cliente_inconsistente integer
	IF EXISTS (SELECT id_cliente FROM Clientes WHERE @mail=mail)
		BEGIN
			SET @es_inconsistente = 1;
			INSERT INTO Inconsistencias(tabla,descripcion) VALUES ('Clientes','Ya fue registrado un cliente con ese email')
			SET @id_ultima_inconsistencia_mail = SCOPE_IDENTITY()
		END
	IF EXISTS (SELECT id_cliente FROM Clientes WHERE @pasaporte_nro=pasaporte_Nro)
		BEGIN
			SET @es_inconsistente = 1;
			INSERT INTO Inconsistencias(tabla,descripcion) VALUES ('Clientes','Ya fue registrado un cliente con ese numero de pasaporte')
			SET @id_ultima_inconsistencia_pasaporte = SCOPE_IDENTITY()
		END
	INSERT INTO Clientes(nombre,apellido,mail,dom_Calle,nro_Calle,piso,depto,fecha_Nac,nacionalidad,pasaporte_Nro,inconsistente)
		VALUES (@nombre,@apellido,@mail,@dom_calle,@nro_calle,@piso,@depto,@fecha_nac,@nacionalidad,@pasaporte_nro,@es_inconsistente)
	SET @id_cliente_inconsistente = SCOPE_IDENTITY()
	IF (@id_ultima_inconsistencia_mail>0) 
		BEGIN
			UPDATE Inconsistencias SET fk_registro=@id_cliente_inconsistente WHERE id_inconsistencia=@id_ultima_inconsistencia_mail
		END;
	IF (@id_ultima_inconsistencia_pasaporte>0) 
		BEGIN
			UPDATE Inconsistencias SET fk_registro=@id_cliente_inconsistente WHERE id_inconsistencia=@id_ultima_inconsistencia_pasaporte
		END;
	FETCH NEXT FROM InsertCursor INTO @nombre,@apellido,@mail,@dom_calle,@nro_calle,@piso,@depto,@fecha_nac,@nacionalidad,@pasaporte_nro
  END;

  CLOSE InsertCursor;
  DEALLOCATE InsertCursor;
  
END;
GO
*/


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

INSERT INTO Facturas (id_factura,fecha,total_factura,fk_reserva) 
	(SELECT DISTINCT Factura_Nro, Factura_Fecha, Factura_Total, Reserva_Codigo
	 FROM gd_esquema.Maestra WHERE(Factura_Nro IS NOT NULL))

INSERT INTO Consumibles (id_consumible, descripcion, precio)
	(SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
	 FROM gd_esquema.Maestra 
	 WHERE(Consumible_Codigo IS NOT NULL))

INSERT INTO Items (cantidad_prod,monto_item, fk_factura, fk_consumible)
	(SELECT DISTINCT Item_Factura_Cantidad, Item_Factura_Monto, Factura_Nro, Consumible_Codigo
	 FROM gd_esquema.Maestra WHERE (Factura_Nro IS NOT NULL AND Consumible_Codigo IS NOT NULL))

INSERT INTO Reservas (id_reserva,fecha_inicio,cant_noches,fk_regimen,fk_cliente)
	SELECT m.Reserva_Codigo, m.Reserva_Fecha_Inicio, m.Reserva_Cant_Noches, r.id_regimen, c.id_cliente
	FROM gd_esquema.Maestra m JOIN Regimenes r ON (m.Regimen_Descripcion = r.descripcion) AND (m.Regimen_Precio = r.precio)
							  JOIN Clientes c ON (m.Cliente_Fecha_Nac = c.fecha_Nac) AND (m.Cliente_Pasaporte_Nro = c.pasaporte_Nro)
	WHERE m.Estadia_Fecha_Inicio is null

INSERT INTO Habitaciones_Reservas (fk_habitacion,fk_reserva)
	SELECT ha.id_habitacion, m.Reserva_Codigo
	FROM Hoteles ho JOIN gd_esquema.Maestra m ON (ho.calle=m.Hotel_Calle AND ho.ciudad=m.Hotel_Ciudad AND ho.nro_calle=m.Hotel_Nro_Calle AND ho.cant_estrellas=m.Hotel_CantEstrella)
				   JOIN Habitaciones ha ON (ha.fk_hotel = ho.id_hotel AND ha.frente=m.Habitacion_Frente AND ha.nro_habitacion=m.Habitacion_Numero AND ha.piso=m.Habitacion_Piso AND ha.tipo_habitacion=m.Habitacion_Tipo_Codigo)
	WHERE m.Estadia_Fecha_Inicio IS NULL


/*
SELECT COUNT(pasaporte_Nro),mail
FROM Clientes
GROUP BY mail
HAVING COUNT(pasaporte_Nro)>1
ORDER BY 1 DESC 
*/

SELECT * FROM gd_esquema.Maestra