using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Graphics
{
    class Compared
    {
        
        //static void Main()
        //{
        //    List<Coord> ls = new List<Coord>();
        //    int[] array = { 2, 4,3,3 };
        //    for(int i=0;i<array.Length;i++)
        //    {
        //        ls.Add(new Coord(array[i]));
        //    }

        //    foreach(Coord cd in ls)
        //    {
        //        Console.WriteLine(cd.g);
        //    }

        //    ls.Sort();

        //    foreach (Coord cd in ls)
        //    {
        //        Console.WriteLine(cd.g);
        //    }
        //}
    }

    class Coord:IComparer<Coord>,IComparable
    {
        public int g;

        public Coord(int g)
        {
            this.g = g;
        }

        public int Compare(Coord x, Coord y)
        {
            if(x.g>y.g)
            {
                return 1;
            }
            else if(x.g<y.g)
            {
                return -1;
            }
            return -1;
        }

        public int CompareTo(object obj)
        {
            Coord cd = (Coord)obj;
            if (this.g < cd.g)
            {
                return 1;
            }
            else if (this.g > cd.g)
            {
                return -1;
            }
            return 0;
        }
    }
}
