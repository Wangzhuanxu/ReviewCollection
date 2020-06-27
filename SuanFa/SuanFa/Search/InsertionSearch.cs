using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Search
{
    /// <summary>
    /// 差值查找---有序查找
    /// 对于表长较大，而关键字分布又比较均匀的查找表来说，插值查找算法的平均性能比折半查找要好的多
    /// 。反之，数组中如果分布非常不均匀，那么插值查找未必是很合适的选择。
　　//复杂度分析：查找成功或者失败的时间复杂度均为O(log2(log2n))。
    /// </summary>
    class InsertionSearch
    {
        //static void Main()
        //{
        //    int[] nums = { 1, 2, 4, 5, 6, 7, 8, 9 };
        //    InsertionSearch ins = new InsertionSearch();
        //    for (int i = nums.Length - 1; i >= 0; i--)
        //    {
        //        Console.WriteLine("i=" + ins.insertionSearch(nums, nums[i] - 5, 0, nums.Length - 1) + "  num[i]=" + nums[i]);
        //    }
        //    Console.WriteLine();
        //    for (int i = nums.Length - 1; i >= 0; i--)
        //    {
        //        Console.WriteLine("i=" + ins.insertionSearch(nums, nums[i] - 5, 0, nums.Length - 1) + "  num[i]=" + nums[i]);
        //    }
        //}

        /// <summary>
        ///差值查找
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="key">查找的值</param>
        /// <param name="left">最左边的数索引</param>
        /// <param name="right">最右边的数索引</param>
        /// <returns></returns>
        public int  insertionSearch(int []array,int key,int left,int right)
        {
            if(right>=left)
            {
                int mid = (key - array[left]) / (array[right] - array[left]) * (right - left) + left;
                if(array[mid]==key)
                {
                    return mid;
                }
                else if(mid-1>=left&&array[mid]>key)
                {
                    return insertionSearch(array, key, left, mid - 1);
                }
                else if(mid+1<=right && array[mid] < key)
                {
                    return insertionSearch(array, key, mid + 1, right);
                }
            }
            return -1;
        }
    }
}
