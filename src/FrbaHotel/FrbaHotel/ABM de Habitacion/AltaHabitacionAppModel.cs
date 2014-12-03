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
        private Conexion connSql = Conexion.Instance;
        public override void doActionHabitacion(ComboBox cmb_hotel, Control numero_habitacion, Control piso, ComboBox cmb_tipo_habitacion, RadioButton exterior, RadioButton interior, Control descripcion)
        {
            Conexion cnn = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comando1 = new System.Data.SqlClient.SqlCommand();
            comando1.CommandType = CommandType.StoredProcedure;

            comando1.Parameters.Add("@nro_habitacion", SqlDbType.Int);
            comando1.Parameters.Add("@fk_hotel", SqlDbType.Int);
            comando1.Parameters.Add("@piso", SqlDbType.Int);
            comando1.Parameters.Add("@frente", SqlDbType.Char);
            comando1.Parameters.Add("@tipo_habitacion", SqlDbType.Int);

            comando1.Parameters[0].Value = Int32.Parse(numero_habitacion.Text);
            comando1.Parameters[1].Value = this.id_hotels[cmb_hotel.SelectedIndex];
            comando1.Parameters[2].Value = Int32.Parse(piso.Text);
            comando1.Parameters[3].Value = (exterior.Checked ? 'S' : 'N');
            comando1.Parameters[4].Value = this.id_tipo_habitaciones[cmb_tipo_habitacion.SelectedIndex];

            comando1.CommandText = "SQLECT.altaHabitacion";
            cnn.ejecutarQueryConSP(comando1);

            MessageBox.Show("Alta exitosa", "Alta de Habitacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
