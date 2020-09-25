using Project.Common;
using Project.MODEL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class SysRoleDAL
    {
        /// <summary>
        /// Add SysRole
        /// </summary>
        /// <param name="model">SysRole Model</param>
        /// <returns>True or False</returns>
        public bool Add(SysRoleModel model)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@ClassID", model.ClassID);
            param[1] = new SqlParameter("@RoleID", model.RoleID);

            try
            {
                string sql = "INSERT INTO SysRole (ClassID,RoleID) VALUES(@ClassID,@RoleID)";
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
        /// 根据角色ID获取对应的菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int[] getSysClassByRoleId(int id)
        {
            List<SysRoleModel> sysList = DbHelper.GetList<SysRoleModel>("SELECT ClassID FROM SysRole WHERE RoleID = @RoleID", new SqlParameter("@RoleID", id));
            return sysList.Select(m => m.ClassID).ToArray();
        }

        /// <summary>
        /// 删除角色对应的菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DeleteByRoleId(RoleModel model)
        {
            return DbHelper.ExecuteSql("DELETE FROM SysRole WHERE RoleID = @RoleID", new SqlParameter("@RoleID", model.RoleID));
        }
    }
}
