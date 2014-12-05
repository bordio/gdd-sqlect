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

        public AppModel_Agregar_Huesped(int cantHuespedes, ModificacionMain_Cliente formulario)
        {
            this.huespedes = cantHuespedes;
            this.formulario = formulario;
        }

        public override void Accionarbt_AgregarHuesped()
        {
            formulario.cambiarLabelHuespedes(--huespedes);
        }

    }
}