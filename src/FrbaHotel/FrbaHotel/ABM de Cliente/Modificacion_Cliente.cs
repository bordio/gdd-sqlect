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
    public partial class Modificacion_Cliente : Form
    {
        private AppModel_Modificacion_Cliente appModel_Modificar;

        private StringBuilder nombreSeleccionado = new StringBuilder();
        private StringBuilder apellidoSeleccionado = new StringBuilder();
        private StringBuilder emailSeleccionado = new StringBuilder();
        private StringBuilder fechaNacimientoSeleccionado = new StringBuilder();
        private StringBuilder dom_CalleSeleccionado = new StringBuilder();
        private StringBuilder nro_CalleSeleccionado = new StringBuilder();
        private StringBuilder pisoSeleccionado = new StringBuilder();
        private StringBuilder deptoSeleccionado = new StringBuilder();
        private StringBuilder nacionalidadSeleccionado = new StringBuilder();
        private StringBuilder pasaporteSeleccionado = new StringBuilder();
        private StringBuilder habilitadoSeleccionado = new StringBuilder();
        
        public Modificacion_Cliente()
        {
            InitializeComponent();
            appModel_Modificar = new AppModel_Modificacion_Cliente();
        }

        public Modificacion_Cliente(int idReserva)
        {
            InitializeComponent();
            appModel_Modificar = new AppModel_Modificacion_Cliente();
            this.idReservaDelCliente = idReserva;
            
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.labelNacionalidad.Visible = false;
            this.Nombre.Visible = false;
            this.Apellido.Visible = false;
            this.Nacionalidad.Visible = false;
            this.btModificar.Text = "Seleccionar";
            this.btModificar.Visible = true;
        }
        string emailDeLaReservaDelCliente;
        int pasaporteDeLaReservaDelCliente;
        int idReservaDelCliente;
        private void Modificacion_Cliente_Load(object sender, EventArgs e)
        {
            /*string seleccion = "SELECT nombre 'Nombre', apellido 'Apellido', mail 'Email', fecha_Nac 'Fecha Nacimiento', dom_Calle 'Calle', nro_calle 'Nro Calle', piso 'Piso', depto 'Departamento', nacionalidad 'Nacionalidad', pasaporte_Nro 'Pasaporte', habilitado 'Habilitado' FROM SQLECT.Clientes";
            gridClientes.DataSource = this.appModel_Modificar.cargar_lista(this.appModel_Modificar.getAllInstances(seleccion)).DefaultView;
            gridClientes.AllowUserToAddRows = false;*/
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder();
            string select = "SELECT nombre 'Nombre', apellido 'Apellido', mail 'Email', fecha_Nac 'Fecha Nacimiento', dom_Calle 'Calle', nro_calle 'Nro Calle', piso 'Piso', depto 'Departamento', nacionalidad 'Nacionalidad', pasaporte_Nro 'Pasaporte', habilitado 'Habilitado' FROM SQLECT.Clientes";
            sentence = this.appModel_Modificar.getAllInstances(select);

            if ((Nombre.Text != "") || (Apellido.Text != "") || (Email.Text != "") || (Nacionalidad.Text != "") || (Pasaporte.Text != ""))
            {
                sentence.Append(" WHERE ");
                this.appModel_Modificar.appendASentencia(Nombre.Text, sentence, "nombre");
                this.appModel_Modificar.appendASentencia(Apellido.Text, sentence, "apellido");
                this.appModel_Modificar.appendASentencia(Email.Text, sentence, "mail");
                this.appModel_Modificar.appendASentencia(Nacionalidad.Text, sentence, "nacionalidad");
                this.appModel_Modificar.appendASentencia(Pasaporte.Text, sentence, "pasaporte_Nro");

                StringBuilder sentenceFiltro = new StringBuilder().AppendFormat(sentence.ToString().Substring(0, sentence.Length - 5));
                gridClientes.DataSource = this.appModel_Modificar.cargar_lista(sentenceFiltro).DefaultView;
                gridClientes.AllowUserToAddRows = false;
            
            }

            else
            {
                gridClientes.DataSource = this.appModel_Modificar.cargar_lista(sentence).DefaultView;
                gridClientes.AllowUserToAddRows = false;
            }

        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            gridClientes.DataSource = null;
            Nombre.Text = null;
            Apellido.Text = null;
            Email.Text = null;
            Nacionalidad.Text = null;
            Pasaporte.Text = null;
        }

        private void gridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            emailDeLaReservaDelCliente = gridClientes.CurrentRow.Cells[2].Value.ToString();
            pasaporteDeLaReservaDelCliente = Convert.ToInt32(gridClientes.CurrentRow.Cells[9].Value.ToString());

            /*DataGridViewRow a = gridClientes.CurrentRow;
            StringBuilder b = new StringBuilder().AppendFormat("Nombre: {0}, Apellido: {1}, Email: {2}", a.Cells[1].Value.ToString(), a.Cells[2].Value.ToString(), a.Cells[3].Value.ToString());
            */
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (btModificar.Text=="Seleccionar")
            {
                FrbaHotel.Generar_Modificar_Reserva.ConfirmarClienteReserva formConfirmarCliente = new FrbaHotel.Generar_Modificar_Reserva.ConfirmarClienteReserva(emailDeLaReservaDelCliente, pasaporteDeLaReservaDelCliente, idReservaDelCliente);
                formConfirmarCliente.Show();
            }
            else
            {
            Alta_Cliente formAlta = new Alta_Cliente(this.gridClientes, this.nombreSeleccionado,this.apellidoSeleccionado, this.emailSeleccionado, this.fechaNacimientoSeleccionado, this.dom_CalleSeleccionado, this.nro_CalleSeleccionado, this.pisoSeleccionado, this.deptoSeleccionado, this.nacionalidadSeleccionado, this.pasaporteSeleccionado, this.habilitadoSeleccionado);
            formAlta.Show();}
        }
}
}