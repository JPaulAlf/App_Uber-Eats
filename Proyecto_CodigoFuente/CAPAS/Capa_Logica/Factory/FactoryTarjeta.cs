using Capa_Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Factory
{
    /// <summary>
    /// Clase FactoryTarjeta, se encarga de cosntruir el tipo de tarjeta
    /// </summary>
   public  class FactoryTarjeta
    {

        /// <summary>
        /// Metodo creaTarjeta, se encarga de la construccion del objeto tarjeta
        /// </summary>
        /// <returns>Tarjeta</returns>
        public static Tarjeta CreaTarjeta(TipoTarjeta pTipo)
        {
            Tarjeta instanciaTarjeta = null;
            switch (pTipo)
            {
                case TipoTarjeta.MASTER_CARD:
                    instanciaTarjeta = new Tarjeta();
                    instanciaTarjeta._TipoTarjeta = TipoTarjeta.MASTER_CARD;
                    break;
               case TipoTarjeta.VISA:
                    instanciaTarjeta = new Tarjeta();
                    instanciaTarjeta._TipoTarjeta = TipoTarjeta.VISA;
                    break;
            }
            return instanciaTarjeta;
        }
    }
}
