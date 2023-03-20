using System.Data;
using System.Data.SqlClient;

namespace RecruApp
{
    internal class DbQueryClass
    {
        private static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = RecruAppDb; Integrated Security = True; Connect Timeout = 30; Encrypt=False";
        public DataTable ExecuteQuery(SqlCommand cmd, out string Exception)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                cmd.Connection = sqlConn;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                try
                {
                    sqlDataAdapter.Fill(dt);
                }
                catch(SqlException sqlEx)
                {
                    Exception = sqlEx.Message;
                    return null;
                }
                sqlDataAdapter.Dispose();
                sqlConn.Close();
            }
            Exception = null;
            return dt;
        }

        public int ExecuteNonQuery(SqlCommand cmd, out string Exception)
        {
            int rowsAffected = 0;
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                cmd.Connection = sqlConn;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                try
                {
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    Exception = sqlEx.Message;
                    return -1;
                }
                sqlDataAdapter.Dispose();
                sqlConn.Close();
            }
            Exception = null;
            return rowsAffected;
        }
    }
}
