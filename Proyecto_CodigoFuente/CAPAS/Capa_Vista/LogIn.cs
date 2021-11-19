using Capa_Entidades.Clases;
using Capa_Logica_Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace Capa_Vista
{
    public partial class LogIn : Form
    {
        // Es el usuario llamado en el resto de ventanas...
       public  static Usuario userLogIn = null;
       private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        private static bool banderaActivacionVentana=false;

        public LogIn()
        {
            if (banderaActivacionVentana == false)
            {
                Thread t = new Thread(new ThreadStart(SplashStart));
                t.Start();
                Thread.Sleep(7750);// da el tiempo a la ventana de carga
                t.Abort();
                banderaActivacionVentana = true;
            }
            InitializeComponent();

            this.pnlContenido.BackColor = Color.FromArgb(150, Color.Black);
            this.pnlBarraEstado.BackColor = Color.FromArgb(210, Color.Black);

            this.txtContrasenna.Size = new Size(399, 25);
            this.txtContrasenna.MinimumSize = new Size(399, 25);
            this.txtContrasenna.MaximumSize = new Size(399, 25);
            this.txtContrasenna.Multiline = false;


            this.txtNombreUsuario.Size = new Size(399, 25);
            this.txtNombreUsuario.MinimumSize = new Size(399, 25);
            this.txtNombreUsuario.MaximumSize = new Size(399, 25);
            this.txtNombreUsuario.Multiline = false;

        }
        private void LogIn_Load(object sender, EventArgs e)
        {
            this.txtNombreUsuario.Focus();
            log.Info("APERTURA FRM LOGIN");
        }



        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                
                //_MyLogControlEventos.Warn("Traza de Advertencia");
                //_MyLogControlEventos.Fatal("Traza de Error-Fatal");
                //_MyLogControlEventos.Error("Traza de Error");
                //_MyLogControlEventos.Debug("Traza de Debug");

                //string mensaje = "hola";
                //mensaje = mensaje.Substring(0, 100000);


                this.erpErrores.Clear();
                //Verifica que no esten vacios
                if (string.IsNullOrEmpty(this.txtNombreUsuario.Text))
                {
                    this.erpErrores.SetError(this.txtNombreUsuario, "Dato requerido");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtContrasenna.Text))
                {
                    this.erpErrores.SetError(this.txtContrasenna, "Dato requerido");
                    return;
                }

                //INCIO DE LA ACCION DEL BOTON DE < INICIAR SESION >

                string correo = this.txtNombreUsuario.Text;
                string contrasenna = this.txtContrasenna.Text;

                string tipoUsuarioIncioSesion = UsuarioLN.ObtenerTipoUsuario_LogIn(correo,contrasenna);

                UsuarioLN user = new UsuarioLN();
                switch (tipoUsuarioIncioSesion)
                {
                    case "1"://cliente
                        userLogIn = user.ObtenerUsuario_Cliente(correo,contrasenna);
                        Menu_Usuario form1 = new Menu_Usuario();
                        form1.Show();
                        this.Hide();
                        log.Info("Inicio de sesion cliente: "+userLogIn.Nombre);
                        break;
                    case "2"://empresa
                        userLogIn = user.ObtenerUsuario_Comercio(correo, contrasenna);
                       // userLogIn = user.ObtenerUsuario_Comercio_Calificacion(userLogIn);
                        Menu_Empresa form2 = new Menu_Empresa();
                        form2.Show();
                        this.Hide();
                        log.Info("Inicio de sesion empresa: " + userLogIn.Nombre);
                        break;
                    case "3"://repartidor
                        userLogIn = user.ObtenerUsuario_Repartidor(correo, contrasenna);
                        Menu_Repartidor form3 = new Menu_Repartidor();
                        form3.Show();
                        this.Hide();
                        log.Info("Inicio de sesion repartidor: " + userLogIn.Nombre);
                        break;
                    case "4"://administrador
                        userLogIn = user.ObtenerUsuario_Administrador(correo, contrasenna);
                        Menu_Administrador form4 = new Menu_Administrador();
                        form4.Show();
                        this.Hide();
                        log.Info("Inicio de sesion administrador: " + userLogIn.Nombre);
                        break;
                    case "-1":
                        MessageBox.Show("El correo o contrasena ingresada no corresponde a ningun usuario registrado o activo \n\n Favor revisar correo o contrasena ingresada",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }

            }
            catch (Exception err)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", err.Message);
                msg.AppendFormat("Source         {0}\n", err.Source);
                msg.AppendFormat("Data           {0}\n", err.Data);
                msg.AppendFormat("InnerException {0}\n", err.InnerException);

               // Salvar el error en el log
                log.Error(msg.ToString());

                //Mostrar mensaje al usuario
                MessageBox.Show("Se ha producido un error FORZADO:\n\nRevise el LOG\n\n"+err.Message, "Error"); 
            }
        }


        #region METODOS QUE DAN ACCION A LA VENTANA


        private void lblRegistrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            log.Info("APERTURA DESDE FRM_LOGIN DE  FRM_REGISTRO");
            LogIn_RegistroNuevoUsuario form = new LogIn_RegistroNuevoUsuario();
            form.Show();
            this.Hide();
        }

        private void lblRecuperarContrasenna_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            log.Info("APERTURA DESDE FRM_LOGIN DE  FRM_OLVIDOCONTRASENNA");
            LogIn_OlvidoContrasenna form = new LogIn_OlvidoContrasenna();
            form.Show();
            this.Hide();
        }
        #endregion


        #region METODOS DE FUNCIONALIDAD DE VENTANA
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SplashStart()
        {
            Application.Run(new Splash());

        }


        #endregion

        private void chVerContrasenna_Usuario_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chVerContrasenna_Usuario.Checked == true)
                {
                    this.txtContrasenna.PasswordChar = '\0';
                    txtContrasenna.UseSystemPasswordChar = false;
                }
                else
                {
                    txtContrasenna.PasswordChar = '•';
                    txtContrasenna.UseSystemPasswordChar = true;
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





        #region FUNCIONALIDAD VETANA
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pnlBarraEstado_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnSalir_App__MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
        private void txtNombreUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtContrasenna.Focus();
            }
        }

        private void txtContrasenna_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnIniciarSesion.Focus();
            }
        }

        private void btnIniciarSesion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.erpErrores.Clear();
                    //Verifica que no esten vacios
                    if (string.IsNullOrEmpty(this.txtNombreUsuario.Text))
                    {
                        this.erpErrores.SetError(this.txtNombreUsuario, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtContrasenna.Text))
                    {
                        this.erpErrores.SetError(this.txtContrasenna, "Dato requerido");
                        return;
                    }

                    //INCIO DE LA ACCION DEL BOTON DE < INICIAR SESION >

                    string correo = this.txtNombreUsuario.Text;
                    string contrasenna = this.txtContrasenna.Text;

                    string tipoUsuarioIncioSesion = UsuarioLN.ObtenerTipoUsuario_LogIn(correo, contrasenna);

                    UsuarioLN user = new UsuarioLN();
                    switch (tipoUsuarioIncioSesion)
                    {
                        case "1"://cliente
                            userLogIn = user.ObtenerUsuario_Cliente(correo, contrasenna);
                            Menu_Usuario form1 = new Menu_Usuario();
                            form1.Show();
                            this.Hide();

                            break;
                        case "2"://empresa
                            userLogIn = user.ObtenerUsuario_Comercio(correo, contrasenna);
                            // userLogIn = user.ObtenerUsuario_Comercio_Calificacion(userLogIn);
                            Menu_Empresa form2 = new Menu_Empresa();
                            form2.Show();
                            this.Hide();

                            break;
                        case "3"://repartidor
                            userLogIn = user.ObtenerUsuario_Repartidor(correo, contrasenna);
                            Menu_Repartidor form3 = new Menu_Repartidor();
                            form3.Show();
                            this.Hide();

                            break;
                        case "4"://administrador
                            userLogIn = user.ObtenerUsuario_Administrador(correo, contrasenna);
                            Menu_Administrador form4 = new Menu_Administrador();
                            form4.Show();
                            this.Hide();

                            break;
                        case "-1":
                            MessageBox.Show("El correo o contrasena ingresada no corresponde a ningun usuario registrado \n favor revisar lo ingresado");
                            break;
                    }


                }
                catch (Exception err)
                {
                    StringBuilder msg = new StringBuilder();
                    msg.AppendFormat("Message        {0}\n", err.Message);
                    msg.AppendFormat("Source         {0}\n", err.Source);
                    msg.AppendFormat("Data           {0}\n", err.Data);
                    msg.AppendFormat("InnerException {0}\n", err.InnerException);

                    //Salvar el error en el log
                    //    _MyLogControlEventos.Error(msg.ToString());

                    //Mostrar mensaje al usuario
                    MessageBox.Show("Se ha producido un error FORZADO:\n\nRevise el LOG\n\n" + err.Message, "Error");
                }

            }
        }




        #endregion

        
    }
}
















//[DllImport("user32.DLL", EntryPoint = "RelaseCapture")]
//private extern static void ReleaseCapture();
//[DllImport("user32.DLL", EntryPoint = "SendMessage")]
//private extern static void SendMessage(System.IntPtr hwnd,int wmsg, int wparam,int lparam );
