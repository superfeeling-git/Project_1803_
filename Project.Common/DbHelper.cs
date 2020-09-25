using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace Project.Common
{
    public class DbHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static string ConnStr = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;

        /// <summary>
        /// 预处理请求参数
        /// </summary>
        /// <param name="sqlParm"></param>
        private static void ProcessSqlParm(SqlCommand cmd, SqlParameter[] sqlParm)
        {
            if (sqlParm != null)
            {
                foreach (var item in sqlParm)
                {
                    if (item.Value == null)
                    {
                        item.Value = DBNull.Value;
                    }
                }

                cmd.Parameters.AddRange(sqlParm);
            }
        }


        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="Sql"></param>
        /// <param name="sqlParm"></param>
        /// <returns></returns>
        public static int ExecuteSql(string Sql, params SqlParameter[] sqlParm)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = Sql;

                /// 预处理请求参数
                ProcessSqlParm(cmd, sqlParm);

                conn.Open();

                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 返回单条实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Sql"></param>
        /// <param name="sqlParm"></param>
        /// <returns></returns>
        public static T GetModel<T>(string Sql, params SqlParameter[] sqlParm)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);

                /// 预处理请求参数
                ProcessSqlParm(cmd, sqlParm);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                string json = JsonConvert.SerializeObject(dt);

                List<T> list = JsonConvert.DeserializeObject<List<T>>(json);

                return list.FirstOrDefault();
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="Sql"></param>
        /// <param name="sqlParm"></param>
        /// <returns></returns>
        public static int ExecuteScalar(string Sql, params SqlParameter[] sqlParm)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);

                /// 预处理请求参数
                ProcessSqlParm(cmd, sqlParm);

                conn.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        /// <summary>
        /// 返回所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Sql"></param>
        /// <param name="sqlParm"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(string Sql, params SqlParameter[] sqlParm)
        {
            return GetList<T>(Sql, CommandType.Text, sqlParm);
        }

        /// <summary>
        /// 调用存储过程，返回数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Sql"></param>
        /// <param name="CommandType"></param>
        /// <param name="sqlParm"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(string Sql, CommandType CommandType, params SqlParameter[] sqlParm)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);

                cmd.CommandType = CommandType;

                /// 预处理请求参数
                ProcessSqlParm(cmd, sqlParm);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                string json = JsonConvert.SerializeObject(dt);

                List<T> list = JsonConvert.DeserializeObject<List<T>>(json);

                return list;
            }
        }
    }
}
