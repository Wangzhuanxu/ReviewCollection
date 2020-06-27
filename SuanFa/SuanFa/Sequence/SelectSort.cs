using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Sequence
{
    /// <summary>
    /// 选择排序
    /// 在要排序的一组数中，选出最小（或者最大）的一个数与第1个位置的数交换；
    /// 然后在剩下的数当中再找最小（或者最大）的与第2个位置的数交换，
    /// 依次类推，直到第n-1个元素（倒数第二个数）和第n个元素（最后一个数）比较为止。
    /// </summary>
    class SelectSort
    {
        //static void Main()
        //{
        //    SelectSort ss = new SelectSort();
        //    DateTime dt1 = new DateTime();
        //    DateTime dt2 = new DateTime();
        //    TimeSpan ts = new TimeSpan();
        //    dt1 = DateTime.Now;
        //    ss.selectSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    Console.WriteLine("================================" + ts.TotalMilliseconds);
        //}

        public void selectSort()
        {
            int[] nums = { 1, 2, 4, 34, 5345, 34, 43, 342 };
            int k = int.MaxValue;
            int temp = 0;
            int t=0;//记录索引
            for(int i=0;i<nums.Length;i++)//i代表从那个数开始查找
            {
                for(int j=i;j<nums.Length;j++)
                {
                    if(k>nums[j])
                    {
                        t = j;
                        k = nums[j];
                    }
                }

                if(t!=i)
                {
                    temp = nums[i];
                    nums[i] = nums[t];
                    nums[t] = temp;
                }
                print(nums);
                Console.WriteLine();
                k = int.MaxValue;
                temp = 0;
                t = 0;
            }

            print(nums);
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="nums">打印的数组</param>
        public void print(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write("i=" + nums[i] + "  ");
            }
            Console.WriteLine();
        }
    }
}
