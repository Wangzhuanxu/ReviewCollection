using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Sequence
{
    /// <summary>
    /// 冒泡排序法
    /// 基本思想：在要排序的一组数中，对当前还未排好序的范围内的全部数，
    /// 自上而下对相邻的两个数依次进行比较和调整，让较大的数往下沉，较小的往上冒。
    /// 即：每当两相邻的数比较后发现它们的排序与排序要求相反时，就将它们互换。
    /// 
    /// </summary>
    class BubbleSort
    {
        //static void Main()
        //{
        //    BubbleSort bs = new BubbleSort();
        //    DateTime dt1 = new DateTime();
        //    DateTime dt2 = new DateTime();
        //    TimeSpan ts = new TimeSpan();
        //    dt1 = DateTime.Now;
        //    bs.bubbleSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    Console.WriteLine("================================" + ts.TotalMilliseconds);
        //    bs.bubbleSort1();
        //    dt1 = DateTime.Now;
        //    ts = dt1 - dt2;
        //    Console.WriteLine("================================" + ts.TotalMilliseconds);
        //    bs.bubbleSort2();
        //}
        /// <summary>
        /// 未改进时的冒泡排序法,时间复杂度=(n-1)!=O(n^2)
        /// </summary>
        public void bubbleSort()
        {
            int[] nums = { 1, 2, 4, 34, 5345, 34, 43, 342 };
            int temp = 0;
            for(int i=0;i<nums.Length-1;i++)
            {
                for(int j=0;j<nums.Length-1-i;j++)
                {
                    if(nums[j]>nums[j+1])
                    {
                        temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }
            print(nums);
        }
        /// <summary>
        /// 改进后。设置一标志性变量pos,用于记录每趟排序中最后一次进行交换的位置。
        /// 由于pos位置之后的记录均已交换到位,故在进行下一趟排序时只要扫描到pos位置即可。
        /// </summary>
        public void bubbleSort1()
        {
            int[] nums = { 1, 2, 4, 34, 5345, 34, 43, 342 };
            int temp = 0;
            int k = nums.Length - 1;
            int pos = 0;
            while (k>0)
            {
                pos = 0;
                for(int i=0;i<k;i++)
                {
                    if(nums[i]>nums[i+1])
                    {
                        pos = i;
                        temp = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = temp;
                    }
                }
                k = pos;
            }
            print(nums);
        }

        public void bubbleSort2()
        {
            int[] nums = { 1, 2, 4, 34, 5345, 34, 43, 342 };
            int temp = 0;
            int k = nums.Length - 1;
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < k; i++)
                {
                    if (nums[i] > nums[i + 1])
                    {
                        flag = true;
                        temp = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = temp;
                    }
                }
                k = k-1;
            }
            print(nums);
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="nums">打印的数组</param>
        public void print(int[] nums)
        {
            for(int i=0;i<nums.Length;i++)
            {
                Console.WriteLine("i=" + nums[i]);
            }
        }
    }
}
