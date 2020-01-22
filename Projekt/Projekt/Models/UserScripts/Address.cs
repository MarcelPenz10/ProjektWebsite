using System;
namespace Projekt.Models.UserScripts
{
    public class Address
    {
        public string Street { get; set; }
        public int Housenumber
        {
            get { return _housenumber; }
            set
            { if (_housenumber >= 0)
                {
                    _housenumber = value;
                }
            }
        }
        private int _housenumber { get; set; }
        private int _postcode { get; set; }
        public int Postcode
        {
            get { return _postcode; }
            set
            {
                if (_postcode >= 0)
                {
                    _postcode = value;
                }
            }
        }
        public string Place { get; set; }

        public Address () : this ("", 0, 0, "") { }
        public Address (string street, int housenumber, int postcode, string place)
        {
            this.Street = street;
            this.Housenumber = housenumber;
            this.Postcode = postcode;
            this.Place = place;
        }
    }
}
