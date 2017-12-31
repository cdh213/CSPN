using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSPN.Factory
{
    /// <summary>
    /// Connection工厂用于实例化对应的IDbConnection对象，传递给Dapper。
    /// </summary>
    public class ConnectionFactory
    {
        private static readonly string connectionName = ConfigurationManager.AppSettings["ConnectionName"];
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public static IDbConnection CreateConnection()
        {
            IDbConnection conn;
            switch (connectionName)
            {
                case "SQLServer":
                    conn = new SqlConnection(connStr);
                    break;
                case "Access":
                    conn = new OleDbConnection(connStr);
                    break;
                default:
                    conn = new SqlConnection(connStr);
                    break;
            }
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
