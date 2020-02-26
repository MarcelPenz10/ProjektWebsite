using MySql.Data.MySqlClient;
using System.Data;
using Projekt.Models.UserScripts;
using System;

namespace Projekt.Models.DB
{
    public class UserDB : IUser
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
        public bool Insert (User u)
        {
            if (this._connection == null || this._connection.State != ConnectionState.Open)
            {
                return false;
            }

            if (u == null)
            {
                return false;
            }

            try
            {
                // Command (Befehl) erzeugen
                MySqlCommand cmdInsert = this._connection.CreateCommand();

                cmdInsert.CommandText = "insert into users values (null, @firstname, @lastname, @birthdate, @gender, @email, @username, sha1(@pwd), @isAdmin)";
                cmdInsert.Parameters.AddWithValue("firstname", u.Name);
                cmdInsert.Parameters.AddWithValue("lastname", u.Lastname);
                cmdInsert.Parameters.AddWithValue("birthdate", u.Birthday);
                cmdInsert.Parameters.AddWithValue("gender", u.Gender);
                cmdInsert.Parameters.AddWithValue("email", u.EMail);
                cmdInsert.Parameters.AddWithValue("username", u.Username);
                cmdInsert.Parameters.AddWithValue("pwd", u.Password);
                cmdInsert.Parameters.AddWithValue("isAdmin", u.isAdmin == 0);
                return cmdInsert.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
