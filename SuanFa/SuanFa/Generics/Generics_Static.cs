using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Generics
{
    class Generics_Static<T>
    {
        public static int i = 0;
    }
    class Generics_Static2<T>:Generics_Static<T>
    {

    }
    class Generics_Static_Test
    {
        //static void Main()
        //{
        //    Generics_Static<int>.i = 11;
        //    Generics_Static<string>.i = 123;
        //    Generics_Static2<int>.i = 2324;
        //    Console.WriteLine(Generics_Static<int>.i + "  " + Generics_Static<string>.i);
        //}
    }

}
