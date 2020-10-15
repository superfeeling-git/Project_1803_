using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.BLL;
using Project.MODEL;

namespace Project_1803.Controllers
{
    public class CommonController : Controller
    {
        NewsBLL newsBLL = new NewsBLL();

        NewsClassBLL newsClassBLL = new NewsClassBLL();

        // GET: Common
        public ActionResult Index()
        {
            
            ViewBag.newsList = newsBLL.getTopNews(5, 6, false);
            ViewBag.project = newsClassBLL.GetNewsClass().Where(m => m.ParentID == 37);
            return View();
        }

        public ActionResult SubNav()
        {
            NewsClassBLL newsClassBLL = new NewsClassBLL();

            int rootid;

            object _rootid = ControllerContext.RouteData.Values["rootid"];

            if(_rootid == null)
            {
                //控制器名称
                string ControllerName = ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString().ToLower();

                //Action名称
                String ActionName = ControllerContext.ParentActionViewContext.RouteData.Values["action"].ToString().ToLower();

                if (ControllerName == "news" && ActionName == "view")
                {
                    //1、找到当前新闻对应的分类ID
                    var newsid = Convert.ToInt32(ControllerContext.RouteData.Values["id"]);

                    var classid = newsBLL.getModel(newsid).ClassID;

                    var parentPath = newsClassBLL.getNewsClassById(classid).ParentPath;

                    //2、根据找到的分类ID获取根ID
                    rootid = Convert.ToInt32(parentPath.Split(',')[1]);                   
                }
                else
                { 
                    rootid = 0;
                }
            }
            else
            {
                rootid = Convert.ToInt32(_rootid);
            }

            ViewBag.banner = newsClassBLL.GetNewsClass().First(m => m.ClassID == rootid).ItemImg;

            IList<NewsClassModel> newsClass = newsClassBLL.GetNewsClass();

            ViewBag.List = newsClass.Where(m => m.ParentID == rootid).ToList();

            var id = ControllerContext.RouteData.Values["id"];

            if (id == null)
            {
                id = newsClassBLL.GetNewsClass().First(m => m.ParentID == rootid).ClassID;
            }

            return View(newsClassBLL.GetNewsClass().First(m => m.ClassID == Convert.ToInt32(id)));
        }
    }
}