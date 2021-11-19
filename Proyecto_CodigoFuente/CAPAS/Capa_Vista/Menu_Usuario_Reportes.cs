using Capa_Entidades.Clases;
using Capa_Logica_Negocios;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Capa_Vista
{
    public partial class Menu_Usuario_Reportes : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        //**************************************************
        //**************************************************
        //brindan la actividad normal de la ventana
        private Usuario LocalUser = Menu_Usuario.userAux;
        private UsuarioLN userLN = new UsuarioLN();

        //**************************************************
        //**************************************************

        public Menu_Usuario_Reportes()
        {
            InitializeComponent();
            LocalUser = Menu_Usuario.userAux;
            log.Info("SE ABRIO EL FRM_REPORTES_CLIENTE");
        }

        private void Menu_Usuario_Reportes_Load(object sender, EventArgs e)
        {
            foreach (Usuario item in UsuarioLN.ObtenerListaUsuariosApp_Comercios())
                this.cbxNegociosDisponibles.Items.Add(item);

            //this.cbxNegociosDisponibles.DataSource = UsuarioLN.ObtenerListaUsuariosApp_Comercios();
            this.cbxNegociosDisponibles.DisplayMember = "Nombre";
            this.cbxNegociosDisponibles.ValueMember = "Identificacion";


        //TODO: esta línea de código carga datos en la tabla 'JustEat_Pry5CTDataSet3.PA_REPORTE_OrdenesCliente' Puede moverla o quitarla según sea necesario.
                this.PA_REPORTE_OrdenesClienteTableAdapter.Fill(this.JustEat_Pry5CTDataSet3.PA_REPORTE_OrdenesCliente, LocalUser.Identificacion, 0);
       // TODO: esta línea de código carga datos en la tabla 'JustEat_Pry5CTDataSet.PA_REPORTE_CLIENTE_CuponesObtenidos' Puede moverla o quitarla según sea necesario.
            this.PA_REPORTE_CLIENTE_CuponesObtenidosTableAdapter.Fill(this.JustEat_Pry5CTDataSet.PA_REPORTE_CLIENTE_CuponesObtenidos,LocalUser.Identificacion);

            //parametros reporte 1
            ReportParameter param1 = new ReportParameter("vNombreCliente");
            param1.Values.Add(this.LocalUser.Nombre);
            this.reportViewer2.LocalReport.SetParameters(param1);
            ReportParameter param2 = new ReportParameter("vNombreEmpresa");
            param2.Values.Add("");
            this.reportViewer2.LocalReport.SetParameters(param2);

            ReportParameter param3 = new ReportParameter("vNombreCliente");
            param3.Values.Add(this.LocalUser.Nombre);
            this.reportViewer1.LocalReport.SetParameters(param3);



            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }





        private void pnlReportesPedido_MouseClick(object sender, MouseEventArgs e)
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

        private void pnlReportesCupone_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {


                this.tabControl1.SelectedIndex = 2;


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




        private void btnAtrasPedidos_Click(object sender, EventArgs e)
        {
            try
            {

                this.tabControl1.SelectedIndex = 0;




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

        private void btnAtrasCupones_Click(object sender, EventArgs e)
        {
            try
            {


                this.tabControl1.SelectedIndex = 0;



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
            try
            {
                Usuario users = (Usuario)this.cbxNegociosDisponibles.SelectedItem;
                int identificacion = users.Identificacion;

                // TODO: esta línea de código carga datos en la tabla 'JustEat_Pry5CTDataSet3.PA_REPORTE_OrdenesCliente' Puede moverla o quitarla según sea necesario.
                this.PA_REPORTE_OrdenesClienteTableAdapter.Fill(this.JustEat_Pry5CTDataSet3.PA_REPORTE_OrdenesCliente, LocalUser.Identificacion, identificacion);

                ReportParameter param2 = new ReportParameter("vNombreEmpresa");
                param2.Values.Add(users.Nombre);
                this.reportViewer2.LocalReport.SetParameters(param2);

                this.reportViewer2.RefreshReport();

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





    }
}
