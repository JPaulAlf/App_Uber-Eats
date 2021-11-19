using Capa_Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Gestor
{
    /// <summary>
    /// Clase Gestor_Factura, se encarga de  obtener los metodos de Factura
    /// </summary>
  public class Gestor_Factura
    {

        /// <summary> oFactura </summary>
        /// <value> instancia de Factura </value>
        private Factura oFactura = null;

        /// <summary>
        /// Constructor de clase, que recibe
        /// Factura, para asi construir el objeto oFactura
        /// </summary>
        public Gestor_Factura()
        {
            this.oFactura = new Factura();
        }


        #region METODOS
        /// <summary>
        /// Metodo que obtiene AsignaCliente, 
        /// asigna el Cliente
        /// </summary>
        /// <returns>void</returns>
        public void AsignaCliente(Usuario pCliente)
        {
            oFactura.AsignaCliente(pCliente);
        }

        /// <summary>
        /// Metodo que obtiene AsignaCliente, 
        /// asigna el Pago
        /// </summary>
        /// <returns>void</returns>
        public void AsignaPagoCliente(Pago pPago)
        {
            oFactura.AsignaPagoCliente(pPago);
        }

        /// <summary>
        /// Metodo que obtiene AsignaCliente, 
        /// asigna el Comercio
        /// </summary>
        /// <returns>void</returns>
        public void AsignaComercio(Usuario pComercio)
        {
            oFactura.AsignaComercio(pComercio);
        }

        /// <summary>
        /// Metodo que devuelve la instancia de factura
        /// </summary>
        /// <returns>Factura</returns>
        public Factura GetInstanceFactura()
        {
            return oFactura;
        }


        /// <summary>
        /// Metodo que obtieneCalculaMonto_Total,
        /// calcula el total de la factura
        /// </summary>
        /// <returns>double</returns>
        public double CalculaMonto_Total()
        {
            return oFactura.CalculaMonto_Total();
        }

        /// <summary>
        /// Metodo CalculaMonto_Total_Dolares, calcula el total de la factura en dolares
        /// </summary>
        /// <returns>double</returns>
        public double CalculaMonto_Total_Dolares()
        {
            return oFactura.CalculaMonto_Total_Dolares();
        }

        /// <summary>
        /// Metodo que obtiene CalculaMonto_Adicionales, 
        /// calcula el total de dinero
        /// por los adicionales
        /// </summary>
        /// <returns>double</returns>
        public double CalculaMonto_Adicionales()
        {
            return oFactura.CalculaMonto_Cupones();
        }

        /// <summary>
        /// Metodo que obtiene CalculaMonto_Productos, 
        /// calcula el total de dinero
        /// por los productos
        /// </summary>
        /// <returns>double</returns>
        public double CalculaMonto_Productos()
        {
            return oFactura.CalculaMonto_Productos();
        }

        /// <summary>
        /// Metodo que obtiene Calcula_IVA
        /// </summary>
        /// <returns>double</returns>
        public double Calcula_IVA()
        {
            return oFactura.Calcula_IVA();
        }

        /// <summary>
        /// Metodo Calcula_SubTotal, calcula monto sin IVA
        /// </summary>
        /// <returns>double</returns>
        public double Calcula_SubTotal()
        {
            return oFactura.Calcula_SubTotal();
        }

        /// <summary>
        /// Metodo Calcula_Envio, calcula coste del envio
        /// </summary>
        /// <returns>double</returns>
        public double Calcula_Envio()
        {
            return oFactura.Calcula_Envio();
        }
        



        /// <summary>
        /// Metodo que obtiene el XML de Factura
        /// </summary>
        /// <returns>string</returns>
        public string ObtenerXML()
        {
            return oFactura.ObtenerXML();
        }

        /// <summary>
        /// Metodo que obtiene el PDF de Factura
        /// </summary>
        /// <returns>string</returns>
        public void ObtenerPDF()
        {
            oFactura.ObtenerPDF();
        }

        /// <summary>
        /// Metodo que genera el PDF de Factura, y lo guarda en la ruta especificada por el usuario
        /// </summary>
        /// <returns>void</returns>
        public void ObtenerPDF_GuardadoEnRutaSeleccionada(string pRuta)
        {
            oFactura.ObtenerPDF_GuardadoEnRutaSeleccionada(pRuta);
        }

        #endregion

    }
}
