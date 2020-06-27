using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa
{
    class OneList:IEnumerable
    {
        OneListNode first=null;
        public int count = 0;

      


        public void addFirst(int x)
        {
            if(first==null)
            {
                first = new OneListNode(x);
                return;
            }
            OneListNode node = new OneListNode(x);
            node.next = first;
            first = node;
            count++;
        }


        public void addLast(int x)
        {
            if(first==null)
            {
                first = new OneListNode(x);
                return;
            }
            OneListNode temp = first;
            OneListNode father = temp;
            while(temp!=null)
            {
                father = temp;
                temp = temp.next;
            }
            father.next = new OneListNode(x);
            count++;
        }

        public void addIndex(int index,int x)
        {
            if(index>=count)
            {
                return;
            }
            OneListNode temp = first;
            while(index>0)
            {
                temp = temp.next;
                index--;
            }
            OneListNode node = new OneListNode(x);
            node.next = temp.next;
            temp.next = node;
            count++;
        }

        public void removeFirst()
        {
            if(first==null)
            {
                return;
            }
            first = first.next;
            count--;
        }


        public void removeLast()
        {
            if(first==null)
            {
                return;
            }
            OneListNode temp= first;
            OneListNode father = temp;
            while(temp!=null)
            {
                father = temp;
                temp = temp.next;
            }
            father = null;
            count--;
        }

        public int getIndex(int index)
        {
            if(index>=count)
            {
                return 0;
            }
            OneListNode node = first;
            while(index>0)
            {
                node = node.next;
                index--;
            }
            return node.val;
        }

        public int getFirst()
        {
            if(first==null)
            {
                return 0;
            }
            return first.val;
        }
        public int getLast()
        {
            if(first==null)
            {
                return 0;
            }
            OneListNode temp = first;
            OneListNode father = temp;
            while(temp!=null)
            {
                father = temp;
                temp = temp.next;
            }
            return father.val;
        }

        public OneListNode invert()
        {
            if(first==null)
            {
                return null;
            }
            OneListNode node = first;
            OneListNode pre = null;
            OneListNode next = null;
            while(node!=null)
            {
                next = node.next;
                node.next = pre;
                pre = node;
                node = next;
            }

            return pre;
        }

        //static void Main()
        //{
        //    int[] array = { 1, 2, 3,55, 4, 5, 6 };
        //    OneList list = new OneList();
        //    list.addFirst(12);
        //    foreach(var v in array)
        //    {
        //        list.addLast(v);
        //    }
        //    list.addIndex(3, 122);
        //    foreach (var v in list)
        //    {
        //        Console.Write(v+",");
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine(list.getIndex(3));

        //    OneListNode node = list.invert();
        //    while(node!=null)
        //    {
        //        Console.Write(node.val + ",");
        //        node = node.next;
        //    }

        //    Console.WriteLine();
        //    foreach (var v in list)
        //    {
        //        Console.Write(v + ",");
        //    }
        //    Console.WriteLine();
        //    List<int> ls = new List<int>();
        //    foreach (var v in array)
        //    {
        //        ls.Add(v);
        //    }
        //    list.delete(ls);
        //}

        public List<int> delete(List<int> ls)
        {
            if(ls.Count==0||ls==null)
            {
                return new List<int>() ;
            } 

            int start = 0;
            int end = ls.Count - 1;
            while(start!=end)
            {
                while(start!=end&&ls[start]%2==1)
                {
                    start++;
                }
                while(end!=start&&ls[end]%2==0)
                {
                    end--;
                    //break;
                }
                if(start!=end)
                {
                    int temp = ls[start];
                    ls[start] = ls[end];
                    ls[end] = temp;
                }
            }
            for(int i=ls.Count-1;i>=start;i--)
            {
                ls.RemoveAt(i);
            }

            foreach(var v in ls)
            {
                Console.Write(v + ",");
            }
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            OneListNode node = first;
            while(node!=null)
            {
                yield return node.val;
                node = node.next;
            }
        }
    }

    class OneListNode
    {
        public int val;
        public OneListNode next;
        public OneListNode(int val)
        {
            this.val = val;
        }
    }
   
}
