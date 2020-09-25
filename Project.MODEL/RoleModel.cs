using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project.MODEL.Model
{
    public class RoleModel
    {
        public int RoleID { get; set; }
        [Required(ErrorMessage = "请输入角色名称")]
        public string RoleName { get; set; }
        public int[] sysClassID { get; set; }
    }
}
