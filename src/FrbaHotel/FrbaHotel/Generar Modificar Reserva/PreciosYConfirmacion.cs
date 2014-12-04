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
    public partial class PreciosYConfirmacion : Form
    {
        Form formularioAnterior;
        public PreciosYConfirmacion(string tipoRegimen, int idDelHotel, decimal cantHues, decimal cantSimples, decimal cantDobles, decimal cantTri, decimal cantCuadru, decimal cantQuin, string fechaDesde, string fechaHasta, string usuarioDeSesion, Form formulario)
        {
            InitializeComponent();
            formularioAnterior = formulario;
            this.regimenElegido = tipoRegimen;
            this.idHotelEnCuestion = idDelHotel;
            this.cantidadHuespedes = cantHues;
            this.cantidadSimples = cantSimples;
            this.cantidadDobles = cantDobles;
            this.cantidadTriples = cantTri;
            this.cantidadCuadruples = cantCuadru;
            this.cantidadQuintuples = cantQuin;
            this.fechaDesde=fechaDesde;
            this.fechaHasta=fechaHasta;
            this.usuarioDeSesion = usuarioDeSesion;
        }


        AppModel_Reservas funcionesReservas = new AppModel_Reservas();

        string usuarioDeSesion;
        string regimenElegido;
        int idHotelEnCuestion;
        decimal cantidadHuespedes;
        decimal cantidadSimples;
        decimal cantidadDobles;
        decimal cantidadTriples;
        decimal cantidadCuadruples;
        decimal cantidadQuintuples;
        string fechaDesde;
        string fechaHasta;


        private void PreciosYConfirmacion_Load(object sender, EventArgs e)
        {

            TimeSpan fechaDif = DateTime.Parse(fechaHasta) - DateTime.Parse(fechaDesde);
            int diasReservados = fechaDif.Days + 1;


            textoPresentacion.Text = string.Format("Precios de las habtiaciones para el régimen: {0}", regimenElegido.ToString());

            DataTable tablaDePreciosDelRegimen = funcionesReservas.obtenerPreciosDeHabtitaciones(regimenElegido, idHotelEnCuestion);

            tablaPreciosHabitaciones.DataSource = tablaDePreciosDelRegimen.DefaultView;

            /*DataGridViewCheckBoxColumn pruebaCheckBox = new DataGridViewCheckBoxColumn();*/
          

            if (funcionesReservas.chequearCantHuespedesYHabitaciones(Convert.ToInt32(cantidadHuespedes), Convert.ToInt32(cantidadSimples), Convert.ToInt32(cantidadDobles), Convert.ToInt32(cantidadTriples), Convert.ToInt32(cantidadCuadruples), Convert.ToInt32(cantidadQuintuples)) & cantidadHuespedes>0)
            {
                
                textoInformativo.Text=(string.Format("Está reservando {0} noches", diasReservados.ToString()));
                textPrecioReserva.Visible = true;
                textPrecioReserva.Text = string.Format("U$S {0}",funcionesReservas.calcularPrecioReserva(tablaDePreciosDelRegimen,diasReservados, Convert.ToInt32(cantidadSimples), Convert.ToInt32(cantidadDobles), Convert.ToInt32(cantidadTriples), Convert.ToInt32(cantidadCuadruples), Convert.ToInt32(cantidadQuintuples)).ToString() );    
                botonElegirHabitaciones.Enabled = true;
            }
            else
            {
                if (cantidadHuespedes == 0)
                textoInformativo.Text="No eligio la cantidad de huéspedes";
                else
                textoInformativo.Text = "Hay más huéspedes que la capacidad de alojamiento de habitaciones que escogio";
            }
        
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonRealizarReserva_Click(object sender, EventArgs e)
        {

            ElegirHabitaciones formFinal = new ElegirHabitaciones(idHotelEnCuestion, fechaDesde, fechaHasta, Convert.ToInt32(cantidadSimples), Convert.ToInt32(cantidadDobles),Convert.ToInt32(cantidadTriples),Convert.ToInt32(cantidadCuadruples) ,Convert.ToInt32(cantidadQuintuples),usuarioDeSesion,regimenElegido,Convert.ToInt32(cantidadHuespedes),this);
            formFinal.Show();

            
            /*TimeSpan difFech = DateTime.Parse(fechaHasta) - DateTime.Parse(fechaDesde);
            int cantNoches = difFech.Days + 1;        

            bool reservaHecha = funcionesReservas.realizarReserva(fechaDesde, cantNoches, usuarioDeSesion, regimenElegido, idHotelEnCuestion, Convert.ToInt32(cantidadSimples), Convert.ToInt32(cantidadDobles), Convert.ToInt32(cantidadTriples), Convert.ToInt32(cantidadCuadruples), Convert.ToInt32(cantidadQuintuples));
            if (reservaHecha)
                MessageBox.Show("Falta hacer el insert a la BD");*/
        }

        public void Cerrate() {
            this.Close();
            formularioAnterior.Close();
        }
    }
}
