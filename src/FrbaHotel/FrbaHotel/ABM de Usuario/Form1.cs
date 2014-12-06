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
    
    
    public partial class Form1 : Form
    {
      public Form1()
        {
            InitializeComponent();
        }

        private StringBuilder usuarioSeleccionado = new StringBuilder();
        private AppModel_Alta_Usuario funcionesUsuarios = new AppModel_Alta_Usuario();
        private StringBuilder estadoDelUsuario = new StringBuilder();
        private StringBuilder hotelSeleccionado = new StringBuilder();
        private StringBuilder nombre = new StringBuilder();
        private StringBuilder apellido = new StringBuilder();
        private StringBuilder mailSeleccionado = new StringBuilder();
        private StringBuilder tipoDoc = new StringBuilder();
        private StringBuilder numeroDoc = new StringBuilder();
        private StringBuilder telefono = new StringBuilder();
        private StringBuilder direccion = new StringBuilder();
        private StringBuilder fechaNacimiento = new StringBuilder();
        private StringBuilder rolSeleccionado = new StringBuilder();



        
    private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT DISTINCT nombre FROM SQLECT.Roles WHERE nombre<>'Guest'");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            foreach (DataRow dat in tabla.Rows)
            {

                comboRol.Items.Add(dat[0]);
            }



        }
        public static StringBuilder getAllInstances()
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT u.usr_name 'Usuario', r.nombre 'Rol',CASE u.estado_usr WHEN 1 THEN 'Habilitado' ELSE 'Inhabilitado' END 'Estado',h.nombre 'Hotel a cargo',e.nombre'Nombre',e.apellido'Apellido',e.email'Mail',e.dni_tipo'Tipo Doc',e.dni_nro 'Numero Doc',e.telefono'Telefono',e.direccion'Direccion',e.fecha_nacimiento'Fecha' FROM SQLECT.Usuarios u LEFT JOIN SQLECT.Roles_Usuarios ru ON (u.id_usuario=ru.fk_usuario) LEFT JOIN SQLECT.Roles r ON (r.id_rol = ru.fk_rol) LEFT JOIN SQLECT.Usuarios_Hoteles uh ON (u.id_usuario=uh.fk_usuario) LEFT JOIN SQLECT.Hoteles h ON (h.id_hotel=uh.fk_hotel) LEFT JOIN SQLECT.Empleados e ON (e.id_empleado=u.fk_empleado) ");
            return sentence;
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";
            comboRol.SelectedItem = null;
            radioHabilitado.Checked = false;
            radioInhabilitado.Checked = false;
            tablaDeUsuarios.DataSource = null;
            botonBaja.Enabled = false;
            botonModificar.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder listadoUsuarios = getAllInstances();

            if ((textBoxNombre.Text != "") || (comboRol.SelectedIndex > -1) || (radioHabilitado.Checked != false) || (radioInhabilitado.Checked != false))
            {
                listadoUsuarios.Append(" WHERE ");
                if (textBoxNombre.Text != "") 
                    listadoUsuarios.AppendFormat(" (u.usr_name LIKE '%{0}%') AND ", textBoxNombre.Text);

                if (comboRol.SelectedIndex>-1) 
                    listadoUsuarios.AppendFormat(" (r.nombre = '{0}') AND ", comboRol.SelectedItem.ToString());

                if (radioHabilitado.Checked == true)
                    listadoUsuarios.Append(" (u.estado_usr=1) AND ");
                 else
                {
                    if (radioInhabilitado.Checked == true)
                        listadoUsuarios.Append(" (u.estado_usr=0) AND ");
              }
                StringBuilder listadoUsuariosFiltrados = new StringBuilder().AppendFormat(listadoUsuarios.ToString().Substring(0, listadoUsuarios.Length - 5));
                cargarLista(listadoUsuariosFiltrados);
            }
            else
             cargarLista(listadoUsuarios);
        }

        public void cargarLista(StringBuilder consulta)
        {
            DataTable tabla = Conexion.Instance.ejecutarQuery(consulta.ToString());
             tablaDeUsuarios.DataSource = tabla.DefaultView;

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (funcionesUsuarios.nombresHotelesVacios())
            {
                MessageBox.Show("Todos los hoteles están sin nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                ABM_de_Usuario.AltaUsuario formularioAlta = new AltaUsuario();
                formularioAlta.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            botonModificar.Enabled = false;
            botonBaja.Enabled = false;

            if (usuarioSeleccionado.ToString() != "guest")
            {
                if (estadoDelUsuario.ToString() == "Habilitado")
                {
                    tablaDeUsuarios.DataSource = null;
                    BajaUsuario formularioBaja = new BajaUsuario(usuarioSeleccionado.ToString());
                    formularioBaja.Show();
                }
                else
                    MessageBox.Show("El usuario ya se encuentra dado de baja");
            }
            else
                MessageBox.Show("El usuario genérico no se puede dar de baja", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tablaDeUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow registro_actual = tablaDeUsuarios.CurrentRow;
            usuarioSeleccionado.Remove(0, usuarioSeleccionado.Length);
            estadoDelUsuario.Remove(0,estadoDelUsuario.Length);
            hotelSeleccionado.Remove(0, hotelSeleccionado.Length);
            nombre.Remove(0, nombre.Length);
            apellido.Remove(0, apellido.Length);
            tipoDoc.Remove(0, tipoDoc.Length);
            numeroDoc.Remove(0, numeroDoc.Length);
            telefono.Remove(0, telefono.Length);
            direccion.Remove(0, direccion.Length);
            fechaNacimiento.Remove(0, fechaNacimiento.Length);
            rolSeleccionado.Remove(0, rolSeleccionado.Length);
            mailSeleccionado.Remove(0, mailSeleccionado.Length);

            usuarioSeleccionado.AppendFormat("{0}", registro_actual.Cells[0].Value.ToString());
            rolSeleccionado.AppendFormat("{0}",registro_actual.Cells[1].Value.ToString());
            estadoDelUsuario.AppendFormat("{0}", registro_actual.Cells[2].Value.ToString());
            hotelSeleccionado.AppendFormat("{0}", registro_actual.Cells[3].Value.ToString());
            nombre.AppendFormat("{0}", registro_actual.Cells[4].Value.ToString());
            apellido.AppendFormat("{0}", registro_actual.Cells[5].Value.ToString());
            mailSeleccionado.AppendFormat("{0}", registro_actual.Cells[6].Value.ToString());
            tipoDoc.AppendFormat("{0}", registro_actual.Cells[7].Value.ToString());
            numeroDoc.AppendFormat("{0}", registro_actual.Cells[8].Value.ToString());
            telefono.AppendFormat("{0}", registro_actual.Cells[9].Value.ToString());
            direccion.AppendFormat("{0}", registro_actual.Cells[10].Value.ToString());
            fechaNacimiento.AppendFormat("{0}", registro_actual.Cells[11].Value.ToString());

            botonModificar.Enabled = true;
            botonBaja.Enabled = true;


        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            /*if (funcionesUsuarios.nombresHotelesVacios())
            {
                MessageBox.Show("Todos los hoteles están sin nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else*/
            if (usuarioSeleccionado.ToString() != "guest")
            {

                botonModificar.Enabled = false;
                botonBaja.Enabled = false;
                tablaDeUsuarios.DataSource = null;
                ModificacionUsuario formModificacion = new ModificacionUsuario(usuarioSeleccionado.ToString(), nombre.ToString(), apellido.ToString(), tipoDoc.ToString(), numeroDoc.ToString(), mailSeleccionado.ToString(), telefono.ToString(), direccion.ToString(), fechaNacimiento.ToString(), hotelSeleccionado.ToString(), rolSeleccionado.ToString());
                formModificacion.Show();
            }
            else
                MessageBox.Show("El usuario genérico no se puede modificar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
