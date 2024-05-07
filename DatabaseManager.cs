using System.Data;
using Microsoft.Data.SqlClient;

namespace Test1
{
    public class DatabaseManager : IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public DatabaseManager()
        {
            _connectionString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True;User Id=s26136;Password=___;Encrypt=False";
             _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public DataTable ExecuteQuery(string sql_query)
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();

            using (var command = new SqlCommand(sql_query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();

                _connection.Dispose();
            }
        }
    }
}