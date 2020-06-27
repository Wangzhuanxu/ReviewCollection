using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.IEnumerableInterface
{
    class InheritIEnumerable : IEnumerable
    {
        public int[] array = new int[] { 1, 3, 4 };

        //static void Main()
        //{
        //    InheritIEnumerable ii = new InheritIEnumerable();
        //    Console.WriteLine("foreach执行结果：");
        //    foreach (int i in ii)
        //    {
        //        Console.WriteLine("i=" + i);
        //    }
        //    Console.WriteLine("普通迭代：");
        //    IEnumerable ieable = new InheritIEnumerable();
        //    IEnumerator ie = ieable.GetEnumerator();
        //    while (ie.MoveNext())
        //    {
        //        Console.WriteLine(ie.Current);
        //    }
        //}
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return 1;
            yield return 0;
            yield return 4;
        }

        /// <summary>
        /// 返回IEnumerator类型的对象
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            Console.WriteLine("获取枚举器");
            return new InheritIEnumerator(array);
        }
    }

    public class InheritIEnumerator : IEnumerator
    {
        int[] array;
        int pos = -1;
        public InheritIEnumerator(int []array)
        {
            this.array = array;
        }
        public object Current
        {
            get
            {
                Console.WriteLine("获取Current");
                if (pos<array.Length)
                {
                    return array[pos];
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public bool MoveNext()
        {
            
            if (pos<array.Length-1)
            {
                Console.WriteLine("MoveNext true");
                pos++;
                return true;
            }
            else
            {
                Console.WriteLine("MoveNext false");
                return false;
            }
        }

        public void Reset()
        {
            pos = -1;
        }
    }
}
