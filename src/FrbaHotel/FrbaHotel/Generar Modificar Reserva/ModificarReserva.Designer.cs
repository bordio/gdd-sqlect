namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class ModificarReserva
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
            this.botonConsultarDispo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.botonSeleccionarH = new System.Windows.Forms.Button();
            this.botonSeleccionarD = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fechaHasta = new System.Windows.Forms.TextBox();
            this.fechaDesde = new System.Windows.Forms.TextBox();
            this.checkCambiarFechas = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkCambiarRegimen = new System.Windows.Forms.CheckBox();
            this.botonPreciosRegimen = new System.Windows.Forms.Button();
            this.comboRegimen = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboRegimen);
            this.groupBox1.Controls.Add(this.botonPreciosRegimen);
            this.groupBox1.Controls.Add(this.checkCambiarRegimen);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.checkCambiarFechas);
            this.groupBox1.Controls.Add(this.botonConsultarDispo);
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
            this.groupBox1.Location = new System.Drawing.Point(37, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(828, 397);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reserva";
            // 
            // botonConsultarDispo
            // 
            this.botonConsultarDispo.Enabled = false;
            this.botonConsultarDispo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonConsultarDispo.Location = new System.Drawing.Point(406, 140);
            this.botonConsultarDispo.Name = "botonConsultarDispo";
            this.botonConsultarDispo.Size = new System.Drawing.Size(128, 52);
            this.botonConsultarDispo.TabIndex = 2;
            this.botonConsultarDispo.Text = "Consultar disponibilidad";
            this.botonConsultarDispo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tipo de régimen actual";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(541, 30);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 7;
            this.monthCalendar.Visible = false;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // botonSeleccionarH
            // 
            this.botonSeleccionarH.Enabled = false;
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
            this.botonSeleccionarD.Enabled = false;
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
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha";
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
            // checkCambiarFechas
            // 
            this.checkCambiarFechas.AutoSize = true;
            this.checkCambiarFechas.Location = new System.Drawing.Point(39, 157);
            this.checkCambiarFechas.Name = "checkCambiarFechas";
            this.checkCambiarFechas.Size = new System.Drawing.Size(121, 20);
            this.checkCambiarFechas.TabIndex = 27;
            this.checkCambiarFechas.Text = "Cambiar fechas";
            this.checkCambiarFechas.UseVisualStyleBackColor = true;
            this.checkCambiarFechas.CheckedChanged += new System.EventHandler(this.checkCambiarFechas_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(218, 265);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(172, 22);
            this.textBox1.TabIndex = 28;
            // 
            // checkCambiarRegimen
            // 
            this.checkCambiarRegimen.AutoSize = true;
            this.checkCambiarRegimen.Location = new System.Drawing.Point(39, 327);
            this.checkCambiarRegimen.Name = "checkCambiarRegimen";
            this.checkCambiarRegimen.Size = new System.Drawing.Size(130, 20);
            this.checkCambiarRegimen.TabIndex = 29;
            this.checkCambiarRegimen.Text = "Cambiar regimen";
            this.checkCambiarRegimen.UseVisualStyleBackColor = true;
            this.checkCambiarRegimen.CheckedChanged += new System.EventHandler(this.checkCambiarRegimen_CheckedChanged);
            // 
            // botonPreciosRegimen
            // 
            this.botonPreciosRegimen.Enabled = false;
            this.botonPreciosRegimen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonPreciosRegimen.Location = new System.Drawing.Point(406, 271);
            this.botonPreciosRegimen.Name = "botonPreciosRegimen";
            this.botonPreciosRegimen.Size = new System.Drawing.Size(128, 52);
            this.botonPreciosRegimen.TabIndex = 30;
            this.botonPreciosRegimen.Text = "Consultar precios del regimen";
            this.botonPreciosRegimen.UseVisualStyleBackColor = true;
            // 
            // comboRegimen
            // 
            this.comboRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRegimen.Enabled = false;
            this.comboRegimen.FormattingEnabled = true;
            this.comboRegimen.Location = new System.Drawing.Point(218, 323);
            this.comboRegimen.Name = "comboRegimen";
            this.comboRegimen.Size = new System.Drawing.Size(172, 24);
            this.comboRegimen.TabIndex = 31;
            // 
            // ModificarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 442);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificarReserva";
            this.Text = "Modificar Reserva";
            this.Load += new System.EventHandler(this.ModificarReserva_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botonConsultarDispo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Button botonSeleccionarH;
        private System.Windows.Forms.Button botonSeleccionarD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fechaHasta;
        private System.Windows.Forms.TextBox fechaDesde;
        private System.Windows.Forms.CheckBox checkCambiarFechas;
        private System.Windows.Forms.Button botonPreciosRegimen;
        private System.Windows.Forms.CheckBox checkCambiarRegimen;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboRegimen;

    }
}