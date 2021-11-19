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
    public partial class Menu_Repartidor_AceptarPedido : Form
    {

        //**************************************************
        //**************************************************
        //brindan la actividad normal de la ventana
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Usuario LocalUser = Menu_Repartidor.userAux;
        //**************************************************
        //**************************************************



        public Menu_Repartidor_AceptarPedido()
        {
            InitializeComponent();

            
            this.LlenaDGV_Opciones();

            foreach (DataGridViewRow fila in dgvNegocios_Disponibles_.Rows)
                fila.Height = 100;
            dgvNegocios_Disponibles_.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvNegocios_Disponibles_.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvNegocios_Disponibles_.RowTemplate.Height = 100;

            log.Info("SE ABRIO EL FRM_ACEPTAR _PEDIDO");

            LocalUser = Menu_Repartidor.userAux;

            this.btnAceptarPedido.Enabled = false;
            this.btnCancelarSeleccion.Enabled = false;
        }


        private void LlenaDGV_Opciones()
        {
            // this.dgvOpcionesCalificacion.Rows.Clear();
            this.dgvNegocios_Disponibles_.ClearSelection();

            FacturacionLN fact = new FacturacionLN();
            this.dgvNegocios_Disponibles_.DataSource = fact.RetornaOrdenesAceptadas();
        }
        private void Menu_Repartidor_AceptarPedido_Load(object sender, EventArgs e)
        {
            if (this.dgvNegocios_Disponibles_.Rows.Count <= 0)
            {
                MessageBox.Show("No hay mas ordenes disponibles por ser entregadas");
                return;
            }
            if ((LocalUser as Usuario_Repartidor)._UsuarioPaquete != null)
            {
                MessageBox.Show("Hay una entrega en curso,favor terminar la actual antes de seleccionar otra");
                return;
            }
        }


        private void btnAceptarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvNegocios_Disponibles_.Rows.Count <= 0)
                {
                    MessageBox.Show("No hay mas ordenes disponibles por ser entregadas");
                    return;
                }
                if((LocalUser as Usuario_Repartidor)._UsuarioPaquete != null)
                {
                    MessageBox.Show("Hay una entrega en curso,favor terminar la actual antes de seleccionar otra");
                    return;
                }
                this.errProvider.Clear();

                if (this.dgvNegocios_Disponibles_.SelectedRows.Count == 0)
                {
                    this.errProvider.SetError(this.dgvNegocios_Disponibles_, "Dato requerido");
                    return;
                }


                string NumeroOrden = this.dgvNegocios_Disponibles_.CurrentRow.Cells[1].Value.ToString();

                List<string> listUser = new List<string>();
                List<string> listComer = new List<string>();

                FacturacionLN fact = new FacturacionLN();
                listUser=fact.AceptarOrdenEntrega(Convert.ToInt32(NumeroOrden),LocalUser.Identificacion);// asigna que esta obtenida por repartidor
                listComer = fact.DevuelveComercioOrden(Convert.ToInt32(NumeroOrden));

                UsuarioLN ln = new UsuarioLN();
                Usuario user = ln.ObtenerUsuario_Cliente(listUser.ElementAt<string>(0), listUser.ElementAt<string>(1));
                Usuario seller= ln.ObtenerUsuario_Comercio(listComer.ElementAt<string>(0), listComer.ElementAt<string>(1));

                (LocalUser as Usuario_Repartidor)._UsuarioPaquete = user;
                (LocalUser as Usuario_Repartidor)._UsuarioComercio = seller;

                Menu_Repartidor.userAux = LocalUser;
                Menu_Repartidor.numOrdenAceptada = Convert.ToInt32(NumeroOrden);

                MessageBox.Show("Seleccion de entrega exitosa");
                log.Info("PAQUETE ACEPTADO PARA SER REPARTIDO POR: "+LocalUser.Nombre);
                this.dataGridView1.Rows.Clear();
                this.LlenaDGV_Opciones();

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
                if (this.dgvNegocios_Disponibles_.Rows.Count <= 0)
                {
                    MessageBox.Show("No hay mas ordenes disponibles por ser entregadas");
                    return;
                }
                if ((LocalUser as Usuario_Repartidor)._UsuarioPaquete != null)
                {
                    MessageBox.Show("Hay una entrega en curso,favor terminar la actual antes de seleccionar otra");
                    return;
                }

                this.dgvNegocios_Disponibles_.ClearSelection();
                

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


        private void dgvNegocios_Disponibles__MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.dataGridView1.Rows.Clear();

                string NumeroOrden = this.dgvNegocios_Disponibles_.CurrentRow.Cells[1].Value.ToString();
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

        private void dgvNegocios_Disponibles__MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.dgvNegocios_Disponibles_.ClearSelection();
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
