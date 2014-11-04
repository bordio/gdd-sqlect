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
        private AppModel_Alta_Cliente appModel_Alta = new AppModel_Alta_Cliente();
        
        Boolean validaciones = false;
        
        public Alta_Cliente()
        {
            InitializeComponent();
        }


        private void btGuardar_Click(object sender, EventArgs e)
        {
            StringBuilder mensajeValidacion = new StringBuilder();
            //Validaciones

            //Campos Obligatorios
            this.appModel_Alta.validarNoVacio(Nombre, mensajeValidacion);
            this.appModel_Alta.validarNoVacio(Apellido, mensajeValidacion);
            Boolean emailOk = this.appModel_Alta.validarNoVacio(Email, mensajeValidacion);
            this.appModel_Alta.validarNoVacio(Fecha, mensajeValidacion);
            Boolean pasapOk = this.appModel_Alta.validarNoVacio(Pasaporte, mensajeValidacion);
            this.appModel_Alta.validarNoVacio(Nacionalidad, mensajeValidacion);
            //Longitudes
            this.appModel_Alta.validarLongitud(Nombre, 60, mensajeValidacion);
            this.appModel_Alta.validarLongitud(Apellido, 60, mensajeValidacion);
            emailOk = this.appModel_Alta.validarLongitud(Email, 255, mensajeValidacion);
            //Campos numericos
            this.appModel_Alta.validarNumerico(Numero, mensajeValidacion);
            pasapOk = this.appModel_Alta.validarNumerico(Pasaporte, mensajeValidacion);
            //Email repetido
            if (emailOk)
            {
                this.appModel_Alta.validarEmail(Email, mensajeValidacion);
            }
            //Pasaporte repetido
            if (pasapOk)
            {
                this.appModel_Alta.validarPasaporte(Pasaporte, mensajeValidacion);
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
                bool alta = this.appModel_Alta.altaCliente(this.Nombre.Text, this.Apellido.Text, this.Email.Text,
                                this.Calle.Text, this.Numero.Text, this.Piso.Text, this.Departamento.Text,
                                this.Fecha.Text, this.Nacionalidad.Text, this.Pasaporte.Text);

                if (alta)
                {
                    MessageBox.Show("Alta exitosa", "Alta de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else {
                    MessageBox.Show("Alta desastrosa", "Alta de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            Fecha.Clear();
            Fecha.AppendText(monthCalendar.SelectionStart.ToShortDateString());
            //monthCalendar.Visible = false;
        }

        private void btFechaNac_Click(object sender, EventArgs e)
        {
            monthCalendar.Visible = true;
        }

    }

   
}
