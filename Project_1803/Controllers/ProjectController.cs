using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project.BLL;
using Project.MODEL;

namespace Project_1803.Controllers
{
    public class ProjectController : Controller
    {
        NewsClassBLL bll = new NewsClassBLL();
        // GET: Project
        public ActionResult Index(int rootid)
        {
            int id = rootid;

            NewsClassModel currModel = bll.GetNewsClass().First(m => m.ClassID == rootid);

            if(currModel.ParentID != 0)
            {
                rootid = Convert.ToInt32(bll.GetNewsClass().First(m => m.ClassID == rootid).ParentPath.Split(',')[1]);
            }
            
            ViewBag.banner = bll.getNewsClassById(rootid).ItemImg;
            

            NewsClassModel Model = bll.getNewsClassById(id);
            ViewBag.ItemName = Model.ClassName;

            ViewBag.Class = bll.GetNewsClass();


            return View(bll.GetNewsClass().Where(m => m.ParentID == Model.ClassID));
        }

        public ActionResult View(int id)
        {
            NewsClassModel currModel = bll.GetNewsClass().First(m => m.ClassID == id);

            int rootid = Convert.ToInt32(bll.GetNewsClass().First(m => m.ClassID == id).ParentPath.Split(',')[1]);

            ViewBag.banner = bll.getNewsClassById(rootid).ItemImg;

            return View(currModel);
        }

        public ActionResult News(int id, int PageIndex = 1)
        {
            NewsBLL newsBLL = new NewsBLL();

            int rootid = Convert.ToInt32(bll.GetNewsClass().First(m => m.ClassID == id).ParentPath.Split(',')[1]);

            ViewBag.banner = bll.getNewsClassById(rootid).ItemImg;

            ViewBag.ItemName = bll.getNewsClassById(id).ClassName;
            

            PageModel<NewsModel> pageData = newsBLL.getList("", Convert.ToInt32(id), PageIndex, 30);

            var page = new StaticPagedList<NewsModel>(pageData.PageData, PageIndex, pageData.PageSize, pageData.TotalCount);

            return View(page);
        }
    }
}