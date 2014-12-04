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
using FrbaHotel.ABM_de_Usuario;


namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class GenerarReserva : Form
    {
        public GenerarReserva(int idDeHotel,string usuarioDeSesion)
        {
            InitializeComponent();
            this.idHotelEnCuestion = idDeHotel;
            this.usuarioDeSesion = usuarioDeSesion;
        }

        int idHotelEnCuestion;
        string usuarioDeSesion;
        bool soyDesde = false;
        DateTime fechaActual = DateTime.Today;

        AppModel_Alta_Usuario funciones = new AppModel_Alta_Usuario();
        StringBuilder mensajeValidacion = new StringBuilder();
        AppModel_Reservas funcionesReservas = new AppModel_Reservas();

        private void GenerarReserva_Load(object sender, EventArgs e)
        {
            
            monthCalendar.Visible = false;

            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT r.descripcion FROM SQLECT.Regimenes_Hoteles rh JOIN SQLECT.Hoteles h ON (rh.fk_hotel=h.id_hotel) JOIN SQLECT.Regimenes r ON (r.id_regimen=rh.fk_regimen) WHERE h.id_hotel={0}",idHotelEnCuestion);
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            foreach (DataRow dat in tabla.Rows)
            {

                comboRegimen.Items.Add(dat[0]);
            }

            comboRegimen.Enabled = false;
            botonPrecio.Enabled = false;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            botonConsultarDispo.Enabled = true;
            label12.Visible = false;
            comboRegimen.Enabled = false;
            comboRegimen.SelectedItem = null;
            botonPrecio.Enabled = false;

            botonSeleccionarD.Enabled = true;
            botonSeleccionarH.Enabled=true;

            fechaDesde.Text = null;
            fechaHasta.Text = null;

            cantidadSimples.Enabled = false;
            cantidadDobles.Enabled = false;
            cantidadTriples.Enabled = false;
            cantidadCuádruples.Enabled=false;
            cantidadQuíntuples.Enabled = false;
            cantidadHuéspedes.Enabled = false;

            maxSimples.Visible = false;
            maxDobles.Visible = false;
            maxTriples.Visible = false;
            maxCuadruples.Visible = false;
            maxQuintuples.Visible = false;

            cantidadHuéspedes.Value = 0;
            cantidadSimples.Value = 0;
            cantidadDobles.Value = 0;
            cantidadTriples.Value = 0;
            cantidadCuádruples.Value = 0;
            cantidadQuíntuples.Value = 0;

            monthCalendar.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
      
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            /*Valido que tengan fechas*/
            bool fechaDesdeOK = this.funciones.validarNoVacio(fechaDesde, mensajeValidacion);
            bool fechaHastaOK = this.funciones.validarNoVacio(fechaHasta, mensajeValidacion);

            bool fechasValidas=false;


            if (fechaDesdeOK & fechaHastaOK)
            {
                if (Convert.ToDateTime(fechaDesde.Text) < fechaActual | Convert.ToDateTime(fechaHasta.Text) < fechaActual)
                    MessageBox.Show("No puede elegir fechas anterior a la actual");

                else
                {

                    if (Convert.ToDateTime(fechaDesde.Text) > Convert.ToDateTime(fechaHasta.Text))
                        MessageBox.Show("El check-in es posterior al check-out");
                    else

                        fechasValidas = true;
                    /*if (Convert.ToDateTime(fechaDesde.Text) <= Convert.ToDateTime(fechaHasta.Text)  )
                        fechasValidas = true;
                     else
                        mensajeValidacion.AppendLine("La fecha de Check-in es posterior a la de Check-out");*/

                }
            }

            if (!fechasValidas)
            {
                MessageBox.Show(mensajeValidacion.ToString());
                mensajeValidacion.Remove(0, mensajeValidacion.Length);
            }
            else
            {
                //Cargo los máximos disponibles por cada tipo de habitación            
                
                DataTable tablaDeMaximos = funcionesReservas.habitacionesMaximasDisponibles(fechaDesde.Text, fechaHasta.Text, idHotelEnCuestion);
                funcionesReservas.cargarCantidadesMaximasDeHabitaciones(tablaDeMaximos, cantidadSimples, cantidadDobles, cantidadTriples, cantidadCuádruples, cantidadQuíntuples);

                if (cantidadSimples.Maximum == 0 & cantidadDobles.Maximum == 0 & cantidadTriples.Maximum == 0 & cantidadCuádruples.Maximum == 0 & cantidadQuíntuples.Maximum == 0)
                {
                    MessageBox.Show(string.Format("Se encuentra todo reservado para el {0} hasta el {1}", fechaDesde.Text.ToString(), fechaHasta.Text.ToString()));
                }
                else
                {
                    botonConsultarDispo.Enabled = false;

                    comboRegimen.Enabled = true;

                    botonSeleccionarD.Enabled = false;
                    botonSeleccionarH.Enabled = false;
                    fechaDesde.Enabled = false;
                    fechaHasta.Enabled = false;

                    label12.Visible = true;
                    cantidadSimples.Enabled = true;
                    cantidadDobles.Enabled = true;
                    cantidadTriples.Enabled = true;
                    cantidadCuádruples.Enabled = true;
                    cantidadQuíntuples.Enabled = true;
                    cantidadHuéspedes.Enabled = true;
                    comboRegimen.Enabled = true;

                    botonPrecio.Enabled = true;

                    maxSimples.Visible = true;
                    maxDobles.Visible = true;
                    maxTriples.Visible = true;
                    maxCuadruples.Visible = true;
                    maxQuintuples.Visible = true;

                    maxSimples.Text = cantidadSimples.Maximum.ToString();
                    maxDobles.Text = cantidadDobles.Maximum.ToString();
                    maxTriples.Text = cantidadTriples.Maximum.ToString();
                    maxCuadruples.Text = cantidadCuádruples.Maximum.ToString();
                    maxQuintuples.Text = cantidadQuíntuples.Maximum.ToString();
                }
            
            }
            
        }

        private void botonPrecio_Click(object sender, EventArgs e)
        {
            if (comboRegimen.SelectedIndex<0)
                MessageBox.Show("Debe elegir un tipo de Régimen");
            else
            {
                PreciosYConfirmacion formularioPrecios = new PreciosYConfirmacion(comboRegimen.SelectedItem.ToString(), idHotelEnCuestion, cantidadHuéspedes.Value, cantidadSimples.Value, cantidadDobles.Value, cantidadTriples.Value, cantidadCuádruples.Value, cantidadQuíntuples.Value,fechaDesde.Text.ToString(),fechaHasta.Text.ToString(), usuarioDeSesion, this);
                formularioPrecios.ShowDialog();
            }
        }

      
    }
}
