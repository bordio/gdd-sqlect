using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;
using FrbaHotel.Commons.FuncionalidadesVarias;
using FrbaHotel.ABM_de_Usuario;


namespace FrbaHotel.ABM_de_Usuario
{
    public partial class ModificacionUsuario : Form
    {
        public ModificacionUsuario(string username,string nombre, string apellido, string tipoDoc,string numeroDoc, string mail, string telefono, string direccion, string fechaNacimiento,string hotelSeleccionado,string idDeRol)
        {
            InitializeComponent();
            this.usuarioActual = username;
            this.nombreActual = nombre;
            this.apellidoActual = apellido;
            this.tipoDocActual = tipoDoc;
            this.numeroDocActual = numeroDoc;
            this.mailActual = mail;
            this.telefonoActual = telefono;
            this.direccionActual = direccion;
            this.fechaNacActual = fechaNacimiento;
            this.hotelActual = hotelSeleccionado;
            this.idDeRolActual = idDeRol;
         
        }
        private AppModel_Modifiacion_Usuario funciones = new AppModel_Modifiacion_Usuario();
        private AppModel_Alta_Usuario funcionesUsuarios = new AppModel_Alta_Usuario();
        private Funcionalidades funcionesVarias = new Funcionalidades();
        
        string usuarioActual;
        string nombreActual;
        string apellidoActual;
        string tipoDocActual;
        string numeroDocActual;
        string mailActual;
        string telefonoActual;
        string direccionActual;
        string fechaNacActual;
        string hotelActual;
        string idDeRolActual;

        bool validaciones = false;
        bool quitarHotel = false;
        bool quitarRol = false;
        bool agregarRol = false;
        string rolNuevo = null;
        string hotelNuevo = null;


        private void ModificacionUsuario_Load(object sender, EventArgs e)
        {
            


            StringBuilder sentencia = new StringBuilder().AppendFormat("SELECT DISTINCT h.nombre FROM SQLECT.Hoteles h LEFT JOIN SQLECT.Bajas_por_hotel bh ON (h.id_hotel=bh.fk_hotel) WHERE h.nombre<>'{0}' ",hotelActual);
            DataTable tablaHoteles = Conexion.Instance.ejecutarQuery(sentencia.ToString());

            foreach (DataRow dat in tablaHoteles.Rows)
            {

                comboHoteles.Items.Add(dat[0]);
            }

            StringBuilder sentenciaRoles = new StringBuilder().AppendFormat("SELECT DISTINCT r.nombre FROM SQLECT.Roles r LEFT JOIN SQLECT.Roles_Usuarios ru ON (r.id_rol=ru.fk_rol) LEFT JOIN SQLECT.Usuarios u ON (u.id_usuario=ru.fk_usuario) WHERE r.estado_rol=1 AND r.nombre NOT IN ('Guest','{0}') ",idDeRolActual);
            DataTable tablaRoles = Conexion.Instance.ejecutarQuery(sentenciaRoles.ToString());

            foreach (DataRow dat in tablaRoles.Rows)
            {

                comboRol.Items.Add(dat[0]);
            }

            /*bool validaciones = false;
            bool quitarHotel = false;
            bool quitarRol = false;
            bool agregarRol = false;
            string rolNuevo = null;
            string hotelNuevo = null;*/

            comboRol.Enabled = false;
            comboTipoDNI.SelectedItem = null;
            username.Text = usuarioActual;
            nombre.Text = nombreActual;
            apellido.Text = apellidoActual;
            numeroDoc.Text = numeroDocActual;
            mail.Text = mailActual;
            telefono.Text = telefonoActual;
            direccion.Text = direccionActual;
            if (!string.IsNullOrEmpty(fechaNacActual))
            { fechaNacimiento.Text = DateTime.Parse(fechaNacActual).ToShortDateString(); }
            else
                fechaNacimiento.Text = fechaNacActual.ToString();
           
            hotelDondeTrabaja.Text = hotelActual;
            radioMantener.Checked = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            monthCalendar.Visible = true;
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            fechaNacimiento.Clear();
            fechaNacimiento.AppendText(monthCalendar.SelectionStart.ToShortDateString());
            monthCalendar.Visible = false;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            nombre.Text = "";
            apellido.Text = "";
            comboTipoDNI.SelectedItem = null;
            numeroDoc.Text = "";
            mail.Text = "";
            telefono.Text = "";
            direccion.Text = "";
            fechaNacimiento.Text = "";
            hotelDondeTrabaja.Text = null;
            radioMantener.Checked = true;
            radioQuitar.Checked = false;
            comboHoteles.Enabled = false;
            comboHoteles.SelectedIndex=-1;
            radioQuitarRol.Checked = false;
            radioAgregarRol.Checked = false;
            comboRol.Enabled = false;
            comboRol.SelectedItem=null;


            validaciones = false;
            quitarHotel = false;
            quitarRol = false;
            agregarRol = false;
            rolNuevo = null;
            hotelNuevo = null;
            
        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            /*Compruebo campos vacíos*/
            StringBuilder mensajeValidacion = new StringBuilder();
            //Validaciones

            //Campos obligatorios
            bool usuarioOK = this.funcionesUsuarios.validarNoVacio(username, mensajeValidacion);
            this.funcionesUsuarios.validarNoVacio(nombre, mensajeValidacion);
            this.funcionesUsuarios.validarNoVacio(apellido, mensajeValidacion);
            bool tipoDniOK = this.funcionesUsuarios.validarComboVacio(comboTipoDNI, mensajeValidacion);
            bool numeroDniOK = this.funcionesUsuarios.validarNumerico(numeroDoc, mensajeValidacion);
            bool mailOK = this.funcionesUsuarios.validarNoVacio(mail, mensajeValidacion);
            this.funcionesUsuarios.validarNoVacio(telefono, mensajeValidacion);
            this.funcionesUsuarios.validarNoVacio(direccion, mensajeValidacion);
            this.funcionesUsuarios.validarNoVacio(fechaNacimiento, mensajeValidacion);

            //Control de longitudes
            this.funcionesUsuarios.validarLongitud(nombre, 30, mensajeValidacion);
            this.funcionesUsuarios.validarLongitud(apellido, 60, mensajeValidacion);
            this.funcionesUsuarios.validarLongitud(mail, 255, mensajeValidacion);

            //Campos numéricos

            this.funcionesUsuarios.validarNumerico(numeroDoc, mensajeValidacion);
            this.funcionesUsuarios.validarNumerico(telefono, mensajeValidacion);

            //Chequeo de inconsistencias

            if ((tipoDniOK & numeroDniOK))
            {
                if ((tipoDocActual != comboTipoDNI.SelectedItem.ToString()) && (numeroDocActual != numeroDoc.Text)) 

                this.funcionesUsuarios.validarDNI(comboTipoDNI.SelectedItem.ToString(), numeroDoc, mensajeValidacion);
            }

            if (mailOK & (mailActual!=mail.Text))
            {
                this.funcionesUsuarios.validarEmail(mail, mensajeValidacion);
            }
            
            
            if (radioAgregarRol.Checked == true && string.IsNullOrEmpty(rolNuevo) )
            {
                mensajeValidacion.AppendLine("Debe elegir un Rol"); 
            }
            

            if (!tipoDniOK)
                mensajeValidacion.AppendLine("Debe elegir un tipo de Documento");
            

            //Si hay algún error, se muestra el mensaje.
            if (mensajeValidacion.Length > 0)
            {
                validaciones = false;
                MessageBox.Show(mensajeValidacion.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mensajeValidacion = null;

                /*if (comboHoteles.SelectedIndex > -1)
                { hotelNuevo = comboHoteles.SelectedItem.ToString(); }*/
            }
            else
            { validaciones = true; }

            bool usuarioModificado = false;
            
            if (validaciones)
            {
                  if (comboHoteles.SelectedIndex > -1)
                  { hotelNuevo = comboHoteles.SelectedItem.ToString(); }
                  if (quitarRol == false && agregarRol == false)
                  {
                      usuarioModificado = funciones.modificarUsuario(username.Text, nombre.Text, apellido.Text, comboTipoDNI.SelectedItem.ToString(), numeroDoc.Text, mail.Text, telefono.Text, direccion.Text, fechaNacimiento.Text, quitarHotel, hotelNuevo);
                  }
                  else
                      usuarioModificado = funciones.modificarUsuario(username.Text, nombre.Text, apellido.Text, comboTipoDNI.SelectedItem.ToString(), numeroDoc.Text, mail.Text, telefono.Text, direccion.Text, fechaNacimiento.Text, quitarHotel, hotelNuevo, quitarRol, comboRol.SelectedItem.ToString(),idDeRolActual);
                
                /*MessageBox.Show("Todo correcto");*/
            
            }

            if (usuarioModificado)
            {
                MessageBox.Show("Usuario modificado", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
            
        }

        private void radioQuitarRol_CheckedChanged(object sender, EventArgs e)
        {
            
            quitarRol = true;
            agregarRol = false;
            
            /*radioAgregarRol.Checked = false;*/
            comboRol.Enabled = false;
            
        }

        private void radioAgregarRol_CheckedChanged(object sender, EventArgs e)
        {
            agregarRol = true;
            quitarRol = false;
            
            comboRol.Enabled = true;
            /*radioQuitarRol.Checked = false;*/
            if (comboRol.SelectedIndex > -1)
                rolNuevo = comboRol.SelectedItem.ToString();
            else
                rolNuevo = null;


        }

        private void radioQuitar_CheckedChanged(object sender, EventArgs e)
        {
            hotelNuevo = hotelDondeTrabaja.Text;
            /*radioMantener.Checked = false;*/
            comboHoteles.Enabled = false;
            quitarHotel = true;
        }

        private void radioMantener_CheckedChanged(object sender, EventArgs e)
        {
            hotelNuevo = "";
            /*radioQuitar.Checked = false;*/
            comboHoteles.Enabled = true;
            quitarHotel = false;
            
        }

        private void comboHoteles_SelectedValueChanged(object sender, EventArgs e)
        {
            hotelNuevo = null;
            if (comboHoteles.SelectedItem != null)
            {
                hotelNuevo = comboHoteles.SelectedItem.ToString();
            }
                  
        }

        private void comboRol_SelectedValueChanged(object sender, EventArgs e)
        {
            rolNuevo = null;
            if (comboRol.SelectedItem != null)
            {
                rolNuevo = comboRol.SelectedItem.ToString();
            }
            
        }


    }
}
