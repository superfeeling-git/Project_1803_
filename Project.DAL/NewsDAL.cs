using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Common;
using Project.MODEL;

namespace Project.DAL
{
    public class NewsDAL
    {
        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public bool Add(NewsModel Model)
        {
            try
            {
                SqlParameter[] sqlParm = {
                    new SqlParameter("@ClassID",Model.ClassID),
                    new SqlParameter("@Title",Model.Title),
                    new SqlParameter("@TitleColor",Model.TitleColor),
                    new SqlParameter("@Author",Model.Author),
                    new SqlParameter("@Source",Model.Source),
                    new SqlParameter("@Hit",Model.Hit),
                    new SqlParameter("@AddTime",Model.AddTime),
                    new SqlParameter("@NewsImg",Model.NewsImg),
                    new SqlParameter("@IsLink",Model.IsLink),
                    new SqlParameter("@LinkUrl",Model.LinkUrl),
                    new SqlParameter("@IsHome",Model.IsHome),
                    new SqlParameter("@Content",Model.Content)
                };

                string sql = "INSERT INTO News VALUES(@ClassID, @Title, @TitleColor, @Author, @Source, @Hit, @AddTime, @NewsImg, @IsLink, @LinkUrl, @IsHome, @Content)";
                
                DbHelper.ExecuteSql(sql, sqlParm);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 返回新闻分页记录
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="ClassId"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public PageModel<NewsModel> getList(string Title,int ClassId, int PageIndex, int PageSize = 10)
        {
            SqlParameter[] sqlParm = {
                new SqlParameter("@ClassId",ClassId),
                new SqlParameter("@Title",Title),
                new SqlParameter("@PageIndex",PageIndex),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@TotalCount",SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@PageCount",SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            List<NewsModel> newsList = DbHelper.GetList<NewsModel>("__PageList__OFFSET", CommandType.StoredProcedure, sqlParm);

            int TotalCount = Convert.ToInt32(sqlParm[4].Value);

            int PageCount = Convert.ToInt32(sqlParm[5].Value);

            return new PageModel<NewsModel> {
                PageCount = PageCount, 
                TotalCount = TotalCount,
                PageData = newsList,
                PageIndex = PageIndex,
                PageSize = PageSize
            };
        }

        /// <summary>
        /// 根据不同的分类ID获取前TOP条内容
        /// </summary>
        /// <param name="ClassId"></param>
        /// <param name="Top"></param>
        /// <returns></returns>
        public IEnumerable<NewsModel> getTopNews(int ClassId, int Top)
        {
            return getTopNews(ClassId, Top, true);
        }

        /// <summary>
        /// 根据不同的分类ID获取前TOP条内容
        /// </summary>
        /// <param name="ClassId"></param>
        /// <param name="Top"></param>
        /// <returns></returns>
        public IEnumerable<NewsModel> getTopNews(int ClassId, int Top, bool IsHome = false)
        {
            string sql = $@"SELECT TOP {Top} NewsID,ClassID,Title,TitleColor,AddTime,NewsImg,IsLink,LinkUrl,IsHome,Content
                         FROM News WHERE ClassID IN
                         (
                         SELECT ClassID FROM NewsClass WHERE ParentPath + ',' LIKE '%,{ClassId},%' OR ClassID = @ClassID
                         )";
            if (IsHome)
                sql += " AND IsHome = 1 ";

            sql += "ORDER BY AddTime DESC";

            return DbHelper.GetList<NewsModel>(sql, new SqlParameter("@ClassID", ClassId));
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public int Delete(string idList)
        {
            return DbHelper.ExecuteSql($"DELETE FROM News WHERE NewsID IN({idList})");
        }

        /// <summary>
        /// 获取单条新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsModel getModel(int id)
        {
            return DbHelper.GetModel<NewsModel>("SELECT * FROM News WHERE NewsID = @NewsID", new SqlParameter("@NewsID", id));
        }


        /// <summary>
        /// 更新新闻
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public bool Update(NewsModel Model)
        {
            SqlParameter[] sqlParm = {
                    new SqlParameter("@NewsId",Model.NewsID),
                    new SqlParameter("@ClassID",Model.ClassID),
                    new SqlParameter("@Title",Model.Title),
                    new SqlParameter("@TitleColor",Model.TitleColor),
                    new SqlParameter("@Author",Model.Author),
                    new SqlParameter("@Source",Model.Source),
                    new SqlParameter("@Hit",Model.Hit),
                    new SqlParameter("@AddTime",Model.AddTime),
                    new SqlParameter("@NewsImg",Model.NewsImg),
                    new SqlParameter("@IsLink",Model.IsLink),
                    new SqlParameter("@LinkUrl",Model.LinkUrl),
                    new SqlParameter("@IsHome",Model.IsHome),
                    new SqlParameter("@Content",Model.Content)
                };

            string sql = "UPDATE News SET ClassID = @ClassID, Title = @Title, TitleColor = @TitleColor, Author = @Author, Source = @Source, AddTime = @AddTime, NewsImg = @NewsImg, IsLink = @IsLink, LinkUrl = @LinkUrl, IsHome = @IsHome, Content = @Content WHERE NewsID = @NewsID";

            DbHelper.ExecuteSql(sql, sqlParm);
            return true;

            try
            {
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
