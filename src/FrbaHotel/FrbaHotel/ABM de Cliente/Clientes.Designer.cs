namespace FrbaHotel.ABM_de_Cliente
{
    partial class Clientes
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
            this.btAlta = new System.Windows.Forms.Button();
            this.btModifBaja = new System.Windows.Forms.Button();
            this.btSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btAlta
            // 
            this.btAlta.Location = new System.Drawing.Point(150, 54);
            this.btAlta.Name = "btAlta";
            this.btAlta.Size = new System.Drawing.Size(226, 72);
            this.btAlta.TabIndex = 0;
            this.btAlta.Text = "Crear Cliente Nuevo";
            this.btAlta.UseVisualStyleBackColor = true;
            this.btAlta.Click += new System.EventHandler(this.btAlta_Click);
            // 
            // btModifBaja
            // 
            this.btModifBaja.Location = new System.Drawing.Point(150, 132);
            this.btModifBaja.Name = "btModifBaja";
            this.btModifBaja.Size = new System.Drawing.Size(226, 72);
            this.btModifBaja.TabIndex = 1;
            this.btModifBaja.Text = "Modificacion de datos / Habilitacion de Clientes";
            this.btModifBaja.UseVisualStyleBackColor = true;
            this.btModifBaja.Click += new System.EventHandler(this.btModifBaja_Click);
            // 
            // btSalir
            // 
            this.btSalir.Location = new System.Drawing.Point(451, 218);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(103, 43);
            this.btSalir.TabIndex = 2;
            this.btSalir.Text = "SALIR";
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 273);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.btModifBaja);
            this.Controls.Add(this.btAlta);
            this.Name = "Clientes";
            this.Text = "Gestionar Clientes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAlta;
        private System.Windows.Forms.Button btModifBaja;
        private System.Windows.Forms.Button btSalir;
    }
}