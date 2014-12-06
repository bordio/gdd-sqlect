namespace FrbaHotel.Registrar_Consumible
{
    partial class RegistrarConsumible
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
            this.comboConsumibles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nroHabitacion = new System.Windows.Forms.TextBox();
            this.cantidadConsumible = new System.Windows.Forms.TextBox();
            this.botonGenerico = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.botonVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboConsumibles
            // 
            this.comboConsumibles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboConsumibles.FormattingEnabled = true;
            this.comboConsumibles.Items.AddRange(new object[] {
            "Coca Cola",
            "Whisky",
            "Bonbones",
            "Agua Mineral"});
            this.comboConsumibles.Location = new System.Drawing.Point(320, 135);
            this.comboConsumibles.Name = "comboConsumibles";
            this.comboConsumibles.Size = new System.Drawing.Size(150, 21);
            this.comboConsumibles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Consumible";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(593, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Número de habitacion";
            // 
            // nroHabitacion
            // 
            this.nroHabitacion.Location = new System.Drawing.Point(68, 136);
            this.nroHabitacion.Name = "nroHabitacion";
            this.nroHabitacion.Size = new System.Drawing.Size(100, 20);
            this.nroHabitacion.TabIndex = 4;
            // 
            // cantidadConsumible
            // 
            this.cantidadConsumible.Location = new System.Drawing.Point(596, 136);
            this.cantidadConsumible.Name = "cantidadConsumible";
            this.cantidadConsumible.Size = new System.Drawing.Size(53, 20);
            this.cantidadConsumible.TabIndex = 5;
            // 
            // botonGenerico
            // 
            this.botonGenerico.Location = new System.Drawing.Point(596, 257);
            this.botonGenerico.Name = "botonGenerico";
            this.botonGenerico.Size = new System.Drawing.Size(130, 52);
            this.botonGenerico.TabIndex = 6;
            this.botonGenerico.Text = "Registrar Consumible";
            this.botonGenerico.UseVisualStyleBackColor = true;
            this.botonGenerico.Click += new System.EventHandler(this.botonRegistrarConsumible_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ingrese los datos del producto";
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(68, 257);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(130, 52);
            this.botonVolver.TabIndex = 8;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // RegistrarConsumible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 345);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.botonGenerico);
            this.Controls.Add(this.cantidadConsumible);
            this.Controls.Add(this.nroHabitacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboConsumibles);
            this.Name = "RegistrarConsumible";
            this.Text = "RegistrarConsumible";
            this.Load += new System.EventHandler(this.RegistrarConsumible_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboConsumibles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nroHabitacion;
        private System.Windows.Forms.TextBox cantidadConsumible;
        private System.Windows.Forms.Button botonGenerico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button botonVolver;
    }
}