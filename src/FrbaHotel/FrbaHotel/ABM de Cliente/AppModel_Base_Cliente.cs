﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente {

    public abstract class AppModel_Base_Cliente {

        public DataTable rowHotel = new DataTable();
        private Conexion sqlconexion = Conexion.Instance;

        public abstract void abmlCliente(string nombre, string apellido, string mail, string dom_Calle, string nro_Calle, string piso, string depto, string fecha_Nac, string nacionalidad, string pasaporte_Nro);
        
        /*Validacion de campos*/

        public bool validarNoVacio(Control control, StringBuilder mensajeValidacion)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                mensajeValidacion.AppendLine(string.Format(" El campo {0} no puede estar en blanco.", control.Name));
                return false;
            }
            return true;
        }

        public bool validarLongitud(Control control, int maxLength, StringBuilder mensajeValidacion)
        {
            if ((control.Text.Length <= 0) && (control.Text.Length > maxLength))
            {
                mensajeValidacion.AppendLine(string.Format(" Incorrecta cantidad de caracteres en el campo {0}.", control.Name));
                return false;
            }
            return true;
        }

        public bool validarNumerico(Control control, StringBuilder mensajeValidacion)
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

        public void validarEmail(Control mail, StringBuilder mensajeValidacion)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("SELECT * FROM SQLECT.Clientes c WHERE c.mail='{0}'", mail.Text);
            if (this.sqlconexion.ejecutarQuery(query.ToString()).Rows.Count > 0)
            {
                mensajeValidacion.AppendLine(string.Format(" El email {0} ya existe.", mail.Text));
            };
        }

        public void validarPasaporte(Control pasaporte, StringBuilder mensajeValidacion)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("SELECT * FROM SQLECT.Clientes c WHERE c.pasaporte_Nro='{0}'", pasaporte.Text);
            if (this.sqlconexion.ejecutarQuery(query.ToString()).Rows.Count > 0)
            {
                mensajeValidacion.AppendLine(string.Format(" El pasaporte {0} ya existe.", pasaporte.Text));
            };
        }

        /*Para listar segun un filtrado determinado*/

        public StringBuilder getAllInstances(string select)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat(select);
            return sentence;
        }

        public DataTable cargar_lista(StringBuilder sentence)
        {
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());
            return tabla;
        }

        public void appendASentencia(String control, StringBuilder sentence, String campo){

            if(control != ""){
                sentence.AppendFormat(" ({0} LIKE '%{1}%') AND ", campo, control);
            }

        }

       //public abstract void levantar(StringBuilder nombre, StringBuilder apellido, StringBuilder email, StringBuilder fechaNacimiento, StringBuilder dom_Calle, StringBuilder nro_Calle, StringBuilder piso, StringBuilder depto, StringBuilder nacionalidad, StringBuilder pasaporte, StringBuilder habilitado);
    
    }
}