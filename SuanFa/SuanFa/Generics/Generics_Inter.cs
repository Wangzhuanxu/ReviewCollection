using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Generics
{
    class Generics_Inter
    {
        protected int i=0;
    }
    class Generics_InterSon:Generics_Inter
    {
       
        //static void Main()
        //{
        //    Generics_InterSon gi = new Generics_InterSon();
        //    gi.i = 0;
        //}
    }
    abstract class B
    {
        public B(int B)
        {

        }
    }

    abstract class A:B
    {
        public A():this(12)
        {

        }
        public A(int i) : base(i)
        {

        }
    }
}
