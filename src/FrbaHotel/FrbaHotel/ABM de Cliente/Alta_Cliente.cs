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
        StringBuilder mensajeValidacion = new StringBuilder();
        Boolean validaciones = false;
        
        public Alta_Cliente()
        {
            InitializeComponent();
        }


        private void btGuardar_Click(object sender, EventArgs e)
        {
            //Validaciones

            //Campos Obligatorios
            this.appModel_Alta.validarNoVacio(Nombre, mensajeValidacion);
            this.appModel_Alta.validarNoVacio(Apellido, mensajeValidacion);
            this.appModel_Alta.validarNoVacio(Email, mensajeValidacion);
            this.appModel_Alta.validarNoVacio(dtFechaNac, mensajeValidacion);
            this.appModel_Alta.validarNoVacio(Pasaporte, mensajeValidacion);
            //Longitudes
            this.appModel_Alta.validarLongitud(Nombre, 60, mensajeValidacion);
            this.appModel_Alta.validarLongitud(Apellido, 60, mensajeValidacion);
            this.appModel_Alta.validarLongitud(Email, 255, mensajeValidacion);
            //Campos numericos
            this.appModel_Alta.validarNumerico(Pasaporte, mensajeValidacion);
            //Email repetido
            this.appModel_Alta.validarEmail(Email, mensajeValidacion);
            //Pasaporte repetido
            this.appModel_Alta.validarPasaporte(Pasaporte, mensajeValidacion);

            if(mensajeValidacion != null){
                validaciones = false;
                MessageBox.Show(mensajeValidacion.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mensajeValidacion = null;
            }

            //CONEXION BD
            if (validaciones)
            {
                bool alta = this.appModel_Alta.altaCliente(this.Nombre.Text, this.Apellido.Text, this.Email.Text,
                                this.Calle.Text, this.Numero.Text, this.Piso.Text, this.Departamento.Text,
                                this.dtFechaNac.Value, this.Nacionalidad.Text, this.Pasaporte.Text);

                if (alta)
                {
                    MessageBox.Show("Alta exitosa", "Alta de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

        }

        private void btLimpiar_Click(object sender, EventArgs e) {
            this.Nombre.Text = null;
            this.Apellido.Text = null;
            this.Email.Text = null;
            this.Calle.Text = null;
            this.Numero.Text = null;
            this.Piso.Text = null;
            this.Departamento.Text = null;
            this.Nacionalidad.Text = null;
            this.Pasaporte.Text = null;
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

   
}
