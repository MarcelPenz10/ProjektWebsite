using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace Projekt.Models.DB
{
    public class ParkDB : IPark
    {
        private string _connectionString = "Server=localhost; Database=ParkWebsite; UID=root;";
        private MySqlConnection _connection;  

        public void Open()
        {
            if (this._connection == null)
            {
                this._connection = new MySqlConnection(this._connectionString);
            }
            if (this._connection.State != ConnectionState.Open)
            {
                this._connection.Open();
            }
        }

        public void Close()
        {
            if ((this._connection != null) && (this._connection.State == ConnectionState.Open))
            {
                this._connection.Close();
            }
        }


    }
}
