using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RepositoryClassLibrary.Helper
{
    public class SqlDatabaseService
    {
        private SqlConnection sqlConnection = null;
        public SqlDatabaseService()
        {
            String connectionString = @ConfigurationManager.AppSettings["ConnectionString"];
            if (this.sqlConnection == null) {
                this.sqlConnection = new SqlConnection(connectionString);
                OpenConnection(this.sqlConnection);
            }
        }
        public void OpenConnection(SqlConnection Connection)
        {
            Connection.Open();
        }
        public void CloseConnection()
        {
            this.sqlConnection.Close();
        }
        public SqlConnection GetSqlConnection()
        {
            return this.sqlConnection;
        }
    }
}
