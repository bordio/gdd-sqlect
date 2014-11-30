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

        AppModel_Alta_Usuario funcionesVarias = new AppModel_Alta_Usuario();
        AppModel_Reservas funcionesReservas = new AppModel_Reservas();
        private int idHotelEnCuestion;
        private string codigoReservaActual;
        StringBuilder mensaje = new StringBuilder();

        private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT DISTINCT nombre FROM SQLECT.Items");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());



        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
        
        }

        private void botonAgregarFila_Click(object sender, EventArgs e)
        {
           
        }

        private void tablaDeConsumibles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            
            
            }

        
  }
   
}

