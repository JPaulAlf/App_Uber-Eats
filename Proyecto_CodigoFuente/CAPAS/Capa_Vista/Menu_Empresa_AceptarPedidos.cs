using Capa_Entidades.Clases;
using Capa_Logica_Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista
{
    public partial class Menu_Empresa_AceptarPedidos : Form
    {
        //**************************************************
        //**************************************************
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //brindan la actividad normal de la ventana
        private Usuario LocalUser = Menu_Empresa.userAux;

        //**************************************************
        //**************************************************

        public Menu_Empresa_AceptarPedidos()
        {
            InitializeComponent();
            LocalUser = Menu_Empresa.userAux;

            
            this.LlenaDGV_Opciones();

            foreach (DataGridViewRow fila in dgvOrdenesDisponibles.Rows)
                fila.Height = 65;
            dgvOrdenesDisponibles.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvOrdenesDisponibles.RowTemplate.Height = 65;

            log.Info("SE ABRIO EL FRM_ACEPTAR_PEDIDO");

            this.btnAceptarPedido.Enabled = false;
            this.btnCancelarSeleccion.Enabled = false;
        }

        private void LlenaDGV_Opciones()
        {

            // this.dgvOpcionesCalificacion.Rows.Clear();
            this.dgvOrdenesDisponibles.ClearSelection();

            FacturacionLN fact = new FacturacionLN();
            this.dgvOrdenesDisponibles.DataSource = fact.RetornaOrdenesDisponiblesParaAceptar(LocalUser.Identificacion);



        }
        private void Menu_Empresa_AceptarPedidos_Load(object sender, EventArgs e)
        {
            if (this.dgvOrdenesDisponibles.Rows.Count <= 0)
            {
                MessageBox.Show("No hay mas ordenes disponibles por ser aceptadas");
                return;
            }
        }



        private void btnAceptarPedido_Click(object sender, EventArgs e)
        { 
            try
            {
                if (this.dgvOrdenesDisponibles.Rows.Count <= 0)
                {
                    MessageBox.Show("No hay mas ordenes disponibles por ser aceptadas");
                    return;
                }


                this.errProvider.Clear();

                if (this.dgvOrdenesDisponibles.SelectedRows.Count == 0)
                {
                    this.errProvider.SetError(this.dgvOrdenesDisponibles, "Dato requerido");
                    return;
                }

                string NumeroOrden = this.dgvOrdenesDisponibles.CurrentRow.Cells[0].Value.ToString();

                FacturacionLN fact = new FacturacionLN();
                fact.ActualizaEstaAceptado(Convert.ToInt32(NumeroOrden));
                MessageBox.Show("Producto aceptado y despachado para ser entregado");
                log.Info("SE DESPACHO UN PRODUCTO PARA SER ENTREGADO AL CLIENTE");
                this.dgvOrdenesDisponibles.ClearSelection();
                this.dataGridView1.Rows.Clear();
                this.LlenaDGV_Opciones();

                if (this.dgvOrdenesDisponibles.Rows.Count <= 0)
                {
                    MessageBox.Show("No hay mas ordenes disponibles por ser aceptadas");
                    return;
                }


            }
            catch (Exception err)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", err.Message);
                msg.AppendFormat("Source         {0}\n", err.Source);
                msg.AppendFormat("Data           {0}\n", err.Data);
                msg.AppendFormat("InnerException {0}\n", err.InnerException);

                log.Error(msg.ToString());
                MessageBox.Show("Se ha producido un error FORZADO:\n\nRevise el LOG\n\n" + err.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelarSeleccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvOrdenesDisponibles.Rows.Count <= 0)
                {
                    MessageBox.Show("No hay mas ordenes disponibles por ser aceptadas");
                    return;
                }

                this.dataGridView1.Rows.Clear();
                this.dgvOrdenesDisponibles.ClearSelection();
                this.btnAceptarPedido.Enabled = false;
                this.btnCancelarSeleccion.Enabled = false;
            }
            catch (Exception err)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", err.Message);
                msg.AppendFormat("Source         {0}\n", err.Source);
                msg.AppendFormat("Data           {0}\n", err.Data);
                msg.AppendFormat("InnerException {0}\n", err.InnerException);

                log.Error(msg.ToString());
                MessageBox.Show("Se ha producido un error FORZADO:\n\nRevise el LOG\n\n" + err.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dgvOrdenesDisponibles_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.dataGridView1.Rows.Clear();

                string NumeroOrden = this.dgvOrdenesDisponibles.CurrentRow.Cells[0].Value.ToString();
                int num = Convert.ToInt32(NumeroOrden);

                ArticuloLN art = new ArticuloLN();
                foreach (Articulo item in art.ObtenerListaProductos_OrdenPagada(num))
                {
                    Image imagen1 = this.ByteArrayToImage(item.Fotografia);

                    dataGridView1.Rows.Add
                        (
                        item.Nombre,
                        item.Cantidad,
                        imagen1
                        );
                }

                foreach (DataGridViewRow fila in dataGridView1.Rows)
                    fila.Height = 100;
                dataGridView1.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                this.btnAceptarPedido.Enabled = true;
                this.btnCancelarSeleccion.Enabled = true;
            }
            catch (Exception err)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", err.Message);
                msg.AppendFormat("Source         {0}\n", err.Source);
                msg.AppendFormat("Data           {0}\n", err.Data);
                msg.AppendFormat("InnerException {0}\n", err.InnerException);

                log.Error(msg.ToString());
                MessageBox.Show("Se ha producido un error FORZADO:\n\nRevise el LOG\n\n" + err.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvOrdenesDisponibles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.dgvOrdenesDisponibles.ClearSelection();
            this.btnAceptarPedido.Enabled = false;
            this.btnCancelarSeleccion.Enabled = false;
        }


        public Image ByteArrayToImage(byte[] byteArray)
        {

            MemoryStream ms = new MemoryStream(byteArray);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);

            return returnImage;
        }



    }
}
