using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.ABM_de_Cliente
{
    class AppModel_Agregar_Huesped : AppModel_Alta_Cliente
    {
        public int huespedes;
        ModificacionMain_Cliente formulario;
        public List<Int32> idHuespedes = new List<Int32>();

        public override void abmlCliente(string nombre, string apellido, string mail, string dom_Calle, string nro_Calle, string piso, string depto, string fecha_Nac, string nacionalidad, string documento_Nro, int idReserva, string tipo_documento, string telefono, string localidad, ComboBox pais)
        {
            base.abmlCliente(nombre, apellido, mail, dom_Calle, nro_Calle, piso, depto, fecha_Nac, nacionalidad, documento_Nro, idReserva, tipo_documento, telefono, localidad, pais);
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT id_cliente FROM SQLECT.Clientes WHERE mail='{0}' AND documento_Nro='{1}' AND tipodocumento='{2}' ", mail.ToString(), documento_Nro.ToString(), tipo_documento.ToString());
            this.levantar(sentence, 0);
            formulario.btQuitar_Huesped.Enabled = true;
            this.Accionarbt_AgregarHuesped(Int32.Parse(idCliente.ToString()));
        }

        public AppModel_Agregar_Huesped(int cantHuespedes, ModificacionMain_Cliente formulario)
        {
            this.huespedes = cantHuespedes;
            this.formulario = formulario;
        }



        public override bool quitarIdHuesped(Int32 id)
        {
            if (idHuespedYaIngresado(id))
            {
                this.idHuespedes.Remove(id);
                this.formulario.desmarcarHuesped(id);
                ++huespedes;
                return true;
            }
            else {
                MessageBox.Show("No puede quitar a un Huesped aun no ingreso en el actual checkIn", "Ingreso de Huespedes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        public override void Accionarbt_AgregarHuesped(Int32 idCliente)
        {

            if (!idHuespedYaIngresado(idCliente))
            {
                formulario.cambiarLabelHuespedes(--huespedes);
                this.idHuespedes.Add(idCliente);
                
                formulario.comprobarCantidadHuespedes();
            }
            else { MessageBox.Show("Ya ha ingresado a dicho Huesped en el actual checkIn", "Ingreso de Huespedes", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        public override bool idHuespedYaIngresado(Int32 idCliente)
        {
            if (this.idHuespedes.Contains(idCliente))
            {
                return true;
            }
            else return false;
        }

        public override void Accionarbt_GuardarHuesped(StringBuilder id)
        {
            this.idCliente = Int32.Parse(id.ToString());
            this.Accionarbt_AgregarHuesped(idCliente);
            formulario.remarcarHuesped(idCliente);
        }


    }
}