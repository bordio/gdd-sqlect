using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.ABM_de_Cliente
{
    
    public partial class BaseAltaModificacion_Cliente : Form
    {
        public Boolean emailOk, documentoOk, nombreOk, apellidoOk;
        public Boolean validaciones = false;
        public int idReservaDelCliente;
        public StringBuilder mensajeValidacion;
        public AppModel_Base_Cliente appModel;
        public ABM_de_Cliente.ModificacionMain_Cliente pantallaAnteriorFiltros = null;
        

        public BaseAltaModificacion_Cliente() //Para altas sin reserva. Lo usa clase hija Alta_Cliente
        {
            InitializeComponent();
            appModel = new AppModel_Alta_Cliente();
            Text = "Alta de Cliente";
            llenarComboDocumentos();
            appModel.cargarPaises(PaisOrigen);
            this.idReservaDelCliente = 0;
        }

        public BaseAltaModificacion_Cliente(int cantHuespedes, ModificacionMain_Cliente modificacionMain, AppModel_Base_Cliente appmodelHuesped) //Alta desde checkIn
        {
            InitializeComponent();
            appModel = appmodelHuesped;
            Text = "Alta de Cliente";
            llenarComboDocumentos();
            appModel.cargarPaises(PaisOrigen);
            this.idReservaDelCliente = 0;
        }

        public BaseAltaModificacion_Cliente(int idReserva, RegistroCliente formulario) //Para altas con reserva. Lo usa clase hija Alta_Cliente
        {
            InitializeComponent();
            this.idReservaDelCliente = idReserva;
            appModel = new appModel_AltaOConfirmacion_ClienteReserva(idReservaDelCliente, formulario);
            Text = "Alta de Cliente";
            llenarComboDocumentos();
            appModel.cargarPaises(PaisOrigen);
        }

        public BaseAltaModificacion_Cliente(ABM_de_Cliente.ModificacionMain_Cliente pantallaFiltros,DataGridView lsClientes, StringBuilder email, StringBuilder documento, StringBuilder tipo) //Para modificaciones. Lo usa clase hija Modificacion_Cliente
        {
            InitializeComponent();
            Text = "Modificacion de Cliente";
            llenarComboDocumentos();
            btGuardar.Text = "Guardar Cambios";
            pantallaAnteriorFiltros = pantallaFiltros;
            this.idReservaDelCliente = 0;
        }

        public void llenarComboDocumentos()
        {
            cbTipoDoc.Items.Add("DNI");
            cbTipoDoc.Items.Add("PASAPORTE");
            cbTipoDoc.SelectedIndex = 0;
        }

        public virtual void validacionesAlGuardar() {
            mensajeValidacion = new StringBuilder();
            //Campos Obligatorios: Que no esten vacios
            nombreOk = this.appModel.validarNoVacio(Nombre, mensajeValidacion);
            apellidoOk = this.appModel.validarNoVacio(Apellido, mensajeValidacion);
            emailOk = this.appModel.validarNoVacio(Email, mensajeValidacion);
            this.appModel.validarNoVacio(Fecha, mensajeValidacion);
            documentoOk = this.appModel.validarNoVacio(Documento, mensajeValidacion);
            this.appModel.validarNoVacio(Nacionalidad, mensajeValidacion);
            
            //Longitudes
           if(nombreOk) nombreOk = this.appModel.validarLongitud(Nombre, 60, mensajeValidacion);
           if(apellidoOk) apellidoOk = this.appModel.validarLongitud(Apellido, 60, mensajeValidacion);
            this.appModel.validarLongitud(Telefono, 40, mensajeValidacion);
            if(emailOk) emailOk = this.appModel.validarLongitud(Email, 255, mensajeValidacion);
            
            //Campos numericos
            if (Numero.Text != "") //No es obligatorio este campo
            {
                this.appModel.validarNumeroNegativo(Numero, mensajeValidacion);
            }

            if (Piso.Text != "") //No es obligatorio este campo
            {
                this.appModel.validarNumeroNegativo(Piso, mensajeValidacion);
            }

            if (Telefono.Text != "") //No es obligatorio este campo
            {
                this.appModel.validarNumeroNegativo(Telefono, mensajeValidacion);
            }
            if (documentoOk) { documentoOk = this.appModel.validarNumerico(Documento, mensajeValidacion); }

            //No numericos
            this.appModel.validarNoNumerico(Localidad, mensajeValidacion);

            //Email repetido
            if (emailOk)
            {
                this.appModel.validarEmail(Email, mensajeValidacion);
            }
            //documento repetido
            if (documentoOk)
            {
                this.appModel.validarDocumento(Documento, cbTipoDoc.SelectedItem.ToString(), mensajeValidacion);
            }

        }
        public virtual void btGuardar_Click(object sender, EventArgs e)
        {
            //Ya hechas todas las validaciones. Mostramos el cartel de las mismas en caso de errores:
            if (mensajeValidacion.Length > 0)
            {
                validaciones = false;
                MessageBox.Show(mensajeValidacion.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mensajeValidacion = null;
            }
            else
            {
                validaciones = true;
            }

            //CONEXION BD
            if (validaciones)
            {
               this.appModel.abmlCliente(
                       this.Nombre.Text, this.Apellido.Text, this.Email.Text,
                       this.Calle.Text, this.Numero.Text, this.Piso.Text, this.Depto.Text,
                       this.Fecha.Text, this.Nacionalidad.Text, this.Documento.Text,
                       this.idReservaDelCliente, this.cbTipoDoc.SelectedItem.ToString(), 
                       this.Telefono.Text, this.Localidad.Text, this.PaisOrigen);
                
                this.appModel.refrescarPantalla(pantallaAnteriorFiltros);
                this.Close();
            }
        }


        private void btLimpiar_Click(object sender, EventArgs e) {
            this.Nombre.Text = null;
            this.Apellido.Text = null;
            this.Fecha.Text = null;
            this.Email.Text = null;
            this.Calle.Text = null;
            this.Numero.Text = null;
            this.Piso.Text = null;
            this.Telefono.Text = null;
            this.Localidad.Text = null;
            this.Nacionalidad.Text = null;
            this.Documento.Text = null;
            this.Depto.Text = null;
            this.cbTipoDoc.SelectedIndex = 0;
            this.PaisOrigen.SelectedItem = null;
            mensajeValidacion = null;
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar.Visible = false;
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            Fecha.Clear();
            Fecha.AppendText(monthCalendar.SelectionStart.ToShortDateString());
        }

        private void btFechaNac_Click(object sender, EventArgs e)
        {
            monthCalendar.Visible = true;
        }

    }

   
}
