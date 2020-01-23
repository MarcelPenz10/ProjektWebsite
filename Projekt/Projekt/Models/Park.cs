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


    }

    enum Line
    {
        FamilyLine, ProLine, MediumLine, NoobLine, notSpecified
    }
}
