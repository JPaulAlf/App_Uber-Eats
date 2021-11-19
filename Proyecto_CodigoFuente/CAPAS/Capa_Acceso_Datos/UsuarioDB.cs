using Capa_Entidades.Clases;
using Capa_Entidades.Interfaces;
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
    /// Clase UsuarioDB, se encarga de  obtener los PA de la Base de Datos
    /// </summary>
    public class UsuarioDB
    {



        #region USUARIO CLIENTE
        /// <summary>
        /// Registra el usuario en la Base de datos
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        public void RegistroUsuario_Cliente(Usuario pUsuario)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_RegistroNuevoUsuario_CLIENTE";

                comando.Parameters.AddWithValue("@vIdentificacion", pUsuario.Identificacion);
                comando.Parameters.AddWithValue("@vNombre", pUsuario.Nombre);
                comando.Parameters.AddWithValue("@vApellido", (pUsuario as Usuario_Cliente).Apellido);
                comando.Parameters.AddWithValue("@vNumeroTelefono", pUsuario.NumeroTelefono);

                comando.Parameters.AddWithValue("@vLatitud", pUsuario._Direccion.Latitud);
                comando.Parameters.AddWithValue("@vLongitud", pUsuario._Direccion.Longitud);
                comando.Parameters.AddWithValue("@vDescripcionUbicacion", pUsuario._Direccion.DescripcionUbicacion);

                comando.Parameters.AddWithValue("@vCorreoElectronico", pUsuario.CorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pUsuario.Contrasenna);

                comando.Parameters.AddWithValue("@vNumeroTarjeta", pUsuario._Tarjeta.NumeroTarjeta);
                comando.Parameters.AddWithValue("@vCVV", pUsuario._Tarjeta.CVV);
                comando.Parameters.AddWithValue("@vFechaVencimiento", pUsuario._Tarjeta.FechaVencimiento.ToString("yyyy/MM/dd HH:mm"));
                comando.Parameters.AddWithValue("@vTipoTarjeta", pUsuario._Tarjeta._TipoTarjeta == TipoTarjeta.VISA ? 1 : 2);


                db.ExecuteNonQuery(comando);
            }
        }
        /// <summary>
        /// Obtiene el usuario de la base de datos
        /// </summary>
        /// <param Correo Electronico="pCorreoElectronico"></param>
        /// <param Contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Cliente(string pCorreoElectronico, string pContrasenna)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_RETORNA_USUARIO_CLIENTE";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pContrasenna);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Usuario user = new Usuario_Cliente();
                    user.Identificacion = (int)reader["Identificacion"];
                    user.Nombre = reader["Nombre"].ToString();
                    (user as Usuario_Cliente).Apellido = reader["Apellido"].ToString();
                    user.NumeroTelefono = reader["NumeroTelefono"].ToString();

                    Direccion direct = new Direccion();
                    string lat = reader["Latitud"].ToString().Replace('.', ',');
                    string lng = reader["Longitud"].ToString().Replace('.', ','); 
                    direct.Latitud = Convert.ToDouble(lat);
                    direct.Longitud = Convert.ToDouble(lng);
                    direct.DescripcionUbicacion = reader["DescripcionUbicacion"].ToString();

                    user.CorreoElectronico = reader["CorreoElectronico"].ToString();
                    user.Contrasenna = reader["Contrasenna"].ToString();

                    Tarjeta card = new Tarjeta();
                    card.NumeroTarjeta = reader["NumeroTarjeta"].ToString();
                    card.CVV = reader["CVV"].ToString();
                    card.FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"].ToString());
                    string tipoTarjeta = reader["NombreCategoria"].ToString();
                    if (tipoTarjeta.Equals("VISA"))
                    {
                        card._TipoTarjeta = TipoTarjeta.VISA;
                    }
                    else
                    {
                        card._TipoTarjeta = TipoTarjeta.MASTER_CARD;
                    }

                    user._Tarjeta = card;
                    user._Direccion = direct;

                    return user;
                }
            }

            return null;
        }
        /// <summary>
        /// Actualiza el usuario
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        /// <param Identificacion Original="pIDentificacionOriginal"></param>
        public void ActualizaUsuario_Cliente(Usuario pUsuario, int pIDentificacionOriginal)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_USUARIO_CLIENTE_ActualizaDatos";

                comando.Parameters.AddWithValue("@vIDentificacionOriginal", pIDentificacionOriginal);

                comando.Parameters.AddWithValue("@vIdentificacion", pUsuario.Identificacion);
                comando.Parameters.AddWithValue("@vNombre", pUsuario.Nombre);
                comando.Parameters.AddWithValue("@vApellido", (pUsuario as Usuario_Cliente).Apellido);
                comando.Parameters.AddWithValue("@vNumeroTelefono", pUsuario.NumeroTelefono);

                comando.Parameters.AddWithValue("@vLatitud", pUsuario._Direccion.Latitud);
                comando.Parameters.AddWithValue("@vLongitud", pUsuario._Direccion.Longitud);
                comando.Parameters.AddWithValue("@vDescripcionUbicacion", pUsuario._Direccion.DescripcionUbicacion);

                comando.Parameters.AddWithValue("@vCorreoElectronico", pUsuario.CorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pUsuario.Contrasenna);

                comando.Parameters.AddWithValue("@vNumeroTarjeta", pUsuario._Tarjeta.NumeroTarjeta);
                comando.Parameters.AddWithValue("@vCVV", pUsuario._Tarjeta.CVV);
                comando.Parameters.AddWithValue("@vFechaVencimiento", pUsuario._Tarjeta.FechaVencimiento.ToString("yyyy/MM/dd HH:mm"));
                comando.Parameters.AddWithValue("@vTipoTarjeta", pUsuario._Tarjeta._TipoTarjeta == TipoTarjeta.VISA ? 1 : 2);


                db.ExecuteNonQuery(comando);
            }
        }
        #endregion



        #region USUARIO REPARTIDOR
        /// <summary>
        /// Registra el usuario en la base de datos
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        public void RegistroUsuario_Repartidor_Bicicleta(Usuario pUsuario)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_RegistroNuevoUsuario_REPARTIDOR_BICICLETA";

                comando.Parameters.AddWithValue("@vIdentificacion", pUsuario.Identificacion);
                comando.Parameters.AddWithValue("@vNombre", pUsuario.Nombre);
                comando.Parameters.AddWithValue("@vApellido", (pUsuario as Usuario_Repartidor).Apellidos);
                comando.Parameters.AddWithValue("@vNumeroTelefono", pUsuario.NumeroTelefono);

                comando.Parameters.AddWithValue("@vLatitud", pUsuario._Direccion.Latitud);
                comando.Parameters.AddWithValue("@vLongitud", pUsuario._Direccion.Longitud);
                comando.Parameters.AddWithValue("@vDescripcionUbicacion", pUsuario._Direccion.DescripcionUbicacion);

                comando.Parameters.AddWithValue("@vCorreoElectronico", pUsuario.CorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pUsuario.Contrasenna);

                comando.Parameters.AddWithValue("@vNumeroTarjeta", pUsuario._Tarjeta.NumeroTarjeta);
                comando.Parameters.AddWithValue("@vCVV", pUsuario._Tarjeta.CVV);
                comando.Parameters.AddWithValue("@vFechaVencimiento", pUsuario._Tarjeta.FechaVencimiento.ToString("yyyy/MM/dd HH:mm"));
                comando.Parameters.AddWithValue("@vTipoTarjeta", pUsuario._Tarjeta._TipoTarjeta == TipoTarjeta.VISA ? 1 : 2);

                comando.Parameters.AddWithValue("@vMarca", (pUsuario as Usuario_Repartidor)._Transporte.Marca);
                comando.Parameters.AddWithValue("@vModelo", (pUsuario as Usuario_Repartidor)._Transporte.Modelo);
                comando.Parameters.AddWithValue("@vColor", (pUsuario as Usuario_Repartidor)._Transporte.Color);

                db.ExecuteNonQuery(comando);
            }
        }
        /// <summary>
        /// Registra el usuari en la base de datos
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        public void RegistroUsuario_Repartidor_MotorVehiculo(Usuario pUsuario)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_RegistroNuevoUsuario_REPARTIDOR_MOTORVEHCULO";

                comando.Parameters.AddWithValue("@vIdentificacion", pUsuario.Identificacion);
                comando.Parameters.AddWithValue("@vNombre", pUsuario.Nombre);
                comando.Parameters.AddWithValue("@vApellido", (pUsuario as Usuario_Repartidor).Apellidos);
                comando.Parameters.AddWithValue("@vNumeroTelefono", pUsuario.NumeroTelefono);

                comando.Parameters.AddWithValue("@vLatitud", pUsuario._Direccion.Latitud);
                comando.Parameters.AddWithValue("@vLongitud", pUsuario._Direccion.Longitud);
                comando.Parameters.AddWithValue("@vDescripcionUbicacion", pUsuario._Direccion.DescripcionUbicacion);

                comando.Parameters.AddWithValue("@vCorreoElectronico", pUsuario.CorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pUsuario.Contrasenna);

                comando.Parameters.AddWithValue("@vNumeroTarjeta", pUsuario._Tarjeta.NumeroTarjeta);
                comando.Parameters.AddWithValue("@vCVV", pUsuario._Tarjeta.CVV);
                comando.Parameters.AddWithValue("@vFechaVencimiento", pUsuario._Tarjeta.FechaVencimiento.ToString("yyyy/MM/dd HH:mm"));
                comando.Parameters.AddWithValue("@vTipoTarjeta", pUsuario._Tarjeta._TipoTarjeta == TipoTarjeta.VISA ? 1 : 2);

                comando.Parameters.AddWithValue("@vMarca", (pUsuario as Usuario_Repartidor)._Transporte.Marca);
                comando.Parameters.AddWithValue("@vModelo", (pUsuario as Usuario_Repartidor)._Transporte.Modelo);
                comando.Parameters.AddWithValue("@vColor", (pUsuario as Usuario_Repartidor)._Transporte.Color);

                if ((pUsuario as Usuario_Repartidor)._Transporte is Transporte_Carro)
                {
                    Transporte trans = new Transporte_Carro();
                    trans = (pUsuario as Usuario_Repartidor)._Transporte;

                    comando.Parameters.AddWithValue("@vNumeroPlaca", (trans as Transporte_Carro).NumeroPlaca);
                    comando.Parameters.AddWithValue("@vEstaAlDia", (trans as Transporte_Carro).EstaAsegurado ? "true" : "false");
                    comando.Parameters.AddWithValue("@vIDCategoriaVechiclo", 1);

                }
                else if ((pUsuario as Usuario_Repartidor)._Transporte is Transporte_Motocicleta)
                {
                    Transporte trans = new Transporte_Motocicleta();
                    trans = (pUsuario as Usuario_Repartidor)._Transporte;

                    comando.Parameters.AddWithValue("@vNumeroPlaca", (trans as Transporte_Motocicleta).NumeroPlaca);
                    comando.Parameters.AddWithValue("@vEstaAlDia", (trans as Transporte_Motocicleta).EstaAsegurado ? "true" : "false");
                    comando.Parameters.AddWithValue("@vIDCategoriaVechiclo", 2);

                }

                db.ExecuteNonQuery(comando);
            }
        }
        /// <summary>
        /// Obtiene el usuario de la base de datos
        /// </summary>
        /// <param Correo Electornico="pCorreoElectronico"></param>
        /// <param Contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Repartidor(string pCorreoElectronico, string pContrasenna)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_RETORNA_USUARIO_REPARTIDOR";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pContrasenna);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Usuario user = new Usuario_Repartidor();
                    user.Identificacion = (int)reader["Identificacion"];
                    user.Nombre = reader["Nombre"].ToString();
                    (user as Usuario_Repartidor).Apellidos = reader["Apellido"].ToString();
                    user.NumeroTelefono = reader["NumeroTelefono"].ToString();
                    (user as Usuario_Repartidor).PuntuacionTotal = Convert.ToDouble(reader["Calificacion"]);

                    Direccion direct = new Direccion();
                    string lat = reader["Latitud"].ToString().Replace('.', ',');
                    string lng = reader["Longitud"].ToString().Replace('.', ','); 
                    direct.Latitud = Convert.ToDouble(lat);
                    direct.Longitud = Convert.ToDouble(lng);
                    direct.DescripcionUbicacion = reader["DescripcionUbicacion"].ToString();

                    user.CorreoElectronico = reader["CorreoElectronico"].ToString();
                    user.Contrasenna = reader["Contrasenna"].ToString();

                    Tarjeta card = new Tarjeta();
                    card.NumeroTarjeta = reader["NumeroTarjeta"].ToString();
                    card.CVV = reader["CVV"].ToString();
                    card.FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"].ToString());
                    string tipoTarjeta = reader["NombreCategoria"].ToString();
                    if (tipoTarjeta.Equals("VISA"))
                    {
                        card._TipoTarjeta = TipoTarjeta.VISA;
                    }
                    else
                    {
                        card._TipoTarjeta = TipoTarjeta.MASTER_CARD;
                    }

                    Transporte trans;
                    int tipo = (int)reader["IDCategoriaTransporte"];
                    if (tipo == 1)
                    {
                        trans = new Transporte_Carro();
                        trans.Marca = reader["Marca"].ToString();
                        trans.Modelo = reader["Modelo"].ToString();
                        trans.Color = reader["Color"].ToString();
                        (trans as Transporte_Carro).NumeroPlaca = (int)reader["NumeroPlaca"];
                        (trans as Transporte_Carro).EstaAsegurado = reader["EstaAlDia"].ToString().Equals("true");

                        (user as Usuario_Repartidor)._Transporte = trans;

                    }
                    else if (tipo == 2)
                    {
                        trans = new Transporte_Motocicleta();
                        trans.Marca = reader["Marca"].ToString();
                        trans.Modelo = reader["Modelo"].ToString();
                        trans.Color = reader["Color"].ToString();
                        (trans as Transporte_Motocicleta).NumeroPlaca = (int)reader["NumeroPlaca"];
                        (trans as Transporte_Motocicleta).EstaAsegurado = reader["EstaAlDia"].ToString().Equals("true");

                        (user as Usuario_Repartidor)._Transporte = trans;

                    }
                    else if(tipo == 3)
                    {
                        trans = new Transporte_Bicicleta();
                        trans.Marca = reader["Marca"].ToString();
                        trans.Modelo = reader["Modelo"].ToString();
                        trans.Color = reader["Color"].ToString();

                        (user as Usuario_Repartidor)._Transporte = trans;

                    }

                    user._Tarjeta = card;
                    user._Direccion = direct;


                    return user;
                }
            }

            return null;
        }
        /// <summary>
        /// Actualiza el usuario
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        /// <param Identificacion="pIDentificacionOriginal"></param>
        public void ActualizaUsuario_Repartidor(Usuario pUsuario, int pIDentificacionOriginal)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_USUARIO_REPARTIDOR_ActualizaDatos";

                comando.Parameters.AddWithValue("@vIDentificacionOriginal", pIDentificacionOriginal);

                comando.Parameters.AddWithValue("@vIdentificacion", pUsuario.Identificacion);
                comando.Parameters.AddWithValue("@vNombre", pUsuario.Nombre);
                comando.Parameters.AddWithValue("@vApellido", (pUsuario as Usuario_Repartidor).Apellidos);
                comando.Parameters.AddWithValue("@vNumeroTelefono", pUsuario.NumeroTelefono);

                comando.Parameters.AddWithValue("@vLatitud", pUsuario._Direccion.Latitud);
                comando.Parameters.AddWithValue("@vLongitud", pUsuario._Direccion.Longitud);
                comando.Parameters.AddWithValue("@vDescripcionUbicacion", pUsuario._Direccion.DescripcionUbicacion);

                comando.Parameters.AddWithValue("@vCorreoElectronico", pUsuario.CorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pUsuario.Contrasenna);

                comando.Parameters.AddWithValue("@vNumeroTarjeta", pUsuario._Tarjeta.NumeroTarjeta);
                comando.Parameters.AddWithValue("@vCVV", pUsuario._Tarjeta.CVV);
                comando.Parameters.AddWithValue("@vFechaVencimiento", pUsuario._Tarjeta.FechaVencimiento.ToString("yyyy/MM/dd HH:mm"));
                comando.Parameters.AddWithValue("@vTipoTarjeta", pUsuario._Tarjeta._TipoTarjeta == TipoTarjeta.VISA ? 1 : 2);

                Transporte trans = (pUsuario as Usuario_Repartidor)._Transporte;
                if (trans is Transporte_Bicicleta)
                {
                    comando.Parameters.AddWithValue("@vMarca", trans.Marca);
                    comando.Parameters.AddWithValue("@vModelo", trans.Modelo);
                    comando.Parameters.AddWithValue("@vColor", trans.Color);
                    comando.Parameters.AddWithValue("@vNumeroPlaca", "");
                    comando.Parameters.AddWithValue("@vEstaAlDia", "");
                    comando.Parameters.AddWithValue("@vIDCategoriaVechiclo", 3);
                }
                else if (trans is Transporte_Carro)
                {

                    comando.Parameters.AddWithValue("@vMarca", trans.Marca);
                    comando.Parameters.AddWithValue("@vModelo", trans.Modelo);
                    comando.Parameters.AddWithValue("@vColor", trans.Color);
                    comando.Parameters.AddWithValue("@vNumeroPlaca", (trans as Transporte_Carro).NumeroPlaca);
                    comando.Parameters.AddWithValue("@vEstaAlDia", (trans as Transporte_Carro).EstaAsegurado ? "true" : "false");
                    comando.Parameters.AddWithValue("@vIDCategoriaVechiclo", 1);
                }
                else if (trans is Transporte_Motocicleta)
                {

                    comando.Parameters.AddWithValue("@vMarca", trans.Marca);
                    comando.Parameters.AddWithValue("@vModelo", trans.Modelo);
                    comando.Parameters.AddWithValue("@vColor", trans.Color);
                    comando.Parameters.AddWithValue("@vNumeroPlaca", (trans as Transporte_Motocicleta).NumeroPlaca);
                    comando.Parameters.AddWithValue("@vEstaAlDia", (trans as Transporte_Motocicleta).EstaAsegurado ? "true" : "false");
                    comando.Parameters.AddWithValue("@vIDCategoriaVechiclo", 2);
                }



                db.ExecuteNonQuery(comando);
            }
        }

        #endregion




        #region USUARIO COMERCIO
        /// <summary>
        /// Registra el usuario en la base de datos
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        public void RegistroUsuario_Comercio(Usuario pUsuario)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_RegistroNuevoUsuario_NEGOCIO";

                comando.Parameters.AddWithValue("@vIdentificacion", pUsuario.Identificacion);
                comando.Parameters.AddWithValue("@vNombre", pUsuario.Nombre);
                comando.Parameters.AddWithValue("@vNumeroTelefono", pUsuario.NumeroTelefono);

                comando.Parameters.AddWithValue("@vLatitud", pUsuario._Direccion.Latitud);
                comando.Parameters.AddWithValue("@vLongitud", pUsuario._Direccion.Longitud);
                comando.Parameters.AddWithValue("@vDescripcionUbicacion", pUsuario._Direccion.DescripcionUbicacion);

                comando.Parameters.AddWithValue("@vCorreoElectronico", pUsuario.CorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pUsuario.Contrasenna);

                comando.Parameters.AddWithValue("@vNumeroTarjeta", pUsuario._Tarjeta.NumeroTarjeta);
                comando.Parameters.AddWithValue("@vCVV", pUsuario._Tarjeta.CVV);
                comando.Parameters.AddWithValue("@vFechaVencimiento", pUsuario._Tarjeta.FechaVencimiento.ToString("yyyy/MM/dd HH:mm"));
                comando.Parameters.AddWithValue("@vTipoTarjeta", pUsuario._Tarjeta._TipoTarjeta == TipoTarjeta.VISA ? 1 : 2);


                db.ExecuteNonQuery(comando);
            }
        }
        /// <summary>
        /// Obtiene el usuario de la base de datos
        /// </summary>
        /// <param Correo electronico="pCorreoElectronico"></param>
        /// <param Contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Comercio(string pCorreoElectronico, string pContrasenna)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_RETORNA_USUARIO_NEGOCIO";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pContrasenna);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Usuario user = new Usuario_Comercio();
                    user.Identificacion = (int)reader["Identificacion"];
                    user.Nombre = reader["Nombre"].ToString();
                    user.NumeroTelefono = reader["NumeroTelefono"].ToString();

                    Direccion direct = new Direccion();
                    string lat = reader["Latitud"].ToString().Replace('.', ',');
                    string lng = reader["Longitud"].ToString().Replace('.', ','); ;
                    direct.Latitud = Convert.ToDouble(lat);
                    direct.Longitud = Convert.ToDouble(lng);
                    direct.DescripcionUbicacion = reader["DescripcionUbicacion"].ToString();

                    user.CorreoElectronico = reader["CorreoElectronico"].ToString();
                    user.Contrasenna = reader["Contrasenna"].ToString();

                    Tarjeta card = new Tarjeta();
                    card.NumeroTarjeta = reader["NumeroTarjeta"].ToString();
                    card.CVV = reader["CVV"].ToString();
                    card.FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"].ToString());
                    string tipoTarjeta = reader["NombreCategoria"].ToString();
                    if (tipoTarjeta.Equals("VISA"))
                    {
                        card._TipoTarjeta = TipoTarjeta.VISA;
                    }
                    else
                    {
                        card._TipoTarjeta = TipoTarjeta.MASTER_CARD;
                    }
                   (user as Usuario_Comercio).PuntuacionTotal = Convert.ToDouble(reader["Calificacion"]);

                    user._Tarjeta = card;
                    user._Direccion = direct;

                    return user;
                }
            }

            return null;
        }
        /// <summary>
        /// Obtiene la calificacion del negocio
        /// </summary>
        /// <param Usuario="pUsuario"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Comercio_Calificacion(Usuario pUsuario)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_RETORNA_USUARIO_NEGOCIO_CALIFICACION";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pUsuario.CorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pUsuario.Contrasenna);

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Calificacion oCalificacion = new Calificacion();
                    oCalificacion.Comentario = dr["Comentario"].ToString();
                    oCalificacion.Puntuacion = (float)dr["Calificacion"];
                    (pUsuario as Usuario_Comercio).AgregaCalificacion(oCalificacion);
                }

                return pUsuario;
            }
        }
        /// <summary>
        /// Actualiza usuario en la base de datos
        /// </summary>
        /// <param usuario="pUsuario"></param>
        /// <param Identificacion Original="pIDentificacionOriginal"></param>
        public void ActualizaUsuario_Comercio(Usuario pUsuario, int pIDentificacionOriginal)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_USUARIO_NEGOCIO_ActualizaDatos";

                comando.Parameters.AddWithValue("@vIDentificacionOriginal", pIDentificacionOriginal);

                comando.Parameters.AddWithValue("@vIdentificacion", pUsuario.Identificacion);
                comando.Parameters.AddWithValue("@vNombre", pUsuario.Nombre);
                comando.Parameters.AddWithValue("@vNumeroTelefono", pUsuario.NumeroTelefono);

                comando.Parameters.AddWithValue("@vLatitud", pUsuario._Direccion.Latitud);
                comando.Parameters.AddWithValue("@vLongitud", pUsuario._Direccion.Longitud);
                comando.Parameters.AddWithValue("@vDescripcionUbicacion", pUsuario._Direccion.DescripcionUbicacion);

                comando.Parameters.AddWithValue("@vCorreoElectronico", pUsuario.CorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pUsuario.Contrasenna);

                comando.Parameters.AddWithValue("@vNumeroTarjeta", pUsuario._Tarjeta.NumeroTarjeta);
                comando.Parameters.AddWithValue("@vCVV", pUsuario._Tarjeta.CVV);
                comando.Parameters.AddWithValue("@vFechaVencimiento", pUsuario._Tarjeta.FechaVencimiento.ToString("yyyy/MM/dd HH:mm"));
                comando.Parameters.AddWithValue("@vTipoTarjeta", pUsuario._Tarjeta._TipoTarjeta == TipoTarjeta.VISA ? 1 : 2);


                db.ExecuteNonQuery(comando);
            }
        }

        #endregion


        /// <summary>
        /// Obtiene el usuario de la base de datos
        /// </summary>
        /// <param Correo electronico="pCorreoElectronico"></param>
        /// <param Contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Administrador(string pCorreoElectronico, string pContrasenna)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_RETORNA_USUARIO_ADMINISTRADOR";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pContrasenna);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Usuario user = new Usuario_Admin();
                    user.Identificacion = (int)reader["Identificacion"];
                    user.Nombre = reader["Nombre"].ToString();
                    user.NumeroTelefono = reader["NumeroTelefono"].ToString();

                    Direccion direct = new Direccion();
                    string lat = reader["Latitud"].ToString().Replace('.', ',');
                    string lng = reader["Longitud"].ToString().Replace('.', ','); ;
                    direct.Latitud = Convert.ToDouble(lat);
                    direct.Longitud = Convert.ToDouble(lng);
                    direct.DescripcionUbicacion = reader["DescripcionUbicacion"].ToString();

                    user.CorreoElectronico = reader["CorreoElectronico"].ToString();
                    user.Contrasenna = reader["Contrasenna"].ToString();

                    Tarjeta card = new Tarjeta();
                    card.NumeroTarjeta = reader["NumeroTarjeta"].ToString();
                    card.FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"].ToString());
                    card.CVV = reader["CVV"].ToString();
                    string tipoTarjeta = reader["NombreCategoria"].ToString();
                    if (tipoTarjeta.Equals("VISA"))
                    {
                        card._TipoTarjeta = TipoTarjeta.VISA;
                    }
                    else
                    {
                        card._TipoTarjeta = TipoTarjeta.MASTER_CARD;
                    }

                    user._Tarjeta = card;
                    user._Direccion = direct;

                    return user;
                }
            }

            return null;
        }



        /// <summary>
        /// Obtiene el tipo de usuario
        /// </summary>
        /// <param Correo electronico="pCorreoElectronico"></param>
        /// <param Contrasenna="pContrasenna"></param>
        /// <returns>string</returns>
        public static string ObtenerTipoUsuario_LogIn(string pCorreoElectronico, string pContrasenna)
        {
            string Numero = "";
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_VerificaUsuario_TIPO";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pContrasenna);

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
      /// Desactiva el usuario
      /// </summary>
      /// <param Correo electronico="pCorreoElectronico"></param>
      /// <param Contrasenna="pContrasenna"></param>
        public static void EstadoUsuario_Desactiva(string pCorreoElectronico, string pContrasenna)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_USUARIO_ESTADO_Desactiva";
                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pContrasenna);

                db.ExecuteNonQuery(comando);
            }
        }
       /// <summary>
       /// Activa el usuario
       /// </summary>
       /// <param correo electronico="pCorreoElectronico"></param>
       /// <param contrasennna="pContrasenna"></param>
        public static void EstadoUsuario_Activa(string pCorreoElectronico, string pContrasenna)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_USUARIO_ESTADO_Activa";
                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pContrasenna);

                db.ExecuteNonQuery(comando);
            }
        }
       /// <summary>
       /// Desactiva cuenta del usuario
       /// </summary>
       /// <param IdentificacionOriginal="pIdentificacionOriginal"></param>
        public static void EstadoUsuario_Desactiva_Cuenta(int pIdentificacionOriginal)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_USUARIO_ESTADO_Desactiva_Cuenta";
                comando.Parameters.AddWithValue("@vIDentificacionOriginal", pIdentificacionOriginal);

                db.ExecuteNonQuery(comando);
            }
        }



        /// <summary>
        /// verifica existencia de numero de telefono
        /// </summary>
        /// <param Numero de telefono="pNumeroTelefono"></param>
        /// <returns>string</returns>
        public static string VerificaExistencia_NumeroTelefono(string pNumeroTelefono)
        {
            string Numero = "";
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_VerificaUsuario_Existencia_NumeroTelefono";

                comando.Parameters.AddWithValue("@vNumTelefono", pNumeroTelefono);

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
      /// Verifica existencia de Correo electronico
      /// </summary>
      /// <param Correo Electronico="pCorreoElectronico"></param>
      /// <returns>string</returns>
        public static string VerificaExistencia_CorreoElectronico(string pCorreoElectronico)
        {
            string Numero = "";
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_VerificaUsuario_Existencia_CorreoElectronico";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);

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
        /// Verififca existenia de tarjeta
        /// </summary>
        /// <param Numero de tarjeta="pNumeroTarjeta"></param>
        /// <returns><string/returns>
        public static string PA_VerificaUsuario_Existencia_Tarjeta(string pNumeroTarjeta)
        {
            string Numero = "";
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_VerificaUsuario_Existencia_Tarjeta";

                comando.Parameters.AddWithValue("@vNumTarjeta", pNumeroTarjeta);

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
        /// Verifica existencia de identificacion
        /// </summary>
        /// <param identificacion="pIdentificacion"></param>
        /// <returns>string</returns>
        public static string PA_VerificaUsuario_Existencia_Identificacion(int pIdentificacion)
        {
            string Numero = "";
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_VerificaUsuario_Existencia_Identificacion";

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
       /// Verifica estado del usuario Activo/Inactivo
       /// </summary>
       /// <param correo electronico="pCorreoElectronico"></param>
       /// <param Contrasenna="pContrasenna"></param>
       /// <returns>string</returns>
        public static string PA_VerificaUsuario_Estado_Usuario(string pCorreoElectronico, string pContrasenna)
        {
            string estado = "";
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_RETORNA_USUARIO_ESTADO";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pContrasenna);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {

                    estado = reader["Activo/Inactivo"].ToString();
                    return estado;
                }
            }

            return "-1";
        }


        /// <summary>
        /// Devuelve la lisat de usuarios dentro de la aplicacion
        /// </summary>
        /// <returns> List<Usuario></returns>
        public List<Usuario> ObtenerListaUsuariosApp()
        {
            List<Usuario> list = new List<Usuario>();
            Usuario pUser = null;

            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_RETORNA_USUARIO_CORREO_Y_CONTRASENNA";

                DataSet ds = db.ExecuteDataSet(comando);

                string correo = "";
                string contrasenna = "";
                string opcion = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    correo = dr["CorreoElectronico"].ToString();
                    contrasenna = dr["Contrasenna"].ToString();

                    opcion = ObtenerTipoUsuario_LogIn_SinFiltro(correo, contrasenna);
                    if (opcion.Equals("1"))
                    {
                        pUser = ObtenerUsuario_Cliente_SinFiltro(correo, contrasenna);
                        //Console.WriteLine(pUser.Nombre);
                        list.Add(pUser);

                    }
                    else if (opcion.Equals("2"))
                    {
                        pUser = ObtenerUsuario_Comercio_SinFiltro(correo, contrasenna);
                       // Console.WriteLine(pUser.Nombre);

                        list.Add(pUser);
                        
                    }
                    else if (opcion.Equals("3"))
                    {
                        pUser = ObtenerUsuario_Repartidor_SinFiltro(correo, contrasenna);
                       // Console.WriteLine(pUser.Nombre);

                        list.Add(pUser);

                    }
                    
                }
            }
            return list;
        }
        /// <summary>
        /// Retorna la lista de comercios dentro de la aplicacion
        /// </summary>
        /// <returns> List<Usuario></returns>
        public List<Usuario> ObtenerListaUsuariosApp_Comercios()
        {
            List<Usuario> list = new List<Usuario>();
            Usuario pUser = null;

            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_RETORNA_USUARIO_CORREO_Y_CONTRASENNA";

                DataSet ds = db.ExecuteDataSet(comando);

                string correo = "";
                string contrasenna = "";
                string opcion = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    correo = dr["CorreoElectronico"].ToString();
                    contrasenna = dr["Contrasenna"].ToString();

                    opcion = ObtenerTipoUsuario_LogIn(correo, contrasenna);
                    
                     if (opcion.Equals("2"))
                     {
                        pUser = ObtenerUsuario_Comercio(correo, contrasenna);
                        list.Add(pUser);
                     }
                   

                }
            }
            return list;
        }

        /// <summary>
        /// Retorna la lista de comercios dentro de la aplicacion
        /// </summary>
        /// <returns> List<Usuario></returns>
        public List<Usuario> ObtenerListaUsuariosApp_Comercios_SinFiltro()
        {
            List<Usuario> list = new List<Usuario>();
            Usuario pUser = null;

            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_RETORNA_USUARIO_CORREO_Y_CONTRASENNA";

                DataSet ds = db.ExecuteDataSet(comando);

                string correo = "";
                string contrasenna = "";
                string opcion = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    correo = dr["CorreoElectronico"].ToString();
                    contrasenna = dr["Contrasenna"].ToString();

                    opcion = ObtenerTipoUsuario_LogIn(correo, contrasenna);

                    if (opcion.Equals("2"))
                    {
                        pUser = ObtenerUsuario_Comercio_SinFiltro(correo, contrasenna);
                        list.Add(pUser);
                    }


                }
            }
            return list;
        }

        /// <summary>
        /// Obtiene el tipo de usuario sin filtracion
        /// </summary>
        /// <param Correo electornico="pCorreoElectronico"></param>
        /// <param contrasenna="pContrasenna"></param>
        /// <returns>string</returns>
        public string ObtenerTipoUsuario_LogIn_SinFiltro(string pCorreoElectronico, string pContrasenna)
        {
            string Numero = "";
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_VerificaUsuario_TIPO_SIN_FILTRO";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pContrasenna);

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
        /// Obtiene el usuario repartidor sin filtro
        /// </summary>
        /// <param Correo electornico="pCorreoElectronico"></param>
        /// <param contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Repartidor_SinFiltro(string pCorreoElectronico, string pContrasenna)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_RETORNA_USUARIO_REPARTIDOR_SIN_FILTRO";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pContrasenna);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Usuario user = new Usuario_Repartidor();
                    user.Identificacion = (int)reader["Identificacion"];
                    user.Nombre = reader["Nombre"].ToString();
                    (user as Usuario_Repartidor).Apellidos = reader["Apellido"].ToString();
                    user.NumeroTelefono = reader["NumeroTelefono"].ToString();
                    (user as Usuario_Repartidor).PuntuacionTotal = Convert.ToDouble(reader["Calificacion"]);

                    Direccion direct = new Direccion();
                    string lat = reader["Latitud"].ToString().Replace('.', ',');
                    string lng = reader["Longitud"].ToString().Replace('.', ',');
                    direct.Latitud = Convert.ToDouble(lat);
                    direct.Longitud = Convert.ToDouble(lng);
                    direct.DescripcionUbicacion = reader["DescripcionUbicacion"].ToString();

                    user.CorreoElectronico = reader["CorreoElectronico"].ToString();
                    user.Contrasenna = reader["Contrasenna"].ToString();

                    Tarjeta card = new Tarjeta();
                    card.NumeroTarjeta = reader["NumeroTarjeta"].ToString();
                    card.CVV = reader["CVV"].ToString();
                    card.FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"].ToString());
                    string tipoTarjeta = reader["NombreCategoria"].ToString();
                    if (tipoTarjeta.Equals("VISA"))
                    {
                        card._TipoTarjeta = TipoTarjeta.VISA;
                    }
                    else
                    {
                        card._TipoTarjeta = TipoTarjeta.MASTER_CARD;
                    }

                    Transporte trans;
                    int tipo = (int)reader["IDCategoriaTransporte"];
                    if (tipo == 1)
                    {
                        trans = new Transporte_Carro();
                        trans.Marca = reader["Marca"].ToString();
                        trans.Modelo = reader["Modelo"].ToString();
                        trans.Color = reader["Color"].ToString();
                        (trans as Transporte_Carro).NumeroPlaca = (int)reader["NumeroPlaca"];
                        (trans as Transporte_Carro).EstaAsegurado = reader["EstaAlDia"].ToString().Equals("true");

                        (user as Usuario_Repartidor)._Transporte = trans;

                    }
                    else if (tipo == 2)
                    {
                        trans = new Transporte_Motocicleta();
                        trans.Marca = reader["Marca"].ToString();
                        trans.Modelo = reader["Modelo"].ToString();
                        trans.Color = reader["Color"].ToString();
                        (trans as Transporte_Motocicleta).NumeroPlaca = (int)reader["NumeroPlaca"];
                        (trans as Transporte_Motocicleta).EstaAsegurado = reader["EstaAlDia"].ToString().Equals("true");

                        (user as Usuario_Repartidor)._Transporte = trans;

                    }
                    else if (tipo == 3)
                    {
                        trans = new Transporte_Bicicleta();
                        trans.Marca = reader["Marca"].ToString();
                        trans.Modelo = reader["Modelo"].ToString();
                        trans.Color = reader["Color"].ToString();

                        (user as Usuario_Repartidor)._Transporte = trans;

                    }

                    user._Tarjeta = card;
                    user._Direccion = direct;


                    return user;
                }
            }

            return null;
        }
        /// <summary>
        /// Obtiene el usuario repartidor sin filtro
        /// </summary>
        /// <param Correo electornico="pCorreoElectronico"></param>
        /// <param contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Cliente_SinFiltro(string pCorreoElectronico, string pContrasenna)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_RETORNA_USUARIO_CLIENTE_SIN_FILTRO";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pContrasenna);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Usuario user = new Usuario_Cliente();
                    user.Identificacion = (int)reader["Identificacion"];
                    user.Nombre = reader["Nombre"].ToString();
                    (user as Usuario_Cliente).Apellido = reader["Apellido"].ToString();
                    user.NumeroTelefono = reader["NumeroTelefono"].ToString();

                    Direccion direct = new Direccion();
                    string lat = reader["Latitud"].ToString().Replace('.', ',');
                    string lng = reader["Longitud"].ToString().Replace('.', ','); ;
                    direct.Latitud = Convert.ToDouble(lat);
                    direct.Longitud = Convert.ToDouble(lng);
                    direct.DescripcionUbicacion = reader["DescripcionUbicacion"].ToString();

                    user.CorreoElectronico = reader["CorreoElectronico"].ToString();
                    user.Contrasenna = reader["Contrasenna"].ToString();

                    Tarjeta card = new Tarjeta();
                    card.NumeroTarjeta = reader["NumeroTarjeta"].ToString();
                    card.CVV = reader["CVV"].ToString();
                    card.FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"].ToString());
                    string tipoTarjeta = reader["NombreCategoria"].ToString();
                    if (tipoTarjeta.Equals("VISA"))
                    {
                        card._TipoTarjeta = TipoTarjeta.VISA;
                    }
                    else
                    {
                        card._TipoTarjeta = TipoTarjeta.MASTER_CARD;
                    }

                    user._Tarjeta = card;
                    user._Direccion = direct;

                    return user;
                }
            }

            return null;
        }
        /// <summary>
        /// Obtiene el usuario comercio sin filtro
        /// </summary>
        /// <param Correo electornico="pCorreoElectronico"></param>
        /// <param contrasenna="pContrasenna"></param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuario_Comercio_SinFiltro(string pCorreoElectronico, string pContrasenna)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_RETORNA_USUARIO_NEGOCIO_SIN_FILTRO";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pContrasenna);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Usuario user = new Usuario_Comercio();
                    user.Identificacion = (int)reader["Identificacion"];
                    user.Nombre = reader["Nombre"].ToString();
                    user.NumeroTelefono = reader["NumeroTelefono"].ToString();

                    Direccion direct = new Direccion();
                    string lat = reader["Latitud"].ToString().Replace('.', ',');
                    string lng = reader["Longitud"].ToString().Replace('.', ','); ;
                    direct.Latitud = Convert.ToDouble(lat);
                    direct.Longitud = Convert.ToDouble(lng);
                    direct.DescripcionUbicacion = reader["DescripcionUbicacion"].ToString();

                    user.CorreoElectronico = reader["CorreoElectronico"].ToString();
                    user.Contrasenna = reader["Contrasenna"].ToString();

                    Tarjeta card = new Tarjeta();
                    card.NumeroTarjeta = reader["NumeroTarjeta"].ToString();
                    card.CVV = reader["CVV"].ToString();
                    card.FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"].ToString());
                    string tipoTarjeta = reader["NombreCategoria"].ToString();
                    if (tipoTarjeta.Equals("VISA"))
                    {
                        card._TipoTarjeta = TipoTarjeta.VISA;
                    }
                    else
                    {
                        card._TipoTarjeta = TipoTarjeta.MASTER_CARD;
                    }
                   (user as Usuario_Comercio).PuntuacionTotal = Convert.ToDouble(reader["Calificacion"]);

                    user._Tarjeta = card;
                    user._Direccion = direct;

                    return user;
                }
            }

            return null;
        }

        /// <summary>
        /// Verifica el correo
        /// </summary>
        /// <param correo electronico="pCorreoElectronico"></param>
        /// <returns></returns>
        public static string PA_VerificaUsuario_Correo(string pCorreoElectronico)
        {
            string estado = "";
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_VerificaUsuario_Correo";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {

                    estado = reader["Numero"].ToString();
                    return estado;
                }
            }

            return "-1";
        }
       /// <summary>
       /// Actualiza contrasenna de usuario
       /// </summary>
       /// <param correo electornico="pCorreoElectronico"></param>
       /// <param contrasenna="pContrasenna"></param>
        public void ActualizaUsuario_Contrasenna(string pCorreoElectronico, string pContrasenna)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.CommandText = "PA_VerificaUsuario_Actualiza_Contrasenna";

                comando.Parameters.AddWithValue("@vCorreoElectronico", pCorreoElectronico);
                comando.Parameters.AddWithValue("@vContrasenna", pContrasenna);

                db.ExecuteNonQuery(comando);
            }
        }


    }
}
