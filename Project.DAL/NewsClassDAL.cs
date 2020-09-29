using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Common;
using Project.MODEL;
using Project.MODEL.Model;

namespace Project.DAL
{
    public class NewsClassDAL
    {
        /// <summary>
        /// 更新URL
        /// </summary>
        /// <param name="model">SysClass Model</param>
        /// <returns>True or False</returns>
        public bool Update(NewsClassModel model)
        {
            try
            {
                string sql = "UPDATE NewsClass SET LinkUrl = @LinkUrl,ItemType = @ItemType,Content = @Content,ItemImg = @ItemImg WHERE ClassID = @ClassID";
                DbHelper.ExecuteSql(sql, new SqlParameter[] {
                    new SqlParameter("@ClassID",model.ClassID),
                    new SqlParameter("@LinkUrl",model.LinkUrl),
                    new SqlParameter("@ItemType",model.ItemType),
                    new SqlParameter("@Content",model.Content),
                    new SqlParameter("@ItemImg",model.ItemImg)
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
