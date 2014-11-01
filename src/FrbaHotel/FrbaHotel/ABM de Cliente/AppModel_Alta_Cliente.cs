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

                comandoACliente.CommandText = "SQLECT.altaCliente";
                conexion.ejecutarQueryConSP(comandoACliente);
            return true;
        }

        /*Validacion de campos*/

        public bool validarNoVacio(Control control,StringBuilder mensajeValidacion)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                mensajeValidacion.AppendLine(string.Format(" El campo {0} no puede estar en blanco.", control.Name));
                return false;
            }
            return true;
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
            query.AppendFormat("SELECT * FROM SQLECT.Cliente c WHERE c.mail='{0}'", mail.Text);
            if (this.sqlconexion.ejecutarQuery(query.ToString()).Rows.Count > 0) {
                mensajeValidacion.AppendLine(string.Format(" El email {0} ya existe.", mail.Name));
            };
        }
    }
}