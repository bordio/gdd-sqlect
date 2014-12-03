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
        public StringBuilder documentoSeleccionado = new StringBuilder();
        public StringBuilder tipodocSeleccionado = new StringBuilder();

        int idReservaDelCliente;

        public ModificacionMain_Cliente()
        {
            InitializeComponent();
            appModel_Modificar = new AppModel_Modificacion_Cliente();
            btHabilitar.Enabled = false;
            btInhabilitar.Enabled = false;
            btModificar.Enabled = false;
            llenarComboDocumentos();
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
            llenarComboDocumentos();

        }
        public void llenarComboDocumentos()
        {
            cbTipoDoc.Items.Add("DNI");
            cbTipoDoc.Items.Add("PASAPORTE");
            
        }
        public void refrescarPantalla() { //Para refrescar la pantalla de Busqueda luego de una Modificacion. Lo llama la Pantalla de Modificaciones, pero la responsabilidad sigue siendo de ModificacionMain_Cliente
            this.btBuscar_Click("Buscar",null);
            gridClientes.Columns[15].Visible = false;
        }

        public void btBuscar_Click(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder();

            string select = "SELECT c.nombre 'Nombre', c.apellido 'Apellido',c.mail 'Email',c.telefono 'Telefono',c.fecha_Nac 'Fecha Nacimiento', c.dom_Calle 'Calle', c.nro_calle 'Nro Calle', c.piso 'Piso',c.depto 'Departamento', c.localidad 'Localidad', p.nombrePais 'Pais', c.nacionalidad 'Nacionalidad', c.tipoDocumento 'Tipo de Documento',c.documento_Nro 'Número de Documento', c.habilitado 'Habilitado', c.fk_paisOrigen FROM SQLECT.Clientes c LEFT JOIN SQLECT.Paises p ON (p.id_pais = c.fk_paisOrigen)";

            sentence = this.appModel_Modificar.getAllInstances(select);

            if ((Nombre.Text != "") || (Apellido.Text != "") || (Email.Text != "") || (Nacionalidad.Text != "") || (Documento.Text != "") || (cbTipoDoc.SelectedItem != null))
            {
                sentence.Append(" WHERE ");
                this.appModel_Modificar.appendASentencia(Nombre.Text, sentence, "nombre");
                this.appModel_Modificar.appendASentencia(Apellido.Text, sentence, "apellido");
                this.appModel_Modificar.appendASentencia(Email.Text, sentence, "mail");
                this.appModel_Modificar.appendASentencia(Nacionalidad.Text, sentence, "nacionalidad");
                this.appModel_Modificar.appendASentencia(Documento.Text, sentence, "documento_Nro");
                this.appModel_Modificar.appendASentencia(cbTipoDoc, sentence, "tipoDocumento");

                StringBuilder sentenceFiltro = new StringBuilder().AppendFormat(sentence.ToString().Substring(0, sentence.Length - 4));
                gridClientes.DataSource = this.appModel_Modificar.cargar_lista(sentenceFiltro).DefaultView;
                gridClientes.Columns[15].Visible = false; //columna del fkPais
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
            Documento.Text = null;
            this.cbTipoDoc.SelectedItem = null;
            btHabilitar.Enabled = false;
            btInhabilitar.Enabled = false;
            btModificar.Enabled = false;
        }

        private void gridClientes_CellContentClick(object sender, EventArgs e)
        {
            DataGridViewRow celda_actual = gridClientes.CurrentRow;
            emailSeleccionado.Remove(0, emailSeleccionado.Length);
            documentoSeleccionado.Remove(0, documentoSeleccionado.Length);
            tipodocSeleccionado.Remove(0, tipodocSeleccionado.Length);

            if (celda_actual != null)
            {
                emailSeleccionado.AppendFormat("{0}", celda_actual.Cells[2].Value.ToString());
                documentoSeleccionado.AppendFormat("{0}", celda_actual.Cells[13].Value.ToString());
                tipodocSeleccionado.AppendFormat("{0}", celda_actual.Cells[12].Value.ToString());
            }
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (btModificar.Text=="Seleccionar") // La reserva utiliza esta view tambien. Cambiando el nombre del boton "Modificar" por "Seleccionar"
            {
                FrbaHotel.Generar_Modificar_Reserva.ConfirmarClienteReserva formConfirmarCliente = new FrbaHotel.Generar_Modificar_Reserva.ConfirmarClienteReserva(emailSeleccionado.ToString(), Convert.ToInt32(documentoSeleccionado.ToString()), idReservaDelCliente);
                formConfirmarCliente.Show();
            }
            else // Se quiere modificar a un cliente de verdad
            {
                BaseAltaModificacion_Cliente form = new Modificacion_Cliente(this,this.gridClientes, this.emailSeleccionado, this.documentoSeleccionado, this.tipodocSeleccionado); //Chequear despues si esta bien solo usar email
                form.Show();
            }
        }

        public void btInhabilitar_Click(object sender, EventArgs e)
        {
            AppModel_Baja_Cliente appModel;
            appModel = new AppModel_Baja_Cliente();
            if(validacionesAlBorrar()){
                appModel.inhabilitarCliente(this.emailSeleccionado, this.documentoSeleccionado, this.tipodocSeleccionado);
                this.refrescarPantalla();
            }
        }

        public void btHabilitar_Click(object sender, EventArgs e)
        {
            AppModel_Baja_Cliente appModel;
            appModel = new AppModel_Baja_Cliente();
            if(validacionesAlBorrar()){
                appModel.habilitarCliente(this.emailSeleccionado, this.documentoSeleccionado, this.tipodocSeleccionado);
                this.refrescarPantalla();
            }
        }

       // public StringBuilder mensajeValidacion = new StringBuilder();

        public Boolean validacionesAlBorrar()
        {
            //Segun enunciado:
            //Si el cliente ya tiene reservas y se lo inhabilita. Al hacer el checkInt no se le dejara ingresar
            //emailSeleccionado
            //documentoSeleccionado
            //No dice que tengamos que validar algo. Estoy chequeandolo.
            return true;

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


}
}