using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Habitacion
{
    class BajaHabitacionAppModel : ModificacionHabitacionAppModel
    {
        public override bool nroHabitacionDuplicado(ComboBox cmb_hotel, Control numero_habitacion) { return false; }
        public BajaHabitacionAppModel(int id_habitacion, StringBuilder hotelSeleccionado, StringBuilder tipo_habitacionSeleccionado, FormBusqueda formBusq) : base(id_habitacion,hotelSeleccionado,tipo_habitacionSeleccionado,formBusq) { }

        public override void preload(FormHabitacion formHab)
        {
            formHab.Numero_Habitacion.Text = nro_habitacion;
            formHab.Piso.Text = piso;
            (frente == "S" ? formHab.rdExterior : formHab.rdInterior).Checked = true;
            formHab.Descripcion.Text = descripcion;

            formHab.Numero_Habitacion.Enabled = false;
            formHab.Piso.Enabled = false;
            formHab.rdExterior.Enabled = false;
            formHab.rdInterior.Enabled = false;
            formHab.Descripcion.Enabled = false;
            formHab.cmbHoteles.Enabled = false;

            //Estos labels son los '* obligatorio'
            formHab.label6.Visible = false;
            formHab.label7.Visible = false;
            formHab.label8.Visible = false;
            formHab.label9.Visible = false;
            formHab.label10.Visible = false;

            if (this.estado_habitacion == 1) formHab.Guardar.Text = "Dar de baja";
            else formHab.Guardar.Text = "Activar";
        }

        public override void doActionHabitacion(ComboBox cmb_hotel, Control numero_habitacion, Control piso, ComboBox cmb_tipo_habitacion, RadioButton exterior, RadioButton interior, Control descripcion)
        {
            Conexion cnn = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comando1 = new System.Data.SqlClient.SqlCommand();
            comando1.CommandType = CommandType.StoredProcedure;

            comando1.Parameters.Add("@id_habitacion", SqlDbType.Int);
            comando1.Parameters.Add("@estado_habitacion", SqlDbType.Int);

            comando1.Parameters[0].Value = this.id_habitacion;
            comando1.Parameters[1].Value = this.estado_habitacion == 1 ? 0 : 1;

            comando1.CommandText = "SQLECT.actualizacionEstadoHabitacion";
            cnn.ejecutarQueryConSP(comando1);

            MessageBox.Show("Actualizacion de estado exitosa", "Actualizacion de estado de Habitacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            formBusq.filtrar();
        }
        public override string getTitulo()
        {
            return "Formulario de baja/activacion de habitacion";
        }
    }
}
