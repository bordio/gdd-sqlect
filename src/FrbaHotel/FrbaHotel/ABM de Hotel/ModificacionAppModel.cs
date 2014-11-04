using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Hotel
{
    class ModificacionAppModel : HotelAppModel
    {
        private Conexion connSql = Conexion.Instance;
        public override void doActionHotel(Control nombre, Control email, Control cant_estrellas, Control fecha_creacion, bool all_inclusive, bool all_inclusive_moderado, bool pension_completa, bool media_pension, Control pais, Control ciudad, Control calle, Control nro_calle)
        {
            MessageBox.Show("Modificacion exitosa", "Modificacion de Hotel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
