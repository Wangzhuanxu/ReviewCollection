using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa
{
    /// <summary>
    /// 二叉树遍历
    /// </summary>
    //树的遍历
    class TraverseTree
    {
        //static void Main()
        //{
        //    Tree A = new Tree("A");
        //    Tree B = new Tree("B");
        //    Tree C = new Tree("C");
        //    Tree D = new Tree("D");
        //    Tree E = new Tree("E");
        //    Tree F = new Tree("F");
        //    Tree G = new Tree("G");
        //    Tree H = new Tree("H");
        //    Tree I = new Tree("I");

        //    A.left = B;
        //    A.right = C;

        //    B.left = D;
        //    B.right = F;

        //    F.left = E;

        //    C.left = G;
        //    C.right = I;

        //    G.right = H;


        //    TraverseTree tt = new TraverseTree();
        //    Console.WriteLine("先序遍历：");
        //    tt.preOrder1(A);
        //    Console.WriteLine();
        //    tt.preOrder2(A);
        //    Console.WriteLine();

        //    Console.WriteLine("中序遍历：");
        //    tt.inOrder1(A);
        //    Console.WriteLine();
        //    tt.inOrder2(A);
        //    Console.WriteLine();

        //    Console.WriteLine("后序遍历：");
        //    tt.posOrder1(A);
        //    Console.WriteLine();
        //    tt.posOrder2(A);
        //    Console.WriteLine();

        //    Console.WriteLine("层序遍历：");
        //    tt.levelOrder(A);
        //}
        /// <summary>
        /// 先序遍历，递归
        /// </summary>
        /// <param name="root">根节点</param>
        public void preOrder1(Tree root)
        {
            if(root==null)
            {
                return;
            }
            Console.Write(root.node + " ");
            preOrder1(root.left);
            preOrder1(root.right);
        }
        /// <summary>
        /// 先序遍历，非递归
        /// </summary>
        /// <param name="root">根节点</param>
        public void preOrder2(Tree root)
        {
            Stack<Tree> s = new Stack<Tree>();
            Tree t = root;
            while(t!=null||s.Count>0)
            {
                if(t!=null)
                {
                    Console.Write(t.node + " ");
                    s.Push(t);
                    t = t.left;
                }
                else
                {
                    t = s.Pop();
                    t = t.right;
                }
            }
        }

        /// <summary>
        /// 中序遍历，递归
        /// </summary>
        /// <param name="root">根节点</param>
        public void inOrder1(Tree root)
        {
            if (root == null)
            {
                return;
            }
            inOrder1(root.left);
            Console.Write(root.node + " ");
            inOrder1(root.right);
        }
        /// <summary>
        /// 中序遍历，非递归
        /// </summary>
        /// <param name="root">根节点</param>
        public void inOrder2(Tree root)
        {
            Stack<Tree> s = new Stack<Tree>();
            Tree t = root;
            while (t != null || s.Count > 0)
            {
                if (t != null)
                {
                    s.Push(t);
                    t = t.left;
                }
                else
                {
                    t = s.Pop();
                    Console.Write(t.node + " ");
                    t = t.right;
                }
            }
        }

        /// <summary>
        /// 后序遍历，递归
        /// </summary>
        /// <param name="root">根节点</param>
        public void posOrder1(Tree root)
        {
            if (root == null)
            {
                return;
            }
            posOrder1(root.left);
            posOrder1(root.right);
            Console.Write(root.node + " ");
        }
        /// <summary>
        /// 后序遍历，非递归
        /// </summary>
        /// <param name="root">根节点</param>
        public void posOrder2(Tree root)
        {
            Stack<Tree> s = new Stack<Tree>();
            Tree t = root;
            Tree pre = null;
            while (t != null || s.Count > 0)
            {
                while(t!=null)
                {
                    s.Push(t);
                    t = t.left;
                }

                t = s.Peek();
                if(t.right!=null&&t.right!=pre)
                {
                    t = t.right;
                }
                else
                {
                    s.Pop();
                    Console.Write(t.node + " ");
                    pre = t;
                    t = null;
                }

            }
        }

        /// <summary>
        /// 层序遍历
        /// </summary>
        /// <param name="root">根节点</param>
        public void levelOrder(Tree root)
        {
            if (root == null)
            {
                return;
            }
            Queue<Tree> q = new Queue<Tree>();
            Tree t = root;
            q.Enqueue(t);
            while (q.Count > 0)
            {
                t = q.Dequeue();
                Console.Write(t.node + " ");
                if (t.left != null)
                {
                    q.Enqueue(t.left);
                }
                if (t.right != null)
                {
                    q.Enqueue(t.right);
                }
            }

        }


    }



    class Tree
    {
        public string node;
        public Tree left;
        public Tree right;
        public Tree(string node)
        {
            this.node = node;
        }
    }
}
