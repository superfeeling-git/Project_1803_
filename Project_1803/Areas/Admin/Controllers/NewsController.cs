using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.MODEL;
using System.IO;
using System.Configuration;
using Project.BLL;
using Microsoft.Ajax.Utilities;
using System.Web.Helpers;
using Project_1803.Auth;

namespace Project_1803.Areas.Admin.Controllers
{
    //[CustomerAuthorize]

    public class NewsController : Controller
    {
        NewsBLL bll = new NewsBLL();

        // GET: Admin/News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string Title, int ClassId = 0, int PageIndex = 1, int PageSize = 10)
        {
            PageModel<NewsModel> page = bll.getList(Title, ClassId, PageIndex, PageSize);

            return View(page);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(NewsModel Model)
        {
            bll.Add(Model);
            return RedirectToAction("Create", new { info = "添加成功" });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(bll.getModel(id));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NewsModel Model)
        {
            bll.Update(Model);
            return RedirectToAction("Index", new { info = "编辑成功" });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ActionResult Delete(string idList)
        {
            return Json(bll.Delete(idList), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}