using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.KeyWord
{
    class _Sealed
    {
        public virtual void _A()
        {

        }
    }
    sealed class _SealedSon:_Sealed
    {
        public sealed override void _A()
        {
            base._A();
        }
    }
    //class _SealedSon1:_SealedSon//错误，不可以继承密封类
    //{

    //}
    class _SealedSon2 : _Sealed//重写_A方法
    {
        public override void _A()
        {
            base._A();
        }
    }
    class _SealedSon3:_Sealed
    {
        public sealed override void _A()//重写时使用sealed关键字
        {
            base._A();
        }
    }
    class _SealedSon4:_SealedSon3
    {
        //public sealed override void _A()//因为_SealedSon3对_A重写时使用了sealed
        //                                //所以其_SealedSon4无法再次对_A重写
        //{
        //    base._A();
        //}
    }
    class _SealedSon5:_SealedSon2
    {
        public sealed override void _A()//普通就可以重写
        {
            base._A();
        }
    }

}
