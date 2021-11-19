using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Interfaces
{
    /// <summary>
    /// Interfaz ITransporte, establece forma a las clases que la implementen
    /// </summary>
    public interface ITransporte
    {
        /// <summary>
        /// NumeroPlaca
        /// </summary>
        /// <value>
        /// Numero de placa del vehiculo
        /// </value>
        int NumeroPlaca { get; set; }

        /// <summary>
        /// EstaAsegurado
        /// </summary>
        /// <value>
        /// Verificacion de seguro del vehiculo
        /// </value>
        bool EstaAsegurado { get; set; }
    }
}
