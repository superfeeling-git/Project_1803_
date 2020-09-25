/*------------------------------------------------
// File Name:SysRoleInfo.cs
// File Description:SysRole DataBase Entity
// Author:feeling
// Create Time:2020/09/14 15:45:36
//------------------------------------------------*/

using System;

namespace Project.MODEL.Model
{
    /// <summary>
    /// 说明 栏目角色表
    /// </summary>
    [Serializable]
    public class SysRoleModel
    {
        #region 公共属性
        ///<Summary>
        /// 
        ///</Summary>
        public int ID { get; set; }
        ///<Summary>
        /// 栏目ID
        ///</Summary>
        public int ClassID { get; set; }
        ///<Summary>
        /// 角色ID
        ///</Summary>
        public int RoleID { get; set; }
        #endregion
    }
}
