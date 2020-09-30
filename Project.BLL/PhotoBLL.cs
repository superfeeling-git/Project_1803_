using Project.DAL;
using Project.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL
{
    public class PhotoBLL
    {
        public bool Add(PhotoModel Model)
        {
            PhotoDAL dal = new PhotoDAL();
            string[] p = Model.PhotoImg.Split(',');
            Model.PhotoImg = "4";

            Model.PhotoImg = "取第一张";

            Model.Pictures = "";
            return dal.Add(Model);
        }
    }
}
