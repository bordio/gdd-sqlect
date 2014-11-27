using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;





namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class ElegirHabitaciones : Form
    {
        public ElegirHabitaciones(int idHotelEnCuestion, string fechaDesde, string fechaHasta, int cantSimples, int cantDobles, int cantTriples, int cantCuadruples, int cantQuintuples,string usuarioDeSesion,string regimenElegido,int cantHuespedes)
        {
            InitializeComponent();
            this.idHotelActual = idHotelEnCuestion;
            this.fechaDesdeActual = fechaDesde;
            this.fechaHastaActual = fechaHasta;
            this.cantSimples = cantSimples;
            this.cantDobles = cantDobles;
            this.cantTriples = cantTriples;
            this.cantCuadruples = cantCuadruples;
            this.cantQuintuples = cantQuintuples;
            this.usuarioDeSesion = usuarioDeSesion;
            this.regimenActual = regimenElegido;
            this.cantHuespedes = cantHuespedes;
            
            
        }

        AppModel_Reservas funcionesReservas = new AppModel_Reservas();


        int contadorSimples = 0;
        int contadorDobles = 0;
        int contadorTriples = 0;
        int contadorCuadruples = 0;
        int contadorQuintuples = 0;
        
        int cantSimples;
        int cantDobles;
        int cantTriples;
        int cantCuadruples;
        int cantQuintuples;
        int cantHuespedes;
        int idHotelActual;
        string fechaDesdeActual;
        string fechaHastaActual;
        string usuarioDeSesion;
        string regimenActual;

        List<Int32> listaHabitaciones = new List<int>();
        StringBuilder mensajePrueba = new StringBuilder();

        private void ElegirHabitaciones_Load(object sender, EventArgs e)
        {

          DataTable tablaHabitaciones = funcionesReservas.obtenerHabitacionesDisponibles(idHotelActual, fechaDesdeActual, fechaHastaActual);

          DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();
          checkBox.Name="Seleccion";
          tablaPruebaHabitaciones.Columns.Add(checkBox);

          tablaPruebaHabitaciones.DataSource = tablaHabitaciones.DefaultView;

          tablaPruebaHabitaciones.Columns[1].ReadOnly = true;
          tablaPruebaHabitaciones.Columns[2].ReadOnly = true;
          tablaPruebaHabitaciones.Columns[3].ReadOnly = true;
          tablaPruebaHabitaciones.Columns[4].ReadOnly = true;
          tablaPruebaHabitaciones.Columns[5].ReadOnly = true;
        }

        private void botonConfirmarReserva_Click(object sender, EventArgs e)
        {
            TimeSpan difFech = DateTime.Parse(fechaHastaActual) - DateTime.Parse(fechaDesdeActual);
            int cantNoches = difFech.Days + 1; /* Sacamos la cantidad de noches*/

            foreach (DataGridViewRow row in tablaPruebaHabitaciones.Rows)
            {


                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    listaHabitaciones.Add(Convert.ToInt32(row.Cells[3].Value.ToString()));

                    switch (row.Cells[2].Value.ToString())
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

            if ((contadorSimples == cantSimples) & (contadorDobles == cantDobles) & (contadorTriples == cantTriples) & (contadorCuadruples == cantCuadruples & contadorQuintuples == cantQuintuples))
            {
                int idReserva;

                bool reservaHecha = funcionesReservas.realizarReserva(fechaDesdeActual, cantNoches, usuarioDeSesion, regimenActual, idHotelActual,cantHuespedes);


                if (reservaHecha)
                {
                    idReserva = funcionesReservas.obtenerIdReserva();

                    foreach (int numeroHabitacion in listaHabitaciones)
                    {
                        funcionesReservas.reservarHabitacion(idHotelActual, numeroHabitacion, idReserva, fechaDesdeActual, cantNoches);
                    }

                    string codigoReserva = funcionesReservas.generarCodigoReserva(); /*Generamos un código alfanumérico aleatorio de 8 caracteres*/
                    
                    while(funcionesReservas.verificarCodigoReservaRepetido(codigoReserva))
                    {
                    codigoReserva= funcionesReservas.generarCodigoReserva();
                    }

                    funcionesReservas.adjuntarCodigoALaReserva(idReserva, codigoReserva); /* Asignamos el código a la reserva*/

                    MessageBox.Show("Reserva hecha correctamente");
                    this.Close();

                    FrbaHotel.Generar_Modificar_Reserva.RegistroCliente formRegistroCliente = new FrbaHotel.Generar_Modificar_Reserva.RegistroCliente(idReserva);
                    formRegistroCliente.Show();
                }
            }
            else
                MessageBox.Show("La cantidad de habitaciones elegidas difieren de las cantidades que selecciono al comienzo de la reserva");

                listaHabitaciones.Clear();
                contadorSimples = 0;
                contadorDobles = 0;
                contadorTriples = 0;
                contadorCuadruples = 0;
                contadorQuintuples = 0;
                
            
        }

        private void tablaPruebaHabitaciones_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tablaPruebaHabitaciones.IsCurrentCellDirty)

             {
                tablaPruebaHabitaciones.CommitEdit(DataGridViewDataErrorContexts.Commit);
             }
        }

        private void tablaPruebaHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (tablaPruebaHabitaciones.Columns[e.ColumnIndex].Name == "Seleccion")
            {
                DataGridViewRow row = tablaPruebaHabitaciones.Rows[e.ColumnIndex];

                DataGridViewCheckBoxCell cellSeleccion = row.Cells["Seleccion"] as DataGridViewCheckBoxCell;                  
                        
            }
                              
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }

}
