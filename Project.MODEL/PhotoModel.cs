using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL
{
    public class PhotoModel
    {
        public int PhotoID { get; set; }
        public int ClassID { get; set; }
        public string PhotoName { get; set; }
        public int Hit { get; set; }
        public DateTime AddTime { get; set; }
        public string PhotoImg { get; set; }
        public bool IsHome { get; set; }
        public string Pictures { get; set; }
        public string ClassName { get; set; }
        public List<FileModel> Files { get; set; }
        public string imgName { get; set; }
    }
}
