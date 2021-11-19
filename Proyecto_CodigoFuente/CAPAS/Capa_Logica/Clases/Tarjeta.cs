using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Clases
{
    /// <summary>
    /// Clase Trjeta, se encarga de todo lo que es dinero y montos de pago
    /// </summary>
    public class Tarjeta
    {
        #region PROPIEDADES
        /// <summary>
        /// NumeroTarjeta
        /// </summary>
        /// <value>
        /// Numero de la tarjeta del usuario
        /// </value>
        public string NumeroTarjeta { get; set; }

        /// <summary>
        /// FechaVencimiento
        /// </summary>
        /// <value>
        /// Fecha de vencimiento de la tarjeta
        /// </value>
        public DateTime FechaVencimiento { get; set; }

        /// <summary>
        /// CVV
        /// </summary>
        /// <value>
        /// Codigo de seguridad de la tarjeta del usuario
        /// </value>
        public string CVV { get; set; }

        /// <summary>
        /// _PagosTarjeta
        /// </summary>
        /// <value>
        /// Almacena todos los pagos efectuados
        /// </value>
        public List<Pago> _PagosTarjeta { get; set; }

        /// <summary>
        /// _TipoTarjeta
        /// </summary>
        /// <value>
        /// Confirma el tipo de tarjeta del usuario
        /// </value>
        public TipoTarjeta _TipoTarjeta { get; set; }
        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor de clase, sin recibir parametros
        /// </summary>
        public Tarjeta()
        {
            this.NumeroTarjeta = "";
            this.CVV = "";

            this._PagosTarjeta = new List<Pago>();
        }

        /// <summary>
        /// Constructor de clase,recibiendo parametros
        /// </summary>
        public Tarjeta(string pNumeroTarjeta,string pCVV,TipoTarjeta pTipoTarjeta,DateTime pFechaVencimiento)
        {
            this.NumeroTarjeta = pNumeroTarjeta;
            this.CVV = pCVV;
            this._TipoTarjeta = pTipoTarjeta;
            this.FechaVencimiento = pFechaVencimiento;
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Metodo AgregaPago, agrega un pago a la tarjeta
        /// </summary>
        /// <returns>Void</returns>
        public void AgregaPago(Pago pPago)
        {
            this._PagosTarjeta.Add(pPago);
        }

        /// <summary>
        /// Metodo validarFechaTarjeta, se encarga de comprobar que la tarjeta no este vencida
        /// </summary>
        /// <returns>Bool value</returns>
        public  bool validarFechaTarjeta() 
    {
            return (FechaVencimiento.Month >= DateTime.Today.Month && FechaVencimiento.Year >= DateTime.Today.Year);
    }

        /// <summary>
        /// Metodo validarNumeroTarjeta, se encarga de comprobar que el numero de
        /// la tarjeta sea valido
        /// </summary>
        /// <returns>Bool value</returns>
        public  bool validarNumeroTarjeta()
    {
        int s1 = 0, s2 = 0;
        String reversa = NumeroTarjeta.Reverse<char>().ToString();

        for (int i = 0; i < NumeroTarjeta.Length; i++)
        {
            int digito = Convert.ToInt32(NumeroTarjeta.Substring(NumeroTarjeta.Length - 1 - i, 1));
                if (i % 2 == 0)
            {
                s1 += digito;
            }
            else
            {
                s2 += 2 * digito;
                if (digito >= 5)
                {
                    s2 -= 9;
                }
            }
        }
        if ((s1 + s2) % 10 == 0)
        {
            return true;
        }
        return false;
        }

        /// <summary>
        /// Metodo validarTipoTarjeta, se encarga de comprobar que el numero de
        /// la tarjeta sea valido para su tipo
        /// </summary>
        /// <returns>Bool value</returns>
        public  bool validarTipoTarjeta()
    {
        int longTarjeta = NumeroTarjeta.Length;
        int longCVV = CVV.Length;
        char a, b, c;
        switch (_TipoTarjeta)
        {
            case TipoTarjeta.VISA:
                if (longTarjeta == 16 && longCVV == 3)
                {
                    a = NumeroTarjeta.ElementAt<char>(0);
                    if (a == '4')
                    {
                        return true;
                    }
                }
                break;
            case TipoTarjeta.MASTER_CARD:
                if (longTarjeta == 16 && longCVV == 3)
                {
                    b = NumeroTarjeta.ElementAt<char>(0);
                    c = NumeroTarjeta.ElementAt<char>(1);
                    if (b == '5' && c == '1' || b == '5' && c == '2' || b == '5' && c == '3' || b == '5' && c == '4' || b == '5' && c == '5')
                    {
                        return true;
                    }
                }
                break;
        }
        return false;
    }

        #endregion
    }
}
