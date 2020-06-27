using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Sequence
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
    }
    class Class1
    {
        //static void Main()
        //{
        //    int[] pre = { 1,3,5};
        //    int[] pre2 = { 1, 3, 5 };
        //    Class1 c = new Class1();
        //    //treenode t1 = new treenode(1);
        //    //treenode t2 = new treenode(2);
        //    //treenode t3 = new treenode(3);
        //    //treenode t4 = t1;

        //    ListNode node = new ListNode(1);
        //    ListNode head = node;
        //    for (int i = 1; i < pre.Length; i++)
        //    {
        //        ListNode ln = new ListNode(pre[i]);
        //        node.next = ln;
        //        node = ln;
        //    }

        //    ListNode node1 = new ListNode(1);
        //    ListNode head1 = node1;
        //    for (int i = 1; i < pre2.Length; i++)
        //    {
        //        ListNode ln = new ListNode(pre2[i]);
        //        node1.next = ln;
        //        node1 = ln;
        //    }

        //    //while (head1 != null)
        //    //{
        //    //    Console.WriteLine(head1.val);
        //    //    head1 = head1.next;
        //    //}
        //    node = c.ReverseList(head,head1);
        //    //while(node!=null)
        //    //{
        //    //    Console.WriteLine(node.val);
        //    //    node = node.next;
        //    //}
            
        //}
       

        public ListNode ReverseList(ListNode pHead1,ListNode pHead2)
        {
            if(pHead2==null&& pHead1==null)
            {
                return null;
            }
            else if(pHead2 != null && pHead1 == null)
            {
                return pHead2;
            }
            else if(pHead2 == null && pHead1!= null)
            {
                return pHead1;
            }

            ListNode node=null, newNode;
            if(pHead2.val<=pHead1.val)
            {
                newNode = pHead2;
            }
            else
            {
                newNode = pHead1;
            }
            while(pHead1!=null&&pHead2!=null)
            {
                if(pHead1.val>=pHead2.val)
                {
                    if(node==null)
                    {
                        node = pHead2;
                    }
                    else
                    {
                        node.next = pHead2;
                        node = node.next;
                    }
                    pHead2 = pHead2.next;
                }
                else
                {
                    if (node == null)
                    {
                        node = pHead1;
                    }
                    else
                    {
                        node.next = pHead1;
                        node = node.next;
                    }
                    pHead1 = pHead1.next;
                }
            }

            while(pHead1!=null)
            {
                node.next = pHead1;
                node = node.next;
                pHead1 = pHead1.next;
            }
            while (pHead2 != null)
            {
                node.next = pHead2;
                node = node.next;
                pHead2 = pHead2.next;
            }

            while(newNode!=null)
            {
                Console.WriteLine(newNode.val);
                newNode = newNode.next;
            }
            return newNode;
        }

        public int NumberOf1(int n)
        {
            int i = 1;
            int num = 0;
            int index = 0;
            while (i != 0)
            {
                if ((i & n) == i)
                {
                    num++;
                }
                i *= 2;
                Console.WriteLine("i=" + i+"   "+index++);
            }
            return num;
        }

        public  TreeNode reConstructBinaryTree(int[] pre, int[] tin)
        {
            // write code here
            TreeNode tn=new TreeNode(0);
            getTree(pre, tin, tn);
            Queue<TreeNode> q = new Queue<TreeNode>();
            if(tn==null)
            {
                Console.Write(" sfsdf  ");
            }
            q.Enqueue(tn);
            while(q.Count>0)
            {
                TreeNode t = q.Dequeue();
                Console.Write(t.val + " ");
                if (t.left != null)
                {
                    q.Enqueue(t.left);
                }
                if (t.right != null)
                {
                    q.Enqueue(t.right);
                }
            }
            return tn;
        }

        public  void getTree(int[] pre, int[] tin, TreeNode node)
        {
           
            node.val=pre[0];
           /// Console.Write(node.val);
            int index = Array.IndexOf(tin, pre[0]);
            if (index > 0)//有左子树，遍历左子树
            {
                int[] num1 = new int[index];
                Array.Copy(pre, 1, num1, 0, index);
                int[] num2 = new int[index];
                Array.Copy(tin, 0, num2, 0, index);
                node.left = new TreeNode(0);
                getTree(num1, num2, node.left);
            }
            if (index < tin.Length - 1)//有右子树，遍历右子树
            {
                int[] num1 = new int[pre.Length - 1 - index];
                Array.Copy(pre, index + 1, num1, 0, pre.Length - 1 - index);
                int[] num2 = new int[pre.Length - 1 - index];
                Array.Copy(tin, index + 1, num2, 0, pre.Length - 1 - index);
                node.right = new TreeNode(0);
                getTree(num1, num2, node.right);
            }
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }
    }
}
