using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.BLL;
using Project.MODEL;
using System.Reflection;

namespace Project_1803.Controllers
{
    public class CommonController : Controller
    {

        NewsClassBLL newsClassBLL = new NewsClassBLL();


        // GET: Common
        public ActionResult Index()
        {
            NewsBLL newsBLL = new NewsBLL();
            ViewBag.newsList = newsBLL.getTopNews(5, 6, false);
            ViewBag.project = newsClassBLL.GetNewsClass().Where(m => m.ParentID == 37);
            return View();
        }

        public ActionResult SubNav(int? rootid,int? id)
        {
            //说明没有默认的第一个子分类ID
            if(id == null)
            {
                //找到第一个子分类ID
                id = newsClassBLL.GetNewsClass().First(m => m.ParentID == rootid).ClassID;
            }

            //说明有非Index
            if(rootid == null)
            {
                //控制器名称
                string ControllerName = ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString().ToLower();

                //Action名称
                String ActionName = ControllerContext.ParentActionViewContext.RouteData.Values["action"].ToString().ToLower();

                //1、找到当前新闻对应的分类ID
                var newsid = Convert.ToInt32(ControllerContext.RouteData.Values["id"]);

                //程序集路径
                string AssemblyPath = "Project.BLL";

                //类的名称
                string AssemblyName = (ControllerName == "news" && ActionName == "view") ? "News" : "Photo";

                //反射创建对象
                IBLLBase bll = (IBLLBase)Assembly.Load(AssemblyPath).CreateInstance($"{AssemblyPath}.{AssemblyName}BLL");

                id = bll.getClassID(Convert.ToInt32(id)).ClassID;

                var parentPath = newsClassBLL.getNewsClassById(Convert.ToInt32(id)).ParentPath;

                //2、根据找到的分类ID获取根ID
                rootid = Convert.ToInt32(parentPath.Split(',')[1]);
            }

            ViewBag.banner = newsClassBLL.GetNewsClass().First(m => m.ClassID == rootid).ItemImg;

            ViewBag.List = newsClassBLL.GetNewsClass().Where(m => m.ParentID == rootid).ToList();

            return View(newsClassBLL.GetNewsClass().First(m => m.ClassID == id));
        }

        //public ActionResult SubNav__()
        //{
        //    NewsClassBLL newsClassBLL = new NewsClassBLL();

        //    int rootid,classid = 0;

        //    object _rootid = ControllerContext.RouteData.Values["rootid"];

        //    if(_rootid == null)
        //    {
        //        //控制器名称
        //        string ControllerName = ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString().ToLower();

        //        //Action名称
        //        String ActionName = ControllerContext.ParentActionViewContext.RouteData.Values["action"].ToString().ToLower();

        //        if (ControllerName == "news" && ActionName == "view")
        //        {
        //            //1、找到当前新闻对应的分类ID
        //            var newsid = Convert.ToInt32(ControllerContext.RouteData.Values["id"]);

        //            classid = newsBLL.getModel(newsid).ClassID;

        //            var parentPath = newsClassBLL.getNewsClassById(classid).ParentPath;

        //            //2、根据找到的分类ID获取根ID
        //            rootid = Convert.ToInt32(parentPath.Split(',')[1]);                   
        //        }
        //        else if(ControllerName == "ambassador" && ActionName == "view")
        //        {
        //            //1、找到当前图片对应的分类ID
        //            var newsid = Convert.ToInt32(ControllerContext.RouteData.Values["id"]);

        //            classid = photoBLL.getModel(newsid).ClassID;

        //            var parentPath = newsClassBLL.getNewsClassById(classid).ParentPath;

        //            //2、根据找到的分类ID获取根ID
        //            rootid = Convert.ToInt32(parentPath.Split(',')[1]);
        //        }
        //        else
        //        { 
        //            rootid = 0;
        //        }
        //    }
        //    else
        //    {
        //        rootid = Convert.ToInt32(_rootid);
        //    }

        //    ViewBag.banner = newsClassBLL.GetNewsClass().First(m => m.ClassID == rootid).ItemImg;

        //    ViewBag.List = newsClass.Where(m => m.ParentID == rootid).ToList();

        //    IList<NewsClassModel> newsClass = newsClassBLL.GetNewsClass();

            

        //    var id = ControllerContext.RouteData.Values["id"];

        //    if (id == null)
        //    {
        //        id = newsClassBLL.GetNewsClass().First(m => m.ParentID == rootid).ClassID;
        //    }


        //    //rootid/id

        //    return View(newsClassBLL.GetNewsClass().First(m => m.ClassID == classid));
        //}
    }
}