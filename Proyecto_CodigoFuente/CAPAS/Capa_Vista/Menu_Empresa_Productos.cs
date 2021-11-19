using Capa_Entidades.Clases;
using Capa_Entidades.Factory;
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
    public partial class Menu_Empresa_Productos : Form
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

        public Menu_Empresa_Productos()
        {
            InitializeComponent();

            dgvProductos_Disponibles.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvProductos_Disponibles.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            log.Info("SE ABRIO EL FRM_PRODUCTOS");

            usuarioAux = Menu_Empresa.userAux;
        }
        private void Menu_Empresa_Productos_Load(object sender, EventArgs e)
        {
            
        }


        //listo
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
        //listo
        private void btnGestionar_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedIndex = 2;
                this.CargaDGV_Productos();
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

        private void CargaDGV_Productos()
        {
            try
            {
                this.dgvProductos_Disponibles.Rows.Clear();
                string estado = "";

                itemBD = new ArticuloLN();

                foreach (Articulo item in itemBD.ObtenerListaProductos_SinFiltro(usuarioAux))
                {
                    estado =  ArticuloLN.PA_VerificaArticulo_Estado(item.Identificacion);

                    Image imagen = this.ByteArrayToImage(item.Fotografia);

                    this.dgvProductos_Disponibles.Rows.Add(
                        item.Identificacion,
                        item.Nombre,
                        item.Descripcion,
                       "₡" + item.Precio.ToString("#,###,###.00"),
                        imagen,
                        estado
                        ); 

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
            this.txtIdentificacion_Gestionar.Text = pArticulo.Identificacion;
            this.txtNombre_Gestionar.Text = pArticulo.Nombre;
            this.txtPrecio_Gestionar.Text = pArticulo.Precio.ToString();

            Image imagen = this.ByteArrayToImage(pArticulo.Fotografia);
            this.picImagen_Gestionar.Image = imagen;

            this.txtDescripcion_Gestionar.Text = pArticulo.Descripcion;


        }



        #region AREA GUARDAR
        //listo
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
        //listo
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

                    //Verifica si, corresponden realmente a los datos deseados
                    long numero = 0;
                    //if (!long.TryParse(this.txtIdentificacion.Text, out numero)) //verifica que sea numero
                    //{
                    //    this.errProvider.SetError(this.txtIdentificacion, "Debe ser numerico unicamente");
                    //    return;
                    //}
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


                Articulo item = FactoryArticulo.CreaArticulo(TipoArticulo.PRRODUCTO);
                item.Identificacion = this.txtIdentificacion.Text;
                item.Nombre = this.txtNombre.Text;
                item.Precio = Convert.ToDouble(this.txtPrecio.Text);
                item.Descripcion = this.txtDescripcion.Text;

                item.Fotografia = this.ImageToByteArray(this.picImagenProducto_Guardar.Image);


                if (MessageBox.Show("DESEEA CONFIRMAR INGRESO DEL PRODUCTO ", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    itemBD = new ArticuloLN();
                    itemBD.RegistroArticulo_Producto(item, usuarioAux.Identificacion);
                    log.Info("SE INGRESO UN PRODUCTO EXITOSAMENTE");

                    this.LimpiarCampos_Guardar();
                    this.errProvider.Clear();
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("INGRESO DE PRODUCTO CANCELADO",
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
        //listo
        private void btnLimpiarCampos_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtDescripcion.Text = "";
                this.txtIdentificacion.Text = "";
                this.txtNombre.Text = "";
                this.txtPrecio.Text = "";
                this.picImagenProducto_Guardar.Image = null;
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

            this.picImagenProducto_Guardar.Image = null;
        }

        #endregion

       

        //***************************************************************************************

        private void btnActivar_Desactivar_Click(object sender, EventArgs e)
        {
            try
            {
                string estdadoUsuarioACambiar = "";

                //Se asiganan de acuerdo a la fila seleccionada
                if (this.dgvProductos_Disponibles.SelectedRows.Count > 0)
                {
                    estdadoUsuarioACambiar = this.dgvProductos_Disponibles.CurrentRow.Cells[5].Value.ToString();
                      Console.WriteLine(estdadoUsuarioACambiar);
                    if ( estdadoUsuarioACambiar.Equals("ACTIVO") )
                    {

                        string identificacion = this.dgvProductos_Disponibles.CurrentRow.Cells[0].Value.ToString();
                        Console.WriteLine(identificacion);
                        ArticuloLN.EstadoArticulo_Desactiva(identificacion);
                        Console.WriteLine(identificacion);
                        this.CargaDGV_Productos();
                        this.dgvProductos_Disponibles.ClearSelection();

                    }
                    else
                    {
                        string identificacion = this.dgvProductos_Disponibles.CurrentRow.Cells[0].Value.ToString();
                       // Console.WriteLine(identificacion);
                        ArticuloLN.EstadoArticulo_Activa(identificacion);
                        this.CargaDGV_Productos();
                        this.dgvProductos_Disponibles.ClearSelection();
                    }
                }
                else
                {
                    estdadoUsuarioACambiar = "";
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

        //***************************************************************************************


        #region AREA GESTIONAR
        //listo
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
                    articuloAux = itemBD.ObtenerArticulo_Producto_SinFiltro(identificacion, usuarioAux.Identificacion);
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
                //validacion de campos
                try
                {
                    this.errProvider.Clear();

                    //Verifica que no esten vacios
                    if (string.IsNullOrEmpty(this.txtIdentificacion_Gestionar.Text))
                    {
                        this.errProvider.SetError(this.txtIdentificacion_Gestionar, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtNombre_Gestionar.Text))
                    {
                        this.errProvider.SetError(this.txtNombre_Gestionar, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtPrecio_Gestionar.Text))
                    {
                        this.errProvider.SetError(this.txtPrecio_Gestionar, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtDescripcion_Gestionar.Text))
                    {
                        this.errProvider.SetError(this.txtDescripcion_Gestionar, "Dato requerido");
                        return;
                    }
                    if (this.picImagen_Gestionar.Image == null)
                    {
                        this.errProvider.SetError(this.picImagen_Gestionar, "Dato requerido");
                        return;
                    }

                    //Verifica si, corresponden realmente a los datos deseados
                    long numero = 0;
                    if (!long.TryParse(this.txtPrecio_Gestionar.Text, out numero))
                    {
                        this.errProvider.SetError(this.txtPrecio_Gestionar, "Debe ser numerico unicamente");
                        return;
                    }
                    if (long.TryParse(this.txtNombre_Gestionar.Text, out numero))
                    {
                        this.errProvider.SetError(this.txtNombre_Gestionar, "No debe ser numerico");
                        return;
                    }
                    if (long.TryParse(this.txtDescripcion_Gestionar.Text, out numero))
                    {
                        this.errProvider.SetError(this.txtDescripcion_Gestionar, "No debe ser numerico");
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

                if (identificacionProductoOriginal != this.txtIdentificacion_Gestionar.Text)
                {
                    if (ArticuloLN.PA_VerificaArticulo_Existencia_Identificacion_SinFiltro(this.txtIdentificacion_Gestionar.Text).Equals("1"))
                    {
                        MessageBox.Show("La identificacion ingresada esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                Articulo item = FactoryArticulo.CreaArticulo(TipoArticulo.PRRODUCTO);
                item.Identificacion = this.txtIdentificacion_Gestionar.Text;
                item.Nombre = this.txtNombre_Gestionar.Text;
                item.Precio = Convert.ToDouble(this.txtPrecio_Gestionar.Text);
                item.Descripcion = this.txtDescripcion_Gestionar.Text;

                item.Fotografia = this.ImageToByteArray(this.picImagen_Gestionar.Image);


                if (MessageBox.Show("DESEEA CONFIRMAR LA ACTUALIZACION DEL PRODUCTO ", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    itemBD = new ArticuloLN();
                    itemBD.ActualizaArticulo_Producto(item, usuarioAux.Identificacion,identificacionProductoOriginal);
                    log.Info("SE ACTUALIZO UN PRODUCTO");
                    this.LimpiarCampos_Gestionar();
                    this.errProvider.Clear();
                    this.CargaDGV_Productos();
                    tabControl1.SelectedIndex = 2;
                }
                else
                {
                    MessageBox.Show("INGRESO DE PRODUCTO CANCELADO",
                                         "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    this.LimpiarCampos_Gestionar();
                    this.errProvider.Clear();
                    this.CargaDGV_Productos();
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
        //listo
        private void btnBuscarImagen_Gestionar_Click(object sender, EventArgs e)
        {
            try
            {
                opFile_Gestionar.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png";
                this.opFile_Gestionar.ShowDialog();
                if (this.opFile_Gestionar.FileName.Equals("") == false)
                {
                    this.picImagen_Gestionar.Load(this.opFile_Gestionar.FileName);
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

        private void LimpiarCampos_Gestionar()
        {
            this.txtNombre_Gestionar.Text = "";
            this.txtPrecio_Gestionar.Text = "";
            this.txtIdentificacion_Gestionar.Text = "";
            this.txtDescripcion_Gestionar.Text = "";

            this.picImagen_Gestionar.Image = null;
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
