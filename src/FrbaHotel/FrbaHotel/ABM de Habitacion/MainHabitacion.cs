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
    public partial class MainHabitacion : Form
    {
        public MainHabitacion()
        {
            InitializeComponent();
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAlta_Click(object sender, EventArgs e)
        {
            FormHabitacion formAlta = new FormHabitacion(new AltaHabitacionAppModel());
            formAlta.Show();
            formAlta.Text = "Alta de habitacion";
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            FormHabitacion formModificacion = new FormHabitacion(new ModificacionHabitacionAppModel());
            formModificacion.Show();
            formModificacion.Text = "Modificacion de habitacion";
        }
    }
}
