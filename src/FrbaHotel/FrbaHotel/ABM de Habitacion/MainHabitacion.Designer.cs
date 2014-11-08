namespace FrbaHotel.ABM_de_Habitacion
{
    partial class MainHabitacion
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
            this.btVolver = new System.Windows.Forms.Button();
            this.btAlta = new System.Windows.Forms.Button();
            this.btBaja = new System.Windows.Forms.Button();
            this.btModificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(156, 110);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(90, 49);
            this.btVolver.TabIndex = 0;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // btAlta
            // 
            this.btAlta.Location = new System.Drawing.Point(28, 31);
            this.btAlta.Name = "btAlta";
            this.btAlta.Size = new System.Drawing.Size(90, 49);
            this.btAlta.TabIndex = 1;
            this.btAlta.Text = "Alta";
            this.btAlta.UseVisualStyleBackColor = true;
            this.btAlta.Click += new System.EventHandler(this.btAlta_Click);
            // 
            // btBaja
            // 
            this.btBaja.Location = new System.Drawing.Point(156, 31);
            this.btBaja.Name = "btBaja";
            this.btBaja.Size = new System.Drawing.Size(90, 49);
            this.btBaja.TabIndex = 2;
            this.btBaja.Text = "Baja";
            this.btBaja.UseVisualStyleBackColor = true;
            // 
            // btModificar
            // 
            this.btModificar.Location = new System.Drawing.Point(28, 110);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(90, 49);
            this.btModificar.TabIndex = 3;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // MainHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 180);
            this.Controls.Add(this.btModificar);
            this.Controls.Add(this.btBaja);
            this.Controls.Add(this.btAlta);
            this.Controls.Add(this.btVolver);
            this.Name = "MainHabitacion";
            this.Text = "ABM de Habitacion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Button btAlta;
        private System.Windows.Forms.Button btBaja;
        private System.Windows.Forms.Button btModificar;
    }
}