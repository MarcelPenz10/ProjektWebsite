using System;
using System.Collections.Generic;
namespace Projekt.Models
{
    public class Park
    {
        public int ParkId
        { 
            get { return _parkId; }
            set
            {
                if (value >= 0)
                {
                    _parkId = value;
                }
            } 
        }
        private int _parkId { get; set; }

        public string Name { get; set; }

        public int? Length
        {
            get { return _length; }
            set
            {
                if (value >= 0)
                {
                    _length = value;
                }
                else if (value == null)
                {
                    _length = -1;
                }
            }
        }
        private int? _length  { get; set; }

        public int? Jumps
        {
            get { return _jumps; }
            set
            {
                if (value >= 0)
                {
                    _jumps = value;
                }
                else if (value == null)
                {
                    _jumps = -1; 
                }
            }
        }
        private int? _jumps { get; set; }

        public int? Rails
        {
            get { return _rails; }
            set
            {
                if (value >= 0)
                {
                    _rails = value;
                }
                else if (value == null)
                {
                    _rails = -1;
                }
            }
        }
        private int? _rails { get; set; } 

        public int? Cableways
        {
            get { return _cableways; }
            set
            {
                if (value >= 0)
                {
                    _cableways = value;
                }
                else if (value == null)
                {
                    _cableways = -1;
                }
            }
        }
        private int? _cableways { get; set; }

        public int Open { get; set; }

        public List<Comments> Comments { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public Park () : this (0, "", 0, 0,0, 0, 0, new List<Comments>(), "", "") { }
        public Park(int parkId, string name, int length, int jumps, int rails, int cableways, int open, List<Comments> comments, string location, string description)
        {
            this.ParkId = parkId;
            this.Name = name;
            this.Length = length;
            this.Jumps = jumps;
            this.Rails = rails;
            this.Cableways = cableways;
            this.Open = open;
            this.Comments = comments;
            this.Location = location;
            this.Description = description;
        }
        public Park(int parkid, string name, int open)
        {
            this.ParkId = parkid;
            this.Name = name;
            this.Open = open;
        }
    }

    enum Line
    {
        FamilyLine, ProLine, MediumLine, NoobLine, notSpecified
    }
}
