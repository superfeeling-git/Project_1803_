using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project.BLL;

namespace Project_1803.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomerAuthorizeAttribute : AuthorizeAttribute
    {
        RoleBLL bll = new RoleBLL();

        int[] RolesId;

        /// <summary>
        /// 获取当前Action对应的角色信息
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //控制器名称
            string ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            //Action名称
            string ActionName = filterContext.ActionDescriptor.ActionName;

            //URL
            string URL = $"{ControllerName}/{ActionName}";

            //查询
            RolesId = bll.getRolesIdByURL(URL);

            base.OnAuthorization(filterContext);
        }

        /// <summary>
        /// 进行授权验证
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //没有经过身份验证
            if(!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }

            //从Cookies里获了用户的角色信息
            FormsIdentity identity = (FormsIdentity)httpContext.User.Identity;

            //获取当前用户对应的角色信息
            int[] userRoles = Array.ConvertAll(identity.Ticket.UserData.Split(','), m => Convert.ToInt32(m));


            //判断是否拥有访问权限
            foreach (var item in RolesId)
            {
                if(userRoles.Any(m => m == item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 处理未授权
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);

            RedirectResult redirect = new RedirectResult("/Admin/Error/Index");

            filterContext.Result = redirect;
        }
    }
}