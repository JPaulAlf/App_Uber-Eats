using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Capa_Entidades.Clases;

namespace Capa_Vista
{
    public partial class Menu_Administrador : Form
    {

        //***************************************************
        //***************************************************
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //Persistencia de usuarioLogeado
        public static Usuario userAux = LogIn.userLogIn;

        //***************************************************
        //***************************************************

        public Menu_Administrador()
        {
            InitializeComponent();
            log.Info("SE ABRIO EL FRM_MENU_ADMINISTRADOR");
            
        }



        #region FUNCIONALIDAD VETANA
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (pnlMenu_Vertical.Width == 250)
            {
                this.pnlMenu_Vertical.Width = 84;
            }
            else
            {
                this.pnlMenu_Vertical.Width = 250;
            }
        }

        private void pnlBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        #endregion




        private void btnCerrar_Sesion_Click(object sender, EventArgs e)
        {
            LogIn form = new LogIn();
            form.Show();
            this.Hide();
        }

        private void btnSalir_App__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistro_Usuario_Click(object sender, EventArgs e)
        {
            AbrirFormHijo_(new Menu_Administrador_RegistroUsuario());
            log.Info("SE ABRIO EL FRM_REGISTRO_USUARIO DESDE EL FRM_MENU_ADMINISTRADOR POR:" + userAux.Nombre);
            this.lblBienvenida.Visible = false;
            this.lblIndicaciones.Visible = false;
        }


        //private void btnCalificaciones_Click(object sender, EventArgs e)
        //{
        //    //    AbrirFormHijo_(new Menu_Administrador_Calificaciones());
        //    //    log.Info("SE ABRIO EL FRM_CALIFICACIONES DESDE EL FRM_MENU_ADMINISTRADOR POR:" + userAux.Nombre);
        //    //    this.lblBienvenida.Visible = false;
        //    //    this.lblIndicaciones.Visible = false;
        //    }

            private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            AbrirFormHijo_(new Menu_Administrador_Mantenimiento());
            log.Info("SE ABRIO EL FRM_MANTENIMIENTO DESDE EL FRM_MENU_ADMINISTRADOR POR:" + userAux.Nombre);
            Menu_Administrador_Mantenimiento.AsignaValorMenu_Administrador(this);
            this.lblBienvenida.Visible = false;
            this.lblIndicaciones.Visible = false;
        }

     





        private void btnAbrirUsuario_Click(object sender, EventArgs e)
        {
          //  Menu_Usuario.AsignaAdministrador(userAux as Usuario_Admin);
            AbrirFormHijo_(new Menu_Usuario());
            this.lblBienvenida.Visible = false;
            this.lblIndicaciones.Visible = false;
        }

        private void btnNegocio_Click(object sender, EventArgs e)
        {
            //Menu_Empresa.AsignaAdministrador(userAux as Usuario_Admin);
            AbrirFormHijo_(new Menu_Empresa());
            this.lblBienvenida.Visible = false;
            this.lblIndicaciones.Visible = false;
        }
        private void btnRepartidor_Click(object sender, EventArgs e)
        {
            //Menu_Repartidor.AsignaAdministrador(userAux as Usuario_Admin);
            AbrirFormHijo_(new Menu_Repartidor());
            this.lblBienvenida.Visible = false;
            this.lblIndicaciones.Visible = false;
        }





        public void AbrirFormHijo_(Object FormHijo)
        {
            if (pnlContenedor_Frames_Hijos.Controls.Count > 0)
                pnlContenedor_Frames_Hijos.Controls.RemoveAt(0);

            Form fh = FormHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            pnlContenedor_Frames_Hijos.Controls.Add(fh);
            pnlContenedor_Frames_Hijos.Tag = fh;

            fh.Show();
        }

        
    }
}
