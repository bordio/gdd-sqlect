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
    public partial class FormHabitacion : Form
    {
        private HabitacionAppModel appModel;
        public FormHabitacion(HabitacionAppModel appmodel)
        {
            this.appModel = appmodel;
            InitializeComponent();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            bool retValue = this.appModel.actionHabitacion(cmbHoteles, Numero_Habitacion, Piso, cmbTipoHabitacion,
                rdExterior, rdInterior, Descripcion, errores);
            if (retValue)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(errores.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errores = null;
            }
        }
    }
}
