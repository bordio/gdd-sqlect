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
    
    public partial class Alta_Cliente : Form
    {
        private AppModel_Base_Cliente appModel;
        private DataGridView listaClientes;

        Boolean validaciones = false;
        
        public Alta_Cliente()
        {
            InitializeComponent();
            appModel = new AppModel_Alta_Cliente();
            Text = "Alta de Cliente";
        }

        public Alta_Cliente(int idReserva)
        {
            InitializeComponent();
            appModel = new AppModel_Alta_Cliente();
            Text = "Alta de Cliente";
            this.idReservaDelCliente = idReserva;
        }

        int idReservaDelCliente;

        public Alta_Cliente(DataGridView lsClientes, StringBuilder nombre, StringBuilder apellido, StringBuilder email, StringBuilder fechaNacimiento, StringBuilder dom_Calle, StringBuilder nro_Calle, StringBuilder piso, StringBuilder depto, StringBuilder nacionalidad, StringBuilder pasaporte, StringBuilder habilitado)
        {
            InitializeComponent();
            Text = "Modificacion de Cliente";
            listaClientes = lsClientes;
            appModel = new AppModel_Modificacion_Cliente();
            //this.appModel.levantar(nombre, apellido, email, fechaNacimiento, dom_Calle, nro_Calle, piso, depto, nacionalidad, pasaporte, habilitado);
            
            Nombre.Text = appModel.rowHotel.Rows[0][1].ToString();
            Email.Text = appModel.rowHotel.Rows[0][2].ToString();
        }


        private void btGuardar_Click(object sender, EventArgs e)
        {
            StringBuilder mensajeValidacion = new StringBuilder();
            //Validaciones

            //Campos Obligatorios
            this.appModel.validarNoVacio(Nombre, mensajeValidacion);
            this.appModel.validarNoVacio(Apellido, mensajeValidacion);
            Boolean emailOk = this.appModel.validarNoVacio(Email, mensajeValidacion);
            this.appModel.validarNoVacio(Fecha, mensajeValidacion);
            Boolean pasapOk = this.appModel.validarNoVacio(Pasaporte, mensajeValidacion);
            this.appModel.validarNoVacio(Nacionalidad, mensajeValidacion);
            //Longitudes
            this.appModel.validarLongitud(Nombre, 60, mensajeValidacion);
            this.appModel.validarLongitud(Apellido, 60, mensajeValidacion);
            emailOk = this.appModel.validarLongitud(Email, 255, mensajeValidacion);
            //Campos numericos
            this.appModel.validarNumerico(Numero, mensajeValidacion);
            pasapOk = this.appModel.validarNumerico(Pasaporte, mensajeValidacion);
            //Email repetido
            if (emailOk)
            {
                this.appModel.validarEmail(Email, mensajeValidacion);
            }
            //Pasaporte repetido
            if (pasapOk)
            {
                this.appModel.validarPasaporte(Pasaporte, mensajeValidacion);
            }
            //Ya hechas todas las validaciones. Mostramos el cartel de las mismas en caso de errores:
            if (mensajeValidacion.Length > 0)
            {
                validaciones = false;
                MessageBox.Show(mensajeValidacion.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mensajeValidacion = null;
            }
            else {
                validaciones = true;
            }

            //CONEXION BD
            if (validaciones)
            {
                if (idReservaDelCliente != 0)
                {
                    this.appModel.abmlCliente(
                       this.Nombre.Text, this.Apellido.Text, this.Email.Text,
                       this.Calle.Text, this.Numero.Text, this.Piso.Text, this.Departamento.Text,
                       this.Fecha.Text, this.Nacionalidad.Text, this.Pasaporte.Text, this.idReservaDelCliente); /* Cliente sin reserva*/
                }
                else
                {
                    this.appModel.abmlCliente(
                           this.Nombre.Text, this.Apellido.Text, this.Email.Text,
                           this.Calle.Text, this.Numero.Text, this.Piso.Text, this.Departamento.Text,
                           this.Fecha.Text, this.Nacionalidad.Text, this.Pasaporte.Text, 0); /*Cliente con reserva*/
                }
            
            
            
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
            this.Departamento.Text = null;
            this.PaisOrigen.Text = null;
            this.Nacionalidad.Text = null;
            this.Pasaporte.Text = null;
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
