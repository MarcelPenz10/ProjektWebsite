using System;
namespace Projekt.Models
{
    public class Comments
    {
        public int Parkid { get; set; }
        public int Userid { get; set; }
        public string Username { get; set; }
        public int? Commentid { get; set; }
        public string Comment { get; set; }

        public Comments() : this(0,0,0, "", "") { }
        public Comments(int? commentid, int parkid, int userid, string comment, string username)
        {
            this.Commentid = commentid;
            this.Parkid = parkid;
            this.Userid = userid;
            this.Comment = comment;
            this.Username = username;
        }
        public Comments(int commentid, string comment)
        {
            this.Comment = comment;
            this.Commentid = commentid;
        }
    }
}
