using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Sequence
{
    class MergeSort
    {
        //static void Main()
        //{
        //    MergeSort ms = new MergeSort();
        //    int[] array = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        //    ms.sort(array, 0, array.Length - 1);
        //    ms.print(array);
        //}

        public void sort(int[] array, int left, int right)
        {
            if(left<right)
            {
                int mid = (left + right) / 2;
                sort(array, left, mid);
                sort(array, mid + 1, right);
                merge(array, left, right, mid);
            }
        }

        public void merge(int []array,int left,int right,int mid)
        {
            int i = left;//左边索引
            int j = mid+1;//右边索引
            int t = 0;//临时数组索引
            int[] temp = new int[array.Length];//临时数组
            while(i<=mid&&j<=right)
            {
                if(array[i]<array[j])
                {
                    temp[t] = array[i];
                    i++;
                }
                else
                {
                    temp[t] = array[j];
                    j++;
                }
                t++;
            }

            while(i<=mid)
            {
                temp[t] = array[i];
                i++;
                t++;
            }
            while (j <= right)
            {
                temp[t] = array[j];
                j++;
                t++;
            }
            t = 0;
            while(left<=right)
            {
                array[left] = temp[t];
                left++;
                t++;
            }
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
