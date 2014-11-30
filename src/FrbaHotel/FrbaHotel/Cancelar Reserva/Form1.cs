using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Generar_Modificar_Reserva;
using FrbaHotel.ABM_de_Usuario;

namespace FrbaHotel.Cancelar_Reserva
{
    public partial class Form1 : Form
    {
        public Form1(int idHotel, string nombreUusario, string nombreRol, bool esCancelar)
        {
            InitializeComponent();
            this.idHotelEnCuestion = idHotel;
            this.usuarioActual = nombreUusario;
            this.nombreRolActual = nombreRol;
            this.esCancelarReserva = esCancelar;
        }
        
        public Form1(int idHotel, string nombreUusario,bool esCancelar)
        {
            InitializeComponent();
            this.Text = "Modificación de reserva";
            this.idHotelEnCuestion = idHotel;
            this.usuarioActual = nombreUusario;
            this.esCancelarReserva = esCancelar;
        }

        bool esCancelarReserva;
        int idHotelEnCuestion;
        string usuarioActual;
        string nombreRolActual;
        
        AppModel_Reservas funcionesReservas = new AppModel_Reservas();
        AppModel_Alta_Usuario funcionesVarias = new AppModel_Alta_Usuario();
        StringBuilder mensaje = new StringBuilder();
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (funcionesVarias.validarNoVacio(NumeroReserva, mensaje) & funcionesVarias.validarLongitud(NumeroReserva, 8, mensaje))
            {

                bool existeCodigo = funcionesReservas.verificarCodigoReservaRepetido(NumeroReserva.Text);
                bool noSeEfectivizo = funcionesReservas.chequearHabilitacionDeCancelacion(NumeroReserva.Text);

                if (existeCodigo & noSeEfectivizo)
                {
                    if (funcionesReservas.correspondeReservaAlHotel(NumeroReserva.Text, idHotelEnCuestion))
                    {
                        if (esCancelarReserva)
                        {
                            FrbaHotel.Cancelar_Reserva.CancelarLaReserva formCancelarReserva = new FrbaHotel.Cancelar_Reserva.CancelarLaReserva(usuarioActual, nombreRolActual, NumeroReserva.Text);
                            formCancelarReserva.Show();
                        }
                        else
                        {
                            FrbaHotel.Generar_Modificar_Reserva.ModificarReserva formModificarReserva = new FrbaHotel.Generar_Modificar_Reserva.ModificarReserva(usuarioActual,NumeroReserva.Text,idHotelEnCuestion);
                            formModificarReserva.Show();
                        }
                    }

                    else
                    {
                        MessageBox.Show("No tiene acceso a cancelar/modificar reservas de otros hoteles");
                        this.Close();
                    }

                }
                else
                {
                    if (!existeCodigo)
                        MessageBox.Show("Numero de reserva inválido");
                    else
                    {
                        if (esCancelarReserva)
                             MessageBox.Show("No puede cancelar la reserva, ya que esta se encuentra cancelada,finalizada o falta menos de un día para su ingreso");
                        this.Close();
                            
                       
                    }
                }
            }
            else
            { MessageBox.Show(mensaje.ToString()); }
            mensaje.Remove(0, mensaje.Length);
        }
    }
}
