using Capa_Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Clases
{
    /// <summary>
    /// Clase Usuario_Repartidor, hereda metodos y propiedades de Usuario
    /// </summary>
    public class Usuario_Repartidor : Usuario
    {
        #region PROPIEDADES
        /// <summary>
        /// Apellidos
        /// </summary>
        /// <value>
        /// Apellidos del usuario
        /// </value>
        public string Apellidos { get; set; }

        /// <summary>
        /// _Transporte
        /// </summary>
        /// <value>
        /// Transporte del usuario
        /// </value>
        public Transporte _Transporte { get; set; }


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

        /// <summary>
        /// Es el usuario del cual hay que hacerle la entrega
        /// </summary>
        public Usuario _UsuarioPaquete { get; set; }

        /// <summary>
        /// Es el usuario del cual procede el paquete
        /// </summary>
        public Usuario _UsuarioComercio { get; set; }

        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de clase, sin recibir parametros
        /// </summary>
        public Usuario_Repartidor() : base()
        {
            this.PuntuacionTotal = .0;

            this._ListaCalificacion = new List<Calificacion>();
            this._Transporte = null;
            this.Apellidos = "";
        }

        /// <summary>
        /// Constructor de clase,  recibiendo parametros
        /// </summary>
        public Usuario_Repartidor(string pNombre, string pApellido, string pTelefono, string pCorreoElectronico, string pContrasenna)
            : base(pNombre, pTelefono, pCorreoElectronico, pContrasenna)
        {
            this.Apellidos = pApellido;

            this._ListaCalificacion = new List<Calificacion>();
            this.PuntuacionTotal = .0;
            this._Transporte = null;
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
