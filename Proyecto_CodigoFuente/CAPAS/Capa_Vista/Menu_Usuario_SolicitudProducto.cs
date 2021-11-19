using Capa_Entidades.Clases;
using Capa_Entidades.Gestor;
using Capa_Entidades.Util;
using Capa_Logica_Negocios;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista
{
    public partial class Menu_Usuario_SolicitudProducto : Form
    {
        //**************************************************
        //**************************************************
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //brindan la actividad normal de la ventana
        private Usuario LocalUser = Menu_Usuario.userAux;
        Gestor_Factura oGestor = null;
        //**************************************************
        //**************************************************


        //===========================================================
        List<Articulo> ListaArticulosCarrito = new List<Articulo>();

        List<Usuario> ListaNegociosDisponibles = new List<Usuario>();
        List<Articulo> ListaProductosDisponibles = new List<Articulo>();
        List<Articulo> ListaCuponesDisponibles = new List<Articulo>();


        Usuario negocioSeleccionado = null;
        //===========================================================


        public Menu_Usuario_SolicitudProducto()
        {
            InitializeComponent();
            LocalUser = Menu_Usuario.userAux;
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyA_OzMCuyk8EJNjBB-81ykJqJQDa2gGEwI";
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            log.Info("SE ABRIO EL FRM_SOLICITUD_PRODUCTO");
        }

        //EVENTO QUE SE EJECUTA AL CARGAR LA VENTANA POR PRIMERA VEZ
        private void Menu_Usuario_SolicitudProducto_Load(object sender, EventArgs e)
        {
            //  this.llena_DGV_Prueba();
            this.LlenaDGV_Comercios();
            this.lblTotalPagarMomento_Carrito_.Text = "₡0.00";
            this.lblTotalPagarMomento_Carrito_2.Text = "$0.00";

            this.txtTotalDolares.Text = "$0.00";
            this.txtSubTotal.Text = "₡0.00";
            this.txtTotalColones.Text = "₡0.00";
            this.txtImpuestos.Text = "₡0.00";

        }



        //DAN VIDA A LA VENTANA, Y FUNCIONALIDAD
        public void LlenaDGV_Comercios()
        {
            try
            {
                this.dgvNegocios_Disponibles_.Rows.Clear();
                foreach (Usuario user in UsuarioLN.ObtenerListaUsuariosApp_Comercios())
                {

           
                    this.dgvNegocios_Disponibles_.Rows.Add(
                        user.Nombre,
                        user.NumeroTelefono,
                        (user as Usuario_Comercio).PuntuacionTotal,
                        user._Direccion.DescripcionUbicacion,
                        this.DistanciaComercio(LocalUser,user)
                        );
                    this.ListaNegociosDisponibles.Add(user);



                }
                dgvNegocios_Disponibles_.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvNegocios_Disponibles_.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                foreach (DataGridViewRow fila in dgvNegocios_Disponibles_.Rows)
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
        public void LlenaDGVCupones(Usuario pUser)
        {
            try
            {
                ArticuloLN itemLN = new ArticuloLN();
                this.dgvProductos_Disponibles.Rows.Clear();

                if (itemLN.ObtenerListaCupones(pUser).Count <= 0)
                {
                    MessageBox.Show("Este negocio no posee ningun cupon en estos momentos disponible");
                    return;
                }


                foreach (Articulo item in itemLN.ObtenerListaCupones(pUser))
                {
                    Image imagen1 = this.ByteArrayToImage(item.Fotografia);

                    this.dgvProductos_Disponibles.Rows.Add(
                        item.Nombre,
                        item.Descripcion,
                        "₡" + item.Precio.ToString("#,###,###.00"),
                         imagen1
                        );
                    this.ListaCuponesDisponibles.Add(item);
                }

                dgvProductos_Disponibles.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvProductos_Disponibles.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

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
        public void LlenaDGVProductos(Usuario pUser)
        {
            try
            {
                ArticuloLN itemLN = new ArticuloLN();
                this.dgvProductos_Disponibles.Rows.Clear();
                if (itemLN.ObtenerListaProductos(pUser).Count <= 0)
                {
                    MessageBox.Show("Este negocio no posee ningun producto en estos momentos disponible");
                    return;
                }
                foreach (Articulo item in itemLN.ObtenerListaProductos(pUser))
                {
                    Image imagen1 = this.ByteArrayToImage(item.Fotografia);

                    this.dgvProductos_Disponibles.Rows.Add(
                        item.Nombre,
                        item.Descripcion,
                        "₡" + item.Precio.ToString("#,###,###.00"),
                         imagen1
                        );

                    this.ListaProductosDisponibles.Add(item);
                }

                dgvProductos_Disponibles.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvProductos_Disponibles.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

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
        public void LlenaDGVCarrito()
        {
            try
            {

                this.dgvCarritoCompra.Rows.Clear();
                double dinero = .0;
                foreach (Articulo item in ListaArticulosCarrito)
                {
                    Image imagen1 = this.ByteArrayToImage(item.Fotografia);

                    this.dgvCarritoCompra.Rows.Add(
                        item.Nombre,
                        item.Descripcion,
                        "₡" + item.Precio.ToString("#,###,###.00"),
                         imagen1
                        );

                    dinero += item.Precio;
                }

                dgvCarritoCompra.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvCarritoCompra.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dinero = dinero + (dinero * .13);

                this.lblTotalPagarMomento_Carrito_.Text = "₡" + dinero.ToString("#,###,###.00")+" *i.v.a";
                BCCR_Datos datos = new BCCR_Datos();
                double dolar = datos.ObtenerIndicadoresEconomicos_VentaDolar();
                this.lblTotalPagarMomento_Carrito_2.Text = "$" + (dinero/dolar).ToString("#,###,###.00")+" *i.v.a";


                foreach (DataGridViewRow fila in dgvCarritoCompra.Rows)
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
        public string DistanciaComercio(Usuario pUser, Usuario pComercio)
        {  
           PointLatLng inicio = new PointLatLng(pComercio._Direccion.Latitud, pComercio._Direccion.Longitud);
           PointLatLng final = new PointLatLng(pUser._Direccion.Latitud, pUser._Direccion.Longitud);

            GMapOverlay routes = new GMapOverlay("routes");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(inicio);
            points.Add(final);
            var ruta = GoogleMapProvider.Instance.GetRoute(points[0], points[1], false, false, 14);
            GMapRoute route = new GMapRoute(ruta.Points, "Ruta pedido");
            routes.Routes.Add(route);
        //    Console.WriteLine((route.Distance / 1000 * 1000).ToString("##,###.00") + "Km");
            return (route.Distance / 1000 * 1000).ToString("##,###.00") + "Km";
        }



        //---------------------------------------------------------------------------------------
        //***************************************************************************************


        #region PESTANNA 1 : SELECCION DE LOCAL
        private void dgvNegocios_Disponibles__CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvNegocios_Disponibles_.Columns[e.ColumnIndex].Name == "Calificacion")
            {
                try
                {
                    if (e.Value.GetType() != typeof(DBNull))
                    {

                        if (Convert.ToInt32(e.Value) >= 0.0 && Convert.ToInt32(e.Value) <= 25.0)
                        {
                            e.CellStyle.ForeColor = Color.Red;
                        }

                        if (Convert.ToInt32(e.Value) >= 25.0 && Convert.ToInt32(e.Value) <= 65.0)
                        {
                            e.CellStyle.ForeColor = Color.Yellow;
                        }

                        if (Convert.ToInt32(e.Value) >= 65.0 && Convert.ToInt32(e.Value) <= 100.0)
                        {
                            e.CellStyle.ForeColor = Color.Green;
                        }
                    }
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("");
                }
            }
        }

        private void btnSeleccionar_Negocio__Click(object sender, EventArgs e)
        {
            try
            {
                this.errProvider.Clear();
                if (this.dgvNegocios_Disponibles_.SelectedRows.Count == 0)
                {
                    this.errProvider.SetError(this.dgvNegocios_Disponibles_, "Dato requerido");
                    return;
                }


                tabControl1.SelectedIndex = 1;
                int indice=this.dgvNegocios_Disponibles_.SelectedRows[0].Index;

                this.negocioSeleccionado = this.ListaNegociosDisponibles.ElementAt<Usuario>(indice);
                
                this.lblNombreNegocioSeleccionado.Text = negocioSeleccionado.Nombre;

                this.rdbPRODUCTOS.Checked = true;
                this.LlenaDGVProductos(negocioSeleccionado);

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

        private void btnCancelar_Seleccion_Neogcio__Click(object sender, EventArgs e)
        {
            try
            {
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


        #endregion


        //---------------------------------------------------------------------------------------


        #region PESTANNA 2 : SELECCION DE PRODUCTO(S)/ CUPON(ES)

        private void btnSeleccionar_Producto__Click(object sender, EventArgs e)
        {
            try
            {
                this.errProvider.Clear();
                if (this.dgvProductos_Disponibles.SelectedRows.Count == 0)
                {
                    this.errProvider.SetError(this.dgvProductos_Disponibles, "Dato requerido");
                    return;
                }


                if (this.rdbPRODUCTOS.Checked)
                {
                    int indice = this.dgvProductos_Disponibles.SelectedRows[0].Index;
                    this.ListaArticulosCarrito.Add(this.ListaProductosDisponibles.ElementAt<Articulo>(indice));
                    MessageBox.Show("PRODUCTO AGREGADO AL CARRITO");
                    this.LlenaDGVCarrito();
                }else if (this.rdbCUPONES.Checked)
                {
                    int indice = this.dgvProductos_Disponibles.SelectedRows[0].Index;
                    this.ListaArticulosCarrito.Add(this.ListaCuponesDisponibles.ElementAt<Articulo>(indice));
                    MessageBox.Show("CUPON AGREGADO AL CARRITO");
                    this.LlenaDGVCarrito();
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

        private void btnCancelar_Seleccion_Producto__Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvProductos_Disponibles.ClearSelection();
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

        private void btnAtras_Productos_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (MessageBox.Show("SI RETROCEDES, PERDERAS TU CARRITO DE COMPRAS ACTUAL ", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    tabControl1.SelectedIndex = 0;
                    this.ListaArticulosCarrito.Clear();
                    this.ListaCuponesDisponibles.Clear();
                    this.ListaProductosDisponibles.Clear();
                    this.negocioSeleccionado = null;
                }
                else
                {
                    MessageBox.Show("PROCESO CANCELADO",
                                         "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    
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

        private void btnCarrito_Productos_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaArticulosCarrito.Count <= 0)
                {
                    MessageBox.Show("PRIMERO DEBES TENER ALGO EN EL CARRITO DE COMPRAS");
                    return;
                }


                tabControl1.SelectedIndex = 2;
                this.LlenaDGVCarrito();


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

        private void rdbPRODUCTOS_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbPRODUCTOS.Checked)
                {
                    this.LlenaDGVProductos(negocioSeleccionado);
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

        private void rdbCUPONES_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbCUPONES.Checked)
                {
                    this.LlenaDGVCupones(negocioSeleccionado);
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


        #endregion


        //---------------------------------------------------------------------------------------


        #region PESTANNA 3 : CARRITO DE COMPRA

        //listo 
        private void btnAtras_Carrito_Click(object sender, EventArgs e)
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

        private void btnQuitarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                this.errProvider.Clear();
                if (this.dgvCarritoCompra.SelectedRows.Count == 0)
                {
                    this.errProvider.SetError(this.dgvCarritoCompra, "Dato requerido");
                    return;
                }


                if (this.ListaArticulosCarrito.Count > 1)
                {
                    int indice = this.dgvCarritoCompra.SelectedRows[0].Index;
                    this.ListaArticulosCarrito.RemoveAt(indice);
                    this.LlenaDGVCarrito();
                }
                else if (this.ListaArticulosCarrito.Count == 1)
                {
                    int indice = this.dgvCarritoCompra.SelectedRows[0].Index;
                    this.ListaArticulosCarrito.RemoveAt(indice);
                    this.LlenaDGVCarrito();
                    MessageBox.Show("No tienes mas articulos en el carrito");
                    tabControl1.SelectedIndex = 1;
                }
                else if (this.ListaArticulosCarrito.Count == 0 )
                {
                    MessageBox.Show("No tienes mas articulos en el carrito");
                    this.LlenaDGVCarrito();
                    tabControl1.SelectedIndex = 1;
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

        private void btnCancelarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("SI CANCELAS, PERDERAS TU CARRITO DE COMPRAS ACTUAL ", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    tabControl1.SelectedIndex = 0;
                    this.ListaArticulosCarrito.Clear();
                    this.ListaCuponesDisponibles.Clear();
                    this.ListaProductosDisponibles.Clear();
                    this.negocioSeleccionado = null;
                    log.Info("SE CANCELO UNA COMPRA");

                }
                else
                {
                    MessageBox.Show("PROCESO CANCELADO",
                                         "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);


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

        private void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                //Agrega articulos del carrito a la ventana de compra FINALIZADA
                foreach (Articulo item in ListaArticulosCarrito)
                {
                    Image imagen1 = this.ByteArrayToImage(item.Fotografia);

                    this.DGVCompraFinalizada.Rows.Add(
                        item.Nombre,
                        item.Descripcion,
                        "₡" + item.Precio.ToString("#,###,###.00"),
                         imagen1
                        );
                }

                DGVCompraFinalizada.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DGVCompraFinalizada.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                foreach (DataGridViewRow fila in DGVCompraFinalizada.Rows)
                    fila.Height = 100;

                //Calculo de la distancia entre dos puntos
                PointLatLng UbicacionComercio = new PointLatLng(negocioSeleccionado._Direccion.Latitud, negocioSeleccionado._Direccion.Longitud);
                PointLatLng UbicacionUsuario = new PointLatLng(LocalUser._Direccion.Latitud, LocalUser._Direccion.Longitud);

                GMapOverlay routes = new GMapOverlay("routes");
                List<PointLatLng> points = new List<PointLatLng>();
                points.Add(UbicacionComercio);
                points.Add(UbicacionUsuario);
                var ruta = GoogleMapProvider.Instance.GetRoute(points[0], points[1], false, false, 14);
                GMapRoute route = new GMapRoute(ruta.Points, "Ruta pedido");
                routes.Routes.Add(route);
                string distance= (route.Distance / 1000 * 1000).ToString();

                //PARTES DE LA FACTURA:
                Pedido oPedido = new Pedido();
                oPedido.FechaPedido = DateTime.Now;
                oPedido.DistanciaPedido = Convert.ToDouble(distance);
                foreach(Articulo item in ListaArticulosCarrito)
                {
                    oPedido.AgregaArticulo(item);
                }

                BCCR_Datos oDatos = new BCCR_Datos();
                double dolar = oDatos.ObtenerIndicadoresEconomicos_VentaDolar();
                Moneda oMoneda = Moneda.GetInstance();
                oMoneda.AsignaDatos(dolar, DateTime.Now);

                Pago oPago = new Pago();
                oPago.FechaPago = oPedido.FechaPedido;
                oPago.AgregaPedido(oPedido);
                oPago.AsignaMoneda(oMoneda);

                oGestor = new Gestor_Factura();
                oGestor.AsignaCliente(LocalUser);
                oGestor.AsignaComercio(negocioSeleccionado);
                oGestor.AsignaPagoCliente(oPago);


                //LLAMADA DE METODOS DE ASIGNAR CAMPOS Y ENVIO DE EMAIL:
                this.txtSubTotal.Text = "₡ " + oGestor.Calcula_SubTotal().ToString("#,###,###.00");
                this.txtImpuestos.Text = "₡ " + oGestor.Calcula_IVA().ToString("#,###,###.00");
                this.txtExpress.Text = "₡ " + oGestor.Calcula_Envio().ToString("#,###,###.00"); ;
                this.txtTotalColones.Text = "₡ " + oGestor.CalculaMonto_Total().ToString("#,###,###.00"); ;
                this.txtTotalDolares.Text = "$ " + oGestor.CalculaMonto_Total_Dolares().ToString("#,###,###.00");


                Factura fact = oGestor.GetInstanceFactura();
                FacturacionLN factBD = new FacturacionLN();
                string xml = oGestor.ObtenerXML();
                string cifradoXML = Utilitarios.ComputeSha256Hash(xml);

                factBD.IngresaFacturaNueva(fact, cifradoXML);
                factBD.IngresaFacturaUsuario(LocalUser);
                factBD.IngresaFacturaUsuario(negocioSeleccionado);

                int repeticiones = 0;
                List<Articulo> art = new List<Articulo>();
                foreach (Articulo item in ListaArticulosCarrito)
                {
                    foreach (Articulo itemAux in ListaArticulosCarrito)
                    {
                        if (item.Identificacion == itemAux.Identificacion)
                        {
                            repeticiones++;
                        }
                    }
                    Articulo a = item;
                    a.Cantidad = repeticiones;
                    art.Add(a);
                    repeticiones = 0;
                }

                foreach(Articulo item in art.Distinct())
                    factBD.IngresaFacturaArticulo(item);
                

                //GUARDO EN EL DIRECTORIO LOS PDF Y XML, que seran enviados
                if (!Directory.Exists(@"c:\temp"))
                    Directory.CreateDirectory(@"c:\temp");
                File.WriteAllText(@"c:\temp\FacturaXML.xml", xml);

                oGestor.ObtenerPDF();

                //ENVIO DE EMAIL CON PDF Y XML
                EnviaCorreo.EnviaEmail(
                LocalUser.CorreoElectronico,
                    "Factura de compra en " + negocioSeleccionado.Nombre,
                    "Se adjunta a este correo electronico, la copia en PDF y XML de su reciente compra en " +
                    negocioSeleccionado.Nombre + " \n\nQue tengas un feliz dia, y que disfrutes tu comida!"
                    );

                log.Info("SE EFECTUO UNA FACTURA POR "+LocalUser.Nombre);

                //Thread proceso1 = new Thread(new ThreadStart(() => EnviaCorreo.EnviaEmail(
                //LocalUser.CorreoElectronico,
                //    "Factura de compra en " + negocioSeleccionado.Nombre,
                //    "Se adjunta a este correo electronico, la copia en PDF y XML de su reciente compra en " +
                //    negocioSeleccionado.Nombre + " \n\nQue tengas un feliz dia, y que disfrutes tu comida!"
                //    )));



                tabControl1.SelectedIndex = 3;
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

        #endregion


        //---------------------------------------------------------------------------------------


        #region PESTANNA 4 : COMPRA EFECTUADA

        private void btnImprimirFactura_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            this.adobeReaderPDF.src= @"c:\temp\FacturaCompra.pdf";
            log.Info("SE IMPRIMIO UNA FACTURA");

            //saveFileDialog1.Filter = "Solo PDF | *.pdf";
            //DialogResult resultado = saveFileDialog1.ShowDialog();
            //if (resultado == System.Windows.Forms.DialogResult.OK)
            //{
            //    // Aquí agarra la ruta entera del archivo
            //    string ruta = Path.GetFullPath(saveFileDialog1.FileName);
            //    Console.WriteLine("Path: {0}", ruta);
            //    oGestor.ObtenerPDF_GuardadoEnRutaSeleccionada(ruta);
            //}

            //    Process.Start("iexplore.exe", @"c:\temp\FacturaCompra.pdf");

        }

        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            this.ListaArticulosCarrito = new List<Articulo>();
            this.ListaProductosDisponibles = new List<Articulo>();
            this.ListaCuponesDisponibles = new List<Articulo>();
            this.negocioSeleccionado = null;
            this.DGVCompraFinalizada.Rows.Clear();
        }
        private void btnFinalizar2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            this.ListaArticulosCarrito = new List<Articulo>();
            this.ListaProductosDisponibles = new List<Articulo>();
            this.ListaCuponesDisponibles = new List<Articulo>();
            this.negocioSeleccionado = null;
            this.DGVCompraFinalizada.Rows.Clear();
        }
        #endregion


        //***************************************************************************************
        //---------------------------------------------------------------------------------------



        private void llena_DGV_Prueba()
        {
            int numero = 12098;
            string local = "";
            int telefono = 0;
            double calificacion = .0;
            string direccion = "";

             dgvNegocios_Disponibles_.RowTemplate.Height = 30;

            for (int i = 0; i < 50; i++)
            {
                local = "Taco Bell " + numero.ToString();
                telefono = 0001 + numero;
                calificacion = i * numero;
                direccion = "Desconocida";

                this.dgvNegocios_Disponibles_.Rows.Add(
                    local,
                    telefono,
                    calificacion,
                    direccion
                    );

                if (calificacion % 2 == 0)
                {
              ///      this.dgvNegocios_Disponibles
                }
                numero++;
            }
        }


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

        //METODO DE CULTARA INFO 
        public void SetCulture()
        {
            // Colocar Cultura Estandar para Costa Rica
            CultureInfo Micultura = new CultureInfo("es-CR", false);
            Micultura.NumberFormat.CurrencySymbol = "¢";
            Micultura.NumberFormat.CurrencyDecimalDigits = 2;
            Micultura.NumberFormat.CurrencyDecimalSeparator = ".";
            Micultura.NumberFormat.CurrencyGroupSeparator = ",";
            int[] grupo = new int[] { 3, 3, 3 };
            Micultura.NumberFormat.CurrencyGroupSizes = grupo;
            Micultura.NumberFormat.NumberDecimalDigits = 2;
            Micultura.NumberFormat.NumberGroupSeparator = ",";
            Micultura.NumberFormat.NumberDecimalSeparator = ".";
            Micultura.NumberFormat.NumberGroupSizes = grupo;
            Thread.CurrentThread.CurrentCulture = Micultura;
        }

       
    }
}
