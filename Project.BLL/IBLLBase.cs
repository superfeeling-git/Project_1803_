using Project.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL
{
    public interface IBLLBase
    {
        IModelBase getClassID(int id);
    }
}
