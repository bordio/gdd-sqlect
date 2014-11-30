using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class Baja_Hotel : Form
    {
        private StringBuilder errores = new StringBuilder();
        private Conexion connSql = Conexion.Instance;
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
            if (Desde.Text.Length > 0)
            {
                SeleccionarHasta.Enabled = true;
                monthCalendar2.MinDate = Convert.ToDateTime(Desde.Text.ToString()).AddDays(1);
                if (Hasta.Text.Length > 0)
                {
                    if (Convert.ToDateTime(Desde.Text.ToString()).CompareTo(Convert.ToDateTime(Hasta.Text.ToString())) > 0)
                    {
                        Hasta.ResetText();
                    }
                }
            }
        }

        private void Dar_baja_Click(object sender, EventArgs e)
        {
            validar_formulario();
            if (validar_establecimiento_vacio()) errores.AppendLine("El establecimiento no se encuentra vacio en el rango de fechas seleccionado.");
            if (errores.Length > 0) MessageBox.Show(errores.ToString(), "Errores al tratar de dar de baja", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool validar_establecimiento_vacio()
        {
            StringBuilder sentece = new StringBuilder();

            if (Desde.Text.Length > 0 && Hasta.Text.Length > 0)
            {
                StringBuilder fecha_desde = new StringBuilder();
                fecha_desde.AppendFormat("{0}{1}{2}", DateTime.Parse(Desde.Text).Year.ToString(), (Int32.Parse(DateTime.Parse(Desde.Text).Month.ToString()) < 10) ? "0" + DateTime.Parse(Desde.Text).Month.ToString() : DateTime.Parse(Desde.Text).Month.ToString(), Int32.Parse(DateTime.Parse(Desde.Text).Day.ToString()) < 10 ? "0" + DateTime.Parse(Desde.Text).Day.ToString() : DateTime.Parse(Desde.Text).Day.ToString());

                StringBuilder fecha_hasta = new StringBuilder();
                fecha_hasta.AppendFormat("{0}{1}{2}", DateTime.Parse(Hasta.Text).Year.ToString(), (Int32.Parse(DateTime.Parse(Hasta.Text).Month.ToString()) < 10) ? "0" + DateTime.Parse(Hasta.Text).Month.ToString() : DateTime.Parse(Hasta.Text).Month.ToString(), Int32.Parse(DateTime.Parse(Hasta.Text).Day.ToString()) < 10 ? "0" + DateTime.Parse(Hasta.Text).Day.ToString() : DateTime.Parse(Hasta.Text).Day.ToString());

                sentece.AppendFormat("SELECT id_reserva FROM SQLECT.Reservas WHERE NOT (estado_reserva in (2,3,4)) AND fecha_inicio BETWEEN '{0}' AND '{1}' OR fecha_inicio+cant_noches_reserva BETWEEN '{0}' AND '{1}'", fecha_desde.ToString(), fecha_hasta.ToString());
                return this.connSql.ejecutarQuery(sentece.ToString()).Rows.Count > 0;
            }
            return false;
        }

        private bool validar_formulario()
        {
            errores.Remove(0, errores.Length);
            bool result = true;
            if (Desde.Text.Length == 0)
            {
                result = false;
                errores.AppendLine("El campo Desde es obligatorio.");
            }
            if (Hasta.Text.Length == 0)
            {
                result = false;
                errores.AppendLine("El campo Hasta es obligatorio.");
            }
            if (txtMotivo.Text.Length == 0)
            {
                result = false;
                errores.AppendLine("El campo Motivo es obligatorio.");
            }
            return result;
        }
    }
}
