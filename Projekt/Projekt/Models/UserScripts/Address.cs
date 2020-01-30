using System;
namespace Projekt.Models.UserScripts
{
    public class Address
    {
        public string Street { get; set; }
        public int Housenumber { get; set; }
        public int Postcode { get; set; }
        public string Place { get; set; }

        public Address() : this ("",0,0,"") { }
        public Address(string street, int housenumber, int postcode, string place)
        {
            this.Street = street;
            this.Housenumber = housenumber;
            this.Postcode = postcode;
            this.Place = place;
        }
    }
}
