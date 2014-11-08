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
        public override void doActionHotel(Control nombre, Control email, Control cant_estrellas, Control fecha_creacion, bool all_inclusive, bool all_inclusive_moderado, bool pension_completa, bool media_pension, Control pais, Control ciudad, Control calle, Control nro_calle)
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
            comando1.Parameters[1].Value = nombre.Text;
            comando1.Parameters[2].Value = email.Text;
            comando1.Parameters[3].Value = Int32.Parse(cant_estrellas.Text);
            if (fecha_creacion.Text != "") comando1.Parameters[4].Value = DateTime.Parse(fecha_creacion.Text);
            else comando1.Parameters[4].Value = null;
            comando1.Parameters[5].Value = pais.Text;
            comando1.Parameters[6].Value = ciudad.Text;
            comando1.Parameters[7].Value = calle.Text;
            comando1.Parameters[8].Value = Int32.Parse(nro_calle.Text);
            comando1.Parameters[9].Value = (all_inclusive ? 1 : 0);
            comando1.Parameters[10].Value = (all_inclusive_moderado ? 1 : 0);
            comando1.Parameters[11].Value = (pension_completa ? 1 : 0);
            comando1.Parameters[12].Value = (media_pension ? 1 : 0);

            comando1.CommandText = "SQLECT.modificacionHotel";
            cnn.ejecutarQueryConSP(comando1);

            MessageBox.Show("Modificacion exitosa", "Modificacion de Hotel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override bool existeEmail(string email)
        {
            StringBuilder sentece = new StringBuilder();
            sentece.AppendFormat("SELECT * FROM SQLECT.Hoteles h WHERE h.mail='{0}' AND h.id_hotel!={1}", email,this.idHotel);
            return this.connSql.ejecutarQuery(sentece.ToString()).Rows.Count > 0;
        }
    }
}
