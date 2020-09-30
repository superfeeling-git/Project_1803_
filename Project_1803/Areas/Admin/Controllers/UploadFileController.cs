using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_1803.Areas.Admin.Controllers
{
    public class UploadFileController : Controller
    {
        /// <summary>
        /// 上传文件的处理
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public ActionResult Index(HttpPostedFileBase file)
        {
            string fileName = file.FileName;

            //获取文件扩展名
            string extName = Path.GetExtension(fileName);

            //获取配置文件中允许的扩展名
            string[] AllowExtName = ConfigurationManager.AppSettings["image"].Split(',');

            //对文件类型进行判断
            if (!AllowExtName.Any(m => m.ToLower() == extName.ToLower()))
            {
                return Json(new
                {
                    result = "failed",               // 文件上传失败
                    message = "不允许的文件类型"    // 用于在界面上提示用户的消息
                }, JsonRequestBehavior.AllowGet);
            }

            //上传文件的大小（单位：KB）
            int fileSize = file.ContentLength / 1024;

            //获取配置文件中允许的大小
            int AllowSize = Convert.ToInt32(ConfigurationManager.AppSettings["imageMaxFile"]);

            //判断客户端上传文件的大小
            if (fileSize > AllowSize)
            {
                return Json(new
                {
                    result = "failed",               // 文件上传失败
                    message = "超过允许上传的大小"    // 用于在界面上提示用户的消息
                }, JsonRequestBehavior.AllowGet);
            }


            //创建上传的文件夹
            //规则：
            //（1）、重命名文件，新的文件名：当前时间命名，或者加随机数；GUID
            //（2）、/UploadFile/images/202009/38297492374.jpg
            //（2）、/UploadFile/video/202009/38297492374.jpg
            //（2）、/UploadFile/download/202009/38297492374.jpg

            //创建上传文件的目录
            string SavePath = $"/UploadFile/image/{DateTime.Now.ToString("yyyyMMdd")}";
            if (!Directory.Exists(Server.MapPath(SavePath)))
            {
                Directory.CreateDirectory(Server.MapPath(SavePath));
            }

            //上传文件的完整路径
            string SaveFileName = $"{SavePath}/{DateTime.Now.ToString("yyyyMMddHHmmss_fff")}{extName}";

            //保存文件的路径
            string SaveFilePath = Server.MapPath(SaveFileName);

            //保存文件
            file.SaveAs(SaveFilePath);

            //删除文件
            try
            {
                string oldName = Server.MapPath(Request.Form["oldName"]);
                if (System.IO.File.Exists(oldName))
                {
                    System.IO.File.Delete(oldName);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            //向客户端返回文件名
            return Json(new
            {
                result = "ok",     // 文件上传成功
                //status = 200,
                url = SaveFileName        // 文件的下载地址
            }, JsonRequestBehavior.AllowGet);
        }
    }
}