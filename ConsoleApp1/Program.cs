using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Data.Entity;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var html = @"http://www.gd.xinhuanet.com/newscenter/2020-10/23/c_1126649531.htm";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            File.WriteAllText(Path.GetFullPath("../../xinhua.html"), htmlDoc.Text);

            //HtmlNode node = htmlDoc.DocumentNode.SelectSingleNode("//*[@class='link']");

            //Console.WriteLine(node.InnerText);

            //erp_testEntities db = new erp_testEntities();

            //db.test.Find(6).name = "test";

            //db.test.Where(m => m.id == 6).AsNoTracking().First().name = Guid.NewGuid().ToString();

            //IEnumerable<test> obj = new List<test>() {
            //    new test{ name = "张三", id = 2 },
            //    new test{ name = "李四", id = 3 },
            //    new test{ name = "王五", id = 4 },
            //};

            //foreach (var item in obj)
            //{
            //    db.test.Attach(item);
            //}

            //db.test.RemoveRange(obj);

            //db.test.AddRange(obj);

            //test test = new test { id = 5, name = Guid.NewGuid().ToString() };

            //db.test.Attach(test);

            //db.Entry<test>(test).State = System.Data.Entity.EntityState.Deleted;

            //db.test.First(m => m.id == 3).name = Guid.NewGuid().ToString();



            //obj.First(m => m.id == 4).name = Guid.NewGuid().ToString();



            //db.SaveChanges();

            Console.ReadLine();
        }
    }

    public class Student
    {

    }
}
