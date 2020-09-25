using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Project.MODEL.Model
{
    /// <summary>
    /// 说明 管理员表
    /// </summary>
    [Serializable]
    public class AdminModel
    {
        #region 公共属性
        ///<Summary>
        /// 管理员ID
        ///</Summary>
        public int AdminID { get; set; }
        ///<Summary>
        /// 用户名
        ///</Summary>
        [Required(ErrorMessage ="请输入用户名")]
        [Remote("CheckUserName","Admin", AdditionalFields = "AdminID", ErrorMessage = "用户名重复")]
        public string UserName { get; set; }

        ///<Summary>
        /// 密码
        ///</Summary>
        [Required(ErrorMessage ="请输入密码")]
        [MinLength(6,ErrorMessage = "密码最少6位")]
        public string Password { get; set; }
        ///<Summary>
        /// 末次登录时间
        ///</Summary>
        public DateTime? LastLoginTime { get; set; }
        ///<Summary>
        /// 登录IP
        ///</Summary>
        public string LastLoginIP { get; set; }
        /// <summary>
        /// 当前用户拥有的角色ID
        /// </summary>
        public int[] RoleId { get; set; }
        #endregion
    }
}
