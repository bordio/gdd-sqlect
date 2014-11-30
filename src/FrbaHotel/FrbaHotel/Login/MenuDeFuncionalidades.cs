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

namespace FrbaHotel.Login
{
    public partial class MenuDeFuncionalidades : Form
    {
        
        public MenuDeFuncionalidades(string nombreUsuario,string nombreRol)
        {

            InitializeComponent();
            this.usuarioDeSesion = nombreUsuario;
            this.nombreRolDeSesion = nombreRol;
        }

        string usuarioDeSesion;
        string nombreRolDeSesion;

        private Funcionalidades funcionesVarias = new Funcionalidades();

        private void MenuDeFuncionalidades_Load(object sender, EventArgs e)
        {

        }

        public void mostrarHotelesACargo(string nombreDeUsuario, string rolElegido)
        {
            DataTable tabla = buscarHotelesDisponibles(nombreDeUsuario);

            foreach (DataRow dat in tabla.Rows)
            {
                listaHotelesHabilitados.Items.Add(dat[0]);
            }

            cargarFuncionalidades(rolElegido);

        }

        public void cargarFuncionalidades(string rolAsignado)
        {
            label1.Text = string.Format("Listado de funcionalidades del rol: {0}", rolAsignado);
            DataTable elListadoDeFuncionalidades = listarFuncionalidades(rolAsignado);



            tablaDeFuncionalidades.DataSource = elListadoDeFuncionalidades.DefaultView;


        }

        public DataTable listarFuncionalidades(string nombreRol)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand listadoFunc = new System.Data.SqlClient.SqlCommand();

            listadoFunc.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            listadoFunc.Parameters.Add("@nombreRol", SqlDbType.VarChar);
            listadoFunc.Parameters[contador].Value = nombreRol;
            contador++;

            listadoFunc.CommandText = "SQLECT.listarFuncionalidades";

            DataTable table = cnn.ejecutarQueryConSP(listadoFunc);

            return table;
        }


        private void button1_Click(object sender, EventArgs e)
        {


            if (listaHotelesHabilitados.SelectedItem == null)

                MessageBox.Show("Debe seleccionar un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                if (string.IsNullOrEmpty(tareaARealizar.Text))
                    MessageBox.Show("Debe seleccionar una tarea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    dirigirABMElegida(tareaARealizar.Text,usuarioDeSesion);
            }



        }


        public DataTable buscarHotelesDisponibles(string nombreUsuario)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comandoHotelesDisponibles = new System.Data.SqlClient.SqlCommand();

            comandoHotelesDisponibles.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            comandoHotelesDisponibles.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoHotelesDisponibles.Parameters[contador].Value = nombreUsuario;
            contador++;


            comandoHotelesDisponibles.CommandText = "SQLECT.buscarHotelesDisponibles";
            DataTable tablaHoteles = cnn.ejecutarQueryConSP(comandoHotelesDisponibles);
            return tablaHoteles;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tablaDeFuncionalidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tablaDeFuncionalidades_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tareaARealizar.Text = tablaDeFuncionalidades.CurrentRow.Cells[0].Value.ToString();
        }
        public void dirigirABMElegida(string funcionalidad, string usuarioDeSesion)
        {
            int idDeHotelElegido = funcionesVarias.obtenerIDHotel(listaHotelesHabilitados.SelectedItem.ToString());

            switch (funcionalidad)
            {
                case "Gestionar roles": 
                   FrbaHotel.ABM_de_Rol.MainRol gestionarRoles = new FrbaHotel.ABM_de_Rol.MainRol();
                   gestionarRoles.Show();
                    break;
                case "Gestionar usuarios":
                    FrbaHotel.ABM_de_Usuario.Form1 gestionarUsuarios = new FrbaHotel.ABM_de_Usuario.Form1();
                    gestionarUsuarios.Show();
                    break;
                case "Gestionar clientes":
                    FrbaHotel.ABM_de_Cliente.Clientes gestionarClientes = new FrbaHotel.ABM_de_Cliente.Clientes();
                    gestionarClientes.Show();
                    break;
                case "Gestionar hoteles":
                    FrbaHotel.ABM_de_Hotel.MainHotel gestionarHoteles = new FrbaHotel.ABM_de_Hotel.MainHotel();
                    gestionarHoteles.Show();
                    break;
                case "Gestionar habitaciones":
                    FrbaHotel.ABM_de_Habitacion.MainHabitacion gestionarHabitaciones = new FrbaHotel.ABM_de_Habitacion.MainHabitacion();
                    gestionarHabitaciones.Show();
                    break;
                case "Generar/modificar reservas":
                    FrbaHotel.Generar_Modificar_Reserva.Form1 gestionarReservas = new FrbaHotel.Generar_Modificar_Reserva.Form1(idDeHotelElegido,usuarioDeSesion);
                    gestionarReservas.Show();
                    break;
                case "Cancelar reservas":
                    FrbaHotel.Cancelar_Reserva.Form1 cancelarReservas = new FrbaHotel.Cancelar_Reserva.Form1(idDeHotelElegido,usuarioDeSesion,nombreRolDeSesion,true);
                    cancelarReservas.Show();
                    break;
                case "Gestionar estadias":
                    FrbaHotel.Registrar_Estadia.Form1 registrarEstadias = new FrbaHotel.Registrar_Estadia.Form1(usuarioDeSesion, idDeHotelElegido);
                    registrarEstadias.Show();
                    break;
                /*case "Gestionar consumibles":
                    FrbaHotel.Registrar_Consumible.Form1 gestionarConsumibles = new FrbaHotel.Registrar_Consumible.Form1(idDeHotelElegido);
                    gestionarConsumibles.Show();
                    break;
                case "Facturación":
                    FrbaHotel.Registrar_Consumible.Form1 facturacion = new FrbaHotel.Registrar_Consumible.Form1(idDeHotelElegido);
                    facturacion.Show();
                    break;*/
                case "Listado estadístico":
                    FrbaHotel.Listado_Estadistico.Form1 listadoEstadistico = new FrbaHotel.Listado_Estadistico.Form1();
                    listadoEstadistico.Show();
                    break;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrbaHotel.Login.ModificacionContraseña modificarContraseña = new FrbaHotel.Login.ModificacionContraseña(usuarioDeSesion);
            modificarContraseña.Show();


        }

       


    }



}
