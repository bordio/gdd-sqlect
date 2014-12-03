using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.ABM_de_Habitacion
{
    class BusqModHabitacion : BusquedaHabitacionAppModel
    {
        public override void showForm()
        {
            FormHabitacion formModificacion = new FormHabitacion(new ModificacionHabitacionAppModel());
            formModificacion.Show();
            formModificacion.Text = "Modificacion de habitacion";
        }
    }
}
