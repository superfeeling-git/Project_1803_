using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.BLL;
using Project.MODEL.Model;
using Project_1803.Auth;

namespace Project_1803.Areas.Admin.Controllers
{
    [CustomerAuthorize]
    public class AdminController : Controller
    {
        AdminBLL bll = new AdminBLL();
        RoleBLL roleBll = new RoleBLL();

        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View(bll.getList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Roles = roleBll.GetRoleListByPage();
            return View();
        }

        [HttpPost]
        public ActionResult Create(AdminModel model,FormCollection form)
        {
            bll.Add(model, form["RoleId"]);
            return RedirectToAction("Create");
        }

        public ActionResult CheckUserName(string UserName, int AdminID = 0)
        {
            return Json(bll.CheckUserName(UserName, AdminID), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Roles = roleBll.GetRoleListByPage();

            return View(bll.getModel(id));
        }

        [HttpPost]
        public ActionResult Edit(AdminModel model, FormCollection form)
        {
            bll.Update(model, form["RoleId"]);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            bll.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}