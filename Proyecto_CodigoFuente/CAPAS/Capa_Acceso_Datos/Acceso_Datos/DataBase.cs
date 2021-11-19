using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


public class DataBase : IDataBase ,IDisposable
{
    public IDbConnection Conexion
    {
        get;
        set;        
    }

    public IDataReader ExecuteReader(IDbCommand pCommand)
    {

        IDataReader lector = null;
        try
        {

            pCommand.Connection = Conexion;
            lector = pCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return lector;
        }
        catch (Exception)
        {
            
            throw;
        }


    }

    public DataSet ExecuteDataSet(IDbCommand pCommand)
    {

        DataSet dsTabla = new DataSet();
        try
        { 

            using (SqlDataAdapter adaptador = new SqlDataAdapter(pCommand as SqlCommand))
            {
                pCommand.Connection = Conexion;
                dsTabla = new DataSet();
                adaptador.Fill(dsTabla);
            }
            return dsTabla;
        }
        catch (Exception)
        {

            // lanzar excepción                     
            throw;
        }
        finally
        {

            if (dsTabla != null)
                dsTabla.Dispose();
        }
    }

    public DataSet ExecuteDataSet(IDbCommand pCommand, String pTabla)
    {

        DataSet dsTabla = new DataSet();
        try
        {

            using (SqlDataAdapter adaptador = new SqlDataAdapter(pCommand as SqlCommand))
            {
                pCommand.Connection = Conexion;
                dsTabla = new DataSet();
                adaptador.Fill(dsTabla, pTabla);
            }
            return dsTabla;
        }
        catch (Exception)
        {

            // lanzar excepción                     
            throw;
        }
        finally
        {

            if (dsTabla != null)
                dsTabla.Dispose();
        }
    }

    public double ExecuteNonQuery(IDbCommand pCommand, IsolationLevel pIsolationLevel)
    {
        using (IDbTransaction transaccion =  Conexion.BeginTransaction(pIsolationLevel))
        {
            double registrosafectados = 0;
            try
            {

                pCommand.Connection = Conexion;
                pCommand.Transaction = transaccion;
                registrosafectados = pCommand.ExecuteNonQuery();

                // Commit a la transacción
                transaccion.Commit();

                return registrosafectados;
            }

            catch (Exception)
            {

                throw;
            }

        }

    }

    public int ExecuteNonQuery(IDbCommand pCommand)
    {

        int registrosafectados = 0;
        try
        {

            pCommand.Connection = Conexion;

            registrosafectados = pCommand.ExecuteNonQuery();

            return registrosafectados;

        }
        catch (Exception)
        {

            throw;
        }
    }

    public object ExecuteScalar(IDbCommand pCommand)
    {        
        object respuesta = null;
        try
        {

            pCommand.Connection = Conexion;

            respuesta = pCommand.ExecuteScalar();

            return respuesta;
        }
        catch (Exception)
        {

            throw;
        }


    }

    public void ExecuteNonQuery(ref IDbCommand pCommand, IsolationLevel pIsolationLevel)
    {
        using (IDbTransaction transaccion = Conexion.BeginTransaction(pIsolationLevel))
        {

            try
            {

                pCommand.Connection = Conexion;
                pCommand.Transaction = transaccion;
                pCommand.ExecuteNonQuery();

                // Commit a la transacción
                transaccion.Commit();


            }

            catch (Exception error)
            {

                throw error;
            }

        }

    }

    
    public void ExecuteNonQuery(List<IDbCommand> pCommands, IsolationLevel pIsolationLevel)
    {
        
        try
        {
            using (IDbTransaction transaccion = Conexion.BeginTransaction(pIsolationLevel))
            {
                foreach (IDbCommand command in pCommands)
                {
                    command.Connection = (Conexion as SqlConnection);
                    command.Transaction = transaccion;
                    // command.CommandTimeout = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ConnectionTimeOut"].ToString());
                    command.ExecuteNonQuery();
                }
                // Commit a la transacción
                transaccion.Commit();
            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
        }

    }
         
    public void Dispose()
    {
        if (Conexion != null)
            Conexion.Close();
    }

    
}

