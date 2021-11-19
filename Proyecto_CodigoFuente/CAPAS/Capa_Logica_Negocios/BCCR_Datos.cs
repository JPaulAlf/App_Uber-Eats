using Capa_Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica_Negocios
{
    /// <summary>
    /// Clase que obtiene datos del BCCR atraves de BCCR_Moneda
    /// </summary>
    public class BCCR_Datos
    {
        /// <summary>
        /// Obtiene indicadores de la venta del dolar
        /// </summary>
        /// <returns>double</returns>
        public double ObtenerIndicadoresEconomicos_VentaDolar()
        {
            BCCR_Moneda moneda = new BCCR_Moneda();
            return moneda.ObtenerIndicadoresEconomicos_VentaDolar();
        }
        /// <summary>
        /// Obtiene indicadores de la fecha de actualizacion
        /// </summary>
        /// <returns>datetime</returns>
        public DateTime ObtenerIndicadoresEconomicos_FechaActualizacion()
        {
            BCCR_Moneda moneda = new BCCR_Moneda();
            return moneda.ObtenerIndicadoresEconomicos_FechaActualizacion();
        }

    }
}
