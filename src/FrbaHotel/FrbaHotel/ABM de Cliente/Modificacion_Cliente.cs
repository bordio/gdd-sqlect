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
        
        public Modificacion_Cliente()
        {
            InitializeComponent();
            appModel_Modificar = new AppModel_Modificacion_Cliente();
        }

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

            if ((Nombre.Text != "") || (Apellido.Text != "") || (Email.Text != "") || (FechaNacimiento.Text != "") || (Nacionalidad.Text != "") || (Pasaporte.Text != ""))
            {
                sentence.Append(" WHERE ");
                this.appModel_Modificar.appendASentencia(Nombre.Text, sentence, "nombre");
                this.appModel_Modificar.appendASentencia(Apellido.Text, sentence, "apellido");
                this.appModel_Modificar.appendASentencia(Email.Text, sentence, "mail");
                //this.appModel_Modificar.appendASentencia(DateTime.Parse(FechaNacimiento.Text), sentence, "fecha_Nac");
                this.appModel_Modificar.appendASentencia(Nacionalidad.Text, sentence, "nacionalidad");
                this.appModel_Modificar.appendASentencia(Pasaporte.Text, sentence, "pasaporte");

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
            Nombre.Text = null;
            Apellido.Text = null;
            Email.Text = null;
            FechaNacimiento.Text = null;
            Nacionalidad.Text = null;
            Pasaporte.Text = null;
        }

        private void gridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*DataGridViewRow a = gridClientes.CurrentRow;
            StringBuilder b = new StringBuilder().AppendFormat("Nombre: {0}, Apellido: {1}, Email: {2}", a.Cells[1].Value.ToString(), a.Cells[2].Value.ToString(), a.Cells[3].Value.ToString());
            */
        }

        private void btFechaNac_Click(object sender, EventArgs e)
        {
            monthCalendar.Visible = true;
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            FechaNacimiento.Clear();
            FechaNacimiento.AppendText(monthCalendar.SelectionStart.ToShortDateString());
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar.Visible = false;
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
           // Alta_Cliente formAlta = new Alta_Cliente(this.gridClientes, this.paisSeleccionado, this.ciudadSeleccionado, this.calleSeleccionado, this.nro_calleSeleccionado);
            //formAlta.Show();
        }
}
}