using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Search
{
    class BinarySearchTreeNode
    {
        public int data;//数据
        public BinarySearchTreeNode left;//左子
        public BinarySearchTreeNode right;//右子
        public int key;//键值索引
        public BinarySearchTreeNode(int data, int key)
        {
            this.key = key;
            this.data = data;
            this.left = null;
            this.right = null;
        }
    }

    /// <summary>
    /// 二叉查找树--需要建树---中序遍历就是排好的序列
    /// 它和二分查找一样，插入和查找的时间复杂度均为O(logn)，
    /// 但是在最坏的情况下仍然会有O(n)的时间复杂度。原因在于插入和删除元素的时候，树没有保持平衡
    /// </summary>
    class BinarySearchTree
    {

        public BinarySearchTreeNode root;
        public BinarySearchTree()
        {

        }

        //static void Main()
        //{
        //    BinarySearchTree bst = new BinarySearchTree();
        //    int[] nums = { 4, 0, 8, 1, 2, 5, 7, 6, 9 };
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        bst.root= bst.insert(nums[i], i, bst.root);
        //    }
        //    bst.printTree(bst.root);
        //    bst.inOrder2(bst.root);
        //    for (int i = nums.Length - 1; i >= 0; i--)
        //    {
        //        Console.WriteLine("i=" + bst.search(nums[i] - 5, bst.root) + "  num[i]=" + nums[i]);
        //    }

        //    Console.WriteLine("最大值=" + bst.getMax(bst.root));
        //    Console.WriteLine("最小值=" + bst.getMin(bst.root));
        //    Console.WriteLine("小于等于data=" + bst.getFloor(10, bst.root));
        //    Console.WriteLine("大于等于data=" + bst.getCell(8, bst.root));
        //    Console.WriteLine();
        //    Console.WriteLine("删除节点");
        //    bst.root = bst.delete(4, bst.root);

        //    bst.printTree(bst.root);
        //}

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="data">插入的数据</param>
        /// <param name="key">位置，也就是索引</param>
        /// <param name="root">根节点</param>
        public BinarySearchTreeNode insert(int data,int key, BinarySearchTreeNode root)
        {
            if(root==null)
            {
                Console.WriteLine("创建节点");
                root = new BinarySearchTreeNode(data, key);
               // return root;
            }

            else if(data>root.data)//找右子
            {
                root.right= insert(data, key, root.right);
            }
            else if(data<root.data)//左子
            {
                root.left= insert(data, key, root.left);
            }
            return root;
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="root">跟节点</param>
        /// <returns>位置</returns>
        public int  search(int data, BinarySearchTreeNode root)
        {
            if(root==null)
            {
                return -1;
            }
            if(data>root.data)//右子
            {
                return search(data, root.right);
            }
            else if(data<root.data)
            {
                return search(data, root.left);
            }
            else
            {
                return root.key;
            }

        }

        /// <summary>
        /// 找最大值
        /// </summary>
        /// <param name="root">跟节点</param>
        /// <returns>返回最大值索引</returns>
        public int getMax(BinarySearchTreeNode root)
        { 
            BinarySearchTreeNode temp = root;
            while(root.right!=null)
            {
                temp = root;
                root = root.right;
            }
            return temp.key;
        }

        /// <summary>
        /// 找最小值
        /// </summary>
        /// <param name="root">跟节点</param>
        /// <returns>返回最大值索引</returns>
        public int getMin(BinarySearchTreeNode root)
        {
            if (root == null)
            {
                return -1;
            }

            if (root.left == null)
            {
                return root.key;
            }
            else
            {
                return getMax(root.left);
            }
        }

        /// <summary>
        /// 小于等于data中最大的一个
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="root">跟节点</param>
        /// <returns>位置</returns>
        public int getFloor(int data, BinarySearchTreeNode root)
        {
            if(root==null)
            {
                return -1;
            }

            if(data>root.data)//大于，右边
            {
                if(root.right==null)
                {
                    return root.key;
                }
                else
                {
                    return getFloor(data, root.right);
                }
            }
            else if(data < root.data)//小于，左边
            {
                if (root.left == null)
                {
                    return root.key;
                }
                else
                {
                    return getFloor(data, root.left);
                }
            }
            else//左子或根
            {
                return root.key;
            }  
        }
        /// <summary>
        /// 大于等于data的最小一个
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="root">跟节点<param>
        /// <returns>位置</returns>
        public int getCell(int data, BinarySearchTreeNode root)
        {
            if (root == null)
            {
                return -1;
            }

            if (data > root.data)//大于，右边
            {
                if (root.right == null)
                {
                    return root.key;
                }
                else
                {
                    return getFloor(data, root.right);
                }
            }
            else if (data < root.data)//小于，左边
            {
                if (root.left == null)
                {
                    return root.key;
                }
                else
                {
                    return getFloor(data, root.left);
                }
            }
            else//左子或根
            {
                return root.key;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key">删除的值</param>
        /// <param name="root">跟节点</param>
        public BinarySearchTreeNode delete(int key, BinarySearchTreeNode root)
        {
            BinarySearchTreeNode parent = root;//删除节点的父节点
            BinarySearchTreeNode current = root;//删除的节点
            bool isLeftNode = false;//被删除节点是右节点还是左节点
            //寻找被删除节点
            while(current.data!=key)
            {
                parent = current;
                if(key<current.data)//左
                {
                    isLeftNode = true;
                    current = current.left;
                }
                else if(key > current.data)//右
                {
                    isLeftNode = false;
                    current = current.right;
                }
                if(current==null)
                {
                    return null;
                }
            }
            
            if(current==null)//该节点不存在，返回
            {
                Console.WriteLine("删除失败");
                return root;
            }

            //该节点左右子树全为空,直接将该节点设置为空
            if(current.left==null&&current.right==null)
            {
                if (current == root)
                {
                    root = null;
                }
                // 在左子树
                else if (isLeftNode == true)
                {
                    parent.left = null;
                }
                else
                {
                    parent.right = null;
                }
            }
            else if(current.left==null)//该节点左子树为空
            {
                Console.WriteLine("该节点左子树为空");
                if(current==root)
                {
                    root = root.right;
                }
                else if (isLeftNode)
                {
                    parent.left = current.right;
                }
                else
                {
                    parent.right = current.right;
                }
            }
            else if(current.right==null)//该节点右子树为空
            {
                Console.WriteLine("该节点右子树为空");
                if(current==root)
                {
                    root = root.left;
                }
                else if (isLeftNode)
                {
                    parent.left = current.left;
                }
                else
                {
                    parent.right = current.left;
                }
            }
            else //左右子树都不为空
            {
                //Console.WriteLine("左右子树都不为空");
                BinarySearchTreeNode node = getSon(current);
                if(current==root)
                {
                    root = node;
                    //Console.WriteLine("左右子树都不为空="+node.data);
                }
                else if (isLeftNode)
                {
                    parent.left = node;
                }
                else
                {
                    parent.right = node;
                }
                //printTree(node);
                //将要删除的节点的左子树赋值给后继者的左节点
                node.left = current.left;
                
            }

            return root;
        }
        /// <summary>
        /// 获取删除节点的后继者
        /// 删除节点的后继者是在其右节点树中最小的节点
        /// </summary>
        /// <param name="node">返回后继者</param>
        public BinarySearchTreeNode getSon(BinarySearchTreeNode node)
        {
            BinarySearchTreeNode parent = node;//删除节点父节点
            BinarySearchTreeNode current = node;//删除节点
            BinarySearchTreeNode son = node.right;//删除节点的右节点，最后会变为后继者
            Console.WriteLine(son.data);
            while (son!=null)
            {
                parent = current;
                current = son;
                son = son.left;
            }
            //Console.WriteLine(current.data);
            // 检查后继者(不可能有左节点树)是否有右节点树
            // 如果它有右节点树,则替换后继者位置,加到后继者父亲节点的左节点.
            if(current.right!=null&& current!= node.right)
            {
                parent.left = current.right;
                current.right = node.right;//将要删除的节点的右子树赋值给后继者的右节点
            }

            return current;


        }

        public void a(BinarySearchTree a)
        {
            a = null;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="root">跟节点</param>
        public void printTree(BinarySearchTreeNode root)
        {
            if (root == null)
            {
                return;
            }
            Queue<BinarySearchTreeNode> q = new Queue<BinarySearchTreeNode>();
            BinarySearchTreeNode t = root;
            q.Enqueue(t);
            while (q.Count > 0)
            {
                t = q.Dequeue();
                Console.WriteLine(t.data + " "+t.key);
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
        public void inOrder2(BinarySearchTreeNode root)
        {
            Console.WriteLine();
            Stack<BinarySearchTreeNode> s = new Stack<BinarySearchTreeNode>();
            BinarySearchTreeNode t = root;
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
                    Console.WriteLine(t.data + " " + t.key);
                    t = t.right;
                }
            }
        }
    }
}
