using Project.DAL;
using Project.MODEL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace Project.BLL
{
    public class PhotoBLL
    {
        PhotoDAL dal = new PhotoDAL();


        public bool Add(PhotoModel Model)
        {

            if(!string.IsNullOrWhiteSpace(Model.PhotoImg))
            { 
                string[] p = Model.PhotoImg.Split(',');

                Model.PhotoImg = p.First();

                Model.Pictures = string.Join(",", p.Where(m => m != Model.PhotoImg));
            }

            return dal.Add(Model);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="ClassId"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public PageModel<PhotoModel> getList(string PhotoName, int ClassId, int PageIndex, int PageSize = 10)
        {
            return dal.getList(PhotoName, ClassId, PageIndex, PageSize);
        }

        /// <summary>
        /// 获取单条实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PhotoModel getModel(int id)
        {
            PhotoModel Model = dal.getModel(id);

            List<FileModel> fileList = new List<FileModel>();

            List<string> files = $"{Model.PhotoImg},{Model.Pictures}".Split(',').ToList();

            foreach (var item in files)
            {
                FileModel fileModel = new FileModel();
                //文件名
                fileModel.name = item.Split('/').Last();
                //文件信息
                FileInfo info = new FileInfo(HttpContext.Current.Server.MapPath(item));
                //文件大小
                fileModel.size = info.Length;
                //文件路径
                fileModel.url = item;

                fileList.Add(fileModel);
            }
            
            Model.Files = fileList;

            //获取数组形式的字符串，例："/UploadFile/image/20200930/20200930111607_272.jpg","/UploadFile/image/20200930/20200930111607_285.jpg"
            Model.PhotoImg = string.Join(",", files.Select(m => "\"" + m + "\""));

            return Model;
        }
    }
}
