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
using System.Runtime.CompilerServices;

namespace Capa_Vista
{
    public partial class Menu_Empresa : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //***************************************************
        //***************************************************

        //Persistencia de usuarioLogeado
        public static Usuario userAux = LogIn.userLogIn;
        public static Usuario userAdmin = null;
        //***************************************************
        //***************************************************


        public Menu_Empresa()
        {
            InitializeComponent();
            log.Info("SE ABRIO EL FRM_MENU_EMPRESA");
            userAux = LogIn.userLogIn;
            userAdmin = null;

        }


        private void Menu_Empresa_Load(object sender, EventArgs e)
        {
            if (userAdmin != null)
            {
                this.btnActualizar_Datos.Enabled = false;
                this.btnSalir_App_.Visible = false;
                this.btnSalir_App_.Enabled = false;
                this.btnCerrar_Sesion.Visible = false;
                this.btnCerrar_Sesion.Enabled = false;

                userAux = userAdmin;

            }
            else
            {
                this.btnActualizar_Datos.Enabled = true;
                this.btnSalir_App_.Visible = true;
                this.btnSalir_App_.Enabled = true;
                this.btnCerrar_Sesion.Visible = true;
                this.btnCerrar_Sesion.Enabled = true;
            }

        }



        #region  FUNCIONALIDAD VETANA

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
            userAux = null;
            userAdmin = null;
            LogIn form = new LogIn();
            form.Show();
            this.Hide();
        }

        private void btnSalir_App__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Pedido_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo_(new Menu_Empresa_AceptarPedidos());
            log.Info("SE ABRIO EL FRM_ACEPTA_PEDIDO DESDE EL FRM_MENU_EMPRESA POR:" + userAux.Nombre);
            this.lblBienvenida.Visible = false;
            this.lblIndicaciones.Visible = false;
        }

        private void btnMantenimiento_Productos_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo_(new Menu_Empresa_Productos());
            log.Info("SE ABRIO EL FRM_MANTENIMIENTO_PRODUCTOS DESDE EL FRM_MENU_EMPRESA POR:" + userAux.Nombre);
            this.lblBienvenida.Visible = false;
            this.lblIndicaciones.Visible = false;
        }

        private void btnMantenimiento_Cupones_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo_(new Menu_Empresa_Cupones());
            log.Info("SE ABRIO EL FRM_MANTENIMIENTO_CUPONES DESDE EL FRM_MENU_EMPRESA POR:" + userAux.Nombre);
            this.lblBienvenida.Visible = false;
            this.lblIndicaciones.Visible = false;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo_(new Menu_Empresa_Reportes());
            log.Info("SE ABRIO EL FRM_REPORTES DESDE EL FRM_MENU_EMPRESA POR:" + userAux.Nombre);
            this.lblBienvenida.Visible = false;
            this.lblIndicaciones.Visible = false;
        }

        private void btnActualizar_Datos_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo_(new Menu_Empresa_ActualizarDatos());
            log.Info("SE ABRIO EL FRM_ACTUALIZAR_DATOS DESDE EL FRM_MENU_EMPRESA POR:" + userAux.Nombre);
            this.lblBienvenida.Visible = false;
            this.lblIndicaciones.Visible = false;
        }

        private void AbrirFormHijo_(Object FormHijo)
        {
            if (this.pnlContenedor_Frames_Hijos.Controls.Count > 0)
                this.pnlContenedor_Frames_Hijos.Controls.RemoveAt(0);

            Form fh = FormHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnlContenedor_Frames_Hijos.Controls.Add(fh);
            this.pnlContenedor_Frames_Hijos.Tag = fh;

            fh.Show();
        }


        public  void AsignaAdministrador(Usuario admin)
        {
            userAdmin = admin;
        }

        
    }
}
