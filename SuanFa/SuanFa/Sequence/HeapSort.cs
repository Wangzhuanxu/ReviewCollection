using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Sequence
{
    class HeapSort
    {
        //static void Main()
        //{
        //    HeapSort hs = new HeapSort();
        //    hs.heapSort();
        //}

        public void heapSort()
        {
            int[] array = { 20, 50, 20, 40, 70, 10, 80, 30, 60 };
            for (int i = (array.Length - 1) / 2; i>=0; i--)
            {
                headAdjuest(array, array.Length, i);
            }
            print(array);
            for (int i=array.Length-1;i>0;i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                headAdjuest(array, i, 0);
            }

            print(array);
        }

        public void headAdjuest(int[] array, int len,int i)
        {
            int left, right, now;
            int temp;
            while((left=i*2+1)<len)//左子是否存在
            {
                right = left + 1;
                now = left;
                if(right<len&&array[now]<array[right])//找左右节点中比较大的
                {
                    now++;
                }

                if(array[now]>array[i])//子节点是否大于父节点，大于就交换
                {
                    temp = array[now];
                    array[now] = array[i];
                    array[i] = temp;
                }
                else//否则退出循环
                {
                    break;
                }

                i = now;//交换完毕，把当前节点切换到其子节点继续调整
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
