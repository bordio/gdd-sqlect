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
using FrbaHotel.Login;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class Form1 : Form
    {
        public Form1(int idDeHotel, string usuarioDeSesion)
        {
            InitializeComponent();

            this.idDeHotelDeSesion = idDeHotel;
            this.usuarioDeSesion = usuarioDeSesion;

        }

        int idDeHotelDeSesion;
        string usuarioDeSesion;
        Funcionalidades funcionesVarias = new Funcionalidades();

        private void Form1_Load(object sender, EventArgs e)
        {
            if (idDeHotelDeSesion == 0)
            {
                listaHotelAElegir.Visible = true;

                StringBuilder sentencia = new StringBuilder().AppendFormat("SELECT DISTINCT h.nombre FROM SQLECT.Hoteles h WHERE h.estado_hotel =1 ");
                DataTable tablaHoteles = Conexion.Instance.ejecutarQuery(sentencia.ToString());

                foreach (DataRow dat in tablaHoteles.Rows)
                {

                    listaHotelAElegir.Items.Add(dat[0]);
                }

            }
            else
            {
                hotelDeSesion.Visible = true;
                listaHotelAElegir.Visible = false;
                hotelDeSesion.Text = funcionesVarias.obtenerNombreHotel(idDeHotelDeSesion);
            }

        }

        private void botonGenerarReserva_Click(object sender, EventArgs e)
        {
            int idHotelElegido=0;

            if ((idDeHotelDeSesion == 0) & string.IsNullOrEmpty(listaHotelAElegir.SelectedItem.ToString()))
            {
                MessageBox.Show("Debe elegir un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (idDeHotelDeSesion == 0)
                    idHotelElegido = funcionesVarias.obtenerIDHotel(listaHotelAElegir.SelectedItem.ToString());
                else
                    idHotelElegido = idDeHotelDeSesion;
            }

            FrbaHotel.Generar_Modificar_Reserva.GenerarReserva formGenerarReserva = new FrbaHotel.Generar_Modificar_Reserva.GenerarReserva(idHotelElegido,usuarioDeSesion);
            formGenerarReserva.Show();



        }
    }
}
