using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace _32NetSet
{
    public class NetSet_DBFactory
    {
    }

    public class DBOperator
    {
        private DBFactory dbf;
        private IDbConnection dbconn;
        public DBOperator(DBFactory dbf)
        {
            this.dbf = dbf;
        }

        public void Open(string connstring)
        {
            dbconn = dbf.GetDBConnection();
            dbconn.ConnectionString = connstring;
            dbconn.Open();
        }

        public void Close()
        {
            dbconn.Close();
        }

        public DataSet ExecSQL(string sql)
        {
            IDbCommand dbc = dbf.GetDBCommand();
            dbc.Connection = dbconn;
            dbc.CommandText = sql;
            IDataAdapter ida = dbf.GetDataAdapter(dbc);
            DataSet ds = new DataSet();
            ida.Fill(ds);
            return ds;
        }
    }

    public abstract class DBFactory
    {
        public abstract IDbConnection GetDBConnection();
        public abstract IDbCommand GetDBCommand();
        public abstract IDataAdapter GetDataAdapter(IDbCommand dic);
    }

    public class OracleDDBFactory : DBFactory
    {
        public override IDataAdapter GetDataAdapter(IDbCommand dic)
        {
            //return new OracleDataAdapter((OracleCommand)dic);
            throw new NotImplementedException();
        }

        public override IDbCommand GetDBCommand()
        {
            //throw new OracleCommand();
            throw new NotImplementedException();
        }

        public override IDbConnection GetDBConnection()
        {
            //throw new OracleConnection();
            throw new NotImplementedException();
        }
    }
}
