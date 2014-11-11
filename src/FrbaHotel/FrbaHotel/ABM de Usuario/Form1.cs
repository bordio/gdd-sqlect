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
        
    private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT DISTINCT nombre FROM SQLECT.Roles");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            foreach (DataRow dat in tabla.Rows)
            {

                comboRol.Items.Add(dat[0]);
            }



        }
        public static StringBuilder getAllInstances()
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT u.usr_name 'Nombre', r.nombre 'Rol',u.estado_usr 'Estado',h.nombre 'Hotel a cargo' FROM SQLECT.Usuarios u LEFT JOIN SQLECT.Roles_Usuarios ru ON (u.id_usuario=ru.fk_usuario) LEFT JOIN SQLECT.Roles r ON (r.id_rol = ru.fk_rol) LEFT JOIN SQLECT.Usuarios_Hoteles uh ON (u.id_usuario=uh.fk_usuario) LEFT JOIN SQLECT.Hoteles h ON (h.id_hotel=uh.fk_hotel)");
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
                MessageBox.Show("Todos los hoteles están sin nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                ABM_de_Usuario.AltaUsuario formularioAlta = new AltaUsuario();
                formularioAlta.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (estadoDelUsuario.ToString() == "1")
            {
                BajaUsuario formularioBaja = new BajaUsuario(usuarioSeleccionado.ToString());
                formularioBaja.Show();
            }
            else
                MessageBox.Show("El usuario ya se encuentra dado de baja");
        }

        private void tablaDeUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow registro_actual = tablaDeUsuarios.CurrentRow;
            usuarioSeleccionado.Remove(0, usuarioSeleccionado.Length);
            estadoDelUsuario.Remove(0,estadoDelUsuario.Length);

            usuarioSeleccionado.AppendFormat("{0}", registro_actual.Cells[0].Value.ToString());
            estadoDelUsuario.AppendFormat("{0}", registro_actual.Cells[2].Value.ToString());

            botonModificar.Enabled = true;
            botonBaja.Enabled = true;


        }      

    }
}
