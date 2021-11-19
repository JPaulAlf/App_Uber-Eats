using Capa_Entidades.Clases;
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
using Capa_Logica_Negocios;
using Capa_Entidades.Factory;
using System.Net.Mail;

namespace Capa_Vista
{
    public partial class Menu_Usuario_ActualizarDatos : Form
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        //**************************************************
        //**************************************************
        //brindan la actividad normal de la ventana
        private Usuario LocalUser = Menu_Usuario.userAux;
        private UsuarioLN userDB_Access = null;
        private Direccion direccionUsuario = null;

        private string NumTarjeta_Aux = "";
        private string NumTelefono_Aux = "";
        private string CorreoElect_Aux = "";
        private int Identificacion_Aux = 0;
        //**************************************************
        //**************************************************




        //Variables para dar uso al mapa, para seleccion de ubicacion
        private GMarkerGoogle marker_Usuario; // crea un marcador
        private GMapOverlay markerOverlay_Usuario; // da una capa de enmarcado

        //GENERAL PARA TODOS LOS MAPAS 
        private double LatInicial = 10.093008;
        private double LngInicial = -84.473950;

        //Latitud y longitud a mostrar al costado
        private double LatitudSeleccionada = 0;
        private double LongitudSeleccionada = 0;


        public Menu_Usuario_ActualizarDatos()
        {
            InitializeComponent();
            log.Info("SE ABRIO EL FRM_ACTUALIZAR_DATOS_CLIENTE");
            log.Info("SE REGISTRO EXITOSAMENTE AL USUARIO");

            txtFechaVencimiento.Format = DateTimePickerFormat.Custom;
            txtFechaVencimiento.CustomFormat = "MMMM/yyyy";
            txtFechaVencimiento.ShowUpDown = true;

            LocalUser = Menu_Usuario.userAux;
        }

      


        private void Menu_Usuario_ActualizarDatos_Load(object sender, EventArgs e)
        {
            try
            {
                //***************************************************************
                this.NumTarjeta_Aux = LocalUser._Tarjeta.NumeroTarjeta;
                this.CorreoElect_Aux = LocalUser.CorreoElectronico;
                this.Identificacion_Aux = LocalUser.Identificacion;
                this.NumTelefono_Aux = LocalUser.NumeroTelefono;
                //***************************************************************



                //Carga todos los objetos y setea la ubicacion del usuario
                this.CargaObjetosVentana(LocalUser);

                //setea la ubicacion de usuario en el mapa
                this.InicializaMapa_Usuario();

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

        private void InicializaMapa_Usuario()
        {
            //Da caracteristicas al MAPA 
            mapa_Usuario.DragButton = MouseButtons.Left;
            mapa_Usuario.CanDragMap = true;
            mapa_Usuario.MapProvider = GMapProviders.GoogleMap;
            mapa_Usuario.Position = new PointLatLng(LatInicial, LngInicial);
            mapa_Usuario.MinZoom = 0;
            mapa_Usuario.MaxZoom = 24;
            mapa_Usuario.Zoom = 9;
            mapa_Usuario.AutoScroll = true;

            //Crea un marcador
            markerOverlay_Usuario = new GMapOverlay("Marcador");
            marker_Usuario = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red_big_stop);
            markerOverlay_Usuario.Markers.Add(marker_Usuario); //Agrega marcador al mapa

            //Se agrega el toolTip de texto al marcador
            marker_Usuario.ToolTipMode = MarkerTooltipMode.Always;
            marker_Usuario.ToolTipText = string.Format("Ubicacion: \n Latitud:{0} \n Longitud:{1}", LatInicial, LngInicial);

            //Agregamos el mapa y el marcador al mapControl
            mapa_Usuario.Overlays.Add(markerOverlay_Usuario);
        }

        private void CargaObjetosVentana(Usuario pUsuario)
        {
            try
            {
                this.txtIdentificacion.Text = pUsuario.Identificacion.ToString();
                this.txtNombre.Text = pUsuario.Nombre;
                this.txtApellido.Text = (pUsuario as Usuario_Cliente).Apellido;
                this.txtNumeroTelefono.Text = pUsuario.NumeroTelefono;

                this.txtCorreoElectronico.Text = pUsuario.CorreoElectronico;
                this.txtContrasenna1.Text = pUsuario.Contrasenna;
                this.txtContrasenna2.Text = pUsuario.Contrasenna;

                this.txtNumeroTarjeta.Text = pUsuario._Tarjeta.NumeroTarjeta;
                this.txtCVV.Text = pUsuario._Tarjeta.CVV;
                this.txtFechaVencimiento.Value = pUsuario._Tarjeta.FechaVencimiento;

                if (pUsuario._Tarjeta._TipoTarjeta == TipoTarjeta.VISA)
                {
                    this.rdbVISA.Checked = true;
                }
                else
                {
                    this.rdbMasterCard.Checked = true;
                }

                this.LngInicial = pUsuario._Direccion.Longitud;
                this.LatInicial = pUsuario._Direccion.Latitud;
                this.txtDescripcion_Usuario.Text = pUsuario._Direccion.DescripcionUbicacion;

                this.direccionUsuario = pUsuario._Direccion;

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



        //**************************************************************************
        //---------------------------------------------------------------------------
        //**************************************************************************
        //---------------------------------------------------------------------------



        //BOTONES Y ACCIONES DE TAB DE REGISTRO INFO
        private void btnCapturaDireccion_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 1;
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

        private void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                    //Validaciones info general
                    try
                    {
                        this.erpErrores.Clear();

                        //Verifica que no esten vacios
                        if (string.IsNullOrEmpty(this.txtIdentificacion.Text))
                        {
                            this.erpErrores.SetError(this.txtIdentificacion, "Dato requerido");
                            return;
                        }
                        if (!this.txtNumeroTelefono.MaskFull)
                        {
                            this.erpErrores.SetError(this.txtNumeroTelefono, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtNombre.Text))
                        {
                            this.erpErrores.SetError(this.txtNombre, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtApellido.Text))
                        {
                            this.erpErrores.SetError(this.txtApellido, "Dato requerido");
                            return;
                        }

                        //Verifica si, corresponden realmente a los datos deseados
                        long numero = 0;
                        if (!long.TryParse(this.txtIdentificacion.Text, out numero)) //verifica que sea numero
                        {
                            this.erpErrores.SetError(this.txtIdentificacion, "Debe ser numerico unicamente");
                            return;
                        }
                        if (long.TryParse(this.txtNombre.Text, out numero))
                        {
                            this.erpErrores.SetError(this.txtNombre, "No debe ser numerico");
                            return;
                        }
                        if (long.TryParse(this.txtApellido.Text, out numero))
                        {
                            this.erpErrores.SetError(this.txtApellido, "No debe ser numerico");
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
                    //Validaciones Correo electronico
                    try
                    {
                        this.erpErrores2.Clear();

                        //Verifica que no esten vacios
                        if (string.IsNullOrEmpty(this.txtCorreoElectronico.Text))
                        {
                            this.erpErrores2.SetError(this.txtCorreoElectronico, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtContrasenna1.Text))
                        {
                            this.erpErrores2.SetError(this.txtContrasenna1, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtContrasenna2.Text))
                        {
                            this.erpErrores2.SetError(this.txtContrasenna2, "Dato requerido");
                            return;
                        }
                        if (this.txtContrasenna1.Text != txtContrasenna2.Text)
                        {
                            this.erpErrores2.SetError(this.chVerContrasenna, "Verificar Contrasenas");
                            return;
                        }
                        if (!this.MailIsValid(this.txtCorreoElectronico.Text))
                        {
                        this.erpErrores2.SetError(this.txtCorreoElectronico, "No es un correo electornico");
                        return;
                        }

                    //Verifica si, corresponden realmente a los datos deseados
                    int numero = 0;
                        if (int.TryParse(this.txtCorreoElectronico.Text, out numero))
                        {
                            this.erpErrores2.SetError(this.txtCorreoElectronico, "No debe ser unicamente numerico");
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
                    //Validaciones Tarjeta
                    try
                    {
                        this.erpErrores3.Clear();

                        //Verifica que no esten vacios
                        if (string.IsNullOrEmpty(this.txtNumeroTarjeta.Text))
                        {
                            this.erpErrores3.SetError(this.txtNumeroTarjeta, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtCVV.Text))
                        {
                            this.erpErrores3.SetError(this.txtCVV, "Dato requerido");
                            return;
                        }
                        if (this.rdbMasterCard.Checked == false && this.rdbVISA.Checked == false)
                        {
                            this.erpErrores3.SetError(this.label1, "Dato requerido");
                            return;
                        }

                        //Verifica si, corresponden realmente a los datos deseados ( NUMERICOS )
                        long numero = 0;
                        if (!long.TryParse(this.txtNumeroTarjeta.Text, out numero)) //verifica que sea numero
                        {
                            this.erpErrores3.SetError(this.txtNumeroTarjeta, "Debe ser numerico unicamente");
                            return;
                        }
                        if (!long.TryParse(this.txtCVV.Text, out numero)) //verifica que sea numero
                        {
                            this.erpErrores3.SetError(this.txtCVV, "Debe ser numerico unicamente");
                            return;
                        }

                        //VERIFICA SI LA TARJETA INTRODUCIDA ES VALIDA
                        string numeroTarjeta = this.txtNumeroTarjeta.Text;
                        string cvv = this.txtCVV.Text;
                        DateTime fechaVencimiento = this.txtFechaVencimiento.Value;
                        // Console.WriteLine(fechaVencimiento.ToString());

                        Tarjeta tarjeta = null;

                        if (this.rdbMasterCard.Checked)
                        {
                            tarjeta = new Tarjeta(numeroTarjeta, cvv, TipoTarjeta.MASTER_CARD, fechaVencimiento);
                        }
                        else if (this.rdbVISA.Checked)
                        {
                            tarjeta = new Tarjeta(numeroTarjeta, cvv, TipoTarjeta.VISA, fechaVencimiento);
                        }

                        if (tarjeta.validarFechaTarjeta() == false)
                        {
                            this.erpErrores3.SetError(this.txtFechaVencimiento, "Fecha incorrecta");
                            return;
                        }
                        if (tarjeta.validarNumeroTarjeta() == false)
                        {
                            this.erpErrores3.SetError(this.txtNumeroTarjeta, "Numero incorrecto");
                            return;
                        }
                        if (tarjeta.validarTipoTarjeta() == false)
                        {
                            this.erpErrores3.SetError(this.txtNumeroTarjeta, "Numero incorrecto");
                            this.erpErrores3.SetError(this.rdbMasterCard, "Revisar tipo de tarjeta");
                            this.erpErrores3.SetError(this.rdbVISA, "Revisar tipo de tarjeta");
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


                //Validaciones existencia en BaseDatos
                if (CorreoElect_Aux != this.txtCorreoElectronico.Text)
                {
                    if (UsuarioLN.VerificaExistencia_CorreoElectronico(this.txtCorreoElectronico.Text).Equals("1"))
                    {
                        MessageBox.Show("El correo ingresado esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }


                if (NumTelefono_Aux != this.txtNumeroTelefono.Text)
                {
                    if (UsuarioLN.VerificaExistencia_NumeroTelefono(this.txtNumeroTelefono.Text).Equals("1"))
                    {
                        MessageBox.Show("El numero de telefono ingresado esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (NumTarjeta_Aux != this.txtNumeroTarjeta.Text)
                {
                    if (UsuarioLN.PA_VerificaUsuario_Existencia_Tarjeta(this.txtNumeroTarjeta.Text).Equals("1"))
                    {
                        MessageBox.Show("La tarjeta ingresada esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if ( Identificacion_Aux != Convert.ToInt32(this.txtIdentificacion.Text))
                {
                    if (UsuarioLN.PA_VerificaUsuario_Existencia_Identificacion(Convert.ToInt32(this.txtIdentificacion.Text)).Equals("1"))
                    {
                        MessageBox.Show("La identificacion ingresada esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }


                    if (this.direccionUsuario == null)
                    {
                        MessageBox.Show("Favor ingresar una direccion primero",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }


                    Usuario user = FactoryUsuario.creaUsuario(TipoUsuario.CLIENTE);
                    user.Nombre = this.txtNombre.Text;
                    user.Identificacion = Convert.ToInt32(this.txtIdentificacion.Text);
                    (user as Usuario_Cliente).Apellido = this.txtApellido.Text;
                    user.NumeroTelefono = this.txtNumeroTelefono.Text;
                    user.CorreoElectronico = this.txtCorreoElectronico.Text;
                    user.Contrasenna = this.txtContrasenna2.Text;

                    Tarjeta card = FactoryTarjeta.CreaTarjeta(this.rdbVISA.Checked ? TipoTarjeta.VISA : TipoTarjeta.MASTER_CARD);
                    card.NumeroTarjeta = this.txtNumeroTarjeta.Text;
                    card.CVV = this.txtCVV.Text;
                    card.FechaVencimiento = this.txtFechaVencimiento.Value;

                    Direccion direction = direccionUsuario;

                    user._Tarjeta = card;
                    user._Direccion = direction;

                if( MessageBox.Show("DESEEA CONFIRMAR ESTA ACTUALIZACION", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    userDB_Access = new UsuarioLN();
                    userDB_Access.ActualizaUsuario_Cliente(user, Identificacion_Aux);
                    Menu_Usuario.userAux = user;
                    MessageBox.Show("ACTUALIZACION DE DATOS HA SALIDO EXITOSAMENTE",
                         "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    log.Info("SE ACTUALIZO EXITOSAMENTE EL USUARIO : " + user.Nombre);

                }
                else
                {
                    Menu_Usuario.userAux = LocalUser;
                    MessageBox.Show("ACTUALIZACION DE DATOS SE HA CANCELADO",
                        "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.CargaObjetosVentana(LocalUser);
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

        private void btnCancelarActualizacion_Click(object sender, EventArgs e)
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

        private void btnDesactivarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioLN.EstadoUsuario_Desactiva_Cuenta(Identificacion_Aux);
                if (MessageBox.Show("DESEEA CONFIRMAR ESTA DESACTIVACIO DE CUENTA", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    UsuarioLN.EstadoUsuario_Desactiva_Cuenta(Identificacion_Aux);
                    log.Info("SE DESACTIVO LA CUENTA DE: " + LocalUser.Nombre);
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

        private void chVerContrasenna_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chVerContrasenna.Checked == true)
                {
                    this.txtContrasenna1.PasswordChar = '\0';
                    txtContrasenna1.UseSystemPasswordChar = false;

                    this.txtContrasenna2.PasswordChar = '\0';
                    txtContrasenna2.UseSystemPasswordChar = false;
                }
                else
                {
                    txtContrasenna1.PasswordChar = '•';
                    txtContrasenna1.UseSystemPasswordChar = true;

                    txtContrasenna2.PasswordChar = '•';
                    txtContrasenna2.UseSystemPasswordChar = true;
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

        //**************************************************************************
        //---------------------------------------------------------------------------
        //**************************************************************************
        //---------------------------------------------------------------------------

        //BOTONES Y ACCIONES DE TAB DE MAPA
        private void mapa_Usuario_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //Obtiene la latitud y longitud de la posiscion dentro del mapa
                LatitudSeleccionada = mapa_Usuario.FromLocalToLatLng(e.X, e.Y).Lat;
                LongitudSeleccionada = mapa_Usuario.FromLocalToLatLng(e.X, e.Y).Lng;

                //Setea los datos en los txt del costado
                // this.txtLatitud_Usuario.Text = LatitudSeleccionada.ToString();
                //this.txtLongitud_Usuario.Text = LongitudSeleccionada.ToString();

                //mover el marcador, ah la posicion dada por el usuario
                marker_Usuario.Position = new PointLatLng(LatitudSeleccionada, LongitudSeleccionada);
                marker_Usuario.ToolTipText = string.Format("Ubicacion: \n Latitud:{0} \n Longitud:{1}", LatitudSeleccionada, LongitudSeleccionada);

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

        private void btnAtras_Usuario_Ubicacion_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 0;
              //  this.txtDescripcion_Usuario.Text = "";
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

        private void btnObtenerUbicacion_Usuario_Click(object sender, EventArgs e)
        {
            try
            {
                //construye objeto de DIRECCION
                if (this.txtDescripcion_Usuario.Text == "")
                {
                    MessageBox.Show("Favor agregar una descripcion de su ubicacion");
                    return;
                }

                this.direccionUsuario = new Direccion();
                direccionUsuario.Longitud = this.LongitudSeleccionada;
                direccionUsuario.Latitud = this.LatitudSeleccionada;
                direccionUsuario.DescripcionUbicacion = this.txtDescripcion_Usuario.Text;

                this.tabControl1.SelectedIndex = 0;
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

        private void btnLimpiarCampos_Ubicacion_Usuario_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtDescripcion_Usuario.Text = "";

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



        #region VALIDACIONES DE CAMPOS

        private void ValidaCampos_InformacionPersonal()
        {
            try
            {
                this.erpErrores.Clear();

                //Verifica que no esten vacios
                if (string.IsNullOrEmpty(this.txtIdentificacion.Text))
                {
                    this.erpErrores.SetError(this.txtIdentificacion, "Dato requerido");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtNumeroTelefono.Text))
                {
                    this.erpErrores.SetError(this.txtNumeroTelefono, "Dato requerido");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtNombre.Text))
                {
                    this.erpErrores.SetError(this.txtNombre, "Dato requerido");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtApellido.Text))
                {
                    this.erpErrores.SetError(this.txtApellido, "Dato requerido");
                    return;
                }

                //Verifica si, corresponden realmente a los datos deseados
                long numero = 0;
                if (!long.TryParse(this.txtIdentificacion.Text, out numero)) //verifica que sea numero
                {
                    this.erpErrores.SetError(this.txtIdentificacion, "Debe ser numerico unicamente");
                    return;
                }
                if (long.TryParse(this.txtNombre.Text, out numero))
                {
                    this.erpErrores.SetError(this.txtNombre, "No debe ser numerico");
                    return;
                }
                if (long.TryParse(this.txtApellido.Text, out numero))
                {
                    this.erpErrores.SetError(this.txtApellido, "No debe ser numerico");
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

                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidaCampos_InformacionCorreoElectronico()
        {
            try
            {
                this.erpErrores2.Clear();

                //Verifica que no esten vacios
                if (string.IsNullOrEmpty(this.txtCorreoElectronico.Text))
                {
                    this.erpErrores2.SetError(this.txtCorreoElectronico, "Dato requerido");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtContrasenna1.Text))
                {
                    this.erpErrores2.SetError(this.txtContrasenna1, "Dato requerido");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtContrasenna2.Text))
                {
                    this.erpErrores2.SetError(this.txtContrasenna2, "Dato requerido");
                    return;
                }

                //Verifica si, corresponden realmente a los datos deseados
                int numero = 0;
                if (int.TryParse(this.txtCorreoElectronico.Text, out numero))
                {
                    this.erpErrores2.SetError(this.txtNombre, "No debe ser unicamente numerico");
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

                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidaCampos_InformacionTarjeta()
        {
            try
            {
                this.erpErrores3.Clear();

                //Verifica que no esten vacios
                if (string.IsNullOrEmpty(this.txtNumeroTarjeta.Text))
                {
                    this.erpErrores3.SetError(this.txtNumeroTarjeta, "Dato requerido");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtCVV.Text))
                {
                    this.erpErrores3.SetError(this.txtCVV, "Dato requerido");
                    return;
                }
                if (this.rdbMasterCard.Checked == false && this.rdbVISA.Checked == false)
                {
                    this.erpErrores3.SetError(this.label11, "Dato requerido");
                    return;
                }

                //Verifica si, corresponden realmente a los datos deseados ( NUMERICOS )
                long numero = 0;
                if (!long.TryParse(this.txtNumeroTarjeta.Text, out numero)) //verifica que sea numero
                {
                    this.erpErrores3.SetError(this.txtNumeroTarjeta, "Debe ser numerico unicamente");
                    return;
                }
                if (!long.TryParse(this.txtCVV.Text, out numero)) //verifica que sea numero
                {
                    this.erpErrores3.SetError(this.txtCVV, "Debe ser numerico unicamente");
                    return;
                }

                //VERIFICA SI LA TARJETA INTRODUCIDA ES VALIDA
                string numeroTarjeta = this.txtNumeroTarjeta.Text;
                string cvv = this.txtCVV.Text;
                DateTime fechaVencimiento = this.txtFechaVencimiento.Value;
                // Console.WriteLine(fechaVencimiento.ToString());

                Tarjeta tarjeta = null;

                if (this.rdbMasterCard.Checked)
                {
                    tarjeta = new Tarjeta(numeroTarjeta, cvv, TipoTarjeta.MASTER_CARD, fechaVencimiento);
                }
                else if (this.rdbVISA.Checked)
                {
                    tarjeta = new Tarjeta(numeroTarjeta, cvv, TipoTarjeta.VISA, fechaVencimiento);
                }

                if (tarjeta.validarFechaTarjeta() == false)
                {
                    this.erpErrores3.SetError(this.txtFechaVencimiento, "Fecha incorrecta");
                    return;
                }
                if (tarjeta.validarNumeroTarjeta() == false)
                {
                    this.erpErrores3.SetError(this.txtNumeroTarjeta, "Numero incorrecto");
                    return;
                }
                if (tarjeta.validarTipoTarjeta() == false)
                {
                    this.erpErrores3.SetError(this.txtNumeroTarjeta, "Numero incorrecto");
                    this.erpErrores3.SetError(this.rdbMasterCard, "Revisar tipo de tarjeta");
                    this.erpErrores3.SetError(this.rdbVISA, "Revisar tipo de tarjeta");
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

                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        #endregion



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
