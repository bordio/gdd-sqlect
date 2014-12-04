using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace FrbaHotel.ABM_de_Hotel
{
    class ModificacionAppModel : HotelAppModel
    {
        private Conexion connSql = Conexion.Instance;
        private int idHotel;
        public ModificacionAppModel(StringBuilder sentence)
        {
            rowHotel = Conexion.Instance.ejecutarQuery(sentence.ToString());
            this.idHotel = Int32.Parse(rowHotel.Rows[0][0].ToString());
        }
        public override void doActionHotel(Alta_Hotel formAlta)
        {
            Conexion cnn = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comando1 = new System.Data.SqlClient.SqlCommand();
            comando1.CommandType = CommandType.StoredProcedure;

            comando1.Parameters.Add("@id_hotel", SqlDbType.Int);
            comando1.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando1.Parameters.Add("@email", SqlDbType.VarChar);
            comando1.Parameters.Add("@cant_estrellas", SqlDbType.Int);
            comando1.Parameters.Add("@fecha_creacion", SqlDbType.DateTime);
            comando1.Parameters.Add("@pais", SqlDbType.VarChar);
            comando1.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando1.Parameters.Add("@calle", SqlDbType.VarChar);
            comando1.Parameters.Add("@nro_calle", SqlDbType.Int);
            comando1.Parameters.Add("@all_inclusive", SqlDbType.Int);
            comando1.Parameters.Add("@all_inclusive_moderado", SqlDbType.Int);
            comando1.Parameters.Add("@pension_completa", SqlDbType.Int);
            comando1.Parameters.Add("@media_pension", SqlDbType.Int);

            comando1.Parameters[0].Value = this.idHotel;
            comando1.Parameters[1].Value = formAlta.Nombre.Text;
            comando1.Parameters[2].Value = formAlta.Email.Text;
            comando1.Parameters[3].Value = Int32.Parse(formAlta.Cantidad_Estrellas.Text);
            if (formAlta.Fecha_creacion.Text != "") comando1.Parameters[4].Value = DateTime.Parse(formAlta.Fecha_creacion.Text);
            else comando1.Parameters[4].Value = null;
            comando1.Parameters[5].Value = formAlta.cmbPais.SelectedItem.ToString();
            comando1.Parameters[6].Value = formAlta.Ciudad.Text;
            comando1.Parameters[7].Value = formAlta.Calle.Text;
            comando1.Parameters[8].Value = Int32.Parse(formAlta.Nro_calle.Text);
            comando1.Parameters[9].Value = (formAlta.ckAllInclusive.Checked ? 1 : 0);
            comando1.Parameters[10].Value = (formAlta.ckAllInclusiveModerado.Checked ? 1 : 0);
            comando1.Parameters[11].Value = (formAlta.ckPensionCompleta.Checked ? 1 : 0);
            comando1.Parameters[12].Value = (formAlta.ckMediaPension.Checked ? 1 : 0);

            comando1.CommandText = "SQLECT.modificacionHotel";
            cnn.ejecutarQueryConSP(comando1);

            MessageBox.Show("Modificacion exitosa", "Modificacion de Hotel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override bool hotelDuplicado(String pais, String ciudad, String calle, Int32 nro_calle)
        {
            StringBuilder sentece = new StringBuilder();
            sentece.AppendFormat("SELECT id_hotel FROM SQLECT.Hoteles h, SQLECT.Paises p WHERE UPPER(p.nombrePais)=UPPER('{0}') AND UPPER(h.ciudad)=UPPER('{1}') AND UPPER(h.calle)=UPPER('{2}') AND h.nro_calle={3} AND (p.id_pais = h.fk_pais) AND h.id_hotel!={4}", pais.ToString(), ciudad.ToString(), calle.ToString(), nro_calle,this.idHotel);
            return this.connSql.ejecutarQuery(sentece.ToString()).Rows.Count > 0;
        }

        public override bool existeEmail(String email)
        {
            StringBuilder sentece = new StringBuilder();
            sentece.AppendFormat("SELECT * FROM SQLECT.Hoteles h WHERE h.mail='{0}' AND h.id_hotel!={1}", email,this.idHotel);
            return this.connSql.ejecutarQuery(sentece.ToString()).Rows.Count > 0;
        }

        public override bool puedeEliminarRegimen(string regimen)
        {
            int anioFormateado = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Año"].ToString()) * 10000 + Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Mes"].ToString()) * 100 + Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Dia"].ToString());
            StringBuilder sentece = new StringBuilder();
            sentece.AppendFormat("SELECT SQLECT.funcPuedoQuitarRegimen({0},'{1}','{2}')", idHotel, regimen, anioFormateado);
            return (Int32.Parse(this.connSql.ejecutarQuery(sentece.ToString()).Rows[0][0].ToString()) == 1);
        }

        public override void cargarPaises(ComboBox cmbPais)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT nombrePais FROM SQLECT.Paises");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                cmbPais.Items.Add(tabla.Rows[i]["nombrePais"].ToString());
                if (tabla.Rows[i]["nombrePais"].ToString() == this.rowHotel.Rows[0][4].ToString())
                {
                    cmbPais.SelectedIndex = i;
                }
            }
        }

        public override string getNombreSeleccionado() { return rowHotel.Rows[0][1].ToString(); }
        public override string getEmailSeleccionado() { return rowHotel.Rows[0][2].ToString(); }
        public override string getCantidadEstrellasSeleccionado() { return rowHotel.Rows[0][8].ToString(); }
        public override string getFechaCreacionSeleccionado() { return rowHotel.Rows[0][3].ToString(); }
        public override string getPaisSeleccionado() { return rowHotel.Rows[0][4].ToString(); }
        public override string getCiudadSeleccionado() { return rowHotel.Rows[0][5].ToString(); }
        public override string getCalleSeleccionado() { return rowHotel.Rows[0][6].ToString(); }
        public override string getNroCalleSeleccionado() { return rowHotel.Rows[0][7].ToString(); }
    }
}
