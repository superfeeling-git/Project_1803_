using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.BLL;
using Project.MODEL;

namespace Project_1803.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult Index()
        {
            NewsClassBLL newsClassBLL = new NewsClassBLL();

            int rootid = Convert.ToInt32(ControllerContext.RouteData.Values["rootid"]);

            var id = ControllerContext.RouteData.Values["id"];

            if(id == null)
            {
                id = newsClassBLL.GetNewsClass().First(m => m.ParentID == rootid).ClassID;
            }

            return View(newsClassBLL.GetNewsClass().First(m => m.ClassID == Convert.ToInt32(id)));
        }
    }
}