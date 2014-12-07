namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class ModificarHabitaciones
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tablaHabitacionesDisponibles = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericCantHuespedes = new System.Windows.Forms.NumericUpDown();
            this.botonContinuar = new System.Windows.Forms.Button();
            this.textoDelRegimen = new System.Windows.Forms.Label();
            this.botonVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaHabitacionesDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantHuespedes)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaHabitacionesDisponibles
            // 
            this.tablaHabitacionesDisponibles.AllowUserToAddRows = false;
            this.tablaHabitacionesDisponibles.AllowUserToDeleteRows = false;
            this.tablaHabitacionesDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tablaHabitacionesDisponibles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tablaHabitacionesDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaHabitacionesDisponibles.Location = new System.Drawing.Point(15, 60);
            this.tablaHabitacionesDisponibles.Name = "tablaHabitacionesDisponibles";
            this.tablaHabitacionesDisponibles.Size = new System.Drawing.Size(653, 291);
            this.tablaHabitacionesDisponibles.TabIndex = 1;
            this.tablaHabitacionesDisponibles.CurrentCellDirtyStateChanged += new System.EventHandler(this.tablaHabitacionesDisponibles_CurrentCellDirtyStateChanged);
            this.tablaHabitacionesDisponibles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaHabitacionesDisponibles_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(590, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione las nuevas habitaciones, incluyendo o no las que tenía antes, que va a" +
                " tomar.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cantidad de huéspedes";
            // 
            // numericCantHuespedes
            // 
            this.numericCantHuespedes.Location = new System.Drawing.Point(180, 402);
            this.numericCantHuespedes.Name = "numericCantHuespedes";
            this.numericCantHuespedes.Size = new System.Drawing.Size(59, 20);
            this.numericCantHuespedes.TabIndex = 5;
            // 
            // botonContinuar
            // 
            this.botonContinuar.Location = new System.Drawing.Point(721, 444);
            this.botonContinuar.Name = "botonContinuar";
            this.botonContinuar.Size = new System.Drawing.Size(120, 47);
            this.botonContinuar.TabIndex = 6;
            this.botonContinuar.Text = "Realizar modificación";
            this.botonContinuar.UseVisualStyleBackColor = true;
            this.botonContinuar.Click += new System.EventHandler(this.botonContinuar_Click);
            // 
            // textoDelRegimen
            // 
            this.textoDelRegimen.AutoSize = true;
            this.textoDelRegimen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoDelRegimen.Location = new System.Drawing.Point(389, 406);
            this.textoDelRegimen.Name = "textoDelRegimen";
            this.textoDelRegimen.Size = new System.Drawing.Size(135, 16);
            this.textoDelRegimen.TabIndex = 7;
            this.textoDelRegimen.Text = "Tiene como régimen:";
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(12, 444);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(120, 47);
            this.botonVolver.TabIndex = 9;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // ModificarHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 495);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.textoDelRegimen);
            this.Controls.Add(this.botonContinuar);
            this.Controls.Add(this.numericCantHuespedes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tablaHabitacionesDisponibles);
            this.Name = "ModificarHabitaciones";
            this.Text = "Modificacion de Habitaciones";
            this.Load += new System.EventHandler(this.ModificarHabitaciones_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModificarHabitaciones_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.tablaHabitacionesDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantHuespedes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaHabitacionesDisponibles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericCantHuespedes;
        private System.Windows.Forms.Button botonContinuar;
        private System.Windows.Forms.Label textoDelRegimen;
        private System.Windows.Forms.Button botonVolver;
    }
}