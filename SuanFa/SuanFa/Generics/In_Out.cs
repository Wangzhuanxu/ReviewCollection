using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Generics
{
    class In_Out
    {
        //static void Main()
        //{
        //    IDisplay<In_Out> id = new In_OutSon2();
        //    IDisplay<In_OutSon> id1 = new In_OutSon2();
        //    IDisplay<In_OutSon> id2 = id;
        //    int? x = null;
        //    if(x==null)
        //    {
        //        Console.WriteLine("sdfsd");
        //    }
        //}
    }
    class In_OutSon : In_Out
    {

    }
    interface IDisplay<in T>
    {

    }
    class In_OutSon2:IDisplay<In_Out>
    {

    }


}
