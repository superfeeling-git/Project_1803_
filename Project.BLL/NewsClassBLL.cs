﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.MODEL;
using Project.DAL;
using De.DAL;
using Project.MODEL.Model;
using Project.Common;
using System.Web;

namespace Project.BLL
{
    public class NewsClassBLL
    {
        private NewsClassDAL dal = new NewsClassDAL();

        private BaseClassBLL<NewsClassModel> bll = new BaseClassBLL<NewsClassModel>();

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public bool Add(NewsClassModel Model)
        {
            Model.ClassID = bll.Add(Model);

            return dal.Update(Model);
        }

        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public bool Update(NewsClassModel Model)
        {
            bll.Update(Model);
            return dal.Update(Model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResultInfo Delete(int id)
        {
            return bll.Delete(id);
        }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsClassModel getNewsClassById(int id)
        {
            return bll.getClassModelById(id);
        }


        /// <summary>
        /// 获取递归之后的所有分类
        /// </summary>
        /// <returns></returns>
        public IList<NewsClassModel> GetNewsClass()
        {
            return bll.GetClass();
        }
    }
}
