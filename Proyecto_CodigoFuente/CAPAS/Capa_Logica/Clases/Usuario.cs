using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Capa_Entidades.Clases
{
    /// <summary>
    /// Clase Usuario, hereda metodos y propiedades de Transporte y de ITransporte
    /// </summary>
    public class Usuario
    {
        #region PROPIEDADES
        /// <summary>
        /// Identificacion
        /// </summary>
        /// <value>
        /// Identificacion del usuario
        /// </value>
        public int Identificacion { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        /// <value>
        /// Nombre del usuario
        /// </value>
        public string Nombre { get; set; }

        /// <summary>
        /// _Direccion
        /// </summary>
        /// <value>
        /// Direccion del usuario
        /// </value>
        public Direccion _Direccion { get; set; }

        /// <summary>
        /// NumeroTelefono
        /// </summary>
        /// <value>
        /// Numero de telefono del usuario
        /// </value>
        public string NumeroTelefono { get; set; }

        /// <summary>
        /// CorreoElectronico
        /// </summary>
        /// <value>
        /// Correo electronico del usuario
        /// </value>
        public string CorreoElectronico { get; set; }

        /// <summary>
        /// Contrasenna
        /// </summary>
        /// <value>
        /// Contrasenna del usuario
        /// </value>
        public string Contrasenna { get; set; }

        /// <summary>
        /// _Tarjeta
        /// </summary>
        /// <value>
        /// Tarjeta del usuario
        /// </value>
        public Tarjeta _Tarjeta { get; set; }

        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de clase, sin recibir parametros
        /// </summary>
        public Usuario()
        {
            this.Nombre = "";
            this.NumeroTelefono = "";
            this.CorreoElectronico = "";
            this.Contrasenna = "";
            this._Tarjeta = null;
            this._Direccion = null;
        }

        /// <summary>
        /// Constructor de clase,  recibiendo parametros
        /// </summary>
        public Usuario(string pNombre,string pTelefono, string pCorreoElectronico, string pContrasenna)
        {
            this.Nombre = pNombre;
            this.NumeroTelefono = pTelefono;
            this.CorreoElectronico = pCorreoElectronico;
            this.Contrasenna = pContrasenna;

            this._Tarjeta = null;
            this._Direccion = null;
        }
        #endregion

        
    }
}
