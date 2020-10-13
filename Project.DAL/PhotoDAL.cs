using Project.Common;
using Project.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class PhotoDAL
    {
        public bool Add(PhotoModel Model)
        {
            try
            {
                SqlParameter[] sqlParm = {
                    new SqlParameter("@ClassID",Model.ClassID),
                    new SqlParameter("@PhotoName",Model.PhotoName),
                    new SqlParameter("@Hit",Model.Hit),
                    new SqlParameter("@AddTime",Model.AddTime),
                    new SqlParameter("@PhotoImg",Model.PhotoImg),
                    new SqlParameter("@IsHome",Model.IsHome),
                    new SqlParameter("@Pictures",Model.Pictures)
                };

                string sql = "INSERT INTO Photo VALUES(@ClassID, @PhotoName, @Hit, @AddTime, @PhotoImg, @Pictures, @IsHome)";

                DbHelper.ExecuteSql(sql, sqlParm);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据不同的分类ID获取前TOP条内容
        /// </summary>
        /// <param name="ClassId"></param>
        /// <param name="Top"></param>
        /// <returns></returns>
        public IEnumerable<PhotoModel> getTopPhoto(int ClassId)
        {
            string sql = $@"SELECT * FROM Photo WHERE ClassID IN
                            (
                            SELECT ClassID FROM NewsClass WHERE ParentPath + ',' LIKE '%,{ClassId},%' OR ClassID = @ClassID
                            )
                             AND IsHome = 1 ORDER BY PhotoID DESC";
            return DbHelper.GetList<PhotoModel>(sql, new SqlParameter("@ClassID", ClassId));
        }

        /// <summary>
        /// 返回图片分页记录
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="ClassId"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public PageModel<PhotoModel> getList(string PhotoName, int ClassId, int PageIndex, int PageSize = 10)
        {
            SqlParameter[] sqlParm = {
                new SqlParameter("@ClassId",ClassId),
                new SqlParameter("@PhotoName",PhotoName),
                new SqlParameter("@PageIndex",PageIndex),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@TotalCount",SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@PageCount",SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            List<PhotoModel> newsList = DbHelper.GetList<PhotoModel>("__Photo_PageList__OFFSET", CommandType.StoredProcedure, sqlParm);

            int TotalCount = Convert.ToInt32(sqlParm[4].Value);

            int PageCount = Convert.ToInt32(sqlParm[5].Value);

            return new PageModel<PhotoModel>
            {
                PageCount = PageCount,
                TotalCount = TotalCount,
                PageData = newsList,
                PageIndex = PageIndex,
                PageSize = PageSize
            };
        }

        public PhotoModel getModel(int id)
        {
            return DbHelper.GetModel<PhotoModel>("SELECT * FROM Photo WHERE PhotoID = @PhotoID", new SqlParameter("@PhotoID", id));
        }

        public T getModel<T>(int id)
        {
            return DbHelper.GetModel<T>("SELECT * FROM xx WHERE id = @id", new SqlParameter("", id));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public bool Update(PhotoModel Model)
        {
            try
            {
                SqlParameter[] sqlParm = {
                    new SqlParameter("@ClassID",Model.ClassID),
                    new SqlParameter("@PhotoName",Model.PhotoName),
                    new SqlParameter("@Hit",Model.Hit),
                    new SqlParameter("@AddTime",Model.AddTime),
                    new SqlParameter("@PhotoImg",Model.PhotoImg),
                    new SqlParameter("@IsHome",Model.IsHome),
                    new SqlParameter("@Pictures",Model.Pictures),
                    new SqlParameter("@PhotoID",Model.PhotoID)
                };

                string sql = "UPDATE Photo SET ClassID = @ClassID,PhotoName = @PhotoName,Hit = @Hit," +
                    "AddTime = @AddTime,PhotoImg = @PhotoImg,Pictures = @Pictures,IsHome = @IsHome WHERE PhotoID = @PhotoID";

                DbHelper.ExecuteSql(sql, sqlParm);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeletePhoto(string idList)
        {
            return DbHelper.ExecuteSql($"DELETE FROM Photo WHERE PhotoID IN ({idList})");
        }

        /// <summary>
        /// 根据ID列表获取所有的图片URL
        /// </summary>
        /// <returns></returns>
        public string[] getPhotoForPath(string idList)
        {
            return DbHelper.GetList<PhotoModel>($"SELECT PhotoImg + ',' + Pictures AS imgName FROM Photo WHERE PhotoID IN({idList})").Select(m => m.imgName).ToArray();
        }
    }
}
