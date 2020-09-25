using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.MODEL;
using Project.DAL;
using Project.Common;
using Project.MODEL.Model;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;

namespace Project.BLL
{
    public class AdminBLL
    {
        AdminDAL dal = new AdminDAL();
        RoleAdminDAL roleadminDAL = new RoleAdminDAL();
        RoleBLL rollBll = new RoleBLL();

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="Model"></param>
        /// <param name="Code"></param>
        /// <returns></returns>
        public ResultInfo Login(AdminModel Model,string Code)
        {
            string sessioncode = HttpContext.Current.Session["Code"].ToString();

            if(Code.ToLower() != sessioncode.ToLower())
            {
                return new ResultInfo { ErrorCode = 1, Msg = "验证码错误" };
            }

            AdminModel admin = dal.GetByName(Model.UserName);

            if(admin == null)
            {
                return new ResultInfo { ErrorCode = 2, Msg = "用户不存在" };
            }
            else
            {                
                if(admin.Password == Model.Password.Md5())
                {
                    //当前用户的角色信息
                    int[] rolesID = rollBll.getRolesIdByUser(Model.UserName);

                    //生成票据验证数据
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Model.UserName, DateTime.Now, DateTime.Now.AddHours(1), true, string.Join(",", rolesID));

                    //加密票据数据
                    string formsticket = FormsAuthentication.Encrypt(ticket);

                    //使用默认Forms验证名称创建Cookies
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, formsticket);

                    //设置cookies过期时间
                    cookie.Expires = DateTime.Now.AddHours(1);

                    //仅允许HTTP访问
                    cookie.HttpOnly = true;

                    //写入Cookies
                    HttpContext.Current.Response.Cookies.Add(cookie);

                    //
                    string ip = "";
                    if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null) // using proxy
                    {
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP.
                    }
                    else// not using proxy or can't get the Client IP
                    {
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP.
                    }

                    return new ResultInfo { ErrorCode = 0, Msg = "验证通过" };
                }
                else
                {
                    return new ResultInfo { ErrorCode = 3, Msg = "密码错误" };
                }
            }
        }


        public bool CheckUserName(string UserName, int AdminID)
        {
            AdminModel model = dal.GetByName(UserName, AdminID);

            if(model == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="model"></param>
        public void Add(AdminModel model, string idList)
        {
            //加密密码
            model.Password = model.Password.Md5();
            //管理员表记录添加
            int newId = dal.Add(model);
            //中间表
            foreach (var item in idList.Split(','))
            {
                roleadminDAL.Add(new RoleAdminModel { AdminId = newId, RoleId = Convert.ToInt32(item) });
            }
        }

        /// <summary>
        /// 返回所有的管理员
        /// </summary>
        /// <returns></returns>
        public List<AdminModel> getList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 返回当前管理员ID所拥有的角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AdminModel getModel(int id)
        {
            AdminModel model = dal.GetById(id);

            model.RoleId = roleadminDAL.getRoleByAdmin(id);

            return model;
        }

        public void Update(AdminModel model, string idList)
        {
            //加密密码
            if(!string.IsNullOrWhiteSpace(model.Password))
                model.Password = model.Password.Md5();

            //更新管理员表
            dal.Update(model);

            //删除中间表的角色信息
            roleadminDAL.DeleteByAdminId(model);

            //中间表
            foreach (var item in idList.Split(','))
            {
                roleadminDAL.Add(new RoleAdminModel { AdminId = model.AdminID, RoleId = Convert.ToInt32(item) });
            }
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            dal.Delete(id);
        }
    }
}
