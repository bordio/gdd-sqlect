using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class Facturacion : Form
    {
        Form1 formularioAnterior;
        public Facturacion(string codigoReserva, int idHotel, Form1 formulario)
        {
            InitializeComponent();
            this.formularioAnterior = formulario;
            this.codigoReservaActual = codigoReserva;
            this.idHotelEnCuestion = idHotel;
        }

        int idHotelEnCuestion;
        string codigoReservaActual;
        AppModel_Facturacion funcionesFacturacion = new AppModel_Facturacion();

        private void Facturacion_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            fecha.Text = fechaActual.ToShortDateString();
            hora.Text = fechaActual.ToShortTimeString();

            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT nombre,calle+' '+CAST(nro_calle as varchar),cant_estrellas,mail FROM SQLECT.Hoteles WHERE id_hotel={0}",idHotelEnCuestion);
            DataTable datosHotel = Conexion.Instance.ejecutarQuery(sentence.ToString());

            foreach (DataRow filaHotel in datosHotel.Rows) 
            {
                nombreHotel.Text = filaHotel[0].ToString();
                domicilioHotel.Text = filaHotel[1].ToString();
                estrellasHotel.Text = filaHotel[2].ToString();
                contactoHotel.Text = filaHotel[3].ToString();
            }

            StringBuilder sentencia = new StringBuilder().AppendFormat("SELECT nombre+' '+apellido,dom_Calle+' '+CAST(nro_Calle as varchar),documento_Nro,mail FROM SQLECT.Reservas r JOIN SQLECT.Clientes c ON (r.fk_cliente = c.id_cliente) WHERE codigo_reserva='{0}'", codigoReservaActual);
            DataTable datosCliente = Conexion.Instance.ejecutarQuery(sentencia.ToString());

            foreach (DataRow filaCliente in datosCliente.Rows)
            {
                nombreYapellidoCliente.Text = filaCliente[0].ToString();
                domicilioCliente.Text = filaCliente[1].ToString();
                documentoCliente.Text = filaCliente[2].ToString();
                contactoCliente.Text = filaCliente[3].ToString();
            
            }
            
            /*funcionesFacturacion.generarFactura(codigoReservaActual, idHotelEnCuestion);*/

            DataTable detallesFactura = funcionesFacturacion.obtenerDetallesFactura(codigoReservaActual);
            tablaFactura.DataSource = detallesFactura.DefaultView;

            numeroFactura.Text = funcionesFacturacion.obtenerNumeroFactura(codigoReservaActual).ToString();
            totalFactura.Text = funcionesFacturacion.obtenerMontoTotalFactura(codigoReservaActual).ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrbaHotel.Registrar_Consumible.FormaDePago formRegistrarFormaDePago = new FormaDePago(codigoReservaActual, this);
            formRegistrarFormaDePago.ShowDialog();
        }

        public void Cerrate() {
            this.Close();
            formularioAnterior.Cerrate(false);
        }

       
    }
}
