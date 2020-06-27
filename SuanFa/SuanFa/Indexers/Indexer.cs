using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Indexers
{
    class Indexer : IProgramA, IProgramB//实现多个接口
    {
        //实现属性,隐式实现
        public string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        //实现方法，隐式实现
        public void addFunc(int i, int j)
        {
            Console.WriteLine("i+j=" + (i + j));
        }
        //实现索引器，隐式实现
        int[] array = { 2, 4, 53, 4, 5, 324 };
        public int this[int i]
        {
            get
            {
                if (i < array.Length)
                {
                    return array[i];
                }
                return -1;
            }
        }
        //实现事件，隐式实现
        public event AddFunc af;
        //实现另一个接口中的方法，显式实现
        void IProgramB.funcB()
        {
            Console.WriteLine("显式实现的接口方法");
        }
        //static void Main()
        //{
        //    //类的实例方法接口方法
        //    Indexer id = new Indexer();
        //    id.af += id.addFunc;
        //    id.af(1, 2);

        //    //接口的实例方法接口方法
        //    IProgramA ia = new Indexer();
        //    ia.addFunc(23, 23);

        //    //funcB只可有IProgramB的实例调用
        //    IProgramB ib = new Indexer();
        //    ib.funcB();
        //}
    }
    public delegate void AddFunc(int i, int j);
    interface IProgramA
    {
        //属性
        string Name
        {
            get;set;
        }
        //方法
        void addFunc(int i, int j);
        //索引器
        int this[int i]
        {
            get;
        }
        //事件
        event AddFunc af;
    }
    interface IProgramB
    {
        void funcB();
    }

   
}
