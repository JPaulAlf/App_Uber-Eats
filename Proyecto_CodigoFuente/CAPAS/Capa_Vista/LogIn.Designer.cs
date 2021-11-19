namespace Capa_Vista
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.chVerContrasenna_Usuario = new System.Windows.Forms.CheckBox();
            this.lblRegistrar = new System.Windows.Forms.LinkLabel();
            this.txtContrasenna = new System.Windows.Forms.TextBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblRecuperarContrasenna = new System.Windows.Forms.LinkLabel();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlBarraEstado = new System.Windows.Forms.Panel();
            this.btnSalir_App_ = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.erpErrores = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlContenido.SuspendLayout();
            this.pnlBarraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir_App_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.Controls.Add(this.chVerContrasenna_Usuario);
            this.pnlContenido.Controls.Add(this.lblRegistrar);
            this.pnlContenido.Controls.Add(this.txtContrasenna);
            this.pnlContenido.Controls.Add(this.txtNombreUsuario);
            this.pnlContenido.Controls.Add(this.lblRecuperarContrasenna);
            this.pnlContenido.Controls.Add(this.btnIniciarSesion);
            this.pnlContenido.Controls.Add(this.label4);
            this.pnlContenido.Controls.Add(this.label1);
            this.pnlContenido.Controls.Add(this.label3);
            this.pnlContenido.Controls.Add(this.pnlBarraEstado);
            this.pnlContenido.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlContenido.Location = new System.Drawing.Point(-1, -1);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(955, 653);
            this.pnlContenido.TabIndex = 0;
            // 
            // chVerContrasenna_Usuario
            // 
            this.chVerContrasenna_Usuario.AutoSize = true;
            this.chVerContrasenna_Usuario.BackColor = System.Drawing.Color.Transparent;
            this.chVerContrasenna_Usuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chVerContrasenna_Usuario.ForeColor = System.Drawing.Color.White;
            this.chVerContrasenna_Usuario.Location = new System.Drawing.Point(702, 399);
            this.chVerContrasenna_Usuario.Name = "chVerContrasenna_Usuario";
            this.chVerContrasenna_Usuario.Size = new System.Drawing.Size(59, 25);
            this.chVerContrasenna_Usuario.TabIndex = 28;
            this.chVerContrasenna_Usuario.Text = "VER";
            this.chVerContrasenna_Usuario.UseVisualStyleBackColor = false;
            this.chVerContrasenna_Usuario.CheckedChanged += new System.EventHandler(this.chVerContrasenna_Usuario_CheckedChanged);
            // 
            // lblRegistrar
            // 
            this.lblRegistrar.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lblRegistrar.AutoSize = true;
            this.lblRegistrar.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRegistrar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrar.LinkColor = System.Drawing.Color.White;
            this.lblRegistrar.Location = new System.Drawing.Point(745, 587);
            this.lblRegistrar.Name = "lblRegistrar";
            this.lblRegistrar.Size = new System.Drawing.Size(84, 17);
            this.lblRegistrar.TabIndex = 12;
            this.lblRegistrar.TabStop = true;
            this.lblRegistrar.Text = "Registrarse?";
            this.toolTip1.SetToolTip(this.lblRegistrar, "Registrarse con una nueva cuenta");
            this.lblRegistrar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRegistrar_LinkClicked);
            // 
            // txtContrasenna
            // 
            this.txtContrasenna.BackColor = System.Drawing.Color.White;
            this.txtContrasenna.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContrasenna.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenna.ForeColor = System.Drawing.Color.Black;
            this.txtContrasenna.Location = new System.Drawing.Point(297, 399);
            this.txtContrasenna.MaxLength = 32;
            this.txtContrasenna.Multiline = true;
            this.txtContrasenna.Name = "txtContrasenna";
            this.txtContrasenna.PasswordChar = '•';
            this.txtContrasenna.Size = new System.Drawing.Size(399, 25);
            this.txtContrasenna.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtContrasenna, "Contrasena del usuario ingresado");
            this.txtContrasenna.UseSystemPasswordChar = true;
            this.txtContrasenna.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrasenna_KeyDown);
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.BackColor = System.Drawing.Color.White;
            this.txtNombreUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreUsuario.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtNombreUsuario.Location = new System.Drawing.Point(297, 268);
            this.txtNombreUsuario.MaxLength = 50;
            this.txtNombreUsuario.Multiline = true;
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(399, 25);
            this.txtNombreUsuario.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txtNombreUsuario, "Nombre de usuario");
            this.txtNombreUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombreUsuario_KeyDown);
            // 
            // lblRecuperarContrasenna
            // 
            this.lblRecuperarContrasenna.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lblRecuperarContrasenna.AutoSize = true;
            this.lblRecuperarContrasenna.BackColor = System.Drawing.Color.Transparent;
            this.lblRecuperarContrasenna.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRecuperarContrasenna.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecuperarContrasenna.LinkColor = System.Drawing.Color.White;
            this.lblRecuperarContrasenna.Location = new System.Drawing.Point(745, 608);
            this.lblRecuperarContrasenna.Name = "lblRecuperarContrasenna";
            this.lblRecuperarContrasenna.Size = new System.Drawing.Size(153, 17);
            this.lblRecuperarContrasenna.TabIndex = 9;
            this.lblRecuperarContrasenna.TabStop = true;
            this.lblRecuperarContrasenna.Text = "Restaurar contrasena?";
            this.toolTip1.SetToolTip(this.lblRecuperarContrasenna, "Restaura contrasena de cuenta");
            this.lblRecuperarContrasenna.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRecuperarContrasenna_LinkClicked);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.Transparent;
            this.btnIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarSesion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnIniciarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.GreenYellow;
            this.btnIniciarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.White;
            this.btnIniciarSesion.Location = new System.Drawing.Point(297, 479);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(399, 50);
            this.btnIniciarSesion.TabIndex = 8;
            this.btnIniciarSesion.Text = "Ingresar";
            this.toolTip1.SetToolTip(this.btnIniciarSesion, "Ingresar");
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            this.btnIniciarSesion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnIniciarSesion_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(283, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Contrasena";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(283, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Correo Electronico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(395, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Inicio Sesion";
            // 
            // pnlBarraEstado
            // 
            this.pnlBarraEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.pnlBarraEstado.Controls.Add(this.btnSalir_App_);
            this.pnlBarraEstado.Location = new System.Drawing.Point(2, 0);
            this.pnlBarraEstado.Name = "pnlBarraEstado";
            this.pnlBarraEstado.Size = new System.Drawing.Size(955, 41);
            this.pnlBarraEstado.TabIndex = 3;
            this.pnlBarraEstado.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBarraEstado_MouseDown);
            // 
            // btnSalir_App_
            // 
            this.btnSalir_App_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir_App_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir_App_.Image = global::Capa_Vista.Properties.Resources.cerrar__8_;
            this.btnSalir_App_.Location = new System.Drawing.Point(891, 6);
            this.btnSalir_App_.Name = "btnSalir_App_";
            this.btnSalir_App_.Size = new System.Drawing.Size(49, 28);
            this.btnSalir_App_.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSalir_App_.TabIndex = 5;
            this.btnSalir_App_.TabStop = false;
            this.btnSalir_App_.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSalir_App__MouseClick);
            // 
            // erpErrores
            // 
            this.erpErrores.ContainerControl = this;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = global::Capa_Vista.Properties.Resources.splash3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(953, 651);
            this.Controls.Add(this.pnlContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            this.pnlBarraEstado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir_App_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpErrores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel pnlBarraEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.TextBox txtContrasenna;
        private System.Windows.Forms.LinkLabel lblRecuperarContrasenna;
        private System.Windows.Forms.LinkLabel lblRegistrar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider erpErrores;
        public System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.CheckBox chVerContrasenna_Usuario;
        private System.Windows.Forms.PictureBox btnSalir_App_;
    }
}