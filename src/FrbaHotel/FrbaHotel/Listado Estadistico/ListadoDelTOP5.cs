using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Listado_Estadistico
{
    public partial class ListadoDelTOP5 : Form
    {
        public ListadoDelTOP5()
        {
            InitializeComponent();
        }

        private void ListadoDelTOP5_Load(object sender, EventArgs e)
        {


        }

        public void mostrarTOP5(DataTable top5, string enunciado)
        {
            leyendaTOP5.Visible = true;
            leyendaTOP5.Text = enunciado;

            if (top5.Rows.Count > 0)
            {
                tablaDelTOP5.Visible = true;
                tablaDelTOP5.DataSource = top5.DefaultView;
                tablaDelTOP5.AllowUserToAddRows = false;
            }
            else
            {
                MessageBox.Show("No existe el top 5 de esta opción");
                this.Close();
            }
            
        }
    }
}