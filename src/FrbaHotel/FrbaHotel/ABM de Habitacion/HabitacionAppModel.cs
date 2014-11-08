using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Habitacion
{
    public abstract class HabitacionAppModel
    {
        private Conexion connSql = Conexion.Instance;
        protected bool fallo_carga = false;
        public abstract void doActionHabitacion(Control cmb_hotel, Control numero_habitacion, Control piso, Control cmb_tipo_habitacion, Control exterior, Control interior, Control descripcion);

        public bool actionHabitacion(Control cmb_hotel, Control numero_habitacion, Control piso, Control cmb_tipo_habitacion, Control exterior, Control interior, Control descripcion, StringBuilder errores)
        {
            validarForm(cmb_hotel, numero_habitacion, piso, cmb_tipo_habitacion, exterior, interior, descripcion, errores);
            if (errores.Length > 0)
            {
                return false;
            }
            else
            {
                doActionHabitacion(cmb_hotel, numero_habitacion, piso, cmb_tipo_habitacion, exterior, interior, descripcion);
                return true;
            }
        }

        public void validarForm(Control cmb_hotel, Control numero_habitacion, Control piso, Control cmb_tipo_habitacion, Control exterior, Control interior, Control descripcion, StringBuilder errores)
        {
            /*
            if (nombre.Text == "" || email.Text == "" || cant_estrellas.Text == "" || pais.Text == "" || ciudad.Text == "" || calle.Text == "" || nro_calle.Text == "")
            {
                errores.AppendLine("No debe dejar los campos obligatorios en blanco");
                fallo_carga = true;
            }
            if (!fallo_carga && this.existeEmail(email.Text))
            {
                errores.AppendLine("Email duplicado");
            }
            if (!fallo_carga && !this.seleccionoAlgunRegimen(all_inclusive, all_inclusive_moderado, pension_completa, media_pension))
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
            }*/
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
