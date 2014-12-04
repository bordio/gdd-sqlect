namespace FrbaHotel.Registrar_Consumible
{
    partial class Form1
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
            this.tablaDeConsumibles = new System.Windows.Forms.DataGridView();
            this.botonConfirmarOperacion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.botonRegistrarConsumible = new System.Windows.Forms.Button();
            this.botonModificarConsumible = new System.Windows.Forms.Button();
            this.botonBorrarConsumible = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeConsumibles)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaDeConsumibles
            // 
            this.tablaDeConsumibles.AllowUserToAddRows = false;
            this.tablaDeConsumibles.AllowUserToDeleteRows = false;
            this.tablaDeConsumibles.AllowUserToResizeColumns = false;
            this.tablaDeConsumibles.AllowUserToResizeRows = false;
            this.tablaDeConsumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeConsumibles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tablaDeConsumibles.Enabled = false;
            this.tablaDeConsumibles.Location = new System.Drawing.Point(39, 90);
            this.tablaDeConsumibles.Name = "tablaDeConsumibles";
            this.tablaDeConsumibles.Size = new System.Drawing.Size(353, 143);
            this.tablaDeConsumibles.TabIndex = 0;
            // 
            // botonConfirmarOperacion
            // 
            this.botonConfirmarOperacion.Location = new System.Drawing.Point(767, 268);
            this.botonConfirmarOperacion.Name = "botonConfirmarOperacion";
            this.botonConfirmarOperacion.Size = new System.Drawing.Size(149, 57);
            this.botonConfirmarOperacion.TabIndex = 1;
            this.botonConfirmarOperacion.Text = "Confirmar operación";
            this.botonConfirmarOperacion.UseVisualStyleBackColor = true;
            this.botonConfirmarOperacion.Click += new System.EventHandler(this.botonConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cargue los productos y/o servicios consumidos durante la estadía.";
            // 
            // botonRegistrarConsumible
            // 
            this.botonRegistrarConsumible.Location = new System.Drawing.Point(530, 90);
            this.botonRegistrarConsumible.Name = "botonRegistrarConsumible";
            this.botonRegistrarConsumible.Size = new System.Drawing.Size(162, 31);
            this.botonRegistrarConsumible.TabIndex = 3;
            this.botonRegistrarConsumible.Text = "Registrar consumible";
            this.botonRegistrarConsumible.UseVisualStyleBackColor = true;
            this.botonRegistrarConsumible.Click += new System.EventHandler(this.botonRegistrarConsumible_Click);
            // 
            // botonModificarConsumible
            // 
            this.botonModificarConsumible.Location = new System.Drawing.Point(530, 147);
            this.botonModificarConsumible.Name = "botonModificarConsumible";
            this.botonModificarConsumible.Size = new System.Drawing.Size(162, 31);
            this.botonModificarConsumible.TabIndex = 4;
            this.botonModificarConsumible.Text = "Modificar consumible";
            this.botonModificarConsumible.UseVisualStyleBackColor = true;
            this.botonModificarConsumible.Click += new System.EventHandler(this.botonModificarConsumible_Click);
            // 
            // botonBorrarConsumible
            // 
            this.botonBorrarConsumible.Location = new System.Drawing.Point(530, 202);
            this.botonBorrarConsumible.Name = "botonBorrarConsumible";
            this.botonBorrarConsumible.Size = new System.Drawing.Size(162, 31);
            this.botonBorrarConsumible.TabIndex = 5;
            this.botonBorrarConsumible.Text = "Borrar consumible";
            this.botonBorrarConsumible.UseVisualStyleBackColor = true;
            this.botonBorrarConsumible.Click += new System.EventHandler(this.botonBorrarConsumible_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 354);
            this.Controls.Add(this.botonBorrarConsumible);
            this.Controls.Add(this.botonModificarConsumible);
            this.Controls.Add(this.botonRegistrarConsumible);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonConfirmarOperacion);
            this.Controls.Add(this.tablaDeConsumibles);
            this.Name = "Form1";
            this.Text = "Registrar Conumibles";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeConsumibles)).EndInit();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaDeConsumibles;
        private System.Windows.Forms.Button botonConfirmarOperacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonRegistrarConsumible;
        private System.Windows.Forms.Button botonModificarConsumible;
        private System.Windows.Forms.Button botonBorrarConsumible;
    }
}