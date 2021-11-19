namespace Capa_Vista
{
    partial class Menu_Repartidor_EntregaPedido
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblRuta_NegClient = new System.Windows.Forms.Label();
            this.lblRuta_RepNeg = new System.Windows.Forms.Label();
            this.lblGananciaEntrega = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDistancia = new System.Windows.Forms.Label();
            this.btnHibrido = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnSatelital = new System.Windows.Forms.Button();
            this.btnRelieve = new System.Windows.Forms.Button();
            this.mapa_Repartidor = new GMap.NET.WindowsForms.GMapControl();
            this.btnTrazaRuta = new System.Windows.Forms.Button();
            this.btnEntregaRealizada = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(-4, -4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1199, 850);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage1.Controls.Add(this.lblRuta_NegClient);
            this.tabPage1.Controls.Add(this.lblRuta_RepNeg);
            this.tabPage1.Controls.Add(this.lblGananciaEntrega);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lblDistancia);
            this.tabPage1.Controls.Add(this.btnHibrido);
            this.tabPage1.Controls.Add(this.btnNormal);
            this.tabPage1.Controls.Add(this.btnSatelital);
            this.tabPage1.Controls.Add(this.btnRelieve);
            this.tabPage1.Controls.Add(this.mapa_Repartidor);
            this.tabPage1.Controls.Add(this.btnTrazaRuta);
            this.tabPage1.Controls.Add(this.btnEntregaRealizada);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1191, 824);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // lblRuta_NegClient
            // 
            this.lblRuta_NegClient.AutoSize = true;
            this.lblRuta_NegClient.BackColor = System.Drawing.Color.Transparent;
            this.lblRuta_NegClient.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuta_NegClient.ForeColor = System.Drawing.Color.Red;
            this.lblRuta_NegClient.Location = new System.Drawing.Point(397, 730);
            this.lblRuta_NegClient.Name = "lblRuta_NegClient";
            this.lblRuta_NegClient.Size = new System.Drawing.Size(210, 16);
            this.lblRuta_NegClient.TabIndex = 65;
            this.lblRuta_NegClient.Text = "Ruta hacia el lugar de entrega";
            // 
            // lblRuta_RepNeg
            // 
            this.lblRuta_RepNeg.AutoSize = true;
            this.lblRuta_RepNeg.BackColor = System.Drawing.Color.Transparent;
            this.lblRuta_RepNeg.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuta_RepNeg.ForeColor = System.Drawing.Color.Blue;
            this.lblRuta_RepNeg.Location = new System.Drawing.Point(397, 712);
            this.lblRuta_RepNeg.Name = "lblRuta_RepNeg";
            this.lblRuta_RepNeg.Size = new System.Drawing.Size(215, 16);
            this.lblRuta_RepNeg.TabIndex = 64;
            this.lblRuta_RepNeg.Text = "Ruta hacia el negocio de orden";
            // 
            // lblGananciaEntrega
            // 
            this.lblGananciaEntrega.AutoSize = true;
            this.lblGananciaEntrega.BackColor = System.Drawing.Color.Transparent;
            this.lblGananciaEntrega.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGananciaEntrega.ForeColor = System.Drawing.Color.Black;
            this.lblGananciaEntrega.Location = new System.Drawing.Point(953, 113);
            this.lblGananciaEntrega.Name = "lblGananciaEntrega";
            this.lblGananciaEntrega.Size = new System.Drawing.Size(166, 25);
            this.lblGananciaEntrega.TabIndex = 63;
            this.lblGananciaEntrega.Text = "@@ DINERO @@";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(732, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 25);
            this.label2.TabIndex = 62;
            this.label2.Text = "Pago por la entrega:";
            // 
            // lblDistancia
            // 
            this.lblDistancia.AutoSize = true;
            this.lblDistancia.BackColor = System.Drawing.Color.Transparent;
            this.lblDistancia.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistancia.ForeColor = System.Drawing.Color.Black;
            this.lblDistancia.Location = new System.Drawing.Point(294, 113);
            this.lblDistancia.Name = "lblDistancia";
            this.lblDistancia.Size = new System.Drawing.Size(199, 25);
            this.lblDistancia.TabIndex = 61;
            this.lblDistancia.Text = "@@ DISTANCIA @@";
            // 
            // btnHibrido
            // 
            this.btnHibrido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            this.btnHibrido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHibrido.FlatAppearance.BorderSize = 0;
            this.btnHibrido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHibrido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnHibrido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHibrido.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHibrido.ForeColor = System.Drawing.Color.Black;
            this.btnHibrido.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHibrido.Location = new System.Drawing.Point(299, 712);
            this.btnHibrido.Name = "btnHibrido";
            this.btnHibrido.Size = new System.Drawing.Size(82, 31);
            this.btnHibrido.TabIndex = 60;
            this.btnHibrido.Text = "Hibrido";
            this.btnHibrido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHibrido.UseVisualStyleBackColor = false;
            this.btnHibrido.Click += new System.EventHandler(this.btnHibrido_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            this.btnNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNormal.FlatAppearance.BorderSize = 0;
            this.btnNormal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNormal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnNormal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNormal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNormal.ForeColor = System.Drawing.Color.Black;
            this.btnNormal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNormal.Location = new System.Drawing.Point(123, 712);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(82, 31);
            this.btnNormal.TabIndex = 59;
            this.btnNormal.Text = "Normal";
            this.btnNormal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNormal.UseVisualStyleBackColor = false;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnSatelital
            // 
            this.btnSatelital.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            this.btnSatelital.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSatelital.FlatAppearance.BorderSize = 0;
            this.btnSatelital.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSatelital.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnSatelital.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSatelital.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSatelital.ForeColor = System.Drawing.Color.Black;
            this.btnSatelital.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSatelital.Location = new System.Drawing.Point(35, 712);
            this.btnSatelital.Name = "btnSatelital";
            this.btnSatelital.Size = new System.Drawing.Size(82, 31);
            this.btnSatelital.TabIndex = 58;
            this.btnSatelital.Text = "Satelital";
            this.btnSatelital.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSatelital.UseVisualStyleBackColor = false;
            this.btnSatelital.Click += new System.EventHandler(this.btnSatelital_Click);
            // 
            // btnRelieve
            // 
            this.btnRelieve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            this.btnRelieve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRelieve.FlatAppearance.BorderSize = 0;
            this.btnRelieve.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRelieve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnRelieve.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRelieve.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelieve.ForeColor = System.Drawing.Color.Black;
            this.btnRelieve.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRelieve.Location = new System.Drawing.Point(211, 712);
            this.btnRelieve.Name = "btnRelieve";
            this.btnRelieve.Size = new System.Drawing.Size(82, 31);
            this.btnRelieve.TabIndex = 57;
            this.btnRelieve.Text = "Relieve";
            this.btnRelieve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelieve.UseVisualStyleBackColor = false;
            this.btnRelieve.Click += new System.EventHandler(this.btnRelieve_Click);
            // 
            // mapa_Repartidor
            // 
            this.mapa_Repartidor.Bearing = 0F;
            this.mapa_Repartidor.CanDragMap = true;
            this.mapa_Repartidor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mapa_Repartidor.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapa_Repartidor.GrayScaleMode = false;
            this.mapa_Repartidor.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapa_Repartidor.LevelsKeepInMemmory = 5;
            this.mapa_Repartidor.Location = new System.Drawing.Point(35, 141);
            this.mapa_Repartidor.MarkersEnabled = true;
            this.mapa_Repartidor.MaxZoom = 2;
            this.mapa_Repartidor.MinZoom = 2;
            this.mapa_Repartidor.MouseWheelZoomEnabled = true;
            this.mapa_Repartidor.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mapa_Repartidor.Name = "mapa_Repartidor";
            this.mapa_Repartidor.NegativeMode = false;
            this.mapa_Repartidor.PolygonsEnabled = true;
            this.mapa_Repartidor.RetryLoadTile = 0;
            this.mapa_Repartidor.RoutesEnabled = true;
            this.mapa_Repartidor.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mapa_Repartidor.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapa_Repartidor.ShowTileGridLines = false;
            this.mapa_Repartidor.Size = new System.Drawing.Size(1117, 565);
            this.mapa_Repartidor.TabIndex = 56;
            this.mapa_Repartidor.Zoom = 0D;
            this.mapa_Repartidor.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mapa_Repartidor_MouseDoubleClick);
            // 
            // btnTrazaRuta
            // 
            this.btnTrazaRuta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            this.btnTrazaRuta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrazaRuta.FlatAppearance.BorderSize = 0;
            this.btnTrazaRuta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTrazaRuta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnTrazaRuta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTrazaRuta.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrazaRuta.ForeColor = System.Drawing.Color.Black;
            this.btnTrazaRuta.Image = global::Capa_Vista.Properties.Resources.camino;
            this.btnTrazaRuta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTrazaRuta.Location = new System.Drawing.Point(657, 730);
            this.btnTrazaRuta.Name = "btnTrazaRuta";
            this.btnTrazaRuta.Size = new System.Drawing.Size(249, 77);
            this.btnTrazaRuta.TabIndex = 18;
            this.btnTrazaRuta.Text = "Trazar Ruta";
            this.btnTrazaRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrazaRuta.UseVisualStyleBackColor = false;
            this.btnTrazaRuta.Click += new System.EventHandler(this.btnTrazaRuta_Click);
            // 
            // btnEntregaRealizada
            // 
            this.btnEntregaRealizada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            this.btnEntregaRealizada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntregaRealizada.FlatAppearance.BorderSize = 0;
            this.btnEntregaRealizada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEntregaRealizada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnEntregaRealizada.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEntregaRealizada.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntregaRealizada.ForeColor = System.Drawing.Color.Black;
            this.btnEntregaRealizada.Image = global::Capa_Vista.Properties.Resources.caja;
            this.btnEntregaRealizada.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEntregaRealizada.Location = new System.Drawing.Point(930, 728);
            this.btnEntregaRealizada.Name = "btnEntregaRealizada";
            this.btnEntregaRealizada.Size = new System.Drawing.Size(249, 79);
            this.btnEntregaRealizada.TabIndex = 17;
            this.btnEntregaRealizada.Text = "Entrega Completa\r\n\r\n";
            this.btnEntregaRealizada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntregaRealizada.UseVisualStyleBackColor = false;
            this.btnEntregaRealizada.Click += new System.EventHandler(this.btnEntregaRealizada_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(39, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Distancia de la entrega:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(29, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(409, 66);
            this.label3.TabIndex = 6;
            this.label3.Text = "¿ Donde entregar el pedido ?\r\n\r\n";
            // 
            // Menu_Repartidor_EntregaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1191, 861);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu_Repartidor_EntregaPedido";
            this.Text = "Menu_Repartidor_EntregaPedido";
            this.Load += new System.EventHandler(this.Menu_Repartidor_EntregaPedido_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnTrazaRuta;
        private System.Windows.Forms.Button btnEntregaRealizada;
        private System.Windows.Forms.Label label3;
        private GMap.NET.WindowsForms.GMapControl mapa_Repartidor;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnSatelital;
        private System.Windows.Forms.Button btnRelieve;
        private System.Windows.Forms.Button btnHibrido;
        private System.Windows.Forms.Label lblDistancia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGananciaEntrega;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRuta_NegClient;
        private System.Windows.Forms.Label lblRuta_RepNeg;
    }
}