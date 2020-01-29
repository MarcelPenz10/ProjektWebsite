using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekt.Models.UserScripts;

namespace Projekt.Models.UserScripts
{
    public class Kontakt
    {
      
        public string Name { get; set; }
        public string Lastname { get; set; }
        public Address Address { get; set; }
        public string EMail { get; set; }

        public Kontakt() : this("", "", new Address(), "") { }
        public Kontakt(string name, string lastname, Address address, string eMail)
        {
            this.Name = name;
            this.Lastname = lastname;
            this.Address = address;
            this.EMail = eMail;
        }

    }




}
