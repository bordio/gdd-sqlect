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
    public partial class ModificacionMain_Cliente : Form
    {
        private AppModel_Modificacion_Cliente appModel_Modificar;

        public StringBuilder emailSeleccionado = new StringBuilder();
        public StringBuilder pasaporteSeleccionado = new StringBuilder();

        int idReservaDelCliente;

        public ModificacionMain_Cliente()
        {
            InitializeComponent();
            appModel_Modificar = new AppModel_Modificacion_Cliente();
            btHabilitar.Enabled = false;
            btInhabilitar.Enabled = false;
            btModificar.Enabled = false;

        }

        public ModificacionMain_Cliente(int idReserva)
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

                StringBuilder sentenceFiltro = new StringBuilder().AppendFormat(sentence.ToString().Substring(0, sentence.Length - 5)); //Si se agrega una nueva condicion al WHERE. Se debe cambiar el 5 a 6 y así.. Horrible, A cambiar si queda tiempo.
                gridClientes.DataSource = this.appModel_Modificar.cargar_lista(sentenceFiltro).DefaultView;
                //gridClientes.
                gridClientes.AllowUserToAddRows = false;

                btHabilitar.Enabled = true;
                btInhabilitar.Enabled = true;
                btModificar.Enabled = true;
            
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

            btHabilitar.Enabled = false;
            btInhabilitar.Enabled = false;
            btModificar.Enabled = false;
        }

        private void gridClientes_CellContentClick(object sender, EventArgs e)
        {
            DataGridViewRow celda_actual = gridClientes.CurrentRow;
            emailSeleccionado.Remove(0, emailSeleccionado.Length);
            pasaporteSeleccionado.Remove(0, pasaporteSeleccionado.Length);

            emailSeleccionado.AppendFormat("{0}", celda_actual.Cells[2].Value.ToString());
            pasaporteSeleccionado.AppendFormat("{0}", celda_actual.Cells[9].Value.ToString());
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (btModificar.Text=="Seleccionar") // Viene de reservas. Analizar. No entiendo por que la responsabilidad esta aca
            {
                FrbaHotel.Generar_Modificar_Reserva.ConfirmarClienteReserva formConfirmarCliente = new FrbaHotel.Generar_Modificar_Reserva.ConfirmarClienteReserva(emailSeleccionado.ToString(), Convert.ToInt32(pasaporteSeleccionado.ToString()), idReservaDelCliente);
                formConfirmarCliente.Show();
            }
            else // Se quiere modificar a un cliente de verdad
            {
                BaseAltaModificacion_Cliente formAlta = new Modificacion_Cliente(this.gridClientes, this.emailSeleccionado,this.pasaporteSeleccionado); //Chequear despues si esta bien solo usar email
                formAlta.Show();
            }
        }

        public void btInhabilitar_Click(object sender, EventArgs e)
        {
            AppModel_Baja_Cliente appModel;
            appModel = new AppModel_Baja_Cliente();
            if(validacionesAlBorrar()){
                appModel.inhabilitarCliente(this.emailSeleccionado, this.pasaporteSeleccionado);
            }
        }

        public void btHabilitar_Click(object sender, EventArgs e)
        {
            AppModel_Baja_Cliente appModel;
            appModel = new AppModel_Baja_Cliente();
            if(validacionesAlBorrar()){
                appModel.habilitarCliente(this.emailSeleccionado, this.pasaporteSeleccionado);
            }
        }

       // public StringBuilder mensajeValidacion = new StringBuilder();

        public Boolean validacionesAlBorrar()
        {
            //Segun enunciado:
            //Si el cliente ya tiene reservas y se lo inhabilita. Al hacer el checkInt no se le dejara ingresar
            //emailSeleccionado
            //pasaporteSeleccionado
            //No dice que tengamos que validar algo. Estoy chequeandolo.
            return true;

        }
}
}