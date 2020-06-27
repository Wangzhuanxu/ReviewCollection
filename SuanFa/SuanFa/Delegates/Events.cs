using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Delegates
{
    public delegate void ADD(int i);
    class Events
    {
        public  event  Action<int> a;
        public ADD ad;
        public void add(int i)
        {
            // Console.WriteLine(a(i));
            a(i);
        }

        public static int i = 0;
    }

    class EventsSon:Events
    {

        protected static void DS(int i)
        {
            Console.WriteLine("i=" + i);
        }
        //static void Main()
        //{
        //    Events e = new Events();
        //    e.a += DS;
        //    e.ad = DS;
        //    e.ad(1);
        //    e.add(2);
        //    //e.add(1, DS);
        //    //e.a += Eve add;
        //    Console.WriteLine(Events.i);
        //    Console.WriteLine(EventsSon.i);
        //    Console.WriteLine(ES.i);
        //    EventsSon.i = 11;
        //    Console.WriteLine(Events.i);
        //    Console.WriteLine(EventsSon.i);
        //    Console.WriteLine(ES.i);
        //    ES.i = 111;
        //    Console.WriteLine(Events.i);
        //    Console.WriteLine(EventsSon.i);
        //    Console.WriteLine(ES.i);
        //}
    }
    class ES:EventsSon
    {

    }

}
