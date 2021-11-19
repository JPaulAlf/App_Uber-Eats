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
    public partial class Menu_Repartidor_Reportes : Form
    {

        //**************************************************
        //**************************************************
        //brindan la actividad normal de la ventana
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Usuario LocalUser = Menu_Repartidor.userAux;
        private UsuarioLN userLN = new UsuarioLN();

        //**************************************************
        //**************************************************

        public Menu_Repartidor_Reportes()
        {
            InitializeComponent();

            foreach (Usuario item in UsuarioLN.ObtenerListaUsuariosApp_Comercios())
                this.cbxNegociosDisponibles.Items.Add(item);

            this.cbxNegociosDisponibles.DisplayMember = "Nombre";
            this.cbxNegociosDisponibles.ValueMember = "Identificacion";


            foreach (Usuario item in UsuarioLN.ObtenerListaUsuariosApp_Comercios())
                this.comboBox1.Items.Add(item);

            this.comboBox1.DisplayMember = "Nombre";
            this.comboBox1.ValueMember = "Identificacion";

            log.Info("SE ABRIO EL FRM_REPORTES_REPARTIDOR");
            LocalUser = Menu_Repartidor.userAux;

        }

        private void Menu_Repartidor_Reportes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'JustEat_Pry5CTDataSet5.PA_REPORTE_REPARTIDOR_EntregasCalificadasMal' Puede moverla o quitarla según sea necesario.
            this.PA_REPORTE_REPARTIDOR_EntregasCalificadasMalTableAdapter.Fill(this.JustEat_Pry5CTDataSet5.PA_REPORTE_REPARTIDOR_EntregasCalificadasMal, LocalUser.Identificacion, 0);
            // TODO: esta línea de código carga datos en la tabla 'JustEat_Pry5CTDataSet4.PA_REPORTE_REPARTIDOR_EntregasRealizadas' Puede moverla o quitarla según sea necesario.
            this.PA_REPORTE_REPARTIDOR_EntregasRealizadasTableAdapter.Fill(this.JustEat_Pry5CTDataSet4.PA_REPORTE_REPARTIDOR_EntregasRealizadas, LocalUser.Identificacion, 0);


            //parametros reporte 1
            ReportParameter param1 = new ReportParameter("vNombreCliente");
            param1.Values.Add(this.LocalUser.Nombre);
            this.reportViewer2.LocalReport.SetParameters(param1);
            ReportParameter param2 = new ReportParameter("vNombreEmpresa");
            param2.Values.Add("");
            this.reportViewer2.LocalReport.SetParameters(param2);

            //parametros reporte 2
            ReportParameter param3 = new ReportParameter("vNombreCliente");
            param3.Values.Add(this.LocalUser.Nombre);
            this.reportViewer1.LocalReport.SetParameters(param3);
            ReportParameter param4 = new ReportParameter("vNombreEmpresa");
            param4.Values.Add("");
            this.reportViewer1.LocalReport.SetParameters(param4);



            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }



        private void pnlReporteRealizadas_MouseClick(object sender, MouseEventArgs e)
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

        private void pnlReporteNegativas_MouseClick(object sender, MouseEventArgs e)
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

        private void btnAtrasEntregados_Click(object sender, EventArgs e)
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

        private void btnAtrasEntregadosMal_Click(object sender, EventArgs e)
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




        private void cbxNegociosDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Usuario users = (Usuario)this.cbxNegociosDisponibles.SelectedItem;
                int identificacion = users.Identificacion;
                this.PA_REPORTE_REPARTIDOR_EntregasRealizadasTableAdapter.Fill(this.JustEat_Pry5CTDataSet4.PA_REPORTE_REPARTIDOR_EntregasRealizadas, LocalUser.Identificacion, identificacion);
               
                ReportParameter param2 = new ReportParameter("vNombreEmpresa");
                param2.Values.Add(users.Nombre);
                this.reportViewer1.LocalReport.SetParameters(param2);
                
                this.reportViewer1.RefreshReport();


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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Usuario users = (Usuario)this.comboBox1.SelectedItem;
                int identificacion = users.Identificacion;

                this.PA_REPORTE_REPARTIDOR_EntregasCalificadasMalTableAdapter.Fill(this.JustEat_Pry5CTDataSet5.PA_REPORTE_REPARTIDOR_EntregasCalificadasMal, LocalUser.Identificacion, identificacion);

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
