using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public static class StringHelper
    {
        /// <summary>
        /// MD5的加密
        /// </summary>
        /// <param name="s"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Md5(this string s)
        {
            MD5 md5 = MD5.Create();

            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(s));

            StringBuilder sb = new StringBuilder();

            foreach (var item in bytes)
            {
                sb.Append(item.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
