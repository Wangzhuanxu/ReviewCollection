using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Generics
{
    /// <summary>
    /// where关键字
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    class Generics_Class<TKey,TValue>
    {
        

        public Generics_Class(TKey t,TValue v)
        {
            Console.WriteLine(t + "_" + v);
            Generics_func(t, v);
            Generics_func1<int>(14);
        }

        public void Generics_func(TKey t,TValue v)
        {
            Console.WriteLine(t + " " + v);
        }

        public void Generics_func1<T>(T t)
        {
            Console.WriteLine("t=" + t);
        }
    }
    
    class Generics_Test
    {
        //static void Main()
        //{
        //    Generics_Class<int, string> g = new Generics_Class<int, string>(12, "32");
        //    Generics_Class1<int> g1 = new Generics_Class1<int>();
        //    Generics_Class2<string> g2 = new Generics_Class2<string>();
        //    Generics_Class4<Generics_Class3> g3 = new Generics_Class4<Generics_Class3>();
        //    Generics_Class5<Generics_Class6> g4 = new Generics_Class5<Generics_Class6>();
           
        //}
    }

    class Generics_Class1<T>
        where T:struct
    {
        
    }

    class Generics_Class2<T>
       where T : class
    {
        
    }

    interface IGenerics
    {

    }

   class Generics_Class3:IGenerics
    {
        int i = 0;
    }
    class Generics_Class4<T>
        where T:IGenerics
    {

    }

    class Generics_Class5<T>
        where T : Generics_Class3
    {

    }

    class Generics_Class6:Generics_Class3
    {

    }
}
