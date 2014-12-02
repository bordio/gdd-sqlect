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
    class BajaAppModel
    {
        public StringBuilder errores = new StringBuilder();
        private Conexion connSql = Conexion.Instance;
        public int id_hotel;
        public BajaAppModel(String pais, String ciudad, String calle, Int32 nro_calle)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT id_hotel FROM SQLECT.Hoteles WHERE pais='{0}' AND ciudad='{1}' AND calle='{2}' AND nro_calle={3}", pais, ciudad, calle, nro_calle);
            DataTable row_id_hotel = Conexion.Instance.ejecutarQuery(sentence.ToString());
            this.id_hotel = Int32.Parse(row_id_hotel.Rows[0][0].ToString());
        }

        public void darDeBaja(Control Desde, Control Hasta, Control Motivo, Form Window)
        {
            validar_formulario(Desde,Hasta,Motivo);
            if (validar_establecimiento_vacio(Desde,Hasta)) this.errores.AppendLine("El establecimiento no se encuentra vacio en el rango de fechas seleccionado.");
            if (this.errores.Length > 0) MessageBox.Show(this.errores.ToString(), "Errores al tratar de dar de baja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Conexion cnn = Conexion.Instance;
                System.Data.SqlClient.SqlCommand comando1 = new System.Data.SqlClient.SqlCommand();
                comando1.CommandType = CommandType.StoredProcedure;

                comando1.Parameters.Add("@id_hotel", SqlDbType.Int);
                comando1.Parameters.Add("@desde", SqlDbType.DateTime);
                comando1.Parameters.Add("@hasta", SqlDbType.DateTime);
                comando1.Parameters.Add("@motivo", SqlDbType.Text);

                comando1.Parameters[0].Value = this.id_hotel;
                comando1.Parameters[1].Value = Desde.Text;
                comando1.Parameters[2].Value = Hasta.Text;
                comando1.Parameters[3].Value = Motivo.Text;

                comando1.CommandText = "SQLECT.bajaHotel";
                cnn.ejecutarQueryConSP(comando1);
                MessageBox.Show("Se ha dado de baja temporal correctamente.", "Baja temporal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Window.Close();
            }
        }

        public bool validar_establecimiento_vacio(Control Desde, Control Hasta)
        {
            StringBuilder sentece = new StringBuilder();

            if (Desde.Text.Length > 0 && Hasta.Text.Length > 0)
            {
                String fecha_desde = this.formatearFechaDateTime(Desde.Text);
                String fecha_hasta = this.formatearFechaDateTime(Hasta.Text);
                sentece.Append("SELECT res.id_reserva");
                sentece.Append(" FROM SQLECT.Habitaciones hab, SQLECT.Habitaciones_Reservas habres, SQLECT.Reservas res");
                sentece.AppendFormat(" WHERE (hab.fk_hotel = {0}) AND (hab.id_habitacion = habres.fk_habitacion) AND (habres.fk_reserva = res.id_reserva)",this.id_hotel);
                sentece.Append(" AND ((NOT (res.estado_reserva in (2,3,4))");
                sentece.AppendFormat(" AND (res.fecha_inicio BETWEEN '{0}' AND '{1}')", fecha_desde, fecha_hasta);
                sentece.AppendFormat(" OR (res.fecha_inicio+res.cant_noches_reserva BETWEEN '{0}' AND '{1}')))", fecha_desde, fecha_hasta);
                return this.connSql.ejecutarQuery(sentece.ToString()).Rows.Count > 0;
            }
            return false;
        }

        private String formatearFechaDateTime(String fechaAFormatear)
        {
            StringBuilder fecha = new StringBuilder();
            fecha.AppendFormat("{0}{1}{2}", DateTime.Parse(fechaAFormatear).Year.ToString(), (Int32.Parse(DateTime.Parse(fechaAFormatear).Month.ToString()) < 10) ? "0" + DateTime.Parse(fechaAFormatear).Month.ToString() : DateTime.Parse(fechaAFormatear).Month.ToString(), Int32.Parse(DateTime.Parse(fechaAFormatear).Day.ToString()) < 10 ? "0" + DateTime.Parse(fechaAFormatear).Day.ToString() : DateTime.Parse(fechaAFormatear).Day.ToString());
            return fecha.ToString();
        }

        public bool validar_formulario(Control Desde, Control Hasta, Control Motivo)
        {
            errores.Remove(0, errores.Length);
            bool result = true;
            if (Desde.Text.Length == 0)
            {
                result = false;
                errores.AppendLine("El campo Desde es obligatorio.");
            }
            if (Hasta.Text.Length == 0)
            {
                result = false;
                errores.AppendLine("El campo Hasta es obligatorio.");
            }
            if (Motivo.Text.Length == 0)
            {
                result = false;
                errores.AppendLine("El campo Motivo es obligatorio.");
            }
            return result;
        }
    }
}
