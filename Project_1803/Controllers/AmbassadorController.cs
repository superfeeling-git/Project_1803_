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
    public class AmbassadorController : Controller
    {
        NewsClassBLL newsClassBLL = new NewsClassBLL();

        PhotoBLL photoBLL = new PhotoBLL();

        // GET: Ambassador
        public ActionResult Index(int PageIndex = 1)
        {
            int rootid = Convert.ToInt32(ControllerContext.RouteData.Values["rootid"]);

            var id = ControllerContext.RouteData.Values["id"];

            if (id == null)
            {
                id = newsClassBLL.GetNewsClass().First(m => m.ParentID == rootid).ClassID;
            }

            int PageSize = 20;

            PageModel<PhotoModel> pageData = photoBLL.getList(ClassId: Convert.ToInt32(id), PageIndex: PageIndex, PageSize: PageSize,PhotoName:"");

            var page = new StaticPagedList<PhotoModel>(pageData.PageData, PageIndex, pageData.PageSize, pageData.TotalCount);

            return View(page);
        }

        public ActionResult View(int id)
        {
            return View(photoBLL.getModel(id));
        }
    }
}