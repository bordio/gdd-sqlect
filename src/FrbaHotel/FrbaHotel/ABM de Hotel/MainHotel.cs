﻿using System;
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
            lstHoteles.DataSource = cargar_lista(getAllInstances()).DefaultView;
            lstHoteles.AllowUserToAddRows = false;
        }

        public static StringBuilder getAllInstances()
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT nombre 'Nombre', pais 'Pais', ciudad 'Ciudad', calle + ' ' + CONVERT(varchar,nro_calle,10) 'Direccion', cant_estrellas 'Cantidad de estrellas' FROM SQLECT.Hoteles");
            return sentence;
        }

        public static DataTable cargar_lista(StringBuilder sentence)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            Nombre.ResetText();
            CantidadEstrellas.ResetText();
            Ciudad.ResetText();
            Pais.ResetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder();
            sentence = getAllInstances();

            if ((Nombre.Text != "") || (CantidadEstrellas.Text != "") || (Ciudad.Text != "") || (Pais.Text != ""))
            {
                sentence.Append(" WHERE ");
                if (Nombre.Text != "") sentence.AppendFormat(" (nombre LIKE '%{0}%') AND ", Nombre.Text);
                if (CantidadEstrellas.Text != "")
                {
                    try
                    {
                        int numero = Convert.ToInt32(CantidadEstrellas.Text);
                        sentence.AppendFormat(" (cant_estrellas = '{0}') AND ", numero);
                    }
                    catch
                    {
                        MessageBox.Show("El filtro de cantidad estrellas debe ser numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (Ciudad.Text != "") sentence.AppendFormat(" (ciudad LIKE '%{0}%') AND ", Ciudad.Text);
                if (Pais.Text != "") sentence.AppendFormat(" (pais LIKE '%{0}%') AND ", Pais.Text);
                StringBuilder sentenceFiltro = new StringBuilder().AppendFormat(sentence.ToString().Substring(0, sentence.Length - 5));
                lstHoteles.DataSource = cargar_lista(sentenceFiltro).DefaultView;
                lstHoteles.AllowUserToAddRows = false;
            }
            else
            {
                lstHoteles.DataSource = cargar_lista(sentence).DefaultView;
                lstHoteles.AllowUserToAddRows = false;
            }
        }
    }
}
