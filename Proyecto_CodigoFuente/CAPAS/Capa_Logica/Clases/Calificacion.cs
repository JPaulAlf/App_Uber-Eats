using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Interfaces
{
    /// <summary>
    /// Clasew Calificacion, establece la calificacion a las clases que la implementen
    /// </summary>
    public class Calificacion
    {
        /// <summary>
        /// Comentario
        /// </summary>
        /// <value>
        /// Comentario de la calificacion
        /// </value>
        public string Comentario { get; set; }

        /// <summary>
        /// Puntuacion
        /// </summary>
        /// <value>
        /// Puntacion del Usuario
        /// </value>
        public double Puntuacion { get; set; }
    }
}
