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
    public partial class ConfirmarClienteReserva : Form
    {
        public ConfirmarClienteReserva(string email, int pasaporte,int idReserva)
        {
            InitializeComponent();
            this.emailDelClienteDeLaReserva = email;
            this.pasaporteDelClienteDeLaReserva = pasaporte;
            this.idReserva = idReserva;
        }

        AppModel_Reservas funcionesReservas = new AppModel_Reservas();
        string emailDelClienteDeLaReserva;
        int pasaporteDelClienteDeLaReserva;
        int idReserva;
        private void ConfirmarClienteReserva_Load(object sender, EventArgs e)
        {
            Mail.Text = emailDelClienteDeLaReserva;
            Pasaporte.Text = pasaporteDelClienteDeLaReserva.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Mail.Text) | Convert.ToInt32(Pasaporte.Text) == 0)
                MessageBox.Show("Error en la elección del cliente");
            else
            {
                bool todoOk = funcionesReservas.adjudicarClienteALaReserva(emailDelClienteDeLaReserva, pasaporteDelClienteDeLaReserva, idReserva);
                if (todoOk)
                {
                    MessageBox.Show(string.Format("Registro correcto del cliente a la reserva, guarde el siguiente codigo para posibles modificaciones: {0}",funcionesReservas.obtenerCodigoReserva(idReserva)));
                }
            }
        }
    }
}
