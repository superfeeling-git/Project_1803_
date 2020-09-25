using Project.MODEL.Model;
using Project.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Project.Common;

namespace Project.DAL
{
    public class RoleAdminDAL
    {
        public bool Add(RoleAdminModel model)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@RoleId", model.RoleId);
            param[1] = new SqlParameter("@AdminId", model.AdminId);

            try
            {
                string sql = "INSERT INTO RoleAdmin (RoleId,AdminId) VALUES(@RoleId,@AdminId)";
                DbHelper.ExecuteSql(sql, param);
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 根据管理ID获取对应的角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int[] getRoleByAdmin(int id)
        {
            List<RoleAdminModel> RoleList = DbHelper.GetList<RoleAdminModel>("SELECT RoleId FROM RoleAdmin WHERE AdminId = @AdminId", new SqlParameter("@AdminId", id));
            return RoleList.Select(m => m.RoleId).ToArray();
        }

        /// <summary>
        /// 删除管理员对应的角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DeleteByAdminId(AdminModel model)
        {
            return DbHelper.ExecuteSql("DELETE FROM RoleAdmin WHERE AdminId = @AdminId", new SqlParameter("@AdminId", model.AdminID));
        }

    }
}
