using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Clases
{
    /// <summary>
    /// Clase Transporte, se encarga de crear el medio de transporte del repartidor
    /// </summary>
    public class Transporte
    {
        #region PROPIEDADES
        /// <summary>
        /// Marca
        /// </summary>
        /// <value>
        /// Nombre de la marca de vehiculo
        /// </value>
        public string Marca { get; set; }

        /// <summary>
        /// Modelo
        /// </summary>
        /// <value>
        /// Nombre del modelo de vehiculo
        /// </value>
        public string Modelo { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        /// <value>
        /// Color del vehiculo
        /// </value>
        public string Color { get; set; }

        #endregion


        #region CONSTRUCTORES

        /// <summary>
        /// Constructor de clase, sin recibir parametros
        /// </summary>
        public Transporte()
        {
            this.Marca = "";
            this.Modelo = "";
            this.Color = "";
        }

        /// <summary>
        /// Constructor de clase, recibiendo parametros
        /// </summary>
        public Transporte(string pMarca,string pModelo,string pColor)
        {
            this.Marca = pMarca;
            this.Modelo = pModelo;
            this.Color = pColor;
        }
        #endregion


    }
}
