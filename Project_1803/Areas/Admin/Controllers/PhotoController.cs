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
        // GET: Admin/Photo
        public ActionResult Index()
        {
            return View();
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
    }
}