using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Project.MODEL;
using Project.BLL;
using Project.MODEL.Model;

namespace Project_1803.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        AdminBLL bll = new AdminBLL();

        // GET: Admin/Login
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminModel Model,FormCollection form)
        {
            return Json(bll.Login(Model, form["ValidateCode"]),JsonRequestBehavior.AllowGet);
        }


        public ActionResult ValidateCode()
        {
            string code = CreateCode();

            //存入SESSION
            Session["Code"] = code;

            //创建位图图像
            Bitmap bitmap = new Bitmap(code.Length * 14, 22);

            //创建画布
            Graphics graphics = Graphics.FromImage(bitmap);

            //清空并填充白色
            graphics.Clear(Color.White);


            Random random = new Random(unchecked((int)DateTime.Now.Ticks));

            //画线
            for (int i = 0; i < 20; i++)
            {
                graphics.DrawLine(new Pen(Color.FromArgb(100, 0, 0, 255)), random.Next(bitmap.Width), random.Next(bitmap.Height), random.Next(bitmap.Width), random.Next(bitmap.Height));
            }            

            Font font = new Font("微软雅黑", 12, (FontStyle.Bold | FontStyle.Italic));

            Rectangle rec = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            LinearGradientBrush bursh = new LinearGradientBrush(rec, Color.Red, Color.Blue, 10);

            graphics.DrawString(code, font, bursh, rec);

            //保存文件
            MemoryStream stream = new MemoryStream();

            bitmap.Save(stream, ImageFormat.Jpeg);

            return File(stream.ToArray(), @"image/jpeg");
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public string CreateCode()
        {
            //数字和字母
            StringBuilder sb = new StringBuilder();

            //数字
            for (int i = 0; i < 10; i++)
            {
                sb.Append(i);
            }

            //字母
            for (int i = 65; i < 91; i++)
            {
                sb.Append((char)i);
            }

            
            //随机数
            Random random = new Random(unchecked((int)DateTime.Now.Ticks));

            char[] code = new char[6];

            for (int i = 0; i < code.Length; i++)
            {
                code[i] = sb.ToString()[random.Next(0, sb.Length - 1)];
            }

            return string.Join("", code);
        }
    }
}