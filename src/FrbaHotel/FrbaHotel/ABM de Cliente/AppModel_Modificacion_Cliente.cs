using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    class AppModel_Modificacion_Cliente : AppModel_Base_Cliente
    {
        private Conexion sqlconexion = Conexion.Instance;
        

        public override void abmlCliente(string nombre, string apellido, string mail, string dom_Calle, string nro_Calle, string piso, string depto, String fecha_Nac, string nacionalidad, string pasaporte_Nro)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoACliente = new System.Data.SqlClient.SqlCommand();
            comandoACliente.CommandType = CommandType.StoredProcedure;

            comandoACliente.Parameters.Add("@Nombre", SqlDbType.VarChar);
            comandoACliente.Parameters.Add("@Apellido", SqlDbType.VarChar);
            comandoACliente.Parameters.Add("@Mail", SqlDbType.VarChar);
            comandoACliente.Parameters.Add("@Dom_Calle", SqlDbType.VarChar);
            comandoACliente.Parameters.Add("@Nro_Calle", SqlDbType.Int);
            comandoACliente.Parameters.Add("@Piso", SqlDbType.TinyInt);
            comandoACliente.Parameters.Add("@Depto", SqlDbType.VarChar);
            comandoACliente.Parameters.Add("@Fecha_Nac", SqlDbType.DateTime);
            comandoACliente.Parameters.Add("@Nacionalidad", SqlDbType.VarChar);
            comandoACliente.Parameters.Add("@Pasaporte_Nro", SqlDbType.BigInt);

            comandoACliente.Parameters[0].Value = nombre;
            comandoACliente.Parameters[1].Value = apellido;
            comandoACliente.Parameters[3].Value = mail;
            comandoACliente.Parameters[2].Value = dom_Calle;
            comandoACliente.Parameters[4].Value = nro_Calle;
            comandoACliente.Parameters[5].Value = piso;
            comandoACliente.Parameters[6].Value = depto;
            comandoACliente.Parameters[7].Value = DateTime.Parse(fecha_Nac);
            comandoACliente.Parameters[8].Value = nacionalidad;
            comandoACliente.Parameters[9].Value = pasaporte_Nro;

            comandoACliente.CommandText = "SQLECT.modificacionCliente";
            conexion.ejecutarQueryConSP(comandoACliente);

            MessageBox.Show("Modificacion exitosa", "Modificacion de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

        
        }

      /*  public override void levantar(StringBuilder nombre, StringBuilder apellido, StringBuilder email, StringBuilder fechaNacimiento, StringBuilder dom_Calle, StringBuilder nro_Calle, StringBuilder piso, StringBuilder depto, StringBuilder nacionalidad, StringBuilder pasaporte, StringBuilder habilitado)
       {
           //StringBuilder sentence = new StringBuilder().AppendFormat("SELECT nombre,apellido,mail,fecha_Nac,dom_Calle,nro_Calle,piso,depto,nacionalidad,pasaporte_Nro,habilitado FROM SQLECT.Clientes WHERE nombre='{0}' AND apellido='{1}' AND mail='{2}' AND fecha_Nac='{3}' AND dom_Calle='{4}' AND nro_Calle={5} AND piso={6} AND depto={7} AND nacionalidad={8} AND pasaporte_Nro={9} AND habilitado={10}", nombre.ToString(), apellido.ToString(), email.ToString(), fechaNacimiento, dom_Calle.ToString(), nro_Calle, piso, depto.ToString(), nacionalidad.ToString(), pasaporte.ToString(), habilitado);
           //rowHotel = Conexion.Instance.ejecutarQuery(sentence.ToString());
       }*/

    }
}
