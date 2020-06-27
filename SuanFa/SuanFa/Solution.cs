using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }

        //static void Main()
        //{
        //    LinkedList<int> ll = new LinkedList<int>();

        //    TreeNode a = new TreeNode(1);
        //    TreeNode b = new TreeNode(2);
        //    TreeNode c = new TreeNode(3);
        //    TreeNode d = new TreeNode(4);
        //    TreeNode e = new TreeNode(5);

        //    a.left = b;
        //    a.right = c;
        //    b.left = d;
        //    c.right = e;

        //    TreeNode f = new TreeNode(1);
        //    TreeNode g = new TreeNode(2);
        //    TreeNode h = new TreeNode(3);
        //    f.left = g;
        //    f.right = h;
        //    Solution s = new Solution();

        //    int[] array =
        //    {
        //        4,8,6,12,16,14,10
        //    };
        //    Console.WriteLine(s.VerifySquenceOfBST(array));
        //    List<int> l = new List<int>();
        //    new List<int>(l);

        //    TreeNode tn = new TreeNode(2);
        //    //Activator.CreateInstance()
        //    One o;
        //    o.i = 12;
        //    o.j = 12;
        //    o.s = "S";
        //    One o1 = o;
        //    o1.i = 100;
        //    o1.s = "SSS";
        //    Console.WriteLine(o.i+"  "+o.s);
        //}
        static int g = 0;
        void B()
        {
            g = 33;
        }
        int i = 0;
        static void A()
        {
           
        }
       
    }
    struct One
    {
        public int i;
        public int j;
        public string s;
        //public One(int i,int j)
        //{
        //    this.i = i;
        //    this.j = j;
        //}
    }
    class Solution
    {
        public bool VerifySquenceOfBST(int[] sequence)
        {
            // write code here
            if (sequence == null || sequence.Length == 0)
            {
                return false;
            }
            return isLastOrder(sequence, 0, sequence.Length-1);
        }
        public bool isLastOrder(int[] sequence, int start, int end)
        {
            if (start == end)
            {
                return true;
            }
            int mid = start;//寻找左右子树分界点
            while (mid <=end && sequence[mid] < sequence[end])
            {
                mid++;
            }
            int temp = mid;

            while (mid <= end && sequence[mid] > sequence[end])
            {
                mid++;
            }

            if (mid < end)
            {
                return false;
            }
            else
            {
                return isLastOrder(sequence, start, temp - 1) && isLastOrder(sequence, temp, end - 1);
            }
        }
    }
}
