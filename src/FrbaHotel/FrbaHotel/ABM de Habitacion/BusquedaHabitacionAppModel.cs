using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Habitacion
{
    public abstract class BusquedaHabitacionAppModel : HabitacionAppModel
    {
        public virtual void showForm() { }
        public DataTable searchByExample(ComboBox hotel, Control nro_habitacion, Control piso, ComboBox tipo_habitacion)
        {
            StringBuilder sentence = new StringBuilder();
            sentence.Append("SELECT id_habitacion , hotel, nro_habitacion, piso, frente, tipo_habitacion FROM SQLECT.Habitaciones_Vista");

            if ((nro_habitacion.Text != "") || (piso.Text != "") || (hotel.SelectedIndex > 0) || (tipo_habitacion.SelectedIndex > 0))
            {
                sentence.Append(" WHERE ");
                if (hotel.SelectedIndex > 0) sentence.AppendFormat(" (id_hotel = {0}) AND ", this.id_hotels[hotel.SelectedIndex-1]);
                if (piso.Text != "")
                {
                    try
                    {
                        int numero = Convert.ToInt32(piso.Text);
                        sentence.AppendFormat(" (piso = '{0}') AND ", numero);
                    }
                    catch
                    {
                        MessageBox.Show("El filtro de piso debe ser numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (tipo_habitacion.SelectedIndex > 0) sentence.AppendFormat(" (id_tipo_habitacion = {0}) AND ", this.id_tipo_habitaciones[tipo_habitacion.SelectedIndex - 1]);
                if (nro_habitacion.Text != "")
                {
                    try
                    {
                        int numero = Convert.ToInt32(nro_habitacion.Text);
                        sentence.AppendFormat(" (nro_habitacion = '{0}') AND ", numero);
                    }
                    catch
                    {
                        MessageBox.Show("El filtro de numero de habitacion debe ser numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                StringBuilder sentenceFiltro = new StringBuilder().AppendFormat(sentence.ToString().Substring(0, sentence.Length - 5));
                
                DataTable tabla = Conexion.Instance.ejecutarQuery(sentenceFiltro.ToString());
                return tabla;
            }
            else
            {
                DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());
                return tabla;
            }
        }
    }
}
