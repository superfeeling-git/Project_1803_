using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL
{
    public class HomeModel
    {
        public IEnumerable<NewsClassModel> AllClass { get; set; }
        public IEnumerable<NewsClassModel> NewsClass { get; set; }
        public IEnumerable<NewsClassModel> PhotoClass { get; set; }
    }
}
