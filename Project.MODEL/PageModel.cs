using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL
{
    public class PageModel<T>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 每页记录数据
        /// </summary>
        public List<T> PageData { get; set; }
    }
}
