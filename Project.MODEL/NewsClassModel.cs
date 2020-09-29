using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL
{
    public class NewsClassModel : BaseClassModel
    {
        private string _ClassName;

        ///<Summary>
        /// 栏目名称
        ///</Summary>
        [Required(ErrorMessage = "请输入新闻分类名称")]
        public new string ClassName
        {
            get { return _ClassName; }
            set
            {
                base.ClassName = value;
                _ClassName = value;
            }
        }

        public string LinkUrl { get; set; }
        public int? ItemType { get; set; }
        public string Content { get; set; }
        public string ItemImg { get; set; }
    }
}
