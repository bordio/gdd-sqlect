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

namespace FrbaHotel.Registrar_Consumible
{
    public partial class FormaDePago : Form
    {
        Facturacion formularioAnterior;
        public FormaDePago(string codigoReserva, Facturacion formulario)
        {
            InitializeComponent();
            this.formularioAnterior = formulario;
            this.codigoReservaActual = codigoReserva;
        }

        string codigoReservaActual;
        AppModel_Facturacion funcionesFacturacion = new AppModel_Facturacion();
        AppModel_Alta_Usuario funcionesValidacion = new AppModel_Alta_Usuario();
        StringBuilder mensaje = new StringBuilder();
        private void FormaDePago_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool formaDePagoOk = funcionesValidacion.validarComboVacio(formaPago, mensaje);
            bool detallesDePagoOk = funcionesValidacion.validarNoVacio(detalles, mensaje);

            if (formaDePagoOk & detallesDePagoOk)
            {
                funcionesFacturacion.registrarFormaDePago(codigoReservaActual, formaPago.SelectedItem.ToString(), detalles.Text);
                FrbaHotel.Registrar_Consumible.Agradecimiento formFinal = new Agradecimiento();
                formFinal.ShowDialog();
                this.Close();
                formularioAnterior.Cerrate();
            }
            else
                if (!formaDePagoOk)
                { mensaje.AppendLine("Debe seleccionar una forma de pago"); }

                MessageBox.Show(mensaje.ToString());
                mensaje.Remove(0, mensaje.Length);
        }
    }
}
