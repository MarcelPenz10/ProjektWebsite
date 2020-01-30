using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace Projekt.Models.DB
{
    public class ParkDB : IPark
    {
        private string _connectionString = "Server=localhost; Database=ParkWebsite; UID=root; password=Ghost3131;";
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

        public List<Park> GetAllSnowparks()
        {
            if (this._connection == null || this._connection.State != ConnectionState.Open)
            {
                return null;
            }

            List<Park> snowparks = new List<Park>();

            MySqlCommand cmd = this._connection.CreateCommand();
            cmd.CommandText = "Select * from Park";

            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        snowparks.Add(
                            new Park
                            {
                                ParkId = Convert.ToInt32(reader["id"]),
                                Name = Convert.ToString(reader["name"]),
                                Open = Convert.ToInt32(reader["status"]),
                            }
                        );
                    }
                }

                return snowparks.Count == 0 ? null : snowparks;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
