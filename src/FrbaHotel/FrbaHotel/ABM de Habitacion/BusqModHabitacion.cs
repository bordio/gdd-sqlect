using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.ABM_de_Habitacion
{
    class BusqModHabitacion : BusquedaHabitacionAppModel
    {
        public override void showForm(Int32 id_habitacion, StringBuilder hotelSeleccionado, StringBuilder tipo_habitacionSeleccionado, FormBusqueda formBusq)
        {
            FormHabitacion formModificacion = new FormHabitacion(new ModificacionHabitacionAppModel(id_habitacion,hotelSeleccionado,tipo_habitacionSeleccionado,formBusq));
            formModificacion.ShowDialog(formBusq);
        }
        public override string getTitulo()
        {
            return "Formulario de busqueda de modificacion de habitacion";
        }
    }
}
