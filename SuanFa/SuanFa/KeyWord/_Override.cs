using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.KeyWord
{
    abstract class _Override
    {
        //public abstract int i;//错误，i是字段
        public abstract int Current//抽象属性
        {
            get;
            
        }
        public abstract void oi();//方法
        public virtual int Next//抽象字段
        {
            get;
            set;
        }
        public abstract event Action<int> e;//抽象事件
        public abstract int this[int index]//抽象索引器
        {
            get;
        }
    }
    class _OverrideSon:_Override
    {
        public override int Current {
            get => throw new NotImplementedException();
        }
        public override event Action<int> e;
        public override void oi()
        {
            throw new NotImplementedException();
        }
        public override int Next {
            get => base.Next;
            set => base.Next = value;
        }

        public override int this[int index] => 
            throw new NotImplementedException();
    }
}
