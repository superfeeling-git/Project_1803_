using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.BLL;
using Project.MODEL;
using PagedList;
using PagedList.Mvc;

namespace Project_1803.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index(int PageIndex = 1)
        {
            NewsClassBLL newsClassBLL = new NewsClassBLL();

            NewsBLL newsBLL = new NewsBLL();

            int rootid = Convert.ToInt32(ControllerContext.RouteData.Values["rootid"]);

            var id = ControllerContext.RouteData.Values["id"];

            if (id == null)
            {
                id = newsClassBLL.GetNewsClass().First(m => m.ParentID == rootid).ClassID;
            }

            int PageSize = 20;

            ViewBag.news = newsBLL.getTopNews(Convert.ToInt32(id), 1, false).First();

            PageModel<NewsModel> pageData = newsBLL.getList("", Convert.ToInt32(id), PageIndex, PageSize);

            var page = new StaticPagedList<NewsModel>(pageData.PageData, PageIndex, pageData.PageSize, pageData.TotalCount);

            return View(page);
        }
    }
}