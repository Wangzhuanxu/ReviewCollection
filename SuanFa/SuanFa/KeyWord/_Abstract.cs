using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.KeyWord
{
    abstract class _Abstract
    {
        void _A() { }//非抽象方法
        protected abstract void _AA();
    }
    abstract class _AbstractSon1:_Abstract
    {//抽象类继承抽象类不需要做任何事，当然也可以
     //实现父类的抽象方法
        protected override void _AA()//此方法可写也可不写
        {

        }

    }
    class _AbstractSon2 :_AbstractSon1
    {
       //若前面类实现了抽象方法，则其子类可不必须再次重写抽象方法
       //当然也可以重写
        protected override void _AA()//该方法不必须存在
        {

        }
    }
    class _AbstractSon3:_Abstract
    {
        protected override void _AA()//该方法必须村子
        {
            throw new NotImplementedException();
        }
    }

}
