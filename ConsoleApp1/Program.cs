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
            //string[] names = File.ReadAllLines($"{Path.GetFullPath("../../")}/c.txt");

            ////names = Regex.Replace(names, @"\s+", ",").Trim(',');

            //string[] _names = @"卢洋洋；张少宇；张磊；张耀伟；王明港；刘洁；张旭东；于汪洋；马铭春；宋燚；张权旺；聂一博；杜庆丽；李琰；贺世贸；李明瑞；袁畅恒；曹一鸣；方琪；刘洋；伊卓；任俊丞；周杰；段文杰；赵振阳；李世恒；王铭；龚靖翔；卢雪悦".Split('；');

            ////_names = Regex.Replace(_names, @"\s", ",").Trim(',');

            //foreach (var item in names)
            //{
            //    if (!_names.Any(m => m == item))
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            ////Console.WriteLine(names.Split(',').Length);

            //////Console.WriteLine(names);
            ////Console.Read();

            //Console.WriteLine(typeof(Student).Name);

            Random random = new Random(unchecked((int)DateTime.Now.Ticks));

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(random.Next(100, 1000));
            }


            Console.Read();
        }
    }

    public class Student
    {

    }
}
