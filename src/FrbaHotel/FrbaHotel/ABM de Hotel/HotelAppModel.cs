using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Hotel
{
    public abstract class HotelAppModel
    {
        private Conexion connSql = Conexion.Instance;
        protected bool fallo_carga = false;
        public DataTable rowHotel = new DataTable();

        public abstract void doActionHotel(Control nombre, Control email, Control cant_estrellas, Control fecha_creacion, bool all_inclusive, bool all_inclusive_moderado, bool pension_completa, bool media_pension, Control pais, Control ciudad, Control calle, Control nro_calle);

        public bool actionHotel(Control nombre, Control email, Control cant_estrellas, Control fecha_creacion, bool all_inclusive, bool all_inclusive_moderado, bool pension_completa, bool media_pension, Control pais, Control ciudad, Control calle, Control nro_calle, StringBuilder errores)
        {
            validarForm(nombre, email, cant_estrellas, fecha_creacion, all_inclusive, all_inclusive_moderado, pension_completa, media_pension, pais, ciudad, pais, nro_calle, errores);
            if (errores.Length > 0)
            {
                return false;
            }
            else
            {
                doActionHotel(nombre, email, cant_estrellas, fecha_creacion, all_inclusive, all_inclusive_moderado, pension_completa, media_pension, pais, ciudad, calle, nro_calle);
                return true;
            }
        }

        public void validarForm(Control nombre, Control email, Control cant_estrellas, Control fecha_creacion, bool all_inclusive, bool all_inclusive_moderado, bool pension_completa, bool media_pension, Control pais, Control ciudad, Control calle, Control nro_calle, StringBuilder errores)
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
            if (!fallo_carga && !this.seleccionoAlgunRegimen(all_inclusive,all_inclusive_moderado,pension_completa,media_pension))
            {
                errores.AppendLine("Debe seleccionar algun regimen");
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
            fallo_carga = false;
        }

        public virtual bool existeEmail(string email)
        {
            StringBuilder sentece = new StringBuilder();
            sentece.AppendFormat("SELECT * FROM SQLECT.Hoteles h WHERE h.mail='{0}'", email);
            return this.connSql.ejecutarQuery(sentece.ToString()).Rows.Count > 0;
        }

        private bool seleccionoAlgunRegimen(bool all_inclusive, bool all_inclusive_moderado, bool pension_completa, bool media_pension)
        {
            if (all_inclusive || all_inclusive_moderado || pension_completa || media_pension) return true;
            else return false;
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
