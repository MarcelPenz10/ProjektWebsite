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
        public Address Address { get; set; }
        public string EMail {get; set;}
        public string Password { get; set; }
        public Gender Gender { get; set; }

        public User () : this (0, "", "", DateTime.Now, new Address(), "", "", Gender.notSpecified) { }
        public User(int userid, string name, string lastname, DateTime birthday, Address address, string eMail, string password, Gender gender)
        {
            this.UserId = userid;
            this.Name = name;
            this.Lastname = lastname;
            this.Birthday = birthday;
            this.Address = address;
            this.EMail = eMail;
            this.Password = password;
            this.Gender = gender;
        }

    }

    public enum Gender
    {
        male, female, notSpecified
    }
}
