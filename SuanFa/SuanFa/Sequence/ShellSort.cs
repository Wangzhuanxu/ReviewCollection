using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Sequence
{
    /// <summary>
    /// 希尔排序
    /// 该方法的基本思想是：先将整个待排元素序列分割成若干个子序列
    /// （由相隔某个“增量”的元素组成的）分别进行直接插入排序，
    /// 然后依次缩减增量再进行排序，待整个序列中的元素基本有序（增量足够小）时，
    /// 再对全体元素进行一次直接插入排序。因为直接插入排序在元素基本有序的情况下（接近最好情况），
    /// 效率是很高的，因此希尔排序在时间效率上比前两种方法有较大提高
    /// </summary>
    class ShellSort
    {
        //static void Main()
        //{
        //    ShellSort ss = new ShellSort();
        //    DateTime dt1 = new DateTime();
        //    DateTime dt2 = new DateTime();
        //    TimeSpan ts = new TimeSpan();
        //    dt1 = DateTime.Now;
        //    ss.shellSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    Console.WriteLine("================================" + ts.TotalMilliseconds);
        //    //ins.bubbleSort1();
        //    //dt1 = DateTime.Now;
        //    //ts = dt1 - dt2;
        //    //Console.WriteLine("================================" + ts.TotalMilliseconds);
        //}

        public void shellSort()
        {
            int[] nums = { 1, 2, 4, 34, 5345, 34, 43, 342 };
            int gap = nums.Length / 2;//步长
            int j=0;//交换上一元素索引
            int temp = 0;
            int t = 0;//交换元素的值
            while(gap>=1)
            {
                for(int i=gap;i<nums.Length;i++)
                {
                    j = i - gap;
                    t = nums[i];
                    while(t<nums[j])
                    {
                        nums[j + gap] = nums[j];
                        j -= gap;
                    }
                    nums[j + gap] = t;
                }
                gap /= 2;
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
                Console.WriteLine("i=" + nums[i] + "  ");
            }
            Console.WriteLine();
        }
    }

   
}
