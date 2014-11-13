using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;
using FrbaHotel.Commons.FuncionalidadesVarias;

namespace FrbaHotel.ABM_de_Usuario
{
    class AppModel_Modifiacion_Usuario
    {
        private Conexion sqlconexion = Conexion.Instance;
        Funcionalidades funcionesVarias = new Funcionalidades();

        public DataGridView cargarDatos(string usuario)
        {

            StringBuilder query = new StringBuilder();
            query.AppendFormat("SELECT DISTINCT u.usr_name'usuario',u.pssword'password',e.nombre'nombre',e.apellido'apellido',e.dni_tipo'tipo_doc',e.dni_nro'nro_doc',e.email'mail',e.telefono'tel',e.direccion'direccion',e.fecha_nacimiento'fecha' FROM SQLECT.Empleados e RIGHT JOIN SQLECT.Usuarios u ON (e.id_empleado=u.fk_empleado) WHERE u.usr_name='{0}'", usuario);
            DataTable tablaResultados = this.sqlconexion.ejecutarQuery(query.ToString());
            DataGridView tablaFinal = new DataGridView();

            tablaFinal.DataSource = tablaResultados.DefaultView;
            return tablaFinal;
        }

        public bool modificarUsuario(string username,string nombre, string apellido, string tipoDocumento, string numeroDocumento, string mail, string telefono, string direccion, string fechaNacimiento, bool situacionHotel, string posibleNuevoHotel)
        {
            modificarDatosDelUsuario(username, nombre, apellido, tipoDocumento, numeroDocumento, mail, telefono, direccion, fechaNacimiento);

            if (situacionHotel == true)
            {
                quitarHotelDelUsuario(username, posibleNuevoHotel);
            }
            else
                if (!string.IsNullOrEmpty(posibleNuevoHotel))
                {
                    agregarHotelAlUsuario(username, posibleNuevoHotel);
                }
            
            
            
            
            
            return true;
           
        }

        public bool modificarUsuario(string username,string nombre, string apellido, string tipoDocumento, string numeroDocumento, string mail, string telefono, string direccion, string fechaNacimiento, bool situacionHotel, string posibleNuevoHotel, bool situacionRol, string posibleeNuevoRol, string idDeRol)
        {
            modificarDatosDelUsuario(username, nombre, apellido, tipoDocumento, numeroDocumento, mail, telefono, direccion, fechaNacimiento);

            if (situacionHotel == true)
            {
                quitarHotelDelUsuario(username, posibleNuevoHotel);
            }
            else
                if (!string.IsNullOrEmpty(posibleNuevoHotel))
                {
                    agregarHotelAlUsuario(username, posibleNuevoHotel);
                }

            if (situacionRol == true)
            {
                quitarRolDelUsuario(username, idDeRol);
            }
            else
                agregarRolAlUsuario(username, posibleeNuevoRol);


            
            return true;
        }

        
        public bool modificarDatosDelUsuario(string username,string nombre, string apellido, string tipoDocumento, string numeroDocumento, string mail, string telefono, string direccion, String fechaNacimiento)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAUsuario = new System.Data.SqlClient.SqlCommand();
            comandoAUsuario.CommandType = CommandType.StoredProcedure;

            comandoAUsuario.Parameters.Add("@username", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@nombre", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@apellido", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@tipoDoc", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@numeroDoc", SqlDbType.Int);
            comandoAUsuario.Parameters.Add("@mail", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@telefono", SqlDbType.BigInt);
            comandoAUsuario.Parameters.Add("@direccion", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@fechaNacimiento", SqlDbType.DateTime);


            comandoAUsuario.Parameters[0].Value = username;
            comandoAUsuario.Parameters[1].Value = nombre;
            comandoAUsuario.Parameters[2].Value = apellido;
            comandoAUsuario.Parameters[3].Value = tipoDocumento;
            comandoAUsuario.Parameters[4].Value = numeroDocumento;
            comandoAUsuario.Parameters[5].Value = mail;
            comandoAUsuario.Parameters[6].Value = telefono;
            comandoAUsuario.Parameters[7].Value = direccion;
            comandoAUsuario.Parameters[8].Value = DateTime.Parse(fechaNacimiento);
    

            comandoAUsuario.CommandText = "SQLECT.modificarDatosDelUsuario";
            conexion.ejecutarSP(comandoAUsuario);

            return true;
        }


        public void quitarHotelDelUsuario(string username, string nombreHotel)
        
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAUsuario = new System.Data.SqlClient.SqlCommand();
            comandoAUsuario.CommandType = CommandType.StoredProcedure;

            comandoAUsuario.Parameters.Add("@username", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@nombreHotel", SqlDbType.VarChar);
          
            comandoAUsuario.Parameters[0].Value = username;
            comandoAUsuario.Parameters[1].Value = nombreHotel;

            comandoAUsuario.CommandText = "SQLECT.quitarHotelDeUsuario";
            conexion.ejecutarSP(comandoAUsuario);

        
        }
    
    public void agregarHotelAlUsuario(string username, string nombreHotel)
    {
        Conexion conexion = Conexion.Instance;
        System.Data.SqlClient.SqlCommand comandoAUsuario = new System.Data.SqlClient.SqlCommand();
        comandoAUsuario.CommandType = CommandType.StoredProcedure;

        comandoAUsuario.Parameters.Add("@username", SqlDbType.VarChar);
        comandoAUsuario.Parameters.Add("@nombreHotel", SqlDbType.VarChar);

        comandoAUsuario.Parameters[0].Value = username;
        comandoAUsuario.Parameters[1].Value = nombreHotel;

        comandoAUsuario.CommandText = "SQLECT.agregarHotelAlUsuario";
        conexion.ejecutarSP(comandoAUsuario);
            
    }


    public void quitarRolDelUsuario(string username, string idDeRol)
    {
        Conexion conexion = Conexion.Instance;
        System.Data.SqlClient.SqlCommand comandoAUsuario = new System.Data.SqlClient.SqlCommand();
        comandoAUsuario.CommandType = CommandType.StoredProcedure;

        comandoAUsuario.Parameters.Add("@username", SqlDbType.VarChar);
        comandoAUsuario.Parameters.Add("@rol", SqlDbType.VarChar);

        comandoAUsuario.Parameters[0].Value = username;
        comandoAUsuario.Parameters[1].Value = idDeRol;

        comandoAUsuario.CommandText = "SQLECT.quitarRolDelUsuario";
        conexion.ejecutarSP(comandoAUsuario);
    }

    public void agregarRolAlUsuario(string username, string nuevoRol)
    {
        Conexion conexion = Conexion.Instance;
        System.Data.SqlClient.SqlCommand comandoAUsuario = new System.Data.SqlClient.SqlCommand();
        comandoAUsuario.CommandType = CommandType.StoredProcedure;

        comandoAUsuario.Parameters.Add("@username", SqlDbType.VarChar);
        comandoAUsuario.Parameters.Add("@nombreRol", SqlDbType.VarChar);

        comandoAUsuario.Parameters[0].Value = username;
        comandoAUsuario.Parameters[1].Value = nuevoRol;

        comandoAUsuario.CommandText = "SQLECT.agregarRolAlUsuario";
        conexion.ejecutarSP(comandoAUsuario);


    }

    }



 
    
}
