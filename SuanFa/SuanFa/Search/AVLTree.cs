using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Search
{
    class AVLTreeNode
    {
        public AVLTreeNode left;//左子树
        public AVLTreeNode right;//右子树
        public int data;//数据
        public int height;//高度

        public AVLTreeNode(int data)
        {
            this.data = data;
            this.height = 0;
            this.left = null;
            this.right = null;
        }
    }

    /// <summary>
    /// 平衡二叉树
    /// 最坏情况也是lgn
    /// </summary>
    class AVLTree
    {
        public AVLTreeNode root;
        public AVLTree()
        {

        }
        //static void Main()
        //{
        //    AVLTree t1 = new AVLTree();
        //    int[] array = {2, 4, 3 };
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        t1.root = t1.insert(t1.root, array[i]);
        //    }
        //    t1.printTree(t1.root);
        //    Console.WriteLine();
        //    t1.inOrder2(t1.root);

        //    Console.WriteLine();

        //    //root = t1.delete(root, 2343);
        //    //t1.inOrder2(root);
        //    //Console.WriteLine();
        //    //Console.WriteLine();
        //    //t1.printTree(root);
        //}
        /// <summary>
        /// 获取节点高度
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int getHeight(AVLTreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.height;
        }
        /// <summary>
        /// 获取左右子树最大高度
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int getMaxHeight(AVLTreeNode left, AVLTreeNode right)
        {
            if (left != null && right != null)
            {
                return (getHeight(left) >= getHeight(right)) ? getHeight(left) : getHeight(right);
            }
            else if (left == null && right != null)
            {
                return getHeight(right);
            }
            else if (right == null && left != null)
            {
                return getHeight(left);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 向右旋转一次
        /// </summary>
        public AVLTreeNode turnRight(AVLTreeNode node)
        {
            AVLTreeNode temp = node.left;
            node.left = temp.right;
            temp.right = node;

            //获取新的高度
            node.height = getMaxHeight(node.left, node.right) + 1;
            temp.height = getMaxHeight(temp.left, temp.right) + 1;
            return temp;
        }
        /// <summary>
        /// 左旋一次
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public AVLTreeNode turnLeft(AVLTreeNode node)
        {
            AVLTreeNode temp = node.right;
            node.right = temp.left;
            temp.left = node;

            //获取新的高度
            node.height = getMaxHeight(node.left, node.right) + 1;
            temp.height = getMaxHeight(temp.left, temp.right) + 1;
            return temp;
        }
        /// <summary>
        /// 先右旋一次在左旋一次
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public AVLTreeNode turnRightLeft(AVLTreeNode node)
        {
            node.right = turnRight(node.right);
            return turnLeft(node);
        }
        /// <summary>
        /// 左旋一次，再右旋一次
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public AVLTreeNode turnLeftRight(AVLTreeNode node)
        {
            node.left = turnLeft(node.left);
            return turnRight(node);
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="root"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public AVLTreeNode insert(AVLTreeNode root,int data)
        {
            if(root==null)
            {
                root = new AVLTreeNode(data);
            }

            if(data<root.data)
            {
                
                root.left = insert(root.left, data);
                if( getHeight (root.left) - getHeight(root.right) ==2 )
                {
                    if(data<root.left.data)
                    {
                        //Console.WriteLine("left=" + data);
                        root=turnRight(root);
                    }
                    else
                    {
                        root=turnLeftRight(root);
                    }
                }
                
            }
            else if(data>root.data)
            {
                root.right = insert(root.right, data);
                if(getHeight(root.right)-getHeight(root.left)==2)
                {
                    if(data>root.right.data)
                    {
                        root=turnLeft(root);
                    }
                    else
                    {
                        root=turnRightLeft(root);
                    }
                }
            }
            root.height = getMaxHeight(root.left, root.right) + 1;
            return root;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="root"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public AVLTreeNode delete(AVLTreeNode root, int data)
        {
            if(root==null)
            {
                return null;
            }

            if (data < root.data)
            {

                root.left = delete(root.left, data);
                if (getHeight(root.left) - getHeight(root.right) == 2)
                {
                    if (data < root.left.data)
                    {
                        Console.WriteLine("left=" + data);
                        root = turnRight(root);
                    }
                    else
                    {
                        root = turnLeftRight(root);
                    }
                }

            }
            else if (data > root.data)
            {
                root.right = delete(root.right, data);
                if (getHeight(root.right) - getHeight(root.left) == 2)
                {
                    if (data > root.right.data)
                    {
                        root = turnLeft(root);
                    }
                    else
                    {
                        root = turnRightLeft(root);
                    }
                }
            }
            else if(data==root.data)//等于
            {
                if(root.left!=null&&root.right!=null)
                {
                    //寻找后继者，为右子树中最小的点
                    root.data = getSon(root.right).data;
                    //删除那个后继者
                    root.right=delete(root.right, root.data);
           
                }
                else
                {
                    if(root.left!=null)
                    {
                        root = root.left;
                    }
                    else if(root.right!=null)
                    {
                        root = root.right;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            //更新高度
            root.height = getMaxHeight(root.left, root.right);
            return root;
        }
        /// <summary>
        /// 寻找其右子树中最小节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public AVLTreeNode getSon(AVLTreeNode node)
        {
            AVLTreeNode parent = node;
            AVLTreeNode current = node;
            AVLTreeNode son = current.left;
            while(son!=null)
            {
                parent = current;
                current = son;
                son = son.left;
            }
            return current;
        }


        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="root">跟节点</param>
        public void printTree(AVLTreeNode root)
        {
            if (root == null)
            {
                return;
            }
            Queue<AVLTreeNode> q = new Queue<AVLTreeNode>();
            AVLTreeNode t = root;
            q.Enqueue(t);
            while (q.Count > 0)
            {
                t = q.Dequeue();
                Console.WriteLine(t.data + " " );
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
        public void inOrder2(AVLTreeNode root)
        {
            Stack<AVLTreeNode> s = new Stack<AVLTreeNode>();
            AVLTreeNode t = root;
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
                    Console.Write(t.data + " ");
                    t = t.right;
                }
            }
        }

    }


}
