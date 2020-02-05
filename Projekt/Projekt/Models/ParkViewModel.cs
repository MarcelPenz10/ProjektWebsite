using System;
using Projekt.Models;
using System.IO;

namespace Projekt.Models
{
    public class ParkViewModel
    {
        public Park Park { get; set; }
        public DirectoryInfo DirectoryInfo { get; set; }
        public FileInfo[] FileInfo { get; set; }

        public ParkViewModel() : this(new Park(), null, null) { }
        public ParkViewModel(Park park, DirectoryInfo directoryInfo, FileInfo[] fileInfo)
        {
            this.Park = park;
            this.DirectoryInfo = directoryInfo;
            this.FileInfo = fileInfo;
        }
    }
}
