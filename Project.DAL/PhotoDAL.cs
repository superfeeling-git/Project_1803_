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

                string sql = "INSERT INTO Photo VALUES(@ClassID, @PhotoName, @Hit, @AddTime, @PhotoImg, @IsHome, @Pictures)";

                DbHelper.ExecuteSql(sql, sqlParm);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
