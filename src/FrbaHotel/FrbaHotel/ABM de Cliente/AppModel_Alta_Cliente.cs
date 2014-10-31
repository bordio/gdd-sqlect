using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
class AppModel_Alta_Cliente
{
    private Conexion sqlconexion = Conexion.Instance;

    public bool altaCliente(string nombre, string apellido, string mail, string dom_Calle, string nro_Calle, string piso, string depto, DateTime fecha_Nac, string nacionalidad, string pasaporte_Nro)
    {
        if (nombre == "" || apellido == "" || mail == "" || dom_Calle == "" || nro_Calle == "" || piso == "" || depto == "" || nacionalidad == null || pasaporte_Nro == null)
        {
            MessageBox.Show("Error: Se intentó crear un cliente con datos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        else{
            /*
             Agregar validaciones
             */
            
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
            comandoACliente.Parameters.Add("@Pasaporte_Nro", SqlDbType.Int);

            comandoACliente.Parameters[0].Value = nombre;
            comandoACliente.Parameters[1].Value = apellido;
            comandoACliente.Parameters[3].Value = mail;
            comandoACliente.Parameters[2].Value = dom_Calle;
            comandoACliente.Parameters[4].Value = nro_Calle;
            comandoACliente.Parameters[5].Value = piso;
            comandoACliente.Parameters[6].Value = depto;
            comandoACliente.Parameters[7].Value = fecha_Nac;
            comandoACliente.Parameters[8].Value = nacionalidad;
            comandoACliente.Parameters[9].Value = pasaporte_Nro;

            comandoACliente.CommandText = "altaCliente";
            conexion.ejecutarQueryConSP(comandoACliente);

        }
        return true;
       /*List<string> campos = new List<string>();
        campos = [nombre, apellido, mail, dom_Calle, nro_Calle, piso, depto, nacionalidad, pasaporte_Nro);
        validarCamposVacios(List<string>; 
        validarNotFilled(campos);*/
    }
    
   /* validarNotFilled(string campos){
    }*/
}
}