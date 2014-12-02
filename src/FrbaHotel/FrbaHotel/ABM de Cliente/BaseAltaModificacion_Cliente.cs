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
    
    public partial class BaseAltaModificacion_Cliente : Form
    {
        public AppModel_Base_Cliente appModel;
        public ABM_de_Cliente.ModificacionMain_Cliente pantallaAnteriorFiltros;

        public BaseAltaModificacion_Cliente() //Para altas sin reserva. Lo usa clase hija Alta_Cliente
        {
            InitializeComponent();
            appModel = new AppModel_Alta_Cliente();
            Text = "Alta de Cliente";
            llenarComboDocumentos();
        }

        public BaseAltaModificacion_Cliente(int idReserva) //Para altas con reserva. Lo usa clase hija Alta_Cliente
        {
            appModel = new AppModel_Alta_Cliente();
            Text = "Alta de Cliente";
            this.idReservaDelCliente = idReserva;
            llenarComboDocumentos();
        }

        public BaseAltaModificacion_Cliente(ABM_de_Cliente.ModificacionMain_Cliente pantallaFiltros,DataGridView lsClientes, StringBuilder email, StringBuilder documento, StringBuilder tipo) //Para modificaciones. Lo usa clase hija Modificacion_Cliente
        {
            InitializeComponent();
            Text = "Modificacion de Cliente";
            llenarComboDocumentos();
            btGuardar.Text = "Guardar Cambios";
            pantallaAnteriorFiltros = pantallaFiltros;
        }

        public int idReservaDelCliente;

        public Boolean emailOk;
        public Boolean documentoOk;
        public Boolean validaciones = false;
        public StringBuilder mensajeValidacion;

        public void llenarComboDocumentos()
        {
            cbTipoDoc.Items.Add("DNI");
            cbTipoDoc.Items.Add("PASAPORTE");
            cbTipoDoc.SelectedIndex = 0;
        }

        public virtual void validacionesAlGuardar() {
            mensajeValidacion = new StringBuilder();
            //Campos Obligatorios: Que no esten vacios
            this.appModel.validarNoVacio(Nombre, mensajeValidacion);
            this.appModel.validarNoVacio(Apellido, mensajeValidacion);
            emailOk = this.appModel.validarNoVacio(Email, mensajeValidacion);
            this.appModel.validarNoVacio(Fecha, mensajeValidacion);
            documentoOk = this.appModel.validarNoVacio(Documento, mensajeValidacion);
            this.appModel.validarNoVaciocb(cbTipoDoc.SelectedItem.ToString(),mensajeValidacion);
            this.appModel.validarNoVacio(Nacionalidad, mensajeValidacion);
            
            //Longitudes
            this.appModel.validarLongitud(Nombre, 60, mensajeValidacion);
            this.appModel.validarLongitud(Apellido, 60, mensajeValidacion);
            emailOk = this.appModel.validarLongitud(Email, 255, mensajeValidacion);
            
            //Campos numericos
            if (Numero.Text != "") //No es obligatorio este campo
            {
                this.appModel.validarNumerico(Numero, mensajeValidacion);
            }

            if (Piso.Text != "") //No es obligatorio este campo
            {
                this.appModel.validarNumerico(Piso, mensajeValidacion);
            }
            documentoOk = this.appModel.validarNumerico(Documento, mensajeValidacion);

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
                if (idReservaDelCliente != 0)
                {
                    this.appModel.abmlCliente(
                       this.Nombre.Text, this.Apellido.Text, this.Email.Text,
                       this.Calle.Text, this.Numero.Text, this.Piso.Text, this.Depto.Text,
                       this.Fecha.Text, this.Nacionalidad.Text, this.Documento.Text, 
                       this.idReservaDelCliente,this.cbTipoDoc.SelectedItem.ToString(), this.Telefono.Text, this.Localidad.Text); /* Cliente CON reserva*/
                }
                else
                {
                    this.appModel.abmlCliente(
                           this.Nombre.Text, this.Apellido.Text, this.Email.Text,this.Calle.Text, 
                           this.Numero.Text, this.Piso.Text, this.Depto.Text,
                           this.Fecha.Text, this.Nacionalidad.Text, this.Documento.Text, 0, 
                           this.cbTipoDoc.SelectedItem.ToString(), this.Telefono.Text, this.Localidad.Text); /*Cliente SIN reserva*/
                }
                this.pantallaAnteriorFiltros.refrescarPantalla();
            
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
            this.Localidad.Text = null;
            this.PaisOrigen.Text = null;
            this.Nacionalidad.Text = null;
            this.Documento.Text = null;
            this.cbTipoDoc.SelectedItem = null;
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
