using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.MODEL;
using Project.BLL;
using Project.MODEL.Model;
using Project_1803.Auth;

namespace Project_1803.Areas.Admin.Controllers
{
    [CustomerAuthorize]
    public class SysClassController : Controller
    {
        SysClassBLL bll = new SysClassBLL();

        // GET: Admin/SysClass
        public ActionResult Index()
        {
            return View(bll.GetSysClass());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SysClassModel Model)
        {
            return Json(bll.Add(Model), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(bll.getsysClassById(id));
        }

        [HttpPost]
        public ActionResult Edit(SysClassModel Model,FormCollection form)
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