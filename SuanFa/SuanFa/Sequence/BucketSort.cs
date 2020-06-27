using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Sequence
{
    class BucketSort
    {
        static void Main()
        {
            //create an object
            BucketSort bs = new BucketSort();
            bs.bucketSort();
        }

        public void bucketSort()
        {
            //define ordered sequence
            int[] array = { 21, 8, 6, 11, 36, 50, 27,42,30,12 };
            //define buckets,ten buckets ,the size of the bucket is ten
            int[,] bucket = new int[10,10];
            //initialize buckets
            for(int i=0;i<bucket.GetLength(0);i++)
            {
                for(int j=0;j<bucket.GetLength(1);j++)
                {
                    bucket[i, j] = 0;
                }
            }
            //sort
            for(int i=0;i<array.Length;i++)
            {
                int index = getIndex(array[i]);
                insertSort(bucket,array[i],index);
            }
            //put the ordered sequence to array
            int t = 0;
            for (int i = 0; i < bucket.GetLength(0); i++)
            {
                for (int j = 0; j < bucket.GetLength(1); j++)
                {
                    if(bucket[i,j]!=0&&j!=0)
                    {
                        array[t] = bucket[i,j];
                        t++;
                    }
                }
            }
            //print ordered array
            print(array);
        }
        //insert sort
        public void insertSort(int[,] array,int k,int index)
        {
            //the position of the new element
            int i = array[index,0] + 1;
            while (i>0&&k<array[index,i])
            {
                //move the bigger element  back
                array[index,i + 1] = array[index,i];
                i--;
            }
            //save new element
            array[index,i + 1] = k;
            array[index, 0]++;
        }
        //the index of the bucket
        public int getIndex(int i)
        {
            return i / 10 % 10;
        }

        /// <summary>
        /// print
        /// </summary>
        /// <param name="nums">the array which will printed</param>
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
