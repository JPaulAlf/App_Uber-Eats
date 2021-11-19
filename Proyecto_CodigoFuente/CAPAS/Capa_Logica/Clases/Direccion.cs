using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Clases

{
    /// <summary>
    ///Clase Direccion, posee las caracteristicas y datos de direccion de cada usuario
    /// </summary>
    public class Direccion
    {
        /// <summary>
        /// Longitud
        /// </summary>
        /// <value>
        /// Longitud de posicion en el mapa
        /// </value>
        public double Longitud { get; set; }

        /// <summary>
        /// Latitud
        /// </summary>
        /// <value>
        /// Latitud de posicion en el mapa
        /// </value>
        public double Latitud { get; set; }

        /// <summary>
        /// DescripcionUbicacion
        /// </summary>
        /// <value>
        /// Descripcion de la ubicacion relativa del usuario
        /// </value>
        public string DescripcionUbicacion { get; set; }
    }
}
