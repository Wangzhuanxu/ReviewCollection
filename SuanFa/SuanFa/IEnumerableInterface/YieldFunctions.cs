using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.IEnumerableInterface
{
    class YieldFunctions:IEnumerable<int>
    {
        int[] array = { 1, 32, 4 };
        public static IEnumerable<int> getNums()
        {
            yield return 1;
            yield return 0;
            yield return 3;
            yield break;
            yield return 5;
        }
        //public static void Main()
        //{
        //    YieldFunctions ye = new YieldFunctions();
        //    foreach (int i in ye)
        //    {
        //        Console.WriteLine(i);
        //    }
        //    IEnumerable iee = new YieldFunctions();
        //    IEnumerator ie = iee.GetEnumerator();
        //    while(ie.MoveNext())
        //    {
        //        Console.WriteLine(ie.Current);
        //    }
        //}

        public IEnumerator<int> GetEnumerator()
        {
            return new YieldFunctionsIE(array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class YieldFunctionsIE : IEnumerator<int>
    {

        int[] array;
        int pos = -1;
        public YieldFunctionsIE(int []array)
        {
            this.array = array;
        }

        public int Current
        {
            get
            {
                return array[pos];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            array = null;
        }

        public bool MoveNext()
        {
            if (pos < array.Length - 1)
            {
                pos++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            pos = -1;
        }
    }
}
