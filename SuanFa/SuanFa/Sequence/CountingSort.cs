using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Sequence
{
    class CountingSort
    {
        //static void Main()
        //{
        //    CountingSort cs = new CountingSort();
        //    cs.countingSort();
        //}

        public void countingSort()
        {
            int[] array= { 2, 10, 2, 1, 4, 6, 7, 4 };
            int max = getMax(array);
            int min = getMin(array);
            int[] temp = new int[max - min + 1];
            int[] array2 = new int[array.Length];
            for(int i=0;i<array.Length;i++)//统计每个元素出现次数
            {
                temp[(array[i]-min)]++;
               // Console.WriteLine("(array[i]-min)=" + ((array[i] - min)) +"   "+ temp[(array[i] - min)]);
            }

            for(int i=1;i<temp.Length;i++)//统计该大小的元素首先应该出现的位置
            {
                temp[i] += temp[i - 1];
                Console.WriteLine("temp=" + temp[i]);
            }

            for (int i = array.Length - 1; i >= 0; i--)//排序
            {
                
                array2[temp[(array[i]-min)]-1] = array[i];//temp[(array[i]-min)]为个数，用的时候需要减去1，减去1才为索引
                temp[(array[i]-min)]--;
            }

            for(int i=0;i<array.Length;i++)//将排序好的数据加到array中
            {
                array[i] = array2[i];
            }

            print(array);
            
        }

        public int getMin(int []array)
        {
            int min = array[0];
            foreach(int i in array)
            {
                if(min>i)
                {
                    min = i;
                }
            }
            return min;
        }

        public int getMax(int []array)
        {
            int max = array[0];
            foreach(int i in array)
            {
                if(max<i)
                {
                    max = i;
                }
            }
            return max;
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
