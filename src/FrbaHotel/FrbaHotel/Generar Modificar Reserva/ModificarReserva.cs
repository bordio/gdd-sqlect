using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;
using FrbaHotel.ABM_de_Usuario;

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

        AppModel_Alta_Usuario funciones = new AppModel_Alta_Usuario();
        AppModel_Reservas funcionesReservas = new AppModel_Reservas();
        /*string fechaDesdeReserva;
        string fechaHastaReserva;*/
        int idHotelEnCuestion;
        string usuarioDeSesionActual;
        string codigoReservaActual;
        bool soyDesde = false;
        bool cambioDeFecha = false;
        private string fechaDesdeConvertida;
        private string fechaHastaConvertida;
        private int fechaActual;
        StringBuilder mensajeValidacion = new StringBuilder();
        
        private void ModificarReserva_Load(object sender, EventArgs e)
        {
            fechaActual = funcionesReservas.devolverFechaAppConfig();
            tablaPreciosRegimenes.Visible = false;

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

                fechaDesdeConvertida = fechaDesdeCruda.ToShortDateString();
                fechaHastaConvertida = fechaHastaCruda.ToShortDateString();

                fechaDesde.Text = fechaDesdeConvertida;
                fechaHasta.Text = fechaHastaConvertida;
                regimenActual.Text = datos[2].ToString();

            }
      
        }

            
        private void checkCambiarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCambiarFechas.Checked == true)
            {
                botonSeleccionarH.Enabled = true;
                botonSeleccionarD.Enabled = true;

            }
            else
            {
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

        private void botonConsultarDispo_Click(object sender, EventArgs e)
        {
         
            /*Valido que tengan fechas*/
            bool fechaDesdeOK = this.funciones.validarNoVacio(fechaDesde, mensajeValidacion);
            bool fechaHastaOK = this.funciones.validarNoVacio(fechaHasta, mensajeValidacion);

            bool fechasValidas = false;


            if (fechaDesdeOK & fechaHastaOK)
            {
                if ( (funcionesReservas.pasarDateTimeAInt(DateTime.Parse(fechaDesde.Text)) < fechaActual) | (funcionesReservas.pasarDateTimeAInt(DateTime.Parse(fechaHasta.Text)) < fechaActual) )
                    MessageBox.Show("No puede elegir fechas anterior a la actual","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                else
                {

                    if (Convert.ToDateTime(fechaDesde.Text) > Convert.ToDateTime(fechaHasta.Text))
                        MessageBox.Show("El check-in es posterior al check-out","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    else

                        fechasValidas = true;
                    /*if (Convert.ToDateTime(fechaDesde.Text) <= Convert.ToDateTime(fechaHasta.Text)  )
                        fechasValidas = true;
                     else
                        mensajeValidacion.AppendLine("La fecha de Check-in es posterior a la de Check-out");*/

                }
            }

            if (fechasValidas)
            {  
                string regimenModificado = regimenActual.Text;
                cambioDeFecha = false;


            if ((fechaDesdeConvertida != fechaDesde.Text) | (fechaHastaConvertida != fechaHasta.Text))
            {
                cambioDeFecha = true;
            }

            if ((comboRegimen.SelectedIndex > -1) & (Convert.ToString(comboRegimen.SelectedItem) != regimenActual.Text) )
                regimenModificado = comboRegimen.SelectedItem.ToString();
            else
            { regimenModificado = regimenActual.Text; }

                tablaPreciosRegimenes.Visible = false;
                
                funcionesReservas.desocuparHabitacionesDeReserva(codigoReservaActual);
                
                FrbaHotel.Generar_Modificar_Reserva.ModificarHabitaciones formModificarHabitaciones = new ModificarHabitaciones(codigoReservaActual,regimenModificado,fechaDesde.Text,fechaHasta.Text,cambioDeFecha,idHotelEnCuestion,usuarioDeSesionActual);
                formModificarHabitaciones.ShowDialog(); 

            }


        }

        private void botonPreciosRegimen_Click(object sender, EventArgs e)
        {

            if (comboRegimen.SelectedIndex>-1)
            {
                DataTable tablaDePreciosDelRegimen = funcionesReservas.obtenerPreciosDeHabtitaciones(comboRegimen.SelectedItem.ToString(), idHotelEnCuestion);

                tablaPreciosRegimenes.DataSource = tablaDePreciosDelRegimen.DefaultView;
                tablaPreciosRegimenes.Visible = true;
                button1.Enabled = true;
            }
            else
                MessageBox.Show("No selecciono ningún regimen");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablaPreciosRegimenes.Visible = false;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
