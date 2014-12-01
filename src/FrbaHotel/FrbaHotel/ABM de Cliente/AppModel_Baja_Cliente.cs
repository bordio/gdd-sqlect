using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    class AppModel_Baja_Cliente : AppModel_Base_Cliente
    {
        private Conexion sqlconexion = Conexion.Instance;
        System.Data.SqlClient.SqlCommand comandoACliente;


        public void comandoCliente(StringBuilder email, StringBuilder documento_Nro)
        {       
                comandoACliente.Parameters.Add("@Mail", SqlDbType.VarChar);
                comandoACliente.Parameters.Add("@documento_Nro", SqlDbType.BigInt);

                comandoACliente.Parameters[0].Value = email.ToString();
                comandoACliente.Parameters[1].Value = documento_Nro.ToString();
        }

        public void inhabilitarCliente(StringBuilder email, StringBuilder documento_Nro)
        {
            Conexion conexion = Conexion.Instance;
            comandoACliente = new System.Data.SqlClient.SqlCommand();
            comandoACliente.CommandType = CommandType.StoredProcedure;

            comandoCliente(email, documento_Nro);

            comandoACliente.CommandText = "SQLECT.inhabilitarCliente";
            conexion.ejecutarQueryConSP(comandoACliente);

            MessageBox.Show("Inhabilitacion exitosa", "Inhabilitacion del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void habilitarCliente(StringBuilder email, StringBuilder documento_Nro)
        {
            Conexion conexion = Conexion.Instance;
            comandoACliente = new System.Data.SqlClient.SqlCommand();
            comandoACliente.CommandType = CommandType.StoredProcedure;

            comandoCliente(email, documento_Nro);

            comandoACliente.CommandText = "SQLECT.habilitarCliente";
            conexion.ejecutarQueryConSP(comandoACliente);

            MessageBox.Show("Habilitacion exitosa", "Habilitacion del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        public override void levantar(StringBuilder sentence){}
        public override void abmlCliente(string nombre, string apellido, string mail, string dom_Calle, string nro_Calle, string piso, string depto, string fecha_Nac, string nacionalidad, string documento_Nro, int idReserva) { }
    }
}
