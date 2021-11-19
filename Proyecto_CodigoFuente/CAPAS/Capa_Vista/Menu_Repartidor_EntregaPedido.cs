using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using DevComponents.DotNetBar;
using Capa_Entidades.Clases;
using Capa_Logica_Negocios;

namespace Capa_Vista
{
    public partial class Menu_Repartidor_EntregaPedido : Form
    {

        //**************************************************
        //**************************************************
        //brindan la actividad normal de la ventana
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Usuario LocalUser = Menu_Repartidor.userAux;
        private UsuarioLN userDB_Access = null;
        //**************************************************
        //**************************************************


        //Variables para dar uso al mapa, para seleccion de ubicacion
        private GMarkerGoogle marker_Repartidor; // crea un marcador
        private GMapOverlay markerOverlay_Repartidor; // da una capa de enmarcado

        private GMarkerGoogle marker_Negocio; // crea un marcador
        private GMapOverlay markerOverlay_Negocio; // da una capa de enmarcado

        private GMarkerGoogle marker_DestinoFinal; // crea un marcador
        private GMapOverlay markerOverlay_DestinoFinal; // da una capa de enmarcado


        //Hacer ruta
        private bool trazarRuta = false;
        private PointLatLng poscRepartidor;
        private PointLatLng inicio;
        private PointLatLng final;


        //POSICION DONDE INICIA EL MAPA
        private double LatInicial;
        private double LngInicial;
        //private double LatInicial = 10.093008;
        //private double LngInicial = -84.473950;

        //OBJETOS Direccion
        private Direccion oRepartidor;
        private Direccion oNegocio;
        private Direccion oEntregaPedido;


        public Menu_Repartidor_EntregaPedido()
        {
            InitializeComponent();

            this.LocalUser = Menu_Repartidor.userAux;

            this.btnEntregaRealizada.Enabled = false;
            this.lblDistancia.Text= "- - -";
            this.lblGananciaEntrega.Text = "- - -";

            this.lblRuta_NegClient.Visible = false;
            this.lblRuta_RepNeg.Visible = false;

            this.mapa_Repartidor.ShowCenter = false;

            this.LatInicial = this.LocalUser._Direccion.Latitud;
            this.LngInicial = this.LocalUser._Direccion.Longitud;
            this.oNegocio = this.LocalUser._Direccion;

            this.InicializaMapa_Repartidor();

            log.Info("SE ABRIO EL FRM_ENTREGA_PEDIDO");
            
        }




        private void Menu_Repartidor_EntregaPedido_Load(object sender, EventArgs e)
        {
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyA_OzMCuyk8EJNjBB-81ykJqJQDa2gGEwI";
            GMaps.Instance.Mode = AccessMode.ServerOnly;
        }




        private void btnEntregaRealizada_Click(object sender, EventArgs e)
        {
            try
            {


                FacturacionLN fact = new FacturacionLN();
                fact.OrdenEntregada(Menu_Repartidor.numOrdenAceptada);

                MessageBox.Show("Entrega del paquete completada, gracias por usar nuestra app");
                log.Info("SE ENTREGO EXITOSAMENTE UN PAQUETE, GRACIAS A : "+LocalUser.Nombre);

                (LocalUser as Usuario_Repartidor)._UsuarioPaquete = null;
                (LocalUser as Usuario_Repartidor)._UsuarioComercio = null;
                Menu_Repartidor.userAux = LocalUser;
                Menu_Repartidor.numOrdenAceptada = 0;

                while(mapa_Repartidor.Overlays.Count > 0) 
                { 
                    mapa_Repartidor.Overlays.RemoveAt(0);
                    mapa_Repartidor.Refresh();
                }
                this.lblDistancia.Text = "- - -";
                this.lblGananciaEntrega.Text = "- - -";

                this.lblRuta_NegClient.Visible = false;
                this.lblRuta_RepNeg.Visible = false;

                this.InicializaMapa_Repartidor();

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






        #region DAN FORMA Y VIDA A LA VENTANA

        //Marca la ruta en el mapa
        private void btnTrazaRuta_Click(object sender, EventArgs e)
        {
            try
            {
                if ((LocalUser as Usuario_Repartidor)._UsuarioPaquete == null)
                {
                    MessageBox.Show("No hay una entrega en curso,favor obtener una primero");
                    return;
                }
                if ((LocalUser as Usuario_Repartidor)._UsuarioComercio == null)
                {
                    MessageBox.Show("No hay una entrega en curso,favor obtener una primero");
                    return;
                }


                this.trazarRuta = true;
                this.btnTrazaRuta.Enabled = false;
                this.btnEntregaRealizada.Enabled = true;

                this.lblRuta_NegClient.Visible = true;
                this.lblRuta_RepNeg.Visible = true;

                this.CrearDireccionTrazarRuta();

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

        //Inicializa todoslos componentes del mapa
        private void InicializaMapa_Repartidor()
        {
            while (mapa_Repartidor.Overlays.Count > 0)
            {
                mapa_Repartidor.Overlays.RemoveAt(0);
                mapa_Repartidor.Refresh();
            }

            //Da caracteristicas al MAPA 
            mapa_Repartidor.DragButton = MouseButtons.Left;
            mapa_Repartidor.CanDragMap = true;
            mapa_Repartidor.MapProvider = GMapProviders.GoogleMap;
            mapa_Repartidor.Position = new PointLatLng(LatInicial, LngInicial);
            mapa_Repartidor.MinZoom = 0;
            mapa_Repartidor.MaxZoom = 24;
            mapa_Repartidor.Zoom = 9;
            mapa_Repartidor.AutoScroll = true;

            //Crea un marcador
            markerOverlay_Repartidor = new GMapOverlay("Marcador");
            //marker_Repartidor = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red_big_stop);
            //markerOverlay_Repartidor.Markers.Add(marker_Repartidor); //Agrega marcador al mapa

            //Crea un marcador personalizado
            Bitmap bmpMarker = (Bitmap)Image.FromFile(@"..\..\Mapa_Imagenes\pizza (1).png");
            marker_Repartidor = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), bmpMarker);
            markerOverlay_Repartidor.Markers.Add(marker_Repartidor); //Agrega marcador al mapa



            //Se agrega el toolTip de texto al marcador
            marker_Repartidor.ToolTipMode = MarkerTooltipMode.Always;
            marker_Repartidor.ToolTipText = string.Format("Ubicacion: \n Latitud:{0} \n Longitud:{1}", LatInicial, LngInicial);

            //Agregamos el mapa y el marcador al mapControl
            mapa_Repartidor.Overlays.Add(markerOverlay_Repartidor);
        }

        //permitemover el marcador
        private void mapa_Repartidor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ////Obtiene la latitud y longitud de la posiscion dentro del mapa
                //LatitudSeleccionada = mapa_Repartidor.FromLocalToLatLng(e.X, e.Y).Lat;
                //LongitudSeleccionada = mapa_Repartidor.FromLocalToLatLng(e.X, e.Y).Lng;

                ////mover el marcador, ah la posicion dada por el usuario
                //marker_Repartidor.Position = new PointLatLng(LatitudSeleccionada, LongitudSeleccionada);
                //marker_Repartidor.ToolTipText = string.Format("Ubicacion: \n Latitud:{0} \n Longitud:{1}", LatitudSeleccionada, LongitudSeleccionada);

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

        //crea la ruta mostrada en el mapa
        private void CrearDireccionTrazarRuta()
        {
            try
            {
                if (trazarRuta)
                {
                    //if (mapa_Repartidor.Overlays.Count > 0)
                    //{
                    //    mapa_Repartidor.Overlays.RemoveAt(0);
                    //    mapa_Repartidor.Refresh();
                    //}

                    //crea el camino del repartidor al negocio
                    oRepartidor = new Direccion();
                    oRepartidor.Latitud = LocalUser._Direccion.Latitud;
                    oRepartidor.Longitud = LocalUser._Direccion.Longitud;
                    poscRepartidor = new PointLatLng(oRepartidor.Latitud, oRepartidor.Longitud);

                    oNegocio = new Direccion();
                    oNegocio.Latitud = (LocalUser as Usuario_Repartidor)._UsuarioComercio._Direccion.Latitud;
                    oNegocio.Longitud = (LocalUser as Usuario_Repartidor)._UsuarioComercio._Direccion.Longitud;
                    inicio = new PointLatLng(oNegocio.Latitud, oNegocio.Longitud);

                    GMapOverlay routesAux = new GMapOverlay("routesAux");
                    List<PointLatLng> pointsAux = new List<PointLatLng>();
                    pointsAux.Add(poscRepartidor);
                    pointsAux.Add(inicio);
                    var rutaGoogle = GoogleMapProvider.Instance.GetRoute(pointsAux[0], pointsAux[1], false, false, 14);
                    GMapRoute google = new GMapRoute(rutaGoogle.Points, "Ruta pedido");
                    google.Stroke = new Pen(Color.Blue, 5);
                    routesAux.Routes.Add(google);
                    mapa_Repartidor.Overlays.Add(routesAux);
                    mapa_Repartidor.Zoom = 12;

                    //CrearDireccionTrazarRuta el marcador del negocio
                    markerOverlay_Negocio = new GMapOverlay("MarcadorNegocio");
                    //Crea un marcador personalizado
                    Bitmap bmpMarker = (Bitmap)Image.FromFile(@"..\..\Mapa_Imagenes\tienda (2).png");
                    marker_Negocio = new GMarkerGoogle(new PointLatLng(
                        (LocalUser as Usuario_Repartidor)._UsuarioComercio._Direccion.Latitud, 
                        (LocalUser as Usuario_Repartidor)._UsuarioComercio._Direccion.Longitud), bmpMarker);
                    markerOverlay_Negocio.Markers.Add(marker_Negocio); //Agrega marcador al mapa
                    mapa_Repartidor.Overlays.Add(markerOverlay_Negocio);



                    //Crea el punto a donde entregar el producto
                    oEntregaPedido = new Direccion();
                    oEntregaPedido.Latitud = (LocalUser as Usuario_Repartidor)._UsuarioPaquete._Direccion.Latitud;
                    oEntregaPedido.Longitud = (LocalUser as Usuario_Repartidor)._UsuarioPaquete._Direccion.Longitud;
                    final = new PointLatLng(oEntregaPedido.Latitud, oEntregaPedido.Longitud);

                    //crea la ruta entre el negocio y el punto final
                    GMapOverlay routes = new GMapOverlay("routes");
                    List<PointLatLng> points = new List<PointLatLng>();
                    points.Add(inicio);
                    points.Add(final);

                    var ruta = GoogleMapProvider.Instance.GetRoute(points[0], points[1], false, false, 14);
                    GMapRoute route = new GMapRoute(ruta.Points, "Ruta pedido");
                    route.Stroke = new Pen(Color.Red, 5);
                    routes.Routes.Add(route);
                    mapa_Repartidor.Overlays.Add(routes);
                    mapa_Repartidor.Zoom = 12;

                    markerOverlay_DestinoFinal = new GMapOverlay("MarcadorCliente");
                    //Crea un marcador personalizado
                    Bitmap bmpMarker2 = (Bitmap)Image.FromFile(@"..\..\Mapa_Imagenes\terminar.png");
                    marker_DestinoFinal = new GMarkerGoogle(new PointLatLng( 
                        (LocalUser as Usuario_Repartidor)._UsuarioPaquete._Direccion.Latitud, 
                        (LocalUser as Usuario_Repartidor)._UsuarioPaquete._Direccion.Longitud), bmpMarker2);
                    markerOverlay_DestinoFinal.Markers.Add(marker_DestinoFinal); //Agrega marcador al mapa
                    mapa_Repartidor.Overlays.Add(markerOverlay_DestinoFinal);

                    lblDistancia.Text = ( route.Distance/1000*1000 ).ToString("##,###.00") + "Km";
                    lblGananciaEntrega.Text = "₡" + ((route.Distance / 1000 * 1000) * 100).ToString("##,###.00");





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



        #region DA ESTILO AL MAPA
        private void btnSatelital_Click(object sender, EventArgs e)
        {
            mapa_Repartidor.MapProvider = GMapProviders.GoogleChinaSatelliteMap;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            mapa_Repartidor.MapProvider = GMapProviders.GoogleMap;
        }

        private void btnRelieve_Click(object sender, EventArgs e)
        {
            mapa_Repartidor.MapProvider = GMapProviders.GoogleTerrainMap;
        }

        private void btnHibrido_Click(object sender, EventArgs e)
        {
            mapa_Repartidor.MapProvider = GMapProviders.GoogleHybridMap;
        }

        #endregion



    }
}
