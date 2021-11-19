using Capa_Entidades.Clases;
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
    public partial class Menu_Empresa_Reportes : Form
    {

        //***************************************************
        //***************************************************
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //Persistencia de usuarioLogeado
        public static Usuario usuarioAux = Menu_Empresa.userAux;

        //***************************************************
        //***************************************************

        public Menu_Empresa_Reportes()
        {
            InitializeComponent();
            log.Info("SE ABRIO EL FRM_REPORTES_EMPRESA");
            usuarioAux = Menu_Empresa.userAux;
        }

        private void Menu_Empresa_Reportes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'JustEat_Pry5CTDataSet7.PA_REPORTE_NEGOCIO_Recaudacion' Puede moverla o quitarla según sea necesario.
            this.PA_REPORTE_NEGOCIO_RecaudacionTableAdapter.Fill(this.JustEat_Pry5CTDataSet7.PA_REPORTE_NEGOCIO_Recaudacion, usuarioAux.Identificacion);
            // TODO: esta línea de código carga datos en la tabla 'JustEat_Pry5CTDataSet2.PA_REPORTE_NEGOCIO_CuponesAplicados' Puede moverla o quitarla según sea necesario.
            this.PA_REPORTE_NEGOCIO_CuponesAplicadosTableAdapter.Fill(this.JustEat_Pry5CTDataSet2.PA_REPORTE_NEGOCIO_CuponesAplicados, usuarioAux.Identificacion);
            // TODO: esta línea de código carga datos en la tabla 'JustEat_Pry5CTDataSet1.PA_REPORTE_NEGOCIO_ComentariosNegativos' Puede moverla o quitarla según sea necesario.
            this.PA_REPORTE_NEGOCIO_ComentariosNegativosTableAdapter.Fill(this.JustEat_Pry5CTDataSet1.PA_REPORTE_NEGOCIO_ComentariosNegativos,usuarioAux.Identificacion );


            ReportParameter param1 = new ReportParameter("vNombreEmpresa");
            param1.Values.Add(usuarioAux.Nombre);
            this.reportViewer2.LocalReport.SetParameters(param1);

            ReportParameter param2 = new ReportParameter("vNombreEmpresa");
            param2.Values.Add(usuarioAux.Nombre);
            this.reportViewer3.LocalReport.SetParameters(param2);



            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
        }

        private void pnlReporteRecaudacion_MouseClick(object sender, MouseEventArgs e)
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

        private void pnlReporteCupones_MouseClick(object sender, MouseEventArgs e)
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

        private void pnlReporteCommentsNegativos_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {


                this.tabControl1.SelectedIndex = 3;


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




        private void btnAtrasRecaudacion_Click(object sender, EventArgs e)
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

        private void btnCommentsNegativos_Click(object sender, EventArgs e)
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

        
    }
}
