
/*TOP 5 Reservas canceladas*/
SELECT TOP 5 ho.id_hotel,COUNT(r.id_reserva)'Reservas canceladas' 
  FROM Hoteles ho JOIN Habitaciones ha ON (ho.id_hotel=ha.fk_hotel)
                  JOIN Habitaciones_Reservas hr ON (ha.id_habitacion=hr.fk_habitacion)
                  JOIN Reservas r ON (r.id_reserva=hr.fk_reserva)
    WHERE r.estado_reserva IN (2,3,4)
      GROUP BY ho.id_hotel
		ORDER BY 2 DESC
    
 /* TOP 5 Consumibles Facturados*/   
SELECT TOP 5 ho.id_hotel,SUM(i.cantidad_prod)'Consumibles facturados'
  FROM Hoteles ho JOIN Habitaciones ha ON (ho.id_hotel=ha.fk_hotel)
                  JOIN Habitaciones_Reservas hr ON (ha.id_habitacion=hr.fk_habitacion)
                  JOIN Reservas r ON (r.id_reserva=hr.fk_reserva)
                  JOIN Facturas f ON (f.fk_reserva=r.id_reserva)
                  JOIN Items i ON (i.fk_factura=f.id_factura)
                  JOIN Consumibles c ON (i.fk_consumible=c.id_consumible)
   
	GROUP BY ho.id_hotel
		ORDER BY 2 DESC

/* TOP 5 Hoteles fuera de Servicio */
SELECT TOP 5 b.fk_hotel,SUM(DATEDIFF(day,b.fecha_fin,b.fecha_inicio))'Días fuera de servicio'
   FROM Bajas_por_hotel b
    
    GROUP BY b.fk_hotel
		ORDER BY 2 DESC
		
 /* TOP 5 Habitaciones más ocupadas */
SELECT TOP 5 ha.id_habitacion, ha.fk_hotel,SUM(r.cant_noches_estadia)'Días ocupada'
  FROM Reservas r JOIN Habitaciones_Reservas hr ON (r.id_reserva=hr.fk_reserva)
                  JOIN Habitaciones ha ON (ha.id_habitacion=hr.fk_habitacion)
    
    GROUP BY ha.id_habitacion,ha.fk_hotel
		ORDER BY 3 DESC
		
/* TOP 5 Clientes mejores puntuados*/
SELECT TOP 5 cl.id_cliente,cl.nombre,cl.apellido,SUM( ((re.precio*r.cant_noches_estadia)/10)+((i.cantidad_prod*c.precio)/5) )'Puntos'
  FROM Clientes cl JOIN Reservas r ON (r.fk_cliente=cl.id_cliente)
				   JOIN Regimenes re ON (r.fk_regimen=re.id_regimen)
				   JOIN Facturas f ON (r.id_reserva=f.fk_reserva)
				   JOIN Items i ON (i.fk_factura=f.id_factura)
				   JOIN Consumibles c ON (c.id_consumible=i.fk_consumible)
	
	GROUP BY cl.id_cliente,cl.nombre,cl.apellido
		ORDER BY 4 DESC

     
 