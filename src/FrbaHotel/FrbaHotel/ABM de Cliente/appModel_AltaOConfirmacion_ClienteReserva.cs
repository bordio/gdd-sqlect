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
    class appModel_AltaOConfirmacion_ClienteReserva : AppModel_Alta_Cliente
    {
        private Conexion sqlconexion = Conexion.Instance;
        AppModel_Reservas funcionesReservas = new AppModel_Reservas();
        public int idReservaDelCliente;
        RegistroCliente formularioAnterior;

        public appModel_AltaOConfirmacion_ClienteReserva(int idReserva, RegistroCliente formularioAnterior) //Para dar de alta un cliente desde el proceso de Reserva. En esta instancia estamos dentro de una Transaccion
        {
            this.idReservaDelCliente = idReserva;
            this.formularioAnterior = formularioAnterior;
        }

        public override void abmlCliente(string nombre, string apellido, string mail, string dom_Calle, string nro_Calle, string piso, string depto, string fecha_Nac, string nacionalidad, string documento_Nro, int idReserva, string tipo_documento, string telefono, string localidad, ComboBox pais)
        {
            base.abmlCliente(nombre, apellido, mail, dom_Calle, nro_Calle, piso, depto, fecha_Nac, nacionalidad, documento_Nro, idReserva, tipo_documento, telefono, localidad, pais);
            Conexion.Instance.ejecutarQuery("COMMIT");

            MessageBox.Show("Alta exitosa","Cliente registrado",MessageBoxButtons.OK,MessageBoxIcon.Information);
            MessageBox.Show(funcionesReservas.obtenerCodigoReserva(idReserva), "Código para futuras modificaciones",MessageBoxButtons.OK,MessageBoxIcon.Information);
            formularioAnterior.Cerrate(false);
        }

        public override void Accionarbt_ConfirmarReserva(string emailSeleccionado, int documentoSeleccionado, ModificacionMain_Cliente modificacionMain)
        {
            FrbaHotel.Generar_Modificar_Reserva.ConfirmarClienteReserva formConfirmarCliente = new FrbaHotel.Generar_Modificar_Reserva.ConfirmarClienteReserva(emailSeleccionado, documentoSeleccionado, idReservaDelCliente, modificacionMain);
            formConfirmarCliente.ShowDialog();
        }
    }
}