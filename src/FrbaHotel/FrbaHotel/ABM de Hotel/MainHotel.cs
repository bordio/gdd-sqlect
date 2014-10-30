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
           /* StringBuilder sentence = new StringBuilder().AppendFormat("SELECT ciudad,calle,nro_calle FROM Hoteles");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                this.lstHoteles.Items.Add(tabla.Rows[i][0].ToString());
                this.lstHoteles.Items.Add(tabla.Rows[i][1].ToString());
                this.lstHoteles.Items.Add(tabla.Rows[i][2].ToString());
            }*/
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
         
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT ciudad 'Ciudad',calle'Calle',nro_calle'Número de calle' FROM Hoteles");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            /* lstHoteles.ColumnCount = 3;
             lstHoteles.ColumnHeadersVisible = true;*/



            lstHoteles.DataSource = tabla.DefaultView;
            lstHoteles.AllowUserToAddRows = false;



        }
        }
    }
