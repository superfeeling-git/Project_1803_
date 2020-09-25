/*------------------------------------------------
// File Name:SysClassInfo.cs
// File Description:SysClass DataBase Entity
// Author:feeling
// Create Time:2020/09/10 13:59:12
//------------------------------------------------*/

using System;
using System.ComponentModel.DataAnnotations;

namespace Project.MODEL.Model
{
    /// <summary>
    /// 说明 系统菜单表
    /// </summary>
    [Serializable]
    public class SysClassModel : BaseClassModel
    {
        #region 公共属性
        ///<Summary>
        /// 栏目名称
        ///</Summary>


        private string _ClassName;

        [Required(ErrorMessage = "请输入菜单名称")]
        public new string ClassName
        {
            get { return _ClassName; }
            set {
                base.ClassName = value;
                _ClassName = value;
            }
        }

        /// <summary>
        /// 菜单对应的URL
        /// </summary>
        [Required(ErrorMessage = "菜单对应的URL")]
        public string URL { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; }
        #endregion
    }
}
