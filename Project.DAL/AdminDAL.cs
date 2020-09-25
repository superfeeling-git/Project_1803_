using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.MODEL;
using Project.MODEL.Model;
using Project.Common;
using System.Data;

namespace Project.DAL
{
    public class AdminDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int Add(AdminModel Model)
        {
            string sql = "INSERT INTO [Admin] (UserName,Password) VALUES(@UserName,@Password);SELECT @@IDENTITY";

            SqlParameter[] sqlParm = {
                new SqlParameter("@UserName",Model.UserName),
                new SqlParameter("@Password",Model.Password)
            };

            return DbHelper.ExecuteScalar(sql, sqlParm);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int Delete(int AdminId)
        {
            string sql = "DELETE FROM [Admin] WHERE AdminID = @AdminID";

            return DbHelper.ExecuteSql(sql, new SqlParameter("@AdminID",AdminId));
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public AdminModel GetByName(string UserName)
        {
            string Sql = "SELECT * FROM [Admin] WHERE UserName = @UserName";
            return DbHelper.GetModel<AdminModel>(Sql, new SqlParameter("@UserName", UserName));
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public AdminModel GetByName(string UserName, int AdminID)
        {
            SqlParameter[] sqlParm = {
                new SqlParameter("@UserName",UserName),
                new SqlParameter("@AdminID",AdminID)
            };

            string Sql = "SELECT * FROM [Admin] WHERE UserName = @UserName AND AdminID != @AdminID";
            return DbHelper.GetModel<AdminModel>(Sql, sqlParm);
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public AdminModel GetById(int AdminId)
        {
            string Sql = "SELECT * FROM [Admin] WHERE AdminID = @AdminID";
            return DbHelper.GetModel<AdminModel>(Sql, new SqlParameter("@AdminID", AdminId));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int Update(AdminModel Model)
        {
            string sql = "";
            if(string.IsNullOrWhiteSpace(Model.Password))
            {
                sql = "UPDATE[Admin] SET UserName = @UserName WHERE AdminID = @AdminID";
            }
            else
            {
                sql = "UPDATE[Admin] SET UserName = @UserName,[Password] = @Password WHERE AdminID = @AdminID";
            }

            SqlParameter[] sqlParm = {
                new SqlParameter("@AdminID",Model.AdminID),
                new SqlParameter("@UserName",Model.UserName),
                new SqlParameter("@Password",SqlDbType.NVarChar,50)
            };

            if(string.IsNullOrWhiteSpace(Model.Password))
            {
                sqlParm[2].Value = DBNull.Value;
            }
            else
            {
                sqlParm[2].Value = Model.Password;
            }

            return DbHelper.ExecuteSql(sql, sqlParm);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public List<AdminModel> GetList()
        {
            string Sql = "SELECT * FROM [Admin] ORDER BY AdminID";
            return DbHelper.GetList<AdminModel>(Sql);
        }
    }
}
