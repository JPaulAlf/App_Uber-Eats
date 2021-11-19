using Capa_Entidades.Clases;
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
    /// Clase que obtiene acceso a la base de datos sobre Articulos
    /// </summary>
   public  class ArticuloDB
    {


        /// <summary>
        /// registra un cupon
        /// </summary>
        /// <param Articulo="pArticulo"></param>
        /// <param Identificaion de comercio="pIdetificacionUsuarioComercio"></param>
        public void RegistroArticulo_Cupon(Articulo pArticulo,int pIdetificacionUsuarioComercio)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_INSERTA_ARTICULO_Cupon";

                comando.Parameters.AddWithValue("@vIdentificacion", pArticulo.Identificacion);
                comando.Parameters.AddWithValue("@vNombre", pArticulo.Nombre);
                comando.Parameters.AddWithValue("@vDescripcion", pArticulo.Descripcion);
                comando.Parameters.AddWithValue("@vFotografia", pArticulo.Fotografia);
                comando.Parameters.AddWithValue("@vPrecio", pArticulo.Precio);

                comando.Parameters.AddWithValue("@vCodigoQR", (pArticulo as Articulo_Cupon).CodigoQR);
                comando.Parameters.AddWithValue("@vFechaVencimiento", (pArticulo as Articulo_Cupon).FechaVencimiento.ToString("yyyy/MM/dd HH:mm"));

                comando.Parameters.AddWithValue("@vIdentificacionUsuario", pIdetificacionUsuarioComercio);


                db.ExecuteNonQuery(comando);
            }
        }
        /// <summary>
        /// Obtiene un cupon
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <param identificacion de usuario="pIdentificacionUsuario"></param>
        /// <returns>Articulo</returns>
        public Articulo ObtenerArticulo_Cupon(string pIdentificacion, int pIdentificacionUsuario)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_OBTENER_ARTICULO_Cupon";

                comando.Parameters.AddWithValue("@vIdentificacion", pIdentificacion);
                comando.Parameters.AddWithValue("@vIdentificacionUsuario", pIdentificacionUsuario);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Articulo item = new Articulo_Cupon();
                    item.Identificacion = reader["Identificacion"].ToString();
                    item.Nombre = reader["Nombre"].ToString();
                    item.Descripcion = reader["Descripcion"].ToString();
                    item.Fotografia =(byte[]) reader["Fotografia"];
                    string precio = reader["Precio"].ToString().Replace('.', ',');
                    item.Precio = Convert.ToDouble(precio);

                    (item as Articulo_Cupon).CodigoQR = (byte[]) reader["CodigoQR"];
                    (item as Articulo_Cupon).FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"].ToString());

                    return item;
                }
            }

            return null;
        }
        /// <summary>
        /// Obtiene un cupon sin filtro
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <param identificacion de usuario="pIdentificacionUsuario"></param>
        /// <returns>Articulo</returns>
        public Articulo ObtenerArticulo_Cupon_SinFiltro(string pIdentificacion, int pIdentificacionUsuario)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_OBTENER_ARTICULO_Cupon_SinFiltro";

                comando.Parameters.AddWithValue("@vIdentificacion", pIdentificacion);
                comando.Parameters.AddWithValue("@vIdentificacionUsuario", pIdentificacionUsuario);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Articulo item = new Articulo_Cupon();
                    item.Identificacion = reader["Identificacion"].ToString();
                    item.Nombre = reader["Nombre"].ToString();
                    item.Descripcion = reader["Descripcion"].ToString();
                    item.Fotografia = (byte[])reader["Fotografia"];
                    string precio = reader["Precio"].ToString().Replace('.', ',');
                    item.Precio = Convert.ToDouble(precio);

                    (item as Articulo_Cupon).CodigoQR = (byte[])reader["CodigoQR"];
                    (item as Articulo_Cupon).FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"].ToString());

                    return item;
                }
            }

            return null;
        }
     /// <summary>
     /// Actiualiza un cupon
     /// </summary>
     /// <param Articulo="pArticulo"></param>
     /// <param Identificacion comercio="pIdetificacionUsuarioComercio"></param>
     /// <param identificacion orignal del producto="pIdentificacionOriginalProducto"></param>
        public void ActualizaArticulo_Cupon(Articulo pArticulo, int pIdetificacionUsuarioComercio, string pIdentificacionOriginalProducto)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_ACTUALIZA_ARTICULO_Cupon";

                comando.Parameters.AddWithValue("@vIdentificacion", pArticulo.Identificacion);
                comando.Parameters.AddWithValue("@vNombre", pArticulo.Nombre);
                comando.Parameters.AddWithValue("@vDescripcion", pArticulo.Descripcion);
                comando.Parameters.AddWithValue("@vFotografia", pArticulo.Fotografia);
                comando.Parameters.AddWithValue("@vPrecio", pArticulo.Precio);

                comando.Parameters.AddWithValue("@vCodigoQR", (pArticulo as Articulo_Cupon).CodigoQR);
                comando.Parameters.AddWithValue("@vFechaVencimiento", (pArticulo as Articulo_Cupon).FechaVencimiento.ToString("yyyy/MM/dd HH:mm"));

                comando.Parameters.AddWithValue("@vIdentificacionUsuario", pIdetificacionUsuarioComercio);
                comando.Parameters.AddWithValue("@vIdentificacionOriginalProducto", pIdentificacionOriginalProducto);

                db.ExecuteNonQuery(comando);
            }
        }



        /// <summary>
        /// Registor usuario
        /// </summary>
        /// <param Articulo="pArticulo"></param>
        /// <param Identificacion del negocio="pIdetificacionUsuarioComercio"></param>
        public void RegistroArticulo_Producto(Articulo pArticulo, int pIdetificacionUsuarioComercio)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_INSERTA_ARTICULO_Producto";

                comando.Parameters.AddWithValue("@vIdentificacion", pArticulo.Identificacion);
                comando.Parameters.AddWithValue("@vNombre", pArticulo.Nombre);
                comando.Parameters.AddWithValue("@vDescripcion", pArticulo.Descripcion);
                comando.Parameters.AddWithValue("@vFotografia", pArticulo.Fotografia);
                comando.Parameters.AddWithValue("@vPrecio", pArticulo.Precio);

                comando.Parameters.AddWithValue("@vIdentificacionUsuario", pIdetificacionUsuarioComercio);


                db.ExecuteNonQuery(comando);
            }
        }
        /// <summary>
        /// Obtiene producto
        /// </summary>
        /// <param Identificacion="pIdentificacion"></param>
        /// <param Identificacion="pIdentificacionUsuario"></param>
        /// <returns>Articulo</returns>
        public Articulo ObtenerArticulo_Producto(string pIdentificacion, int pIdentificacionUsuario)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_OBTENER_ARTICULO_Producto";

                comando.Parameters.AddWithValue("@vIdentificacion", pIdentificacion);
                comando.Parameters.AddWithValue("@vIdentificacionUsuario", pIdentificacionUsuario);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Articulo item = new Articulo_Cupon();
                    item.Identificacion = reader["Identificacion"].ToString();
                    item.Nombre = reader["Nombre"].ToString();
                    item.Descripcion = reader["Descripcion"].ToString();
                    item.Fotografia = (byte[])reader["Fotografia"];
                    string precio = reader["Precio"].ToString().Replace('.', ',');
                    item.Precio = Convert.ToDouble(precio);

                    return item;
                }
            }

            return null;
        }
        /// <summary>
        /// Obtiene producto sin filtro
        /// </summary>
        /// <param Identificacion="pIdentificacion"></param>
        /// <param Identificacion del usuario="pIdentificacionUsuario"></param>
        /// <returns>Articulo</returns>
        public Articulo ObtenerArticulo_Producto_SinFiltro(string pIdentificacion, int pIdentificacionUsuario)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_OBTENER_ARTICULO_Producto_SinFiltro";

                comando.Parameters.AddWithValue("@vIdentificacion", pIdentificacion);
                comando.Parameters.AddWithValue("@vIdentificacionUsuario", pIdentificacionUsuario);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Articulo item = new Articulo_Cupon();
                    item.Identificacion = reader["Identificacion"].ToString();
                    item.Nombre = reader["Nombre"].ToString();
                    item.Descripcion = reader["Descripcion"].ToString();
                    item.Fotografia = (byte[])reader["Fotografia"];
                    string precio = reader["Precio"].ToString().Replace('.', ',');
                    item.Precio = Convert.ToDouble(precio);

                    
                    return item;
                }
            }

            return null;
        }
     /// <summary>
     /// Actualiza el producto
     /// </summary>
     /// <param Articulo="pArticulo"></param>
     /// <param Identificacion del comercio="pIdetificacionUsuarioComercio"></param>
     /// <param Identificaicon orifinal del producto="pIdentificacionOriginalProducto"></param>
        public void ActualizaArticulo_Producto(Articulo pArticulo, int pIdetificacionUsuarioComercio, string pIdentificacionOriginalProducto)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_ACTUALIZA_ARTICULO_Producto";

                comando.Parameters.AddWithValue("@vIdentificacion", pArticulo.Identificacion);
                comando.Parameters.AddWithValue("@vNombre", pArticulo.Nombre);
                comando.Parameters.AddWithValue("@vDescripcion", pArticulo.Descripcion);
                comando.Parameters.AddWithValue("@vFotografia", pArticulo.Fotografia);
                comando.Parameters.AddWithValue("@vPrecio", pArticulo.Precio);

                comando.Parameters.AddWithValue("@vIdentificacionUsuario", pIdetificacionUsuarioComercio);
                comando.Parameters.AddWithValue("@vIdentificacionOriginalProducto", pIdentificacionOriginalProducto);

                db.ExecuteNonQuery(comando);
            }
        }



        /// <summary>
        /// Desactiva Articulo
        /// </summary>
        /// <param Identificacion="pIdentificacion"></param>
        public static void EstadoArticulo_Desactiva(string pIdentificacion)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_ARTICULO_ESTADO_Desactiva";
                comando.Parameters.AddWithValue("@vIdentificacion", pIdentificacion);


                db.ExecuteNonQuery(comando);
            }
        }
        /// <summary>
        /// Activa articulo
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        public static void EstadoArticulo_Activa(string pIdentificacion)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_ARTICULO_ESTADO_Activa";
                comando.Parameters.AddWithValue("@vIdentificacion", pIdentificacion);


                db.ExecuteNonQuery(comando);
            }
        }
        /// <summary>
        /// Verifica estado del articulo
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <returns>string</returns>
        public static string PA_VerificaArticulo_Estado(string pIdentificacion)
        {
            string estado = "";
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_ARTICULO_ESTADO";
                comando.Parameters.AddWithValue("@vIdentificacion", pIdentificacion);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {

                    estado = reader["Activo/Inactivo"].ToString();
                    return estado;
                }
            }

            return "-1";
        }




        //1==Si //// -1==NO
        /// <summary>
        /// Verifica existencia de la identificacion
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <returns>string</returns>
        public static string PA_VerificaArticulo_Existencia_Identificacion(string pIdentificacion)
        {
            string Numero = "";
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_ARTICULO_ESTADO_Identificacion";

                comando.Parameters.AddWithValue("@vIdentificacion", pIdentificacion);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {

                    Numero = reader["Numero"].ToString();
                    return Numero;
                }
            }

            return "-1";
        }
      /// <summary>
      /// verifica existencia de la identificacion sin filtro
      /// </summary>
      /// <param Identifiacion="pIdentificacion"></param>
      /// <returns>string</returns>
        public static string PA_VerificaArticulo_Existencia_Identificacion_SinFiltro(string pIdentificacion)
        {
            string Numero = "";
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_ARTICULO_ESTADO_Identificacion_SinFiltro";

                comando.Parameters.AddWithValue("@vIdentificacion", pIdentificacion);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {

                    Numero = reader["Numero"].ToString();
                    return Numero;
                }
            }

            return "-1";
        }



        /// <summary>
        /// retorna lista de productos sin filtro
        /// </summary>
        /// <param Usuario="user"></param>
        /// <returns>List<Articulo></returns>
        public List<Articulo> ObtenerListaProductos_SinFiltro(Usuario user)
        {
            List<Articulo> list = new List<Articulo>();
            Usuario pUser = null;

            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_ARTICULO_RETORNA_IDENTIFICACIONES_PRODUCTOS_SinFiltro";

                comando.Parameters.AddWithValue("@vIdentificacionUsuario",user.Identificacion);

                DataSet ds = db.ExecuteDataSet(comando);

                string identificacion = "";
                Articulo item = null;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    identificacion = dr["Identificacion"].ToString();
                    item = ObtenerArticulo_Producto_SinFiltro(identificacion, user.Identificacion);
                    //Console.WriteLine(item.Nombre);
                    list.Add(item);
                }
            }
            return list;
        }
        /// <summary>
        /// Retorna lista de cupones sin filtro
        /// </summary>
        /// <param Usuario="user"></param>
        /// <returns>List<Articulo></returns>
        public List<Articulo> ObtenerListaCupones_SinFiltro(Usuario user)
        {
            List<Articulo> list = new List<Articulo>();
            Usuario pUser = null;

            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_ARTICULO_RETORNA_IDENTIFICACIONES_CUPONES_SinFiltro";

                comando.Parameters.AddWithValue("@vIdentificacionUsuario", user.Identificacion);

                DataSet ds = db.ExecuteDataSet(comando);

                string identificacion = "";
                Articulo item = null;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    identificacion = dr["Identificacion"].ToString();
                    item = ObtenerArticulo_Cupon_SinFiltro(identificacion, user.Identificacion);
                    //Console.WriteLine(item.Nombre);
                    list.Add(item);
                }
            }
            return list;
        }


        /// <summary>
        /// retorna lista de productos 
        /// </summary>
        /// <param Usuario="user"></param>
        /// <returns>List<Articulo></returns>
        public List<Articulo> ObtenerListaProductos(Usuario user)
        {
            List<Articulo> list = new List<Articulo>();
            Usuario pUser = null;

            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_ARTICULO_RETORNA_IDENTIFICACIONES_PRODUCTOS";

                comando.Parameters.AddWithValue("@vIdentificacionUsuario", user.Identificacion);

                DataSet ds = db.ExecuteDataSet(comando);

                string identificacion = "";
                Articulo item = null;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    identificacion = dr["Identificacion"].ToString();
                    item = ObtenerArticulo_Producto(identificacion, user.Identificacion);
                    //Console.WriteLine(item.Nombre);
                    list.Add(item);
                }
            }
            return list;
        }
        /// <summary>
        /// retorna lista de cupones 
        /// </summary>
        /// <param Usuario="user"></param>
        /// <returns>List<Articulo></returns>
        public List<Articulo> ObtenerListaCupones(Usuario user)
        {
            List<Articulo> list = new List<Articulo>();
            Usuario pUser = null;

            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_ARTICULO_RETORNA_IDENTIFICACIONES_CUPONES";

                comando.Parameters.AddWithValue("@vIdentificacionUsuario", user.Identificacion);

                DataSet ds = db.ExecuteDataSet(comando);

                string identificacion = "";
                Articulo item = null;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    identificacion = dr["Identificacion"].ToString();
                    item = ObtenerArticulo_Cupon(identificacion, user.Identificacion);
                    //Console.WriteLine(item.Nombre);
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// Retorna la lista de articulos que se encuentran en una orden
        /// </summary>
        /// <param Numero de orden="pIdOrden"></param>
        /// <returns></returns>
        public List<Articulo> ObtenerListaProductos_OrdenPagada(int pIdOrden)
        {
            List<Articulo> list = new List<Articulo>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_RETORNA_OrdenesPagadas_Detalle";

                comando.Parameters.AddWithValue("@vIdOrden", pIdOrden);

                DataSet ds = db.ExecuteDataSet(comando);

                Articulo item = null;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    item = new Articulo();
                    item.Nombre = dr["Nombre"].ToString();
                    item.Cantidad = Convert.ToInt32(dr["Cantidad"].ToString());
                    item.Fotografia = (byte[])dr["Fotografia"];
                    list.Add(item);
                }
            }
            return list;
        }


    }
}
