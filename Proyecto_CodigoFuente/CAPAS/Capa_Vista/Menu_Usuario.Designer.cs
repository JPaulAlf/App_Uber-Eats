namespace Capa_Vista
{
    partial class Menu_Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Usuario));
            this.CONTIENE_TODO = new System.Windows.Forms.Panel();
            this.pnlContenedor_Frames_Hijos = new System.Windows.Forms.Panel();
            this.lblIndicaciones = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.pnlBarraTitulo = new System.Windows.Forms.Panel();
            this.btnSalir_App_ = new System.Windows.Forms.PictureBox();
            this.btnSlide = new System.Windows.Forms.PictureBox();
            this.pnlMenu_Vertical = new System.Windows.Forms.Panel();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnActualizar_Datos = new System.Windows.Forms.Button();
            this.btnCalificar_Pedido = new System.Windows.Forms.Button();
            this.btnCerrar_Sesion = new System.Windows.Forms.Button();
            this.btnSolicitud_Producto = new System.Windows.Forms.Button();
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
            this.CONTIENE_TODO.Location = new System.Drawing.Point(0, -1);
            this.CONTIENE_TODO.Name = "CONTIENE_TODO";
            this.CONTIENE_TODO.Size = new System.Drawing.Size(1274, 877);
            this.CONTIENE_TODO.TabIndex = 9;
            // 
            // pnlContenedor_Frames_Hijos
            // 
            this.pnlContenedor_Frames_Hijos.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlContenedor_Frames_Hijos.Controls.Add(this.lblIndicaciones);
            this.pnlContenedor_Frames_Hijos.Controls.Add(this.lblBienvenida);
            this.pnlContenedor_Frames_Hijos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor_Frames_Hijos.Location = new System.Drawing.Point(250, 50);
            this.pnlContenedor_Frames_Hijos.Name = "pnlContenedor_Frames_Hijos";
            this.pnlContenedor_Frames_Hijos.Size = new System.Drawing.Size(1024, 827);
            this.pnlContenedor_Frames_Hijos.TabIndex = 2;
            // 
            // lblIndicaciones
            // 
            this.lblIndicaciones.AutoSize = true;
            this.lblIndicaciones.Font = new System.Drawing.Font("Century Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicaciones.Location = new System.Drawing.Point(11, 745);
            this.lblIndicaciones.Name = "lblIndicaciones";
            this.lblIndicaciones.Size = new System.Drawing.Size(587, 33);
            this.lblIndicaciones.TabIndex = 1;
            this.lblIndicaciones.Text = "Las opciones se encuentran a tu izquierda...\r\n";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Century Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.Location = new System.Drawing.Point(196, 230);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(632, 132);
            this.lblBienvenida.TabIndex = 0;
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
            this.pnlBarraTitulo.Size = new System.Drawing.Size(1024, 50);
            this.pnlBarraTitulo.TabIndex = 1;
            this.pnlBarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBarraTitulo_MouseDown);
            // 
            // btnSalir_App_
            // 
            this.btnSalir_App_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir_App_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir_App_.Image = global::Capa_Vista.Properties.Resources.cerrar__6_;
            this.btnSalir_App_.Location = new System.Drawing.Point(963, 11);
            this.btnSalir_App_.Name = "btnSalir_App_";
            this.btnSalir_App_.Size = new System.Drawing.Size(49, 28);
            this.btnSalir_App_.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSalir_App_.TabIndex = 1;
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
            this.pnlMenu_Vertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.pnlMenu_Vertical.Controls.Add(this.btnReportes);
            this.pnlMenu_Vertical.Controls.Add(this.btnActualizar_Datos);
            this.pnlMenu_Vertical.Controls.Add(this.btnCalificar_Pedido);
            this.pnlMenu_Vertical.Controls.Add(this.btnCerrar_Sesion);
            this.pnlMenu_Vertical.Controls.Add(this.btnSolicitud_Producto);
            this.pnlMenu_Vertical.Controls.Add(this.label3);
            this.pnlMenu_Vertical.Controls.Add(this.label1);
            this.pnlMenu_Vertical.Controls.Add(this.pictureBox1);
            this.pnlMenu_Vertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu_Vertical.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu_Vertical.Name = "pnlMenu_Vertical";
            this.pnlMenu_Vertical.Size = new System.Drawing.Size(250, 877);
            this.pnlMenu_Vertical.TabIndex = 0;
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.Transparent;
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Image = global::Capa_Vista.Properties.Resources.dinero;
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(0, 357);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(250, 71);
            this.btnReportes.TabIndex = 17;
            this.btnReportes.Text = "Reportes                  ";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnActualizar_Datos
            // 
            this.btnActualizar_Datos.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizar_Datos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar_Datos.FlatAppearance.BorderSize = 0;
            this.btnActualizar_Datos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnActualizar_Datos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnActualizar_Datos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar_Datos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar_Datos.ForeColor = System.Drawing.Color.White;
            this.btnActualizar_Datos.Image = global::Capa_Vista.Properties.Resources.texto;
            this.btnActualizar_Datos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar_Datos.Location = new System.Drawing.Point(0, 280);
            this.btnActualizar_Datos.Name = "btnActualizar_Datos";
            this.btnActualizar_Datos.Size = new System.Drawing.Size(250, 71);
            this.btnActualizar_Datos.TabIndex = 16;
            this.btnActualizar_Datos.Text = "Actualizar datos   ";
            this.btnActualizar_Datos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar_Datos.UseVisualStyleBackColor = true;
            this.btnActualizar_Datos.Click += new System.EventHandler(this.btnActualizar_Datos_Click);
            // 
            // btnCalificar_Pedido
            // 
            this.btnCalificar_Pedido.BackColor = System.Drawing.Color.Transparent;
            this.btnCalificar_Pedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalificar_Pedido.FlatAppearance.BorderSize = 0;
            this.btnCalificar_Pedido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCalificar_Pedido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnCalificar_Pedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalificar_Pedido.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalificar_Pedido.ForeColor = System.Drawing.Color.White;
            this.btnCalificar_Pedido.Image = global::Capa_Vista.Properties.Resources.calificar_nota;
            this.btnCalificar_Pedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalificar_Pedido.Location = new System.Drawing.Point(0, 203);
            this.btnCalificar_Pedido.Name = "btnCalificar_Pedido";
            this.btnCalificar_Pedido.Size = new System.Drawing.Size(250, 71);
            this.btnCalificar_Pedido.TabIndex = 15;
            this.btnCalificar_Pedido.Text = "Calificar Pedido     ";
            this.btnCalificar_Pedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalificar_Pedido.UseVisualStyleBackColor = true;
            this.btnCalificar_Pedido.Click += new System.EventHandler(this.btnCalificar_Pedido_Click);
            // 
            // btnCerrar_Sesion
            // 
            this.btnCerrar_Sesion.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar_Sesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar_Sesion.FlatAppearance.BorderSize = 0;
            this.btnCerrar_Sesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar_Sesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnCerrar_Sesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar_Sesion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar_Sesion.ForeColor = System.Drawing.Color.White;
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
            // btnSolicitud_Producto
            // 
            this.btnSolicitud_Producto.BackColor = System.Drawing.Color.Transparent;
            this.btnSolicitud_Producto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSolicitud_Producto.FlatAppearance.BorderSize = 0;
            this.btnSolicitud_Producto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSolicitud_Producto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnSolicitud_Producto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolicitud_Producto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolicitud_Producto.ForeColor = System.Drawing.Color.White;
            this.btnSolicitud_Producto.Image = global::Capa_Vista.Properties.Resources.producto__4_;
            this.btnSolicitud_Producto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSolicitud_Producto.Location = new System.Drawing.Point(0, 126);
            this.btnSolicitud_Producto.Name = "btnSolicitud_Producto";
            this.btnSolicitud_Producto.Size = new System.Drawing.Size(250, 71);
            this.btnSolicitud_Producto.TabIndex = 1;
            this.btnSolicitud_Producto.Text = "Solicitud Producto";
            this.btnSolicitud_Producto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSolicitud_Producto.UseVisualStyleBackColor = true;
            this.btnSolicitud_Producto.Click += new System.EventHandler(this.btnSolicitud_Producto_Click);
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
            // Menu_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 872);
            this.Controls.Add(this.CONTIENE_TODO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_Usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu_Usuario";
            this.Load += new System.EventHandler(this.Menu_Usuario_Load);
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
        private System.Windows.Forms.Panel pnlMenu_Vertical;
        private System.Windows.Forms.Panel pnlBarraTitulo;
        private System.Windows.Forms.Panel pnlContenedor_Frames_Hijos;
        private System.Windows.Forms.PictureBox btnSlide;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSolicitud_Producto;
        private System.Windows.Forms.Button btnCerrar_Sesion;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnActualizar_Datos;
        private System.Windows.Forms.Button btnCalificar_Pedido;
        private System.Windows.Forms.PictureBox btnSalir_App_;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblIndicaciones;
    }
}