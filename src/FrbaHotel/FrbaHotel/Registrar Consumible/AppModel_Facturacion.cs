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
    class AppModel_Facturacion
    {
        private Conexion sqlconexion = Conexion.Instance;
        Funcionalidades funcionesVarias = new Funcionalidades();

        public void generarFactura(string codigoReserva, int idHotel, int fechaDelSistema)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAFactura = new System.Data.SqlClient.SqlCommand();
            comandoAFactura.CommandType = CommandType.StoredProcedure;

            comandoAFactura.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAFactura.Parameters.Add("@idHotel", SqlDbType.Int);
            comandoAFactura.Parameters.Add("@fechaDelSistema", SqlDbType.VarChar);
            
            comandoAFactura.Parameters[0].Value = codigoReserva;
            comandoAFactura.Parameters[1].Value = idHotel;
            comandoAFactura.Parameters[2].Value = Convert.ToString(fechaDelSistema);

            comandoAFactura.CommandText = "SQLECT.generarFactura";
            conexion.ejecutarSP(comandoAFactura);

        }

        public void descontarConsumiblesPorRegimen(string codigoReserva)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAFactura = new System.Data.SqlClient.SqlCommand();
            comandoAFactura.CommandType = CommandType.StoredProcedure;

            comandoAFactura.Parameters.Add("@codigoReserva", SqlDbType.VarChar);

            comandoAFactura.Parameters[0].Value = codigoReserva;

            comandoAFactura.CommandText = "SQLECT.descontarConsumiblesPorRegimen";
            conexion.ejecutarSP(comandoAFactura);

        }


        public DataTable obtenerDetallesFactura(string codigoReserva)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAFactura = new System.Data.SqlClient.SqlCommand();
            comandoAFactura.CommandType = CommandType.StoredProcedure;

            comandoAFactura.Parameters.Add("@codigoReserva", SqlDbType.VarChar);

            comandoAFactura.Parameters[0].Value = codigoReserva;

            comandoAFactura.CommandText = "SQLECT.obtenerDetallesFactura";
            DataTable detallesFactura = conexion.ejecutarQueryConSP(comandoAFactura);
            return detallesFactura;
        
        
        }

        public int obtenerNumeroFactura(string codigoReserva)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAFactura = new System.Data.SqlClient.SqlCommand();
            comandoAFactura.CommandType = CommandType.StoredProcedure;

            comandoAFactura.Parameters.Add("@codigoReserva", SqlDbType.VarChar);

            comandoAFactura.Parameters[0].Value = codigoReserva;            

            comandoAFactura.CommandText = "SQLECT.obtenerNumeroFactura";
            int numeroFactura = conexion.ejecutarEscalarInt(comandoAFactura);

            return numeroFactura; 
        
        
        }

        public int obtenerMontoTotalFactura(string codigoReserva)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAFactura = new System.Data.SqlClient.SqlCommand();
            comandoAFactura.CommandType = CommandType.StoredProcedure;

            comandoAFactura.Parameters.Add("@codigoReserva", SqlDbType.VarChar);

            comandoAFactura.Parameters[0].Value = codigoReserva;

            comandoAFactura.CommandText = "SQLECT.obtenerMontoTotalFactura";
            int montoTotal = conexion.ejecutarEscalarInt(comandoAFactura);

            return montoTotal; 
        
        }
    
        public void registrarFormaDePago(string codigoReserva,string formaDePago, string detallesFormaDePago)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAFactura = new System.Data.SqlClient.SqlCommand();
            comandoAFactura.CommandType = CommandType.StoredProcedure;

            comandoAFactura.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAFactura.Parameters.Add("@formaDePago", SqlDbType.VarChar);
            comandoAFactura.Parameters.Add("@detalles", SqlDbType.VarChar);

            comandoAFactura.Parameters[0].Value = codigoReserva;
            comandoAFactura.Parameters[1].Value = formaDePago;
            comandoAFactura.Parameters[2].Value = detallesFormaDePago;

            comandoAFactura.CommandText = "SQLECT.registrarFormaDePago";
            conexion.ejecutarSP(comandoAFactura);

             
        
        
        }



    }

    


}