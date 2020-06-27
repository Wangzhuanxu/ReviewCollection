using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Search
{
    /// <summary>
    /// 拉链法----哈希表
    /// </summary>
    class HashCode
    {
        const int max = 10;//哈希表的长度
        HashList[] hl = new HashList[max];//哈希表
        //static void Main()
        //{
        //    HashCode hc = new HashCode();

        //    for (int i = 0; i < max; i++)
        //    {
        //        hc.hl[i] = new HashList();
        //    }

        //    int[] array = { 1, 4, 54, 64, 7, 78, 32 };

        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        hc.put(array[i], array[i]);
        //    }

        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        Console.WriteLine(hc.get(array[i]) + "   " + array[i]);

        //    }
        //    Console.WriteLine();
        //    hc.delete(64);

        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        Console.WriteLine(hc.get(array[i]) + "   " + array[i]);

        //    }

        //}
        public void put(int k,int v)
        {
            hl[getHashCode(k)].put(k,v);
        }
        public int get(int k)
        {
            return hl[getHashCode(k)].get(k);
        }
        public void delete(int k)
        {
            hl[getHashCode(k)].delete(k);
        }

        public int getHashCode(int key)
        {
            return key % 10;
        }

        //int array = {}
    }
    /// <summary>
    /// 哈希所用的链表
    /// </summary>
    class HashList
    {
        HashNode first;
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">值</param>
        public void put(int key,int value)
        {
            HashNode temp = first;
            bool hasKey = false;
            while(temp!=null)
            {
                if(temp.key==key)
                {
                    temp.value = value;
                    hasKey = true;
                    break;
                }
                else
                {
                    temp = temp.next;
                }
            }
            if(!hasKey)
            {
                HashNode node = new HashNode(key, value);
                node.next = first;
                first = node;
            }
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int get(int key)
        {
            HashNode temp = first;
            while(temp!=null)
            {
                if(temp.key==key)
                {
                    return temp.value;
                }
                temp = temp.next;
            }
            return -1;//没找到
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key">键值</param>
        public void delete(int key)
        {
            if(key==first.key)
            {
                first = first.next;
            }
            else
            {
                HashNode temp = first;
                HashNode father = first;
                while (temp.value != key)
                {
                    father = temp;
                    temp = temp.next;
                    if(temp==null)
                    {
                        Console.WriteLine("不包含该键值");
                        return;
                    }
                }
                father.next = temp.next;
                if(temp==null)
                {
                    Console.WriteLine("不包含该键值");
                }
            }
            
        }
    }

    class HashNode
    {
        HashList first;//头结点
        public int key;//键值
        public int value;//value
        public HashNode next;//指向下一个链表节点

        public HashNode(int key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }


}
