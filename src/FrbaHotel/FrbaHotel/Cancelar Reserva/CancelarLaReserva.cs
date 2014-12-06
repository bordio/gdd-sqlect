using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.ABM_de_Usuario;
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.Cancelar_Reserva
{
    public partial class CancelarLaReserva : Form
    {
        public CancelarLaReserva(string usuarioDeSesion, string nombreRol,string codigoReserva)
        {
            InitializeComponent();
            this.usuarioDeSesionActual = usuarioDeSesion;
            this.nombreRolActual = nombreRol;
            this.codigoReservaActual = codigoReserva;
        }

        string usuarioDeSesionActual;
        string nombreRolActual;
        string codigoReservaActual;
        StringBuilder mensaje = new StringBuilder();
        AppModel_Alta_Usuario funcionesVarias = new AppModel_Alta_Usuario();
        AppModel_Reservas funcionesReservas = new AppModel_Reservas();
        

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            if (funcionesVarias.validarNoVacio(motivo, mensaje))
            {
                bool reservaCancelada = funcionesReservas.cancelarReserva(codigoReservaActual, usuarioDeSesionActual, nombreRolActual, motivo.Text);

                if (reservaCancelada)
                {
                    MessageBox.Show("Reserva cancelada", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                }
            
            }
            else
                MessageBox.Show(mensaje.ToString());

        }

        private void CancelarLaReserva_Load(object sender, EventArgs e)
        {

        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
