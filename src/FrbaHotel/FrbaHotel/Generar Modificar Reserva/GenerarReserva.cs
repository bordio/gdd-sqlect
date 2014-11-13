using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;
using FrbaHotel.Commons.FuncionalidadesVarias;


namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class GenerarReserva : Form
    {
        public GenerarReserva(int idDeHotel)
        {
            InitializeComponent();
            this.idHotelEnCuestion = idDeHotel;
        }

        int idHotelEnCuestion;
        bool soyDesde = false;

        private void GenerarReserva_Load(object sender, EventArgs e)
        {
            monthCalendar.Visible = false;

            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT r.descripcion FROM SQLECT.Regimenes_Hoteles rh JOIN SQLECT.Hoteles h ON (rh.fk_hotel=h.id_hotel) JOIN SQLECT.Regimenes r ON (r.id_regimen=rh.fk_regimen) WHERE h.id_hotel={0}",idHotelEnCuestion);
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            foreach (DataRow dat in tabla.Rows)
            {

                comboRegimen.Items.Add(dat[0]);
            }

            
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (soyDesde)
            {
                fechaDesde.Clear();
                fechaDesde.AppendText(monthCalendar.SelectionStart.ToShortDateString());
                monthCalendar.Visible = false;
                
            }
            else
            {
                fechaHasta.Clear();
                fechaHasta.AppendText(monthCalendar.SelectionStart.ToShortDateString());
                monthCalendar.Visible = false;
            }

        }

        private void botonSeleccionarD_Click(object sender, EventArgs e)
        {
            monthCalendar.Visible = true;
            soyDesde = true;
           
        }

        private void botonSeleccionarH_Click(object sender, EventArgs e)
        {
            monthCalendar.Visible = true;
            soyDesde = false;
        }
    }
}
