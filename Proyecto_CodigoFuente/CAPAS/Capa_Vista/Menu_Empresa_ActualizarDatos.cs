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
using Capa_Entidades.Factory;
using System.Net.Mail;

namespace Capa_Vista
{
    public partial class Menu_Empresa_ActualizarDatos : Form
    {

        //**************************************************
        //**************************************************
        //brindan la actividad normal de la ventana
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Usuario LocalUser = Menu_Empresa.userAux;
        private UsuarioLN userDB_Access = null;
        private Direccion direccionEmpresa = null;

        private string NumTarjeta_Aux = "";
        private string NumTelefono_Aux = "";
        private string CorreoElect_Aux = "";
        private int Identificacion_Aux = 0;
        //**************************************************
        //**************************************************





        private GMarkerGoogle marker_Empresa; // crea un marcador
        private GMapOverlay markerOverlay_Empresa; // da una capa de enmarcado

        private double LatInicial = 10.093008;
        private double LngInicial = -84.473950;

        //Latitud y longitud a mostrar al costado
        private double LatitudSeleccionada = 0;
        private double LongitudSeleccionada = 0;


        public Menu_Empresa_ActualizarDatos()
        {
            InitializeComponent();

            log.Info("SE ABRIO EL FRM_ACTUALIZAR_DATOS_EMPRESA");
            LocalUser = Menu_Empresa.userAux;
            txtFechaVencimeinto_Empresa.Format = DateTimePickerFormat.Custom;
            txtFechaVencimeinto_Empresa.CustomFormat = "MMMM/yyyy";
            txtFechaVencimeinto_Empresa.ShowUpDown = true;
        }


        private void Menu_Empresa_ActualizarDatos_Load(object sender, EventArgs e)
        {

            //***************************************************************
            this.NumTarjeta_Aux = LocalUser._Tarjeta.NumeroTarjeta;
            this.CorreoElect_Aux = LocalUser.CorreoElectronico;
            this.Identificacion_Aux = LocalUser.Identificacion;
            this.NumTelefono_Aux = LocalUser.NumeroTelefono;
            //***************************************************************

            //Carga todos los objetos y setea la ubicacion del usuario
            this.CargaObjetosVentana(LocalUser);


            this.InicializaMapa_Empresa();

            txtFechaVencimeinto_Empresa.Format = DateTimePickerFormat.Custom;
            txtFechaVencimeinto_Empresa.CustomFormat = "MMMM/yyyy";
            txtFechaVencimeinto_Empresa.ShowUpDown = true;
        }

        private void InicializaMapa_Empresa()
        {
            //Da caracteristicas al MAPA 
            mapa_Empresa.DragButton = MouseButtons.Left;
            mapa_Empresa.CanDragMap = true;
            mapa_Empresa.MapProvider = GMapProviders.GoogleMap;
            mapa_Empresa.Position = new PointLatLng(LatInicial, LngInicial);
            mapa_Empresa.MinZoom = 0;
            mapa_Empresa.MaxZoom = 24;
            mapa_Empresa.Zoom = 9;
            mapa_Empresa.AutoScroll = true;

            //Crea un marcador
            markerOverlay_Empresa = new GMapOverlay("Marcador");
            marker_Empresa = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red_big_stop);
            markerOverlay_Empresa.Markers.Add(marker_Empresa); //Agrega marcador al mapa

            //Se agrega el toolTip de texto al marcador
            marker_Empresa.ToolTipMode = MarkerTooltipMode.Always;
            marker_Empresa.ToolTipText = string.Format("Ubicacion: \n Latitud:{0} \n Longitud:{1}", LatInicial, LngInicial);

            //Agregamos el mapa y el marcador al mapControl
            mapa_Empresa.Overlays.Add(markerOverlay_Empresa);
        }

        private void CargaObjetosVentana(Usuario pUsuario)
        {
            try
            {
                this.txtIdentificacion_Empresa.Text = pUsuario.Identificacion.ToString();
                this.txtNombre_Empresa.Text = pUsuario.Nombre;
                this.txtTelefono_Empresa.Text = pUsuario.NumeroTelefono;

                this.txtCorreo_Empresa.Text = pUsuario.CorreoElectronico;
                this.txtContrasenna1_Empresa.Text = pUsuario.Contrasenna;
                this.txtContrasenna2_Empresa.Text = pUsuario.Contrasenna;

                this.txtNumeroTarjeta_Empresa.Text = pUsuario._Tarjeta.NumeroTarjeta;
                this.txtCVV_Empresa.Text = pUsuario._Tarjeta.CVV;
                this.txtFechaVencimeinto_Empresa.Value = pUsuario._Tarjeta.FechaVencimiento;

                if (pUsuario._Tarjeta._TipoTarjeta == TipoTarjeta.VISA)
                {
                    this.rdbVISA_Empresa.Checked = true;
                }
                else
                {
                    this.rdbMasterCard_Empresa.Checked = true;
                }

                this.LngInicial = pUsuario._Direccion.Longitud;
                this.LatInicial = pUsuario._Direccion.Latitud;
                this.txtDescripcion_Empresa.Text = pUsuario._Direccion.DescripcionUbicacion;

                this.direccionEmpresa = pUsuario._Direccion;

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

        private void btnCapturarUbicacion_Empresa_Click(object sender, EventArgs e)
        {
            try
            {
                this.CONTENEDOR.SelectedIndex = 1;




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

        private void btnActualizar_Empresa_Click(object sender, EventArgs e)
        {
            try
            {
                //Validaciones campos normales
                try
                {
                    this.erpErrores.Clear();

                    //Verifica que no esten vacios
                    if (string.IsNullOrEmpty(this.txtIdentificacion_Empresa.Text))
                    {
                        this.erpErrores.SetError(this.txtIdentificacion_Empresa, "Dato requerido");
                        return;
                    }
                    if (!this.txtTelefono_Empresa.MaskFull)
                    {
                        this.erpErrores.SetError(this.txtTelefono_Empresa, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtNombre_Empresa.Text))
                    {
                        this.erpErrores.SetError(this.txtNombre_Empresa, "Dato requerido");
                        return;
                    }


                    //Verifica si, corresponden realmente a los datos deseados
                    long numero = 0;
                    if (!long.TryParse(this.txtIdentificacion_Empresa.Text, out numero)) //verifica que sea numero
                    {
                        this.erpErrores.SetError(this.txtIdentificacion_Empresa, "Debe ser numerico unicamente");
                        return;
                    }
                    if (long.TryParse(this.txtNombre_Empresa.Text, out numero))
                    {
                        this.erpErrores.SetError(this.txtNombre_Empresa, "No debe ser numerico");
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
                //validaciones campos correo
                try
                {
                    this.erpErrores2.Clear();

                    //Verifica que no esten vacios
                    if (string.IsNullOrEmpty(this.txtCorreo_Empresa.Text))
                    {
                        this.erpErrores2.SetError(this.txtCorreo_Empresa, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtContrasenna1_Empresa.Text))
                    {
                        this.erpErrores2.SetError(this.txtContrasenna1_Empresa, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtContrasenna2_Empresa.Text))
                    {
                        this.erpErrores2.SetError(this.txtContrasenna2_Empresa, "Dato requerido");
                        return;
                    }
                    if (this.txtContrasenna1_Empresa.Text != txtContrasenna2_Empresa.Text)
                    {
                        this.erpErrores2.SetError(this.chVerContrasenna_Empresa, "Verificar Contrasenas");
                        return;
                    }
                    if (!this.MailIsValid(this.txtCorreo_Empresa.Text))
                    {
                        this.erpErrores2.SetError(this.txtCorreo_Empresa, "No es un correo electornico");
                        return;
                    }

                    //Verifica si, corresponden realmente a los datos deseados
                    int numero = 0;
                    if (int.TryParse(this.txtCorreo_Empresa.Text, out numero))
                    {
                        this.erpErrores2.SetError(this.txtCorreo_Empresa, "No debe ser unicamente numerico");
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
                //Validaciones tarjeta
                try
                {
                    this.erpErrores3.Clear();

                    //Verifica que no esten vacios
                    if (string.IsNullOrEmpty(this.txtNumeroTarjeta_Empresa.Text))
                    {
                        this.erpErrores3.SetError(this.txtNumeroTarjeta_Empresa, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtCVV_Empresa.Text))
                    {
                        this.erpErrores3.SetError(this.txtCVV_Empresa, "Dato requerido");
                        return;
                    }
                    if (this.rdbMasterCard_Empresa.Checked == false && this.rdbVISA_Empresa.Checked == false)
                    {
                        this.erpErrores3.SetError(this.label27, "Dato requerido");
                        return;
                    }

                    //Verifica si, corresponden realmente a los datos deseados ( NUMERICOS )
                    long numero = 0;
                    if (!long.TryParse(this.txtNumeroTarjeta_Empresa.Text, out numero)) //verifica que sea numero
                    {
                        this.erpErrores3.SetError(this.txtNumeroTarjeta_Empresa, "Debe ser numerico unicamente");
                        return;
                    }
                    if (!long.TryParse(this.txtCVV_Empresa.Text, out numero)) //verifica que sea numero
                    {
                        this.erpErrores3.SetError(this.txtCVV_Empresa, "Debe ser numerico unicamente");
                        return;
                    }

                    //VERIFICA SI LA TARJETA INTRODUCIDA ES VALIDA
                    string numeroTarjeta = this.txtNumeroTarjeta_Empresa.Text;
                    string cvv = this.txtCVV_Empresa.Text;
                    DateTime fechaVencimiento = this.txtFechaVencimeinto_Empresa.Value;
                    // Console.WriteLine(fechaVencimiento.ToString());

                    Tarjeta tarjeta = null;

                    if (this.rdbMasterCard_Empresa.Checked)
                    {
                        tarjeta = new Tarjeta(numeroTarjeta, cvv, TipoTarjeta.MASTER_CARD, fechaVencimiento);
                    }
                    else if (this.rdbVISA_Empresa.Checked)
                    {
                        tarjeta = new Tarjeta(numeroTarjeta, cvv, TipoTarjeta.VISA, fechaVencimiento);
                    }

                    if (tarjeta.validarFechaTarjeta() == false)
                    {
                        this.erpErrores3.SetError(this.txtFechaVencimeinto_Empresa, "Fecha incorrecta");
                        return;
                    }
                    if (tarjeta.validarNumeroTarjeta() == false)
                    {
                        this.erpErrores3.SetError(this.txtNumeroTarjeta_Empresa, "Numero incorrecto");
                        return;
                    }
                    if (tarjeta.validarTipoTarjeta() == false)
                    {
                        this.erpErrores3.SetError(this.txtNumeroTarjeta_Empresa, "Numero incorrecto");
                        this.erpErrores3.SetError(this.rdbMasterCard_Empresa, "Revisar tipo de tarjeta");
                        this.erpErrores3.SetError(this.rdbVISA_Empresa, "Revisar tipo de tarjeta");
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
                if (CorreoElect_Aux != this.txtCorreo_Empresa.Text)
                {
                    if (UsuarioLN.VerificaExistencia_CorreoElectronico(this.txtCorreo_Empresa.Text).Equals("1"))
                    {
                        MessageBox.Show("El correo ingresado esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }


                if (NumTelefono_Aux != this.txtTelefono_Empresa.Text)
                {
                    if (UsuarioLN.VerificaExistencia_NumeroTelefono(this.txtTelefono_Empresa.Text).Equals("1"))
                    {
                        MessageBox.Show("El numero de telefono ingresado esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (NumTarjeta_Aux != this.txtNumeroTarjeta_Empresa.Text)
                {
                    if (UsuarioLN.PA_VerificaUsuario_Existencia_Tarjeta(this.txtNumeroTarjeta_Empresa.Text).Equals("1"))
                    {
                        MessageBox.Show("La tarjeta ingresada esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (Identificacion_Aux != Convert.ToInt32(this.txtIdentificacion_Empresa.Text))
                {
                    if (UsuarioLN.PA_VerificaUsuario_Existencia_Identificacion(Convert.ToInt32(this.txtIdentificacion_Empresa.Text)).Equals("1"))
                    {
                        MessageBox.Show("La identificacion ingresada esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }


                if (this.direccionEmpresa == null)
                {
                    MessageBox.Show("Favor ingresar una direccion primero",
                        "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Usuario user = FactoryUsuario.creaUsuario(TipoUsuario.COMERCIO);
                user.Nombre = this.txtNombre_Empresa.Text;
                user.Identificacion = Convert.ToInt32(this.txtIdentificacion_Empresa.Text);
                user.NumeroTelefono = this.txtTelefono_Empresa.Text;
                user.CorreoElectronico = this.txtCorreo_Empresa.Text;
                user.Contrasenna = this.txtContrasenna2_Empresa.Text;

                Tarjeta card = FactoryTarjeta.CreaTarjeta(this.rdbVISA_Empresa.Checked ? TipoTarjeta.VISA : TipoTarjeta.MASTER_CARD);
                card.NumeroTarjeta = this.txtNumeroTarjeta_Empresa.Text;
                card.CVV = this.txtCVV_Empresa.Text;
                card.FechaVencimiento = this.txtFechaVencimeinto_Empresa.Value;

                Direccion direction = direccionEmpresa;

                user._Tarjeta = card;
                user._Direccion = direction;


                if (MessageBox.Show("DESEEA CONFIRMAR ESTA ACTUALIZACION", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    userDB_Access = new UsuarioLN();
                    userDB_Access.ActualizaUsuario_Comercio(user, Identificacion_Aux);
                    Menu_Empresa.userAux = user;
                    MessageBox.Show("ACTUALIZACION DE DATOS HA SALIDO EXITOSAMENTE",
                         "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    log.Info("SE ACTUALIZO EXITOSAMENTE EL USUARIO : " + user.Nombre);

                }
                else
                {
                    Menu_Empresa.userAux = LocalUser;
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

        private void chVerContrasenna_Empresa_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (chVerContrasenna_Empresa.Checked == true)
                {
                    txtContrasenna1_Empresa.PasswordChar = '\0';
                    txtContrasenna1_Empresa.UseSystemPasswordChar = false;

                    txtContrasenna2_Empresa.PasswordChar = '\0';
                    txtContrasenna2_Empresa.UseSystemPasswordChar = false;
                }
                else
                {
                    txtContrasenna1_Empresa.PasswordChar = '•';
                    txtContrasenna1_Empresa.UseSystemPasswordChar = true;

                    txtContrasenna2_Empresa.PasswordChar = '•';
                    txtContrasenna2_Empresa.UseSystemPasswordChar = true;
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

        private void btnCancelarActualizacion_Empresa_Click(object sender, EventArgs e)
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






        //UBICACION PANEL ! ! !
        private void btnAtras_Ubicacion_Empresa_Click(object sender, EventArgs e)
        {
            try
            {
                this.CONTENEDOR.SelectedIndex = 0;
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

        private void mapa_Empresa_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            try
            {
                //Obtiene la latitud y longitud de la posiscion dentro del mapa
                LatitudSeleccionada = mapa_Empresa.FromLocalToLatLng(e.X, e.Y).Lat;
                LongitudSeleccionada = mapa_Empresa.FromLocalToLatLng(e.X, e.Y).Lng;

                //mover el marcador, ah la posicion dada por el usuario
                marker_Empresa.Position = new PointLatLng(LatitudSeleccionada, LongitudSeleccionada);
                marker_Empresa.ToolTipText = string.Format("Ubicacion: \n Latitud:{0} \n Longitud:{1}", LatitudSeleccionada, LongitudSeleccionada);

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

        private void btnObtenerUbicacion_Empresa_Click(object sender, EventArgs e)
        {
            try
            {
                //construye objeto de DIRECCION
                if (this.txtDescripcion_Empresa.Text == "")
                {
                    MessageBox.Show("Favor agregar una descripcion de su ubicacion");
                    return;
                }

                this.direccionEmpresa = new Direccion();
                direccionEmpresa.Longitud = this.LongitudSeleccionada;
                direccionEmpresa.Latitud = this.LatitudSeleccionada;
                direccionEmpresa.DescripcionUbicacion = this.txtDescripcion_Empresa.Text;

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



        private void btnLimpiarCampos_Ubicacion_Empresa_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtDescripcion_Empresa.Text = "";
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
