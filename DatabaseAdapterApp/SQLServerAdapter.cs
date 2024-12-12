using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatabaseAdapterApp
{
    public class SQLServerAdapter : IDatabase
    {
        private SqlConnection _connection;

        public void Connect()
        {
            _connection = new SqlConnection("Server=localhost; Database=TestDatabase; Integrated Security=True;");

            _connection.Open();
        }


        public void Disconnect()
        {
            _connection.Close();
        }

        public string FetchData()
        {
            SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM YourTable", _connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader[0].ToString(); // Повертає перше значення з результату запиту
        }
    }
}
