using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project.MODEL.Model;
using Project.BLL;

namespace Project_1803.Areas.Admin.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        RoleBLL bll = new RoleBLL();
        // GET: Admin/Default
        public ActionResult Index()
        {
            string LoginName = User.Identity.Name;

            FormsIdentity identity = (FormsIdentity)User.Identity;

            //获取当前用户对应的角色信息
            //根据用户名或者角色，查询对应的菜单项
            //通过MODEL传递
            return View(bll.getSysClassByRole(identity.Ticket.UserData));
        }

        public ActionResult Right()
        {
            return View();
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}