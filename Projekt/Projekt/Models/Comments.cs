using System;
namespace Projekt.Models
{
    public class Comments
    {
        public int Parkid { get; set; }
        public int Uerid { get; set; }
        public int Commentid { get; set; }
        public string Comment { get; set; }

        public Comments() : this(0,0,0, "") { }
        public Comments(int commentid, int parkid, int userid, string comment)
        {
            this.Commentid = commentid;
            this.Parkid = parkid;
            this.Uerid = userid;
            this.Comment = comment;
        }
    }
}
