using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;
using FrbaHotel.Commons.FuncionalidadesVarias;

namespace FrbaHotel.Registrar_Consumible
{
    class AppModel_Consumible
    {
        private Conexion sqlconexion = Conexion.Instance;
        Funcionalidades funcionesVarias = new Funcionalidades();


        public DataTable cargarConsumibles(string codigoReservaActual)
    {
        StringBuilder sentence = new StringBuilder().AppendFormat(string.Format("SELECT DISTINCT h.nro_habitacion,c.descripcion,ceh.cantidad FROM SQLECT.Consumibles_Estadias_Habitaciones ceh JOIN SQLECT.Consumibles c ON (ceh.fk_consumible=c.id_consumible) JOIN SQLECT.Habitaciones h ON (ceh.fk_habitacion=h.id_habitacion) JOIN SQLECT.Estadias e ON (e.id_estadia=ceh.fk_estadia) JOIN SQLECT.Reservas r ON (e.fk_reserva=r.id_reserva) WHERE r.codigo_reserva='{0}' AND ceh.cantidad>0", codigoReservaActual));
        DataTable tablaConsumibles = Conexion.Instance.ejecutarQuery(sentence.ToString());

        return tablaConsumibles;
    }
        
        
        public bool verificarHabitacionDeReserva(string codigoReserva, int numeroHabitacion)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@numeroHabitacion", SqlDbType.Int);

            comandoAReserva.Parameters[0].Value = codigoReserva;
            comandoAReserva.Parameters[1].Value = numeroHabitacion;

            comandoAReserva.CommandText = "SQLECT.verificarHabitacionDeReserva";
            bool existenciaDeHabitacion = conexion.ejecutarEscalar(comandoAReserva);

            return existenciaDeHabitacion;
        
        }

        public void registrarConsumible(string codigoReserva, int numeroHabitacion, string consumible, int cantidadConsumida)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@numeroHabitacion", SqlDbType.Int);
            comandoAReserva.Parameters.Add("@consumible", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@cantidadConsumida", SqlDbType.Int);

            comandoAReserva.Parameters[0].Value = codigoReserva;
            comandoAReserva.Parameters[1].Value = numeroHabitacion;
            comandoAReserva.Parameters[2].Value = consumible;
            comandoAReserva.Parameters[3].Value = cantidadConsumida;

            comandoAReserva.CommandText = "SQLECT.registrarConsumible";
            conexion.ejecutarSP(comandoAReserva);
        
        }

        public void modificarConsumible(string codigoReserva, int numeroHabitacion, string consumible, int cantidadConsumida)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@numeroHabitacion", SqlDbType.Int);
            comandoAReserva.Parameters.Add("@consumible", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@cantidadConsumida", SqlDbType.Int);

            comandoAReserva.Parameters[0].Value = codigoReserva;
            comandoAReserva.Parameters[1].Value = numeroHabitacion;
            comandoAReserva.Parameters[2].Value = consumible;
            comandoAReserva.Parameters[3].Value = cantidadConsumida;

            comandoAReserva.CommandText = "SQLECT.modificarConsumible";
            conexion.ejecutarSP(comandoAReserva);
        
        }
        public void eliminarConsumible(string codigoReserva, int numeroHabitacion, string consumible)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@numeroHabitacion", SqlDbType.Int);
            comandoAReserva.Parameters.Add("@consumible", SqlDbType.VarChar);
            
            comandoAReserva.Parameters[0].Value = codigoReserva;
            comandoAReserva.Parameters[1].Value = numeroHabitacion;
            comandoAReserva.Parameters[2].Value = consumible;
            
            comandoAReserva.CommandText = "SQLECT.eliminarConsumible";
            conexion.ejecutarSP(comandoAReserva);
        
        }
    


    }


}