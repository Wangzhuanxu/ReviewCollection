using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Graphics
{
    /// <summary>
    /// 深度优先
    /// 难以寻找最优解，仅仅只能寻找有解。其优点就是内存消耗小，
    /// 克服了刚刚说的广度优先搜索的缺点。
    /// </summary>
    class DFS
    {
        //四个方向
        int[,] dir =
        {
            {1,0 },
            {-1,0 },
            {0,1 },
            {0,-1 }
        };
        
        //static void Main()
        //{
        //    //迷宫
        //    int[,] maze = {
        //       { 0, 1, 0, 0, 0 },
        //       { 0, 1, 0, 1, 0 },
        //       { 0, 0, 0, 0, 0 },
        //       { 0, 1, 1, 1, 0 },
        //       { 0, 0, 0, 1, 0 },
        //    };
        //    DFS b = new DFS();
        //    int[,] visit = new int[maze.GetLength(0), maze.GetLength(1)];//是否访问过
        //    DFSNode r = b.dfs(new DFSNode(0, 0), new DFSNode(4, 4), maze,visit);
        //    if (r == null)
        //        Console.WriteLine("null");

        //    while (r != null)
        //    {
        //        Console.WriteLine(r.x + "__" + r.y);
        //        r = r.parent;
        //    }


        //}
        public DFSNode dfs(DFSNode start, DFSNode end, int[,] maze,int [,]visit)
        {
            visit[start.x, start.y] = 1;//设置为访问
            Console.WriteLine(start.x + " " + start.y);
            //Console.WriteLine(start.x + " " + start.y);
            if (start==null)
            {
                return null;
            }
            for (int i = 0; i < 4; i++)//当前节点的四个方位
            {
                DFSNode next = new DFSNode(start.x + dir[i, 0], start.y + dir[i, 1]);//下一个方向节点
                if (next.x >= 0 && next.x < maze.GetLength(0) && next.y >= 0 && next.y < maze.GetLength(1) && maze[next.x, next.y] != 1)//该值是否存在
                {  
                    next.parent = start;
                    next.len = start.len + 1;//路径加一
                    if (next.x == end.x && next.y == end.y)
                    {
                        return next;//返回终点
                    }
                    if (visit[next.x, next.y] == 0)//判断该点是否访问过
                    {
                        DFSNode node = dfs(next, end, maze,visit);
                        if (node!=null&&node.x == end.x && node.y == end.y)//查看是否查找到相应的点
                        {
                            return node;//返回查找到的点
                        }
                    }
                }
            }
            Console.WriteLine();
               
            return null;
        }
    }

    class DFSNode
    {
        public int x;//xy坐标
        public int y;
        public DFSNode parent;//父节点
        public int len;//长度
        public DFSNode(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.parent = null;
            len = 1;
        }
    }
}
