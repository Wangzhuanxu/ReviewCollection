using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Sequence
{
    class QuickSort
    {
        //static void Main()
        //{
        //    QuickSort qs = new QuickSort();
        //    int[] array = { 10, 5, 3, 1, 7, 2, 8 };
        //    qs.quickSort(array, 0, (array.Length - 1));
        //    qs.print(array);
        //}

        public void quickSort(int []array,int _left,int _right)
        {
            int left = _left;//最左边第一项，也就是比较的基数
            int right = _right;//最右边的一项
            int temp = 0;//基数
            temp = array[left];
           
            while (right!=left)//排序个数需要大于1个
            {
                while (right>left&&array[right]>=temp)//右边元素大于基数
                {
                    right--;//找下一个右边元素，直到找到一个正好小于基数的元素
                }
                array[left] = array[right];//将小于的元素替换到左边
                while(left<right&&array[left]<=temp)//左边元素小于基数
                {
                    left++;//找下一个左边元素，直到找到一个正好大于基数的元素
                }
                array[right] = array[left];//将大于的元素替换到右边
            }

            array[left] = temp;//将基数替换到左右相等的地方

            if(left-1>=_left)  //左边数组个数大于等于1
            {
                quickSort(array, _left, left - 1);//继续遍历左边数组
            }
            if(right+1<=_right)//右边数组个数大于等于1
            {
                quickSort(array, left + 1, _right);//继续遍历右边数组
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
