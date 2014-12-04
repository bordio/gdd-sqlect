using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class Alta_Hotel : Form
    {
        public HotelAppModel appModel;
        private DataGridView listaHoteles;

        public bool ckPensionCompleta_old;
        public bool ckMediaPension_old;
        public bool ckAllInclusive_old;
        public bool ckAllInclusiveModerado_old;

        public Alta_Hotel(DataGridView lsHoteles,int id_usuario)
        {
            listaHoteles = lsHoteles;
            InitializeComponent();
            appModel = new AltaHotelAppModel(id_usuario);
            Text = "Alta de Hotel";
            appModel.cargarPaises(cmbPais);
        }

        public Alta_Hotel(DataGridView lsHoteles, StringBuilder pais, StringBuilder ciudad, StringBuilder calle, Int32 nro_calle)
        {
            listaHoteles = lsHoteles;
            InitializeComponent();
            Text = "Modificacion de Hotel";
            StringBuilder sentence = new StringBuilder().Append("SELECT h.id_hotel,h.nombre,h.mail,h.fecha_creacion,p.nombrePais 'pais',h.ciudad,h.calle,h.nro_calle,h.cant_estrellas,rh.fk_regimen");
            sentence.Append(" FROM SQLECT.Hoteles h, SQLECT.Regimenes_Hoteles rh, SQLECT.Paises p");
            sentence.AppendFormat(" WHERE p.nombrePais='{0}' AND h.ciudad='{1}' AND h.calle='{2}' AND h.nro_calle={3} AND h.id_hotel=rh.fk_hotel AND h.fk_pais = p.id_pais", pais.ToString(), ciudad.ToString(), calle.ToString(), nro_calle);
            appModel = new ModificacionAppModel(sentence);
          
            Nombre.Text = this.appModel.getNombreSeleccionado();
            Email.Text = this.appModel.getEmailSeleccionado();
            Fecha_creacion.Text = this.appModel.getFechaCreacionSeleccionado();
            Ciudad.Text = this.appModel.getCiudadSeleccionado();
            Calle.Text = this.appModel.getCalleSeleccionado();
            Nro_calle.Text = this.appModel.getNroCalleSeleccionado();
            Cantidad_Estrellas.Text = this.appModel.getCantidadEstrellasSeleccionado();
            appModel.cargarPaises(cmbPais);

            int i;
            for (i = 0; i<appModel.rowHotel.Rows.Count;i++) {
                int fk_regimen = Int32.Parse(appModel.rowHotel.Rows[i][9].ToString());
                if (fk_regimen==1) ckPensionCompleta.Checked = true;
                if (fk_regimen==2) ckMediaPension.Checked = true;
                if (fk_regimen==3) ckAllInclusive.Checked = true;
                if (fk_regimen==4) ckAllInclusiveModerado.Checked = true;
            }

            this.ckAllInclusive_old = ckAllInclusive.Checked;
            this.ckAllInclusiveModerado_old = ckAllInclusiveModerado.Checked;
            this.ckMediaPension_old = ckMediaPension.Checked;
            this.ckPensionCompleta_old = ckPensionCompleta.Checked;
        }

        private void btSeleccionarFecha_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nombre.ResetText();
            Email.ResetText();
            Fecha_creacion.ResetText();
            Calle.ResetText();
            Nro_calle.ResetText();
            cmbPais.ResetText();
            Ciudad.ResetText();
            Cantidad_Estrellas.ResetText();
            ckAllInclusive.Checked = false;
            ckAllInclusiveModerado.Checked = false;
            ckMediaPension.Checked = false;
            ckPensionCompleta.Checked = false;
        }

        private void btAlta_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            bool retValue = this.appModel.actionHotel(this, errores);

            if (retValue)
            {
                this.listaHoteles.DataSource = ABM_de_Hotel.MainHotel.cargar_lista(ABM_de_Hotel.MainHotel.getAllInstances()).DefaultView;
                this.listaHoteles.AllowUserToAddRows = false;
                this.Close();
            }
            else
            {
                MessageBox.Show(errores.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errores = null;
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            Fecha_creacion.Clear();
            Fecha_creacion.AppendText(monthCalendar1.SelectionStart.ToShortDateString());
            monthCalendar1.Visible = false;
        }
    }
}
