namespace FrbaHotel.ABM_de_Usuario
{
    partial class BajaUsuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.usuarioADarDeBaja = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.botonConfirmar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esta por dar de baja al usuario:";
            // 
            // usuarioADarDeBaja
            // 
            this.usuarioADarDeBaja.Enabled = false;
            this.usuarioADarDeBaja.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioADarDeBaja.Location = new System.Drawing.Point(104, 95);
            this.usuarioADarDeBaja.Name = "usuarioADarDeBaja";
            this.usuarioADarDeBaja.Size = new System.Drawing.Size(179, 26);
            this.usuarioADarDeBaja.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(383, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Si confirma la operacion, se inhabilitara dicho usuario para todos los \r\nhoteles " +
                "y sus respectivos roles  que tenga a cargo hasta el momento.";
            // 
            // botonConfirmar
            // 
            this.botonConfirmar.Location = new System.Drawing.Point(41, 244);
            this.botonConfirmar.Name = "botonConfirmar";
            this.botonConfirmar.Size = new System.Drawing.Size(90, 35);
            this.botonConfirmar.TabIndex = 3;
            this.botonConfirmar.Text = "Confirmar";
            this.botonConfirmar.UseVisualStyleBackColor = true;
            this.botonConfirmar.Click += new System.EventHandler(this.botonConfirmar_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(373, 244);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(90, 35);
            this.botonCancelar.TabIndex = 4;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // BajaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 318);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonConfirmar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usuarioADarDeBaja);
            this.Controls.Add(this.label1);
            this.Name = "BajaUsuario";
            this.Text = "Baja de Usuario";
            this.Load += new System.EventHandler(this.BajaUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usuarioADarDeBaja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button botonConfirmar;
        private System.Windows.Forms.Button botonCancelar;
    }
}