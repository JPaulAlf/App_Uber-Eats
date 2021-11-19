using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Clases
{
    /// <summary>
    /// Clase Pago, se encarga de generar un pago, que luego sera ingresado en la tarjeta
    /// </summary>
    public class Pago
    {
        #region PROPIEDADES
        /// <summary>
        /// FechaPago
        /// </summary>
        /// <value>
        /// Fecha del pago
        /// </value>
        public DateTime FechaPago { get; set; }

        /// <summary>
        /// MontoDolares
        /// </summary>
        /// <value>
        /// Monto en dolares pagado
        /// </value>
        public double MontoDolares { get; set; }

        /// <summary>
        /// MontoColones
        /// </summary>
        /// <value>
        /// Monto en colones de lo pagado
        /// </value>
        public double  MontoColones { get; set; }

        /// <summary>
        /// _Pedido
        /// </summary>
        /// <value>
        /// Es el pedido
        /// </value>
        public Pedido _Pedido { get; set; }

        /// <summary>
        /// _Moneda
        /// </summary>
        /// <value>
        /// Es el valor de la moneda
        /// </value>
        public Moneda _Moneda { get; set; }
        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor de clase, sin recibir parametros
        /// </summary>
        public Pago()
        {
            this.MontoDolares = .0;
            this.MontoColones = .0;
            this._Pedido = null;
            this._Moneda = null ;
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Metodo AgregaPedido, agrega un pedido
        /// </summary>
        /// <returns>Void</returns>
        public void AgregaPedido(Pedido pPedido)
        {
            this._Pedido = pPedido;
        }

        /// <summary>
        /// Metodo AsignarCostoColones, asigna costo en colones
        /// </summary>
        /// <returns>Void</returns>
        public double CostoExpressColones()
        {
           return _Pedido.DistanciaPedido * 100;
        }

        /// <summary>
        /// Metodo AsignaMoneda, asigna la moneda actual
        /// </summary>
        /// <returns>Void</returns>
        public void AsignaMoneda(Moneda pMoneda)
        {
            this._Moneda = pMoneda;
        }


        #endregion


    }
}
