/*------------------------------------------------
// File Name:SysClass.cs
// File Description:SysClass SQL Server DataBase Access
// Author:feeling
// Create Time:2020/09/10 14:00:26
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
    /// SysClass
    /// </summary>
    public class SysClassDAL
    {
        /// <summary>
        /// 更新URL
        /// </summary>
        /// <param name="model">SysClass Model</param>
        /// <returns>True or False</returns>
        public bool Update(SysClassModel model)
        {
            try
            {
                string sql = "UPDATE SysClass SET URL = @URL,IsShow = @IsShow WHERE ClassID = @ClassID";
                DbHelper.ExecuteSql(sql, new SqlParameter[] {
                    new SqlParameter("@ClassID",model.ClassID),
                    new SqlParameter("@URL",model.URL),
                    new SqlParameter("@IsShow",model.IsShow)
                });
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }
    }
}
