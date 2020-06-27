using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.GarbageCollection
{
    class Finalizes:IDisposable
    {
        public Finalizes()
        {
            Console.WriteLine("Finalizes");
        }
        ~Finalizes()
        {
            Console.WriteLine("~Finalizes");
        }

        protected virtual void Dispose(bool isDispose)
        {

        }

        public void Dispose()
        {
            Dispose(true);
        }
    }

    class Finalizes2:Finalizes
    {
        public Finalizes2()
        {
            Console.WriteLine("Finalizes2");
        }
        ~Finalizes2()
        {
            Console.WriteLine("~Finalizes2");
        }

        protected override void Dispose(bool isDispose)
        {
            Console.WriteLine("子类虚拟方法");
        }

        //static void Main()
        //{
        //    Finalizes f = new Finalizes2();
        //    f.Dispose();
        //}
    }
}
