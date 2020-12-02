using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CarExamProject
{
    public class SqlAbstractDAO : IAbstractDAO
    {
        private String connectionString;

        public SqlAbstractDAO()
        {
            connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        }

        public IDbConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void ReleaseConnection(IDbConnection connection)
        {
            connection.Close();
        }
    }
}
