using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Search
{
    /// <summary>
    /// 二分查找---有序查找
    /// 最坏情况下，关键词比较次数为log2(n+1)，且期望时间复杂度为O(log2n)；
    /// </summary>
    class BinarySearch
    {
        //static void Main()
        //{
        //    int[] nums = { 1, 2, 4, 5, 6, 7, 8, 9 };
        //    BinarySearch bs = new BinarySearch();
        //    for (int i = nums.Length - 1; i >= 0; i--)
        //    {
        //        Console.WriteLine("i=" + bs.binarySearch(nums, nums[i] - 5, 0, nums.Length - 1) + "  num[i]=" + nums[i]);
        //    }

        //    for (int i = nums.Length - 1; i >= 0; i--)
        //    {
        //        Console.WriteLine("i=" + bs.binarySearch2(nums, nums[i] - 5, 0, nums.Length - 1) + "  num[i]=" + nums[i]);
        //    }
        //}

        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="key">查找的数</param>
        /// <param name="left">最左边的数索引</param>
        /// <param name="right">最右边的数索引</param>
        /// <returns></returns>
        public int  binarySearch(int []array,int key,int left,int right)
        {
            if(left<=right)
            {
                int mid = (left + right) / 2;
                if(array[mid]==key)
                {
                    return mid;
                }
                else if(array[mid]>key&&mid-1>=left)
                {
                    return binarySearch(array, key, left, mid - 1);
                }
                else if(mid+1<=right)
                {
                    return binarySearch(array, key, mid + 1, right);
                }
            }
            return -1;
        }

        public int binarySearch2(int []array,int key,int left,int right)
        {
            int mid = 0;
            int index = -1;
            while(left<=right)
            {
                mid = (left + right) / 2;
                if (array[mid] == key)
                {
                    index= mid;
                    break;
                }
                else if (array[mid] > key)
                {
                    right=mid - 1;
                }
                else 
                {
                   left= mid + 1;
                }
            }
            return index;
        }
    }
}
