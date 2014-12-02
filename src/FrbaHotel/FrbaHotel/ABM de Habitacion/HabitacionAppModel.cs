using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;

namespace FrbaHotel.ABM_de_Habitacion
{
    public abstract class HabitacionAppModel
    {
        private Conexion connSql = Conexion.Instance;
        private List<Int32> id_hotels = new List<Int32>();
        protected bool fallo_carga = false;
        public abstract void doActionHabitacion(ComboBox cmb_hotel, Control numero_habitacion, Control piso, ComboBox cmb_tipo_habitacion, Control exterior, Control interior, Control descripcion);

        public bool actionHabitacion(ComboBox cmb_hotel, Control numero_habitacion, Control piso, ComboBox cmb_tipo_habitacion, Control exterior, Control interior, Control descripcion, StringBuilder errores)
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

        public virtual void cargarHoteles(ComboBox cmbHoteles) {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT nombre,id_hotel FROM SQLECT.Hoteles");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                cmbHoteles.Items.Add(tabla.Rows[i]["nombre"].ToString());
                this.id_hotels.Add(Int32.Parse(tabla.Rows[i]["id_hotel"].ToString()));
            }
        }

        public virtual void cargarTipoHabitaciones(ComboBox cmbTipoHabitaciones)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT descripcion FROM SQLECT.Tipos_Habitaciones");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                cmbTipoHabitaciones.Items.Add(tabla.Rows[i]["descripcion"].ToString());
            }
        }

        public void validarForm(ComboBox cmb_hotel, Control numero_habitacion, Control piso, ComboBox cmb_tipo_habitacion, Control exterior, Control interior, Control descripcion, StringBuilder errores)
        {
            if (numero_habitacion.Text == "" || piso.Text == "")
            {
                errores.AppendLine("No debe dejar los campos obligatorios en blanco");
                fallo_carga = true;
            }
            if (!fallo_carga && !esNumerico(numero_habitacion))
            {
                errores.AppendLine("El numero de habitacion debe ser numerico");
            }
            if (!fallo_carga && !esNumerico(piso))
            {
                errores.AppendLine("El numero de piso debe ser numerico");
            }
            if (!fallo_carga && esNumerico(piso))
            {
                if (Int32.Parse(piso.Text) < 0)
                {
                    errores.AppendLine("El piso dentro del hotel debe ser un numero positivo");
                }
            }
            if (!fallo_carga && esNumerico(numero_habitacion) && nroHabitacionDuplicado(cmb_hotel, numero_habitacion))
            {
                errores.AppendLine("El numero de habitacion esta duplicado para este hotel");
            }
            fallo_carga = false;
        }

        private bool nroHabitacionDuplicado(ComboBox cmb_hotel, Control numero_habitacion)
        {
            StringBuilder sentece = new StringBuilder();
            sentece.AppendFormat("SELECT id_habitacion FROM SQLECT.Habitaciones WHERE fk_hotel={0} AND nro_habitacion={1}", id_hotels[cmb_hotel.SelectedIndex],Int32.Parse(numero_habitacion.Text));
            return this.connSql.ejecutarQuery(sentece.ToString()).Rows.Count > 0;
        }

        private bool esNumerico(Control control)
        {
            try
            {
                int esNumero = Convert.ToInt32(control.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
