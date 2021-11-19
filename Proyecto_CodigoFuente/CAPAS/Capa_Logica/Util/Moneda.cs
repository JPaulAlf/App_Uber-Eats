using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Clases
{
    /// <summary>
    /// Clase Moneda, se encarga de consumir servicios web
    /// </summary>
    public class Moneda
    {
        private static Moneda _InstanciaMoneda = null;

        #region PROPIEDADES
        /// <summary>
        /// FechaActualizacion
        /// </summary>
        /// <value>
        /// Fecha ultima que se actulizo los valores
        /// </value>
        public DateTime FechaActualizacion { get; set; }

        /// <summary>
        /// ValorVenta
        /// </summary>
        /// <value>
        /// Valor de venta de la moneda
        /// </value>
        public double ValorVenta { get; set; }

        /// <summary>
        /// ValorCompra
        /// </summary>
        /// <value>
        /// Valor de compra de la moneda
        /// </value>
        public double ValorCompra { get; set; }
        #endregion



        #region CONSTRUCTORES

        private Moneda()
        {
            this.ValorCompra = .0;
            this.ValorVenta = .0;
        }

        #endregion




        #region METODOS

        /// <summary>
        /// Metodo que aplica patron singleton y devuelve su instancia
        /// </summary>
        /// <returns>Instancia</returns>
        public static Moneda GetInstance()
        {
            if (_InstanciaMoneda == null)
            {
                return _InstanciaMoneda = new Moneda();
            }
            else
            {
                return _InstanciaMoneda;
            }
        }

        /// <summary>
        /// Asigna valor de compra a la moneda
        /// </summary>
        /// <returns>No retorna</returns>
        public void AsignaCompra()
        {
            this.ValorCompra = .0;
        }

        /// <summary>
        /// Asigna valor de compra a la moneda
        /// </summary>
        /// <returns>No retorna</returns>
        public void AsignaVenta()
        {
            this.ValorVenta = .0;
        }

        /// <summary>
        /// Asigna valores a las propiedades
        /// </summary>
        /// <returns>No retorna</returns>
        public void AsignaDatos(double valorDolar,DateTime FechaActualizacion)
        {
            this.ValorCompra = valorDolar;
            this.FechaActualizacion = FechaActualizacion;
        }
        #endregion



    }
}
