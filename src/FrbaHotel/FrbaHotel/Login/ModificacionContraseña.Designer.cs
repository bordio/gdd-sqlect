namespace FrbaHotel.Login
{
    partial class ModificacionContraseña
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
            this.nombreDelUsuario = new System.Windows.Forms.Label();
            this.contraseñaActual = new System.Windows.Forms.TextBox();
            this.contraseñaConfirmada = new System.Windows.Forms.TextBox();
            this.contraseñaNueva = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nombreDelUsuario
            // 
            this.nombreDelUsuario.AutoSize = true;
            this.nombreDelUsuario.Location = new System.Drawing.Point(53, 24);
            this.nombreDelUsuario.Name = "nombreDelUsuario";
            this.nombreDelUsuario.Size = new System.Drawing.Size(35, 13);
            this.nombreDelUsuario.TabIndex = 0;
            this.nombreDelUsuario.Text = "label1";
            this.nombreDelUsuario.Visible = false;
            // 
            // contraseñaActual
            // 
            this.contraseñaActual.Location = new System.Drawing.Point(158, 104);
            this.contraseñaActual.Name = "contraseñaActual";
            this.contraseñaActual.PasswordChar = '•';
            this.contraseñaActual.Size = new System.Drawing.Size(160, 20);
            this.contraseñaActual.TabIndex = 1;
            // 
            // contraseñaConfirmada
            // 
            this.contraseñaConfirmada.Location = new System.Drawing.Point(158, 227);
            this.contraseñaConfirmada.Name = "contraseñaConfirmada";
            this.contraseñaConfirmada.PasswordChar = '•';
            this.contraseñaConfirmada.Size = new System.Drawing.Size(160, 20);
            this.contraseñaConfirmada.TabIndex = 2;
            // 
            // contraseñaNueva
            // 
            this.contraseñaNueva.Location = new System.Drawing.Point(158, 178);
            this.contraseñaNueva.Name = "contraseñaNueva";
            this.contraseñaNueva.PasswordChar = '•';
            this.contraseñaNueva.Size = new System.Drawing.Size(160, 20);
            this.contraseñaNueva.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(422, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Contraeña actual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Contraseña nueva";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Confirme contraseña";
            // 
            // ModificacionContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 355);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.contraseñaNueva);
            this.Controls.Add(this.contraseñaConfirmada);
            this.Controls.Add(this.contraseñaActual);
            this.Controls.Add(this.nombreDelUsuario);
            this.Name = "ModificacionContraseña";
            this.Text = "ModificacionContraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nombreDelUsuario;
        private System.Windows.Forms.TextBox contraseñaActual;
        private System.Windows.Forms.TextBox contraseñaConfirmada;
        private System.Windows.Forms.TextBox contraseñaNueva;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}