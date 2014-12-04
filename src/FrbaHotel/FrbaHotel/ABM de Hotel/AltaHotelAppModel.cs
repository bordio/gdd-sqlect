using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Hotel
{
    class AltaHotelAppModel : HotelAppModel
    {
        private Conexion connSql = Conexion.Instance;
        private int id_usuario;
        public AltaHotelAppModel(int id_usuario)
        {
            this.id_usuario = id_usuario;
        }
        public override void doActionHotel(Alta_Hotel formAlta)
        {
            Conexion cnn = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comando1 = new System.Data.SqlClient.SqlCommand();
            comando1.CommandType = CommandType.StoredProcedure;

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
            comando1.Parameters.Add("@id_usuario", SqlDbType.Int);

            comando1.Parameters[0].Value = formAlta.Nombre.Text;
            comando1.Parameters[1].Value = formAlta.Email.Text;
            comando1.Parameters[2].Value = Int32.Parse(formAlta.Cantidad_Estrellas.Text);
            if (formAlta.Fecha_creacion.Text != "") comando1.Parameters[3].Value = DateTime.Parse(formAlta.Fecha_creacion.Text);
            else comando1.Parameters[3].Value = null;
            comando1.Parameters[4].Value = formAlta.Pais.Text;
            comando1.Parameters[5].Value = formAlta.Ciudad.Text;
            comando1.Parameters[6].Value = formAlta.Calle.Text;
            comando1.Parameters[7].Value = Int32.Parse(formAlta.Nro_calle.Text);
            comando1.Parameters[8].Value = (formAlta.ckAllInclusive.Checked ? 1 : 0);
            comando1.Parameters[9].Value = (formAlta.ckAllInclusiveModerado.Checked ? 1 : 0);
            comando1.Parameters[10].Value = (formAlta.ckPensionCompleta.Checked ? 1 : 0);
            comando1.Parameters[11].Value = (formAlta.ckMediaPension.Checked ? 1 : 0);
            comando1.Parameters[12].Value = this.id_usuario;

            comando1.CommandText = "SQLECT.altaHotel";
            cnn.ejecutarQueryConSP(comando1);

            MessageBox.Show("Alta exitosa", "Alta de Hotel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}