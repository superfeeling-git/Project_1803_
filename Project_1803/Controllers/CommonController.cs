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
            ViewBag.newsList = newsBLL.getTopNews(5, 6);
            ViewBag.project = newsClassBLL.GetNewsClass().Where(m => m.ParentID == 37);
            return View();
        }
    }
}