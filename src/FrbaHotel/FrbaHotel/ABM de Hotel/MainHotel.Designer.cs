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
            this.agregar = new System.Windows.Forms.Button();
            this.baja = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.Button();
            this.cerrar = new System.Windows.Forms.Button();
            this.lstHoteles = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstHoteles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstHoteles);
            this.groupBox1.Controls.Add(this.agregar);
            this.groupBox1.Controls.Add(this.baja);
            this.groupBox1.Controls.Add(this.modificar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 267);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hoteles";
            // 
            // agregar
            // 
            this.agregar.Location = new System.Drawing.Point(262, 219);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(75, 23);
            this.agregar.TabIndex = 3;
            this.agregar.Text = "Agregar";
            this.agregar.UseVisualStyleBackColor = true;
            this.agregar.Click += new System.EventHandler(this.agregar_Click);
            // 
            // baja
            // 
            this.baja.Location = new System.Drawing.Point(146, 219);
            this.baja.Name = "baja";
            this.baja.Size = new System.Drawing.Size(75, 23);
            this.baja.TabIndex = 2;
            this.baja.Text = "Dar de baja";
            this.baja.UseVisualStyleBackColor = true;
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(31, 219);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(75, 23);
            this.modificar.TabIndex = 1;
            this.modificar.Text = "Modificar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // cerrar
            // 
            this.cerrar.Location = new System.Drawing.Point(314, 298);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(75, 23);
            this.cerrar.TabIndex = 3;
            this.cerrar.Text = "Salir";
            this.cerrar.UseVisualStyleBackColor = true;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click_1);
            // 
            // lstHoteles
            // 
            this.lstHoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstHoteles.Location = new System.Drawing.Point(31, 29);
            this.lstHoteles.Name = "lstHoteles";
            this.lstHoteles.Size = new System.Drawing.Size(340, 171);
            this.lstHoteles.TabIndex = 4;
            this.lstHoteles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lstHoteles_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Mostrar Hoteles";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 333);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cerrar);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainHotel";
            this.Text = "MainHotel";
            this.Load += new System.EventHandler(this.MainHotel_Load);
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.Button button1;
    }
}