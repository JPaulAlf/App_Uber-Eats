using Capa_Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Facade
{
    /// <summary>
    /// Clase FacadePago, se encarga de realizar calculos para generar el pago
    /// </summary>
    public class FacadePago
    {
        Pago pPago = null;

        /// <summary>
        /// Constructor de clase, recibiendo parametros
        /// debe ser asi para inicalizar el Pago
        /// </summary>
        public FacadePago(Pago oPago)
        {
            pPago = oPago;
        }


        /// <summary>
        /// Metodo CalculaCosto, se encarga de calcular el costo del pago
        /// </summary>
        /// <returns>double</returns>
        public double CalculaCosto()
        {
            return 0;
        }


        /// <summary>
        /// Metodo GenerarXML, se encarga de la construccion del XML
        /// </summary>
        /// <returns>string</returns>
        public string GenerarXML()
        {
            return "";
        }
    }
}
