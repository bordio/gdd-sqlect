﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Habitacion
{
    class ModificacionHabitacionAppModel : HabitacionAppModel
    {
        private Conexion connSql = Conexion.Instance;
        public ModificacionHabitacionAppModel()
        {
            //algo con la id
        }
        public override void doActionHabitacion(ComboBox cmb_hotel, Control numero_habitacion, Control piso, ComboBox cmb_tipo_habitacion, RadioButton exterior, RadioButton interior, Control descripcion)
        {
            MessageBox.Show("TO DO: Mas que en el otro!");
        }
    }
}
