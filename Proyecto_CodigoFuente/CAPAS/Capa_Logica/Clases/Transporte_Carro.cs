using Capa_Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Clases
{
    /// <summary>
    /// Clase Transporte_Carro, hereda metodos y propiedades de Transporte y de ITransporte
    /// </summary>
    public class Transporte_Carro : Transporte,ITransporte
    {
        #region PROPIEDADES
        /// <summary>
        /// NumeroPlaca
        /// </summary>
        /// <value>
        /// Numero de placa del vehiculo
        /// </value>
        public int NumeroPlaca { get; set; }

        /// <summary>
        /// EstaAsegurado
        /// </summary>
        /// <value>
        /// Verificacion de seguro del vehiculo
        /// </value>
        public bool EstaAsegurado { get ; set; }

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor de clase, sin recibir parametros
        /// </summary>
        public Transporte_Carro() : base()
        {
            this.NumeroPlaca = 0;
            this.EstaAsegurado = false;
        }

        /// <summary>
        /// Constructor de clase, recibiendo parametros
        /// </summary>
        public Transporte_Carro(string pMarca, string pModelo, string pColor, int pNumeroPlaca,bool pEstaAsegurado)
            :base(pMarca,pModelo,  pColor)
        {
            this.NumeroPlaca = pNumeroPlaca; 
            this.EstaAsegurado = pEstaAsegurado;
        }
        #endregion

    }
}
