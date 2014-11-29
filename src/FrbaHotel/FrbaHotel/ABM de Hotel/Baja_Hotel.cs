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
    public partial class Baja_Hotel : Form
    {
        public Baja_Hotel(StringBuilder nombre, StringBuilder pais, StringBuilder ciudad, StringBuilder calle, Int32 nro_calle)
        {
            InitializeComponent();
            Text = "Baja temporal de Hotel";
            Nombre.Text = nombre.ToString();
            Pais.Text = pais.ToString();
            Ciudad.Text = ciudad.ToString();
            Direccion.Text = new StringBuilder().AppendFormat("{0} {1}", calle.ToString(), nro_calle.ToString()).ToString();
            SeleccionarHasta.Enabled = false;
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeleccionarDesde_Click(object sender, EventArgs e)
        {
            monthCalendar2.Visible = false;
            monthCalendar1.Show();
        }

        private void SeleccionarHasta_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
            monthCalendar2.Show();
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            Hasta.Clear();
            Hasta.AppendText(monthCalendar2.SelectionStart.ToShortDateString());
            monthCalendar2.Visible = false;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            Desde.Clear();
            Desde.AppendText(monthCalendar1.SelectionStart.ToShortDateString());
            monthCalendar1.Visible = false;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
            monthCalendar2.Visible = false;
        }

        private void Desde_TextChanged(object sender, EventArgs e)
        {
            if (Desde.Text.ToString() != "")
            {
                SeleccionarHasta.Enabled = true;
                monthCalendar2.MinDate = Convert.ToDateTime(Desde.Text.ToString()).AddDays(1);
                if (Hasta.Text.ToString() != "")
                {
                    if (Convert.ToDateTime(Desde.Text.ToString()).CompareTo(Convert.ToDateTime(Hasta.Text.ToString())) > 0)
                    {
                        Hasta.ResetText();
                    }
                }
            }
        }
    }
}
