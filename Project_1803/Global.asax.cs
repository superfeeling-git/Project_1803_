using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Project_1803
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_Error(object obj,EventArgs e)
        //{
        //    Exception exp = Server.GetLastError();
        //    HttpException httpEx = exp as HttpException;
        //    if(httpEx != null)
        //    {
        //        if (httpEx.ErrorCode == 404)
        //        {
        //            HttpContext.Current.ClearError();
        //            Response.Redirect("/error/index?error=Œ¥’“µΩ");
        //        }
        //    }            
        //    else
        //    {
        //        HttpContext.Current.ClearError();
        //        Response.Redirect("/error/index?error=" + exp.Message);                
        //    }
        //    Response.End();
        //}
    }
}
