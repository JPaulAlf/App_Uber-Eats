using Capa_Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Acceso_Datos
{
    /// <summary>
    /// Clase que obtiene datos del BCCR
    /// </summary>
   public class BCCR_Moneda
    {
        /// <summary>
        /// Hace la conexion al servicio web del BCCR
        /// </summary>
       public cr.fi.bccr.gee.wsindicadoreseconomicos cliente = new cr.fi.bccr.gee.wsindicadoreseconomicos();
       
        /// <summary>
        /// Obtiene indicadores de la venta del dolar
        /// </summary>
        /// <returns>double</returns>
       public double ObtenerIndicadoresEconomicos_VentaDolar()
        {
            DataSet data= cliente.ObtenerIndicadoresEconomicos(
                "317", 
                DateTime.Now.ToString("dd/MM/yyyy"),
                DateTime.Now.ToString("dd/MM/yyyy"),
                "John P. Alfaro",
                "N",
                "johnpaul899@hotmail.com",
                "U2ANL22FHU"
                );

            return Convert.ToDouble( data.Tables[0].Rows[0].ItemArray[2].ToString() );

        }
        /// <summary>
        /// Obtiene indicadores de la fecha de actualizacion
        /// </summary>
        /// <returns>datetime</returns>
        public DateTime ObtenerIndicadoresEconomicos_FechaActualizacion()
        {
            DataSet data = cliente.ObtenerIndicadoresEconomicos(
                "317",
                DateTime.Now.ToString("dd/MM/yyyy"),
                DateTime.Now.ToString("dd/MM/yyyy"),
                "John P. Alfaro",
                "N",
                "johnpaul899@hotmail.com",
                "U2ANL22FHU"
                );

            return Convert.ToDateTime(data.Tables[0].Rows[0].ItemArray[1].ToString());

        }



    }
}
