using Project_1803.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.MODEL;
using Project.BLL;

namespace Project_1803.Areas.Admin.Controllers
{
    [CustomerAuthorize]
    public class PhotoController : Controller
    {
        PhotoBLL bll = new PhotoBLL();

        // GET: Admin/Photo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string PhotoName, int ClassId = 0, int PageIndex = 1, int PageSize = 10)
        {
            PageModel<PhotoModel> page = bll.getList(PhotoName, ClassId, PageIndex, PageSize);

            return View(page);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PhotoModel Model)
        {
            PhotoBLL bll = new PhotoBLL();
            bll.Add(Model);

            return RedirectToAction("Create", new { info = "添加成功" });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(bll.getModel(id));
        }

        [HttpPost]
        public ActionResult Edit(PhotoModel Model)
        {
            throw new NotImplementedException();
        }
    }
}