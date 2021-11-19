using Capa_Entidades.Clases;
using Capa_Logica_Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista
{
    public partial class Menu_Usuario_CalificarPedido : Form
    {

        //**************************************************
        //**************************************************
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //brindan la actividad normal de la ventana
        private Usuario LocalUser = Menu_Usuario.userAux;

        //**************************************************
        //**************************************************

        private string NumeroTelefono = "";


        public Menu_Usuario_CalificarPedido()
        {
            InitializeComponent();
            LocalUser = Menu_Usuario.userAux;
            this.txtCalificacion.Text = "Muy mal";
            this.trackBarOpciones.Value = 1;
            this.txtNombreSeleccionado.Text = "_ _ _ _ _ _";

            this.LlenaDGV_OpcionesSujetos();

            foreach (DataGridViewRow fila in dgvOpcionesCalificacion.Rows)
                fila.Height = 65;
            dgvOpcionesCalificacion.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvOpcionesCalificacion.RowTemplate.Height = 65;

            log.Info("SE ABRIO EL FRM_CALIFICAR_PEDIDO");

        }






        private void LlenaDGV_OpcionesSujetos()
        {

            // this.dgvOpcionesCalificacion.Rows.Clear();
            this.dgvOpcionesCalificacion.ClearSelection();

            FacturacionLN fact = new FacturacionLN();
            this.dgvOpcionesCalificacion.DataSource = fact.RetornarnaSujetosDisponiblesCalificacion(LocalUser.Identificacion);



        }


        private void dgvOpcionesCalificacion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.dgvOpcionesCalificacion.SelectedRows.Count == 0)
                {
                    this.errProvider.SetError(this.txtCalificacion, "Dato requerido");
                    return;
                }

                string nombre = this.dgvOpcionesCalificacion.CurrentRow.Cells[0].Value.ToString();
                this.txtNombreSeleccionado.Text = nombre;

                NumeroTelefono = this.dgvOpcionesCalificacion.CurrentRow.Cells[1].Value.ToString();


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
        private void trackBarOpciones_Scroll(object sender, EventArgs e)
        {
            if (this.trackBarOpciones.Value == 1)
                this.txtCalificacion.Text = "Muy mal";
            if (this.trackBarOpciones.Value == 2)
                this.txtCalificacion.Text = "Mal";
            if (this.trackBarOpciones.Value == 3)
                this.txtCalificacion.Text = "Bueno";
            if (this.trackBarOpciones.Value == 4)
                this.txtCalificacion.Text = "Muy bueno";
            if (this.trackBarOpciones.Value == 5)
                this.txtCalificacion.Text = "Excelente";
        }
        private void Menu_Usuario_CalificarPedido_Load(object sender, EventArgs e)
        {
            if (this.dgvOpcionesCalificacion.Rows.Count <= 0)
            {
                MessageBox.Show("No hay calificaciones disponibles, favor hacer una compra primero o si ya hizo una esperar que la compra sea entregada por un repartidor");
                return;
            }
        }



        private void btnCalificar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvOpcionesCalificacion.Rows.Count <= 0)
            {
                MessageBox.Show("No hay calificaciones disponibles, favor hacer una compra primero");
                return;
            }

            try
            {
                //validaciones de campos
                try
                {
                    this.errProvider.Clear();

                    if (string.IsNullOrEmpty(this.txtComentario.Text))
                    {
                        this.errProvider.SetError(this.txtCalificacion, "Dato requerido");
                        return;
                    }
                    if (this.dgvOpcionesCalificacion.SelectedRows.Count == 0)
                    {
                        this.errProvider.SetError(this.txtCalificacion, "Dato requerido");
                        return;
                    }

                    int identificacionU = LocalUser.Identificacion;
               
                    string comment = this.txtComentario.Text;

                    int calificacion = 0;

                    if (this.trackBarOpciones.Value == 1)
                        calificacion = 2;
                    if (this.trackBarOpciones.Value == 2)
                        calificacion = 4;
                    if (this.trackBarOpciones.Value == 3)
                        calificacion = 6;
                    if (this.trackBarOpciones.Value == 4)
                        calificacion = 8;
                    if (this.trackBarOpciones.Value == 5)
                        calificacion = 10;


                    FacturacionLN fact = new FacturacionLN();
                    fact.IngresaCalificacion(identificacionU, NumeroTelefono, calificacion, comment);



                    MessageBox.Show("Calificacion dada exitosamente");
                    log.Info("SE HA EFECTUADO UNA CALIFICACION EXITOSAMENTE POR: "+LocalUser.Nombre);

                    this.LlenaDGV_OpcionesSujetos();

                    this.txtComentario.Text = "";

                    this.txtCalificacion.Text = "Muy mal";
                    this.trackBarOpciones.Value = 1;

                    this.txtNombreSeleccionado.Text = "_ _ _ _ _ _";

                    if (this.dgvOpcionesCalificacion.Rows.Count <= 0)
                    {
                        MessageBox.Show("No hay mas calificaciones disponibles, favor hacer una compra primero");
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
        private void btnCancelarCalificacion_Click_1(object sender, EventArgs e)
        {

            if (this.dgvOpcionesCalificacion.Rows.Count <= 0)
            {
                MessageBox.Show("No hay calificaciones disponibles, favor hacer una compra primero");
                return;
            }

            try
            {

                this.txtCalificacion.Text = "";

                this.txtCalificacion.Text = "Muy mal";
                this.trackBarOpciones.Value = 1;

                this.txtNombreSeleccionado.Text = "_ _ _ _ _ _";

                this.dgvOpcionesCalificacion.ClearSelection();

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





    }
}
