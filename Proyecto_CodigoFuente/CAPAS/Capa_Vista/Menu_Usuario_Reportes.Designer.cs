namespace Capa_Vista
{
    partial class Menu_Usuario_Reportes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Usuario_Reportes));
            this.PA_REPORTE_CLIENTE_CuponesObtenidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.JustEat_Pry5CTDataSet = new Capa_Vista.JustEat_Pry5CTDataSet();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAtrasPedidos = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pnlCuentaRepartidor = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pnlCuentaEmpresa = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAtrasCupones = new System.Windows.Forms.Button();
            this.PA_REPORTE_CLIENTE_CuponesObtenidosTableAdapter = new Capa_Vista.JustEat_Pry5CTDataSetTableAdapters.PA_REPORTE_CLIENTE_CuponesObtenidosTableAdapter();
            this.label50 = new System.Windows.Forms.Label();
            this.cbxNegociosDisponibles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.JustEat_Pry5CTDataSet3 = new Capa_Vista.JustEat_Pry5CTDataSet3();
            this.PA_REPORTE_OrdenesClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PA_REPORTE_OrdenesClienteTableAdapter = new Capa_Vista.JustEat_Pry5CTDataSet3TableAdapters.PA_REPORTE_OrdenesClienteTableAdapter();
            this.justEatPry5CTDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_CLIENTE_CuponesObtenidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JustEat_Pry5CTDataSet)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.pnlCuentaRepartidor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.pnlCuentaEmpresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JustEat_Pry5CTDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_OrdenesClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.justEatPry5CTDataSet3BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PA_REPORTE_CLIENTE_CuponesObtenidosBindingSource
            // 
            this.PA_REPORTE_CLIENTE_CuponesObtenidosBindingSource.DataMember = "PA_REPORTE_CLIENTE_CuponesObtenidos";
            this.PA_REPORTE_CLIENTE_CuponesObtenidosBindingSource.DataSource = this.JustEat_Pry5CTDataSet;
            // 
            // JustEat_Pry5CTDataSet
            // 
            this.JustEat_Pry5CTDataSet.DataSetName = "JustEat_Pry5CTDataSet";
            this.JustEat_Pry5CTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage5.Controls.Add(this.reportViewer2);
            this.tabPage5.Controls.Add(this.panel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1192, 830);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            // 
            // reportViewer2
            // 
            this.reportViewer2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer2.IsDocumentMapWidthFixed = true;
            reportDataSource1.Name = "DataSet3";
            reportDataSource1.Value = this.PA_REPORTE_OrdenesClienteBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Capa_Vista.Asistente_Informes_Reportviewer.Report_Cliente_PedidosRealizados.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(3, 77);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1186, 750);
            this.reportViewer2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label50);
            this.panel1.Controls.Add(this.cbxNegociosDisponibles);
            this.panel1.Controls.Add(this.btnAtrasPedidos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 74);
            this.panel1.TabIndex = 0;
            // 
            // btnAtrasPedidos
            // 
            this.btnAtrasPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            this.btnAtrasPedidos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAtrasPedidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtrasPedidos.FlatAppearance.BorderSize = 0;
            this.btnAtrasPedidos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAtrasPedidos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnAtrasPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtrasPedidos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtrasPedidos.ForeColor = System.Drawing.Color.Black;
            this.btnAtrasPedidos.Image = global::Capa_Vista.Properties.Resources.camara_trasera__2_;
            this.btnAtrasPedidos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAtrasPedidos.Location = new System.Drawing.Point(11, 15);
            this.btnAtrasPedidos.Name = "btnAtrasPedidos";
            this.btnAtrasPedidos.Size = new System.Drawing.Size(101, 44);
            this.btnAtrasPedidos.TabIndex = 18;
            this.btnAtrasPedidos.Text = "Atras";
            this.btnAtrasPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtrasPedidos.UseVisualStyleBackColor = false;
            this.btnAtrasPedidos.Click += new System.EventHandler(this.btnAtrasPedidos_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage4.Controls.Add(this.pnlCuentaRepartidor);
            this.tabPage4.Controls.Add(this.pnlCuentaEmpresa);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1192, 830);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            // 
            // pnlCuentaRepartidor
            // 
            this.pnlCuentaRepartidor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            this.pnlCuentaRepartidor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCuentaRepartidor.Controls.Add(this.label19);
            this.pnlCuentaRepartidor.Controls.Add(this.pictureBox4);
            this.pnlCuentaRepartidor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCuentaRepartidor.Location = new System.Drawing.Point(309, 380);
            this.pnlCuentaRepartidor.Name = "pnlCuentaRepartidor";
            this.pnlCuentaRepartidor.Size = new System.Drawing.Size(561, 103);
            this.pnlCuentaRepartidor.TabIndex = 16;
            this.pnlCuentaRepartidor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlReportesCupone_MouseClick);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(132, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(290, 25);
            this.label19.TabIndex = 10;
            this.label19.Text = "Reporte cupones obtenidos";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Enabled = false;
            this.pictureBox4.Image = global::Capa_Vista.Properties.Resources.cupon__2_;
            this.pictureBox4.Location = new System.Drawing.Point(22, 13);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(68, 68);
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pnlCuentaEmpresa
            // 
            this.pnlCuentaEmpresa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            this.pnlCuentaEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCuentaEmpresa.Controls.Add(this.label22);
            this.pnlCuentaEmpresa.Controls.Add(this.pictureBox3);
            this.pnlCuentaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCuentaEmpresa.ForeColor = System.Drawing.Color.White;
            this.pnlCuentaEmpresa.Location = new System.Drawing.Point(309, 249);
            this.pnlCuentaEmpresa.Name = "pnlCuentaEmpresa";
            this.pnlCuentaEmpresa.Size = new System.Drawing.Size(561, 103);
            this.pnlCuentaEmpresa.TabIndex = 15;
            this.pnlCuentaEmpresa.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlReportesPedido_MouseClick);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(132, 38);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(288, 25);
            this.label22.TabIndex = 7;
            this.label22.Text = "Reporte pedidos realizados";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Enabled = false;
            this.pictureBox3.Image = global::Capa_Vista.Properties.Resources.orden;
            this.pictureBox3.Location = new System.Drawing.Point(22, 18);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(68, 67);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(-6, -7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 856);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1192, 830);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "tabPage1";
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.PA_REPORTE_CLIENTE_CuponesObtenidosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Capa_Vista.Asistente_Informes_Reportviewer.Report_Cliente_CuponesObtenidos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 53);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1186, 774);
            this.reportViewer1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAtrasCupones);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1186, 50);
            this.panel2.TabIndex = 1;
            // 
            // btnAtrasCupones
            // 
            this.btnAtrasCupones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            this.btnAtrasCupones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAtrasCupones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtrasCupones.FlatAppearance.BorderSize = 0;
            this.btnAtrasCupones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAtrasCupones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnAtrasCupones.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtrasCupones.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtrasCupones.ForeColor = System.Drawing.Color.Black;
            this.btnAtrasCupones.Image = global::Capa_Vista.Properties.Resources.camara_trasera__2_;
            this.btnAtrasCupones.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAtrasCupones.Location = new System.Drawing.Point(7, 3);
            this.btnAtrasCupones.Name = "btnAtrasCupones";
            this.btnAtrasCupones.Size = new System.Drawing.Size(101, 44);
            this.btnAtrasCupones.TabIndex = 18;
            this.btnAtrasCupones.Text = "Atras";
            this.btnAtrasCupones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtrasCupones.UseVisualStyleBackColor = false;
            this.btnAtrasCupones.Click += new System.EventHandler(this.btnAtrasCupones_Click);
            // 
            // PA_REPORTE_CLIENTE_CuponesObtenidosTableAdapter
            // 
            this.PA_REPORTE_CLIENTE_CuponesObtenidosTableAdapter.ClearBeforeFill = true;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.Transparent;
            this.label50.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label50.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.Black;
            this.label50.Location = new System.Drawing.Point(782, 27);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(174, 21);
            this.label50.TabIndex = 23;
            this.label50.Text = "Negocios disponibles:";
            // 
            // cbxNegociosDisponibles
            // 
            this.cbxNegociosDisponibles.BackColor = System.Drawing.Color.White;
            this.cbxNegociosDisponibles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxNegociosDisponibles.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNegociosDisponibles.FormattingEnabled = true;
            this.cbxNegociosDisponibles.Location = new System.Drawing.Point(958, 24);
            this.cbxNegociosDisponibles.Name = "cbxNegociosDisponibles";
            this.cbxNegociosDisponibles.Size = new System.Drawing.Size(210, 29);
            this.cbxNegociosDisponibles.TabIndex = 24;
            this.cbxNegociosDisponibles.SelectedIndexChanged += new System.EventHandler(this.cbxTipoVehiculo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(118, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "**Favor seleccionar un negocio para ver sus reportes correspondientes";
            // 
            // JustEat_Pry5CTDataSet3
            // 
            this.JustEat_Pry5CTDataSet3.DataSetName = "JustEat_Pry5CTDataSet3";
            this.JustEat_Pry5CTDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PA_REPORTE_OrdenesClienteBindingSource
            // 
            this.PA_REPORTE_OrdenesClienteBindingSource.DataMember = "PA_REPORTE_OrdenesCliente";
            this.PA_REPORTE_OrdenesClienteBindingSource.DataSource = this.JustEat_Pry5CTDataSet3;
            // 
            // PA_REPORTE_OrdenesClienteTableAdapter
            // 
            this.PA_REPORTE_OrdenesClienteTableAdapter.ClearBeforeFill = true;
            // 
            // justEatPry5CTDataSet3BindingSource
            // 
            this.justEatPry5CTDataSet3BindingSource.DataSource = this.JustEat_Pry5CTDataSet3;
            this.justEatPry5CTDataSet3BindingSource.Position = 0;
            // 
            // Menu_Usuario_Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1191, 861);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_Usuario_Reportes";
            this.Text = "Menu_Usuario_Reportes";
            this.Load += new System.EventHandler(this.Menu_Usuario_Reportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_CLIENTE_CuponesObtenidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JustEat_Pry5CTDataSet)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.pnlCuentaRepartidor.ResumeLayout(false);
            this.pnlCuentaRepartidor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.pnlCuentaEmpresa.ResumeLayout(false);
            this.pnlCuentaEmpresa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.JustEat_Pry5CTDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_OrdenesClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.justEatPry5CTDataSet3BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlCuentaRepartidor;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel pnlCuentaEmpresa;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAtrasPedidos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAtrasCupones;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource PA_REPORTE_CLIENTE_CuponesObtenidosBindingSource;
        private JustEat_Pry5CTDataSet JustEat_Pry5CTDataSet;
        private JustEat_Pry5CTDataSetTableAdapters.PA_REPORTE_CLIENTE_CuponesObtenidosTableAdapter PA_REPORTE_CLIENTE_CuponesObtenidosTableAdapter;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.ComboBox cbxNegociosDisponibles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource PA_REPORTE_OrdenesClienteBindingSource;
        private JustEat_Pry5CTDataSet3 JustEat_Pry5CTDataSet3;
        private JustEat_Pry5CTDataSet3TableAdapters.PA_REPORTE_OrdenesClienteTableAdapter PA_REPORTE_OrdenesClienteTableAdapter;
        private System.Windows.Forms.BindingSource justEatPry5CTDataSet3BindingSource;
    }
}