namespace FrbaHotel.Login
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
            this.button1 = new System.Windows.Forms.Button();
            this.checkUsuarioRegis = new System.Windows.Forms.CheckBox();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.textPass = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelRol = new System.Windows.Forms.Label();
            this.comboBoxRol = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(475, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ingresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkUsuarioRegis
            // 
            this.checkUsuarioRegis.AutoSize = true;
            this.checkUsuarioRegis.Location = new System.Drawing.Point(63, 53);
            this.checkUsuarioRegis.Name = "checkUsuarioRegis";
            this.checkUsuarioRegis.Size = new System.Drawing.Size(111, 17);
            this.checkUsuarioRegis.TabIndex = 1;
            this.checkUsuarioRegis.Text = "Usuario registrado";
            this.checkUsuarioRegis.UseVisualStyleBackColor = true;
            this.checkUsuarioRegis.CheckedChanged += new System.EventHandler(this.checkUsuarioRegis_CheckedChanged);
            // 
            // textUsuario
            // 
            this.textUsuario.Location = new System.Drawing.Point(121, 117);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(100, 20);
            this.textUsuario.TabIndex = 2;
            this.textUsuario.Visible = false;
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(121, 163);
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '•';
            this.textPass.Size = new System.Drawing.Size(100, 20);
            this.textPass.TabIndex = 3;
            this.textPass.Visible = false;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelUsuario.Location = new System.Drawing.Point(28, 123);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(63, 16);
            this.labelUsuario.TabIndex = 5;
            this.labelUsuario.Text = "Usuario";
            this.labelUsuario.Visible = false;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelPass.Location = new System.Drawing.Point(28, 167);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(78, 16);
            this.labelPass.TabIndex = 6;
            this.labelPass.Text = "Password";
            this.labelPass.Visible = false;
            // 
            // labelRol
            // 
            this.labelRol.AutoSize = true;
            this.labelRol.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRol.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelRol.Location = new System.Drawing.Point(28, 213);
            this.labelRol.Name = "labelRol";
            this.labelRol.Size = new System.Drawing.Size(30, 16);
            this.labelRol.TabIndex = 7;
            this.labelRol.Text = "Rol";
            this.labelRol.Visible = false;
            // 
            // comboBoxRol
            // 
            this.comboBoxRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRol.FormattingEnabled = true;
            this.comboBoxRol.Location = new System.Drawing.Point(121, 213);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(139, 21);
            this.comboBoxRol.TabIndex = 8;
            this.comboBoxRol.Visible = false;
           
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 307);
            this.Controls.Add(this.comboBoxRol);
            this.Controls.Add(this.labelRol);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.checkUsuarioRegis);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkUsuarioRegis;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelRol;
        private System.Windows.Forms.ComboBox comboBoxRol;
    }
}