using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Clases
{
    /// <summary>
    /// Clase Usuario_Cliente, hereda metodos y propiedades de Usuario
    /// </summary>
    public class Usuario_Cliente : Usuario
    {
        #region PROPIEDADES
        /// <summary>
        /// Apellido
        /// </summary>
        /// <value>
        /// Apellido del usuario
        /// </value>
        public string Apellido { get; set; }

        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de clase, sin recibir parametros
        /// </summary>
        public Usuario_Cliente() : base()
        {
            this.Apellido = "";
        }

        /// <summary>
        /// Constructor de clase,  recibiendo parametros
        /// </summary>
        public Usuario_Cliente( string pNombre, string pApellido, string pTelefono, string pCorreoElectronico, string pContrasenna) 
            : base(pNombre,pTelefono, pCorreoElectronico, pContrasenna)
        {
            this.Apellido = pApellido;
        }

        #endregion
    }
}
