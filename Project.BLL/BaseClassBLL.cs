﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.MODEL;
using Project.DAL;
using Project.Common;
using System.Reflection;
using System.Web;

namespace Project.BLL
{
    public class BaseClassBLL<T>
    {
        private BaseClassDAL dal;
        private IList<T> ClassList = new List<T>();
        private IList<T> allList;

        private string TableName = typeof(T).Name.Replace("Model", "");

        public BaseClassBLL()
        {
            dal = new BaseClassDAL(TableName);

            IList<T> list = new List<T>();

            if(HttpRuntime.Cache[TableName] != null)
            {
                list = HttpRuntime.Cache[TableName] as List<T>;
            }
            else
            {
                list = dal.GetClassList<T>();
                HttpRuntime.Cache[TableName] = list;
            }

            this.allList = list;
        }

        /// <summary>
        /// 通过表名直接传递
        /// </summary>
        public BaseClassBLL(string TableName)
        {
            dal = new BaseClassDAL(TableName);
            this.allList = dal.GetClassList<T>();
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int Add(BaseClassModel Model)
        {
            HttpRuntime.Cache.Remove(TableName);

            //顶级分类
            if (Model.ClassID == 0)
            {
                Model.ParentID = 0;
                Model.Depth = 0;
                Model.ParentPath = "0";
            }
            else
            {
                BaseClassModel parentModel = dal.GetClassModelByID(Model.ClassID);

                Model.ParentID = Model.ClassID;
                Model.Depth = parentModel.Depth + 1;
                Model.ParentPath = $"{parentModel.ParentPath },{Model.ClassID}";
            }

            int row = dal.Add(Model);


            return row;
        }

        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public bool Update(BaseClassModel Model)
        {
            //顶级分类
            if (Model.ClassID == 0)
            {
                Model.ParentID = 0;
                Model.Depth = 0;
                Model.ParentPath = "0";
            }
            else
            {
                BaseClassModel parentModel = dal.GetClassModelByID(Model.ClassID);

                Model.ParentID = Model.ClassID;
                Model.Depth = parentModel.Depth + 1;
                Model.ParentPath = $"{parentModel.ParentPath },{Model.ClassID}";
                //对子分类的处理

            }
            Model.ClassID = Model.CID;


            bool result = dal.Update(Model);

            HttpRuntime.Cache.Remove(TableName);

            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResultInfo Delete(int id)
        {
            if (dal.GetClassListByParentId(id).Count > 0)
            {
                return new ResultInfo { ErrorCode = 1, Msg = "还有子分类，不能删除" };
            }
            else
            {
                dal.DeleteByID(id);
                HttpRuntime.Cache.Remove(TableName);
                return new ResultInfo { ErrorCode = 0, Msg = "删除成功" };
            }
        }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T getClassModelById(int id)
        {
            return dal.GetClassModelByID<T>(id);
        }


        /// <summary>
        /// 获取递归之后的所有分类
        /// </summary>
        /// <returns></returns>
        public IList<T> GetClass()
        {
            ClassList = new List<T>();
            foreach (var item in allList.Where(m => getPropertyValue("Depth", m) == 0))
            {
                ClassList.Add(item);
                getSubClass(getPropertyValue("ClassID",item));
            }

            return ClassList;
        }

        /// <summary>
        /// 反射获取对象相关字段的值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int getPropertyValue(string FieldName, T obj)
        {
            Type type = obj.GetType();

            PropertyInfo property = type.GetProperty(FieldName);

            return Convert.ToInt32(property.GetValue(obj));
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="ClassId"></param>
        private void getSubClass(int ClassId)
        {
            foreach (var item in allList.Where(m => getPropertyValue("ParentID", m) == ClassId))
            {
                ClassList.Add(item);
                getSubClass(getPropertyValue("ClassID",item));
            }
        }
    }
}
