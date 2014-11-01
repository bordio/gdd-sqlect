using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Hotel
{
    class AltaHotelApplicationModel
    {
        private Conexion connSql = Conexion.Instance;

        private bool fallo_carga = false;

        public bool altaHotel(Control nombre, Control email, Control cant_estrellas, Control fecha_creacion, bool all_inclusive, bool all_inclusive_moderado, bool pension_completa, bool media_pension, Control pais, Control ciudad, Control calle, Control nro_calle, StringBuilder errores)
        {
            if (nombre.Text == "" || email.Text == "" || cant_estrellas.Text == "" || pais.Text == "" || ciudad.Text == "" || calle.Text == "" || nro_calle.Text == "")
            {
                errores.AppendLine("No debe dejar los campos obligatorios en blanco");
                fallo_carga = true;
            }
            if (!fallo_carga && this.existeEmail(email.Text))
            {
                errores.AppendLine("Email duplicado");
            }
            if (!fallo_carga && esNumerico(errores, cant_estrellas))
            {
                if (Int32.Parse(cant_estrellas.Text) < 0)
                {
                    errores.AppendLine("La cantidad de estrellas debe ser un numero positivo");
                }
            }
            if (!fallo_carga && esNumerico(errores, nro_calle))
            {
                if (Int32.Parse(nro_calle.Text) < 0)
                {
                    errores.AppendLine("El numero de calle debe ser un numero positivo");
                }
            }
            if (errores.Length > 0)
            {
                return false;
            }
            else
            {
                Conexion cnn = Conexion.Instance;
                System.Data.SqlClient.SqlCommand comando1 = new System.Data.SqlClient.SqlCommand();
                comando1.CommandType = CommandType.StoredProcedure;

                comando1.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando1.Parameters.Add("@email", SqlDbType.VarChar);
                comando1.Parameters.Add("@cant_estrellas", SqlDbType.Int);
                comando1.Parameters.Add("@fecha_creacion", SqlDbType.DateTime);
                comando1.Parameters.Add("@pais", SqlDbType.VarChar);
                comando1.Parameters.Add("@ciudad", SqlDbType.VarChar);
                comando1.Parameters.Add("@calle", SqlDbType.VarChar);
                comando1.Parameters.Add("@nro_calle", SqlDbType.Int);
                comando1.Parameters.Add("@all_inclusive", SqlDbType.Int);
                comando1.Parameters.Add("@all_inclusive_moderado", SqlDbType.Int);
                comando1.Parameters.Add("@pension_completa", SqlDbType.Int);
                comando1.Parameters.Add("@media_pension", SqlDbType.Int);

                comando1.Parameters[0].Value = nombre.Text;
                comando1.Parameters[1].Value = email.Text;
                comando1.Parameters[2].Value = Int32.Parse(cant_estrellas.Text);
                comando1.Parameters[3].Value = DateTime.Parse(fecha_creacion.Text);
                comando1.Parameters[4].Value = pais.Text;
                comando1.Parameters[5].Value = ciudad.Text;
                comando1.Parameters[6].Value = calle.Text;
                comando1.Parameters[7].Value = Int32.Parse(nro_calle.Text);
                comando1.Parameters[8].Value = (all_inclusive ? 1 : 0);
                comando1.Parameters[9].Value = (all_inclusive_moderado ? 1 : 0);
                comando1.Parameters[10].Value = (pension_completa ? 1 : 0);
                comando1.Parameters[11].Value = (media_pension ? 1 : 0);

                comando1.CommandText = "SQLECT.altaHotel";
                cnn.ejecutarQueryConSP(comando1);

                return true;
            }
        }

        public bool existeEmail(string email)
        {
            StringBuilder sentece = new StringBuilder();
            sentece.AppendFormat("SELECT * FROM SQLECT.Hoteles h WHERE h.mail='{0}'", email);
            return this.connSql.ejecutarQuery(sentece.ToString()).Rows.Count > 0;
        }

        private bool esNumerico(StringBuilder mensajeValidacion, Control control)
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
    }
}
