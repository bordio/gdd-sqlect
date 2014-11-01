using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class Alta_Hotel : Form
    {
        private AltaHotelApplicationModel appModel = new AltaHotelApplicationModel();
        public Alta_Hotel()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSeleccionarFecha_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtFechaCreacion.Clear();
            txtFechaCreacion.AppendText(monthCalendar1.SelectionStart.ToShortDateString());
            monthCalendar1.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtNombre.ResetText();
            txtEmail.ResetText();
            txtFechaCreacion.ResetText();
            txtCalle.ResetText();
            txtNroCalle.ResetText();
            txtPais.ResetText();
            txtCiudad.ResetText();
            txtCantEstrellas.ResetText();
            ckAllInclusive.Checked = false;
            ckAllInclusiveModerado.Checked = false;
            ckMediaPension.Checked = false;
            ckPensionCompleta.Checked = false;
        }

        private void btAlta_Click(object sender, EventArgs e)
        {
            bool retValue = this.appModel.altaHotel(this.txtNombre.Text, this.txtEmail.Text, Int32.Parse(this.txtCantEstrellas.Text),
                DateTime.Parse(this.txtFechaCreacion.Text), this.ckAllInclusive.Checked, this.ckAllInclusiveModerado.Checked, this.ckMediaPension.Checked,
                this.ckPensionCompleta.Checked, this.txtPais.Text, this.txtCiudad.Text, this.txtCalle.Text, Int32.Parse(this.txtNroCalle.Text));

            if (retValue)
            {
                MessageBox.Show("Alta exitosa", "Alta de Hotel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
