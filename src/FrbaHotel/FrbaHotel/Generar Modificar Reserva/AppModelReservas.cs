using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;
using FrbaHotel.Commons.FuncionalidadesVarias;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    class AppModel_Reservas
    {
        private Conexion sqlconexion = Conexion.Instance;
        Funcionalidades funcionesVarias = new Funcionalidades();


        public DataTable habitacionesMaximasDisponibles(string fechaDesde, string fechaHasta, int idHotel)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@fechaDesde", SqlDbType.DateTime);
            comandoAReserva.Parameters.Add("@fechaHasta", SqlDbType.DateTime);
            comandoAReserva.Parameters.Add("@idHotel", SqlDbType.Int);

            comandoAReserva.Parameters[0].Value = DateTime.Parse(fechaDesde);
            comandoAReserva.Parameters[1].Value = DateTime.Parse(fechaHasta);
            comandoAReserva.Parameters[2].Value = idHotel;


            comandoAReserva.CommandText = "SQLECT.obtenerMaximasHabitacionesDisponibles";
            DataTable maximasDisponibles = conexion.ejecutarQueryConSP(comandoAReserva);

            return maximasDisponibles;
        }

    }

}