using Capa_Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Factory
{
    /// <summary>
    /// Clase FactoryTransporte, se encarga de cosntruir el tipo de transporte
    /// para el ususario Repartidor
    /// </summary>
    public class FactoryTransporte
    {
        /// <summary>
        /// Metodo creaTransporte, se encarga de la construccion del objeto transporte
        /// </summary>
        /// <returns>Transporte</returns>
        public static Transporte creaTransporte(TipoTransporte pTipo)
        {
            Transporte instanciaTransporte = null;
            switch (pTipo)
            {
                case TipoTransporte.Bicicleta:
                    instanciaTransporte = new Transporte_Bicicleta();
                    break;
                case TipoTransporte.Carro:
                    instanciaTransporte = new Transporte_Carro();
                    break;
                case TipoTransporte.Moto:
                    instanciaTransporte = new Transporte_Motocicleta();
                    break;
            }
            return instanciaTransporte;
        }
    }
}
