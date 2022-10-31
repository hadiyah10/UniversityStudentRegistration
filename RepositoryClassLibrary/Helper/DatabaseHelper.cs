using RepositoryClassLibrary.Helper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace RepositoryClassLibrary.Helper
{
    public  class DatabaseHelper
    {        
        public DataTable GetDataFromQuery(string query)
        {
            SqlDatabaseService sqldb = new SqlDatabaseService();
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(query, sqldb.GetSqlConnection())) {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }
            sqldb.CloseConnection();
            return dt;
        }

        public DataTable GetDataWithConditions(string query, List<SqlParameter> parameters)
        {
            SqlDatabaseService sqldb = new SqlDatabaseService();
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(query, sqldb.GetSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    parameters.ForEach(parameter => {
                        cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    });
                }
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }

            sqldb.CloseConnection();

            return dt;
        }

        public bool InsertUpdateData(string query, List<SqlParameter> parameters)
        {
            var rowAffected = 0;

            SqlDatabaseService sqldb = new SqlDatabaseService();
            using (SqlCommand cmd = new SqlCommand(query, sqldb.GetSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    parameters.ForEach(parameter => {
                        cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    });
                }
                rowAffected = cmd.ExecuteNonQuery();
            }
            sqldb.CloseConnection();
            var result = rowAffected > 0 ? true : false;
            return result;
        }

        public  DataTable GetData(string query)
        {

            SqlDatabaseService sqldb = new SqlDatabaseService();
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(query, sqldb.GetSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }

            sqldb.CloseConnection();

            return dt;
        }



    }
}
