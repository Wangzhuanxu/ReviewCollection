using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.KeyWord
{
    class _Params
    {
        public static void add(params int[] i)
        {
            Console.WriteLine("可变参数加法");
        }

        public static void add(int i,int j)
        {
            Console.WriteLine("不可变参数加法");
        }

        public static void mix(int i,params int[] j)
        {//j必须放在i后边

        }
        //static void Main()
        //{
        //    _Params.add(new int[] { });//方式一
        //    _Params.add(2, 3);
        //    _Params.add(1, 3, 4, 35, 35, 56);//方式二
        //}
    }
}
