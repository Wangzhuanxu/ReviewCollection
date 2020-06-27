using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.KeyWord
{
    class _New
    {
        public void father()
        {
            Console.WriteLine("我是父亲");
        }
    }
    class _NewSon:_New
    {
        public new void father()
        {
            Console.WriteLine("我是儿子");
        }
       
    }
    class _NewSon2:_New
    {
        //static void Main()
        //{
        //    _New s = new _NewSon2();
        //    _New s1 = new _NewSon();
        //    _New s2 = new _New();
         
        //    _NewSon s4 = new _NewSon();
        //    s.father();
        //    s1.father();
        //    s2.father();
        //    s4.father();
        //    _NewSon3<_NewSon2> n = new _NewSon3<_NewSon2>(2);//初始化成功，_NewSon3具有无参构造器
        //   // _NewSon3<_NewSon4> n2 = new _NewSon3<_NewSon4>(2);//初始化失败，_NewSon4不具有无参构造器
        //}
    }
    class _NewSon3<T> where T:new()//检查参数T类是否具有无参构造器
    {
        public _NewSon3(int T)
        {

        }
    }
    class _NewSon4
    {
        public _NewSon4(int i)
        {

        }
    }
}
