using Capa_Logica_Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista
{
    public partial class LogIn_OlvidoContrasenna : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LogIn_OlvidoContrasenna()
        {
            log.Info("SE ABRIO EL MENU DE RECUPERACION DE CONTRASENNA");
            InitializeComponent();
            /* this.pnlContenido.BackColor = Color.FromArgb(172, Color.Black);
             this.pnlControl.BackColor = Color.FromArgb(185, Color.Black);
             this.pnlBotonAceptar.BackColor = Color.FromArgb(185, Color.Black);*/
           
        }
        private void LogIn_OlvidoContrasenna_Load(object sender, EventArgs e)
        {
            txtContrasenna1.PasswordChar = '•';
           // txtContrasenna1.UseSystemPasswordChar = true;

            txtContrasenna2.PasswordChar = '•';
            //txtContrasenna2.UseSystemPasswordChar = true;
        }

        #region BOTONES DE LA BARRA DE CONTROL SUPERIOR
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LogIn form = new LogIn();
            form.Show();
            this.Hide();
        }
        private void lblAtras_Click(object sender, EventArgs e)
        {
            LogIn form = new LogIn();
            form.Show();
            this.Hide();
        }
        private void btnS_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void lblSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion


        private void btnAceptarContrasenna_Click(object sender, EventArgs e)
        {
            try
            {
                this.errProvider.Clear();

                //Verifica que no esten vacios
                if (string.IsNullOrEmpty(this.txtNombreUsuario.Text))
                {
                    this.errProvider.SetError(this.txtNombreUsuario, "Dato requerido");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtContrasenna1.Text))
                {
                    this.errProvider.SetError(this.txtContrasenna1, "Dato requerido");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtContrasenna2.Text))
                {
                    this.errProvider.SetError(this.txtContrasenna2, "Dato requerido");
                    return;
                }
                int numero = 0;
                if (int.TryParse(this.txtNombreUsuario.Text, out numero))
                {
                    this.errProvider.SetError(this.txtNombreUsuario, "No debe ser unicamente numerico");
                    return;
                }


                if (txtContrasenna1.Text.Equals(this.txtContrasenna2.Text))
                {
                    //valida si el correo ingresado existe
                    if (UsuarioLN.VerificaExistencia_CorreoElectronico(this.txtNombreUsuario.Text).Equals("1"))
                    {
                        if (UsuarioLN.PA_VerificaUsuario_Correo(this.txtNombreUsuario.Text).Equals("1"))
                        {
                            UsuarioLN user = new UsuarioLN();
                            user.ActualizaUsuario_Contrasenna(this.txtNombreUsuario.Text, this.txtContrasenna1.Text);
                            MessageBox.Show("Contrasena actualizada con exito");
                            this.txtNombreUsuario.Text = "";
                            this.txtContrasenna1.Text = "";
                            this.txtContrasenna2.Text = "";
                            log.Info("SE ACTUALIZO LA CONTRASENNA DEL USUARIO SELECCIONADO");
                          
                        }
                        else
                        {
                            MessageBox.Show("El correo ingresado no se le puede modificar la contrasena",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El correo ingresado no existe como registrado",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    this.errProvider.SetError(this.txtContrasenna1, "Dato debe ser identico");
                    this.errProvider.SetError(this.txtContrasenna2, "Dato debe ser identico");
                    this.errProvider.SetError(this.checkBox1, "Dato debe ser identico");
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    this.txtContrasenna2.PasswordChar = '\0';
                    txtContrasenna2.UseSystemPasswordChar = true;

                    this.txtContrasenna1.PasswordChar = '\0';
                    txtContrasenna1.UseSystemPasswordChar = true;
                }
                else
                {
                    txtContrasenna1.PasswordChar = '•';
                    txtContrasenna1.UseSystemPasswordChar = false;

                    txtContrasenna2.PasswordChar = '•';
                    txtContrasenna2.UseSystemPasswordChar = false;
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






        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pnlControl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }




    }
}
