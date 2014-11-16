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
        public PreciosYConfirmacion(string tipoRegimen, int idDelHotel, decimal cantHues, decimal cantSimples, decimal cantDobles, decimal cantTri, decimal cantCuadru, decimal cantQuin, string fechaDesde, string fechaHasta)
        {
            InitializeComponent();
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
        }

        AppModel_Reservas funcionesReservas = new AppModel_Reservas();
        
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

            if (funcionesReservas.chequearCantHuespedesYHabitaciones(Convert.ToInt32(cantidadHuespedes), Convert.ToInt32(cantidadSimples), Convert.ToInt32(cantidadDobles), Convert.ToInt32(cantidadTriples), Convert.ToInt32(cantidadCuadruples), Convert.ToInt32(cantidadQuintuples)) & cantidadHuespedes>0)
            {
                textoInformativo.Text=(string.Format("Reservo {0} días", diasReservados.ToString()));
                botonRealizarReserva.Enabled = true;
            }
            else
            {
                if (cantidadHuespedes == 0)
                textoInformativo.Text="No eligio huéspedes";
                else
                textoInformativo.Text = "Hay más huéspedes que la disponibilidad de habitaciones que escogio";
            }
        
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonRealizarReserva_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Falta hacer el insert a la BD");
        }
    }
}
