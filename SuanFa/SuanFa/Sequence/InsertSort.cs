using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Sequence
{
    /// <summary>
    /// 插入排序
    /// 将一个记录插入到已排序好的有序表中，从而得到一个新的记录数增为1的有序表。
    /// 即：先将序列的第1个记录看成是一个有序的子序列，然后从第2个记录逐个进行插入，
    /// 直至整个序列有序为止。
    /// </summary>
    class InsertSort
    {
        //static void Main()
        //{
        //    //define InsertSort object
        //    InsertSort ins = new InsertSort();
        //    DateTime dt1 = new DateTime();
        //    DateTime dt2 = new DateTime();
        //    TimeSpan ts = new TimeSpan();
        //    dt1 = DateTime.Now;
        //    ins.insertSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    //print run time
        //    Console.WriteLine("================================" + ts.TotalMilliseconds);
        //}
        public void insertSort()
        {
            //define order sequence
            int[] nums = { 1, 2, 4, 34, 5345, 34, 43, 342 };
            int t, k;
            //traversal sequence
            for(int i=1;i<nums.Length;i++)
            {
                t = nums[i];
                k = i - 1;
                while(t<nums[k])
                {
                    //move small data to the back
                    nums[k + 1] = nums[k];
                    k--;
                }
                //sava number
                nums[k+1] = t;
            }
            //print sequence
            print(nums);
        }

        /// <summary>
        /// print ordered sequence
        /// </summary>
        /// <param name="nums">ordered sequence</param>
        public void print(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write("i=" + nums[i]+"  ");
            }
            Console.WriteLine();
        }
    }
}
