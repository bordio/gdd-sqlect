namespace FrbaHotel.ABM_de_Habitacion
{
    partial class FormBusqueda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btAccion = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.lstHabitaciones = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Limpiar = new System.Windows.Forms.Button();
            this.Filtrar = new System.Windows.Forms.Button();
            this.piso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nro_habitacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbHoteles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstHabitaciones)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btAccion);
            this.groupBox1.Controls.Add(this.btVolver);
            this.groupBox1.Controls.Add(this.lstHabitaciones);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 400);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Habitaciones";
            // 
            // btAccion
            // 
            this.btAccion.Location = new System.Drawing.Point(380, 352);
            this.btAccion.Name = "btAccion";
            this.btAccion.Size = new System.Drawing.Size(112, 33);
            this.btAccion.TabIndex = 3;
            this.btAccion.Text = "Modificar";
            this.btAccion.UseVisualStyleBackColor = true;
            this.btAccion.Click += new System.EventHandler(this.btAccion_Click);
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(506, 352);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(112, 33);
            this.btVolver.TabIndex = 2;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstHabitaciones
            // 
            this.lstHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstHabitaciones.Location = new System.Drawing.Point(20, 137);
            this.lstHabitaciones.Name = "lstHabitaciones";
            this.lstHabitaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lstHabitaciones.Size = new System.Drawing.Size(588, 200);
            this.lstHabitaciones.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbTipoHabitacion);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Limpiar);
            this.groupBox2.Controls.Add(this.Filtrar);
            this.groupBox2.Controls.Add(this.piso);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nro_habitacion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbHoteles);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(20, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 109);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros";
            // 
            // cmbTipoHabitacion
            // 
            this.cmbTipoHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoHabitacion.FormattingEnabled = true;
            this.cmbTipoHabitacion.Location = new System.Drawing.Point(340, 62);
            this.cmbTipoHabitacion.Name = "cmbTipoHabitacion";
            this.cmbTipoHabitacion.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoHabitacion.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tipo de habitacion";
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(482, 16);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(106, 35);
            this.Limpiar.TabIndex = 7;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // Filtrar
            // 
            this.Filtrar.Location = new System.Drawing.Point(482, 62);
            this.Filtrar.Name = "Filtrar";
            this.Filtrar.Size = new System.Drawing.Size(106, 35);
            this.Filtrar.TabIndex = 6;
            this.Filtrar.Text = "Buscar";
            this.Filtrar.UseVisualStyleBackColor = true;
            this.Filtrar.Click += new System.EventHandler(this.Filtrar_Click);
            // 
            // piso
            // 
            this.piso.Location = new System.Drawing.Point(389, 23);
            this.piso.Name = "piso";
            this.piso.Size = new System.Drawing.Size(72, 20);
            this.piso.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Piso";
            // 
            // nro_habitacion
            // 
            this.nro_habitacion.Location = new System.Drawing.Point(131, 63);
            this.nro_habitacion.Name = "nro_habitacion";
            this.nro_habitacion.Size = new System.Drawing.Size(88, 20);
            this.nro_habitacion.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Numero de habitacion";
            // 
            // cmbHoteles
            // 
            this.cmbHoteles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoteles.FormattingEnabled = true;
            this.cmbHoteles.Location = new System.Drawing.Point(54, 23);
            this.cmbHoteles.Name = "cmbHoteles";
            this.cmbHoteles.Size = new System.Drawing.Size(271, 21);
            this.cmbHoteles.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotel";
            // 
            // FormBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 417);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormBusqueda";
            this.Text = "FormBusqueda";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstHabitaciones)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView lstHabitaciones;
        private System.Windows.Forms.Button btVolver;
        public System.Windows.Forms.Button btAccion;
        private System.Windows.Forms.Button Filtrar;
        private System.Windows.Forms.TextBox nro_habitacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox piso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbHoteles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Limpiar;
        private System.Windows.Forms.ComboBox cmbTipoHabitacion;
        private System.Windows.Forms.Label label4;
    }
}