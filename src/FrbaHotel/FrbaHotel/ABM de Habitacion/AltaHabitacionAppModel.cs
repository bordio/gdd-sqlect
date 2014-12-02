using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Habitacion
{
    class AltaHabitacionAppModel : HabitacionAppModel
    {
        public override void doActionHabitacion(ComboBox cmb_hotel, Control numero_habitacion, Control piso, ComboBox cmb_tipo_habitacion, Control exterior, Control interior, Control descripcion)
        {
            MessageBox.Show("TO DO: todo! ja");
        }
    }
}
