﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Habitacion
{
    class ModificacionHabitacionAppModel : HabitacionAppModel
    {
        private Conexion connSql = Conexion.Instance;
        private StringBuilder hotelSeleccionado = new StringBuilder();
        private StringBuilder tipo_habitacionSeleccionado = new StringBuilder();
        private string nro_habitacion = null;
        private string piso = null;
        private string frente = null;
        private string descripcion = null;
        private int id_habitacion = 0;
        private FormBusqueda formBusq;

        public ModificacionHabitacionAppModel(Int32 id_habitacion, StringBuilder hotelSeleccionado, StringBuilder tipo_habitacionSeleccionado, FormBusqueda formBusq)
        {
            this.hotelSeleccionado = hotelSeleccionado;
            this.tipo_habitacionSeleccionado = tipo_habitacionSeleccionado;
            this.id_habitacion = id_habitacion;
            this.formBusq = formBusq;
            StringBuilder sentece = new StringBuilder();
            sentece.AppendFormat("SELECT nro_habitacion, piso, frente, descripcion FROM SQLECT.Habitaciones WHERE id_habitacion={0}",id_habitacion);
            DataTable tabla = this.connSql.ejecutarQuery(sentece.ToString());

            nro_habitacion = tabla.Rows[0]["nro_habitacion"].ToString();
            piso = tabla.Rows[0]["piso"].ToString();
            frente = tabla.Rows[0]["frente"].ToString();
            descripcion = tabla.Rows[0]["descripcion"].ToString();
        }

        public override void doActionHabitacion(ComboBox cmb_hotel, Control numero_habitacion, Control piso, ComboBox cmb_tipo_habitacion, RadioButton exterior, RadioButton interior, Control descripcion)
        {
            Conexion cnn = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comando1 = new System.Data.SqlClient.SqlCommand();
            comando1.CommandType = CommandType.StoredProcedure;

            comando1.Parameters.Add("@id_habitacion", SqlDbType.Int);
            comando1.Parameters.Add("@nro_habitacion", SqlDbType.Int);
            comando1.Parameters.Add("@fk_hotel", SqlDbType.Int);
            comando1.Parameters.Add("@piso", SqlDbType.Int);
            comando1.Parameters.Add("@frente", SqlDbType.Char);
            comando1.Parameters.Add("@descripcion", SqlDbType.Text);

            comando1.Parameters[0].Value = this.id_habitacion;
            comando1.Parameters[1].Value = Int32.Parse(numero_habitacion.Text);
            comando1.Parameters[2].Value = this.id_hotels[cmb_hotel.SelectedIndex];
            comando1.Parameters[3].Value = Int32.Parse(piso.Text);
            comando1.Parameters[4].Value = (exterior.Checked ? 'S' : 'N');
            comando1.Parameters[5].Value = descripcion.Text;

            comando1.CommandText = "SQLECT.modificacionHabitacion";
            cnn.ejecutarQueryConSP(comando1);

            MessageBox.Show("Modificacion exitosa", "Modificacion de Habitacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            formBusq.filtrar();
        }

        public override void cargarHoteles(ComboBox cmbHoteles)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT nombre,id_hotel FROM SQLECT.Hoteles");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                cmbHoteles.Items.Add(tabla.Rows[i]["nombre"].ToString());
                this.id_hotels.Add(Int32.Parse(tabla.Rows[i]["id_hotel"].ToString()));
                if (tabla.Rows[i]["nombre"].ToString() == this.hotelSeleccionado.ToString())
                {
                    cmbHoteles.SelectedIndex = i;
                }
            }
        }

        public override void cargarTipoHabitaciones(ComboBox cmbTipoHabitaciones)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT descripcion,id_tipo_habitacion FROM SQLECT.Tipos_Habitaciones");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                cmbTipoHabitaciones.Items.Add(tabla.Rows[i]["descripcion"].ToString());
                this.id_tipo_habitaciones.Add(Int32.Parse(tabla.Rows[i]["id_tipo_habitacion"].ToString()));
                if (tabla.Rows[i]["descripcion"].ToString() == this.tipo_habitacionSeleccionado.ToString())
                {
                    cmbTipoHabitaciones.SelectedIndex = i;
                }
            }
            cmbTipoHabitaciones.Enabled = false;
        }

        public override void preload(Control Numero_Habitacion, Control Piso, RadioButton rdExterior, RadioButton rdInterior, Control Descripcion)
        {
            Numero_Habitacion.Text = nro_habitacion;
            Piso.Text = piso;
            (frente == "S" ? rdExterior : rdInterior).Checked = true;
            Descripcion.Text = descripcion;
        }

        public override bool nroHabitacionDuplicado(ComboBox cmb_hotel, Control numero_habitacion)
        {
            StringBuilder sentece = new StringBuilder();
            sentece.AppendFormat("SELECT id_habitacion FROM SQLECT.Habitaciones WHERE fk_hotel={0} AND nro_habitacion={1} AND id_habitacion != {2}", id_hotels[cmb_hotel.SelectedIndex], Int32.Parse(numero_habitacion.Text), this.id_habitacion);
            return this.connSql.ejecutarQuery(sentece.ToString()).Rows.Count > 0;
        }
    }
}
