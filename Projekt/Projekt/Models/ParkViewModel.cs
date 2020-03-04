using System;
using System.IO;

namespace Projekt.Models
{
    public class ParkViewModel
    {
        public Park Park { get; set; }
        public DirectoryInfo DI { get; set; }
        public FileInfo[] FI { get; set; }
        public string NewComment { get; set; }

        public ParkViewModel() : this(new Park(), null, null, "") { }
        public ParkViewModel(Park park, DirectoryInfo directoryInfo, FileInfo[] fileInfo, string newcomment)
        {
            this.Park = park;
            this.DI = directoryInfo;
            this.FI = fileInfo;
            this.NewComment = newcomment;
        }
    }
}
