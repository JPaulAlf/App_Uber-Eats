using Capa_Acceso_Datos;
using Capa_Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica_Negocios
{
    /// <summary>
    /// Clase que se encarga de establecer conexion con la bsse de datos y crear la factura
    /// </summary>
    public class FacturacionLN
    {

        /// <summary>
        /// Ingresa una factura nueva
        /// </summary>
        /// <param Factura="pFactura"></param>
        /// <param Cifrado del XML="pCifradoXML"></param>
        public void IngresaFacturaNueva(Factura pFactura, string pCifradoXML)
        {
            FacturacionDB fact = new FacturacionDB();
            fact.IngresaFacturaNueva(pFactura, pCifradoXML);
        }
        /// <summary>
        /// Ingresa una factura el usuario
        /// </summary>
        /// <param usuario="pUsuario"></param>
        public void IngresaFacturaUsuario(Usuario pUsuario)
        {
            FacturacionDB fact = new FacturacionDB();
            fact.IngresaFacturaUsuario(pUsuario);
        }
        /// <summary>
        /// Ingresa articulos a la factura
        /// </summary>
        /// <param Articulo="pArticulo"></param>
        public void IngresaFacturaArticulo(Articulo pArticulo)
        {
            FacturacionDB fact = new FacturacionDB();
            fact.IngresaFacturaArticulo(pArticulo);
        }

        /// <summary>
        ///Crea la consulta para mostrar las ordenes efectuadas por el usuario 
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <returns>DataTable</returns>
        public DataTable RetornarnaOrdenesDisponibles(int pIdentificacion)
        {
            FacturacionDB fact = new FacturacionDB();
           return fact.RetornarnaOrdenesDisponibles(pIdentificacion);
        }

        /// <summary>
        ///Crea la consulta para mostrar los sujetos involucrrados
        ///en la compras efectuadas por el usuario 
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <returns>DataTable</returns>
        public DataTable RetornarnaSujetosDisponiblesCalificacion(int pIdentificacion)
        {
            FacturacionDB fact = new FacturacionDB();
            return fact.RetornarnaSujetosDisponiblesCalificacion(pIdentificacion);
        }

        /// <summary>
        /// Ingresa una calificacion al usuario
        /// </summary>
        /// <param identificacion Usuario="pIdentificacionU"></param>
        /// <param nuemero de teelfono empresa="pNumeroTelefonoC"></param>
        /// <param Calificacion="pNuevaCalificacion"></param>
        /// <param Comentario="pComment"></param>
        public void IngresaCalificacion(int pIdentificacionU, string pNumeroTelefonoC, int pNuevaCalificacion, string pComment)
        {
            FacturacionDB fact = new FacturacionDB();
            fact.IngresaCalificacion(pIdentificacionU, pNumeroTelefonoC, pNuevaCalificacion, pComment);
        }


        /// <summary>
        ///Crea la consulta para mostrar losordenes nuevas por aceptar
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <returns>DataTable</returns>
        public DataTable RetornaOrdenesDisponiblesParaAceptar(int pIdentificacion)
        {
            FacturacionDB fact = new FacturacionDB();
            return fact.RetornaOrdenesDisponiblesParaAceptar(pIdentificacion);
        }

        /// <summary>
        /// Acepta el numero de orden
        /// </summary>
        /// <param Numero de orden="pIDOrden"></param>
        public void ActualizaEstaAceptado(int pIDOrden)
        {
            FacturacionDB fact = new FacturacionDB();
            fact.ActualizaEstaAceptado(pIDOrden);
        }


        /// <summary>
        /// Retorna las ordenes aceptadas
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable RetornaOrdenesAceptadas()
        {
            FacturacionDB fact = new FacturacionDB();
            return fact.RetornaOrdenesAceptadas();
        }

        /// <summary>
        /// Retorna el correo y contrasenna del usuario de la orden
        /// </summary>
        /// <param Numero de orden="pOrden"></param>
        /// <param Numero de identificacion="pIdentificacion"></param>
        /// <returns> List<string> </returns>
        public List<string> AceptarOrdenEntrega(int pOrden,int pIdentificacion)
        {
            FacturacionDB fact = new FacturacionDB();
            return fact.AceptarOrdenEntrega(pOrden, pIdentificacion);
        }

        /// <summary>
        /// Retorna el correo y contrasenna del usuario de la orden
        /// </summary>
        /// <param Numero de orden="pOrden"></param>
        /// <returns> List<string> </returns>
        public List<string> DevuelveComercioOrden(int pOrden)
        {
            FacturacionDB fact = new FacturacionDB();
            return fact.DevuelveComercioOrden(pOrden);
        }

        /// <summary>
        /// Marca la orden como entregada
        /// </summary>
        /// <param Numero de Orden="pIDOrden"></param>
        public void OrdenEntregada(int pIDOrden)
        {
            FacturacionDB fact = new FacturacionDB();
            fact.OrdenEntregada(pIDOrden);
        }

    }
}
