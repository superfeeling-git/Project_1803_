using Project.BLL;
using Project.MODEL;
using Project.MODEL.Model;
using Project_1803.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Project.Common;

namespace Project_1803.Areas.Admin.Controllers
{
    public class NewsClassController : Controller
    {
        private IList<ItemType> itemtype = new List<ItemType>();

        public NewsClassController()
        {
            string[] items = ConfigurationManager.AppSettings["itemType"].Split(';');

            for (int i = 0; i < items.Length; i++)
            {
                itemtype.Add(new ItemType { TypeId = i, TypeName = items[i] });
            }
        }


        // GET: Admin/NewsClass
        NewsClassBLL bll = new NewsClassBLL();

        // GET: Admin/SysClass
        public ActionResult Index()
        {
            ViewBag.itemtype = this.itemtype;
            return View(bll.GetNewsClass());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.selectList = new SelectList(this.itemtype, "TypeId", "TypeName");
            
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(NewsClassModel Model)
        {
            return Json(bll.Add(Model), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            NewsClassModel model = bll.getNewsClassById(id);

            ViewBag.selectList = new SelectList(this.itemtype, "TypeId", "TypeName", model.ClassID);

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NewsClassModel Model, FormCollection form)
        {
            Model.CID = Convert.ToInt32(form["CID"]);
            return Json(bll.Update(Model), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ResultInfo info = bll.Delete(id);
            return RedirectToAction("Index", new { info = info.ErrorCode > 0 ? info.Msg : "删除成功" }) ;
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}