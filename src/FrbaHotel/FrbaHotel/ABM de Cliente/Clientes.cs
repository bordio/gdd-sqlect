using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void btAlta_Click(object sender, EventArgs e)
        {
            BaseAltaModificacion_Cliente formAlta = new Alta_Cliente();
            formAlta.Show();
        }

        private void btModifBaja_Click(object sender, EventArgs e)
        {
            ModificacionMain_Cliente formModifBaja = new ModificacionMain_Cliente();
            formModifBaja.Show();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
