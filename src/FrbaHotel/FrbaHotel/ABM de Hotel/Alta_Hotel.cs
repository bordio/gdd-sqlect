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
        private DataGridView listaHoteles;
        public Alta_Hotel(DataGridView lsHoteles)
        {
            listaHoteles = lsHoteles;
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
            Fecha_creacion.Clear();
            Fecha_creacion.AppendText(monthCalendar1.SelectionStart.ToShortDateString());
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
            Nombre.ResetText();
            Email.ResetText();
            Fecha_creacion.ResetText();
            Calle.ResetText();
            Nro_calle.ResetText();
            Pais.ResetText();
            Ciudad.ResetText();
            Cantidad_Estrellas.ResetText();
            ckAllInclusive.Checked = false;
            ckAllInclusiveModerado.Checked = false;
            ckMediaPension.Checked = false;
            ckPensionCompleta.Checked = false;
        }

        private void btAlta_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            bool retValue = this.appModel.altaHotel(Nombre, Email, Cantidad_Estrellas, Fecha_creacion,
                this.ckAllInclusive.Checked, this.ckAllInclusiveModerado.Checked, this.ckMediaPension.Checked,
                this.ckPensionCompleta.Checked, Pais, Ciudad, Calle, Nro_calle, errores);

            if (retValue)
            {
                MessageBox.Show("Alta exitosa", "Alta de Hotel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.listaHoteles.DataSource = ABM_de_Hotel.MainHotel.cargar_lista().DefaultView;
                this.listaHoteles.AllowUserToAddRows = false;
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
