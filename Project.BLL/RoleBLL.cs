using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.MODEL.Model;
using Project.DAL;
using De.DAL;

namespace Project.BLL
{
    public class RoleBLL
    {
        RoleDAL dal = new RoleDAL();
        SysRoleDAL sysroleDal = new SysRoleDAL();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="RoleName"></param>
        /// <param name="idList"></param>
        public void Add(string RoleName, string idList)
        {
            int newID = dal.Add(new RoleModel { RoleName = RoleName });
            foreach (var item in idList.Split(','))
            {
                sysroleDal.Add(new SysRoleModel { RoleID = newID, ClassID = Convert.ToInt32(item) });
            }
        }

        /// <summary>
        /// 根据角色ID获取单个角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoleModel getRole(int id)
        {
            RoleModel model = dal.GetRoleModelByID(id);
            model.sysClassID = sysroleDal.getSysClassByRoleId(id);

            return model;
        }

        /// <summary>
        /// 获取全部角色信息
        /// </summary>
        /// <returns>Role List</returns>
        public IList<RoleModel> GetRoleListByPage()
        {
            return dal.GetRoleListByPage();
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateRole(RoleModel model)
        {
            try
            {
                //更新角色名称
                dal.Update(model);
                //删除角色对应的菜单
                sysroleDal.DeleteByRoleId(model);
                //新增角色对应的菜单
                foreach (var item in model.sysClassID)
                {
                    sysroleDal.Add(new SysRoleModel { RoleID = model.RoleID, ClassID = Convert.ToInt32(item) });
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteByID(int id)
        {
            return dal.DeleteByID(id);
        }

        /// <summary>
        /// 根据URL获取对应的角色
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public int[] getRolesIdByURL(string URL)
        {
            return dal.getRolesIdByURL(URL);
        }

        /// <summary>
        /// 根据用户获取对应的角色
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public int[] getRolesIdByUser(string UserName)
        {
            return dal.getRolesIdByUser(UserName);
        }

        private BaseClassBLL<SysClassModel> bll = new BaseClassBLL<SysClassModel>();

        /// <summary>
        /// 根据角色获取对应的菜单
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public IList<SysClassModel> getSysClassByRole(string idList)
        {

            int[] ClassIdList = dal.getSysClassByRole(idList);

            IList<SysClassModel> SysList = bll.GetClass();

            SysList = SysList.Where(m => ClassIdList.Contains(m.ClassID) && m.IsShow).ToList();


            return SysList;
        }
    }
}
