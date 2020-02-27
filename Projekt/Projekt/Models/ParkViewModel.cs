using System;
using Projekt.Models;
using System.IO;

namespace Projekt.Models
{
    public class ParkViewModel
    {
        public Park Park { get; set; }
        public DirectoryInfo DI { get; set; }
        public FileInfo[] FI { get; set; }

        public ParkViewModel() : this(new Park(), null, null) { }
        public ParkViewModel(Park park, DirectoryInfo directoryInfo, FileInfo[] fileInfo)
        {
            this.Park = park;
            this.DI = directoryInfo;
            this.FI = fileInfo;
        }
    }
}
