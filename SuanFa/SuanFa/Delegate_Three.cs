using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace SuanFa
{
    public delegate int  AddDelegate(int i, int j);
    class Delegate_Three
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Client application started!\n");
        //    Thread.CurrentThread.Name = "Main Thread";
        //    Delegate_Three dt = new Delegate_Three();
        //    AddDelegate ad = new AddDelegate(dt.Add);
        //    AsyncCallback asy = new AsyncCallback(dt.complete);
        //    IAsyncResult asyncResult = ad.BeginInvoke(2, 5, asy, "On Complete");
        //    // 做某些其它的事情，模拟需要执行3 秒钟
        //    for (int i = 1; i <= 3; i++)
        //    {
        //        Thread.Sleep(TimeSpan.FromSeconds(i));
        //        Console.WriteLine("{0}: Client executed {1} second(s).",
        //            Thread.CurrentThread.Name, i);
        //    }
        //    Console.WriteLine("\nPress any key to exit...");
        //    Console.ReadLine();
        //}
        public void complete(IAsyncResult asyncResult)
        {
            //AsyncResult是IAsyncResult的子类
            AsyncResult asy = (AsyncResult)asyncResult;
            AddDelegate ad = (AddDelegate)asy.AsyncDelegate;
            string data = (string)asy.AsyncState;
            int result=0;
            try
            {
                result = ad.EndInvoke(asyncResult);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Data);
            }
             
            Console.WriteLine("{0}: Result, {1}; Data: {2}\n", Thread.CurrentThread.Name, result, data);
        }
        public int Add(int x, int y)
        {
            if (Thread.CurrentThread.IsThreadPoolThread)
            {
                Thread.CurrentThread.Name = "Pool Thread";
            }
            Console.WriteLine("Method invoked!");
            // 执行某些事情，模拟需要执行2 秒钟
            for (int i = 1; i <= 2; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(i));
                Console.WriteLine("{0}: Add executed {1} second(s).", 
                    Thread.CurrentThread.Name, i);
            }
            Console.WriteLine("Method complete!");
            return x + y;
        }
    }
}
