namespace Capa_Vista
{
    partial class Menu_Administrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Administrador));
            this.CONTIENE_TODO = new System.Windows.Forms.Panel();
            this.pnlContenedor_Frames_Hijos = new System.Windows.Forms.Panel();
            this.lblIndicaciones = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.pnlBarraTitulo = new System.Windows.Forms.Panel();
            this.btnSalir_App_ = new System.Windows.Forms.PictureBox();
            this.btnSlide = new System.Windows.Forms.PictureBox();
            this.pnlMenu_Vertical = new System.Windows.Forms.Panel();
            this.btnMantenimiento = new System.Windows.Forms.Button();
            this.btnCerrar_Sesion = new System.Windows.Forms.Button();
            this.btnRegistro_Usuario = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CONTIENE_TODO.SuspendLayout();
            this.pnlContenedor_Frames_Hijos.SuspendLayout();
            this.pnlBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir_App_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).BeginInit();
            this.pnlMenu_Vertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CONTIENE_TODO
            // 
            this.CONTIENE_TODO.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.CONTIENE_TODO.Controls.Add(this.pnlContenedor_Frames_Hijos);
            this.CONTIENE_TODO.Controls.Add(this.pnlBarraTitulo);
            this.CONTIENE_TODO.Controls.Add(this.pnlMenu_Vertical);
            this.CONTIENE_TODO.Location = new System.Drawing.Point(0, -2);
            this.CONTIENE_TODO.Name = "CONTIENE_TODO";
            this.CONTIENE_TODO.Size = new System.Drawing.Size(1357, 923);
            this.CONTIENE_TODO.TabIndex = 11;
            // 
            // pnlContenedor_Frames_Hijos
            // 
            this.pnlContenedor_Frames_Hijos.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlContenedor_Frames_Hijos.Controls.Add(this.lblIndicaciones);
            this.pnlContenedor_Frames_Hijos.Controls.Add(this.lblBienvenida);
            this.pnlContenedor_Frames_Hijos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor_Frames_Hijos.Location = new System.Drawing.Point(250, 50);
            this.pnlContenedor_Frames_Hijos.Name = "pnlContenedor_Frames_Hijos";
            this.pnlContenedor_Frames_Hijos.Size = new System.Drawing.Size(1107, 873);
            this.pnlContenedor_Frames_Hijos.TabIndex = 2;
            // 
            // lblIndicaciones
            // 
            this.lblIndicaciones.AutoSize = true;
            this.lblIndicaciones.Font = new System.Drawing.Font("Century Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicaciones.Location = new System.Drawing.Point(35, 749);
            this.lblIndicaciones.Name = "lblIndicaciones";
            this.lblIndicaciones.Size = new System.Drawing.Size(587, 33);
            this.lblIndicaciones.TabIndex = 7;
            this.lblIndicaciones.Text = "Las opciones se encuentran a tu izquierda...\r\n";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Century Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.Location = new System.Drawing.Point(220, 234);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(632, 132);
            this.lblBienvenida.TabIndex = 6;
            this.lblBienvenida.Text = "Bienvenido!\r\n\r\nFavor seleccionar una opcion, para empezar a\r\ndisfrutar al instant" +
    "e!!   ;)\r\n";
            // 
            // pnlBarraTitulo
            // 
            this.pnlBarraTitulo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlBarraTitulo.Controls.Add(this.btnSalir_App_);
            this.pnlBarraTitulo.Controls.Add(this.btnSlide);
            this.pnlBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraTitulo.Location = new System.Drawing.Point(250, 0);
            this.pnlBarraTitulo.Name = "pnlBarraTitulo";
            this.pnlBarraTitulo.Size = new System.Drawing.Size(1107, 50);
            this.pnlBarraTitulo.TabIndex = 1;
            this.pnlBarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBarraTitulo_MouseDown);
            // 
            // btnSalir_App_
            // 
            this.btnSalir_App_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir_App_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir_App_.Image = global::Capa_Vista.Properties.Resources.cerrar__6_;
            this.btnSalir_App_.Location = new System.Drawing.Point(1046, 11);
            this.btnSalir_App_.Name = "btnSalir_App_";
            this.btnSalir_App_.Size = new System.Drawing.Size(49, 28);
            this.btnSalir_App_.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSalir_App_.TabIndex = 3;
            this.btnSalir_App_.TabStop = false;
            this.btnSalir_App_.Click += new System.EventHandler(this.btnSalir_App__Click);
            // 
            // btnSlide
            // 
            this.btnSlide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlide.Image = global::Capa_Vista.Properties.Resources.menu_abierto;
            this.btnSlide.Location = new System.Drawing.Point(17, 6);
            this.btnSlide.Name = "btnSlide";
            this.btnSlide.Size = new System.Drawing.Size(54, 39);
            this.btnSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSlide.TabIndex = 0;
            this.btnSlide.TabStop = false;
            this.btnSlide.Click += new System.EventHandler(this.btnSlide_Click);
            // 
            // pnlMenu_Vertical
            // 
            this.pnlMenu_Vertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(109)))), ((int)(((byte)(113)))));
            this.pnlMenu_Vertical.Controls.Add(this.btnMantenimiento);
            this.pnlMenu_Vertical.Controls.Add(this.btnCerrar_Sesion);
            this.pnlMenu_Vertical.Controls.Add(this.btnRegistro_Usuario);
            this.pnlMenu_Vertical.Controls.Add(this.label3);
            this.pnlMenu_Vertical.Controls.Add(this.label1);
            this.pnlMenu_Vertical.Controls.Add(this.pictureBox1);
            this.pnlMenu_Vertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu_Vertical.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu_Vertical.Name = "pnlMenu_Vertical";
            this.pnlMenu_Vertical.Size = new System.Drawing.Size(250, 923);
            this.pnlMenu_Vertical.TabIndex = 0;
            // 
            // btnMantenimiento
            // 
            this.btnMantenimiento.BackColor = System.Drawing.Color.Transparent;
            this.btnMantenimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMantenimiento.FlatAppearance.BorderSize = 0;
            this.btnMantenimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMantenimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(226)))));
            this.btnMantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimiento.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMantenimiento.ForeColor = System.Drawing.Color.Black;
            this.btnMantenimiento.Image = global::Capa_Vista.Properties.Resources.llave;
            this.btnMantenimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMantenimiento.Location = new System.Drawing.Point(0, 194);
            this.btnMantenimiento.Name = "btnMantenimiento";
            this.btnMantenimiento.Size = new System.Drawing.Size(250, 71);
            this.btnMantenimiento.TabIndex = 21;
            this.btnMantenimiento.Text = "Mantenimiento    ";
            this.btnMantenimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMantenimiento.UseVisualStyleBackColor = true;
            this.btnMantenimiento.Click += new System.EventHandler(this.btnMantenimiento_Click);
            // 
            // btnCerrar_Sesion
            // 
            this.btnCerrar_Sesion.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar_Sesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar_Sesion.FlatAppearance.BorderSize = 0;
            this.btnCerrar_Sesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar_Sesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(226)))));
            this.btnCerrar_Sesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar_Sesion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar_Sesion.ForeColor = System.Drawing.Color.Black;
            this.btnCerrar_Sesion.Image = global::Capa_Vista.Properties.Resources.salida;
            this.btnCerrar_Sesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar_Sesion.Location = new System.Drawing.Point(0, 780);
            this.btnCerrar_Sesion.Name = "btnCerrar_Sesion";
            this.btnCerrar_Sesion.Size = new System.Drawing.Size(250, 71);
            this.btnCerrar_Sesion.TabIndex = 14;
            this.btnCerrar_Sesion.Text = "Cerrar Sesion         ";
            this.btnCerrar_Sesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar_Sesion.UseVisualStyleBackColor = true;
            this.btnCerrar_Sesion.Click += new System.EventHandler(this.btnCerrar_Sesion_Click);
            // 
            // btnRegistro_Usuario
            // 
            this.btnRegistro_Usuario.BackColor = System.Drawing.Color.Transparent;
            this.btnRegistro_Usuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistro_Usuario.FlatAppearance.BorderSize = 0;
            this.btnRegistro_Usuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRegistro_Usuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(226)))));
            this.btnRegistro_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistro_Usuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro_Usuario.ForeColor = System.Drawing.Color.Black;
            this.btnRegistro_Usuario.Image = global::Capa_Vista.Properties.Resources.registro;
            this.btnRegistro_Usuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistro_Usuario.Location = new System.Drawing.Point(3, 117);
            this.btnRegistro_Usuario.Name = "btnRegistro_Usuario";
            this.btnRegistro_Usuario.Size = new System.Drawing.Size(250, 71);
            this.btnRegistro_Usuario.TabIndex = 1;
            this.btnRegistro_Usuario.Text = "Registro Usuario     ";
            this.btnRegistro_Usuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistro_Usuario.UseVisualStyleBackColor = true;
            this.btnRegistro_Usuario.Click += new System.EventHandler(this.btnRegistro_Usuario_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(151, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Eat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(80, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Just";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Capa_Vista.Properties.Resources.pngegg__3_;
            this.pictureBox1.Location = new System.Drawing.Point(5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Menu_Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 920);
            this.Controls.Add(this.CONTIENE_TODO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_Administrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu_Administrador";
            this.CONTIENE_TODO.ResumeLayout(false);
            this.pnlContenedor_Frames_Hijos.ResumeLayout(false);
            this.pnlContenedor_Frames_Hijos.PerformLayout();
            this.pnlBarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir_App_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).EndInit();
            this.pnlMenu_Vertical.ResumeLayout(false);
            this.pnlMenu_Vertical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CONTIENE_TODO;
        private System.Windows.Forms.Panel pnlContenedor_Frames_Hijos;
        private System.Windows.Forms.Panel pnlBarraTitulo;
        private System.Windows.Forms.PictureBox btnSlide;
        private System.Windows.Forms.Panel pnlMenu_Vertical;
        private System.Windows.Forms.Button btnCerrar_Sesion;
        private System.Windows.Forms.Button btnRegistro_Usuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnSalir_App_;
        private System.Windows.Forms.Label lblIndicaciones;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnMantenimiento;
    }
}