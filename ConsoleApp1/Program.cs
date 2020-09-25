using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string names = File.ReadAllText($"{Path.GetFullPath("../../")}/b.txt");

            //names = Regex.Replace(names, @"\s+", ",").Trim(',');

            //string _names = "胡燕青	赵磊	陈贵菁	李一帆	张恒瑞	李东懋	卢洋	王航	户鹏	刘海亮	任康	朱画宇	郝浩邑	张迎嵩	王天朔	李倩	王闻博	罗石磊	吴国星	褚琪	常乐	孙文东	赵汪洋	岳子阳	相云飞	张建亮	宋治兵 	张鼎瑞	张崔	杨文龙";

            //_names = Regex.Replace(_names, @"\s", ",").Trim(',');



            //foreach (var item in names.Split(','))
            //{
            //    if(!_names.Split(',').Any(m => m == item))
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            //Console.WriteLine(names.Split(',').Length);

            ////Console.WriteLine(names);
            //Console.Read();

            Console.WriteLine(typeof(Student).Name);
            Console.Read();
        }
    }

    public class Student
    {

    }
}
