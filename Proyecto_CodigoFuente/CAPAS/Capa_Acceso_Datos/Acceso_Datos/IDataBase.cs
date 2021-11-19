using System;
using System.Collections.Generic;
using System.Data;

public interface IDataBase: IDisposable 
{
    IDbConnection Conexion { get; set; }
    double ExecuteNonQuery(IDbCommand pCommand, IsolationLevel pIsolationLevel);
    void ExecuteNonQuery(ref IDbCommand pCommand, IsolationLevel pIsolationLevel);
    void ExecuteNonQuery(List<IDbCommand> pCommands, IsolationLevel pIsolationLevel);
    int ExecuteNonQuery(IDbCommand pCommand);
    IDataReader ExecuteReader(IDbCommand pSqlCommand);
    DataSet ExecuteDataSet(IDbCommand pSqlCommand, string pTabla);
    DataSet ExecuteDataSet(IDbCommand pCommand);
    object ExecuteScalar(IDbCommand pSQLCommand);

}