using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente {

    public abstract class AppModel_Base_Cliente {

        public DataTable rowCliente = new DataTable();
        private Conexion sqlconexion = Conexion.Instance;

        public abstract void abmlCliente(string nombre, string apellido, string mail, string dom_Calle, string nro_Calle, string piso, string depto, string fecha_Nac, string nacionalidad, string documento_Nro, int idReserva, string tipodocumento, string telefono);
        
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

        public bool validarNoVaciocb(string comboItem, StringBuilder mensajeValidacion)
        {
            if (string.IsNullOrEmpty(comboItem))
            {
                mensajeValidacion.AppendLine(string.Format(" El campo {0} no puede estar en blanco.", comboItem));
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

        public virtual void validarEmail(Control mail, StringBuilder mensajeValidacion)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("SELECT * FROM SQLECT.Clientes WHERE mail='{0}'", mail.Text);
            if (this.sqlconexion.ejecutarQuery(query.ToString()).Rows.Count > 0)
            {
                mensajeValidacion.AppendLine(string.Format(" El email {0} ya existe.", mail.Text));
            };
        }

        public virtual void validarDocumento(Control documento, string tipo, StringBuilder mensajeValidacion)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("SELECT * FROM SQLECT.Clientes WHERE documento_Nro='{0}' AND tipoDocumento='{1}'", documento.Text, tipo);
            if (this.sqlconexion.ejecutarQuery(query.ToString()).Rows.Count > 0)
            {
                mensajeValidacion.AppendLine(string.Format(" El documento {0} ya existe.", documento.Text));
            };
        }

        public virtual void validarDocumento(Control documento, StringBuilder mensajeValidacion) { }

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

            if((control != "") || (control != null)){
                sentence.AppendFormat(" ({0} LIKE '%{1}%') AND ", campo, control);
            }

        }

        public void appendASentencia(ComboBox control, StringBuilder sentence, String campo)
        {

            if ((control.SelectedItem != null))
            {
                sentence.AppendFormat(" ({0} LIKE '%{1}%') AND ", campo, control.ToString());
            }

        }

        public abstract void levantar(StringBuilder sentence);
    
    }
}