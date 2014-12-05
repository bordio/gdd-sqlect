using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;

namespace FrbaHotel.Listado_Estadistico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT DISTINCT YEAR(fecha_inicio) FROM SQLECT.Reservas UNION (SELECT DISTINCT YEAR(fecha_inicio) FROM SQLECT.Bajas_por_hotel)");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            foreach (DataRow dat in tabla.Rows)
            {
                comboAño.Items.Add(dat[0]);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboAño.SelectedIndex == -1) || (comboTrimestre.SelectedIndex == -1))
                MessageBox.Show("Debe ingresar el año y el trimestre");

            else
            {

                ListadoDelTOP5 nuevoForm = new ListadoDelTOP5();
                nuevoForm.Show();
                nuevoForm.mostrarTOP5(obtenerTOP5(Convert.ToInt32(comboAño.SelectedItem.ToString()), Convert.ToInt32(comboTrimestre.SelectedItem.ToString()), top5HotReserCanc.Text), "Top 5 de los Hoteles con mayor cantidad de reservas canceladas");

            }


        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((comboAño.SelectedIndex == -1) || (comboTrimestre.SelectedIndex == -1))
                MessageBox.Show("Debe ingresar el año y el trimestre");

            else
            {
                ListadoDelTOP5 nuevoForm = new ListadoDelTOP5();
                nuevoForm.Show();

                nuevoForm.mostrarTOP5(obtenerTOP5(Convert.ToInt32(comboAño.SelectedItem.ToString()), Convert.ToInt32(comboTrimestre.SelectedItem.ToString()), top5HotConsFact.Text), "Top 5 de los Hoteles con mayor cantidad de consumibles facturados");
            }


        }

        private void top5HotFueraServ_Click(object sender, EventArgs e)
        {
            if ((comboAño.SelectedIndex == -1) || (comboTrimestre.SelectedIndex == -1))
                MessageBox.Show("Debe ingresar el año y el trimestre");

            else
            {
                ListadoDelTOP5 nuevoForm = new ListadoDelTOP5();
                nuevoForm.Show();

                nuevoForm.mostrarTOP5(obtenerTOP5(Convert.ToInt32(comboAño.SelectedItem.ToString()), Convert.ToInt32(comboTrimestre.SelectedItem.ToString()), top5HotFueraServ.Text), "Top 5 de los Hoteles con mayor cantidad de días fuera de servicio");
            }

        }

        private void top5HabMasOcup_Click(object sender, EventArgs e)
        {
            if ((comboAño.SelectedIndex == -1) || (comboTrimestre.SelectedIndex == -1))
                MessageBox.Show("Debe ingresar el año y el trimestre");

            else
            {
                ListadoDelTOP5 nuevoForm = new ListadoDelTOP5();
                nuevoForm.Show();

                nuevoForm.mostrarTOP5(obtenerTOP5(Convert.ToInt32(comboAño.SelectedItem.ToString()), Convert.ToInt32(comboTrimestre.SelectedItem.ToString()), top5HabMasOcup.Text), "Top 5 de las Habitaciones más ocupadas");
            }

        }


        private void top5CliMejPunt_Click(object sender, EventArgs e)
        {
            if ((comboAño.SelectedIndex == -1) || (comboTrimestre.SelectedIndex == -1))
                MessageBox.Show("Debe ingresar el año y el trimestre");

            else
            {
                ListadoDelTOP5 nuevoForm = new ListadoDelTOP5();
                nuevoForm.Show();

                nuevoForm.mostrarTOP5(obtenerTOP5(Convert.ToInt32(comboAño.SelectedItem.ToString()), Convert.ToInt32(comboTrimestre.SelectedItem.ToString()), top5CliMejPunt.Text), "Top 5 de los Clientes mejores puntuados");

            }

        }

        public DataTable obtenerTOP5(int año, int trimestre, string nombreDelTOP5)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comando1 = new System.Data.SqlClient.SqlCommand();

            comando1.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            int inicioTri = obtenerInicioTrimestre(trimestre); /*Obtenemos el inicio del trimestre*/
            int finTri = obtenerFinTrimestre(trimestre);       /*Obtenemos el fin del trimestre*/

            string nombreProcedureTOP5 = elegirNombreDelProcedure(nombreDelTOP5); /*Obtengo qué top 5 es*/

            comando1.Parameters.Add("@año", SqlDbType.Int);
            comando1.Parameters[contador].Value = año;
            contador++;


            comando1.Parameters.Add("@inicioTri", SqlDbType.Int);
            comando1.Parameters[contador].Value = inicioTri;
            contador++;

            comando1.Parameters.Add("@finTri", SqlDbType.Int);
            comando1.Parameters[contador].Value = finTri;
            contador++;


            comando1.CommandText = nombreProcedureTOP5;

            DataTable table = cnn.ejecutarQueryConSP(comando1); /*Ejecutamos el Procedure top5HotelesReservasCanceladas y obtenemos el top5 */

            return table;


        }
        public string elegirNombreDelProcedure(string nombre)
        {
            string nombreDelProcedure = "";
            switch (nombre)
            {
                case "Hoteles con mayor cantidad de reservas canceladas": nombreDelProcedure = "SQLECT.top5HotelesReservasCanceladas";
                    break;
                case "Hoteles con mayor cantidad de consumibles facturados": nombreDelProcedure = "SQLECT.top5HotelesConsumiblesFacturados";
                    break;
                case "Hoteles con mayor cantidad de días fuera de servicio": nombreDelProcedure = "SQLECT.top5HotelesFueraDeServicio";
                    break;
                case "Habitaciones que mas se ocuparon": nombreDelProcedure = "SQLECT.top5HabitacionesMasOcupadas";
                    break;
                case "Clientes mejores puntuados": nombreDelProcedure = "SQLECT.top5ClientesMejoresPuntuados";
                    break;
            }
            return nombreDelProcedure;
        }

        private int obtenerInicioTrimestre(int trimestre)
        {
            int inicioTri = 0;

            switch (trimestre)
            {
                case 1: inicioTri = 1;
                    break;
                case 2: inicioTri = 4;
                    break;
                case 3: inicioTri = 7;
                    break;
                case 4: inicioTri = 10;
                    break;
            }
            return inicioTri;
        }
        private int obtenerFinTrimestre(int trimestre)
        {
            int finTri = 0;

            switch (trimestre)
            {
                case 1: finTri = 3;
                    break;
                case 2: finTri = 6;
                    break;
                case 3: finTri = 9;
                    break;
                case 4: finTri = 12;
                    break;
            }
            return finTri;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
