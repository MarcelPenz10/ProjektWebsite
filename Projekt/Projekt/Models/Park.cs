using System;
namespace Projekt.Models
{
    public class Park
    {
        public int ParkId
        { 
            get { return _parkId; }
            set
            {
                if (_parkId >= 0)
                {
                    _parkId = value;
                }
            } 
        }
        private int _parkId { get; set; }

        public string Name { get; set; }

        public int Length
        {
            get { return _length; }
            set
            {
                if (_length >= 0)
                {
                    _length = value;
                }
            }
        }
        private int _length { get; set; }

        public int Jumps
        {
            get { return _jumps; }
            set
            {
                if (_jumps >= 0)
                {
                    _jumps = value;
                }
            }
        }
        private int _jumps { get; set; }

        public int Rails
        {
            get { return _rails; }
            set
            {
                if (_rails >= 0)
                {
                    _rails = value;
                }
            }
        }
        private int _rails { get; set; } 

        public int Cableways
        {
            get { return _cableways; }
            set
            {
                if (_cableways >= 0)
                {
                    _cableways = value;
                }
            }
        }
        private int _cableways { get; set; }

        public int Open { get; set; }

        public Park () : this (0, "", 0, 0,0, 0, 0) { }
        public Park(int parkId, string name, int length, int jumps, int rails, int cableways, int open)
        {
            this.ParkId = parkId;
            this.Name = name;
            this.Length = length;
            this.Jumps = jumps;
            this.Rails = rails;
            this.Cableways = cableways;
            this.Open = open; 
        }
    }

    enum Line
    {
        FamilyLine, ProLine, MediumLine, NoobLine, notSpecified
    }
}
