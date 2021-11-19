using Capa_Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Factory
{

    /// <summary>
    /// Clase FactoryUsuario, se encarga de cosntruir el tipo de usuario
    /// </summary>
   public  class FactoryUsuario
    {

        /// <summary>
        /// Metodo creaUsuario, se encarga de la construccion del objeto usuario
        /// </summary>
        /// <returns>Usuario</returns>
        public static Usuario creaUsuario(TipoUsuario pTipo)
        {
            Usuario instanciaUsuario = null;
            switch (pTipo)
            {
                case TipoUsuario.CLIENTE:
                    instanciaUsuario = new Usuario_Cliente();
                    break;
                case TipoUsuario.COMERCIO:
                    instanciaUsuario = new Usuario_Comercio();
                    break;
                case TipoUsuario.REPARTIDOR:
                    instanciaUsuario = new Usuario_Repartidor();
                    break;
            }
            return instanciaUsuario;
        }
    }
}
