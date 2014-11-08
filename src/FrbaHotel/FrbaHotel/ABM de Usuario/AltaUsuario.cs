using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;
using FrbaHotel.Login;
using FrbaHotel.Commons.FuncionalidadesVarias;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class AltaUsuario : Form
    {
        public AltaUsuario()
        {
            InitializeComponent();
        }
        private Funcionalidades funciones = new Funcionalidades();
        private AppModel_Alta_Usuario funcionesUsuarios = new AppModel_Alta_Usuario();
        bool validaciones = false;

        private void AltaUsuario_Load(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT DISTINCT r.nombre FROM SQLECT.Roles r WHERE r.estado_rol=1 AND r.nombre<>'Administrador General'");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString()); 

            foreach (DataRow dat in tabla.Rows)
            {

                comboRol.Items.Add(dat[0]);
            }

       
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username.Text = "";
            password.Text = "";
            nombre.Text = "";
            apellido.Text="";
            comboTipoDNI.SelectedItem = null;
            numeroDoc.Text="";
            mail.Text = "";
            telefono.Text = "";
            direccion.Text = "";
            fechaNacimiento.Text = "";
            hotelDondeTrabaja.Text = "";
            comboRol.SelectedItem = null;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder mensajeValidacion = new StringBuilder();
            //Validaciones

            //Campos obligatorios
            bool usuarioOK = this.funcionesUsuarios.validarNoVacio(username, mensajeValidacion);
            this.funcionesUsuarios.validarNoVacio(password, mensajeValidacion);
            this.funcionesUsuarios.validarComboVacio(comboRol, mensajeValidacion);
            this.funcionesUsuarios.validarNoVacio(nombre, mensajeValidacion);
            this.funcionesUsuarios.validarNoVacio(apellido, mensajeValidacion);
            bool tipoDniOK = this.funcionesUsuarios.validarComboVacio(comboTipoDNI, mensajeValidacion);
            bool numeroDniOK = this.funcionesUsuarios.validarNumerico(numeroDoc, mensajeValidacion);
            bool mailOK = this.funcionesUsuarios.validarNoVacio(mail, mensajeValidacion);
            this.funcionesUsuarios.validarNoVacio(telefono, mensajeValidacion);
            this.funcionesUsuarios.validarNoVacio(direccion, mensajeValidacion);
            this.funcionesUsuarios.validarNoVacio(fechaNacimiento, mensajeValidacion);
            this.funcionesUsuarios.validarNoVacio(hotelDondeTrabaja, mensajeValidacion);
            bool usuarioConRolExistente = funciones.chequearExistenciaDeUsuarioYRol(username.Text,comboRol.SelectedItem.ToString());

            //Control de longitudes
            this.funcionesUsuarios.validarLongitud(nombre, 30, mensajeValidacion);
            this.funcionesUsuarios.validarLongitud(apellido, 60, mensajeValidacion);
            this.funcionesUsuarios.validarLongitud(mail, 255, mensajeValidacion);

            //Campos numéricos

            this.funcionesUsuarios.validarNumerico(numeroDoc, mensajeValidacion);
            this.funcionesUsuarios.validarNumerico(telefono, mensajeValidacion);
             
            //Chequeo de inconsistencias
            if (usuarioOK)
            {
                this.funcionesUsuarios.validarUsuario(username, mensajeValidacion);
            
            }


            if (tipoDniOK && numeroDniOK)
            {
                this.funcionesUsuarios.validarDNI(comboTipoDNI.SelectedItem.ToString(), numeroDoc, mensajeValidacion);
            }

            if (mailOK)
            {
                this.funcionesUsuarios.validarEmail(mail, mensajeValidacion); 
            }
            if (usuarioConRolExistente)
            {
                mensajeValidacion.AppendLine(string.Format(" Ya existe el usuario {0} con el rol de {1}",username.Text,comboRol.SelectedItem.ToString()));
            }

        //Si hay algún error, se muestra el mensaje.
            if (mensajeValidacion.Length > 0)
            {
                validaciones = false;
                MessageBox.Show(mensajeValidacion.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mensajeValidacion = null;

            }
            else
            {validaciones = true;}

             if (validaciones)
            {
                bool alta = funcionesUsuarios.altaUsuario(username.Text, password.Text, comboRol.SelectedItem.ToString(), nombre.Text, apellido.Text, comboTipoDNI.SelectedItem.ToString(),
                                                          Convert.ToInt32(numeroDoc.Text),mail.Text,Convert.ToInt32(telefono.Text),direccion.Text,fechaNacimiento.Text,hotelDondeTrabaja.Text);

                if (alta)
                {
                    MessageBox.Show("Alta exitosa", "Alta de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else {
                    MessageBox.Show("Alta defectuosa", "Alta de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            monthCalendar.Visible=true;
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            fechaNacimiento.Clear();
            fechaNacimiento.AppendText(monthCalendar.SelectionStart.ToShortDateString());
            monthCalendar.Visible = false;

        }

        
        }



    }

