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
    public partial class Menu_Repartidor : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //***************************************************
        //***************************************************

        //Persistencia de usuarioLogeado
        public static Usuario userAux = LogIn.userLogIn;
        public static int numOrdenAceptada = 0;
        public static Usuario userAdmin = null;

        //***************************************************
        //***************************************************



        public Menu_Repartidor()
        {
            InitializeComponent();

            log.Info("SE ABRIO EL FRM_MENU_REPARTIDOR");

            userAux = LogIn.userLogIn;
            userAdmin = null;


        }



        private void Menu_Repartidor_Load(object sender, EventArgs e)
        {
            if (userAdmin != null)
            {
                this.btnActualizar_Datos.Enabled = false;
                this.btnSalir_App_.Visible = false;
                this.btnSalir_App_.Enabled = false;
                this.btnCerrar_Sesion.Visible = false;
                this.btnCerrar_Sesion.Enabled = false;

                userAux = null;
                userAux = userAdmin;

            }
            else
            {
                this.btnActualizar_Datos.Enabled = true;
                this.btnSalir_App_.Visible = true;
                this.btnSalir_App_.Enabled = true;
                this.btnCerrar_Sesion.Visible = true;
                this.btnCerrar_Sesion.Enabled = true;

                userAdmin = null;
            }
        }



        #region  FUNCIONALIDAD VETANA
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pnlBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

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

        #endregion

        private void btnCerrar_Sesion_Click(object sender, EventArgs e)
        {

            if ((userAux as Usuario_Repartidor)._UsuarioPaquete != null)
            {
                MessageBox.Show("Entrega en curso, no puedes cerrar la sesion en estos momentos","ATENCION",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation,
                     MessageBoxDefaultButton.Button1);
                return;
            }


            userAux = null;
            userAdmin = null;
            LogIn form = new LogIn();
            form.Show();
            this.Hide();
           
        }



        private void btnSalir_App__Click(object sender, EventArgs e)
        {

            if ((userAux as Usuario_Repartidor)._UsuarioPaquete != null)
            {
                if (MessageBox.Show("Entrega en curso, realmente desea cerrar de la aplicacion?\n\nQuedaras como moroso, con la entrega y seras calificado muy mal",
                    "INFORMACION", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnAcepta_Pedido_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo_(new Menu_Repartidor_AceptarPedido());
            log.Info("SE ABRIO EL FRM_ACEPTA_PEDIDO DESDE EL FRM_MENU_REPARTIDOR POR:"+userAux.Nombre);
            this.lblBienvenida.Visible = false;
            this.lblIndicaciones.Visible = false;
        }

        private void btnEntrega_Pedido_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo_(new Menu_Repartidor_EntregaPedido());
            log.Info("SE ABRIO EL FRM_ENTREGA_PEDIDO DESDE EL FRM_MENU_REPARTIDOR POR:" + userAux.Nombre);
            this.lblBienvenida.Visible = false;
            this.lblIndicaciones.Visible = false;
        }

        private void btnActualizar_Datos_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo_(new Menu_Repartidor_ActualizarDatos());
            log.Info("SE ABRIO EL FRM_ACTUALIZA_DATOS DESDE EL FRM_MENU_REPARTIDOR POR:" + userAux.Nombre);
            this.lblBienvenida.Visible = false;
            this.lblIndicaciones.Visible = false;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo_(new Menu_Repartidor_Reportes());
            log.Info("SE ABRIO EL FRM_REPORTES DESDE EL FRM_MENU_REPARTIDOR POR:" + userAux.Nombre);
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

        public void AsignaAdministrador(Usuario admin)
        {
            userAdmin = admin;
        }

        
    }
}
