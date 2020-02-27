using System;
using Projekt.Models.UserScripts;

namespace Projekt.Models.UserScripts
{
    public class User
    {
        private int _userid;
        public int UserId
        {
            get { return _userid; }
            set
            {
                if (_userid >= 0)
                {
                    _userid = value;
                }
            }
        }

        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public int isAdmin { get; set; }
        public string EMail {get; set;}
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string Username { get; set; }

        public User () : this (0, "", "", DateTime.Now, 0, "", "", Gender.NotSpecified, "") { }
        public User(int userid, string name, string lastname, DateTime birthday, int isadmin, string eMail, string password, Gender gender, 
            string username)
        {
            this.UserId = userid;
            this.Name = name;
            this.Lastname = lastname;
            this.Birthday = birthday;
            this.isAdmin = isadmin;
            this.EMail = eMail;
            this.Password = password;
            this.Gender = gender;
            this.Username = username;
        }

    }

    public enum Gender
    {
        Male, Female, NotSpecified
    }
}
