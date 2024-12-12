using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DatabaseAdapterApp
{
    public class MySQLAdapter : IDatabase
    {
        private MySqlConnection _connection;

        public void Connect()
        {
            _connection = new MySqlConnection("Server=localhost; Database=TestDatabase; Uid=your_username; Pwd=your_password;");


            _connection.Open();
        }

        public void Disconnect()
        {
            _connection.Close();
        }

        public string FetchData()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM YourTable LIMIT 1", _connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader[0].ToString();
        }
    }
}
