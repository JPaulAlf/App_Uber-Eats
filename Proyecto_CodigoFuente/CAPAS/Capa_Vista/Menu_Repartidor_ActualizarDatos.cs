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
using System.Runtime.InteropServices;
using Capa_Logica_Negocios;
using Capa_Entidades.Factory;
using System.Net.Mail;

namespace Capa_Vista
{
    public partial class Menu_Repartidor_ActualizarDatos : Form
    {

        //**************************************************
        //**************************************************

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //brindan la actividad normal de la ventana
        private Usuario LocalUser = Menu_Repartidor.userAux;
        private UsuarioLN userDB_Access = null;
        private Direccion direccionRepartidor = null;

        private string NumTarjeta_Aux = "";
        private string NumTelefono_Aux = "";
        private string CorreoElect_Aux = "";
        private int Identificacion_Aux = 0;
        //**************************************************
        //**************************************************


        private GMarkerGoogle marker_Repartidor; // crea un marcador
        private GMapOverlay markerOverlay_Repartidor; // da una capa de enmarcado
                                                      //GENERAL PARA TODOS LOS MAPAS 
        private double LatInicial = 10.093008;
        private double LngInicial = -84.473950;

        //Latitud y longitud a mostrar al costado
        private double LatitudSeleccionada = 0;
        private double LongitudSeleccionada = 0;

        public Menu_Repartidor_ActualizarDatos()
        {
            InitializeComponent();

            this.txtNumeroPlacaVehiculo.Visible = false;
            this.chEstaDiaVehiculo.Visible = false;
            this.label52.Visible = false;


            txtVencimiento_Repartidor.Format = DateTimePickerFormat.Custom;
            txtVencimiento_Repartidor.CustomFormat = "MMMM/yyyy";
            txtVencimiento_Repartidor.ShowUpDown = true;

            log.Info("SE ABRIO EL FRM_ACTUALIZA_DATOS_REPARTIDOR");
            LocalUser = Menu_Repartidor.userAux;
        }

        private void Menu_Repartidor_ActualizarDatos_Load(object sender, EventArgs e)
        {
            //***************************************************************
            this.NumTarjeta_Aux = LocalUser._Tarjeta.NumeroTarjeta;
            this.CorreoElect_Aux = LocalUser.CorreoElectronico;
            this.Identificacion_Aux = LocalUser.Identificacion;
            this.NumTelefono_Aux = LocalUser.NumeroTelefono;
            //***************************************************************

            this.cbxTipoVehiculo.Items.Add("Bicicleta");
            this.cbxTipoVehiculo.Items.Add("Automvil");
            this.cbxTipoVehiculo.Items.Add("Motocicleta");

            //Carga todos los objetos y setea la ubicacion del usuario
            this.CargaObjetosVentana(LocalUser);


            this.InicializaMapa_Repartidor();

            


            txtVencimiento_Repartidor.Format = DateTimePickerFormat.Custom;
            txtVencimiento_Repartidor.CustomFormat = "MMMM/yyyy";
            txtVencimiento_Repartidor.ShowUpDown = true;
        }

     

        private void InicializaMapa_Repartidor()
        {
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
            marker_Repartidor = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red_big_stop);
            markerOverlay_Repartidor.Markers.Add(marker_Repartidor); //Agrega marcador al mapa

            //Se agrega el toolTip de texto al marcador
            marker_Repartidor.ToolTipMode = MarkerTooltipMode.Always;
            marker_Repartidor.ToolTipText = string.Format("Ubicacion: \n Latitud:{0} \n Longitud:{1}", LatInicial, LngInicial);

            //Agregamos el mapa y el marcador al mapControl
            mapa_Repartidor.Overlays.Add(markerOverlay_Repartidor);
        }
        private void CargaObjetosVentana(Usuario pUsuario)
        {
            try
            {
                this.txtIdentificacion_Repartidor.Text = pUsuario.Identificacion.ToString();
                this.txtNombre_Repartidor.Text = pUsuario.Nombre;
                this.txtApellido_Repartidor.Text = (pUsuario as Usuario_Repartidor).Apellidos;
                this.txtTelefono_Repartidor.Text = pUsuario.NumeroTelefono;

                this.txtCorreoElectronico_Repartidor.Text = pUsuario.CorreoElectronico;
                this.txtContrasenna1_Repartidor.Text = pUsuario.Contrasenna;
                this.txtContrasenna2_Repartidor.Text = pUsuario.Contrasenna;

                this.txtNumeroTarjeta_Repartidor.Text = pUsuario._Tarjeta.NumeroTarjeta;
                this.txtCVV_Repartidor.Text = pUsuario._Tarjeta.CVV;
                this.txtVencimiento_Repartidor.Value = pUsuario._Tarjeta.FechaVencimiento;

                if (pUsuario._Tarjeta._TipoTarjeta == TipoTarjeta.VISA)
                {
                    this.rdbVISA_Repartidor.Checked = true;
                }
                else
                {
                    this.rdbMasterCard_Repartidor.Checked = true;
                }

                this.LngInicial = pUsuario._Direccion.Longitud;
                this.LatInicial = pUsuario._Direccion.Latitud;
                this.txtDescripcion_Repartidor.Text = pUsuario._Direccion.DescripcionUbicacion;

                this.direccionRepartidor = pUsuario._Direccion;

                this.txtColorVehiculo.Text = (pUsuario as Usuario_Repartidor)._Transporte.Color;
                this.txtModeloVehiculo.Text = (pUsuario as Usuario_Repartidor)._Transporte.Modelo;
                this.txtMarcaVehiculo.Text = (pUsuario as Usuario_Repartidor)._Transporte.Marca;

                if((pUsuario as Usuario_Repartidor)._Transporte is Transporte_Bicicleta)
                {
                    this.cbxTipoVehiculo.SelectedIndex = 0;
                    this.txtNumeroPlacaVehiculo.Visible = false;
                    this.chEstaDiaVehiculo.Visible = false;
                    this.label52.Visible = false;

                }
                if ((pUsuario as Usuario_Repartidor)._Transporte is Transporte_Carro)
                {
                    this.cbxTipoVehiculo.SelectedIndex = 1;
                    Transporte trans = new Transporte_Carro();
                    trans = (pUsuario as Usuario_Repartidor)._Transporte;
                    this.txtNumeroPlacaVehiculo.Text = (trans as Transporte_Carro).NumeroPlaca.ToString();
                    this.chEstaDiaVehiculo.Checked = (trans as Transporte_Carro).EstaAsegurado;

                    this.txtNumeroPlacaVehiculo.Visible = true;
                    this.chEstaDiaVehiculo.Visible = true;
                    this.label52.Visible = true;

                }
                if ((pUsuario as Usuario_Repartidor)._Transporte is Transporte_Motocicleta)
                {
                    this.cbxTipoVehiculo.SelectedIndex = 2;
                    Transporte trans = new Transporte_Motocicleta();
                    trans = (pUsuario as Usuario_Repartidor)._Transporte;
                    this.txtNumeroPlacaVehiculo.Text = (trans as Transporte_Motocicleta).NumeroPlaca.ToString();
                    this.chEstaDiaVehiculo.Checked = (trans as Transporte_Motocicleta).EstaAsegurado;

                    this.txtNumeroPlacaVehiculo.Visible = true;
                    this.chEstaDiaVehiculo.Visible = true;
                    this.label52.Visible = true;

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








        private void btnUbicacion_Repartidor_Click(object sender, EventArgs e)
        {
            try
            {
                this.CONTENEDOR.SelectedIndex = 1;

                // this.InicializaMapa_Repartidor();

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

        private void chVerContrasenna_Repartidor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chVerContrasenna_Repartidor.Checked == true)
                {
                    txtContrasenna1_Repartidor.PasswordChar = '\0';
                    txtContrasenna1_Repartidor.UseSystemPasswordChar = false;

                    txtContrasenna2_Repartidor.PasswordChar = '\0';
                    txtContrasenna2_Repartidor.UseSystemPasswordChar = false;
                }
                else
                {
                    txtContrasenna1_Repartidor.PasswordChar = '•';
                    txtContrasenna1_Repartidor.UseSystemPasswordChar = true;

                    txtContrasenna2_Repartidor.PasswordChar = '•';
                    txtContrasenna2_Repartidor.UseSystemPasswordChar = true;
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






        private void btnActualizar_Repartidor_Click(object sender, EventArgs e)
        {
            try { 
                    //Validcaciones generales
                    try
                    {
                        this.erpErrores.Clear();

                        //Verifica que no esten vacios
                        if (string.IsNullOrEmpty(this.txtIdentificacion_Repartidor.Text))
                        {
                            this.erpErrores.SetError(this.txtIdentificacion_Repartidor, "Dato requerido");
                            return;
                        }
                        if (!this.txtTelefono_Repartidor.MaskFull)
                        {
                            this.erpErrores.SetError(this.txtTelefono_Repartidor, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtNombre_Repartidor.Text))
                        {
                            this.erpErrores.SetError(this.txtNombre_Repartidor, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtApellido_Repartidor.Text))
                        {
                            this.erpErrores.SetError(this.txtApellido_Repartidor, "Dato requerido");
                            return;
                        }

                        //Verifica si, corresponden realmente a los datos deseados
                        long numero = 0;
                        if (!long.TryParse(this.txtIdentificacion_Repartidor.Text, out numero)) //verifica que sea numero
                        {
                            this.erpErrores.SetError(this.txtIdentificacion_Repartidor, "Debe ser numerico unicamente");
                            return;
                        }
                        if (long.TryParse(this.txtNombre_Repartidor.Text, out numero))
                        {
                            this.erpErrores.SetError(this.txtNombre_Repartidor, "No debe ser numerico");
                            return;
                        }
                        if (long.TryParse(this.txtApellido_Repartidor.Text, out numero))
                        {
                            this.erpErrores.SetError(this.txtApellido_Repartidor, "No debe ser numerico");
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
                    //validaciones Correo electronico y contrasenna
                    try
                    {
                        this.erpErrores2.Clear();

                        //Verifica que no esten vacios
                        if (string.IsNullOrEmpty(this.txtCorreoElectronico_Repartidor.Text))
                        {
                            this.erpErrores2.SetError(this.txtCorreoElectronico_Repartidor, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtContrasenna1_Repartidor.Text))
                        {
                            this.erpErrores2.SetError(this.txtContrasenna1_Repartidor, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtContrasenna2_Repartidor.Text))
                        {
                            this.erpErrores2.SetError(this.txtContrasenna2_Repartidor, "Dato requerido");
                            return;
                        }
                        if (this.txtContrasenna1_Repartidor.Text != txtContrasenna2_Repartidor.Text)
                        {
                            this.erpErrores2.SetError(this.chVerContrasenna_Repartidor, "Verificar Contrasenas");
                            return;
                        }
                    if (!this.MailIsValid(this.txtCorreoElectronico_Repartidor.Text))
                    {
                        this.erpErrores2.SetError(this.txtCorreoElectronico_Repartidor, "No es un correo electornico");
                        return;
                    }

                    //Verifica si, corresponden realmente a los datos deseados
                    int numero = 0;
                        if (int.TryParse(this.txtCorreoElectronico_Repartidor.Text, out numero))
                        {
                            this.erpErrores2.SetError(this.txtCorreoElectronico_Repartidor, "No debe ser unicamente numerico");
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
                    //validacion tarjeta ingresada
                    try
                    {
                        this.erpErrores3.Clear();

                        //Verifica que no esten vacios
                        if (string.IsNullOrEmpty(this.txtNumeroTarjeta_Repartidor.Text))
                        {
                            this.erpErrores3.SetError(this.txtNumeroTarjeta_Repartidor, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtCVV_Repartidor.Text))
                        {
                            this.erpErrores3.SetError(this.txtCVV_Repartidor, "Dato requerido");
                            return;
                        }
                        if (this.rdbMasterCard_Repartidor.Checked == false && this.rdbVISA_Repartidor.Checked == false)
                        {
                            this.erpErrores3.SetError(this.label7, "Dato requerido");
                            return;
                        }

                        //Verifica si, corresponden realmente a los datos deseados ( NUMERICOS )
                        long numero = 0;
                        if (!long.TryParse(this.txtNumeroTarjeta_Repartidor.Text, out numero)) //verifica que sea numero
                        {
                            this.erpErrores3.SetError(this.txtNumeroTarjeta_Repartidor, "Debe ser numerico unicamente");
                            return;
                        }
                        if (!long.TryParse(this.txtCVV_Repartidor.Text, out numero)) //verifica que sea numero
                        {
                            this.erpErrores3.SetError(this.txtCVV_Repartidor, "Debe ser numerico unicamente");
                            return;
                        }

                        //VERIFICA SI LA TARJETA INTRODUCIDA ES VALIDA
                        string numeroTarjeta = this.txtNumeroTarjeta_Repartidor.Text;
                        string cvv = this.txtCVV_Repartidor.Text;
                        DateTime fechaVencimiento = this.txtVencimiento_Repartidor.Value;
                        Console.WriteLine(fechaVencimiento.ToString());

                        Tarjeta tarjeta = null;

                        if (this.rdbMasterCard_Repartidor.Checked)
                        {
                            tarjeta = new Tarjeta(numeroTarjeta, cvv, TipoTarjeta.MASTER_CARD, fechaVencimiento);
                        }
                        else if (this.rdbVISA_Repartidor.Checked)
                        {
                            tarjeta = new Tarjeta(numeroTarjeta, cvv, TipoTarjeta.VISA, fechaVencimiento);
                        }

                        if (tarjeta.validarFechaTarjeta() == false)
                        {
                            this.erpErrores3.SetError(this.txtVencimiento_Repartidor, "Fecha incorrecta");
                            return;
                        }
                        if (tarjeta.validarNumeroTarjeta() == false)
                        {
                            this.erpErrores3.SetError(this.txtNumeroTarjeta_Repartidor, "Numero incorrecto");
                            return;
                        }
                        if (tarjeta.validarTipoTarjeta() == false)
                        {
                            this.erpErrores3.SetError(this.txtNumeroTarjeta_Repartidor, "Numero incorrecto");
                            this.erpErrores3.SetError(this.rdbMasterCard_Repartidor, "Revisar tipo de tarjeta");
                            this.erpErrores3.SetError(this.rdbVISA_Repartidor, "Revisar tipo de tarjeta");
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
                    //validacion vehiculo
                    try
                    {
                        this.erpErrores4.Clear();

                        //Verifica que no esten vacios
                        if (string.IsNullOrEmpty(this.txtMarcaVehiculo.Text))
                        {
                            this.erpErrores4.SetError(this.txtMarcaVehiculo, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtModeloVehiculo.Text))
                        {
                            this.erpErrores4.SetError(this.txtModeloVehiculo, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtColorVehiculo.Text))
                        {
                            this.erpErrores4.SetError(this.txtColorVehiculo, "Dato requerido");
                            return;
                        }
                        if (this.cbxTipoVehiculo.SelectedIndex == -1)
                        {
                            this.erpErrores4.SetError(this.cbxTipoVehiculo, "Dato requerido");
                            return;
                        }

                        //Verifica si, corresponden realmente a los datos deseados ( NUMERICOS )
                        long numero = 0;
                        if (long.TryParse(this.txtMarcaVehiculo.Text, out numero)) //verifica que no sea numero
                        {
                            this.erpErrores4.SetError(this.txtMarcaVehiculo, "No debe ser numerico");
                            return;
                        }
                        if (long.TryParse(this.txtColorVehiculo.Text, out numero)) //verifica que no sea numero
                        {
                            this.erpErrores4.SetError(this.txtColorVehiculo, "No debe ser numerico");
                            return;
                        }

                        if (cbxTipoVehiculo.SelectedIndex == 1 || cbxTipoVehiculo.SelectedIndex == 2)
                        {
                            if (string.IsNullOrEmpty(this.txtNumeroPlacaVehiculo.Text))
                            {
                                this.erpErrores4.SetError(this.txtColorVehiculo, "Dato requerido");
                                return;
                            }
                            if (!long.TryParse(this.txtNumeroPlacaVehiculo.Text, out numero)) //verifica que no sea numero
                            {
                                this.erpErrores4.SetError(this.txtNumeroPlacaVehiculo, "No debe ser numerico");
                                return;
                            }
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


                //Validaciones existencia en BaseDatos
                if (CorreoElect_Aux != this.txtCorreoElectronico_Repartidor.Text)
                {
                    if (UsuarioLN.VerificaExistencia_CorreoElectronico(this.txtCorreoElectronico_Repartidor.Text).Equals("1"))
                    {
                        MessageBox.Show("El correo ingresado esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }


                if (NumTelefono_Aux != this.txtTelefono_Repartidor.Text)
                {
                    if (UsuarioLN.VerificaExistencia_NumeroTelefono(this.txtTelefono_Repartidor.Text).Equals("1"))
                    {
                        MessageBox.Show("El numero de telefono ingresado esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (NumTarjeta_Aux != this.txtNumeroTarjeta_Repartidor.Text)
                {
                    if (UsuarioLN.PA_VerificaUsuario_Existencia_Tarjeta(this.txtNumeroTarjeta_Repartidor.Text).Equals("1"))
                    {
                        MessageBox.Show("La tarjeta ingresada esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (Identificacion_Aux != Convert.ToInt32(this.txtIdentificacion_Repartidor.Text))
                {
                    if (UsuarioLN.PA_VerificaUsuario_Existencia_Identificacion(Convert.ToInt32(this.txtIdentificacion_Repartidor.Text)).Equals("1"))
                    {
                        MessageBox.Show("La identificacion ingresada esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }


                if (this.direccionRepartidor == null)
                {
                    MessageBox.Show("Favor ingresar una direccion primero",
                        "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                     Usuario user = FactoryUsuario.creaUsuario(TipoUsuario.REPARTIDOR);
                    user.Nombre = this.txtNombre_Repartidor.Text;
                    user.Identificacion = Convert.ToInt32(this.txtIdentificacion_Repartidor.Text);
                    (user as Usuario_Repartidor).Apellidos = this.txtApellido_Repartidor.Text;
                    user.NumeroTelefono = this.txtTelefono_Repartidor.Text;
                    user.CorreoElectronico = this.txtCorreoElectronico_Repartidor.Text;
                    user.Contrasenna = this.txtContrasenna2_Repartidor.Text;

                    Tarjeta card = FactoryTarjeta.CreaTarjeta(this.rdbVISA_Repartidor.Checked ? TipoTarjeta.VISA : TipoTarjeta.MASTER_CARD);
                    card.NumeroTarjeta = this.txtNumeroTarjeta_Repartidor.Text;
                    card.CVV = this.txtCVV_Repartidor.Text;
                    card.FechaVencimiento = this.txtVencimiento_Repartidor.Value;

                    Direccion direction = direccionRepartidor;

                    Transporte trans = null;

                    if (this.cbxTipoVehiculo.SelectedIndex == 0)
                    {
                        trans = FactoryTransporte.creaTransporte(TipoTransporte.Bicicleta);
                        trans.Marca = this.txtMarcaVehiculo.Text;
                        trans.Modelo = this.txtModeloVehiculo.Text;
                        trans.Color = this.txtColorVehiculo.Text;

                        user._Tarjeta = card;
                        user._Direccion = direction;
                        (user as Usuario_Repartidor)._Transporte = trans;

                    if (MessageBox.Show("DESEEA CONFIRMAR ESTA ACTUALIZACION", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        userDB_Access = new UsuarioLN();
                        userDB_Access.ActualizaUsuario_Repartidor(user, Identificacion_Aux);
                        Menu_Repartidor.userAux = user;
                        MessageBox.Show("ACTUALIZACION DE DATOS HA SALIDO EXITOSAMENTE",
                             "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        log.Info("SE ACTUALIZO EXITOSAMENTE EL USUARIO : " + user.Nombre);

                    }
                    else
                    {
                        Menu_Repartidor.userAux = LocalUser;
                        MessageBox.Show("ACTUALIZACION DE DATOS SE HA CANCELADO",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.CargaObjetosVentana(LocalUser);
                    }

                }
                    else if (this.cbxTipoVehiculo.SelectedIndex == 1)
                    {
                        trans = FactoryTransporte.creaTransporte(TipoTransporte.Carro);
                        trans.Marca = this.txtMarcaVehiculo.Text;
                        trans.Modelo = this.txtModeloVehiculo.Text;
                        trans.Color = this.txtColorVehiculo.Text;
                        (trans as Transporte_Carro).NumeroPlaca = Convert.ToInt32(this.txtNumeroPlacaVehiculo.Text);
                        (trans as Transporte_Carro).EstaAsegurado = this.chEstaDiaVehiculo.Checked;

                        user._Tarjeta = card;
                        user._Direccion = direction;
                        (user as Usuario_Repartidor)._Transporte = trans;

                    if (MessageBox.Show("DESEEA CONFIRMAR ESTA ACTUALIZACION", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        userDB_Access = new UsuarioLN();
                        userDB_Access.ActualizaUsuario_Repartidor(user, Identificacion_Aux);
                        Menu_Repartidor.userAux = user;
                        MessageBox.Show("ACTUALIZACION DE DATOS HA SALIDO EXITOSAMENTE",
                             "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        log.Info("SE ACTUALIZO EXITOSAMENTE EL USUARIO : " + user.Nombre);

                    }
                    else
                    {
                        Menu_Repartidor.userAux = LocalUser;
                        MessageBox.Show("ACTUALIZACION DE DATOS SE HA CANCELADO",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.CargaObjetosVentana(LocalUser);
                    }
                }
                    else if (this.cbxTipoVehiculo.SelectedIndex == 2)
                    {
                        trans = FactoryTransporte.creaTransporte(TipoTransporte.Moto);
                        trans.Marca = this.txtMarcaVehiculo.Text;
                        trans.Modelo = this.txtModeloVehiculo.Text;
                        trans.Color = this.txtColorVehiculo.Text;
                        (trans as Transporte_Motocicleta).NumeroPlaca = Convert.ToInt32(this.txtNumeroPlacaVehiculo.Text);
                        (trans as Transporte_Motocicleta).EstaAsegurado = this.chEstaDiaVehiculo.Checked;

                        user._Tarjeta = card;
                        user._Direccion = direction;
                        (user as Usuario_Repartidor)._Transporte = trans;

                    if (MessageBox.Show("DESEEA CONFIRMAR ESTA ACTUALIZACION", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        userDB_Access = new UsuarioLN();
                        userDB_Access.ActualizaUsuario_Repartidor(user, Identificacion_Aux);
                        Menu_Repartidor.userAux = user;
                        MessageBox.Show("ACTUALIZACION DE DATOS HA SALIDO EXITOSAMENTE",
                             "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        log.Info("SE ACTUALIZO EXITOSAMENTE EL USUARIO : " + user.Nombre);

                    }
                    else
                    {
                        Menu_Repartidor.userAux = LocalUser;
                        MessageBox.Show("ACTUALIZACION DE DATOS SE HA CANCELADO",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.CargaObjetosVentana(LocalUser);
                    }
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

        private void btnDesactivarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("DESEEA CONFIRMAR ESTA DESACTIVACIO DE CUENTA", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    UsuarioLN.EstadoUsuario_Desactiva_Cuenta(Identificacion_Aux);
                    log.Info("SE DESACTIVO LA CUENTA DE: "+LocalUser.Nombre );

                    FormCollection formulariosApp = Application.OpenForms;
                    foreach (Form f in formulariosApp)
                    {
                            f.Hide();                      
                    }
                    LogIn form = new LogIn();
                    form.Show();
                    

                }
                else
                {

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

        private void cbxTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxTipoVehiculo.SelectedIndex == 1 || this.cbxTipoVehiculo.SelectedIndex == 2)
            {
                this.txtNumeroPlacaVehiculo.Enabled = true;
                this.chEstaDiaVehiculo.Enabled = true;
                this.txtNumeroPlacaVehiculo.Visible = true;
                this.chEstaDiaVehiculo.Visible = true;
                this.label52.Visible = true;

            }
            else
            {
                this.txtNumeroPlacaVehiculo.Enabled = false;
                this.chEstaDiaVehiculo.Enabled = false;
                this.txtNumeroPlacaVehiculo.Visible = false;
                this.chEstaDiaVehiculo.Visible = false;
                this.label52.Visible = false;
                this.txtNumeroPlacaVehiculo.Text = "";

            }
        }

        private void btnCancelarActualizacion_Repartidor_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargaObjetosVentana(LocalUser);
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






        //----------------------------------------------------------------------------------
        //VENTANA MAPA
        private void btnAtras_Ubicacion_Repartidor_Click(object sender, EventArgs e)
        {
            try
            {
                this.CONTENEDOR.SelectedIndex = 0;
                this.txtDescripcion_Repartidor.Text = "";
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

        private void mapa_Repartidor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //Obtiene la latitud y longitud de la posiscion dentro del mapa
                LatitudSeleccionada = mapa_Repartidor.FromLocalToLatLng(e.X, e.Y).Lat;
                LongitudSeleccionada = mapa_Repartidor.FromLocalToLatLng(e.X, e.Y).Lng;

                //mover el marcador, ah la posicion dada por el usuario
                marker_Repartidor.Position = new PointLatLng(LatitudSeleccionada, LongitudSeleccionada);
                marker_Repartidor.ToolTipText = string.Format("Ubicacion: \n Latitud:{0} \n Longitud:{1}", LatitudSeleccionada, LongitudSeleccionada);

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

        private void btnObtenerUbicacion_Repartidor_Click(object sender, EventArgs e)
        {
            try
            {
                //construye objeto de DIRECCION
                if (this.txtDescripcion_Repartidor.Text == "")
                {
                    MessageBox.Show("Favor agregar una descripcion de su ubicacion");
                    return;
                }

                this.direccionRepartidor = new Direccion();
                direccionRepartidor.Longitud = this.LongitudSeleccionada;
                direccionRepartidor.Latitud = this.LatitudSeleccionada;
                direccionRepartidor.DescripcionUbicacion = this.txtDescripcion_Repartidor.Text;

                this.CONTENEDOR.SelectedIndex = 0;
                // this.txtDescripcion_Usuario.Text = "";
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

        private void btnLimpiarCampos_Ubicacion_Repartidor_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtDescripcion_Repartidor.Text = "";

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


        private void Limpiar_Repartidor()
        {
            try
            {
                this.txtNombre_Repartidor.Text = "";
                this.txtApellido_Repartidor.Text = "";
                this.txtIdentificacion_Repartidor.Text = "";
                this.txtTelefono_Repartidor.Text = "";

                this.txtCorreoElectronico_Repartidor.Text = "";
                this.txtContrasenna1_Repartidor.Text = "";
                this.txtContrasenna2_Repartidor.Text = "";

                this.txtNumeroTarjeta_Repartidor.Text = "";
                this.txtCVV_Repartidor.Text = "";

                this.txtMarcaVehiculo.Text = "";
                this.txtModeloVehiculo.Text = "";
                this.txtColorVehiculo.Text = "";
                this.txtNumeroPlacaVehiculo.Text = "";

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



        public bool MailIsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
