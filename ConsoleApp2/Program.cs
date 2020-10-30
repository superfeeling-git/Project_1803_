using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Project_1803Entities db = new Project_1803Entities();

            //db.Test.Where(m => m.ID > 6).Delete()

            //db.Test.Delete(m => m.ID == 5);


            //db.Test.Where(m => m.ID == 6).Update<Test>(m => new Test { AddTime = m.AddTime });

            //string orderField = "ID";

            //db.Test.OrderBy("ID");

            //db.Test.OrderBy(m => m.ID);


            //List<Test> tests = new List<Test> { new Test { ID = 5 } };

            //添加

            //db.Test.Add()

            //db.Test.AddRange(tests);

            //更新
            //db.Test.First(m => m.ID == 1).NAME = "王五";

            //db.Test.Find(2).NAME = "赵六";

            //Test test = new Test { ID = 4 };

            //db.Entry<Test>(test).State = System.Data.Entity.EntityState.Modified;

            //db.Entry

            //db.Entry<Test>(tests).State = System.Data.Entity.EntityState.Added;

            //db.Test.Attach(test);

            //db.Entry<Test>(test).State = System.Data.Entity.EntityState.Deleted;

            //db.Test.RemoveRange()

            //db.Test.Remove(test);

            //db.SaveChanges();

            Console.ReadLine();
        }
    }
}
