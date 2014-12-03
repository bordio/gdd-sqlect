using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Habitacion
{
    class BusqBajaHabitacion : BusquedaHabitacionAppModel
    {
        public override void showForm(Int32 id_habitacion, StringBuilder hotelSeleccionado, StringBuilder tipo_habitacionSeleccionado, FormBusqueda formBusq)
        {
            FormHabitacion formBaja = new FormHabitacion(new BajaHabitacionAppModel(id_habitacion, hotelSeleccionado, tipo_habitacionSeleccionado, formBusq));
            formBaja.Show();
            formBaja.Text = "Baja temporal de habitacion";
        }

        public override void actualizarBoton(Button btAccion,string Estado)
        {
            if (Estado == "SI") btAccion.Text = "Dar de baja";
            else btAccion.Text = "Activar";
        }
    }
}
