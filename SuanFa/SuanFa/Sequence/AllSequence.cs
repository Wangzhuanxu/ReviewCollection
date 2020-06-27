using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Sequence
{
    public class AllSequence
    {
      
        //static void Main()
        //{
        //    AllSequence all = new AllSequence();
        //    int index = 1;

        //    DateTime dt1 = new DateTime();
        //    DateTime dt2 = new DateTime();
        //    TimeSpan ts = dt2 - dt1;
        //    Console.WriteLine("====================" + "冒泡排序"+index++);
        //    dt1 = DateTime.Now;
        //    all.bubbleSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    Console.WriteLine("====================" + ts.TotalMilliseconds);
        //    Console.WriteLine();
        //    Console.WriteLine();

        //    Console.WriteLine("====================" + "桶排序" + index++);
        //    dt1 = DateTime.Now;
        //    all.bubbleSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    Console.WriteLine("====================" + ts.TotalMilliseconds);
        //    Console.WriteLine();
        //    Console.WriteLine();

        //    Console.WriteLine("====================" + "计数排序" + index++);
        //    dt1 = DateTime.Now;
        //    all.countingSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    Console.WriteLine("====================" + ts.TotalMilliseconds);
        //    Console.WriteLine();
        //    Console.WriteLine();

        //    Console.WriteLine("====================" + "堆排序" + index++);
        //    dt1 = DateTime.Now;
        //    all.heapSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    Console.WriteLine("====================" + ts.TotalMilliseconds);
        //    Console.WriteLine();
        //    Console.WriteLine();

        //    Console.WriteLine("====================" + "插入排序" + index++);
        //    dt1 = DateTime.Now;
        //    all.insertSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    Console.WriteLine("====================" + ts.TotalMilliseconds);
        //    Console.WriteLine();
        //    Console.WriteLine();

        //    Console.WriteLine("====================" + "归并排序" + index++);
        //    dt1 = DateTime.Now;
        //    all.mergeSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    Console.WriteLine("====================" + ts.TotalMilliseconds);
        //    Console.WriteLine();
        //    Console.WriteLine();

        //    Console.WriteLine("====================" + "快速排序" + index++);
        //    dt1 = DateTime.Now;
        //    all.quickSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    Console.WriteLine("====================" + ts.TotalMilliseconds);
        //    Console.WriteLine();
        //    Console.WriteLine();

        //    Console.WriteLine("====================" + "希尔排序" + index++);
        //    dt1 = DateTime.Now;
        //    all.shellSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    Console.WriteLine("====================" + ts.TotalMilliseconds);
        //    Console.WriteLine();
        //    Console.WriteLine();

        //    Console.WriteLine("====================" + "基数排序" + index++);
        //    dt1 = DateTime.Now;
        //    all.radixSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    Console.WriteLine("====================" + ts.TotalMilliseconds);
        //    Console.WriteLine();
        //    Console.WriteLine();

        //    Console.WriteLine("====================" + "选择排序" + index++);
        //    dt1 = DateTime.Now;
        //    all.selectSort();
        //    dt2 = DateTime.Now;
        //    ts = dt2 - dt1;
        //    Console.WriteLine("====================" + ts.TotalMilliseconds);
        //    Console.WriteLine();
        //    Console.WriteLine();

        //    //Random n = new Random();
        //    //for (int i=0;i<100;i++)
        //    //{
        //    //    Console.Write(n.Next(100)+",");
        //    //}

        //}

        #region 冒泡排序

        public void bubbleSort()
        {
            int[] array = { 63,98,3,26,51,58,74,44,61,98,23,46,7,5,37,8,32,5,30,44,12,7,98,91,96,64,76,73,47
                            ,79,95,97,70,74,88,91,21,64,99,7,13,80,98,13,88,50,14,5,20,0,14,40,84,67,89,55,99,
                            11,30,86,81,1,97,82,2,25,76,32,16,45,86,68,6,23,30,32,8,84,3,46,50,70,52,47,64
                            ,54,13,2,85,32,91,10,33,12,25,12,83,16,10,62};
            int temp = 0;//临时变量
            int pos = 0;//最后一个交换的索引
            int k = array.Length - 1;//需要比较k次
            while (k > 0)
            {
                pos = 0;
                for (int i = 0; i < k; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        pos = i;//记录最后一次交换的数组的索引，该索引后面的数据全部排序完毕
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
                k = pos;
            }

            print(array);
        }
        #endregion

        #region 桶排序
        public void bucketSort()
        {
            int[] array = { 63,98,3,26,51,58,74,44,61,98,23,46,7,5,37,8,32,5,30,44,12,7,98,91,96,64,76,73,47
                            ,79,95,97,70,74,88,91,21,64,99,7,13,80,98,13,88,50,14,5,20,0,14,40,84,67,89,55,99,
                            11,30,86,81,1,97,82,2,25,76,32,16,45,86,68,6,23,30,32,8,84,3,46,50,70,52,47,64
                            ,54,13,2,85,32,91,10,33,12,25,12,83,16,10,62};
            int[,] array2 = new int[10, 10];//通数组，分10个桶，每个桶的第一个元素为该桶内元素个数，每个桶可装9个元素
            for(int i=0;i<array.Length-1;i++)
            {
                int index = getIndex(array[i]);//获取该应在那个桶中
                binsertSort(array2, array[i], index);//将元素放入该桶中的相应位置
            }

            int t = 0;
            for(int i=0;i<array2.GetLength(0);i++)
            {
                for(int j=0;j<array2.GetLength(1);j++)
                {
                    if(j!=0&&array2[i,j]!=0)
                    {
                        array[t] = array2[i, j];
                        t++;
                    }
                }
            }

            print(array);
        }
        //获取所在桶的索引
        public int getIndex(int i)
        {
            return i / 10 % 10;
        }
        //每个桶内元素排序
        public void binsertSort(int [,]array,int k,int index)
        {
            int i = array[index, 0] + 1;
            while(i>0&&k<array[index,i])
            {
                array[index, i + 1] = array[index, i];
                i--;
            }
            array[index, i + 1] = k;
            array[index, 0]++;
        }
        #endregion

        #region 计数排序

        public void countingSort()
        {
            int[] array = { 63,98,3,26,51,58,74,44,61,98,23,46,7,5,37,8,32,5,30,44,12,7,98,91,96,64,76,73,47
                            ,79,95,97,70,74,88,91,21,64,99,7,13,80,98,13,88,50,14,5,20,0,14,40,84,67,89,55,99,
                            11,30,86,81,1,97,82,2,25,76,32,16,45,86,68,6,23,30,32,8,84,3,46,50,70,52,47,64
                            ,54,13,2,85,32,91,10,33,12,25,12,83,16,10,62};
            int[] mm= getMM(array);//获取最大最小值
            int[] array2 = new int[array.Length];//临时数组，排序时所用的数组，里面存储排好顺序的数据。
            int[] temp = new int[mm[0]-mm[1]+1];//辅助数组，里面先存储每个元素出现次数，在存储该元素出现的初始位置
            for (int i=0;i<array.Length;i++)//统计每个元素出现次数
            {
                temp[array[i] - mm[1]]++;//array[i]-min是控制array数组元素大小<辅助数组temp最大索引
            }

            for(int i=1;i<temp.Length;i++)//temp[i]=每个元素出现的初始位置+1
            {
                temp[i] += temp[i - 1];
            }

            for(int i=array.Length-1;i>=0;i--)
            {
                array2[temp[array[i] - mm[1]] - 1] = array[i];//使用时需要-1
                temp[array[i] - mm[1]]--;
            }

            for(int i=0;i<array.Length;i++)//array2数据拷贝到array中
            {
                array[i] = array2[i];
            }
            print(array);
        }

        public int[] getMM(int []array)
        {
            int[] mm = { array[0],array[0]};
            foreach(int i in array)
            {
                if(i>mm[0])//最大值
                {
                    mm[0] = i;
                }
                if(i<mm[1])//最小值
                {
                    mm[1] = i;
                }
            }
            return mm;
        }

        #endregion

        #region 堆排序
        public void heapSort()
        {
            int[] array = { 63,98,3,26,51,58,74,44,61,98,23,46,7,5,37,8,32,5,30,44,12,7,98,91,96,64,76,73,47
                            ,79,95,97,70,74,88,91,21,64,99,7,13,80,98,13,88,50,14,5,20,0,14,40,84,67,89,55,99,
                            11,30,86,81,1,97,82,2,25,76,32,16,45,86,68,6,23,30,32,8,84,3,46,50,70,52,47,64
                            ,54,13,2,85,32,91,10,33,12,25,12,83,16,10,62};
            for (int i= (array.Length - 1) / 2; i>=0;i--)//有子节点的元素,必须从有节点的最底层找起
            {
                heapAdjuest(array, array.Length,i);
            }
            int temp = 0;
            for(int i=array.Length-1;i>0;i--)
            {
                temp = array[i];
                array[i] = array[0];
                array[0] = temp;
                heapAdjuest(array,i, 0);
            }

            print(array);
        }
        /// <summary>
        /// 调整堆
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="k">需要插入的元素</param>
        public void heapAdjuest(int []array,int len,int k)
        {
            int left = 0;
            int right = 0;
            int j =0;
            int temp = 0;
            while((left=k*2+1)<len)//是否有左节点
            {
                j = left;
                right = left + 1;
                if(right<len&&array[right]>array[left])//比较左右节点那个更大
                {
                    j = right;
                }
                if(array[j]>array[k])
                {
                    temp = array[j];
                    array[j] = array[k];
                    array[k] = temp;
                }
                else
                {
                    break;
                }
                k = j;
            }

        }

        #endregion

        #region 插入排序

        public void insertSort()
        {
            int[] array = { 63,98,3,26,51,58,74,44,61,98,23,46,7,5,37,8,32,5,30,44,12,7,98,91,96,64,76,73,47
                            ,79,95,97,70,74,88,91,21,64,99,7,13,80,98,13,88,50,14,5,20,0,14,40,84,67,89,55,99,
                            11,30,86,81,1,97,82,2,25,76,32,16,45,86,68,6,23,30,32,8,84,3,46,50,70,52,47,64
                            ,54,13,2,85,32,91,10,33,12,25,12,83,16,10,62};
            int j = 0;//比较的数的索引
            int t = 0;//需要插入的数
            for(int i=1;i<array.Length;i++)
            {
                j = i - 1;
                t = array[i];
                while(j>=0&&array[j]>t)
                {
                    array[j+1] = array[j];
                    j--;
                }
                array[j+1] = t;
            }
            print(array);
        }

        #endregion

        #region 归并排序
        public void mergeSort()
        {
            int[] array = { 63,98,3,26,51,58,74,44,61,98,23,46,7,5,37,8,32,5,30,44,12,7,98,91,96,64,76,73,47
                            ,79,95,97,70,74,88,91,21,64,99,7,13,80,98,13,88,50,14,5,20,0,14,40,84,67,89,55,99,
                            11,30,86,81,1,97,82,2,25,76,32,16,45,86,68,6,23,30,32,8,84,3,46,50,70,52,47,64
                            ,54,13,2,85,32,91,10,33,12,25,12,83,16,10,62};
            int[] temp = new int[array.Length];
            sort(array, 0, array.Length - 1,temp);
            print(array);
        }
        public void sort(int []array,int left,int right,int[] temp)
        {
            
            if(left<right)
            {
                int mid = (left + right) / 2;
                sort(array, left, mid,temp);
                sort(array, mid + 1, right,temp);
                merge(array, left, right, mid, temp);
            }
        }

        public void merge(int []array,int _left,int _right,int mid,int []array2)
        {
            int left = _left;
            int right = mid+1;
            int index = 0;
            while(left<=mid&&right<=_right)
            {
                if(array[left]>array[right])
                {
                    array2[index] = array[right];
                    right++;
                }
                else
                {
                    array2[index] = array[left];
                    left++;
                }
                index++;
            }

            while(left<=mid)
            {
                array2[index] = array[left];
                left++;
                index++;
            }

            while(right<=_right)
            {
                array2[index] = array[right];
                right++;
                index++;
            }

            index = 0;
            for(int i=_left;i<=_right;i++)
            {
                array[i] = array2[index];
                index++;
            }
        }

        #endregion

        #region 快速排序

        public void quickSort()
        {
            int[] array = { 63,98,3,26,51,58,74,44,61,98,23,46,7,5,37,8,32,5,30,44,12,7,98,91,96,64,76,73,47
                            ,79,95,97,70,74,88,91,21,64,99,7,13,80,98,13,88,50,14,5,20,0,14,40,84,67,89,55,99,
                            11,30,86,81,1,97,82,2,25,76,32,16,45,86,68,6,23,30,32,8,84,3,46,50,70,52,47,64
                            ,54,13,2,85,32,91,10,33,12,25,12,83,16,10,62};
            qSort(array, 0, array.Length - 1);
            print(array);
        }

        public void qSort(int[] array, int _left, int _right)
        {
            
            int left = _left;
            int right = _right;
            int radix = array[left];
            
            while (left != right)
            {
                while (right>left&&array[right]>=radix)
                {
                    
                    right--;
                }
                array[left] = array[right];
                while(left<right&&array[left]<=radix)
                {
                    left++;
                }
                array[right] = array[left];
            }
            array[left] = radix;
           
            if (left-1>=_left)
            {
                
                qSort(array, _left, left - 1);

            }
            if(right+1<=_right)
            {
                
                qSort(array, left + 1, _right);
            }
            
        }
        #endregion

        #region 基数排序
        public void radixSort()
        {
            int[] array = { 63,98,3,26,51,58,74,44,61,98,23,46,7,5,37,8,32,5,30,44,12,7,98,91,96,64,76,73,47
                            ,79,95,97,70,74,88,91,21,64,99,7,13,80,98,13,88,50,14,5,20,0,14,40,84,67,89,55,99,
                            11,30,86,81,1,97,82,2,25,76,32,16,45,86,68,6,23,30,32,8,84,3,46,50,70,52,47,64
                            ,54,13,2,85,32,91,10,33,12,25,12,83,16,10,62};

            int max = getMax(array);
            for(int i=1;i<max;i*=10)
            {
                rSort(array, i);
            }
            print(array);
        }
        /// <summary>
        ///获取排序中最大的数
        /// </summary>
        /// <param name="array">数组</param>
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
        /// 基数排序
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="exp">基数，也就是按哪位（十百千）</param>
        public void rSort(int[] array, int exp)
        {
            int[] array2 = new int[array.Length];
            int[] temp = new int[10];//每个位数所出现的次数
            for (int i = 0; i < array.Length; i++)//记录该位数出现的次数
            {
                temp[array[i] / exp % 10]++;
            }

            for (int i = 1; i < 10; i++)//该位数出现的起始位置
            {
                temp[i] += temp[i - 1];
            }

            for(int i=array.Length-1;i>=0;i--)
            {
                array2[temp[array[i] / exp % 10]-1] = array[i];
                temp[array[i] / exp % 10]--;
            }

            for(int i=0;i<array.Length;i++)
            {
                array[i] = array2[i];
            }
         

            
        }

        #endregion

        #region 希尔排序
        public void shellSort()
        {
            int[] array = { 63,98,3,26,51,58,74,44,61,98,23,46,7,5,37,8,32,5,30,44,12,7,98,91,96,64,76,73,47
                            ,79,95,97,70,74,88,91,21,64,99,7,13,80,98,13,88,50,14,5,20,0,14,40,84,67,89,55,99,
                            11,30,86,81,1,97,82,2,25,76,32,16,45,86,68,6,23,30,32,8,84,3,46,50,70,52,47,64
                            ,54,13,2,85,32,91,10,33,12,25,12,83,16,10,62};
            int gap = array.Length / 2;
            int t=0;//要插入的数
            int j = 0;//要比较的数的索引
            while(gap>=1)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    t = array[i];
                    j = i - gap;
                    
                    while(j>=0&&t<array[j])
                    {
                        array[j + gap] = array[j];
                        j -= gap;
                    }
                    array[j + gap] = t;
                    
                }
                gap = gap / 2;
            }

            print(array);
        }
        #endregion

        #region
        public void selectSort()
        {
            int[] array = { 63,98,3,26,51,58,74,44,61,98,23,46,7,5,37,8,32,5,30,44,12,7,98,91,96,64,76,73,47
                            ,79,95,97,70,74,88,91,21,64,99,7,13,80,98,13,88,50,14,5,20,0,14,40,84,67,89,55,99,
                            11,30,86,81,1,97,82,2,25,76,32,16,45,86,68,6,23,30,32,8,84,3,46,50,70,52,47,64
                            ,54,13,2,85,32,91,10,33,12,25,12,83,16,10,62};
            int min = 0;//最小数
            int t = 0;//最小数的索引
            for (int i=0;i<array.Length;i++)
            {
                min = array[i];
                for(int j=i;j<array.Length;j++)
                {
                    if(array[j]<min)
                    {
                        min = array[j];
                        t = j;
                    }
                }
                if(i!=t)
                {
                    int temp = array[i];
                    array[i] = array[t];
                    array[t] = temp;
                }
            }
            print(array);
        }
#endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="nums">打印的数组</param>
        public void print(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write("i=" + nums[i] + "，");
            }
            Console.WriteLine();
        }

#endregion
    }


}
