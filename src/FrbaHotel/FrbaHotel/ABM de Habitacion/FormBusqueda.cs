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
        public FormBusqueda(BusquedaHabitacionAppModel model)
        {
            this.appModel = model;
            InitializeComponent();
            cmbTipoHabitacion.Items.Add("");
            cmbHoteles.Items.Add("");
            this.appModel.cargarHoteles(cmbHoteles);
            this.appModel.cargarTipoHabitaciones(cmbTipoHabitacion);
            lstHabitaciones.AllowUserToAddRows = false;
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
        }
    }
}
