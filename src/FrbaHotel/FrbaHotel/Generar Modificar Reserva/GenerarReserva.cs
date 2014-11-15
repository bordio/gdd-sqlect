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
        public GenerarReserva(int idDeHotel)
        {
            InitializeComponent();
            this.idHotelEnCuestion = idDeHotel;
        }

        int idHotelEnCuestion;
        bool soyDesde = false;

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
            fechaDesde.Enabled = true;
            fechaHasta.Enabled = true;
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
                if (Convert.ToDateTime(fechaDesde.Text) <= Convert.ToDateTime(fechaHasta.Text))
                    fechasValidas = true;
                 else
                    mensajeValidacion.AppendLine("La fecha de Check-in es posterior a la de Check-out");
            }

            if (!fechasValidas)
            {
                MessageBox.Show(mensajeValidacion.ToString());
                mensajeValidacion.Remove(0, mensajeValidacion.Length);
            }
            else
            {
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

                //Cargo los máximos disponibles por cada tipo de habitación
                 DataTable tablaDeMaximos = funcionesReservas.habitacionesMaximasDisponibles(fechaDesde.Text, fechaHasta.Text, idHotelEnCuestion);

                 dataGridView1.DataSource = tablaDeMaximos.DefaultView;
                
                for (int i =0; i < tablaDeMaximos.Rows.Count; i++) 
                
                { int tipoHab=Convert.ToInt32(tablaDeMaximos.Rows[i]["Tipo"].ToString());
                    
                    switch(tipoHab)
                    {
                        case 1001:
                        cantidadSimples.Maximum= Convert.ToInt32(tablaDeMaximos.Rows[i]["Cant."].ToString() );
                        break;
                        case 1002:
                        cantidadDobles.Maximum = Convert.ToInt32(tablaDeMaximos.Rows[i]["Cant."].ToString());
                        break;
                        case 1003:
                        cantidadTriples.Maximum = Convert.ToInt32(tablaDeMaximos.Rows[i]["Cant."].ToString());
                        break;
                        case 1004:
                        cantidadCuádruples.Maximum = Convert.ToInt32(tablaDeMaximos.Rows[i]["Cant."].ToString());
                        break;
                        case 1005:
                        cantidadQuíntuples.Maximum = Convert.ToInt32(tablaDeMaximos.Rows[i]["Cant."].ToString());
                        break;

                    
                    }
                
                    
                }

               

                              
            
            }
            
        }

      
    }
}
