namespace Capa_Vista
{
    partial class Menu_Usuario_CalificarPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCalificacion = new System.Windows.Forms.Label();
            this.trackBarOpciones = new System.Windows.Forms.TrackBar();
            this.txtNombreSeleccionado = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.RichTextBox();
            this.btnCancelarCalificacion = new System.Windows.Forms.Button();
            this.btnCalificar = new System.Windows.Forms.Button();
            this.dgvOpcionesCalificacion = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcionesCalificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-4, -4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1199, 850);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtCalificacion);
            this.tabPage2.Controls.Add(this.trackBarOpciones);
            this.tabPage2.Controls.Add(this.txtNombreSeleccionado);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtComentario);
            this.tabPage2.Controls.Add(this.btnCancelarCalificacion);
            this.tabPage2.Controls.Add(this.btnCalificar);
            this.tabPage2.Controls.Add(this.dgvOpcionesCalificacion);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1191, 824);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // txtCalificacion
            // 
            this.txtCalificacion.AutoSize = true;
            this.txtCalificacion.BackColor = System.Drawing.Color.Transparent;
            this.txtCalificacion.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalificacion.ForeColor = System.Drawing.Color.Black;
            this.txtCalificacion.Location = new System.Drawing.Point(334, 419);
            this.txtCalificacion.Name = "txtCalificacion";
            this.txtCalificacion.Size = new System.Drawing.Size(244, 24);
            this.txtCalificacion.TabIndex = 40;
            this.txtCalificacion.Text = "@@ CALIFICACION @@";
            // 
            // trackBarOpciones
            // 
            this.trackBarOpciones.AutoSize = false;
            this.trackBarOpciones.LargeChange = 1;
            this.trackBarOpciones.Location = new System.Drawing.Point(338, 446);
            this.trackBarOpciones.Maximum = 5;
            this.trackBarOpciones.Minimum = 1;
            this.trackBarOpciones.Name = "trackBarOpciones";
            this.trackBarOpciones.Size = new System.Drawing.Size(340, 45);
            this.trackBarOpciones.TabIndex = 39;
            this.trackBarOpciones.Value = 1;
            this.trackBarOpciones.Scroll += new System.EventHandler(this.trackBarOpciones_Scroll);
            // 
            // txtNombreSeleccionado
            // 
            this.txtNombreSeleccionado.AutoSize = true;
            this.txtNombreSeleccionado.BackColor = System.Drawing.Color.Transparent;
            this.txtNombreSeleccionado.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreSeleccionado.ForeColor = System.Drawing.Color.Black;
            this.txtNombreSeleccionado.Location = new System.Drawing.Point(33, 467);
            this.txtNombreSeleccionado.Name = "txtNombreSeleccionado";
            this.txtNombreSeleccionado.Size = new System.Drawing.Size(183, 24);
            this.txtNombreSeleccionado.TabIndex = 36;
            this.txtNombreSeleccionado.Text = "@@ NOMBRE @@";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(33, 416);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 24);
            this.label5.TabIndex = 35;
            this.label5.Text = "Ah calificar:";
            // 
            // txtComentario
            // 
            this.txtComentario.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(338, 497);
            this.txtComentario.MaxLength = 250;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(382, 196);
            this.txtComentario.TabIndex = 34;
            this.txtComentario.Text = "";
            // 
            // btnCancelarCalificacion
            // 
            this.btnCancelarCalificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            this.btnCancelarCalificacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarCalificacion.FlatAppearance.BorderSize = 0;
            this.btnCancelarCalificacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancelarCalificacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnCancelarCalificacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarCalificacion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarCalificacion.ForeColor = System.Drawing.Color.Black;
            this.btnCancelarCalificacion.Image = global::Capa_Vista.Properties.Resources.cancelar__2_;
            this.btnCancelarCalificacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarCalificacion.Location = new System.Drawing.Point(859, 663);
            this.btnCancelarCalificacion.Name = "btnCancelarCalificacion";
            this.btnCancelarCalificacion.Size = new System.Drawing.Size(249, 77);
            this.btnCancelarCalificacion.TabIndex = 33;
            this.btnCancelarCalificacion.Text = "Cancelar";
            this.btnCancelarCalificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarCalificacion.UseVisualStyleBackColor = false;
            this.btnCancelarCalificacion.Click += new System.EventHandler(this.btnCancelarCalificacion_Click_1);
            // 
            // btnCalificar
            // 
            this.btnCalificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            this.btnCalificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalificar.FlatAppearance.BorderSize = 0;
            this.btnCalificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCalificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btnCalificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCalificar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalificar.ForeColor = System.Drawing.Color.Black;
            this.btnCalificar.Image = global::Capa_Vista.Properties.Resources.garrapata;
            this.btnCalificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalificar.Location = new System.Drawing.Point(859, 559);
            this.btnCalificar.Name = "btnCalificar";
            this.btnCalificar.Size = new System.Drawing.Size(249, 79);
            this.btnCalificar.TabIndex = 32;
            this.btnCalificar.Text = "Calificar";
            this.btnCalificar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalificar.UseVisualStyleBackColor = false;
            this.btnCalificar.Click += new System.EventHandler(this.btnCalificar_Click_1);
            // 
            // dgvOpcionesCalificacion
            // 
            this.dgvOpcionesCalificacion.AllowUserToAddRows = false;
            this.dgvOpcionesCalificacion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            this.dgvOpcionesCalificacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvOpcionesCalificacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOpcionesCalificacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvOpcionesCalificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOpcionesCalificacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOpcionesCalificacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOpcionesCalificacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvOpcionesCalificacion.ColumnHeadersHeight = 30;
            this.dgvOpcionesCalificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOpcionesCalificacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.FechaCompra,
            this.dataGridViewTextBoxColumn3});
            this.dgvOpcionesCalificacion.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOpcionesCalificacion.DefaultCellStyle = dataGridViewCellStyle25;
            this.dgvOpcionesCalificacion.EnableHeadersVisualStyles = false;
            this.dgvOpcionesCalificacion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.dgvOpcionesCalificacion.Location = new System.Drawing.Point(37, 132);
            this.dgvOpcionesCalificacion.Name = "dgvOpcionesCalificacion";
            this.dgvOpcionesCalificacion.ReadOnly = true;
            this.dgvOpcionesCalificacion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOpcionesCalificacion.RowHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgvOpcionesCalificacion.RowHeadersVisible = false;
            this.dgvOpcionesCalificacion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(109)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.White;
            this.dgvOpcionesCalificacion.RowsDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvOpcionesCalificacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOpcionesCalificacion.Size = new System.Drawing.Size(829, 262);
            this.dgvOpcionesCalificacion.TabIndex = 31;
            this.dgvOpcionesCalificacion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvOpcionesCalificacion_MouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn1.FillWeight = 94.90359F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NumeroTelefono";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn2.FillWeight = 104.2396F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Telefono";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // FechaCompra
            // 
            this.FechaCompra.DataPropertyName = "MontoColones";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.FechaCompra.DefaultCellStyle = dataGridViewCellStyle23;
            this.FechaCompra.HeaderText = "Monto de compra";
            this.FechaCompra.Name = "FechaCompra";
            this.FechaCompra.ReadOnly = true;
            this.FechaCompra.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Calificacion";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewTextBoxColumn3.FillWeight = 100.7237F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Calificacion";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(31, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(372, 66);
            this.label6.TabIndex = 30;
            this.label6.Text = "¿ A quien deseas calificar ?\r\n\r\n";
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 17);
            this.label1.TabIndex = 41;
            this.label1.Text = "**Doble click para seleccionar un sujeto a calificar\r\n";
            // 
            // Menu_Usuario_CalificarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1191, 861);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu_Usuario_CalificarPedido";
            this.Text = "Menu_Usuario_CalificarPedido";
            this.Load += new System.EventHandler(this.Menu_Usuario_CalificarPedido_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcionesCalificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label txtCalificacion;
        private System.Windows.Forms.TrackBar trackBarOpciones;
        private System.Windows.Forms.Label txtNombreSeleccionado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtComentario;
        private System.Windows.Forms.Button btnCancelarCalificacion;
        private System.Windows.Forms.Button btnCalificar;
        private System.Windows.Forms.DataGridView dgvOpcionesCalificacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label1;
    }
}