using Capa_Entidades.Clases;
using Capa_Entidades.Factory;
using Capa_Logica_Negocios;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista
{
    public partial class Menu_Empresa_Cupones : Form
    {

        //***************************************************
        //***************************************************
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //Persistencia de usuarioLogeado
        public static Usuario usuarioAux = Menu_Empresa.userAux;

        //***************************************************
        //***************************************************


        private string identificacionProductoOriginal = "";
        Articulo articuloAux = null;
        ArticuloLN itemBD = null;



        public Menu_Empresa_Cupones()
        {
            InitializeComponent();

            txtFechaVencimiento.Format = DateTimePickerFormat.Custom;
            txtFechaVencimiento.CustomFormat = "dd-MMMM- yyyy";
            txtFechaVencimiento.ShowUpDown = true;
            txtFechaVencimiento.MinDate = DateTime.Now;

            txtFechaVencimiento_Gestor.Format = DateTimePickerFormat.Custom;
            txtFechaVencimiento_Gestor.CustomFormat = "dd-MMMM- yyyy";
            txtFechaVencimiento_Gestor.ShowUpDown = true;
            txtFechaVencimiento_Gestor.MinDate = DateTime.Now;

            this.txtFechaVencimiento.Value = DateTime.Now;
            this.txtFechaVencimiento_Gestor.Value = DateTime.Now;

            dgvProductos_Disponibles.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            log.Info("SE ABRIO EL FRM_CUPONES");

            usuarioAux = Menu_Empresa.userAux;
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                tabControl1.SelectedIndex = 1;



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

        private void btnGestionar_Click(object sender, EventArgs e)
        {
            try
            {

                tabControl1.SelectedIndex = 2;
                this.CargaDGV_Cupones();


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


        private void dgvProductos_Disponibles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (this.dgvProductos_Disponibles.Columns[e.ColumnIndex].Name == "Estado")
            {
                try
                {
                    if (e.Value.GetType() != typeof(DBNull))
                    {

                        if (e.Value.ToString() == "INACTIVO")
                        {
                            e.CellStyle.ForeColor = Color.Red;
                        }


                    }
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("");
                }
            }
        }
        private void dgvProductos_Disponibles_DoubleClick(object sender, EventArgs e)
        {
            this.dgvProductos_Disponibles.ClearSelection();
        }
        private void CargaDGV_Cupones()
        {
            try
            {
                this.dgvProductos_Disponibles.Rows.Clear();
                string estado = "";

                itemBD = new ArticuloLN();

                foreach (Articulo item in itemBD.ObtenerListaCupones_SinFiltro(usuarioAux))
                {
                    estado = ArticuloLN.PA_VerificaArticulo_Estado(item.Identificacion);

                    Image imagen1 = this.ByteArrayToImage(item.Fotografia);
                    Image imagen2= this.ByteArrayToImage((item as Articulo_Cupon).CodigoQR);

                    this.dgvProductos_Disponibles.Rows.Add(
                        item.Identificacion,
                        item.Nombre,
                        "₡" + item.Precio.ToString("#,###,###.00"),
                        imagen1,
                        imagen2,
                        (item as Articulo_Cupon).FechaVencimiento.ToString("dd/MM/yy"),
                        estado
                        ) ;

                }

                foreach (DataGridViewRow fila in dgvProductos_Disponibles.Rows)
                    fila.Height = 100;

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
        private void cargaObjetosVentana_Gestionar(Articulo pArticulo)
        {
            this.txtIdentificacion_Gestor.Text = pArticulo.Identificacion;
            this.txtNombre_Gestor.Text = pArticulo.Nombre;
            this.txtPrecio_Gestor.Text = pArticulo.Precio.ToString();

            Image imagen1 = this.ByteArrayToImage(pArticulo.Fotografia);
            Image imagen2 = this.ByteArrayToImage((pArticulo as Articulo_Cupon).CodigoQR);
            this.picImagen_Gestor.Image = imagen1;
            this.pnlCodigoQR_Gestor.Image = imagen2;

            this.txtDescripcion_Gestor.Text = pArticulo.Descripcion;
            this.txtFechaVencimiento_Gestor.Value = (pArticulo as Articulo_Cupon).FechaVencimiento;

        }




        //---------------------------------------------------------------




        #region AREA GUARDAR
        private void btnAtras_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.LimpiarCampos_Guardar();
                this.errProvider.Clear();
                tabControl1.SelectedIndex = 0;
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

        private void btnBuscarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                opFile_Guardar.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png";
                this.opFile_Guardar.ShowDialog();
                if (this.opFile_Guardar.FileName.Equals("") == false)
                {
                    this.picImagenProducto_Guardar.Load(this.opFile_Guardar.FileName);
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
                //MessageBox.Show("Se ha producido un error FORZADO:\n\nRevise el LOG\n\n" + err.Message,
                //    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarQR_Click(object sender, EventArgs e)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(this.txtIdentificacion.Text, out qrCode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero),Brushes.Black,Brushes.White);
            MemoryStream ms = new MemoryStream();

            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var image = new Bitmap(imageTemporal, new Size(new Point(249, 189)));
            this.pnlQR.Image = image;

            //Image xv = image;
            //this.picImagenProducto_Guardar.Image = xv;
            //image.Save("imagen.png", ImageFormat.Png);

        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            try  
            {
                //validaciones de campos
                try
                {
                    this.errProvider.Clear();

                    //Verifica que no esten vacios
                    if (string.IsNullOrEmpty(this.txtIdentificacion.Text))
                    {
                        this.errProvider.SetError(this.txtIdentificacion, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtNombre.Text))
                    {
                        this.errProvider.SetError(this.txtNombre, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtPrecio.Text))
                    {
                        this.errProvider.SetError(this.txtPrecio, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtDescripcion.Text))
                    {
                        this.errProvider.SetError(this.txtDescripcion, "Dato requerido");
                        return;
                    }
                    if (this.picImagenProducto_Guardar.Image == null)
                    {
                        this.errProvider.SetError(this.picImagenProducto_Guardar, "Dato requerido");
                        return;
                    }
                    if (this.pnlQR.Image == null)
                    {
                        this.errProvider.SetError(this.pnlQR, "Dato requerido");
                        return;
                    }

                    //Verifica si, corresponden realmente a los datos deseados
                    long numero = 0;
                   
                    if (!long.TryParse(this.txtPrecio.Text, out numero))
                    {
                        this.errProvider.SetError(this.txtPrecio, "Debe ser numerico unicamente");
                        return;
                    }
                    if (long.TryParse(this.txtNombre.Text, out numero))
                    {
                        this.errProvider.SetError(this.txtNombre, "No debe ser numerico");
                        return;
                    }
                    if (long.TryParse(this.txtDescripcion.Text, out numero))
                    {
                        this.errProvider.SetError(this.txtDescripcion, "No debe ser numerico");
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

                if (ArticuloLN.PA_VerificaArticulo_Existencia_Identificacion_SinFiltro(this.txtIdentificacion.Text) == "1")
                {
                    MessageBox.Show("La identificacion ingresada, ya se encuentra en uso, favor ingresar una diferente");
                    return;
                }

                Articulo item = FactoryArticulo.CreaArticulo(TipoArticulo.CUPON);
                item.Identificacion = this.txtIdentificacion.Text;
                item.Nombre = this.txtNombre.Text;
                item.Precio = Convert.ToDouble(this.txtPrecio.Text);
                item.Descripcion = this.txtDescripcion.Text;
                item.Fotografia = this.ImageToByteArray(this.picImagenProducto_Guardar.Image);

                (item as Articulo_Cupon).FechaVencimiento = this.txtFechaVencimiento.Value;
                (item as Articulo_Cupon).CodigoQR = this.ImageToByteArray(this.pnlQR.Image);

                if (MessageBox.Show("DESEEA CONFIRMAR INGRESO DEL CUPON ", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    itemBD = new ArticuloLN();
                    itemBD.RegistroArticulo_Cupon(item, usuarioAux.Identificacion);
                    log.Info("SE INGRESO UN CUPON EXITOSAMENTE");
                    this.LimpiarCampos_Guardar();
                    this.errProvider.Clear();
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("INGRESO DE CUPON CANCELADO",
                                         "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    this.LimpiarCampos_Guardar();
                    this.errProvider.Clear();
                    tabControl1.SelectedIndex = 0;
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

        private void btnLimpiarCampos_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtDescripcion.Text = "";
                this.txtIdentificacion.Text = "";
                this.txtNombre.Text = "";
                this.txtPrecio.Text = "";
                this.txtFechaVencimiento.Value = DateTime.Now;
                this.picImagenProducto_Guardar.Image = null;
                this.pnlQR.Image = null;
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

        private void LimpiarCampos_Guardar()
        {
            this.txtNombre.Text = "";
            this.txtPrecio.Text = "";
            this.txtIdentificacion.Text = "";
            this.txtDescripcion.Text = "";
            this.txtFechaVencimiento.Value = DateTime.Now;
            this.picImagenProducto_Guardar.Image = null;
            this.pnlQR.Image = null;
        }

        #endregion





        //---------------------------------------------------------------

        //***************************************************************************************

        private void btnActivar_Desactivar_Click(object sender, EventArgs e)
        {
         //   "\r\nACTIVO"
            try
            {
                string estdadoUsuarioACambiar = "";

                //Se asiganan de acuerdo a la fila seleccionada
                if (this.dgvProductos_Disponibles.SelectedRows.Count > 0)
                {
                    estdadoUsuarioACambiar = this.dgvProductos_Disponibles.CurrentRow.Cells[6].Value.ToString();
                    Console.WriteLine(estdadoUsuarioACambiar);
                    if (estdadoUsuarioACambiar.Equals("ACTIVO"))
                    {

                        string identificacion = this.dgvProductos_Disponibles.CurrentRow.Cells[0].Value.ToString();
                        Console.WriteLine(identificacion);
                        ArticuloLN.EstadoArticulo_Desactiva(identificacion);
                        Console.WriteLine(identificacion);
                        this.CargaDGV_Cupones();
                        this.dgvProductos_Disponibles.ClearSelection();

                    }
                    else
                    {
                        string identificacion = this.dgvProductos_Disponibles.CurrentRow.Cells[0].Value.ToString();
                        // Console.WriteLine(identificacion);
                        ArticuloLN.EstadoArticulo_Activa(identificacion);
                        this.CargaDGV_Cupones();
                        this.dgvProductos_Disponibles.ClearSelection();
                    }
                }
                else
                {
                    estdadoUsuarioACambiar = "";
                    MessageBox.Show("No has seleccionado ningun cupon a cambiar su estado");
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

        //***************************************************************************************




        #region AREA GESTOR


        private void btnAtrasGestionar1_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedIndex = 0;
                this.LimpiarCampos_Gestionar();
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
        private void btnSeleccionarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                string identificacion = "";

                if (this.dgvProductos_Disponibles.SelectedRows.Count > 0)
                {
                    identificacion = this.dgvProductos_Disponibles.CurrentRow.Cells[0].Value.ToString();

                    itemBD = new ArticuloLN();
                    articuloAux = itemBD.ObtenerArticulo_Cupon_SinFiltro(identificacion, usuarioAux.Identificacion);
                    Console.WriteLine(articuloAux.Nombre);
                    //la magia sucede aca:

                    this.identificacionProductoOriginal = articuloAux.Identificacion;

                    this.cargaObjetosVentana_Gestionar(articuloAux);

                    tabControl1.SelectedIndex = 3;

                }
                else
                {
                    MessageBox.Show("No has seleccionado ningun producto a cambiar su estado");
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





        private void btnConfirmarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                //valida campos
                try
                {
                    this.errProvider.Clear();

                    //Verifica que no esten vacios
                    if (string.IsNullOrEmpty(this.txtIdentificacion_Gestor.Text))
                    {
                        this.errProvider.SetError(this.txtIdentificacion_Gestor, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtNombre_Gestor.Text))
                    {
                        this.errProvider.SetError(this.txtNombre_Gestor, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtPrecio_Gestor.Text))
                    {
                        this.errProvider.SetError(this.txtPrecio_Gestor, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtDescripcion_Gestor.Text))
                    {
                        this.errProvider.SetError(this.txtDescripcion_Gestor, "Dato requerido");
                        return;
                    }
                    if (this.picImagen_Gestor.Image == null)
                    {
                        this.errProvider.SetError(this.picImagen_Gestor, "Dato requerido");
                        return;
                    }
                    if (this.pnlCodigoQR_Gestor.Image == null)
                    {
                        this.errProvider.SetError(this.pnlCodigoQR_Gestor, "Dato requerido");
                        return;
                    }
                    //Verifica si, corresponden realmente a los datos deseados
                    long numero = 0;
                    
                    if (!long.TryParse(this.txtPrecio_Gestor.Text, out numero))
                    {
                        this.errProvider.SetError(this.txtPrecio_Gestor, "Debe ser numerico unicamente");
                        return;
                    }
                    if (long.TryParse(this.txtNombre_Gestor.Text, out numero))
                    {
                        this.errProvider.SetError(this.txtNombre_Gestor, "No debe ser numerico");
                        return;
                    }
                    if (long.TryParse(this.txtDescripcion_Gestor.Text, out numero))
                    {
                        this.errProvider.SetError(this.txtDescripcion_Gestor, "No debe ser numerico");
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

                if (identificacionProductoOriginal != this.txtIdentificacion_Gestor.Text)
                {
                    if (ArticuloLN.PA_VerificaArticulo_Existencia_Identificacion_SinFiltro(this.txtIdentificacion_Gestor.Text).Equals("1"))
                    {
                        MessageBox.Show("La identificacion ingresada esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                Articulo item = FactoryArticulo.CreaArticulo(TipoArticulo.CUPON);
                item.Identificacion = this.txtIdentificacion_Gestor.Text;
                item.Nombre = this.txtNombre_Gestor.Text;
                item.Precio = Convert.ToDouble(this.txtPrecio_Gestor.Text);
                item.Descripcion = this.txtDescripcion_Gestor.Text;
                item.Fotografia = this.ImageToByteArray(this.picImagen_Gestor.Image);

                (item as Articulo_Cupon).FechaVencimiento = this.txtFechaVencimiento_Gestor.Value;
                (item as Articulo_Cupon).CodigoQR = this.ImageToByteArray(this.pnlCodigoQR_Gestor.Image);

                if (MessageBox.Show("DESEEA CONFIRMAR LA ACTUALIZACION DEL CUPON ", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    itemBD = new ArticuloLN();
                    itemBD.ActualizaArticulo_Cupon(item, usuarioAux.Identificacion,identificacionProductoOriginal);
                    log.Info("SE ACTUALIZO UN CUPON EXITOSAMENTE");
                    this.LimpiarCampos_Gestionar();
                    this.errProvider.Clear();
                    this.CargaDGV_Cupones();
                    tabControl1.SelectedIndex = 2;
                }
                else
                {
                    MessageBox.Show("INGRESO DE CUPON CANCELADO",
                                         "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    this.LimpiarCampos_Gestionar();
                    this.errProvider.Clear();
                    this.CargaDGV_Cupones();
                    tabControl1.SelectedIndex = 2;
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

        private void btnCancelarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                this.LimpiarCampos_Gestionar();
                this.errProvider.Clear();
                tabControl1.SelectedIndex = 2;
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
        private void btnBuscarImagen_Gestor_Click(object sender, EventArgs e)
        {
            try
            {
                opFile_Gestor.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png";
                this.opFile_Gestor.ShowDialog();
                if (this.opFile_Gestor.FileName.Equals("") == false)
                {
                    this.picImagen_Gestor.Load(this.opFile_Gestor.FileName);
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

        private void btnGenerarQR_Gestor_Click(object sender, EventArgs e)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(this.txtIdentificacion_Gestor.Text, out qrCode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();

            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var image = new Bitmap(imageTemporal, new Size(new Point(249, 189)));
            this.pnlCodigoQR_Gestor.Image = image;

        }

        private void LimpiarCampos_Gestionar()
        {
            this.txtNombre_Gestor.Text = "";
            this.txtPrecio_Gestor.Text = "";
            this.txtIdentificacion_Gestor.Text = "";
            this.txtDescripcion_Gestor.Text = "";
            this.txtFechaVencimiento_Gestor.Value = DateTime.Now;
            this.picImagen_Gestor.Image = null;
            this.pnlCodigoQR_Gestor.Image = null;
        }

        #endregion








        public byte[] ImageToByteArray(System.Drawing.Image imagen)
        {

            MemoryStream ms = new MemoryStream();
            imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();

        }

        public Image ByteArrayToImage(byte[] byteArray)
        {

            MemoryStream ms = new MemoryStream(byteArray);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);

            return returnImage;
        }


    }
}
