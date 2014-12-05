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
using FrbaHotel.ABM_de_Cliente;
using FrbaHotel.ABM_de_Usuario;

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
        AppModel_Alta_Usuario funcionesUsuarios = new AppModel_Alta_Usuario();
        StringBuilder mensaje = new StringBuilder();

        private void Form1_Load(object sender, EventArgs e)
        {
            if (idDeHotelDeSesion == 0)
            {
                listaHotelAElegir.Visible = true;

                StringBuilder sentencia = new StringBuilder().AppendFormat("SELECT DISTINCT h.nombre FROM SQLECT.Hoteles h LEFT JOIN SQLECT.Bajas_por_hotel bh ON (h.id_hotel=bh.fk_hotel) WHERE ( ( ('{0}' NOT BETWEEN bh.fecha_inicio AND bh.fecha_fin) AND ('{0}' NOT BETWEEN bh.fecha_inicio AND bh.fecha_fin) AND ('{0}'>bh.fecha_fin OR '{0}'<bh.fecha_inicio) ) OR (bh.fecha_inicio IS NULL AND bh.fecha_fin IS NULL) ) ",funcionesVarias.devolverFechaAppConfig());
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

            if ((idDeHotelDeSesion == 0) & !funcionesUsuarios.validarComboVacio(listaHotelAElegir,mensaje) )
            {
                MessageBox.Show("Debe elegir un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (idDeHotelDeSesion == 0)
                    idHotelElegido = funcionesVarias.obtenerIDHotel(listaHotelAElegir.SelectedItem.ToString());
                else
                    idHotelElegido = idDeHotelDeSesion;

                FrbaHotel.Generar_Modificar_Reserva.GenerarReserva formGenerarReserva = new FrbaHotel.Generar_Modificar_Reserva.GenerarReserva(idHotelElegido, usuarioDeSesion);
                formGenerarReserva.Show();
            }

            /*FrbaHotel.Generar_Modificar_Reserva.GenerarReserva formGenerarReserva = new FrbaHotel.Generar_Modificar_Reserva.GenerarReserva(idHotelElegido,usuarioDeSesion);
            formGenerarReserva.Show();*/



        }

        private void botonModificarReserva_Click(object sender, EventArgs e)
        {
            int idHotelElegido = 0;

            if ((idDeHotelDeSesion == 0) & !funcionesUsuarios.validarComboVacio(listaHotelAElegir, mensaje))
            {
                MessageBox.Show("Debe elegir un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (idDeHotelDeSesion == 0)
                    idHotelElegido = funcionesVarias.obtenerIDHotel(listaHotelAElegir.SelectedItem.ToString());
                else
                    idHotelElegido = idDeHotelDeSesion;

                FrbaHotel.Cancelar_Reserva.Form1 formModificarReserva = new FrbaHotel.Cancelar_Reserva.Form1(idHotelElegido, usuarioDeSesion, false);
                formModificarReserva.Show();
            }

            /*FrbaHotel.Cancelar_Reserva.Form1 formModificarReserva = new FrbaHotel.Cancelar_Reserva.Form1(idDeHotelDeSesion, usuarioDeSesion, false);
            formModificarReserva.Show();*/

        }
    }
}
