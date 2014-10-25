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
            MessageBox.Show("Error: Se intentó dar de alta con datos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        else{

            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comando1 = new System.Data.SqlClient.SqlCommand();
            comando1.CommandType = CommandType.StoredProcedure;

            comando1.Parameters.Add("@Name", SqlDbType.NVarChar);
            comando1.Parameters.Add("@Surname", SqlDbType.NVarChar);
            comando1.Parameters.Add("@Dni", SqlDbType.BigInt);
            comando1.Parameters.Add("@Email", SqlDbType.NVarChar);
            comando1.Parameters.Add("@PhoneNumber", SqlDbType.BigInt);
            comando1.Parameters.Add("@Address", SqlDbType.NVarChar);
            comando1.Parameters.Add("@PostalCode", SqlDbType.NVarChar);
            comando1.Parameters.Add("@Birthday", SqlDbType.DateTime);

            comando1.Parameters[0].Value = name;
            comando1.Parameters[1].Value = surname;
            comando1.Parameters[2].Value = dni;
            comando1.Parameters[3].Value = email;
            comando1.Parameters[4].Value = phone;
            comando1.Parameters[5].Value = address;
            comando1.Parameters[6].Value = postalcode;
            comando1.Parameters[7].Value = birthday;

            comando1.CommandText = "TRANSA_SQL.altaCliente";
            conexion.ejecutarQueryConSP(comando1);

            StringBuilder sentence = new StringBuilder();
            sentence.AppendFormat("SELECT C.CustomerId FROM TRANSA_SQL.Customer C WHERE C.Dni={0}", dni);
            int customerId = (int)connSql.ejecutarQuery(sentence.ToString()).Rows[0][0];

            System.Data.SqlClient.SqlCommand comando2 = new System.Data.SqlClient.SqlCommand();
            comando2.CommandType = CommandType.StoredProcedure;

            comando2.Parameters.Add("@CustomerId", SqlDbType.Int);
            comando2.Parameters.Add("@CityName", SqlDbType.NVarChar);
            comando2.CommandText = "TRANSA_SQL.insertarCiudad";
            comando2.Parameters[0].Value = customerId;

        }

    /*    List<string> campos = new List<string>();
        campos = [nombre, apellido, mail, dom_Calle, nro_Calle, piso, depto, nacionalidad, pasaporte_Nro);
        validarCamposVacios(List<string>; 
        validarNotFilled(campos);*/
    }
    
    /*validarNotFilled(string campos){
    }*/
}
}