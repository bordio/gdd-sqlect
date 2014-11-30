using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class RegistroCliente : Form
    {
        public RegistroCliente(int idReservaDelCliente)
        {
            InitializeComponent();
            this.idReservaDelCliente = idReservaDelCliente;
        }

        int idReservaDelCliente;
        private void button1_Click(object sender, EventArgs e)
        {
            FrbaHotel.ABM_de_Cliente.BaseAltaModificacion_Cliente formAltaCliente = new FrbaHotel.ABM_de_Cliente.Alta_Cliente(idReservaDelCliente);
            formAltaCliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrbaHotel.ABM_de_Cliente.ModificacionMain_Cliente formBuscarCliente = new FrbaHotel.ABM_de_Cliente.ModificacionMain_Cliente(idReservaDelCliente);
            formBuscarCliente.Show();
        
        }
    }
}
