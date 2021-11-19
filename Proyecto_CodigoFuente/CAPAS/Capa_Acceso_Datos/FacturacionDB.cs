using Capa.Datos;
using Capa_Entidades.Clases;
using Microsoft.ReportingServices.Diagnostics.Internal;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Acceso_Datos
{
    /// <summary>
    /// Clase que se encarga de establecer conexion con la bsse de datos y crear la factura
    /// </summary>
    public class FacturacionDB
    {
        /// <summary>
        /// Ingresa una factura nueva
        /// </summary>
        /// <param Factura="pFactura"></param>
        /// <param Cifrado del XML="pCifradoXML"></param>
        public void IngresaFacturaNueva(Factura pFactura,string pCifradoXML)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_INSERTA_EncFactura";

                comando.Parameters.AddWithValue("@vFechaPago",pFactura._PagoUsuarioCliente.FechaPago.ToString("yyyy/MM/dd HH:mm"));
                comando.Parameters.AddWithValue("@vMontoSubTotal", pFactura.Calcula_SubTotal_Gravado());
                comando.Parameters.AddWithValue("@vMontoExpress", pFactura.Calcula_Envio());
                comando.Parameters.AddWithValue("@vImpuesto", pFactura.Calcula_IVA());
                comando.Parameters.AddWithValue("@vMontoColones", pFactura.CalculaMonto_Total());
                comando.Parameters.AddWithValue("@MontoDolares", pFactura.CalculaMonto_Total_Dolares());
                comando.Parameters.AddWithValue("@vRespaldoXML", pCifradoXML);

                db.ExecuteNonQuery(comando);
            }
        }

        /// <summary>
        /// Ingresa una factura el usuario
        /// </summary>
        /// <param usuario="pUsuario"></param>
        public void IngresaFacturaUsuario(Usuario pUsuario)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_INSERTA_EncFacturaUsuario";

                comando.Parameters.AddWithValue("@vIdentificacionUsuario", pUsuario.Identificacion);

                db.ExecuteNonQuery(comando);
            }
        }

        /// <summary>
        /// Ingresa articulos a la factura
        /// </summary>
        /// <param Articulo="pArticulo"></param>
        public void IngresaFacturaArticulo(Articulo pArticulo)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_INSERTA_DetFactura";

                comando.Parameters.AddWithValue("@vIdentificacion", pArticulo.Identificacion);
                comando.Parameters.AddWithValue("@vCantidad", pArticulo.Cantidad);
                comando.Parameters.AddWithValue("@vPrecio", pArticulo.Cantidad*pArticulo.Precio);


                db.ExecuteNonQuery(comando);
            }
        }

        /// <summary>
        ///Crea la consulta para mostrar las ordenes efectuadas por el usuario 
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <returns>DataTable</returns>
        public DataTable RetornarnaOrdenesDisponibles(int pIdentificacion)
        {
            
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                SqlCommand sqlCmd;
                DataTable dtData = new DataTable();
                sqlCmd = new SqlCommand("PA_RETORNA_OrdenesDisponibles", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCmd.Parameters.AddWithValue("@vIdentificacionUsuario", pIdentificacion);
                SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
                sqlSda.Fill(dtData);
                return dtData;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        ///Crea la consulta para mostrar los sujetos involucrrados
        ///en la compras efectuadas por el usuario 
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <returns>DataTable</returns>
        public DataTable RetornarnaSujetosDisponiblesCalificacion(int pIdentificacion)
        {

            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                SqlCommand sqlCmd;
                DataTable dtData = new DataTable();
                sqlCmd = new SqlCommand("PA_RETORNA_CalificacionUltimaCompra", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCmd.Parameters.AddWithValue("@vIdentificacionUsuario", pIdentificacion);
                SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
                sqlSda.Fill(dtData);
                return dtData;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }


        /// <summary>
        /// Ingresa una calificacion al usuario
        /// </summary>
        /// <param identificacion Usuario="pIdentificacionU"></param>
        /// <param nuemero de teelfono empresa="pNumeroTelefonoC"></param>
        /// <param Calificacion="pNuevaCalificacion"></param>
        /// <param Comentario="pComment"></param>
        public void IngresaCalificacion(int pIdentificacionU, string pNumeroTelefonoC, int pNuevaCalificacion, string pComment)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_INSERTA_CALIFICACION";

                comando.Parameters.AddWithValue("@vIdentificacionUsuario", pIdentificacionU);
                comando.Parameters.AddWithValue("@vNumeroTelefonoComercio", pNumeroTelefonoC);
                comando.Parameters.AddWithValue("@vNuevaCalificacion", pNuevaCalificacion);
                comando.Parameters.AddWithValue("@vComentario", pComment);


                db.ExecuteNonQuery(comando);
            }
        }

        /// <summary>
        ///Crea la consulta para mostrar losordenes nuevas por aceptar
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <returns>DataTable</returns>
        public DataTable RetornaOrdenesDisponiblesParaAceptar(int pIdentificacion)
        {

            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                SqlCommand sqlCmd;
                DataTable dtData = new DataTable();
                sqlCmd = new SqlCommand("PA_RETORNA_OrdenesPagadas", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCmd.Parameters.AddWithValue("@vIdentificacion", pIdentificacion);
                SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
                sqlSda.Fill(dtData);
                return dtData;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Acepta el numero de orden
        /// </summary>
        /// <param Numero de orden="pIDOrden"></param>
        public void ActualizaEstaAceptado(int pIDOrden)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_Actualiza_AceptaOrden";
                comando.Parameters.AddWithValue("@vIDOrden", pIDOrden);

                db.ExecuteNonQuery(comando);
            }
        }

        /// <summary>
        /// Retorna las ordenes aceptadas
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable RetornaOrdenesAceptadas()
        {

            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();
                SqlCommand sqlCmd;
                DataTable dtData = new DataTable();
                sqlCmd = new SqlCommand("PA_RETORNA_OrdenesAceptadas", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
                sqlSda.Fill(dtData);
                return dtData;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Retorna el correo y contrasenna del usuario de la orden
        /// </summary>
        /// <param Numero de orden="pOrden"></param>
        /// <param Numero de identificacion="pIdentificacion"></param>
        /// <returns> List<string> </returns>
        public List<string> AceptarOrdenEntrega(int pOrden,int pIdentificacin)
        {
            List<string> list = new List<string>();

            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_INSERTA_AceptaOrdenEntregar";
                comando.Parameters.AddWithValue("@vIDOrden", pOrden);
                comando.Parameters.AddWithValue("@vIdentificacion", pIdentificacin);


                
                System.Data.DataSet ds = db.ExecuteDataSet(comando);

                string correo = "";
                string contrasenna = "";
                string cantidad = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    correo = dr["CorreoElectronico"].ToString();
                    contrasenna = dr["Contrasenna"].ToString();
                    cantidad= dr["Cantidad"].ToString();
                    list.Add(correo);
                    list.Add(contrasenna);
                    list.Add(cantidad);


                }
            }
            return list;
        }

        /// <summary>
        /// Retorna el correo y contrasenna del usuario de la orden
        /// </summary>
        /// <param Numero de orden="pOrden"></param>
        /// <returns> List<string> </returns>
        public List<string> DevuelveComercioOrden(int pOrden)
        {
            List<string> list = new List<string>();

            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_RETORNA_NegocioVenta";
                comando.Parameters.AddWithValue("@vIDOrden", pOrden);

                System.Data.DataSet ds = db.ExecuteDataSet(comando);

                string correo = "";
                string contrasenna = "";
                string cantidad = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    correo = dr["CorreoElectronico"].ToString();
                    contrasenna = dr["Contrasenna"].ToString();
                    cantidad = dr["Cantidad"].ToString();
                    list.Add(correo);
                    list.Add(contrasenna);
                    list.Add(cantidad);


                }
            }
            return list;
        }

        /// <summary>
        /// Marca la orden como entregada
        /// </summary>
        /// <param Numero de Orden="pIDOrden"></param>
        public void OrdenEntregada(int pIDOrden)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_INSERTA_OrdenEntregada";
                comando.Parameters.AddWithValue("@vIDOrden", pIDOrden);

                db.ExecuteNonQuery(comando);
            }
        }









    }

}
