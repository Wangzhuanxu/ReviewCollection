using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Search
{
    /// <summary>
    /// 斐波那契查找---有序查找
    /// (1)数据必须采用顺序存储结构；(2)数据必须有序。
    /// (2)最接近查找长度的斐波那契值来确定拆分点;(2)黄金分割
    /// (3)最坏情况下，时间复杂度为O(log2n)，且其期望复杂度也为O(log2n)。
    /// </summary>
    class FbonacciSearch
    {
        //static void Main()
        //{
        //    int[] nums = { 1, 2, 4, 5, 6, 7, 8, 9 };
        //    FbonacciSearch fbs = new FbonacciSearch();
        //    int[] fb = fbs.makeFBArray(20);//制作斐波那契数组
        //    int k = 0;
        //    while(fb[k]<nums.Length)//寻找k
        //    {
                
        //        k++;
        //    }
        //    int[] temp = new int[fb[k]];
        //    for(int i=0;i<temp.Length;i++)//创建fb[k]长度的数组,多余长度用nums数组中最后一个元素填充
        //    {
        //        if(i>=nums.Length)
        //        {
        //            temp[i] = nums[nums.Length - 1];
        //        }
        //        else
        //        {
        //            temp[i] = nums[i];
        //        }
        //    }
        //    for (int i = nums.Length - 1; i >= 0; i--)
        //    {
        //        Console.WriteLine("i=" + fbs.fbonacciSearch(temp, 0, temp.Length - 1, fb,nums[i]-5, k, nums.Length) + "  num[i]=" + nums[i]);
        //    }
        //    Console.WriteLine();
        //    for (int i = nums.Length - 1; i >= 0; i--)
        //    {
        //        Console.WriteLine("i=" + fbs.fbonacciSearch2(temp, 0, temp.Length - 1, fb, nums[i] - 5, k, nums.Length) + "  num[i]=" + nums[i]);
        //    }
        //}

        /// <summary>
        /// 斐波那契查找
        /// </summary>
        /// <param name="array">临时数组</param>
        /// <param name="left">最左边的数的索引</param>
        /// <param name="right">最右边数的索引</param>
        /// <param name="fb">斐波那契数组</param>
        /// <param name="key">查找的值</param>
        /// <param name="k">斐波那契数组中刚好大于数组长度数的索引</param>
        /// <param name="length">所要查找的数组长度</param>
        /// 斐波那契公式f(b)=f(b-1)+f(b-2);
        /// <returns></returns>
        public int fbonacciSearch2(int[] array, int left, int right, int[] fb, int key, int k, int length)
        {
            while(left<=right)
            {
                int mid = left + fb[k - 1] - 1;
                if (array[mid]>key)
                {
                    right = mid - 1;
                    k -=1;
                }
                else if(array[mid]<key)
                {
                    left = mid + 1;
                    k -= 2;
                }
                else
                {
                    if(mid<length)
                    {
                        return mid;
                    }
                    else
                    {
                        return length - 1;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// 斐波那契查找
        /// </summary>
        /// <param name="array">临时数组</param>
        /// <param name="left">最左边的数的索引</param>
        /// <param name="right">最右边数的索引</param>
        /// <param name="fb">斐波那契数组</param>
        /// <param name="key">查找的值</param>
        /// <param name="k">斐波那契数组中刚好大于数组长度数的索引</param>
        /// <param name="length">所要查找的数组长度</param>
        /// 斐波那契公式f(b)=f(b-1)+f(b-2);
        /// <returns></returns>
        public int fbonacciSearch(int []array,int left,int right,int []fb,int key,int k,int length)
        {
            //Console.WriteLine(left+" "+right+"  " + array[left]+" "+ array[right]);
            if (left > right || key < array[left] || key > array[right] || array.Length == 0)
            {
                return -1;
            } 
            else
            {
                int mid = left + fb[k - 1] - 1;//拆分点
                if (array[mid] > key)
                {
                    return fbonacciSearch(array, left, mid - 1, fb, key, k - 1,length);
                }
                else if (array[mid] < key)
                {
                    return fbonacciSearch(array, mid + 1, right, fb, key, k - 2,length);
                }
                else
                {
                    if(mid<length)
                    {
                        return mid;
                    }
                    else
                    {
                        return length - 1;
                    }
                }

            }
        }
        /// <summary>
        /// 制作斐波那契数组
        /// </summary>
        /// <param name="num">数组长度,大于2</param>
        /// <returns></returns>
        public int[] makeFBArray(int num)
        {
            int[] array = new int[num];
            array[0] = array[1] = 1;
            for(int i=2;i<num;i++)
            { 
                array[i] = array[i - 1] + array[i - 2];
            }
            return array;
        }
    }
}
