namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class GenerarReserva
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.botonSeleccionarH = new System.Windows.Forms.Button();
            this.botonSeleccionarD = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fechaHasta = new System.Windows.Forms.TextBox();
            this.fechaDesde = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboRegimen = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cantidadQuíntuples = new System.Windows.Forms.NumericUpDown();
            this.cantidadCuádruples = new System.Windows.Forms.NumericUpDown();
            this.cantidadTriples = new System.Windows.Forms.NumericUpDown();
            this.cantidadDobles = new System.Windows.Forms.NumericUpDown();
            this.cantidadSimples = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cantidadHuéspedes = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadQuíntuples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadCuádruples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadTriples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadDobles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadSimples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadHuéspedes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cantidadHuéspedes);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cantidadSimples);
            this.groupBox1.Controls.Add(this.cantidadDobles);
            this.groupBox1.Controls.Add(this.cantidadTriples);
            this.groupBox1.Controls.Add(this.cantidadCuádruples);
            this.groupBox1.Controls.Add(this.cantidadQuíntuples);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboRegimen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.monthCalendar);
            this.groupBox1.Controls.Add(this.botonSeleccionarH);
            this.groupBox1.Controls.Add(this.botonSeleccionarD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fechaHasta);
            this.groupBox1.Controls.Add(this.fechaDesde);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(882, 424);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reserva";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(405, 15);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 7;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // botonSeleccionarH
            // 
            this.botonSeleccionarH.Location = new System.Drawing.Point(266, 95);
            this.botonSeleccionarH.Name = "botonSeleccionarH";
            this.botonSeleccionarH.Size = new System.Drawing.Size(94, 23);
            this.botonSeleccionarH.TabIndex = 6;
            this.botonSeleccionarH.Text = "Seleccionar";
            this.botonSeleccionarH.UseVisualStyleBackColor = true;
            this.botonSeleccionarH.Click += new System.EventHandler(this.botonSeleccionarH_Click);
            // 
            // botonSeleccionarD
            // 
            this.botonSeleccionarD.Location = new System.Drawing.Point(266, 51);
            this.botonSeleccionarD.Name = "botonSeleccionarD";
            this.botonSeleccionarD.Size = new System.Drawing.Size(94, 23);
            this.botonSeleccionarD.TabIndex = 5;
            this.botonSeleccionarD.Text = "Seleccionar";
            this.botonSeleccionarD.UseVisualStyleBackColor = true;
            this.botonSeleccionarD.Click += new System.EventHandler(this.botonSeleccionarD_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fechas";
            // 
            // fechaHasta
            // 
            this.fechaHasta.Enabled = false;
            this.fechaHasta.Location = new System.Drawing.Point(110, 95);
            this.fechaHasta.Name = "fechaHasta";
            this.fechaHasta.Size = new System.Drawing.Size(120, 22);
            this.fechaHasta.TabIndex = 1;
            // 
            // fechaDesde
            // 
            this.fechaDesde.Enabled = false;
            this.fechaDesde.Location = new System.Drawing.Point(110, 52);
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Size = new System.Drawing.Size(120, 22);
            this.fechaDesde.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tipo de régimen";
            // 
            // comboRegimen
            // 
            this.comboRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRegimen.FormattingEnabled = true;
            this.comboRegimen.Location = new System.Drawing.Point(188, 366);
            this.comboRegimen.Name = "comboRegimen";
            this.comboRegimen.Size = new System.Drawing.Size(172, 24);
            this.comboRegimen.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tipo de habitación";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Cantidad de huéspedes";
            // 
            // cantidadQuíntuples
            // 
            this.cantidadQuíntuples.Location = new System.Drawing.Point(291, 266);
            this.cantidadQuíntuples.Name = "cantidadQuíntuples";
            this.cantidadQuíntuples.Size = new System.Drawing.Size(33, 22);
            this.cantidadQuíntuples.TabIndex = 16;
            // 
            // cantidadCuádruples
            // 
            this.cantidadCuádruples.Location = new System.Drawing.Point(291, 237);
            this.cantidadCuádruples.Name = "cantidadCuádruples";
            this.cantidadCuádruples.Size = new System.Drawing.Size(33, 22);
            this.cantidadCuádruples.TabIndex = 17;
            // 
            // cantidadTriples
            // 
            this.cantidadTriples.Location = new System.Drawing.Point(291, 205);
            this.cantidadTriples.Name = "cantidadTriples";
            this.cantidadTriples.Size = new System.Drawing.Size(33, 22);
            this.cantidadTriples.TabIndex = 18;
            // 
            // cantidadDobles
            // 
            this.cantidadDobles.Location = new System.Drawing.Point(291, 177);
            this.cantidadDobles.Name = "cantidadDobles";
            this.cantidadDobles.Size = new System.Drawing.Size(33, 22);
            this.cantidadDobles.TabIndex = 19;
            // 
            // cantidadSimples
            // 
            this.cantidadSimples.Location = new System.Drawing.Point(291, 149);
            this.cantidadSimples.Name = "cantidadSimples";
            this.cantidadSimples.Size = new System.Drawing.Size(33, 22);
            this.cantidadSimples.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Simple";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(146, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Doble";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(146, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Triple";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(146, 239);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "Cuádruple";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(146, 268);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "Quíntuple";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(453, 268);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(294, 16);
            this.label12.TabIndex = 26;
            this.label12.Text = "Elija la cantidad de habitaciones que va a tomar";
            // 
            // cantidadHuéspedes
            // 
            this.cantidadHuéspedes.Location = new System.Drawing.Point(220, 311);
            this.cantidadHuéspedes.Name = "cantidadHuéspedes";
            this.cantidadHuéspedes.Size = new System.Drawing.Size(50, 22);
            this.cantidadHuéspedes.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(34, 464);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(612, 464);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 52);
            this.button2.TabIndex = 2;
            this.button2.Text = "Consultar disponibilidad";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // GenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 528);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenerarReserva";
            this.Text = "GenerarReserva";
            this.Load += new System.EventHandler(this.GenerarReserva_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadQuíntuples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadCuádruples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadTriples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadDobles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadSimples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadHuéspedes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fechaHasta;
        private System.Windows.Forms.TextBox fechaDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Button botonSeleccionarH;
        private System.Windows.Forms.Button botonSeleccionarD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboRegimen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown cantidadSimples;
        private System.Windows.Forms.NumericUpDown cantidadDobles;
        private System.Windows.Forms.NumericUpDown cantidadTriples;
        private System.Windows.Forms.NumericUpDown cantidadCuádruples;
        private System.Windows.Forms.NumericUpDown cantidadQuíntuples;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown cantidadHuéspedes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}