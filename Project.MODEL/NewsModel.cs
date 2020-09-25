using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Remoting.Activation;

namespace Project.MODEL
{
    public class NewsModel
    {
        public int NewsID { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        [Required(ErrorMessage ="请选择分类")]
        public int ClassID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage ="请输入文章标题")]
        public string Title { get; set; }
        /// <summary>
        /// 标题颜色
        /// </summary>
        public string TitleColor { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 点击量
        /// </summary>
        public int Hit { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Required(ErrorMessage ="请选择时间")]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 文章配图
        /// </summary>
        public string NewsImg { get; set; }
        /// <summary>
        /// 是否外链
        /// </summary>
        public bool IsLink { get; set; }
        /// <summary>
        /// 链接URL
        /// </summary>
        [System.ComponentModel.DataAnnotations.Url(ErrorMessage = "请输入一个正确的URL")]
        public string LinkUrl { get; set; }
        public bool IsHome { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string ClassName { get; set; }
    }
}
