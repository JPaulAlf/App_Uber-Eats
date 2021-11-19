using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Clases
{
    /// <summary>
    /// Clase Pedido, se encarga de almacenar los articulos que compro el usuario
    /// </summary>
    public class Pedido
    {
        #region PROPIEDADES
        /// <summary>
        /// FechaPedido
        /// </summary>
        /// <value>
        /// Fecha del pedido 
        /// </value>
        public DateTime FechaPedido { get; set; }

        /// <summary>
        /// DistanciaPedido
        /// </summary>
        /// <value>
        /// Costo del pedido, por la distancia del mismo
        /// </value>
        public double DistanciaPedido { get; set; }

        /// <summary>
        /// _ListaArticulosComprados
        /// </summary>
        /// <value>
        /// Lista de articulos comprados
        /// </value>
        public List<Articulo> _ListaArticulosComprados { get; set; }
        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor de clase, sin recibir parametros
        /// </summary>
        public Pedido()
        {
            this.FechaPedido = DateTime.Today;
            this.DistanciaPedido = .0;
            this._ListaArticulosComprados = new List<Articulo>();
        }

        /// <summary>
        /// Constructor de clase,recibiendo parametros
        /// </summary>
        public Pedido(DateTime pFecha, double pDistanciaPedido)
        {
            this.FechaPedido = pFecha;
            this.DistanciaPedido = pDistanciaPedido;
            this._ListaArticulosComprados = new List<Articulo>();
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Metodo AgregaPedido, agrega un articulo al pedido
        /// </summary>
        /// <returns>Void</returns>
        public void AgregaArticulo(Articulo pArticulo)
        {
            this._ListaArticulosComprados.Add(pArticulo);
        }

        #endregion
    }
}
