using Project.BLL;
using Project.MODEL;
using Project.MODEL.Model;
using Project_1803.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_1803.Areas.Admin.Controllers
{
    [CustomerAuthorize]
    public class NewsClassController : Controller
    {
        // GET: Admin/NewsClass
        NewsClassBLL bll = new NewsClassBLL();

        // GET: Admin/SysClass
        public ActionResult Index()
        {
            return View(bll.GetNewsClass());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsClassModel Model)
        {
            return Json(bll.Add(Model), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(bll.getNewsClassById(id));
        }

        [HttpPost]
        public ActionResult Edit(NewsClassModel Model, FormCollection form)
        {
            Model.CID = Convert.ToInt32(form["CID"]);
            return Json(bll.Update(Model), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            bll.Delete(id);
            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
    }
}