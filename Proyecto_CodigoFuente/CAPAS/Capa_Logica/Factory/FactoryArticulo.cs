using Capa_Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Factory
{
    /// <summary>
    /// Clase FactoryArticulo, se encarga de cosntruir el tipo de articulo
    /// </summary>
    public class FactoryArticulo
    {

        /// <summary>
        /// Metodo CreaArticulo, se encarga de la construccion del objeto artiuclo
        /// </summary>
        /// <returns>Articulo</returns>
        public static Articulo CreaArticulo(TipoArticulo pTipo)
        {
            Articulo instanciaArticulo = null;
            switch (pTipo)
            {
                case TipoArticulo.PRRODUCTO:
                    instanciaArticulo = new Articulo_Producto();
                    break;
                case TipoArticulo.CUPON:
                    instanciaArticulo = new Articulo_Cupon();
                    break;
            }
            return instanciaArticulo;
        }


    }
}
