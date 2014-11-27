using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class ModificarHabitaciones : Form
    {
        public ModificarHabitaciones(string codigoReserva, string regimenModificado, string fechaDesde, string fechaHasta, bool cambioDeFecha, int idHotel,string usuarioDeSesion)
        {
            InitializeComponent();
            this.codigoReservaActual = codigoReserva;
            this.regimenModificadoActual = regimenModificado;
            this.fechaDesdeActual = fechaDesde;
            this.fechaHastaActual = fechaHasta;
            this.cambioDeFechaActual = cambioDeFecha;
            this.idHotelEnCuestion = idHotel;
            this.usuarioDeSesionActual = usuarioDeSesion;
            
        }

        AppModel_Reservas funcionesReservas = new AppModel_Reservas();
        string usuarioDeSesionActual;
        string codigoReservaActual;
        string regimenModificadoActual;
        string fechaDesdeActual;
        string fechaHastaActual;
        int idHotelEnCuestion;
        int cantidadHuespedes = 0;
        int contadorSimples;
        int contadorDobles;
        int contadorTriples;
        int contadorCuadruples;
        int contadorQuintuples;
        bool cambioDeFechaActual;

        List<Int32> listaHabitaciones = new List<int>();

        private void ModificarHabitaciones_Load(object sender, EventArgs e)
        {
                      
            textoDelRegimen.Text = string.Format("Está con el régimen:{0}", regimenModificadoActual);
            
            DataTable tablaHabAct = funcionesReservas.obtenerHabitacionesActualesDeReserva(codigoReservaActual);
            tablaHabitacionesActuales.DataSource = tablaHabAct.DefaultView;

            DataTable tablaHabDisp = new DataTable();
            tablaHabDisp = funcionesReservas.obtenerHabitacionesDisponibles(idHotelEnCuestion, fechaDesdeActual, fechaHastaActual);

            DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();
            checkBox.Name = "Seleccion";
            tablaHabitacionesDisponibles.Columns.Add(checkBox);

           
            if (cambioDeFechaActual)           
            
            {
                if (tablaHabDisp.Rows.Count > 0)
                {
                    tablaHabitacionesDisponibles.DataSource = tablaHabDisp.DefaultView;
                    
                    tablaHabitacionesDisponibles.Columns[1].ReadOnly = true;
                    tablaHabitacionesDisponibles.Columns[2].ReadOnly = true;
                    tablaHabitacionesDisponibles.Columns[3].ReadOnly = true;
                    tablaHabitacionesDisponibles.Columns[4].ReadOnly = true;
                }

                else
                {
                    MessageBox.Show(string.Format("No hay habitaciones disponibles desde el {0} hasta el {1}", fechaDesdeActual, fechaHastaActual));
                    this.Close();
                }
                
            }
                else
                {
                   foreach (DataRow fila in tablaHabAct.Rows)
                    {
                        tablaHabDisp.ImportRow(fila);
                    }  
                   tablaHabitacionesDisponibles.DataSource = tablaHabDisp.DefaultView;

                   tablaHabitacionesDisponibles.Columns[1].ReadOnly = true;
                   tablaHabitacionesDisponibles.Columns[2].ReadOnly = true;
                   tablaHabitacionesDisponibles.Columns[3].ReadOnly = true;
                   tablaHabitacionesDisponibles.Columns[4].ReadOnly = true;

                }        
    }

        private void botonContinuar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in tablaHabitacionesDisponibles.Rows)
            {
                if (Convert.ToBoolean(fila.Cells[0].Value))
                {
                    listaHabitaciones.Add(Convert.ToInt32(fila.Cells[3].Value.ToString()));

                    switch (fila.Cells[2].Value.ToString())
                    {
                        case "Base Simple": contadorSimples++;
                            break;
                        case "Base Doble": contadorDobles++;
                            break;
                        case "Base Triple": contadorTriples++;
                            break;
                        case "Base Cuadruple": contadorCuadruples++;
                            break;
                        case "King": contadorQuintuples++;
                            break;
                    }
                }
            }

            cantidadHuespedes = contadorSimples + contadorDobles * 2 + contadorTriples * 3 + contadorCuadruples * 4 + contadorQuintuples * 5;

            if ( (cantidadHuespedes > 0) & (numericCantHuespedes.Value>0) )
            {

                if (numericCantHuespedes.Value > cantidadHuespedes) 
                {
                    MessageBox.Show("Hay más huespedes que la cantidad máxima de alojamiento de habitaciones que eligio");
               }
                else
                {
                    /*Realizo cambios a la reserva en general*/
                    if (funcionesReservas.modificarReserva(codigoReservaActual, usuarioDeSesionActual, Convert.ToInt32(numericCantHuespedes.Value), regimenModificadoActual, fechaDesdeActual, fechaHastaActual))
                    {
                      /*Desocupo las habitaciones que tenía la reserva hasta este momento*/
                        funcionesReservas.desocuparHabitacionesDeReserva(codigoReservaActual);

                        /*Ocupo las habitaciones nuevas o modificadas*/

                        foreach (int numeroHabitacion in listaHabitaciones)
                        {
                            funcionesReservas.modificarHabitacionDeReserva(codigoReservaActual, numeroHabitacion, idHotelEnCuestion);
                        }
                        MessageBox.Show("Modificación exitosa");
                      
                        this.Close();
                    }

                }
                listaHabitaciones.Clear();
                contadorSimples = 0;
                contadorDobles = 0;
                contadorTriples = 0;
                contadorCuadruples = 0;
                contadorQuintuples = 0;


            }
            else
            { MessageBox.Show("Debe elegir una cantidad de huéspedes y alguna habitacion");

            listaHabitaciones.Clear();
            contadorSimples = 0;
            contadorDobles = 0;
            contadorTriples = 0;
            contadorCuadruples = 0;
            contadorQuintuples = 0;
            
            }
 
        
        }

        private void tablaHabitacionesDisponibles_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tablaHabitacionesDisponibles.IsCurrentCellDirty)
            {
                tablaHabitacionesDisponibles.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tablaHabitacionesDisponibles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (tablaHabitacionesDisponibles.Columns[e.ColumnIndex].Name == "Seleccion")
            {
                DataGridViewRow row = tablaHabitacionesDisponibles.Rows[e.ColumnIndex];

                DataGridViewCheckBoxCell cellSeleccion = row.Cells["Seleccion"] as DataGridViewCheckBoxCell;


            }


        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            tablaHabitacionesDisponibles.DataSource = null;
            tablaHabitacionesActuales.DataSource = null;
            this.Close();
        }
    }
}
