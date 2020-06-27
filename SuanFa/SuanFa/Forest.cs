using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa
{
    /// <summary>
    /// 森林遍历
    /// </summary>
    class Forest
    {
       //static void Main()
       // {
       //     Tree2 A = new Tree2("A");
       //     Tree2 B = new Tree2("B");
       //     Tree2 C = new Tree2("C");
       //     Tree2 D = new Tree2("D");
       //     Tree2 E = new Tree2("E");
       //     Tree2 F = new Tree2("F");
       //     Tree2 G = new Tree2("G");
       //     Tree2 H = new Tree2("H");
       //     Tree2 I = new Tree2("I");
       //     A.t.Add(B);
       //     A.t.Add(C);
       //     A.t.Add(D);
       //     A.t.Add(E);
       //     A.t.Add(F);
       //     A.t.Add(G);
       //     B.t.Add(H);
       //     B.t.Add(I);
       //     Forest fr = new Forest();
       //     fr.forestPre2(A);
       //     fr.forestPre(A);
       //     fr.forestPost(A);
       //     fr.forestPost2(A);
       // }
        /// <summary>
        /// 树的森林的先序遍历，递归
        /// </summary>
        /// <param name="t"></param>
        public void forestPre2(Tree2 t)
        {
            if (t == null)
                return;
            Console.WriteLine(t.node);
            foreach(Tree2 tt in t.t)
            {
                forestPre2(tt);
            }
        }
        /// <summary>
        /// 树的森林的先序遍历，非递归
        /// </summary>
        /// <param name="root"></param>
        public void forestPre(Tree2 root)
        {
            Tree2 tt = root;//根节点
            Stack<Tree2> s = new Stack<Tree2>();
            int[] whichChild = new int[200];//访问到该节点的第几个子节点
            int index = 0;//栈中元素索引
            while (tt != null || s.Count > 0)
            {
                if (tt != null)
                {
                    Console.Write(tt.node);//该节点输出
                    s.Push(tt);//该节点入栈
                    whichChild[index] = 0;//需要遍历该节点的子节点索引
                    if (tt.t.Count >0)//有子节点
                    {
                        tt = tt.t[whichChild[index]];
                        whichChild[index]++;//需要访问该节点的下一个子节点
                    }
                    else
                    {
                        tt = null;
                    }
                    index++;//栈中下一个元素索引
                }
                else if(whichChild[index-1]<s.Peek().t.Count)//找该节点的兄弟节点
                {
                    tt = s.Peek().t[whichChild[index-1]];//获取兄弟节点
                    whichChild[index-1]++;//该节点的下一个兄弟节点的索引
                }
                else
                {
                    s.Pop();//删除该节点
                    index--;
                    tt = null;
                }
            }
        }
        /// <summary>
        /// 森林的后序遍历，递归
        /// </summary>
        /// <param name="root"></param>
        public void forestPost(Tree2 root)
        {
            if (root == null)
                return;
            foreach(Tree2 t in root.t)
            {
                forestPost(t);
            }
            Console.WriteLine(root.node);
        }
        /// <summary>
        /// 森林的后序遍历，非递归，解释同上
        /// </summary>
        /// <param name="root"></param>
        public void forestPost2(Tree2 root)
        {
            Tree2 tt = root;
            Stack<Tree2> s = new Stack<Tree2>();
            int[] whichChild = new int[200];
            int index = 0;
            while(tt!=null||s.Count>0)
            {
                if(tt!=null)
                {
                    s.Push(tt);
                    whichChild[index]=0;
                    if(tt.t.Count>0)
                    {
                        tt = tt.t[whichChild[index]];
                        whichChild[index]++;
                    }
                    else
                    {
                        tt = null;
                    }
                    index++;
                }
                else if(whichChild[index-1]<s.Peek().t.Count)
                {
                    tt = s.Peek().t[whichChild[index - 1]];
                    whichChild[index-1]++;
                }
                else
                {
                    tt = s.Pop();
                    Console.Write(tt.node);
                    index--;
                    tt = null;
                }
            }
        }
    }
    class Tree2
    {
        public string node;
        public List<Tree2> t = new List<Tree2>();
        public Tree2(string node)
        {
            this.node = node;
        }
    }
}
