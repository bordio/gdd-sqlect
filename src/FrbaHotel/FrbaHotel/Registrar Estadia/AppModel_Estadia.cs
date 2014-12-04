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

    class AppModel_Estadias
    {
        private Conexion sqlconexion = Conexion.Instance;
        Funcionalidades funcionesVarias = new Funcionalidades();

        public bool chequearFechaDeIngreso(string codigoReserva,int fechaDelSistema)
        {
     
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@fechaDelSistema", SqlDbType.VarChar);

            comandoAReserva.Parameters[0].Value = codigoReserva;
            comandoAReserva.Parameters[1].Value = Convert.ToString(fechaDelSistema);

            comandoAReserva.CommandText = "SQLECT.chequearFechaDeIngreso";
            bool mismoDiaQueElInicioDeLaReserva = conexion.ejecutarEscalar(comandoAReserva);

            return mismoDiaQueElInicioDeLaReserva;       
        }

        public void cancelarReservaPorNoShow(string codigoReserva,int fechaDelSistema)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@fechaDelSistema", SqlDbType.VarChar);

            comandoAReserva.Parameters[0].Value = codigoReserva;
            comandoAReserva.Parameters[1].Value = Convert.ToString(fechaDelSistema);

            comandoAReserva.CommandText = "SQLECT.cancelarReservaPorNoShow";
            conexion.ejecutarSP(comandoAReserva);
      
        }

        public void realizarCheckIn(string codigoReserva, string usuario,int fechaDelSistema)
        
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@fechaDelSistema", SqlDbType.VarChar);

            comandoAReserva.Parameters[0].Value = codigoReserva;
            comandoAReserva.Parameters[1].Value = usuario;
            comandoAReserva.Parameters[2].Value= Convert.ToString(fechaDelSistema);

            comandoAReserva.CommandText = "SQLECT.realizarCheckIn";
            conexion.ejecutarSP(comandoAReserva);
        
        }

        public bool chequearFechaDeEgreso(string codigoReserva,int fechaDelSistema)
    
        {   Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@fechaDelSistema", SqlDbType.VarChar);

            comandoAReserva.Parameters[0].Value = codigoReserva;
            comandoAReserva.Parameters[1].Value = Convert.ToString(fechaDelSistema);

            comandoAReserva.CommandText = "SQLECT.chequearFechaDeEgreso";
            bool mismoDiaQueElInicioDeLaReserva = conexion.ejecutarEscalar(comandoAReserva);

            return mismoDiaQueElInicioDeLaReserva;      
               
        }

        public void realizarCheckOut(string codigoReserva, string usuario,int fechaDelSistema)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@fechaDelSistema", SqlDbType.VarChar);

            comandoAReserva.Parameters[0].Value = codigoReserva;
            comandoAReserva.Parameters[1].Value = usuario;
            comandoAReserva.Parameters[2].Value = Convert.ToString(fechaDelSistema);

            comandoAReserva.CommandText = "SQLECT.realizarCheckOut";
            conexion.ejecutarQuery("BEGIN TRANSACTION"); // Comienza transaccion del CheckOut La misma termina con un commit en AppModel_Facturacion: registrarFormaDePago()
            conexion.ejecutarSP(comandoAReserva);
        
        }

        public bool chequearRealizacionDeCheckIn(string codigoReserva)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);

            comandoAReserva.Parameters[0].Value = codigoReserva;

            comandoAReserva.CommandText = "SQLECT.chequearRealizacionDeCheckIn";
            bool yaHizoElCheckIn = conexion.ejecutarEscalar(comandoAReserva);

            return yaHizoElCheckIn;   
        
        }

        public bool chequearRealizacionDeCheckOut(string codigoReserva)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);

            comandoAReserva.Parameters[0].Value = codigoReserva;

            comandoAReserva.CommandText = "SQLECT.chequearRealizacionDeCheckOut";
            bool yaHizoElCheckOut = conexion.ejecutarEscalar(comandoAReserva);

            return yaHizoElCheckOut;

        }
    }
}