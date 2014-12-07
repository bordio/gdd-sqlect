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
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class Form1 : Form
    {
        public Form1(int idHotel,string codigoReserva)
        {
            InitializeComponent();
            this.idHotelEnCuestion = idHotel;
            this.codigoReservaActual = codigoReserva;
        }

        AppModel_Facturacion funcionesFacturacion = new AppModel_Facturacion();
        AppModel_Consumible funcionesConsumibles = new AppModel_Consumible();
        AppModel_Alta_Usuario funcionesVarias = new AppModel_Alta_Usuario();
        AppModel_Reservas funcionesReservas = new AppModel_Reservas();
        private int idHotelEnCuestion;
        private string codigoReservaActual;
        StringBuilder mensaje = new StringBuilder();

        private void Form1_Load(object sender, EventArgs e)
        {

            DataTable tablaConsumibles = funcionesConsumibles.cargarConsumibles(codigoReservaActual);
            tablaDeConsumibles.DataSource = tablaConsumibles.DefaultView;

        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            funcionesFacturacion.generarFactura(codigoReservaActual, idHotelEnCuestion,funcionesReservas.devolverFechaAppConfig());
            funcionesFacturacion.descontarConsumiblesPorRegimen(codigoReservaActual);
           
            FrbaHotel.Registrar_Consumible.Facturacion formFacturacion = new Facturacion(codigoReservaActual,idHotelEnCuestion,this);
            formFacturacion.ShowDialog();
        }

        private void botonRegistrarConsumible_Click(object sender, EventArgs e)
        {
            RegistrarConsumible formRegistrarConsumible = new RegistrarConsumible(codigoReservaActual,"agregar");
            if (formRegistrarConsumible.ShowDialog() == DialogResult.OK)
            {
                DataTable tablaConsumibles = funcionesConsumibles.cargarConsumibles(codigoReservaActual);
                tablaDeConsumibles.DataSource = tablaConsumibles.DefaultView;
            
            }
        }

        private void botonModificarConsumible_Click(object sender, EventArgs e)
        {
            RegistrarConsumible formRegistrarConsumible = new RegistrarConsumible(codigoReservaActual, "modificar");
            if (formRegistrarConsumible.ShowDialog() == DialogResult.OK)
            {
                DataTable tablaConsumibles = funcionesConsumibles.cargarConsumibles(codigoReservaActual);
                tablaDeConsumibles.DataSource = tablaConsumibles.DefaultView;

            }
        }

        private void botonBorrarConsumible_Click(object sender, EventArgs e)
        {
            RegistrarConsumible formRegistrarConsumible = new RegistrarConsumible(codigoReservaActual, "borrar");
            if (formRegistrarConsumible.ShowDialog() == DialogResult.OK)
            {
                DataTable tablaConsumibles = funcionesConsumibles.cargarConsumibles(codigoReservaActual);
                tablaDeConsumibles.DataSource = tablaConsumibles.DefaultView;
            }
        }

        public bool hacerRollBack = true;

        public void Cerrate(bool rollback)
        {
            this.hacerRollBack = rollback;
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (hacerRollBack)
            {
                Conexion.Instance.ejecutarQuery("ROLLBACK");
            }
        }


  
  }
   
}

