using MySql.Data.MySqlClient;
using System.Data;
using Projekt.Models.UserScripts;
using System;

namespace Projekt.Models.DB
{
    public class UserDB : IUser
    {
        private string _connectionString = "Server=localhost; Database=ParkWebsite; UID=WebProjekt; password=admin;";
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
            int Gender = 2;
            if (this._connection == null || this._connection.State != ConnectionState.Open)
            {
                return false;
            }

            if (u == null)
            {
                return false;
            }
            if (u.Gender.ToString() == "Male")
            {
                Gender = 0;
            }
            if (u.Gender.ToString() == "Feale")
            {
                Gender = 1;
            }
            if (u.Gender.ToString() == "NotSpecified")
            {
                Gender = 2;
            }
            try
            {
                MySqlCommand cmdInsert = this._connection.CreateCommand();

                cmdInsert.CommandText = "insert into user values (null, @firstname, @lastname, @birthdate, @isAdmin, @email, sha1(@pwd), @gender, @username)";
                cmdInsert.Parameters.AddWithValue("firstname", u.Name);
                cmdInsert.Parameters.AddWithValue("lastname", u.Lastname);
                cmdInsert.Parameters.AddWithValue("birthdate", u.Birthday);
                cmdInsert.Parameters.AddWithValue("gender", Gender);
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

        public User Login (User u)
        {
            if (u == null)
            {
                return null;
            }
            User user = new User();
            MySqlCommand cmd = this._connection.CreateCommand();
            cmd.CommandText = "Select username, password from User where username=@username and password=sha1(@pwd)";
            cmd.Parameters.AddWithValue("username", u.Username);
            cmd.Parameters.AddWithValue("pwd", u.Password);

            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.Username = Convert.ToString(reader["username"]);
                        user.Password = Convert.ToString(reader["password"]);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return user == null ? null : user;

        }
    }
}
