using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuanFa
{
    /// <summary>
    /// 观察者模式
    /// </summary>
    /// <param name="eb"></param>
    public delegate void EventHandler(EventBase eb);
    public class Delegate_Observe
    {
        /// <summary>
        ///  已被注册事件，这里面的一些事件在某帧中将会被执行
        /// </summary>
        public Dictionary<string, List<EventHandler>> registedCallbacks 
            = new Dictionary<string, List<EventHandler>>();
        /// <summary>
        /// 在派发信息时新注册的事件，在下次派发时将被添加到registedCallbacks中。
        /// </summary>
        public Dictionary<string, List<EventHandler>> registedCallbacksPending 
            = new Dictionary<string, List<EventHandler>>();
        /// <summary>
        /// 是否正在执行registedCallbacks中的事件，为true时表示正在派发信息
        /// </summary>
        public bool isEnuming=false;
        /// <summary>
        /// 派发过程中有收到新的需要派发的信息，下次派发前，将被添加到lEvents中
        /// </summary>
        public List<EventBase> lPendingEvents = new List<EventBase>();//待处理事件
        /// <summary>
        /// 需要被派发的信息
        /// </summary>
        public List<EventBase> lEvents = new List<EventBase>();//要处理事件
        /// <summary>
        /// 单例
        /// </summary>
        static Delegate_Observe deob = new Delegate_Observe();
        public static Delegate_Observe Deob
        {
            get
            {
                return deob;
            }
        }
        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="eventName">键值</param>
        /// <param name="eh">事件列表</param>
        public void registedEvent(string eventName,EventHandler eh)
        {
            lock(this)
            {
                if (!registedCallbacks.ContainsKey(eventName))
                {
                    registedCallbacks.Add(eventName, new List<EventHandler>());
                }
                else
                {
                    Console.WriteLine("已注册该事件"+eventName);
                }
                if (isEnuming)
                {
                    if (!registedCallbacksPending.ContainsKey(eventName))
                    {
                        registedCallbacksPending.Add(eventName, new List<EventHandler>());
                    }
                    registedCallbacksPending[eventName].Add(eh);
                    return;
                }
                registedCallbacks[eventName].Add(eh);
            }
           
        }
        /// <summary>
        /// 添加需要派发的信息
        /// </summary>
        /// <typeparam name="T">信息的类型</typeparam>
        /// <param name="value">信息</param>
        public void Dispather<T>(T value) 
            where T:EventBase
        {
            lock(this)
            {
                if (!registedCallbacks.ContainsKey(value.eventName))
                {
                    Console.WriteLine("未注册该事件");
                    return;
                }

                if (isEnuming)
                {
                    lPendingEvents.Add(value);
                    Console.WriteLine("添加为要事件");
                    return;
                }

                foreach (EventBase eb in lPendingEvents)
                {
                    lEvents.Add(eb);
                }
                lPendingEvents.Clear();
                lEvents.Add(value);
            }
           
        }
        /// <summary>
        /// 没帧执行，派发信息
        /// </summary>
        public void onTick()
        {
            lock(this)
            {
                if (lEvents.Count == 0)//没有需要处理的事件，查看是否有将要注册的事件,为派发做准备
                {
                    foreach (string str in registedCallbacksPending.Keys)
                    {
                        registedCallbacks.Add(str, registedCallbacksPending[str]);
                    }
                    registedCallbacksPending.Clear();
                    foreach (EventBase eb in lPendingEvents)
                    {
                        lEvents.Add(eb);
                    }
                    lPendingEvents.Clear();
                    return;
                }
                isEnuming = true;
                foreach (EventBase eb in lEvents)
                {
                    for (int i = 0; i < registedCallbacks[eb.eventName].Count; i++)
                    {
                        if (registedCallbacks[eb.eventName][i] != null)
                        {
                            registedCallbacks[eb.eventName][i](eb);
                        }
                    }
                }
                lEvents.Clear();
            }
            isEnuming = false;
        }
    }
    /// <summary>
    /// 信息基类
    /// </summary>
    public class EventBase
    {
        public string eventName;
        public object value;
        public EventBase(string eventName,object value)
        {
            this.eventName = eventName;
            this.value = value;
        }
    }
    /// <summary>
    /// 信息子类
    /// </summary>
    public class EventWithValue:EventBase
    {
        public object value1;
        public EventWithValue(string eventName,object value1)
            :base(eventName,value1)
        {
            this.eventName = eventName;
            this.value1 = value1;
        }
    }

    public class Test
    {
        /// <summary>
        /// 键值，每个键值对应一个事件列表
        /// </summary>
        static string[] name = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "K" };
        /// <summary>
        /// 注册线程执行方法，每隔一段事件就会注册新的事件，
        /// 这些事件的目的是处理得到的信息
        /// </summary>
        static void zhuce()
        {
            int index = 0;
            while(true)
            {
                if(index>=name.Length)
                {
                    break;
                }
                Delegate_Observe.Deob.registedEvent(name[index], getSome);
                Console.WriteLine("添加注册事件"+ name[index]);
                try
                {
                    Thread.Sleep(1000);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Data);
                }
                index++;
            }
        }
        /// <summary>
        /// 事件所对应的方法
        /// </summary>
        /// <param name="eb"></param>
        static void getSome(EventBase eb)
        {
            EventWithValue ev = eb as EventWithValue;
            int i = (int)ev.value1;
            Console.WriteLine(ev.eventName + " "+i);
        }
        /// <summary>
        ///添加需要派发的信息的线程执行方法
        /// </summary>
        static void yunxing()
        {
            int index = 0;
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Data);
                }
                if (index >= name.Length)
                {
                    break;
                }
                EventWithValue ev = new EventWithValue(name[index], index);
                Delegate_Observe.Deob.Dispather<EventWithValue>(ev);
               
                index++;
            }
        }
        /// <summary>
        /// 派发信息的执行线程
        /// </summary>
        static void diaoyong()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(500);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Data);
                }
                Delegate_Observe.Deob.onTick();
            }
        }

        //static void Main()
        //{
        //    Thread s1 = new Thread(new ThreadStart(zhuce));
        //    Thread s2 = new Thread(new ThreadStart(yunxing));
        //    Thread s3 = new Thread(new ThreadStart(diaoyong));
        //    s1.Start();
        //    s2.Start();
        //    s3.Start();
        //}
    }


}
