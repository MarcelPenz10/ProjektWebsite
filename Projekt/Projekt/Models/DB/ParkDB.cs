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
                        /*if (reader.IsDBNull(2)) {
                            snowpark.Length = null;
                        }
                        else
                        {
                            snowpark.Length = Convert.ToInt32(reader["length"]);
                        }*/
                        snowpark.ParkId = Convert.ToInt32(reader["id"]);
                        snowpark.Name = Convert.ToString(reader["name"]);
                        snowpark.Length = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2);
                        snowpark.Jumps = reader.IsDBNull(3) == true ? (int?)null : Convert.ToInt32(reader["jumps"]);
                        snowpark.Rails = reader.IsDBNull(4) == true ? (int?)null : Convert.ToInt32(reader["rails"]);
                        snowpark.Cableways = reader.IsDBNull(5) == true ? (int?)null : Convert.ToInt32(reader["cableways"]);
                        snowpark.Open = Convert.ToInt32(reader["status"]);
                        snowpark.Location = Convert.ToString(reader["location"]);
                        snowpark.Description = Convert.ToString(reader["description"]); 
                    }
                }
                List<Comments> comments = GetAllCommentsForOnePark(snowpark.ParkId);
                if (comments != null) {
                    for (int i = 0; i < comments.Count; i++)
                    {
                        snowpark.Comments.Add(comments[i]);
                    }
                }
                else {
                    snowpark.Comments = new List<Comments>();
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
                                Userid = Convert.ToInt32(reader["userid"]),
                                Username = Convert.ToString(reader["username"]),
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

        public bool AddComment(Comments comment)
        {
            if (comment != null)
            {
                try
                {
                    MySqlCommand cmdInsert = this._connection.CreateCommand();

                    cmdInsert.CommandText = "insert into comments values (null, @ParkId, @Comment, @UserId, @username)";
                    cmdInsert.Parameters.AddWithValue("ParkId", comment.Parkid);
                    cmdInsert.Parameters.AddWithValue("UserId", comment.Userid);
                    cmdInsert.Parameters.AddWithValue("Comment", comment.Comment);
                    cmdInsert.Parameters.AddWithValue("username", comment.Username);
                    return cmdInsert.ExecuteNonQuery() == 1;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return false;
        }
        public bool DeleteComment(Comments comment)
        {
            if (comment != null)
            {
                try
                {
                    MySqlCommand cmdDelete = this._connection.CreateCommand();

                    cmdDelete.CommandText = "delete * from comments where id=@id";
                    cmdDelete.Parameters.Add(comment.Commentid);
                    return cmdDelete.ExecuteNonQuery() == 1;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return false;
        }
    }
}
