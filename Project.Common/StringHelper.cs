using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// 根据LinkUrl生成指定的链接
        /// </summary>
        /// <param name="LinkUrl"></param>
        /// <returns></returns>
        public static string getUrl(this string LinkUrl, int ClassId, int? ItemType)
        {
            if (string.IsNullOrWhiteSpace(LinkUrl))
            {
                if (ItemType == 1)
                {
                    return $"/item/{ClassId}";
                }
                else if (ItemType == 2)
                {
                    return $"/news/{ClassId}";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return LinkUrl.Replace("{id}", ClassId.ToString());
            }
        }

        #region//Asc:将ASCII码改成字符编码
        /// <summary>
        ///将ASCII码改成字符编码
        /// </summary>
        /// <param name＝"S">将要编码的字符串</param>
        /// <returns>返回字符编码</returns>
        private static int Asc(string S)
        {
            return Convert.ToInt32(Convert.ToChar(S));
        }
        #endregion

        #region breakString:获取指定长度的字符，一个中文算两个字符．
        /// <summary>
        /// 获取指定长度的字符，一个中文算两个字符．
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="strLen">截取长度</param>
        /// <returns>截取后的字符串</returns>
        public static string breakString(this string str, int strLen)
        {
            string qdkRe = "";
            if (str == null || str == "")
            {
                return qdkRe;
            }
            qdkRe = str;
            int sLen, tLen, cLen;
            sLen = str.Length;
            tLen = 0;
            for (int i = 0; i < sLen; i++)
            {
                cLen = Math.Abs(Asc(str.Substring(i, 1)));
                if (cLen > 255)
                {
                    tLen += 2;
                }
                else
                {
                    tLen += 1;
                }
                if (tLen >= strLen)
                {
                    qdkRe = str.Substring(0, i);
                    qdkRe += "...";
                    break;
                }
            }

            return qdkRe;
        }

        /// <summary>
        /// 以正则表达式形式获取指定长度的字符串
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="strLen">截取长度</param>
        /// <param name="patton">正则表达式</param>
        /// <returns>截取后的字符串</returns>
        public static string breakString(this string str, int strLen, string patton)
        {
            if (str == null || str == "")
            {
                return "";
            }
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(patton.ToString(), RegexOptions.IgnoreCase);
            return str = breakString(regex.Replace(str, ""), strLen);
        }
        #endregion
    }
}
