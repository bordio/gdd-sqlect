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
        private HotelAppModel appModel;
        private DataGridView listaHoteles;

        public Alta_Hotel(DataGridView lsHoteles)
        {
            listaHoteles = lsHoteles;
            InitializeComponent();
            appModel = new AltaHotelAppModel();
            Text = "Alta de Hotel";
        }

        public Alta_Hotel(DataGridView lsHoteles, StringBuilder pais, StringBuilder ciudad, StringBuilder calle, Int32 nro_calle)
        {
            listaHoteles = lsHoteles;
            InitializeComponent();
            appModel = new ModificacionAppModel();
            Text = "Modificacion de Hotel";
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
            bool retValue = this.appModel.actionHotel(Nombre, Email, Cantidad_Estrellas, Fecha_creacion,
                this.ckAllInclusive.Checked, this.ckAllInclusiveModerado.Checked, this.ckMediaPension.Checked,
                this.ckPensionCompleta.Checked, Pais, Ciudad, Calle, Nro_calle, errores);

            if (retValue)
            {
                this.listaHoteles.DataSource = ABM_de_Hotel.MainHotel.cargar_lista(ABM_de_Hotel.MainHotel.getAllInstances()).DefaultView;
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
