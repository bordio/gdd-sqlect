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
            this.botonConfirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.botonAgregarFila = new System.Windows.Forms.Button();
            this.numeroHab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadConsumidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeConsumibles)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaDeConsumibles
            // 
            this.tablaDeConsumibles.AllowUserToResizeColumns = false;
            this.tablaDeConsumibles.AllowUserToResizeRows = false;
            this.tablaDeConsumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeConsumibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroHab,
            this.consumible,
            this.cantidadConsumidos});
            this.tablaDeConsumibles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tablaDeConsumibles.Location = new System.Drawing.Point(39, 90);
            this.tablaDeConsumibles.Name = "tablaDeConsumibles";
            this.tablaDeConsumibles.Size = new System.Drawing.Size(353, 149);
            this.tablaDeConsumibles.TabIndex = 0;
            this.tablaDeConsumibles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaDeConsumibles_CellEndEdit);
            // 
            // botonConfirmar
            // 
            this.botonConfirmar.Location = new System.Drawing.Point(659, 225);
            this.botonConfirmar.Name = "botonConfirmar";
            this.botonConfirmar.Size = new System.Drawing.Size(133, 57);
            this.botonConfirmar.TabIndex = 1;
            this.botonConfirmar.Text = "Confirmar operación";
            this.botonConfirmar.UseVisualStyleBackColor = true;
            this.botonConfirmar.Click += new System.EventHandler(this.botonConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ingrese los productos que consumió y su cantidad.";
            // 
            // botonAgregarFila
            // 
            this.botonAgregarFila.Location = new System.Drawing.Point(513, 90);
            this.botonAgregarFila.Name = "botonAgregarFila";
            this.botonAgregarFila.Size = new System.Drawing.Size(162, 31);
            this.botonAgregarFila.TabIndex = 3;
            this.botonAgregarFila.Text = "Registrar consumible";
            this.botonAgregarFila.UseVisualStyleBackColor = true;
            this.botonAgregarFila.Click += new System.EventHandler(this.botonAgregarFila_Click);
            // 
            // numeroHab
            // 
            this.numeroHab.HeaderText = "Numero de Habitacion";
            this.numeroHab.Name = "numeroHab";
            this.numeroHab.ReadOnly = true;
            // 
            // consumible
            // 
            this.consumible.HeaderText = "Consumible";
            this.consumible.Name = "consumible";
            this.consumible.ReadOnly = true;
            // 
            // cantidadConsumidos
            // 
            this.cantidadConsumidos.HeaderText = "Cantidad";
            this.cantidadConsumidos.Name = "cantidadConsumidos";
            this.cantidadConsumidos.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 354);
            this.Controls.Add(this.botonAgregarFila);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonConfirmar);
            this.Controls.Add(this.tablaDeConsumibles);
            this.Name = "Form1";
            this.Text = "Registrar Conumibles";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeConsumibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaDeConsumibles;
        private System.Windows.Forms.Button botonConfirmar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonAgregarFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroHab;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumible;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadConsumidos;
    }
}