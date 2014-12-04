using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class RegistroCliente : Form
    {
        public bool hacerRollBack = true;
        public ElegirHabitaciones formularioAnterior;

        public RegistroCliente(int idReservaDelCliente, ElegirHabitaciones formulario)
        {
            InitializeComponent();
            this.idReservaDelCliente = idReservaDelCliente;
            formularioAnterior = formulario;
        }

        int idReservaDelCliente;
        private void button1_Click(object sender, EventArgs e)
        {
            FrbaHotel.ABM_de_Cliente.Alta_Cliente formAltaCliente = new FrbaHotel.ABM_de_Cliente.Alta_Cliente(idReservaDelCliente, this);
            formAltaCliente.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrbaHotel.ABM_de_Cliente.ModificacionMain_Cliente formBuscarCliente = new FrbaHotel.ABM_de_Cliente.ModificacionMain_Cliente(idReservaDelCliente, this);
            formBuscarCliente.ShowDialog();
        
        }

        public void Cerrate(bool rollback){
            this.hacerRollBack = rollback;
            this.Close();
            formularioAnterior.Cerrate();
       }

        private void RegistroCliente_FormClosed(object sender, EventArgs e) {
            if (hacerRollBack)
            {
                Conexion.Instance.ejecutarQuery("ROLLBACK");
            }
        }
    }
}
