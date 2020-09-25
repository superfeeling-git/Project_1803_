﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.MODEL;
using Project.DAL;

namespace Project.BLL
{
    public class NewsBLL
    {
        NewsDAL dal = new NewsDAL();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Model"></param>
        public void Add(NewsModel Model)
        {
            if (string.IsNullOrEmpty(Model.TitleColor))
                Model.TitleColor = "#000000";

            Model.Hit = 0;

            dal.Add(Model);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="ClassId"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public PageModel<NewsModel> getList(string Title, int ClassId, int PageIndex, int PageSize = 10)
        {
            return dal.getList(Title, ClassId, PageIndex, PageSize);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public int Delete(string idList)
        {
            return dal.Delete(idList);
        }

        /// <summary>
        /// 获取单条新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsModel getModel(int id)
        {
            return dal.getModel(id);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public bool Update(NewsModel Model)
        {
            return dal.Update(Model);
        }
    }
}