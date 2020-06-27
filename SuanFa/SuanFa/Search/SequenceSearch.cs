using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Search
{
    /// <summary>
    /// 顺序查找--无序查找
    /// 查找成功时的平均查找长度为：（假设每个数据元素的概率相等） ASL = 1/n(1+2+3+…+n) = (n+1)/2 ;
　　//当查找不成功时，需要n+1次比较，时间复杂度为O(n);
    //所以，顺序查找的时间复杂度为O(n)。
    /// </summary>
    class SequenceSearch
    {
        //static void Main()
        //{
        //    int[] nums = { 1, 2, 4, 34, 5345, 34, 43, 342 };
        //    SequenceSearch ss = new SequenceSearch();
        //    Console.WriteLine("index=" + ss.sequenceSearch(nums, 342));
        //}
        /// <summary>
        /// 顺序查找
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="key">查找的值</param>
        /// <returns></returns>
        public int  sequenceSearch(int []array,int key)
        {
            int index = -1;
            for(int i=0;i<array.Length;i++)
            {
                if(array[i]==key)
                {
                    index = i;
                }
            }
            return index;
        }
    }
}
