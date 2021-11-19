using Capa_Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Clases
{
    /// <summary>
    /// Clase Usuario_Comercio, hereda metodos y propiedades de Usuario
    /// </summary>
    public class Usuario_Comercio :Usuario
    {
        #region PROPIEDADES

        /// <summary>
        /// _ListaArticulos
        /// </summary>
        /// <value>
        /// Lista de articulos disponibles
        /// </value>
        public List<Articulo> _ListaArticulos { get; set; }


        /// <summary>
        /// _ListaCalificacion
        /// </summary>
        /// <value>
        /// Lista de calificaciones disponibles
        /// </value>
        public List<Calificacion> _ListaCalificacion { get; set; }


        /// <summary>
        /// PuntuacionTotal
        /// </summary>
        /// <value>
        /// Puntacion del Usuario
        /// </value>
        public double PuntuacionTotal { get; set; }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de clase, sin recibir parametros
        /// </summary>
        public Usuario_Comercio() : base()
        {

            this._ListaCalificacion = new List<Calificacion>();
            this.PuntuacionTotal = .0;

            this._ListaArticulos = new List<Articulo>();
        }

        /// <summary>
        /// Constructor de clase,  recibiendo parametros
        /// </summary>
        public Usuario_Comercio(string pNombre, string pTelefono, string pCorreoElectronico, string pContrasenna)
            : base(pNombre, pTelefono, pCorreoElectronico, pContrasenna)
        {

            this._ListaCalificacion = new List<Calificacion>();
            this.PuntuacionTotal = .0;

            this._ListaArticulos = new List<Articulo>();
        }
        #endregion


        #region METODOS

        /// <summary>
        /// Metodo AgregaCalificacion, agrega una calificacion a la lista
        /// </summary>
        /// <returns>Void</returns>
        public void AgregaCalificacion(Calificacion pCalificacion)
        {
            this._ListaCalificacion.Add(pCalificacion);
        }

        #endregion


    }
}
