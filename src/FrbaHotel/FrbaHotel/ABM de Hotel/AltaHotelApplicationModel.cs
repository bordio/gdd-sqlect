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

        public bool altaHotel(string nombre, string email, int cant_estrellas, DateTime fecha_creacion, bool all_inclusive, bool all_inclusive_moderado, bool pension_completa, bool media_pension, string pais, string ciudad, string calle, int nro_calle)
        {
            if (nombre == "" || email == "" || cant_estrellas == null || fecha_creacion == null || all_inclusive == null || all_inclusive_moderado == null || pension_completa == null || media_pension == null || pais == "" || ciudad == "" || nro_calle < 0)
            {
                MessageBox.Show("Error: No debe dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (this.existeEmail(email))
                {
                    StringBuilder mensaje = new StringBuilder();
                    mensaje.AppendLine("Email duplicado.");
                    MessageBox.Show(mensaje.ToString());
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

                    comando1.Parameters[0].Value = nombre;
                    comando1.Parameters[1].Value = email;
                    comando1.Parameters[2].Value = cant_estrellas;
                    comando1.Parameters[3].Value = fecha_creacion;
                    comando1.Parameters[4].Value = pais;
                    comando1.Parameters[5].Value = ciudad;
                    comando1.Parameters[6].Value = calle;
                    comando1.Parameters[7].Value = nro_calle;

                    comando1.CommandText = "SQLECT.altaHotel";
                    cnn.ejecutarQueryConSP(comando1);

                    //TO DO: INSERTS de la relacion regimenes_hoteles

                    return true;
                }
            }
        }

        public bool existeEmail(string email)
        {
            StringBuilder sentece = new StringBuilder();
            sentece.AppendFormat("SELECT * FROM SQLECT.Hoteles h WHERE h.mail={0}", email);
            return this.connSql.ejecutarQuery(sentece.ToString()).Rows.Count > 0;
        }


        public void validarSoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public void validarSoloLetrasYnumeros(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public void validarMail(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '@')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '_')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
