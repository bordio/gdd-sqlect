using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class FormBusqueda : Form
    {
        private BusquedaHabitacionAppModel appModel;
        private StringBuilder hotelSeleccionado = new StringBuilder();
        private StringBuilder tipo_habitacionSeleccionado = new StringBuilder();
        private Int32 id_habitacionSeleccionado;

        public FormBusqueda(BusquedaHabitacionAppModel model)
        {
            this.appModel = model;
            InitializeComponent();
            cmbTipoHabitacion.Items.Add("");
            cmbHoteles.Items.Add("");
            this.appModel.cargarHoteles(cmbHoteles);
            this.appModel.cargarTipoHabitaciones(cmbTipoHabitacion);
            lstHabitaciones.AllowUserToAddRows = false;
            btAccion.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAccion_Click(object sender, EventArgs e)
        {
            this.appModel.showForm();
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            cmbHoteles.ResetText();
            cmbTipoHabitacion.ResetText();
            piso.ResetText();
            nro_habitacion.ResetText();
            lstHabitaciones.DataSource = null;
        }

        private void Filtrar_Click(object sender, EventArgs e)
        {
            lstHabitaciones.DataSource = this.appModel.searchByExample(cmbHoteles, nro_habitacion, piso, cmbTipoHabitacion).DefaultView;
            lstHabitaciones.Columns[0].Visible = false; //id_habitacion
        }

        private void lstHabitaciones_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow celda_actual = lstHabitaciones.CurrentRow;
            this.hotelSeleccionado.Remove(0,this.hotelSeleccionado.Length);
            this.tipo_habitacionSeleccionado.Remove(0, this.tipo_habitacionSeleccionado.Length);
            this.id_habitacionSeleccionado = 0;

            if (celda_actual != null)
            {
                id_habitacionSeleccionado = Int32.Parse(celda_actual.Cells[0].Value.ToString());
                hotelSeleccionado.AppendFormat("{0}", celda_actual.Cells[1].Value.ToString());
                tipo_habitacionSeleccionado.AppendFormat("{0}", celda_actual.Cells[5].Value.ToString());

                btAccion.Enabled = true;
            }

        }
    }
}
