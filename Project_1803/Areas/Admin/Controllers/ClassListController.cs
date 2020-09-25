using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.MODEL;
using Project.BLL;
using Project.MODEL.Model;

namespace Project_1803.Areas.Admin.Controllers
{
    public class ClassListController : Controller
    {
        /// <summary>
        /// 分类下拉
        /// </summary>
        /// <param name="selectedValue"></param>
        /// <param name="FirstText"></param>
        /// <param name="FirstValue"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Index(string TableName, int? selectedValue, string FirstText = "做为一级分类",int FirstValue = 0)
        {
            BaseClassBLL<BaseClassModel> bll = new BaseClassBLL<BaseClassModel>(TableName);

            //从业务逻辑层获取所有分类（菜单）数据
            IList<BaseClassModel> sysList = bll.GetClass();

            //创建下拉项集合（空的）
            List<SelectListItem> items = new List<SelectListItem>();

            //第一个下拉项的默认文本和默认值
            items.Add(new SelectListItem { Text = FirstText, Value = FirstValue.ToString() });

            foreach (var item in sysList)
            {
                string nbsp = string.Empty;
                for (int i = 0; i < item.Depth * 4; i++)
                {
                    //HTML空格
                    nbsp += "&nbsp;";
                }

                //添加下拉的菜单项
                //<option value="123" selected="selected">asd</option>
                SelectListItem li = new SelectListItem { Text = Server.HtmlDecode(nbsp + "├" + item.ClassName), Value = item.ClassID.ToString() };

                //设置选中项
                if(item.ClassID == selectedValue)
                {
                    li.Selected = true;
                }

                items.Add(li);
            }

            return View(items);
        }
    }
}