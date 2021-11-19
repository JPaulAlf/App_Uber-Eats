using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Clases
{

    /// <summary>
    ///Clase Articulo_Cupon, la cual hereda de la clase Articulo 
    ///todos sus metodos y propiedades
    /// </summary>
    public class Articulo_Cupon :Articulo
    {
        #region PROPIEDADES
        /// <summary>
        /// CodigoQR
        /// </summary>
        /// <value>
        /// Guarda QR del cupon
        /// </value>
        public byte[] CodigoQR { get; set; }

        /// <summary>
        /// FechaVencimiento
        /// </summary>
        /// <value>
        /// Fecha de vencimiento del cupon
        /// </value>
        public DateTime FechaVencimiento { get; set; }
        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor de clase, sin recibir parametros
        /// </summary>
        public Articulo_Cupon() :base()
        {
            
        }

        /// <summary>
        /// Constructor de clase,  recibiendo parametros
        /// </summary>
        public Articulo_Cupon(string pIdentificacion, string pNombre, string pDescripcion, double pPrecio, DateTime pFechaVencimiento) 
            :base(pIdentificacion,pNombre, pDescripcion,  pPrecio)
        {
            this.FechaVencimiento = pFechaVencimiento;
        }
        #endregion
    }
}
