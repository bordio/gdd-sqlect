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
    class AppModel_Alta_Usuario
    {
        private Conexion sqlconexion = Conexion.Instance;
        Funcionalidades funcionesVarias = new Funcionalidades();

        /*Validacion de campos*/

        public bool validarNoVacio(Control control, StringBuilder mensajeValidacion)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                mensajeValidacion.AppendLine(string.Format(" El campo {0} no puede estar en blanco.", control.Name));
                return false;
            }
            return true;
        }
        
        public bool validarComboVacio(ComboBox combo, StringBuilder mensajeValidacion)
        {
            if (combo.SelectedIndex > -1)
                return true;
            else
            {
                mensajeValidacion.AppendLine(string.Format(" Debe elegir una opcion de la lista {0}", combo.Name));
                return false;
            }
        }

        public bool validarLongitud(Control control, int maxLength, StringBuilder mensajeValidacion)
        {
            if ((control.Text.Length <= 0) && (control.Text.Length > maxLength))
            {
                mensajeValidacion.AppendLine(string.Format(" Incorrecta cantidad de caracteres en el campo {0}.", control.Name));
                return false;
            }
            return true;
        }

        public bool validarNumerico(Control control, StringBuilder mensajeValidacion)
        {
            try
            {
                int esNumero = Convert.ToInt32(control.Text);
                return true;
            }
            catch
            {
                mensajeValidacion.AppendLine(string.Format(" El campo {0} debe ser numerico.", control.Name));
                return false;
            }
        }

        public void validarEmail(Control mail, StringBuilder mensajeValidacion)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("SELECT * FROM SQLECT.Empleados e WHERE e.email='{0}'", mail.Text);
            if (this.sqlconexion.ejecutarQuery(query.ToString()).Rows.Count > 0)
            {
                mensajeValidacion.AppendLine(string.Format(" El email {0} ya existe.", mail.Text));
            };
        }

        public void validarDNI(string tipo, Control numero, StringBuilder mensajeValidacion)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("SELECT * FROM SQLECT.Empleados e WHERE e.dni_tipo='{0}' AND e.dni_nro='{1}'", tipo, numero.Text);
            if (this.sqlconexion.ejecutarQuery(query.ToString()).Rows.Count > 0)
            {
                mensajeValidacion.AppendLine(string.Format(" El tipo de dni {0} con el numero {1} ya existe.", tipo, numero.Text));
            };
        }
         
        public void validarUsuario(Control usuario, StringBuilder mensajeValidacion)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("SELECT * FROM SQLECT.Usuarios u WHERE u.usr_name='{0}'", usuario.Text);
            if (this.sqlconexion.ejecutarQuery(query.ToString()).Rows.Count > 0)
            {
                mensajeValidacion.AppendLine(string.Format(" El usuario {0} ya existe.", usuario.Text));
            };
        }



        public bool altaUsuario(string username, string password, string rol, string nombre, string apellido, string tipoDoc, int numeroDoc, string mail, int telefono, string direccion, string fechaDeNacimiento, string hotelDeDesempeño)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAUsuario = new System.Data.SqlClient.SqlCommand();
            comandoAUsuario.CommandType = CommandType.StoredProcedure;

            string passHasheada = funcionesVarias.encriptarPassword(password);

            comandoAUsuario.Parameters.Add("@username", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@password", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@rol", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@nombre", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@apellido", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@tipoDoc", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@numeroDoc", SqlDbType.Int);
            comandoAUsuario.Parameters.Add("@mail", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@telefono", SqlDbType.BigInt);
            comandoAUsuario.Parameters.Add("@direccion", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@fechaNacimiento", SqlDbType.DateTime);
            comandoAUsuario.Parameters.Add("@hotelDesempeño", SqlDbType.VarChar);

            comandoAUsuario.Parameters[0].Value = username;
            comandoAUsuario.Parameters[1].Value = passHasheada;
            comandoAUsuario.Parameters[3].Value = rol;
            comandoAUsuario.Parameters[2].Value = nombre;
            comandoAUsuario.Parameters[4].Value = apellido;
            comandoAUsuario.Parameters[5].Value = tipoDoc;
            comandoAUsuario.Parameters[6].Value = numeroDoc;
            comandoAUsuario.Parameters[7].Value = mail;
            comandoAUsuario.Parameters[8].Value = telefono;
            comandoAUsuario.Parameters[9].Value = direccion;
            comandoAUsuario.Parameters[10].Value = DateTime.Parse(fechaDeNacimiento);
            comandoAUsuario.Parameters[11].Value = hotelDeDesempeño;

            comandoAUsuario.CommandText = "SQLECT.altaUsuario";
            conexion.ejecutarQueryConSP(comandoAUsuario);
            
            return true;
        }

        public bool nombresHotelesVacios() 
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT nombre FROM SQLECT.Hoteles WHERE nombre IS NULL "); 
            if (this.sqlconexion.ejecutarQuery(sentence.ToString()).Rows.Count > 0)

            { return true; 
            }
            else
                return false;
        }

    }
}