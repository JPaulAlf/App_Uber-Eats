using System;
using System.Drawing;

namespace Capa_Entidades.Clases
{

    /// <summary>
    ///Clase Articulo, le da forma y sentido a las clases derivadas de esta
    /// </summary>
    public class Articulo
    {
        #region PROPIEDADES

        /// <summary>
        /// Nombre
        /// </summary>
        /// <value>
        /// Es el nombre del articulo
        /// </value>
        public string Nombre { get; set; }

        /// <summary>
        /// Identificacion
        /// </summary>
        /// <value>
        /// Es la identificacion del articulo
        /// </value>
        public string Identificacion { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        /// <value>
        /// Descripcion del articulo
        /// </value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Fotografia
        /// </summary>
        /// <value>
        /// Fotografia del articulo
        /// </value>
        public byte[] Fotografia { get; set; }

        /// <summary>
        /// Precio
        /// </summary>
        /// <value>
        /// Precio del articulo
        /// </value>
        public double Precio { get; set; }


        /// <summary>
        /// Cantidad
        /// </summary>
        /// <value>
        /// cantidad del articulo
        /// </value>
        public double Cantidad { get; set; }

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor de clase, sin recibir parametros
        /// </summary>
        public Articulo()
        {
            this.Nombre = "";
            this.Identificacion = "";
            this.Descripcion = "";
            this.Fotografia = null;
            this.Precio = 0;
        }

        /// <summary>
        /// Constructor de clase,  recibiendo parametros
        /// </summary>
        public Articulo(string pIdentificacion,string pNombre,string pDescripcion, double pPrecio)
        {
            this.Nombre = pNombre;
            this.Identificacion = pIdentificacion;
            this.Descripcion = pDescripcion;
            this.Precio = pPrecio;
        }
        #endregion

    }
}
