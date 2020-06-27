using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SuanFa.KeyWord
{
    class AProgram
    {
        public virtual void AFun()//方法
        {
            Console.WriteLine("父类的虚方法");
        }
        public virtual event Action<int> a;//定义带一个参数的事件
        public virtual string Current//属性
        {
            get;set;
        }
        int this[int index]//索引器
        {
            get
            {
                return 1;
            }
        }
    }
    class Program : AProgram
    {
        public override void AFun()//c重写
        {
            Console.WriteLine("子类的虚方法");
        }
        public override event Action<int> a;//重写
        
    }
    class ProgramSon:Program
    {
        //static void Main(string[] args)
        //{
        //    AProgram ap = new AProgram();
        //    AProgram p = new Program();
        //    AProgram pr = new Program();
        //    AProgram ps = new ProgramSon();
        //    ap.AFun();
        //    p.AFun();
        //    pr.AFun();
        //    ps.AFun();
        //}
    }
}
