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
            this.lstHoteles = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
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
            this.agregar.Location = new System.Drawing.Point(266, 229);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(75, 23);
            this.agregar.TabIndex = 3;
            this.agregar.Text = "Agregar";
            this.agregar.UseVisualStyleBackColor = true;
            // 
            // baja
            // 
            this.baja.Location = new System.Drawing.Point(147, 229);
            this.baja.Name = "baja";
            this.baja.Size = new System.Drawing.Size(75, 23);
            this.baja.TabIndex = 2;
            this.baja.Text = "Dar de baja";
            this.baja.UseVisualStyleBackColor = true;
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(31, 229);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(75, 23);
            this.modificar.TabIndex = 1;
            this.modificar.Text = "Modificar";
            this.modificar.UseVisualStyleBackColor = true;
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
            this.lstHoteles.FormattingEnabled = true;
            this.lstHoteles.Location = new System.Drawing.Point(15, 19);
            this.lstHoteles.MultiColumn = true;
            this.lstHoteles.Name = "lstHoteles";
            this.lstHoteles.Size = new System.Drawing.Size(347, 199);
            this.lstHoteles.TabIndex = 3;
            // 
            // MainHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 333);
            this.Controls.Add(this.cerrar);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainHotel";
            this.Text = "MainHotel";
            this.Load += new System.EventHandler(this.MainHotel_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Button baja;
        private System.Windows.Forms.Button agregar;
        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.ListBox lstHoteles;
    }
}