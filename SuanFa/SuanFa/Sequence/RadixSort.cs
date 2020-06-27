using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Sequence
{
    class RadixSort
    {
        //static void Main()
        //{
        //    RadixSort rs = new RadixSort();
        //    int []a = { 53, 3, 542, 748, 14, 214, 154, 63, 616 };
        //    int max = rs.getMax(a);
        //    for(int i=1;i<max;i*=10)
        //    {
        //        rs.radixSort(a, i);
        //    }
        //    rs.print(a);
        //}

        public int getMax(int []array)
        {
            int max = array[0];
            for(int i=0;i<array.Length;i++)
            {
                if(array[i]>max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public void radixSort(int []array,int exp)
        {
            int[] bucket = new int[10];//记录每位在array2中的起始位置
            int[] array2 = new int[array.Length]; 
            for(int i=0;i<array.Length;i++)//查看其最小以为是几
            {
                bucket[(array[i] / exp) % 10]++;
            }

            for(int i=1;i<10;i++)//查看尾数是该位的时候在array2中的位置
            {
                bucket[i] += bucket[i - 1];//bucket[i]记录的是array2中的第几个，不是array2中的索引，求索引时需要减去1
            }

            for(int i=array.Length-1;i>=0;i--)//将排序后的数字写入临时数组array2
            {
                //Console.WriteLine("i=" + i + " (array[i] / exp) % 10]="+(bucket[(array[i] / exp) % 10]));
                array2[bucket[(array[i] / exp) % 10]-1] = array[i];
                
                bucket[(array[i] / exp) % 10]--;
            }

            for(int i =0;i<array.Length;i++)//将数据放回原数组
            {
                array[i] = array2[i];
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
