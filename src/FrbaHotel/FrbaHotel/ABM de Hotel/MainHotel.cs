using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.Commons.Database;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class MainHotel : Form
    {
        public MainHotel()
        {
            InitializeComponent();
        }

        private void MainHotel_Load(object sender, EventArgs e)
        {
            lstHoteles.DataSource = cargar_lista().DefaultView;
            lstHoteles.AllowUserToAddRows = false;
        }

        public static DataTable cargar_lista()
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT ciudad 'Ciudad', calle + ' ' + CONVERT(varchar,nro_calle,10) 'Direccion' FROM SQLECT.Hoteles");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            return tabla;
        }

        private void cerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modificar_Click(object sender, EventArgs e)
        {

        }

        private void lstHoteles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            Alta_Hotel formAlta = new Alta_Hotel(this.lstHoteles);
            formAlta.Show();
        }
    }
}
