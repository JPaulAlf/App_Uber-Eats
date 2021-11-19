using Capa_Acceso_Datos;
using Capa_Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica_Negocios
{
    /// <summary>
    /// Clase UsuarioLN, se encarga de  obtener los PA atraves de UsuarioBD
    /// </summary>
    public class UsuarioLN
    {


        #region USUARIO CLIENTE
        /// <summary>
        /// Registra el usuario en la Base de datos
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        public void RegistroUsuario_Cliente(Usuario pUsuario)
        {
            if (pUsuario == null)
                throw new ApplicationException("No existe un usuario");

            UsuarioDB user = new UsuarioDB();
            user.RegistroUsuario_Cliente(pUsuario);
        }
        /// <summary>
        /// Obtiene el usuario de la base de datos
        /// </summary>
        /// <param Correo Electronico="pCorreoElectronico"></param>
        /// <param Contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Cliente(string pCorreoElectronico, string pContrasenna)
        {
            if (pCorreoElectronico.Length == 0)
                throw new ApplicationException("El correo es requerido");
            if (pContrasenna.Length == 0)
                throw new ApplicationException("La contrasenna es requerida");

            UsuarioDB user = new UsuarioDB();
            return user.ObtenerUsuario_Cliente(pCorreoElectronico, pContrasenna);
        }
        /// <summary>
        /// Actualiza el usuario
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        /// <param Identificacion Original="pIDentificacionOriginal"></param>
        public void ActualizaUsuario_Cliente(Usuario pUsuario, int pIDentificacionOriginal)
        {
            if (pUsuario == null)
                throw new ApplicationException("No existe un usuario");

            UsuarioDB user = new UsuarioDB();
            user.ActualizaUsuario_Cliente(pUsuario, pIDentificacionOriginal);
        }
        #endregion



        #region USUARIO REPARTIDOR
        /// <summary>
        /// Registra el usuario en la base de datos
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        public void RegistroUsuario_Repartidor_Bicicleta(Usuario pUsuario)
        {
            if (pUsuario == null)
                throw new ApplicationException("No existe un usuario");

            UsuarioDB user = new UsuarioDB();
            user.RegistroUsuario_Repartidor_Bicicleta(pUsuario);
        }
        /// <summary>
        /// Registra el usuari en la base de datos
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        public void RegistroUsuario_Repartidor_MotorVehiculo(Usuario pUsuario)
        {
            if (pUsuario == null)
                throw new ApplicationException("No existe un usuario");

            UsuarioDB user = new UsuarioDB();
            user.RegistroUsuario_Repartidor_MotorVehiculo(pUsuario);
        }
        /// <summary>
        /// Obtiene el usuario de la base de datos
        /// </summary>
        /// <param Correo Electornico="pCorreoElectronico"></param>
        /// <param Contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Repartidor(string pCorreoElectronico, string pContrasenna)
        {

            if (pCorreoElectronico.Length == 0)
                throw new ApplicationException("El correo es requerido");
            if (pContrasenna.Length == 0)
                throw new ApplicationException("La contrasenna es requerida");

            UsuarioDB user = new UsuarioDB();
            return user.ObtenerUsuario_Repartidor(pCorreoElectronico, pContrasenna);
        }
        /// <summary>
        /// Actualiza el usuario
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        /// <param Identificacion="pIDentificacionOriginal"></param>
        public void ActualizaUsuario_Repartidor(Usuario pUsuario, int pIDentificacionOriginal)
        {

            if (pUsuario == null)
                throw new ApplicationException("No existe un usuario");

            UsuarioDB user = new UsuarioDB();
            user.ActualizaUsuario_Repartidor(pUsuario, pIDentificacionOriginal);
        }

        #endregion



        #region USUARIO COMERCIO
        /// <summary>
        /// Registra el usuario en la base de datos
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        public void RegistroUsuario_Comercio(Usuario pUsuario)
        {
            if (pUsuario == null)
                throw new ApplicationException("No existe un usuario");

            UsuarioDB user = new UsuarioDB();
            user.RegistroUsuario_Comercio(pUsuario);
        }
        /// <summary>
        /// Obtiene el usuario de la base de datos
        /// </summary>
        /// <param Correo electronico="pCorreoElectronico"></param>
        /// <param Contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Comercio(string pCorreoElectronico, string pContrasenna)
        {
            if (pCorreoElectronico.Length == 0)
                throw new ApplicationException("El correo es requerido");
            if (pContrasenna.Length == 0)
                throw new ApplicationException("La contrasenna es requerida");

            UsuarioDB user = new UsuarioDB();
            return user.ObtenerUsuario_Comercio(pCorreoElectronico, pContrasenna);
        }
        /// <summary>
        /// Obtiene la calificacion del negocio
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Comercio_Calificacion(Usuario pUsuario)
        {
            if (pUsuario == null)
                throw new ApplicationException("No existe un usuario");

            UsuarioDB user = new UsuarioDB();
            return user.ObtenerUsuario_Comercio_Calificacion(pUsuario);
        }
        /// <summary>
        /// Actualiza usuario en la base de datos
        /// </summary>
        /// <param usuario="pUsuario"></param>
        /// <param Identificacion Original="pIDentificacionOriginal"></param>
        public void ActualizaUsuario_Comercio(Usuario pUsuario, int pIDentificacionOriginal)
        {
            if (pUsuario == null)
                throw new ApplicationException("No existe un usuario");

            UsuarioDB user = new UsuarioDB();
            user.ActualizaUsuario_Comercio(pUsuario, pIDentificacionOriginal);
        }

        #endregion


        /// <summary>
        /// Obtiene el usuario de la base de datos
        /// </summary>
        /// <param Correo electronico="pCorreoElectronico"></param>
        /// <param Contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Administrador(string pCorreoElectronico, string pContrasenna)
        {
            if (pCorreoElectronico.Length == 0)
                throw new ApplicationException("El correo es requerido");
            if (pContrasenna.Length == 0)
                throw new ApplicationException("La contrasenna es requerida");

            UsuarioDB user = new UsuarioDB();
            return user.ObtenerUsuario_Administrador(pCorreoElectronico, pContrasenna);
        }



        /// <summary>
        /// Obtiene el tipo de usuario
        /// </summary>
        /// <param Correo electronico="pCorreoElectronico"></param>
        /// <param Contrasenna="pContrasenna"></param>
        /// <returns>string</returns>
        public static string ObtenerTipoUsuario_LogIn(string pCorreoElectronico, string pContrasenna)
        {
            return UsuarioDB.ObtenerTipoUsuario_LogIn(pCorreoElectronico, pContrasenna);
        }
        /// <summary>
        /// Desactiva el usuario
        /// </summary>
        /// <param Correo electronico="pCorreoElectronico"></param>
        /// <param Contrasenna="pContrasenna"></param>
        public static void EstadoUsuario_Desactiva(string pCorreoElectronico, string pContrasenna)
        {
            UsuarioDB.EstadoUsuario_Desactiva(pCorreoElectronico, pContrasenna);
        }
        /// <summary>
        /// Activa el usuario
        /// </summary>
        /// <param correo electronico="pCorreoElectronico"></param>
        /// <param contrasennna="pContrasenna"></param>
        public static void EstadoUsuario_Activa(string pCorreoElectronico, string pContrasenna)
        {
            UsuarioDB.EstadoUsuario_Activa(pCorreoElectronico, pContrasenna);
        }
        /// <summary>
        /// Desactiva cuenta del usuario
        /// </summary>
        /// <param IdentificacionOriginal="pIdentificacionOriginal"></param>
        public static void EstadoUsuario_Desactiva_Cuenta(int pIdentificacionOriginal)
        {
            UsuarioDB.EstadoUsuario_Desactiva_Cuenta(pIdentificacionOriginal);
        }


        /// <summary>
        /// verifica existencia de numero de telefono
        /// </summary>
        /// <param Numero de telefono="pNumeroTelefono"></param>
        /// <returns>string</returns>
        public static string VerificaExistencia_NumeroTelefono(string pNumeroTelefono)
        {
            return UsuarioDB.VerificaExistencia_NumeroTelefono(pNumeroTelefono);

        }
        /// <summary>
        /// Verifica existencia de Correo electronico
        /// </summary>
        /// <param Correo Electronico="pCorreoElectronico"></param>
        /// <returns>string</returns>
        public static string VerificaExistencia_CorreoElectronico(string pCorreoElectronico)
        {
            return UsuarioDB.VerificaExistencia_CorreoElectronico(pCorreoElectronico);
        }
        /// <summary>
        /// Verififca existenia de tarjeta
        /// </summary>
        /// <param Numero de tarjeta="pNumeroTarjeta"></param>
        /// <returns><string/returns>
        public static string PA_VerificaUsuario_Existencia_Tarjeta(string pNumeroTarjeta)
        {
            return UsuarioDB.PA_VerificaUsuario_Existencia_Tarjeta(pNumeroTarjeta);
        }
        /// <summary>
        /// Verifica existencia de identificacion
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <returns>string</returns>
        public static string PA_VerificaUsuario_Existencia_Identificacion(int pIdentificacion)
        {
            return UsuarioDB.PA_VerificaUsuario_Existencia_Identificacion(pIdentificacion);
        }
        /// <summary>
        /// Verifica estado del usuario Activo/Inactivo
        /// </summary>
        /// <param correo electronico="pCorreoElectronico"></param>
        /// <param Contrasenna="pContrasenna"></param>
        /// <returns>string</returns>
        public static string PA_VerificaUsuario_Estado_Usuario(string pCorreoElectronico, string pContrasenna)
        {
            return UsuarioDB.PA_VerificaUsuario_Estado_Usuario(pCorreoElectronico, pContrasenna);
        }


        /// <summary>
        /// Devuelve la lisat de usuarios dentro de la aplicacion
        /// </summary>
        /// <returns> List<Usuario></returns>
        public static List<Usuario> ObtenerListaUsuariosApp()
        {
            UsuarioDB user = new UsuarioDB();
            return user.ObtenerListaUsuariosApp();

        }
        /// <summary>
        /// Retorna la lista de comercios dentro de la aplicacion
        /// </summary>
        /// <returns> List<Usuario></returns>
        public static List<Usuario> ObtenerListaUsuariosApp_Comercios()
        {
            UsuarioDB user = new UsuarioDB();
            return user.ObtenerListaUsuariosApp_Comercios();
        }

        /// <summary>
        /// Retorna la lista de comercios dentro de la aplicacion
        /// </summary>
        /// <returns> List<Usuario></returns>
        public List<Usuario> ObtenerListaUsuariosApp_Comercios_SinFiltro()
        {
            UsuarioDB user = new UsuarioDB();
            return user.ObtenerListaUsuariosApp_Comercios_SinFiltro();
        }

        /// <summary>
        /// Obtiene el tipo de usuario sin filtracion
        /// </summary>
        /// <param Correo electornico="pCorreoElectronico"></param>
        /// <param contrasenna="pContrasenna"></param>
        /// <returns>string</returns>
        public static string ObtenerTipoUsuario_LogIn_SinFiltro(string pCorreoElectronico, string pContrasenna)
        {
            UsuarioDB user = new UsuarioDB();
            return user.ObtenerTipoUsuario_LogIn_SinFiltro(pCorreoElectronico, pContrasenna);
        }
        /// <summary>
        /// Obtiene el usuario repartidor sin filtro
        /// </summary>
        /// <param Correo electornico="pCorreoElectronico"></param>
        /// <param contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Repartidor_SinFiltro(string pCorreoElectronico, string pContrasenna)
        {
            UsuarioDB user = new UsuarioDB();
            return user.ObtenerUsuario_Repartidor_SinFiltro(pCorreoElectronico, pContrasenna);
        }
        /// <summary>
        /// Obtiene el usuario repartidor sin filtro
        /// </summary>
        /// <param Correo electornico="pCorreoElectronico"></param>
        /// <param contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Cliente_SinFiltro(string pCorreoElectronico, string pContrasenna)
        {
            UsuarioDB user = new UsuarioDB();
            return user.ObtenerUsuario_Cliente_SinFiltro(pCorreoElectronico, pContrasenna);
        }
        /// <summary>
        /// Obtiene el usuario comercio sin filtro
        /// </summary>
        /// <param Correo electornico="pCorreoElectronico"></param>
        /// <param contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Comercio_SinFiltro(string pCorreoElectronico, string pContrasenna)
        {
            UsuarioDB user = new UsuarioDB();
            return user.ObtenerUsuario_Comercio_SinFiltro(pCorreoElectronico, pContrasenna);
        }


        /// <summary>
        /// Verifica el correo
        /// </summary>
        /// <param correo electronico="pCorreoElectronico"></param>
        /// <returns></returns>
        public static string PA_VerificaUsuario_Correo(string pCorreoElectronico)
        {
            return UsuarioDB.PA_VerificaUsuario_Correo(pCorreoElectronico);
        }
        /// <summary>
        /// Actualiza contrasenna de usuario
        /// </summary>
        /// <param correo electornico="pCorreoElectronico"></param>
        /// <param contrasenna="pContrasenna"></param>
        public void ActualizaUsuario_Contrasenna(string pCorreoElectronico, string pContrasenna)
        {
            UsuarioDB user = new UsuarioDB();
            user.ActualizaUsuario_Contrasenna(pCorreoElectronico, pContrasenna);
        }



    }
}
