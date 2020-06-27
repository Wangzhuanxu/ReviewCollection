using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Search
{
    class RedBlackTreeNode
    {
        public const bool RED = false;
        public const bool BLACK = true;
        public RedBlackTreeNode left;//左子树
        public RedBlackTreeNode right;//右子树
        public RedBlackTreeNode parent;//父节点
        public bool isRed;//红节点
        public int data;//键值
        public int trueData;//数据
        public RedBlackTreeNode(int data, int trueData)
        {
            this.data = data;
            this.isRed = RED;
            this.trueData = trueData;
            this.left = this.parent = this.right = null;
        }
    }

    /// <summary>
    /// 红黑树
    /// 复杂度永为lgn
    /// </summary>
    class RedBlackTree
    {
        public RedBlackTree()
        {

        }

        public RedBlackTreeNode root;//本科树的跟节点
        
        /// <summary>
        /// 左旋
        /// </summary>
        /// <param name="node">左旋节点</param>
        /// <param name="root">//跟节点</param>
        public RedBlackTreeNode turnLeft(RedBlackTreeNode node, RedBlackTreeNode root)
        {
            RedBlackTreeNode temp = node.right;
            node.right = temp.left;

            if(temp.left!=null)//将node子节点的左子的父节点设置为node
            {
                temp.left.parent = node.right;
            }

            temp.parent = node.parent;

            if(temp.parent==null)//是否是跟节点
            {
                root = temp;
            }
            else if(node==node.parent.left)//node是其父节点的左节点还是右节点
            {
                node.parent.left = temp;
            }
            else
            {
                node.parent.right = temp;
            }
            node.parent = temp;
            temp.left = node;
            return root;
        }
        /// <summary>
        /// 右旋
        /// </summary>
        /// <param name="node">右旋节点</param>
        /// <param name="root">跟节点</param>
        public RedBlackTreeNode turnRight(RedBlackTreeNode node, RedBlackTreeNode root)
        {
            RedBlackTreeNode temp = node.left;
            node.left = temp.right;

            
            if(temp.right!=null)
            {
                temp.right.parent = node;
            }
            temp.parent = node.parent;

            if (temp.parent == null)//temp成为跟节点
            {
                
                root = temp;
            }
            else if(node==node.parent.left)
            {
                node.parent.left = temp;
            }
            else
            {
                node.parent.right = temp;
            }
            Console.WriteLine("wugen="+root.data);
            node.parent = temp;

            temp.right = node;
            return root;
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="data">插入数据</param>
        /// <param name="root">跟节点</param>
        public RedBlackTreeNode insert(int data, RedBlackTreeNode root,int trueData)
        {

            RedBlackTreeNode parent = root;//插入节点的父节点
            RedBlackTreeNode node = root;//临时遍历变量
            while(node!=null)//寻找插入位置
            {
                parent = node;
                if(data>node.data)
                {
                    node = node.right;
                }
                else
                {
                    node = node.left;
                }
            }
            node = new RedBlackTreeNode(data,trueData);//创建节点
            node.parent = parent;//设置创建节点的父节点
            if(parent!=null&& data>parent.data)//查看node为父节点的左子还是右子
            {
                parent.right = node;
            }
            else if(parent != null)
            {
                parent.left = node;
            }
            if(root==null)//未插入节点
            {
                root = fix(node, node);
            }
            else
            {
                root = fix(node, root);
            }
            return root;
        }
        /// <summary>
        /// 修正红黑树
        /// </summary>
        /// <param name="node">插入的节点</param>
        /// <param name="root">跟节点</param>
        public RedBlackTreeNode fix(RedBlackTreeNode node, RedBlackTreeNode root)
        {
            RedBlackTreeNode parent, gparent;//当前节点的父节点和祖父节点
            while((parent=getParent(node))!=null&&parent.isRed== RedBlackTreeNode.RED)//父节点存在，并且父节点为红色
            {
                gparent = getParent(parent);//祖父节点一定存在，因为跟节点必须是黑色节点
                if(gparent==null)
                {
                    break;
                }
                else if(parent==gparent.left)//父节点是祖父节点的左子
                {
                    if(gparent.right!=null&&gparent.right.isRed==RedBlackTreeNode.RED)//叔叔节点存在，且为红色
                    {
                        gparent.right.isRed = gparent.left.isRed = RedBlackTreeNode.BLACK;//父节点和叔叔节点设置为黑色
                        gparent.isRed = RedBlackTreeNode.RED;//祖父为红色
                        node = gparent;//从其祖父节点计算
                        continue;
                    }

                    if(node==parent.right&&parent.isRed== RedBlackTreeNode.RED)//当前节点为父节点的右子,并且父节点为红色
                    {
                        root=turnLeft(parent, root);//右转后，以前的父节点指向现在的节点，
                        RedBlackTreeNode temp = node; //需要重新获得以前的父节点地址，并将以前的父节点的父节点换为当前节点。
                        node = parent;
                        parent = temp;
                       
                    }
                    Console.WriteLine(parent.data+"   "+gparent.data+"\n");
                    if(parent.isRed== RedBlackTreeNode.RED)
                    {
                        parent.isRed = RedBlackTreeNode.BLACK;
                        gparent.isRed = RedBlackTreeNode.RED;
                        root=turnRight(gparent, root);
                    }
                }
                else//父节点是祖父节点的右子
                {
                    if (gparent.left != null && gparent.left.isRed == RedBlackTreeNode.RED)//叔叔节点存在，且为红色
                    {
                        gparent.right.isRed = gparent.left.isRed = RedBlackTreeNode.BLACK;//父节点和叔叔节点设置为黑色
                        gparent.isRed = RedBlackTreeNode.RED;//祖父为红色
                        node = gparent;//从其祖父节点计算
                        continue;
                    }

                    if (node == parent.left && parent.isRed == RedBlackTreeNode.RED)//当前节点为父节点的右子,并且父节点为空色
                    {
                        root=turnRight(parent, root);//右转后，以前的父节点指向现在的节点，
                        RedBlackTreeNode temp = node; //需要重新获得以前的父节点地址，并将以前的父节点的父节点换为当前节点。
                        node = parent;
                        parent = temp;
                    }

                    if(parent.isRed== RedBlackTreeNode.RED)//父节点为红色
                    {
                        parent.isRed = RedBlackTreeNode.BLACK;//设置父节点为黑色，祖父节点为红色
                        gparent.isRed = RedBlackTreeNode.RED;
                        root=turnLeft(gparent, root);
                    }
                   
                }
                
            }
            root.isRed = RedBlackTreeNode.BLACK;
            return root;//返回跟节点
        }
        /// <summary>
        /// 获取父节点
        /// </summary>
        /// <param name="node">子节点</param>
        /// <returns></returns>
        public RedBlackTreeNode getParent(RedBlackTreeNode node)//寻找父节点
        {
            return node.parent;
        }

        //static void Main()
        //{
        //    RedBlackTree rbt = new RedBlackTree();
        //    int[] array = { 11, 2, 14, 1, 7, 15, 5, 8, 4 };
        //    //RedBlackTree root = new RedBlackTree(11);
        //    //root.isRed = BLACK;//第一个节点为黑色

        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        rbt.root = rbt.insert(array[i], rbt.root, array[i]);
        //    }
        //    Console.WriteLine();
        //    rbt.printTree(rbt.root);//打印
        //}



        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="root">跟节点</param>
        public void printTree(RedBlackTreeNode root)
        {
            if (root == null)
            {
                return;
            }
            Queue<RedBlackTreeNode> q = new Queue<RedBlackTreeNode>();
            RedBlackTreeNode t = root;
            q.Enqueue(t);
            while (q.Count > 0)
            {
                t = q.Dequeue();
                Console.WriteLine(t.data + " "+(t.isRed== RedBlackTreeNode.RED ? "RED":"BLACK"));
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

        /// <summary>
        /// 中序遍历，非递归
        /// </summary>
        /// <param name="root">根节点</param>
        public void inOrder2(RedBlackTreeNode root)
        {
            Stack<RedBlackTreeNode> s = new Stack<RedBlackTreeNode>();
            RedBlackTreeNode t = root;
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
                    Console.Write(t.data + " "+t.isRed);
                    t = t.right;
                }
            }
        }

    }

}

