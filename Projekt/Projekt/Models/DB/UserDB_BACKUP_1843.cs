using MySql.Data.MySqlClient;
using System.Data;
using Projekt.Models.UserScripts;
using System;
using System.Collections.Generic;
using System.Data.Common;

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

                cmdInsert.CommandText = "insert into user values (null, @firstname, @lastname, @birthdate, @isAdmin, @email, sha2(@pwd, 512), @gender, @username)";
                cmdInsert.Parameters.AddWithValue("firstname", u.Name);
                cmdInsert.Parameters.AddWithValue("lastname", u.Lastname);
                cmdInsert.Parameters.AddWithValue("birthdate", u.Birthday);
                cmdInsert.Parameters.AddWithValue("gender", Gender);
                cmdInsert.Parameters.AddWithValue("email", u.EMail);
                cmdInsert.Parameters.AddWithValue("username", u.Username);
                cmdInsert.Parameters.AddWithValue("pwd", u.Password);
                cmdInsert.Parameters.AddWithValue("isAdmin", u.isAdmin = 0);
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
<<<<<<< HEAD
            cmd.CommandText = "Select username, password from User where username=@username and password=sha2(@pwd, 512)";
=======
            cmd.CommandText = "Select * from User where username=@username and password=sha1(@pwd)";
>>>>>>> 69ef8b6951a66c98368734a988d29dd9af59a879
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
                        user.Birthday = Convert.ToDateTime(reader["birthday"]);
                        user.EMail = Convert.ToString(reader["email"]);
                        user.Lastname = Convert.ToString(reader["lastname"]);
                        user.Name = Convert.ToString(reader["name"]);
                        user.UserId = Convert.ToInt32(reader["id"]);
                        user.isAdmin = Convert.ToInt32(reader["isAdmin"]);
                        user.Gender = Gender.Male;
                    }

                }
                return user == null ? null : user;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int UserId)
        {
            DbCommand cmdDel = this._connection.CreateCommand();
            cmdDel.CommandText = "DELETE FROM user WHERE id=@UserId";

            DbParameter paramId = cmdDel.CreateParameter();
            paramId.ParameterName = "UserId";
            paramId.Value = UserId;
            paramId.DbType = DbType.Int32;

            cmdDel.Parameters.Add(paramId);

            return cmdDel.ExecuteNonQuery() == 1;
        }

        public List<User> GetAllUser()
        {
            List<User> users = new List<User>();


            DbCommand cmdSelect = this._connection.CreateCommand();
            cmdSelect.CommandText = "SELECT * FROM user";

            using (DbDataReader reader = cmdSelect.ExecuteReader())
            {
                while (reader.Read())
                {
                    users.Add(new User
                    {

                        UserId = Convert.ToInt32(reader["id"]),
                        Name = Convert.ToString(reader["name"]),
                        Lastname = Convert.ToString(reader["lastname"]),
                        Gender = (Gender)Convert.ToInt32(reader["gender"]),
                        Birthday = Convert.ToDateTime(reader["birthday"]),
                        EMail = Convert.ToString(reader["email"]),
                        isAdmin = Convert.ToInt32(reader["isAdmin"]),
                        Username = Convert.ToString(reader["username"]),
                        Password = ""
                    });
                }
            }
            return users;
        }
    }
}
