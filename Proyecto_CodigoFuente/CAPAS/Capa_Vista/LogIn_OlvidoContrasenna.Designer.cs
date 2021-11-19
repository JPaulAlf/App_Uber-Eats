namespace Capa_Vista
{
    partial class LogIn_OlvidoContrasenna
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn_OlvidoContrasenna));
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pnlBotonAceptar = new System.Windows.Forms.Panel();
            this.btnAceptarContrasenna = new System.Windows.Forms.Button();
            this.txtContrasenna1 = new System.Windows.Forms.TextBox();
            this.txtContrasenna2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnS = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlContenido.SuspendLayout();
            this.pnlBotonAceptar.SuspendLayout();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlContenido.Controls.Add(this.checkBox1);
            this.pnlContenido.Controls.Add(this.pnlBotonAceptar);
            this.pnlContenido.Controls.Add(this.txtContrasenna1);
            this.pnlContenido.Controls.Add(this.txtContrasenna2);
            this.pnlContenido.Controls.Add(this.label6);
            this.pnlContenido.Controls.Add(this.label4);
            this.pnlContenido.Controls.Add(this.txtNombreUsuario);
            this.pnlContenido.Controls.Add(this.label3);
            this.pnlContenido.Controls.Add(this.label2);
            this.pnlContenido.Controls.Add(this.pnlControl);
            this.pnlContenido.Location = new System.Drawing.Point(0, 0);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(934, 591);
            this.pnlContenido.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(500, 321);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 25);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "VER";
            this.toolTip.SetToolTip(this.checkBox1, "Ver contrasena ingresada");
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pnlBotonAceptar
            // 
            this.pnlBotonAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.pnlBotonAceptar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBotonAceptar.Controls.Add(this.btnAceptarContrasenna);
            this.pnlBotonAceptar.Location = new System.Drawing.Point(0, 467);
            this.pnlBotonAceptar.Name = "pnlBotonAceptar";
            this.pnlBotonAceptar.Size = new System.Drawing.Size(931, 74);
            this.pnlBotonAceptar.TabIndex = 20;
            // 
            // btnAceptarContrasenna
            // 
            this.btnAceptarContrasenna.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAceptarContrasenna.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptarContrasenna.FlatAppearance.MouseDownBackColor = System.Drawing.Color.YellowGreen;
            this.btnAceptarContrasenna.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnAceptarContrasenna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarContrasenna.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptarContrasenna.ForeColor = System.Drawing.Color.White;
            this.btnAceptarContrasenna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptarContrasenna.Location = new System.Drawing.Point(589, 14);
            this.btnAceptarContrasenna.Name = "btnAceptarContrasenna";
            this.btnAceptarContrasenna.Size = new System.Drawing.Size(299, 41);
            this.btnAceptarContrasenna.TabIndex = 0;
            this.btnAceptarContrasenna.Text = "Cambiar contrasena";
            this.toolTip.SetToolTip(this.btnAceptarContrasenna, "Confirmacion de contrasena");
            this.btnAceptarContrasenna.UseVisualStyleBackColor = true;
            this.btnAceptarContrasenna.Click += new System.EventHandler(this.btnAceptarContrasenna_Click);
            // 
            // txtContrasenna1
            // 
            this.txtContrasenna1.BackColor = System.Drawing.Color.White;
            this.txtContrasenna1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContrasenna1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenna1.ForeColor = System.Drawing.Color.Black;
            this.txtContrasenna1.Location = new System.Drawing.Point(56, 406);
            this.txtContrasenna1.MaxLength = 32;
            this.txtContrasenna1.Multiline = true;
            this.txtContrasenna1.Name = "txtContrasenna1";
            this.txtContrasenna1.PasswordChar = '•';
            this.txtContrasenna1.Size = new System.Drawing.Size(427, 28);
            this.txtContrasenna1.TabIndex = 18;
            this.toolTip.SetToolTip(this.txtContrasenna1, "Contrasena nueva");
            // 
            // txtContrasenna2
            // 
            this.txtContrasenna2.BackColor = System.Drawing.Color.White;
            this.txtContrasenna2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContrasenna2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenna2.ForeColor = System.Drawing.Color.Black;
            this.txtContrasenna2.Location = new System.Drawing.Point(56, 318);
            this.txtContrasenna2.MaxLength = 32;
            this.txtContrasenna2.Multiline = true;
            this.txtContrasenna2.Name = "txtContrasenna2";
            this.txtContrasenna2.PasswordChar = '•';
            this.txtContrasenna2.Size = new System.Drawing.Size(427, 28);
            this.txtContrasenna2.TabIndex = 17;
            this.toolTip.SetToolTip(this.txtContrasenna2, "Confirmacion de contrasena nueva");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(33, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "Confirma contrasena";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(33, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nueva contrasena";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.BackColor = System.Drawing.Color.White;
            this.txtNombreUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreUsuario.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtNombreUsuario.Location = new System.Drawing.Point(56, 174);
            this.txtNombreUsuario.MaxLength = 50;
            this.txtNombreUsuario.Multiline = true;
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(503, 28);
            this.txtNombreUsuario.TabIndex = 11;
            this.toolTip.SetToolTip(this.txtNombreUsuario, "Correo electronico");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 33);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cambio de contrasena";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(33, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Correo de la cuenta";
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlControl.Controls.Add(this.pictureBox1);
            this.pnlControl.Controls.Add(this.btnS);
            this.pnlControl.Location = new System.Drawing.Point(-14, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(955, 41);
            this.pnlControl.TabIndex = 7;
            this.pnlControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlControl_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Capa_Vista.Properties.Resources.regreso;
            this.pictureBox1.Location = new System.Drawing.Point(21, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnS
            // 
            this.btnS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnS.Image = global::Capa_Vista.Properties.Resources.cerrar__6_;
            this.btnS.Location = new System.Drawing.Point(893, 3);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(34, 30);
            this.btnS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnS.TabIndex = 0;
            this.btnS.TabStop = false;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // LogIn_OlvidoContrasenna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(923, 575);
            this.Controls.Add(this.pnlContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogIn_OlvidoContrasenna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OlvidoContrasenna";
            this.Load += new System.EventHandler(this.LogIn_OlvidoContrasenna_Load);
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            this.pnlBotonAceptar.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.PictureBox btnS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtContrasenna1;
        private System.Windows.Forms.TextBox txtContrasenna2;
        private System.Windows.Forms.Panel pnlBotonAceptar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnAceptarContrasenna;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ErrorProvider errProvider;
    }
}