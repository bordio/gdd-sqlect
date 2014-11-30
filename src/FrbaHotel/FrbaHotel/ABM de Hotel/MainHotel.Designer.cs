namespace FrbaHotel.ABM_de_Hotel
{
    partial class MainHotel
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Pais = new System.Windows.Forms.TextBox();
            this.Ciudad = new System.Windows.Forms.TextBox();
            this.CantidadEstrellas = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lstHoteles = new System.Windows.Forms.DataGridView();
            this.baja = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.Button();
            this.agregar = new System.Windows.Forms.Button();
            this.cerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstHoteles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lstHoteles);
            this.groupBox1.Controls.Add(this.baja);
            this.groupBox1.Controls.Add(this.modificar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 445);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hoteles";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Pais);
            this.groupBox2.Controls.Add(this.Ciudad);
            this.groupBox2.Controls.Add(this.CantidadEstrellas);
            this.groupBox2.Controls.Add(this.Nombre);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(18, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 104);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros";
            // 
            // Pais
            // 
            this.Pais.Location = new System.Drawing.Point(326, 61);
            this.Pais.Name = "Pais";
            this.Pais.Size = new System.Drawing.Size(100, 20);
            this.Pais.TabIndex = 15;
            // 
            // Ciudad
            // 
            this.Ciudad.Location = new System.Drawing.Point(326, 29);
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.Size = new System.Drawing.Size(100, 20);
            this.Ciudad.TabIndex = 14;
            // 
            // CantidadEstrellas
            // 
            this.CantidadEstrellas.Location = new System.Drawing.Point(138, 57);
            this.CantidadEstrellas.Name = "CantidadEstrellas";
            this.CantidadEstrellas.Size = new System.Drawing.Size(100, 20);
            this.CantidadEstrellas.TabIndex = 13;
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(138, 29);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(100, 20);
            this.Nombre.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Cantidad de estrellas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ciudad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Pais:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 38);
            this.button2.TabIndex = 7;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstHoteles
            // 
            this.lstHoteles.AllowUserToAddRows = false;
            this.lstHoteles.AllowUserToDeleteRows = false;
            this.lstHoteles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.lstHoteles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.lstHoteles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.lstHoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstHoteles.Location = new System.Drawing.Point(18, 129);
            this.lstHoteles.MultiSelect = false;
            this.lstHoteles.Name = "lstHoteles";
            this.lstHoteles.ReadOnly = true;
            this.lstHoteles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lstHoteles.Size = new System.Drawing.Size(574, 255);
            this.lstHoteles.TabIndex = 4;
            this.lstHoteles.SelectionChanged += new System.EventHandler(this.lstHoteles_SelectionChanged);
            // 
            // baja
            // 
            this.baja.Enabled = false;
            this.baja.Location = new System.Drawing.Point(137, 396);
            this.baja.Name = "baja";
            this.baja.Size = new System.Drawing.Size(103, 38);
            this.baja.TabIndex = 2;
            this.baja.Text = "Dar de baja";
            this.baja.UseVisualStyleBackColor = true;
            this.baja.Click += new System.EventHandler(this.baja_Click);
            // 
            // modificar
            // 
            this.modificar.Enabled = false;
            this.modificar.Location = new System.Drawing.Point(18, 396);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(103, 38);
            this.modificar.TabIndex = 1;
            this.modificar.Text = "Modificar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // agregar
            // 
            this.agregar.Location = new System.Drawing.Point(407, 463);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(92, 34);
            this.agregar.TabIndex = 3;
            this.agregar.Text = "Nuevo";
            this.agregar.UseVisualStyleBackColor = true;
            this.agregar.Click += new System.EventHandler(this.agregar_Click);
            // 
            // cerrar
            // 
            this.cerrar.Location = new System.Drawing.Point(527, 463);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(92, 34);
            this.cerrar.TabIndex = 3;
            this.cerrar.Text = "Volver";
            this.cerrar.UseVisualStyleBackColor = true;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click_1);
            // 
            // MainHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(631, 509);
            this.Controls.Add(this.cerrar);
            this.Controls.Add(this.agregar);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainHotel";
            this.Text = "MainHotel";
            this.Load += new System.EventHandler(this.MainHotel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstHoteles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Button baja;
        private System.Windows.Forms.Button agregar;
        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.DataGridView lstHoteles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Pais;
        private System.Windows.Forms.TextBox Ciudad;
        private System.Windows.Forms.TextBox CantidadEstrellas;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}