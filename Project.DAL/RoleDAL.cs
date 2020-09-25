/*------------------------------------------------
// File Name:Role.cs
// File Description:Role SQL Server DataBase Access
// Author:feeling
// Create Time:2020/09/14 15:32:53
//------------------------------------------------*/

using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using Project.MODEL.Model;
using Project.Common;

namespace De.DAL
{
    /// <summary>
    /// Role
    /// </summary>
    public class RoleDAL
    {
        public RoleDAL() { }

        #region Role Interface Implement
        /// <summary>
        /// Add Role
        /// </summary>
        /// <param name="model">Role Model</param>
        /// <returns>True or False</returns>
        public int Add(RoleModel model)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@RoleName", model.RoleName);

            try
            {
                string sql = "INSERT INTO Role (RoleName) VALUES(@RoleName);SELECT @@IDENTITY";                

                return DbHelper.ExecuteScalar(sql, param);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return 0;
            }
        }

        /// <summary>
        /// Delete Role By ID
        /// </summary>
        /// <param name="id">Role ID</param>
        /// <returns>True or False</returns>
        public bool DeleteByID(int RoleID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RoleID", RoleID);
            try
            {
                string sql = "DELETE FROM Role WHERE RoleID = @RoleID";
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
        /// Delete Role By Name
        /// </summary>
        /// <param name="name">Role Name</param>
        /// <returns>True or False</returns>
        public bool DeleteByName(string name)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", name);
            try
            {
                //SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "SP_DelRoleByName", param);
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 更新角色信息（名称）
        /// </summary>
        /// <param name="model">Role Model</param>
        /// <returns>True or False</returns>
        public bool Update(RoleModel model)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@RoleID", model.RoleID);
            param[1] = new SqlParameter("@RoleName", model.RoleName);
            try
            {
                string sql = "UPDATE Role SET RoleName = @RoleName WHERE RoleID = @RoleID";
                DbHelper.ExecuteScalar(sql, param);
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Get Role By ID
        /// </summary>
        /// <param name="id">Role ID</param>
        /// <returns>Role Model</returns>
        public RoleModel GetRoleModelByID(int RoleID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RoleID", RoleID);

            return DbHelper.GetModel<RoleModel>("SELECT * FROM Role WHERE RoleID = @RoleID", param);
        }

        /// <summary>
        /// 根据URL获取对应的角色
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public int[] getRolesIdByURL(string URL)
        {
            string sql = @"select [Role].RoleID from SysClass INNER JOIN SysRole
                        ON SysClass.ClassID = SysRole.ClassID
                        INNER JOIN [Role] ON SysRole.RoleID = [Role].RoleID
                        WHERE URL = @URL";

            return DbHelper.GetList<RoleModel>(sql, new SqlParameter("@URL", URL)).Select(m => m.RoleID).ToArray();
        }

        /// <summary>
        /// 根据用户获取对应的角色
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public int[] getRolesIdByUser(string UserName)
        {
            string sql = @"SELECT * FROM [Admin] INNER JOIN RoleAdmin
                            ON [Admin].AdminID = RoleAdmin.AdminID
                            INNER JOIN [Role] ON [Role].RoleID = RoleAdmin.RoleID
                            WHERE UserName = @UserName";

            return DbHelper.GetList<RoleModel>(sql, new SqlParameter("@UserName", UserName)).Select(m => m.RoleID).ToArray();
        }

        /// <summary>
        /// 根据角色获取对应的菜单项
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public int[] getSysClassByRole(string idList)
        {
            string sql = $@"SELECT ClassID FROM SysRole INNER JOIN [Role] 
                            ON SysRole.RoleID = [Role].RoleID
						    WHERE [Role].RoleID IN({idList})";

            return DbHelper.GetList<SysClassModel>(sql).Select(m=>m.ClassID).ToArray();
        }


        /// <summary>
        /// 获取全部角色信息
        /// </summary>
        /// <returns>Role List</returns>
        public IList<RoleModel> GetRoleListByPage()
        {
            return DbHelper.GetList<RoleModel>("SELECT * FROM Role ORDER BY RoleID");
        }

        #endregion
    }
}
