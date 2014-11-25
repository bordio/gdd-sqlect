using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class ModificarReserva : Form
    {
        public ModificarReserva(string usuarioDeSesion, string codigoReserva, int idHotel)
        {
            InitializeComponent();
            this.usuarioDeSesionActual = usuarioDeSesion;
            this.codigoReservaActual = codigoReserva;
            this.idHotelEnCuestion = idHotel;
        }

        AppModel_Reservas funcionesReservas = new AppModel_Reservas();
        int idHotelEnCuestion;
        string usuarioDeSesionActual;
        string codigoReservaActual;
        bool soyDesde = false;
        
        private void ModificarReserva_Load(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT r.descripcion FROM SQLECT.Regimenes_Hoteles rh JOIN SQLECT.Hoteles h ON (rh.fk_hotel=h.id_hotel) JOIN SQLECT.Regimenes r ON (r.id_regimen=rh.fk_regimen) WHERE h.id_hotel={0}", idHotelEnCuestion);
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            foreach (DataRow dat in tabla.Rows)
            {

                comboRegimen.Items.Add(dat[0]);
            }

            StringBuilder sentecia = new StringBuilder().AppendFormat("SELECT r.fecha_inicio,r.cant_noches_reserva,re.descripcion FROM SQLECT.Reservas r JOIN SQLECT.Regimenes re ON (r.fk_regimen=re.id_regimen) WHERE r.codigo_reserva='{0}'", codigoReservaActual);
            DataTable tablaDatosReserva = Conexion.Instance.ejecutarQuery(sentecia.ToString());

            foreach (DataRow datos in tablaDatosReserva.Rows)
            {
                int calculo = Convert.ToInt32(datos[1].ToString()) - 1;

                DateTime fechaDesdeCruda = DateTime.Parse(datos[0].ToString());
                DateTime fechaHastaCruda = fechaDesdeCruda.AddDays(Convert.ToDouble(calculo));

                string fechaDesdeConvertida = fechaDesdeCruda.ToShortDateString();
                string fechaHastaConvertida = fechaHastaCruda.ToShortDateString();

                fechaDesde.Text = fechaDesdeConvertida;
                fechaHasta.Text = fechaHastaConvertida;          
            }
        
        
        }

    
        
        
        private void checkCambiarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCambiarFechas.Checked == true)
            {
                botonSeleccionarH.Enabled = true;
                botonSeleccionarD.Enabled = true;
                botonConsultarDispo.Enabled = true;

            }
            else
            {
                botonConsultarDispo.Enabled = false;
                botonSeleccionarH.Enabled = false;
                botonSeleccionarD.Enabled = false;
            }
        }

        private void checkCambiarRegimen_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCambiarRegimen.Checked == true)
            {
                botonPreciosRegimen.Enabled = true;
                comboRegimen.Enabled = true;
            }
            else
            {
                botonPreciosRegimen.Enabled = false;
                comboRegimen.Enabled = false;                   
            }
        }

        private void botonSeleccionarD_Click(object sender, EventArgs e)
        {
            soyDesde = true;
            monthCalendar.Visible = true;
        }

        private void botonSeleccionarH_Click(object sender, EventArgs e)
        {
            soyDesde = false;
            monthCalendar.Visible = true;
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (soyDesde)
            {
                fechaDesde.Clear();
                fechaDesde.AppendText(monthCalendar.SelectionStart.ToShortDateString());
            }
            else
            {
                fechaHasta.Clear();
                fechaHasta.AppendText(monthCalendar.SelectionStart.ToShortDateString());
            }
            monthCalendar.Visible = false;
        }
    }
}
