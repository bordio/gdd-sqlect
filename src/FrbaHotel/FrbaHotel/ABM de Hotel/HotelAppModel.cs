using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Hotel
{
    public abstract class HotelAppModel
    {
        private Conexion connSql = Conexion.Instance;
        protected bool fallo_carga = false;
        public DataTable rowHotel = new DataTable();

        public abstract void doActionHotel(Alta_Hotel formAlta);
        public virtual bool puedeEliminarRegimen(string regimen) { return false; }

        public bool actionHotel(Alta_Hotel formAlta, StringBuilder errores)
        {
            validarForm(formAlta, errores);
            if (errores.Length > 0)
            {
                return false;
            }
            else
            {
                doActionHotel(formAlta);
                return true;
            }
        }

        public void validarForm(Alta_Hotel formAlta, StringBuilder errores)
        {
            if (formAlta.Nombre.Text == "" || formAlta.Email.Text == "" || formAlta.Cantidad_Estrellas.Text == "" || formAlta.Pais.Text == "" || formAlta.Ciudad.Text == "" || formAlta.Calle.Text == "" || formAlta.Nro_calle.Text == "")
            {
                errores.AppendLine("No debe dejar los campos obligatorios en blanco");
                fallo_carga = true;
            }
            if (!fallo_carga && this.existeEmail(formAlta.Email.Text))
            {
                errores.AppendLine("Email duplicado");
            }
            if (!fallo_carga && this.hotelDuplicado(formAlta.Pais.Text,formAlta.Ciudad.Text,formAlta.Calle.Text,Int32.Parse(formAlta.Nro_calle.Text))) {
                errores.AppendLine("Ya existe un hotel en ese pais, en esa ciudad y en la misma direccion.");
            }
            if (!fallo_carga && !this.seleccionoAlgunRegimen(formAlta.ckAllInclusive,formAlta.ckAllInclusiveModerado,formAlta.ckPensionCompleta,formAlta.ckMediaPension))
            {
                errores.AppendLine("Debe seleccionar algun regimen");
            }
            if (!fallo_carga && esNumerico(errores, formAlta.Cantidad_Estrellas))
            {
                if (Int32.Parse(formAlta.Cantidad_Estrellas.Text) < 0)
                {
                    errores.AppendLine("La cantidad de estrellas debe ser un numero positivo");
                }
            }
            if (!fallo_carga && esNumerico(errores, formAlta.Nro_calle))
            {
                if (Int32.Parse(formAlta.Nro_calle.Text) < 0)
                {
                    errores.AppendLine("El numero de calle debe ser un numero positivo");
                }
            }
            if (!fallo_carga && !formAlta.ckAllInclusive.Checked && (formAlta.ckAllInclusive_old != formAlta.ckAllInclusive.Checked) && !puedeEliminarRegimen("All inclusive"))
            {
                errores.AppendLine("El regimen All inclusive no se puede dar de baja debido a que ya existen reservas tomadas con este regimen.");
            }
            if (!fallo_carga && !formAlta.ckAllInclusiveModerado.Checked && (formAlta.ckAllInclusiveModerado_old != formAlta.ckAllInclusiveModerado.Checked) && !puedeEliminarRegimen("All Inclusive moderado"))
            {
                errores.AppendLine("El regimen All Inclusive moderado no se puede dar de baja debido a que ya existen reservas tomadas con este regimen.");
            }
            if (!fallo_carga && !formAlta.ckPensionCompleta.Checked && (formAlta.ckPensionCompleta_old != formAlta.ckPensionCompleta.Checked) && !puedeEliminarRegimen("Pension Completa"))
            {
                errores.AppendLine("El regimen Pension Completa no se puede dar de baja debido a que ya existen reservas tomadas con este regimen.");
            }
            if (!fallo_carga && !formAlta.ckMediaPension.Checked && (formAlta.ckMediaPension_old != formAlta.ckMediaPension.Checked) && !puedeEliminarRegimen("Media Pensión"))
            {
                errores.AppendLine("El regimen Media Pensión no se puede dar de baja debido a que ya existen reservas tomadas con este regimen.");
            }

            fallo_carga = false;
        }

        public virtual bool hotelDuplicado(String pais, String ciudad, String calle, Int32 nro_calle)
        {
            StringBuilder sentece = new StringBuilder();
            sentece.AppendFormat("SELECT id_hotel FROM SQLECT.Hoteles h WHERE UPPER(h.pais)=UPPER('{0}') AND UPPER(h.ciudad)=UPPER('{1}') AND UPPER(h.calle)=UPPER('{2}') AND h.nro_calle={3}", pais.ToString(),ciudad.ToString(),calle.ToString(),nro_calle);
            return this.connSql.ejecutarQuery(sentece.ToString()).Rows.Count > 0;
        }

        public virtual bool existeEmail(string email)
        {
            StringBuilder sentece = new StringBuilder();
            sentece.AppendFormat("SELECT id_hotel FROM SQLECT.Hoteles h WHERE h.mail='{0}'", email);
            return this.connSql.ejecutarQuery(sentece.ToString()).Rows.Count > 0;
        }

        private bool seleccionoAlgunRegimen(CheckBox all_inclusive, CheckBox all_inclusive_moderado, CheckBox pension_completa, CheckBox media_pension)
        {
            if (all_inclusive.Checked || all_inclusive_moderado.Checked || pension_completa.Checked || media_pension.Checked) return true;
            else return false;
        }

        private bool esNumerico(StringBuilder mensajeValidacion, Control control)
        {
            try
            {
                int esNumero = Convert.ToInt32(control.Text);
                return true;
            }
            catch
            {
                mensajeValidacion.AppendLine(string.Format(" El campo {0} debe ser numerico.", control.Name));
                return false;
            }
        }
    }
}
