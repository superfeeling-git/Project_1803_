using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.BLL;
using Project.MODEL;
using HtmlAgilityPack;

namespace Project_1803.Controllers
{
    public class HomeController : Controller
    {
        NewsClassBLL newsClassBLL = new NewsClassBLL();

        PhotoBLL photoBLL = new PhotoBLL();

        NewsBLL newsbll = new NewsBLL();

        public ActionResult Index()
        {
            IList<NewsClassModel> newsclass = newsClassBLL.GetNewsClass();            

            HomeModel homeModel = new HomeModel();

            //所有的分类
            homeModel.AllClass = newsclass;            

            #region 所有的新闻部分
            int[] NewsIdList = { 24, 23, 37 };

            homeModel.NewsClass = newsclass.Where(m => NewsIdList.Contains(m.ClassID));

            foreach (var item in homeModel.NewsClass)
            {
                item.NewsList = newsbll.getTopNews(item.ClassID, 6);

                foreach (var news in item.NewsList)
                {
                    //新闻内容
                    var html = news.Content;

                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);

                    html = htmlDoc.DocumentNode.InnerText;

                    news.Content = html.Substring(0, html.Length > 65 ? 65 : html.Length);
                }
            }
            #endregion

            #region 所有的图片部分
            //VIEW中对应的图片分类ID
            int[] PhotoIdList = { 1, 10, 11, 37, 27, 28, 29 };

            homeModel.PhotoClass = newsclass.Where(m => PhotoIdList.Contains(m.ClassID));

            foreach (var @class in homeModel.PhotoClass)
            {
                @class.PhotoList = photoBLL.getTopPhoto(@class.ClassID);
            }

            return View(homeModel);
            #endregion
        }
    }
}