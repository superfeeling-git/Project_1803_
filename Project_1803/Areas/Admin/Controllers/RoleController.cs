using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.MODEL;
using Project.BLL;
using System.ComponentModel;
using Project.MODEL.Model;
using Project_1803.Auth;

namespace Project_1803.Areas.Admin.Controllers
{
    [CustomerAuthorize]

    public class RoleController : Controller
    {
        SysClassBLL bll = new SysClassBLL();
        RoleBLL roleBll = new RoleBLL();

        // GET: Admin/Role
        public ActionResult Index()
        {
            return View(roleBll.GetRoleListByPage());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.sys = bll.GetSysClass();
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            roleBll.Add(form["RoleName"], form["idList"]);
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(roleBll.getRole(id));
        }

        [HttpPost]
        public ActionResult Edit(RoleModel model, FormCollection form)
        {
            int[] idList = Array.ConvertAll(form["idList"].Split(','), m => Convert.ToInt32(m));
            model.sysClassID = idList;
            roleBll.UpdateRole(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            roleBll.DeleteByID(id);
            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult getJson(string idList)
        {
            string[] idArr = new string[] { };

            if(!string.IsNullOrWhiteSpace(idList))
            {
                idArr = idList.Split(',');
            }

            return Json(bll.GetSysClass().Select(m => new 
            {
                id = m.ClassID,
                pId = m.ParentID,
                name = m.ClassName,
                open = true,
                @checked = idArr.Any(id => id == m.ClassID.ToString())
            }), JsonRequestBehavior.AllowGet);
        }
    }
}