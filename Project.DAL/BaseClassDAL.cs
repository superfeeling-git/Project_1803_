using Project.Common;
using Project.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class BaseClassDAL
    {
        private string _tableName;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tableName"></param>
        public BaseClassDAL(string tableName) {
            this._tableName = tableName;
        }

        #region NewsClass Interface Implement
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">NewsClass Model</param>
        /// <returns>True or False</returns>
        public int Add(BaseClassModel model)
        {
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@ClassName", model.ClassName);
            param[1] = new SqlParameter("@ParentID", model.ParentID);
            param[2] = new SqlParameter("@Depth", model.Depth);
            param[3] = new SqlParameter("@ParentPath", model.ParentPath);

            string sql = $"INSERT INTO {_tableName} (ClassName,ParentID,Depth,ParentPath) VALUES(@ClassName,@ParentID,@Depth,@ParentPath);select @@identity;";

            return DbHelper.ExecuteScalar(sql, param);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">NewsClass ID</param>
        /// <returns>True or False</returns>
        public bool DeleteByID(int ClassID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ClassID", ClassID);
            try
            {
                string sql = $"DELETE FROM {_tableName} WHERE ClassID = @ClassID";
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
        /// 更新
        /// </summary>
        /// <param name="model">NewsClass Model</param>
        /// <returns>True or False</returns>
        public bool Update(BaseClassModel model)
        {
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@ClassID", model.ClassID);
            param[1] = new SqlParameter("@ClassName", model.ClassName);
            param[2] = new SqlParameter("@ParentID", model.ParentID);
            param[3] = new SqlParameter("@Depth", model.Depth);
            param[4] = new SqlParameter("@ParentPath", model.ParentPath);

            try
            {
                string sql = $"UPDATE {_tableName} SET ClassName = @ClassName,ParentID = @ParentID,Depth = @Depth,ParentPath = @ParentPath WHERE ClassID = @ClassID";
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
        /// 根据ID获取
        /// </summary>
        /// <param name="id">NewsClass ID</param>
        /// <returns>NewsClass Model</returns>
        public BaseClassModel GetClassModelByID(int ClassID)
        {
            return DbHelper.GetModel<BaseClassModel>($"select * from {_tableName} WHERE ClassID = @ClassID", new SqlParameter("@ClassID", ClassID));
        }

        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="id">NewsClass ID</param>
        /// <returns>NewsClass Model</returns>
        public T GetClassModelByID<T>(int ClassID)
        {
            return DbHelper.GetModel<T>($"select * from {_tableName} WHERE ClassID = @ClassID", new SqlParameter("@ClassID", ClassID));
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns>NewsClass List</returns>
        public IList<BaseClassModel> GetClassList()
        {
            return DbHelper.GetList<BaseClassModel>($"SELECT * FROM {_tableName} ORDER BY ClassId");
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns>NewsClass List</returns>
        public IList<T> GetClassList<T>()
        {
            return DbHelper.GetList<T>($"SELECT * FROM {_tableName} ORDER BY ClassId");
        }

        /// <summary>
        /// 根据父ID获取所有子菜单
        /// </summary>
        /// <returns>NewsClass List</returns>
        public IList<BaseClassModel> GetClassListByParentId(int ParentId)
        {
            return DbHelper.GetList<BaseClassModel>($"SELECT * FROM {_tableName} WHERE ParentID = @ParentId", new SqlParameter("@ParentId", ParentId));
        }
        #endregion
    }
}
