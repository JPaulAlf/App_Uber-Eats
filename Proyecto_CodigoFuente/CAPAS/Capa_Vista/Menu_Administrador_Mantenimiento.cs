
using Capa_Entidades.Clases;
using Capa_Entidades.Factory;
using Capa_Logica_Negocios;


using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Capa_Vista
{
    public partial class Menu_Administrador_Mantenimiento : Form
    {

        private UsuarioLN userDB_Access = null;
        private static Menu_Administrador adminMenu = null;// se utiliza para entrar a los forms hijos
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //**************************************************

        //brindan la actividad normal de la ventana
        private Usuario LocalUser1 = null;//creo que no la uso
        private Direccion direccionUsuario = null;

        private string NumTarjeta_Aux_Usuario = "";
        private string NumTelefono_Aux_Usuario = "";
        private string CorreoElect_Aux_Usuario = "";
        private int Identificacion_Aux_Usuario = 0;

        //**************************************************

        //brindan la actividad normal de la ventana
        private Usuario LocalUser2 = null;//creo que no la uso
        private Direccion direccionEmpresa = null;

        private string NumTarjeta_Aux_Empresa = "";
        private string NumTelefono_Aux_Empresa = "";
        private string CorreoElect_Aux_Empresa = "";
        private int Identificacion_Aux_Empresa = 0;

        //**************************************************

        //brindan la actividad normal de la ventana
        private Usuario LocalUser3 = null; //creo que no la uso
        private Direccion direccionRepartidor = null;

        private string NumTarjeta_Aux_Repartidor = "";
        private string NumTelefono_Aux_Repartidor = "";
        private string CorreoElect_Aux_Repartidor = "";
        private int Identificacion_Aux_Repartidor = 0;

        //**************************************************




        //Variables para dar uso al mapa, para seleccion de ubicacion
        private GMarkerGoogle marker_Usuario; // crea un marcador
        private GMapOverlay markerOverlay_Usuario; // da una capa de enmarcado

        private GMarkerGoogle marker_Empresa; // crea un marcador
        private GMapOverlay markerOverlay_Empresa; // da una capa de enmarcado

        private GMarkerGoogle marker_Repartidor; // crea un marcador
        private GMapOverlay markerOverlay_Repartidor; // da una capa de enmarcado





        //GENERAL PARA TODOS LOS MAPAS 
        private double LatInicial = 10.093008;
        private double LngInicial = -84.473950;

        //Latitud y longitud a mostrar al costado
        private double LatitudSeleccionada = 10.093008;
        private double LongitudSeleccionada = 84.473950;



        public Menu_Administrador_Mantenimiento()
        {
            InitializeComponent();

            txtFechaVencimiento_Usuario.Format = DateTimePickerFormat.Custom;
            txtFechaVencimiento_Usuario.CustomFormat = "MMMM- yyyy";

            txtFechaVencimeinto_Empresa.Format = DateTimePickerFormat.Custom;
            txtFechaVencimeinto_Empresa.CustomFormat = "MMMM- yyyy";

            txtVencimiento_Repartidor.Format = DateTimePickerFormat.Custom;
            txtVencimiento_Repartidor.CustomFormat = "MMMM- yyyy";

            dgvUsuariosApp.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvUsuariosApp.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvUsuariosApp.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            log.Info("SE ABRIO EL FRM_MANTENIMIENTO_USUARIOS");

            adminMenu = null;
        }
        private void Menu_Administrador_Mantenimiento_Load(object sender, EventArgs e)
        {

            txtFechaVencimiento_Usuario.Format = DateTimePickerFormat.Custom;
            txtFechaVencimiento_Usuario.CustomFormat = "MMMM/yyyy";
            txtFechaVencimiento_Usuario.ShowUpDown = true;

            txtFechaVencimeinto_Empresa.Format = DateTimePickerFormat.Custom;
            txtFechaVencimeinto_Empresa.CustomFormat = "MMMM/yyyy";
            txtFechaVencimeinto_Empresa.ShowUpDown = true;


            txtVencimiento_Repartidor.Format = DateTimePickerFormat.Custom;
            txtVencimiento_Repartidor.CustomFormat = "MMMM/yyyy";
            txtVencimiento_Repartidor.ShowUpDown = true;

            this.cbxTipoVehiculo.Items.Add("Bicicleta");
            this.cbxTipoVehiculo.Items.Add("Automvil");
            this.cbxTipoVehiculo.Items.Add("Motocicleta");

            this.CargaActualizadoDGV_Usuarios();

            adminMenu = null;

           

        }




        //EVENTO QUE ABRE EL FORM RESPECTIVO DEL USUARIO SELECCIONADO, Y DEJA VER AL ADMINISTRADOR SU VENTANA 
        private void btnVerComo_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string correoSeleccionado = "";
            //    string contrasennaSeleccionada = "";

            //    //Se asiganan de acuerdo a la fila seleccionada
            //    if (this.dgvUsuariosApp.SelectedRows.Count > 0)
            //    {
            //        correoSeleccionado = this.dgvUsuariosApp.CurrentRow.Cells[3].Value.ToString();
            //        contrasennaSeleccionada = this.dgvUsuariosApp.CurrentRow.Cells[4].Value.ToString();
            //    }
            //    else
            //    {
            //        correoSeleccionado = "";
            //        contrasennaSeleccionada = "";

            //        MessageBox.Show("No has seleccionado ningun registro a modificar");
            //        return;
            //    }

            //    UsuarioLN user = new UsuarioLN();

            //    Usuario pUser = null;

            //    string tipoUsuarioIncioSesion = UsuarioLN.ObtenerTipoUsuario_LogIn_SinFiltro(correoSeleccionado, contrasennaSeleccionada);

            //    switch (tipoUsuarioIncioSesion)
            //    {
            //        case "1"://cliente
            //            pUser = user.ObtenerUsuario_Cliente_SinFiltro(correoSeleccionado, contrasennaSeleccionada);
            //            Menu_Usuario aux1= new Menu_Usuario();
            //            aux1.AsignaAdministrador(pUser);
            //            adminMenu.AbrirFormHijo_(aux1);
            //            Console.WriteLine(pUser.Nombre + " " + pUser._Direccion.Latitud + " " + pUser._Direccion.Longitud);

            //            break;
            //        case "2"://empresa
            //            pUser = user.ObtenerUsuario_Comercio_SinFiltro(correoSeleccionado, contrasennaSeleccionada);
            //            Menu_Empresa aux2 = new Menu_Empresa();
            //            aux2.AsignaAdministrador(pUser);
            //            adminMenu.AbrirFormHijo_(aux2);
            //            Console.WriteLine(pUser.Nombre + " " + pUser._Direccion.Latitud + " " + pUser._Direccion.Longitud);


            //            break;
            //        case "3"://repartidor
            //            pUser = user.ObtenerUsuario_Repartidor_SinFiltro(correoSeleccionado, contrasennaSeleccionada);
            //            Menu_Repartidor aux3 = new Menu_Repartidor();
            //            aux3.AsignaAdministrador(pUser);
            //            adminMenu.AbrirFormHijo_(aux3);
            //            Console.WriteLine(pUser.Nombre +" "+pUser._Direccion.Latitud+" "+pUser._Direccion.Longitud);

            //            break;
            //        case "-1":
            //            MessageBox.Show("El correo o contrasena seleccionada no corresponde a ningun usuario " +
            //                "registrado favor revisar lo seleccionado");
            //            break;
            //    }

            //}
            //catch (Exception err)
            //{
            //    StringBuilder msg = new StringBuilder();
            //    msg.AppendFormat("Message        {0}\n", err.Message);
            //    msg.AppendFormat("Source         {0}\n", err.Source);
            //    msg.AppendFormat("Data           {0}\n", err.Data);
            //    msg.AppendFormat("InnerException {0}\n", err.InnerException);

            //    log.Error(msg.ToString());
            //    MessageBox.Show("Se ha producido un error FORZADO:\n\nRevise el LOG\n\n" + err.Message,
            //        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void btnVerComo_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int auxClick = 0;

                while (auxClick < 2)
                {
                    string correoSeleccionado = "";
                    string contrasennaSeleccionada = "";

                    //Se asiganan de acuerdo a la fila seleccionada
                    if (this.dgvUsuariosApp.SelectedRows.Count > 0)
                    {
                        correoSeleccionado = this.dgvUsuariosApp.CurrentRow.Cells[3].Value.ToString();
                        contrasennaSeleccionada = this.dgvUsuariosApp.CurrentRow.Cells[4].Value.ToString();
                    }
                    else
                    {
                        correoSeleccionado = "";
                        contrasennaSeleccionada = "";

                        MessageBox.Show("No has seleccionado ningun registro a modificar");
                        return;
                    }

                    UsuarioLN user = new UsuarioLN();

                    Usuario pUser = null;

                    string tipoUsuarioIncioSesion = UsuarioLN.ObtenerTipoUsuario_LogIn_SinFiltro(correoSeleccionado, contrasennaSeleccionada);

                    switch (tipoUsuarioIncioSesion)
                    {
                        case "1"://cliente
                            pUser = user.ObtenerUsuario_Cliente_SinFiltro(correoSeleccionado, contrasennaSeleccionada);
                            Menu_Usuario aux1 = new Menu_Usuario();
                            aux1.AsignaAdministrador(pUser);
                            adminMenu.AbrirFormHijo_(aux1);
                            Console.WriteLine(pUser.Nombre + " " + pUser._Direccion.Latitud + " " + pUser._Direccion.Longitud);

                            break;
                        case "2"://empresa
                            pUser = user.ObtenerUsuario_Comercio_SinFiltro(correoSeleccionado, contrasennaSeleccionada);
                            Menu_Empresa aux2 = new Menu_Empresa();
                            aux2.AsignaAdministrador(pUser);
                            adminMenu.AbrirFormHijo_(aux2);
                            Console.WriteLine(pUser.Nombre + " " + pUser._Direccion.Latitud + " " + pUser._Direccion.Longitud);


                            break;
                        case "3"://repartidor
                            pUser = user.ObtenerUsuario_Repartidor_SinFiltro(correoSeleccionado, contrasennaSeleccionada);
                            Menu_Repartidor aux3 = new Menu_Repartidor();
                            aux3.AsignaAdministrador(pUser);
                            adminMenu.AbrirFormHijo_(aux3);
                            Console.WriteLine(pUser.Nombre + " " + pUser._Direccion.Latitud + " " + pUser._Direccion.Longitud);

                            break;
                        case "-1":
                            MessageBox.Show("El correo o contrasena seleccionada no corresponde a ningun usuario " +
                                "registrado favor revisar lo seleccionado");
                            break;
                    }
                    auxClick++;
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
        public static void AsignaValorMenu_Administrador(Menu_Administrador formAdmin)
        {
            adminMenu = formAdmin;
        }





        private void dgvCalificaciones_SelectionChanged(object sender, EventArgs e)
        {
            try
            {


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

        private void btnActivar_Desactivar_Click(object sender, EventArgs e)
        {
            try
            {
                string estdadoUsuarioACambiar = "";

                //Se asiganan de acuerdo a la fila seleccionada
                if (this.dgvUsuariosApp.SelectedRows.Count > 0)
                {
                    estdadoUsuarioACambiar = this.dgvUsuariosApp.CurrentRow.Cells[5].Value.ToString();
                 //   Console.WriteLine(estdadoUsuarioACambiar);
                    if (estdadoUsuarioACambiar.Equals("ACTIVO"))
                    {

                      string correoSeleccionado = this.dgvUsuariosApp.CurrentRow.Cells[3].Value.ToString();
                      string contrasennaSeleccionada = this.dgvUsuariosApp.CurrentRow.Cells[4].Value.ToString(); ;

                        UsuarioLN.EstadoUsuario_Desactiva(correoSeleccionado, contrasennaSeleccionada);

                        this.CargaActualizadoDGV_Usuarios();
                    }
                    else
                    {
                        string correoSeleccionado = this.dgvUsuariosApp.CurrentRow.Cells[3].Value.ToString();
                        string contrasennaSeleccionada = this.dgvUsuariosApp.CurrentRow.Cells[4].Value.ToString(); ;

                        UsuarioLN.EstadoUsuario_Activa(correoSeleccionado, contrasennaSeleccionada);

                        this.CargaActualizadoDGV_Usuarios();
                    }
                }
                else
                {
                    estdadoUsuarioACambiar = "";
                    MessageBox.Show("No has seleccionado ningun registro a cambiar su estado");
                    this.CargaActualizadoDGV_Usuarios();
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

        private void btnActualizarDatos_Click(object sender, EventArgs e)
        {
           try
            {
                string correoSeleccionado = "";
                string contrasennaSeleccionada = "";

                //Se asiganan de acuerdo a la fila seleccionada
                if (this.dgvUsuariosApp.SelectedRows.Count > 0)
                {
                    correoSeleccionado = this.dgvUsuariosApp.CurrentRow.Cells[3].Value.ToString();
                    contrasennaSeleccionada = this.dgvUsuariosApp.CurrentRow.Cells[4].Value.ToString(); ;
                }
                else
                {
                    correoSeleccionado = "";
                    contrasennaSeleccionada = "";

                    MessageBox.Show("No has seleccionado ningun registro a modificar");
                    return;
                }

                Console.WriteLine(correoSeleccionado + "   " + contrasennaSeleccionada);

               

                UsuarioLN user = new UsuarioLN();

                Usuario pUser = null;

                string tipoUsuarioIncioSesion = UsuarioLN.ObtenerTipoUsuario_LogIn_SinFiltro(correoSeleccionado, contrasennaSeleccionada);

                switch (tipoUsuarioIncioSesion)
                {
                    case "1"://cliente
                        pUser = user.ObtenerUsuario_Cliente_SinFiltro(correoSeleccionado, contrasennaSeleccionada);

                        this. NumTarjeta_Aux_Usuario = pUser._Tarjeta.NumeroTarjeta;
                        this. NumTelefono_Aux_Usuario = pUser.NumeroTelefono;
                        this. CorreoElect_Aux_Usuario = pUser.CorreoElectronico;
                        this. Identificacion_Aux_Usuario = pUser.Identificacion;

                        this.CargaObjetosVentana_Usuario(pUser);

                        this.InicializaMapa_Usuario();

                        this.CONTENEDOR.SelectedIndex = 1;

                        break;
                    case "2"://empresa
                        pUser = user.ObtenerUsuario_Comercio_SinFiltro(correoSeleccionado, contrasennaSeleccionada);

                        this.NumTarjeta_Aux_Empresa = pUser._Tarjeta.NumeroTarjeta;
                        this.NumTelefono_Aux_Empresa = pUser.NumeroTelefono;
                        this.CorreoElect_Aux_Empresa = pUser.CorreoElectronico;
                        this.Identificacion_Aux_Empresa = pUser.Identificacion;

                        this.CargaObjetosVentana_Empresa(pUser);

                        this.InicializaMapa_Empresa();

                        this.CONTENEDOR.SelectedIndex = 2;

                        break;
                    case "3"://repartidor
                        pUser = user.ObtenerUsuario_Repartidor_SinFiltro(correoSeleccionado, contrasennaSeleccionada);

                        this.NumTarjeta_Aux_Repartidor = pUser._Tarjeta.NumeroTarjeta;
                        this.NumTelefono_Aux_Repartidor = pUser.NumeroTelefono;
                        this.CorreoElect_Aux_Repartidor = pUser.CorreoElectronico;
                        this.Identificacion_Aux_Repartidor = pUser.Identificacion;

                        this.CargaObjetosVentana_Repartidor(pUser);

                        this.InicializaMapa_Repartidor();

                        this.CONTENEDOR.SelectedIndex = 3;

                        break; 
                    case "-1":
                        MessageBox.Show("El correo o contrasena seleccionada no corresponde a ningun usuario " +
                            "registrado favor revisar lo seleccionado");
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

                log.Error(msg.ToString());
                MessageBox.Show("Se ha producido un error FORZADO:\n\nRevise el LOG\n\n" + err.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }




        public void CargaActualizadoDGV_Usuarios()
        {
            try
            {
                this.dgvUsuariosApp.Rows.Clear();
                string estado = "";
                string tipoUsuario = "";
                foreach(Usuario user in UsuarioLN.ObtenerListaUsuariosApp())
                {
                    estado = UsuarioLN.PA_VerificaUsuario_Estado_Usuario(user.CorreoElectronico, user.Contrasenna);

                    if(user is Usuario_Cliente)
                    {
                        tipoUsuario = "Cliente";
                    }
                    else if (user is Usuario_Comercio)
                    {
                        tipoUsuario = "Negocio";

                    }
                    else if (user is Usuario_Repartidor)
                    {
                        tipoUsuario = "Repartidor";

                    }

                    this.dgvUsuariosApp.Rows.Add(
                        user.Identificacion,
                        user.Nombre,
                        tipoUsuario,                        
                        user.CorreoElectronico,
                        user.Contrasenna,
                        estado
                        );

                }

                foreach (DataGridViewRow fila in dgvUsuariosApp.Rows)
                    fila.Height = 35;

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
        private void dgvUsuariosApp_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvUsuariosApp.Columns[e.ColumnIndex].Name == "Estado")
            {
                try
                {
                    if (e.Value.GetType() != typeof(DBNull))
                    {

                        if (e.Value.ToString() == "INACTIVO")
                        {
                            e.CellStyle.ForeColor = Color.Red;
                        }
                        

                    }
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("");
                }
            }
        }
        private void dgvUsuariosApp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.dgvUsuariosApp.ClearSelection();
        }



        private void CargaObjetosVentana_Usuario(Usuario pUsuario)
        {
            try
            {
                this.txtIdentificacion_Usuario.Text = pUsuario.Identificacion.ToString();
                this.txtNombre_Uusario.Text = pUsuario.Nombre;
                this.txtApellido_Usuario.Text = (pUsuario as Usuario_Cliente).Apellido;
                this.txtNumeroTelefono_Usuario.Text = pUsuario.NumeroTelefono;

                this.txtCorreoElectronico_Usuario.Text = pUsuario.CorreoElectronico;
                this.txtContrasenna1_Usuario.Text = pUsuario.Contrasenna;
                this.txtContrasenna2_Usuario.Text = pUsuario.Contrasenna;

                this.txtNumeroTarjeta_Usuario.Text = pUsuario._Tarjeta.NumeroTarjeta;
                this.txtCVV_Usuario.Text = pUsuario._Tarjeta.CVV;
                this.txtFechaVencimiento_Usuario.Value = pUsuario._Tarjeta.FechaVencimiento;

                if (pUsuario._Tarjeta._TipoTarjeta == TipoTarjeta.VISA)
                {
                    this.rdbVISA_Usuario.Checked = true;
                }
                else
                {
                    this.rdbMasterCard_Usuario.Checked = true;
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
        private void CargaObjetosVentana_Repartidor(Usuario pUsuario)
        {
            try
            {
                this.txtIdentificacion_Repartidor.Text = pUsuario.Identificacion.ToString();
                this.txtNombre_Repartidor.Text = pUsuario.Nombre;
                this.txtApellido_Repartidor.Text = (pUsuario as Usuario_Repartidor).Apellidos;
                this.txtTelefono_Repartidor.Text = pUsuario.NumeroTelefono;

                this.txtCorreoElectronico_Repartidor.Text = pUsuario.CorreoElectronico;
                this.txtContrasenna1_Repartidor.Text = pUsuario.Contrasenna;
                this.txtContrasenna2_Repartidor.Text = pUsuario.Contrasenna;

                this.txtNumeroTarjeta_Repartidor.Text = pUsuario._Tarjeta.NumeroTarjeta;
                this.txtCVV_Repartidor.Text = pUsuario._Tarjeta.CVV;
                this.txtVencimiento_Repartidor.Value = pUsuario._Tarjeta.FechaVencimiento;

                if (pUsuario._Tarjeta._TipoTarjeta == TipoTarjeta.VISA)
                {
                    this.rdbVISA_Repartidor.Checked = true;
                }
                else
                {
                    this.rdbMasterCard_Repartidor.Checked = true;
                }

                this.LngInicial = pUsuario._Direccion.Longitud;
                this.LatInicial = pUsuario._Direccion.Latitud;
                this.txtDescripcion_Repartidor.Text = pUsuario._Direccion.DescripcionUbicacion;

                this.direccionRepartidor = pUsuario._Direccion;

                this.txtColorVehiculo.Text = (pUsuario as Usuario_Repartidor)._Transporte.Color;
                this.txtModeloVehiculo.Text = (pUsuario as Usuario_Repartidor)._Transporte.Modelo;
                this.txtMarcaVehiculo.Text = (pUsuario as Usuario_Repartidor)._Transporte.Marca;

                if ((pUsuario as Usuario_Repartidor)._Transporte is Transporte_Bicicleta)
                {
                    this.cbxTipoVehiculo.SelectedIndex = 0;
                    this.txtNumeroPlacaVehiculo.Visible = false;
                    this.chEstaDiaVehiculo.Visible = false;
                    this.label52.Visible = false;
                }
                if ((pUsuario as Usuario_Repartidor)._Transporte is Transporte_Carro)
                {
                    this.cbxTipoVehiculo.SelectedIndex = 1;
                    Transporte trans = new Transporte_Carro();
                    trans = (pUsuario as Usuario_Repartidor)._Transporte;
                    this.txtNumeroPlacaVehiculo.Text = (trans as Transporte_Carro).NumeroPlaca.ToString();
                    this.chEstaDiaVehiculo.Checked = (trans as Transporte_Carro).EstaAsegurado;

                    this.txtNumeroPlacaVehiculo.Visible = true;
                    this.chEstaDiaVehiculo.Visible = true;
                    this.label52.Visible = true;

                }
                if ((pUsuario as Usuario_Repartidor)._Transporte is Transporte_Motocicleta)
                {
                    this.cbxTipoVehiculo.SelectedIndex = 2;
                    Transporte trans = new Transporte_Motocicleta();
                    trans = (pUsuario as Usuario_Repartidor)._Transporte;
                    this.txtNumeroPlacaVehiculo.Text = (trans as Transporte_Motocicleta).NumeroPlaca.ToString();
                    this.chEstaDiaVehiculo.Checked = (trans as Transporte_Motocicleta).EstaAsegurado;

                    this.txtNumeroPlacaVehiculo.Visible = true;
                    this.chEstaDiaVehiculo.Visible = true;
                    this.label52.Visible = true;

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
        private void CargaObjetosVentana_Empresa(Usuario pUsuario)
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
        private void InicializaMapa_Repartidor()
        {
            //Da caracteristicas al MAPA 
            mapa_Repartidor.DragButton = MouseButtons.Left;
            mapa_Repartidor.CanDragMap = true;
            mapa_Repartidor.MapProvider = GMapProviders.GoogleMap;
            mapa_Repartidor.Position = new PointLatLng(LatInicial, LngInicial);
            mapa_Repartidor.MinZoom = 0;
            mapa_Repartidor.MaxZoom = 24;
            mapa_Repartidor.Zoom = 9;
            mapa_Repartidor.AutoScroll = true;

            //Crea un marcador
            markerOverlay_Repartidor = new GMapOverlay("Marcador");
            marker_Repartidor = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red_big_stop);
            markerOverlay_Repartidor.Markers.Add(marker_Repartidor); //Agrega marcador al mapa

            //Se agrega el toolTip de texto al marcador
            marker_Repartidor.ToolTipMode = MarkerTooltipMode.Always;
            marker_Repartidor.ToolTipText = string.Format("Ubicacion: \n Latitud:{0} \n Longitud:{1}", LatInicial, LngInicial);

            //Agregamos el mapa y el marcador al mapControl
            mapa_Repartidor.Overlays.Add(markerOverlay_Repartidor);
        }



        private void LimpiaMapa_Usuario()
        {
            if (mapa_Usuario.Overlays.Count > 0)
            {
                mapa_Usuario.Overlays.RemoveAt(0);
                mapa_Usuario.Refresh();
            }
        }
        private void LimpiaMapa_Empresa()
        {
            if (mapa_Empresa.Overlays.Count > 0)
            {
                mapa_Empresa.Overlays.RemoveAt(0);
                mapa_Empresa.Refresh();
            }
        }
        private void LimpiaMapa_Repartidor()
        {
            if (mapa_Repartidor.Overlays.Count > 0)
            {
                mapa_Repartidor.Overlays.RemoveAt(0);
                mapa_Repartidor.Refresh();
            }
        }




        #region REGISTRO USUARIO 

        private void btnCapturaDireccion_Usuario_Click(object sender, EventArgs e)
        {
            try
            {
                this.CONTENEDOR.SelectedIndex = 4;

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

        private void btnAtras_Usuario_Click(object sender, EventArgs e)
        {
            try
            {
                this.CONTENEDOR.SelectedIndex = 0;
                this.CargaActualizadoDGV_Usuarios();
                this.CONTENEDOR.SelectedIndex = 0;
                this.NumTarjeta_Aux_Usuario = "";
                this.NumTelefono_Aux_Usuario = "";
                this.CorreoElect_Aux_Usuario = "";
                this.Identificacion_Aux_Usuario = 0;

                this.erpErrores.Clear();
                this.erpErrores2.Clear();
                this.erpErrores3.Clear();
                this.erpErrores4.Clear();
                this.erpErrores5.Clear();

                this.Limpiar_Usuario();
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

        private void btnActualizarDatos_Usuario_Click(object sender, EventArgs e)
        {
            try
            {
                //Validaciones info general
                try
                {
                        this.erpErrores.Clear();

                        //Verifica que no esten vacios
                        if (string.IsNullOrEmpty(this.txtIdentificacion_Usuario.Text))
                        {
                            this.erpErrores.SetError(this.txtIdentificacion_Usuario, "Dato requerido");
                            return;
                        }
                        if (!this.txtNumeroTelefono_Usuario.MaskFull)
                        {
                            this.erpErrores.SetError(this.txtNumeroTelefono_Usuario, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtNombre_Uusario.Text))
                        {
                            this.erpErrores.SetError(this.txtNombre_Uusario, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtApellido_Usuario.Text))
                        {
                            this.erpErrores.SetError(this.txtApellido_Usuario, "Dato requerido");
                            return;
                        }

                        //Verifica si, corresponden realmente a los datos deseados
                        long numero = 0;
                        if (!long.TryParse(this.txtIdentificacion_Usuario.Text, out numero)) //verifica que sea numero
                        {
                            this.erpErrores.SetError(this.txtIdentificacion_Usuario, "Debe ser numerico unicamente");
                            return;
                        }
                        if (long.TryParse(this.txtNombre_Uusario.Text, out numero))
                        {
                            this.erpErrores.SetError(this.txtNombre_Uusario, "No debe ser numerico");
                            return;
                        }
                        if (long.TryParse(this.txtApellido_Usuario.Text, out numero))
                        {
                            this.erpErrores.SetError(this.txtApellido_Usuario, "No debe ser numerico");
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
                        if (string.IsNullOrEmpty(this.txtCorreoElectronico_Usuario.Text))
                        {
                            this.erpErrores2.SetError(this.txtCorreoElectronico_Usuario, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtContrasenna1_Usuario.Text))
                        {
                            this.erpErrores2.SetError(this.txtContrasenna1_Usuario, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtContrasenna2_Usuario.Text))
                        {
                            this.erpErrores2.SetError(this.txtContrasenna2_Usuario, "Dato requerido");
                            return;
                        }
                         if (this.txtContrasenna1_Usuario.Text != txtContrasenna2_Usuario.Text)
                         {
                        this.erpErrores2.SetError(this.chVerContrasenna_Usuario, "Verificar Contrasenas");
                        return;
                         }
                    if (!this.MailIsValid(this.txtCorreoElectronico_Usuario.Text))
                    {
                        this.erpErrores2.SetError(this.txtCorreoElectronico_Usuario, "No es un correo electornico");
                        return;
                    }
                    //Verifica si, corresponden realmente a los datos deseados
                    int numero = 0;
                        if (int.TryParse(this.txtCorreoElectronico_Usuario.Text, out numero))
                        {
                            this.erpErrores2.SetError(this.txtCorreoElectronico_Usuario, "No debe ser unicamente numerico");
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
                        if (string.IsNullOrEmpty(this.txtNumeroTarjeta_Usuario.Text))
                        {
                            this.erpErrores3.SetError(this.txtNumeroTarjeta_Usuario, "Dato requerido");
                            return;
                        }
                        if (string.IsNullOrEmpty(this.txtCVV_Usuario.Text))
                        {
                            this.erpErrores3.SetError(this.txtCVV_Usuario, "Dato requerido");
                            return;
                        }
                        if (this.rdbMasterCard_Usuario.Checked == false && this.rdbVISA_Usuario.Checked == false)
                        {
                            this.erpErrores3.SetError(this.label1, "Dato requerido");
                            return;
                        }

                        //Verifica si, corresponden realmente a los datos deseados ( NUMERICOS )
                        long numero = 0;
                        if (!long.TryParse(this.txtNumeroTarjeta_Usuario.Text, out numero)) //verifica que sea numero
                        {
                            this.erpErrores3.SetError(this.txtNumeroTarjeta_Usuario, "Debe ser numerico unicamente");
                            return;
                        }
                        if (!long.TryParse(this.txtCVV_Usuario.Text, out numero)) //verifica que sea numero
                        {
                            this.erpErrores3.SetError(this.txtCVV_Usuario, "Debe ser numerico unicamente");
                            return;
                        }

                        //VERIFICA SI LA TARJETA INTRODUCIDA ES VALIDA
                        string numeroTarjeta = this.txtNumeroTarjeta_Usuario.Text;
                        string cvv = this.txtCVV_Usuario.Text;
                        DateTime fechaVencimiento = this.txtFechaVencimiento_Usuario.Value;
                        // Console.WriteLine(fechaVencimiento.ToString());

                        Tarjeta tarjeta = null;

                        if (this.rdbMasterCard_Usuario.Checked)
                        {
                            tarjeta = new Tarjeta(numeroTarjeta, cvv, TipoTarjeta.MASTER_CARD, fechaVencimiento);
                        }
                        else if (this.rdbVISA_Usuario.Checked)
                        {
                            tarjeta = new Tarjeta(numeroTarjeta, cvv, TipoTarjeta.VISA, fechaVencimiento);
                        }

                        if (tarjeta.validarFechaTarjeta() == false)
                        {
                            this.erpErrores3.SetError(this.txtFechaVencimiento_Usuario, "Fecha incorrecta");
                            return;
                        }
                        if (tarjeta.validarNumeroTarjeta() == false)
                        {
                            this.erpErrores3.SetError(this.txtNumeroTarjeta_Usuario, "Numero incorrecto");
                            return;
                        }
                        if (tarjeta.validarTipoTarjeta() == false)
                        {
                            this.erpErrores3.SetError(this.txtNumeroTarjeta_Usuario, "Numero incorrecto");
                            this.erpErrores3.SetError(this.rdbMasterCard_Usuario, "Revisar tipo de tarjeta");
                            this.erpErrores3.SetError(this.rdbVISA_Usuario, "Revisar tipo de tarjeta");
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
                if (CorreoElect_Aux_Usuario != this.txtCorreoElectronico_Usuario.Text)
                {
                    if (UsuarioLN.VerificaExistencia_CorreoElectronico(this.txtCorreoElectronico_Usuario.Text).Equals("1"))
                    {
                        MessageBox.Show("El correo ingresado esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (NumTelefono_Aux_Usuario != this.txtNumeroTelefono_Usuario.Text)
                {
                    if (UsuarioLN.VerificaExistencia_NumeroTelefono(this.txtNumeroTelefono_Usuario.Text).Equals("1"))
                    {
                        MessageBox.Show("El numero de telefono ingresado esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (NumTarjeta_Aux_Usuario != this.txtNumeroTarjeta_Usuario.Text)
                {
                    if (UsuarioLN.PA_VerificaUsuario_Existencia_Tarjeta(this.txtNumeroTarjeta_Usuario.Text).Equals("1"))
                    {
                        MessageBox.Show("La tarjeta ingresada esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (Identificacion_Aux_Usuario != Convert.ToInt32(this.txtIdentificacion_Usuario.Text))
                {
                    if (UsuarioLN.PA_VerificaUsuario_Existencia_Identificacion(Convert.ToInt32(this.txtIdentificacion_Usuario.Text)).Equals("1"))
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
                user.Nombre = this.txtNombre_Uusario.Text;
                user.Identificacion = Convert.ToInt32(this.txtIdentificacion_Usuario.Text);
                (user as Usuario_Cliente).Apellido = this.txtApellido_Usuario.Text;
                user.NumeroTelefono = this.txtNumeroTelefono_Usuario.Text;
                user.CorreoElectronico = this.txtCorreoElectronico_Usuario.Text;
                user.Contrasenna = this.txtContrasenna2_Usuario.Text;

                Tarjeta card = FactoryTarjeta.CreaTarjeta(this.rdbVISA_Usuario.Checked ? TipoTarjeta.VISA : TipoTarjeta.MASTER_CARD);
                card.NumeroTarjeta = this.txtNumeroTarjeta_Usuario.Text;
                card.CVV = this.txtCVV_Usuario.Text;
                card.FechaVencimiento = this.txtFechaVencimiento_Usuario.Value;

                Direccion direction = direccionUsuario;

                user._Tarjeta = card;
                user._Direccion = direction;

                if (MessageBox.Show("DESEEA CONFIRMAR ESTA ACTUALIZACION", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    userDB_Access = new UsuarioLN();
                    userDB_Access.ActualizaUsuario_Cliente(user, Identificacion_Aux_Usuario);
                    MessageBox.Show("ACTUALIZACION DE DATOS HA SALIDO EXITOSAMENTE",
                         "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    log.Info("SE ACTUALIZO EXITOSAMENTE EL USUARIO ["+user.Nombre+"] DESDE EL MANTENIMIENTO DE ADMINISTRADOR");

                    this.CONTENEDOR.SelectedIndex = 0;
                    this.NumTarjeta_Aux_Usuario = "";
                    this.NumTelefono_Aux_Usuario = "";
                    this.CorreoElect_Aux_Usuario = "";
                    this.Identificacion_Aux_Usuario = 0;
                    this.CargaActualizadoDGV_Usuarios();
                }
                else
                {
                    MessageBox.Show("ACTUALIZACION DE DATOS SE HA CANCELADO",
                        "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.CONTENEDOR.SelectedIndex = 0;
                    this.NumTarjeta_Aux_Usuario = "";
                    this.NumTelefono_Aux_Usuario = "";
                    this.CorreoElect_Aux_Usuario = "";
                    this.Identificacion_Aux_Usuario = 0;

                    this.CargaActualizadoDGV_Usuarios();
                }





                this.LimpiaMapa_Usuario();

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

        private void chVerContrasenna_Usuario_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chVerContrasenna_Usuario.Checked == true)
                {
                    this.txtContrasenna1_Usuario.PasswordChar = '\0';
                    txtContrasenna1_Usuario.UseSystemPasswordChar = false;

                    this.txtContrasenna2_Usuario.PasswordChar = '\0';
                    txtContrasenna2_Usuario.UseSystemPasswordChar = false;
                }
                else
                {
                    txtContrasenna1_Usuario.PasswordChar = '•';
                    txtContrasenna1_Usuario.UseSystemPasswordChar = true;

                    txtContrasenna2_Usuario.PasswordChar = '•';
                    txtContrasenna2_Usuario.UseSystemPasswordChar = true;
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

        private void btnCancelar_Usuario_Click(object sender, EventArgs e)
        {
            try
            {
                this.CONTENEDOR.SelectedIndex = 0;
                this.LimpiaMapa_Usuario();
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


        //UBICACION PANEL !!!!
        private void btnAtras_Usuario_Ubicacion_Click(object sender, EventArgs e)
        {
            try
            {
                this.CONTENEDOR.SelectedIndex = 1;
           //     this.txtDescripcion_Usuario.Text = "";
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

                this.CONTENEDOR.SelectedIndex = 1;
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


        #region VALIDACIONES DE CAMPOS USUARIO y LIMPIAR

       

        private void Limpiar_Usuario()
        {
            try
            {
                this.txtNombre_Uusario.Text = "";
                this.txtApellido_Usuario.Text = "";
                this.txtIdentificacion_Usuario.Text = "";
                this.txtNumeroTelefono_Usuario.Text = "";

                this.txtCorreoElectronico_Usuario.Text = "";
                this.txtContrasenna1_Usuario.Text = "";
                this.txtContrasenna2_Usuario.Text = "";

                this.txtNumeroTarjeta_Usuario.Text = "";
                this.txtCVV_Usuario.Text = "";

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






        #endregion

        #endregion



        #region REGISTRO EMPRESA 
        private void btnAtras_Empresa_Click(object sender, EventArgs e)
        {
            try
            {
                this.CONTENEDOR.SelectedIndex = 0;
                this.CargaActualizadoDGV_Usuarios();
                this.NumTarjeta_Aux_Empresa = "";
                this.NumTelefono_Aux_Empresa = "";
                this.CorreoElect_Aux_Empresa = "";
                this.Identificacion_Aux_Empresa = 0;

                this.erpErrores.Clear();
                this.erpErrores2.Clear();
                this.erpErrores3.Clear();
                this.erpErrores4.Clear();
                this.erpErrores5.Clear();

                this.Limpiar_Empresa();
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
                this.CONTENEDOR.SelectedIndex = 5;




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
                if (CorreoElect_Aux_Empresa != this.txtCorreo_Empresa.Text)
                {
                    if (UsuarioLN.VerificaExistencia_CorreoElectronico(this.txtCorreo_Empresa.Text).Equals("1"))
                    {
                        MessageBox.Show("El correo ingresado esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (NumTelefono_Aux_Empresa != this.txtTelefono_Empresa.Text)
                {
                    if (UsuarioLN.VerificaExistencia_NumeroTelefono(this.txtTelefono_Empresa.Text).Equals("1"))
                    {
                        MessageBox.Show("El numero de telefono ingresado esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (NumTarjeta_Aux_Empresa != this.txtNumeroTarjeta_Empresa.Text)
                {
                    if (UsuarioLN.PA_VerificaUsuario_Existencia_Tarjeta(this.txtNumeroTarjeta_Empresa.Text).Equals("1"))
                    {
                        MessageBox.Show("La tarjeta ingresada esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (Identificacion_Aux_Empresa != Convert.ToInt32(this.txtIdentificacion_Empresa.Text))
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
                    userDB_Access.ActualizaUsuario_Comercio(user, Identificacion_Aux_Empresa);
                    MessageBox.Show("ACTUALIZACION DE DATOS HA SALIDO EXITOSAMENTE",
                         "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    log.Info("SE ACTUALIZO EXITOSAMENTE EL USUARIO [" + user.Nombre + "] DESDE EL MANTENIMIENTO DE ADMINISTRADOR");
                    this.CONTENEDOR.SelectedIndex = 0;
                     this.NumTarjeta_Aux_Empresa = "";
                     this.NumTelefono_Aux_Empresa = "";
                     this.CorreoElect_Aux_Empresa = "";
                     this.Identificacion_Aux_Empresa = 0;
                    this.CargaActualizadoDGV_Usuarios();

                }
                else
                {
                    MessageBox.Show("ACTUALIZACION DE DATOS SE HA CANCELADO",
                        "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.CONTENEDOR.SelectedIndex = 0;
                    this.NumTarjeta_Aux_Empresa = "";
                    this.NumTelefono_Aux_Empresa = "";
                    this.CorreoElect_Aux_Empresa = "";
                    this.Identificacion_Aux_Empresa = 0;
                    this.CargaActualizadoDGV_Usuarios();

                }







                this.LimpiaMapa_Empresa();


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

        private void btnCancelar_Empresa_Click(object sender, EventArgs e)
        {
            try
            {
                this.erpErrores.Clear();
                this.erpErrores2.Clear();
                this.erpErrores3.Clear();
                this.erpErrores4.Clear();
                this.erpErrores5.Clear();

                this.CONTENEDOR.SelectedIndex = 0;
                this.LimpiaMapa_Empresa();
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
                this.CONTENEDOR.SelectedIndex = 2;
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

        private void mapa_Empresa_MouseDoubleClick(object sender, MouseEventArgs e)
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

                this.CONTENEDOR.SelectedIndex = 2;
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
 

        private void Limpiar_Empresa()
        {
            try
            {
                this.txtNombre_Empresa.Text = "";
                this.txtIdentificacion_Empresa.Text = "";
                this.txtTelefono_Empresa.Text = "";

                this.txtCorreo_Empresa.Text = "";
                this.txtContrasenna1_Empresa.Text = "";
                this.txtContrasenna2_Empresa.Text = "";

                this.txtNumeroTarjeta_Empresa.Text = "";
                this.txtCVV_Empresa.Text = "";

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

        #endregion



        #region REGISTRO REPARTIDOR
        private void btnAtras_Repartidor_Click(object sender, EventArgs e)
        {
            try
            {
                this.CONTENEDOR.SelectedIndex = 0;
                this.Limpiar_Repartidor();
                this.CargaActualizadoDGV_Usuarios();

                this.erpErrores.Clear();
                this.erpErrores2.Clear();
                this.erpErrores3.Clear();
                this.erpErrores4.Clear();
                this.erpErrores5.Clear();
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

        private void btnUbicacion_Repartidor_Click(object sender, EventArgs e)
        {
            try
            {
                this.CONTENEDOR.SelectedIndex = 6;


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

        private void btnRegistrar_Repartidor_Click(object sender, EventArgs e)
        {
            try
            {
                //Validcaciones generales
                try
                {
                    this.erpErrores.Clear();

                    //Verifica que no esten vacios
                    if (string.IsNullOrEmpty(this.txtIdentificacion_Repartidor.Text))
                    {
                        this.erpErrores.SetError(this.txtIdentificacion_Repartidor, "Dato requerido");
                        return;
                    }
                    if (!this.txtTelefono_Repartidor.MaskFull)
                    {
                        this.erpErrores.SetError(this.txtTelefono_Repartidor, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtNombre_Repartidor.Text))
                    {
                        this.erpErrores.SetError(this.txtNombre_Repartidor, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtApellido_Repartidor.Text))
                    {
                        this.erpErrores.SetError(this.txtApellido_Repartidor, "Dato requerido");
                        return;
                    }

                    //Verifica si, corresponden realmente a los datos deseados
                    long numero = 0;
                    if (!long.TryParse(this.txtIdentificacion_Repartidor.Text, out numero)) //verifica que sea numero
                    {
                        this.erpErrores.SetError(this.txtIdentificacion_Repartidor, "Debe ser numerico unicamente");
                        return;
                    }
                    if (long.TryParse(this.txtNombre_Repartidor.Text, out numero))
                    {
                        this.erpErrores.SetError(this.txtNombre_Repartidor, "No debe ser numerico");
                        return;
                    }
                    if (long.TryParse(this.txtApellido_Repartidor.Text, out numero))
                    {
                        this.erpErrores.SetError(this.txtApellido_Repartidor, "No debe ser numerico");
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
                //validaciones Correo electronico y contrasenna
                try
                {
                    this.erpErrores2.Clear();

                    //Verifica que no esten vacios
                    if (string.IsNullOrEmpty(this.txtCorreoElectronico_Repartidor.Text))
                    {
                        this.erpErrores2.SetError(this.txtCorreoElectronico_Repartidor, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtContrasenna1_Repartidor.Text))
                    {
                        this.erpErrores2.SetError(this.txtContrasenna1_Repartidor, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtContrasenna2_Repartidor.Text))
                    {
                        this.erpErrores2.SetError(this.txtContrasenna2_Repartidor, "Dato requerido");
                        return;
                    }
                    if (this.txtContrasenna1_Repartidor.Text != txtContrasenna2_Repartidor.Text)
                    {
                        this.erpErrores2.SetError(this.chVerContrasenna_Repartidor, "Verificar Contrasenas");
                        return;
                    }
                    if (!this.MailIsValid(this.txtCorreoElectronico_Repartidor.Text))
                    {
                        this.erpErrores2.SetError(this.txtCorreoElectronico_Repartidor, "No es un correo electornico");
                        return;
                    }

                    //Verifica si, corresponden realmente a los datos deseados
                    int numero = 0;
                    if (int.TryParse(this.txtCorreoElectronico_Repartidor.Text, out numero))
                    {
                        this.erpErrores2.SetError(this.txtCorreoElectronico_Repartidor, "No debe ser unicamente numerico");
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
                //validacion tarjeta ingresada
                try
                {
                    this.erpErrores3.Clear();

                    //Verifica que no esten vacios
                    if (string.IsNullOrEmpty(this.txtNumeroTarjeta_Repartidor.Text))
                    {
                        this.erpErrores3.SetError(this.txtNumeroTarjeta_Repartidor, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtCVV_Repartidor.Text))
                    {
                        this.erpErrores3.SetError(this.txtCVV_Repartidor, "Dato requerido");
                        return;
                    }
                    if (this.rdbMasterCard_Repartidor.Checked == false && this.rdbVISA_Repartidor.Checked == false)
                    {
                        this.erpErrores3.SetError(this.label7, "Dato requerido");
                        return;
                    }

                    //Verifica si, corresponden realmente a los datos deseados ( NUMERICOS )
                    long numero = 0;
                    if (!long.TryParse(this.txtNumeroTarjeta_Repartidor.Text, out numero)) //verifica que sea numero
                    {
                        this.erpErrores3.SetError(this.txtNumeroTarjeta_Repartidor, "Debe ser numerico unicamente");
                        return;
                    }
                    if (!long.TryParse(this.txtCVV_Repartidor.Text, out numero)) //verifica que sea numero
                    {
                        this.erpErrores3.SetError(this.txtCVV_Repartidor, "Debe ser numerico unicamente");
                        return;
                    }

                    //VERIFICA SI LA TARJETA INTRODUCIDA ES VALIDA
                    string numeroTarjeta = this.txtNumeroTarjeta_Repartidor.Text;
                    string cvv = this.txtCVV_Repartidor.Text;
                    DateTime fechaVencimiento = this.txtVencimiento_Repartidor.Value;
                    Console.WriteLine(fechaVencimiento.ToString());

                    Tarjeta tarjeta = null;

                    if (this.rdbMasterCard_Repartidor.Checked)
                    {
                        tarjeta = new Tarjeta(numeroTarjeta, cvv, TipoTarjeta.MASTER_CARD, fechaVencimiento);
                    }
                    else if (this.rdbVISA_Repartidor.Checked)
                    {
                        tarjeta = new Tarjeta(numeroTarjeta, cvv, TipoTarjeta.VISA, fechaVencimiento);
                    }

                    if (tarjeta.validarFechaTarjeta() == false)
                    {
                        this.erpErrores3.SetError(this.txtVencimiento_Repartidor, "Fecha incorrecta");
                        return;
                    }
                    if (tarjeta.validarNumeroTarjeta() == false)
                    {
                        this.erpErrores3.SetError(this.txtNumeroTarjeta_Repartidor, "Numero incorrecto");
                        return;
                    }
                    if (tarjeta.validarTipoTarjeta() == false)
                    {
                        this.erpErrores3.SetError(this.txtNumeroTarjeta_Repartidor, "Numero incorrecto");
                        this.erpErrores3.SetError(this.rdbMasterCard_Repartidor, "Revisar tipo de tarjeta");
                        this.erpErrores3.SetError(this.rdbVISA_Repartidor, "Revisar tipo de tarjeta");
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
                //validacion vehiculo
                try
                {
                    this.erpErrores4.Clear();

                    //Verifica que no esten vacios
                    if (string.IsNullOrEmpty(this.txtMarcaVehiculo.Text))
                    {
                        this.erpErrores4.SetError(this.txtMarcaVehiculo, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtModeloVehiculo.Text))
                    {
                        this.erpErrores4.SetError(this.txtModeloVehiculo, "Dato requerido");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtColorVehiculo.Text))
                    {
                        this.erpErrores4.SetError(this.txtColorVehiculo, "Dato requerido");
                        return;
                    }
                    if (this.cbxTipoVehiculo.SelectedIndex == -1)
                    {
                        this.erpErrores4.SetError(this.cbxTipoVehiculo, "Dato requerido");
                        return;
                    }

                    //Verifica si, corresponden realmente a los datos deseados ( NUMERICOS )
                    long numero = 0;
                    if (long.TryParse(this.txtMarcaVehiculo.Text, out numero)) //verifica que no sea numero
                    {
                        this.erpErrores4.SetError(this.txtMarcaVehiculo, "No debe ser numerico");
                        return;
                    }
                    if (long.TryParse(this.txtColorVehiculo.Text, out numero)) //verifica que no sea numero
                    {
                        this.erpErrores4.SetError(this.txtColorVehiculo, "No debe ser numerico");
                        return;
                    }

                    if (cbxTipoVehiculo.SelectedIndex == 1 || cbxTipoVehiculo.SelectedIndex == 2)
                    {
                        if (string.IsNullOrEmpty(this.txtNumeroPlacaVehiculo.Text))
                        {
                            this.erpErrores4.SetError(this.txtColorVehiculo, "Dato requerido");
                            return;
                        }
                        if (!long.TryParse(this.txtNumeroPlacaVehiculo.Text, out numero)) //verifica que no sea numero
                        {
                            this.erpErrores4.SetError(this.txtNumeroPlacaVehiculo, "No debe ser numerico");
                            return;
                        }
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
                if (CorreoElect_Aux_Repartidor != this.txtCorreoElectronico_Repartidor.Text)
                {
                    if (UsuarioLN.VerificaExistencia_CorreoElectronico(this.txtCorreoElectronico_Repartidor.Text).Equals("1"))
                    {
                        MessageBox.Show("El correo ingresado esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (NumTelefono_Aux_Repartidor != this.txtTelefono_Repartidor.Text)
                {
                    if (UsuarioLN.VerificaExistencia_NumeroTelefono(this.txtTelefono_Repartidor.Text).Equals("1"))
                    {
                        MessageBox.Show("El numero de telefono ingresado esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (NumTarjeta_Aux_Repartidor != this.txtNumeroTarjeta_Repartidor.Text)
                {
                    if (UsuarioLN.PA_VerificaUsuario_Existencia_Tarjeta(this.txtNumeroTarjeta_Repartidor.Text).Equals("1"))
                    {
                        MessageBox.Show("La tarjeta ingresada esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (Identificacion_Aux_Repartidor != Convert.ToInt32(this.txtIdentificacion_Repartidor.Text))
                {
                    if (UsuarioLN.PA_VerificaUsuario_Existencia_Identificacion(Convert.ToInt32(this.txtIdentificacion_Repartidor.Text)).Equals("1"))
                    {
                        MessageBox.Show("La identificacion ingresada esta en uso actualmente",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (this.direccionRepartidor == null)
                {
                    MessageBox.Show("Favor ingresar una direccion primero",
                        "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Usuario user = FactoryUsuario.creaUsuario(TipoUsuario.REPARTIDOR);
                user.Nombre = this.txtNombre_Repartidor.Text;
                user.Identificacion = Convert.ToInt32(this.txtIdentificacion_Repartidor.Text);
                (user as Usuario_Repartidor).Apellidos = this.txtApellido_Repartidor.Text;
                user.NumeroTelefono = this.txtTelefono_Repartidor.Text;
                user.CorreoElectronico = this.txtCorreoElectronico_Repartidor.Text;
                user.Contrasenna = this.txtContrasenna2_Repartidor.Text;

                Tarjeta card = FactoryTarjeta.CreaTarjeta(this.rdbVISA_Repartidor.Checked ? TipoTarjeta.VISA : TipoTarjeta.MASTER_CARD);
                card.NumeroTarjeta = this.txtNumeroTarjeta_Repartidor.Text;
                card.CVV = this.txtCVV_Repartidor.Text;
                card.FechaVencimiento = this.txtVencimiento_Repartidor.Value;

                Direccion direction = direccionRepartidor;

                Transporte trans = null;

                if (this.cbxTipoVehiculo.SelectedIndex == 0)
                {
                    trans = FactoryTransporte.creaTransporte(TipoTransporte.Bicicleta);
                    trans.Marca = this.txtMarcaVehiculo.Text;
                    trans.Modelo = this.txtModeloVehiculo.Text;
                    trans.Color = this.txtColorVehiculo.Text;

                    user._Tarjeta = card;
                    user._Direccion = direction;
                    (user as Usuario_Repartidor)._Transporte = trans;

                    if (MessageBox.Show("DESEEA CONFIRMAR ESTA ACTUALIZACION", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        userDB_Access = new UsuarioLN();
                        userDB_Access.ActualizaUsuario_Repartidor(user, Identificacion_Aux_Repartidor);
                        MessageBox.Show("ACTUALIZACION DE DATOS HA SALIDO EXITOSAMENTE",
                             "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        log.Info("SE ACTUALIZO EXITOSAMENTE EL USUARIO [" + user.Nombre + "] DESDE EL MANTENIMIENTO DE ADMINISTRADOR");

                        this.CONTENEDOR.SelectedIndex = 0;
                        this.NumTarjeta_Aux_Repartidor = "";
                        this.NumTelefono_Aux_Repartidor = "";
                        this.CorreoElect_Aux_Repartidor = "";
                        this.Identificacion_Aux_Repartidor = 0;
                        this.CargaActualizadoDGV_Usuarios();

                    }

                    else
                    {
                        MessageBox.Show("ACTUALIZACION DE DATOS SE HA CANCELADO",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        this.CONTENEDOR.SelectedIndex = 0;
                        this.NumTarjeta_Aux_Repartidor = "";
                        this.NumTelefono_Aux_Repartidor = "";
                        this.CorreoElect_Aux_Repartidor = "";
                        this.Identificacion_Aux_Repartidor = 0;
                        this.CargaActualizadoDGV_Usuarios();

                    }
                }
                else if (this.cbxTipoVehiculo.SelectedIndex == 1)
                {
                    trans = FactoryTransporte.creaTransporte(TipoTransporte.Carro);
                    trans.Marca = this.txtMarcaVehiculo.Text;
                    trans.Modelo = this.txtModeloVehiculo.Text;
                    trans.Color = this.txtColorVehiculo.Text;
                    (trans as Transporte_Carro).NumeroPlaca = Convert.ToInt32(this.txtNumeroPlacaVehiculo.Text);
                    (trans as Transporte_Carro).EstaAsegurado = this.chEstaDiaVehiculo.Checked;

                    user._Tarjeta = card;
                    user._Direccion = direction;
                    (user as Usuario_Repartidor)._Transporte = trans;

                    if (MessageBox.Show("DESEEA CONFIRMAR ESTA ACTUALIZACION", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        userDB_Access = new UsuarioLN();
                        userDB_Access.ActualizaUsuario_Repartidor(user, Identificacion_Aux_Repartidor);
                        MessageBox.Show("ACTUALIZACION DE DATOS HA SALIDO EXITOSAMENTE",
                             "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        log.Info("SE ACTUALIZO EXITOSAMENTE EL USUARIO [" + user.Nombre + "] DESDE EL MANTENIMIENTO DE ADMINISTRADOR");

                        this.CONTENEDOR.SelectedIndex = 0;
                        this.NumTarjeta_Aux_Repartidor = "";
                        this.NumTelefono_Aux_Repartidor = "";
                        this.CorreoElect_Aux_Repartidor = "";
                        this.Identificacion_Aux_Repartidor = 0;
                        this.CargaActualizadoDGV_Usuarios();

                    }
                    else
                    {
                        MessageBox.Show("ACTUALIZACION DE DATOS SE HA CANCELADO",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        this.CONTENEDOR.SelectedIndex = 0;
                        this.NumTarjeta_Aux_Repartidor = "";
                        this.NumTelefono_Aux_Repartidor = "";
                        this.CorreoElect_Aux_Repartidor = "";
                        this.Identificacion_Aux_Repartidor = 0;
                        this.CargaActualizadoDGV_Usuarios();

                    }
                }
                else if (this.cbxTipoVehiculo.SelectedIndex == 2)
                {
                    trans = FactoryTransporte.creaTransporte(TipoTransporte.Moto);
                    trans.Marca = this.txtMarcaVehiculo.Text;
                    trans.Modelo = this.txtModeloVehiculo.Text;
                    trans.Color = this.txtColorVehiculo.Text;
                    (trans as Transporte_Motocicleta).NumeroPlaca = Convert.ToInt32(this.txtNumeroPlacaVehiculo.Text);
                    (trans as Transporte_Motocicleta).EstaAsegurado = this.chEstaDiaVehiculo.Checked;

                    user._Tarjeta = card;
                    user._Direccion = direction;
                    (user as Usuario_Repartidor)._Transporte = trans;

                    if (MessageBox.Show("DESEEA CONFIRMAR ESTA ACTUALIZACION", "INFORMACION", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        userDB_Access = new UsuarioLN();
                        userDB_Access.ActualizaUsuario_Repartidor(user, Identificacion_Aux_Repartidor);
                        MessageBox.Show("ACTUALIZACION DE DATOS HA SALIDO EXITOSAMENTE",
                             "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        log.Info("SE ACTUALIZO EXITOSAMENTE EL USUARIO [" + user.Nombre + "] DESDE EL MANTENIMIENTO DE ADMINISTRADOR");

                        this.CONTENEDOR.SelectedIndex = 0;
                        this.NumTarjeta_Aux_Repartidor = "";
                        this.NumTelefono_Aux_Repartidor = "";
                        this.CorreoElect_Aux_Repartidor = "";
                        this.Identificacion_Aux_Repartidor = 0;
                        this.CargaActualizadoDGV_Usuarios();

                    }
                    else
                    {
                        MessageBox.Show("ACTUALIZACION DE DATOS SE HA CANCELADO",
                            "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        this.CONTENEDOR.SelectedIndex = 0;
                        this.NumTarjeta_Aux_Repartidor = "";
                        this.NumTelefono_Aux_Repartidor = "";
                        this.CorreoElect_Aux_Repartidor = "";
                        this.Identificacion_Aux_Repartidor = 0;
                        this.CargaActualizadoDGV_Usuarios();

                    }
                }



                this.LimpiaMapa_Repartidor();
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

        private void chVerContrasenna_Repartidor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chVerContrasenna_Repartidor.Checked == true)
                {
                    txtContrasenna1_Repartidor.PasswordChar = '\0';
                    txtContrasenna1_Repartidor.UseSystemPasswordChar = false;

                    txtContrasenna2_Repartidor.PasswordChar = '\0';
                    txtContrasenna2_Repartidor.UseSystemPasswordChar = false;
                }
                else
                {
                    txtContrasenna1_Repartidor.PasswordChar = '•';
                    txtContrasenna1_Repartidor.UseSystemPasswordChar = true;

                    txtContrasenna2_Repartidor.PasswordChar = '•';
                    txtContrasenna2_Repartidor.UseSystemPasswordChar = true;
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

        private void btnCancelar_Repartidor_Click(object sender, EventArgs e)
        {
            try
            {
                this.CONTENEDOR.SelectedIndex = 0;
                this.LimpiaMapa_Repartidor();
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
            if (this.cbxTipoVehiculo.SelectedIndex == 1 || this.cbxTipoVehiculo.SelectedIndex == 2)
            {
                this.txtNumeroPlacaVehiculo.Enabled = true;
                this.chEstaDiaVehiculo.Enabled = true;
                this.txtNumeroPlacaVehiculo.Visible = true;
                this.chEstaDiaVehiculo.Visible = true;
                this.label52.Visible = true;

            }
            else
            {
                this.txtNumeroPlacaVehiculo.Enabled = false;
                this.chEstaDiaVehiculo.Enabled = false;
                this.txtNumeroPlacaVehiculo.Visible = false;
                this.chEstaDiaVehiculo.Visible = false;
                this.label52.Visible = false;
                this.txtNumeroPlacaVehiculo.Text = "";

            }
        }

        //PANEL DE UBICACION ! ! !
        private void btnAtras_Ubicacion_Repartidor_Click(object sender, EventArgs e)
        {
            try
            {
                this.CONTENEDOR.SelectedIndex = 3;
               // this.txtDescripcion_Repartidor.Text = "";
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

        private void mapa_Repartidor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //Obtiene la latitud y longitud de la posiscion dentro del mapa
                LatitudSeleccionada = mapa_Repartidor.FromLocalToLatLng(e.X, e.Y).Lat;
                LongitudSeleccionada = mapa_Repartidor.FromLocalToLatLng(e.X, e.Y).Lng;

                //mover el marcador, ah la posicion dada por el usuario
                marker_Repartidor.Position = new PointLatLng(LatitudSeleccionada, LongitudSeleccionada);
                marker_Repartidor.ToolTipText = string.Format("Ubicacion: \n Latitud:{0} \n Longitud:{1}", LatitudSeleccionada, LongitudSeleccionada);

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

        private void btnObtenerUbicacion_Repartidor_Click(object sender, EventArgs e)
        {
            try
            {
                //construye objeto de DIRECCION
                if (this.txtDescripcion_Repartidor.Text == "")
                {
                    MessageBox.Show("Favor agregar una descripcion de su ubicacion");
                    return;
                }

                this.direccionRepartidor = new Direccion();
                direccionRepartidor.Longitud = this.LongitudSeleccionada;
                direccionRepartidor.Latitud = this.LatitudSeleccionada;
                direccionRepartidor.DescripcionUbicacion = this.txtDescripcion_Repartidor.Text;

                this.CONTENEDOR.SelectedIndex = 3;
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

        private void btnLimpiarCampos_Ubicacion_Repartidor_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtDescripcion_Repartidor.Text = "";

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


        private void Limpiar_Repartidor()
        {
            try
            {
                this.txtNombre_Repartidor.Text = "";
                this.txtApellido_Repartidor.Text = "";
                this.txtIdentificacion_Repartidor.Text = "";
                this.txtTelefono_Repartidor.Text = "";

                this.txtCorreoElectronico_Repartidor.Text = "";
                this.txtContrasenna1_Repartidor.Text = "";
                this.txtContrasenna2_Repartidor.Text = "";

                this.txtNumeroTarjeta_Repartidor.Text = "";
                this.txtCVV_Repartidor.Text = "";

                this.txtMarcaVehiculo.Text = "";
                this.txtModeloVehiculo.Text = "";
                this.txtColorVehiculo.Text = "";
                this.txtNumeroPlacaVehiculo.Text = "";

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
