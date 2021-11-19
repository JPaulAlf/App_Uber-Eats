using Capa_Acceso_Datos;
using Capa_Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica_Negocios
{
    /// <summary>
    /// Clase que obtiene acceso a la base de datos sobre Articulos, a tarevez de la clase ArticuloBD
    /// </summary>
    public class ArticuloLN
    {
        /// <summary>
        /// registra un cupon
        /// </summary>
        /// <param Articulo="pArticulo"></param>
        /// <param Identificaion de comercio="pIdetificacionUsuarioComercio"></param>
        public void RegistroArticulo_Cupon(Articulo pArticulo, int pIdetificacionUsuarioComercio)
        {
            ArticuloDB user = new ArticuloDB();
            user.RegistroArticulo_Cupon(pArticulo, pIdetificacionUsuarioComercio);
        }
        /// <summary>
        /// Obtiene un cupon
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <param identificacion de usuario="pIdentificacionUsuario"></param>
        /// <returns>Articulo</returns>
        public Articulo ObtenerArticulo_Cupon(string pIdentificacion, int pIdentificacionUsuario)
        {
            ArticuloDB user = new ArticuloDB();
            return user.ObtenerArticulo_Cupon(pIdentificacion, pIdentificacionUsuario);
        }
        /// <summary>
        /// Obtiene un cupon sin filtro
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <param identificacion de usuario="pIdentificacionUsuario"></param>
        /// <returns>Articulo</returns>
        public Articulo ObtenerArticulo_Cupon_SinFiltro(string pIdentificacion, int pIdentificacionUsuario)
        {
            ArticuloDB user = new ArticuloDB();
            return user.ObtenerArticulo_Cupon_SinFiltro(pIdentificacion, pIdentificacionUsuario);
        }
        /// <summary>
        /// Actiualiza un cupon
        /// </summary>
        /// <param Articulo="pArticulo"></param>
        /// <param Identificacion comercio="pIdetificacionUsuarioComercio"></param>
        /// <param identificacion orignal del producto="pIdentificacionOriginalProducto"></param>
        public void ActualizaArticulo_Cupon(Articulo pArticulo, int pIdetificacionUsuarioComercio, string pIdentificacionOriginalProducto)
        {
            ArticuloDB user = new ArticuloDB();
            user.ActualizaArticulo_Cupon(pArticulo, pIdetificacionUsuarioComercio, pIdentificacionOriginalProducto);
        }




        /// <summary>
        /// Registor usuario
        /// </summary>
        /// <param Articulo="pArticulo"></param>
        /// <param Identificacion del negocio="pIdetificacionUsuarioComercio"></param>
        public void RegistroArticulo_Producto(Articulo pArticulo, int pIdetificacionUsuarioComercio)
        {
            ArticuloDB user = new ArticuloDB();
            user.RegistroArticulo_Producto(pArticulo, pIdetificacionUsuarioComercio);
        }
        /// <summary>
        /// Obtiene producto
        /// </summary>
        /// <param Identificacion="pIdentificacion"></param>
        /// <param Identificacion="pIdentificacionUsuario"></param>
        /// <returns>Articulo</returns>
        public Articulo ObtenerArticulo_Producto(string pIdentificacion, int pIdentificacionUsuario)
        {
            ArticuloDB user = new ArticuloDB();
            return user.ObtenerArticulo_Producto(pIdentificacion, pIdentificacionUsuario);
        }
        /// <summary>
        /// Obtiene producto sin filtro
        /// </summary>
        /// <param Identificacion="pIdentificacion"></param>
        /// <param Identificacion del usuario="pIdentificacionUsuario"></param>
        /// <returns>Articulo</returns>
        public Articulo ObtenerArticulo_Producto_SinFiltro(string pIdentificacion, int pIdentificacionUsuario)
        {
            ArticuloDB user = new ArticuloDB();
            return user.ObtenerArticulo_Producto_SinFiltro(pIdentificacion, pIdentificacionUsuario);
        }
        /// <summary>
        /// Actualiza el producto
        /// </summary>
        /// <param Articulo="pArticulo"></param>
        /// <param Identificacion del comercio="pIdetificacionUsuarioComercio"></param>
        /// <param Identificaicon orifinal del producto="pIdentificacionOriginalProducto"></param>
        public void ActualizaArticulo_Producto(Articulo pArticulo, int pIdetificacionUsuarioComercio, string pIdentificacionOriginalProducto)
        {
            ArticuloDB user = new ArticuloDB();
            user.ActualizaArticulo_Producto(pArticulo, pIdetificacionUsuarioComercio, pIdentificacionOriginalProducto);
        }



        /// <summary>
        /// Desactiva Articulo
        /// </summary>
        /// <param Identificacion="pIdentificacion"></param>
        public static void EstadoArticulo_Desactiva(string pIdentificacion)
        {
            ArticuloDB.EstadoArticulo_Desactiva(pIdentificacion);
        }
        /// <summary>
        /// Activa articulo
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        public static void EstadoArticulo_Activa(string pIdentificacion)
        {
            ArticuloDB.EstadoArticulo_Activa(pIdentificacion);

        }
        /// <summary>
        /// Verifica estado del articulo
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <returns>string</returns>
        public static string PA_VerificaArticulo_Estado(string pIdentificacion)
        {
            return ArticuloDB.PA_VerificaArticulo_Estado(pIdentificacion);
        }



        //1==Si //// -1==NO
        /// <summary>
        /// Verifica existencia de la identificacion
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <returns>string</returns>
        public static string PA_VerificaArticulo_Existencia_Identificacion(string pIdentificacion)
        {
            return ArticuloDB.PA_VerificaArticulo_Existencia_Identificacion(pIdentificacion);
        }
        /// <summary>
        /// verifica existencia de la identificacion sin filtro
        /// </summary>
        /// <param Identifiacion="pIdentificacion"></param>
        /// <returns>string</returns>
        public static string PA_VerificaArticulo_Existencia_Identificacion_SinFiltro(string pIdentificacion)
        {
            return ArticuloDB.PA_VerificaArticulo_Existencia_Identificacion_SinFiltro(pIdentificacion);

        }


        /// <summary>
        /// retorna lista de productos sin filtro
        /// </summary>
        /// <param Usuario="user"></param>
        /// <returns>List<Articulo></returns>
        public List<Articulo> ObtenerListaProductos_SinFiltro(Usuario user)
        {
            ArticuloDB userA = new ArticuloDB();
            return userA.ObtenerListaProductos_SinFiltro(user);
        }
        /// <summary>
        /// Retorna lista de cupones sin filtro
        /// </summary>
        /// <param Usuario="user"></param>
        /// <returns>List<Articulo></returns>
        public List<Articulo> ObtenerListaCupones_SinFiltro(Usuario user)
        {
            ArticuloDB userA = new ArticuloDB();
            return userA.ObtenerListaCupones_SinFiltro(user);
        }

        /// <summary>
        /// retorna lista de productos 
        /// </summary>
        /// <param Usuario="user"></param>
        /// <returns>List<Articulo></returns>
        public List<Articulo> ObtenerListaProductos(Usuario user)
        {
            ArticuloDB userA = new ArticuloDB();
            return userA.ObtenerListaProductos(user);
        }
        /// <summary>
        /// retorna lista de cupones 
        /// </summary>
        /// <param Usuario="user"></param>
        /// <returns>List<Articulo></returns>
        public List<Articulo> ObtenerListaCupones(Usuario user)
        {
            ArticuloDB userA = new ArticuloDB();
            return userA.ObtenerListaCupones(user);
        }



        /// <summary>
        /// Retorna la lista de articulos que se encuentran en una orden
        /// </summary>
        /// <param Numero de orden="pIdOrden"></param>
        /// <returns></returns>
        public List<Articulo> ObtenerListaProductos_OrdenPagada(int pIdOrden)
        {
            ArticuloDB userA = new ArticuloDB();
            return userA.ObtenerListaProductos_OrdenPagada(pIdOrden);
        }



    }
}
