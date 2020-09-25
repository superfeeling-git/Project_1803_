using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL
{
    public class BaseClassModel
    {
        #region 公共属性
        ///<Summary>
        /// 栏目ID
        ///</Summary>
        public int ClassID { get; set; }
        ///<Summary>
        /// 栏目名称
        ///</Summary>
        public string ClassName { get; set; }
        ///<Summary>
        /// 父ID
        ///</Summary>
        public int ParentID { get; set; }
        ///<Summary>
        /// 深度
        ///</Summary>
        public int Depth { get; set; }
        ///<Summary>
        /// 节点路径
        ///</Summary>
        public string ParentPath { get; set; }
        /// <summary>
        /// 更新的ID
        /// </summary>
        public int CID { get; set; }

        #endregion
    }
}
