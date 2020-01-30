using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace Projekt.Models.DB
{
    public class ParkDB : IPark
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

        public Park GetOneSnowpark(int id)
        {
            if (this._connection == null || this._connection.State != ConnectionState.Open)
            {
                return null;
            }

            Park snowpark = new Park();

            MySqlCommand cmd = this._connection.CreateCommand();
            MySqlParameter paraid = new MySqlParameter("ID", id);
            cmd.CommandText = "Select * from Park where id=@ID";
            cmd.Parameters.Add(paraid);

            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        snowpark.ParkId = Convert.ToInt32(reader["id"]);
                        snowpark.Name = Convert.ToString(reader["name"]);
                        snowpark.Length = Convert.ToInt32(reader["length"]);
                        snowpark.Jumps = Convert.ToInt32(reader["jumps"]);
                        snowpark.Rails = Convert.ToInt32(reader["rails"]);
                        snowpark.Cableways = Convert.ToInt32(reader["cableways"]);
                    }
                }
                List<Comments> comments = GetAllCommentsForOnePark(snowpark.ParkId);
                for (int i = 0; i < comments.Count; i++)
                {
                    snowpark.Comments.Add(comments[i]);
                }
                return snowpark == null ? null : snowpark;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<Comments> GetAllCommentsForOnePark(int id)
        {
            if (this._connection == null || this._connection.State != ConnectionState.Open)
            {
                return null;
            }

            List<Comments> comments = new List<Comments>();
            MySqlCommand cmd = this._connection.CreateCommand();
            MySqlParameter paraid = new MySqlParameter("ID", id);
            cmd.CommandText = "Select * from Comments where commentspark_id=@ID";
            cmd.Parameters.Add(paraid);

            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comments.Add(
                            new Comments
                            {
                                Commentid = Convert.ToInt32(reader["id"]),
                                Comment = Convert.ToString(reader["comment"]),
                                //Userid = Convert.ToInt32(reader["userid"]),
                            }
                        );
                    }
                }

                return comments.Count == 0 ? null : comments;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
