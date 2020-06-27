using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Graphics
{
    /// <summary>
    /// 广度优先---最短路径
    /// 在树的层次较深&子节点数较多的情况下，消耗内存十分严重。
    /// 广度优先搜索适用于节点的子节点数量不多，并且树的层次不会太深的情况。
    /// </summary>
    class BFS
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
        //    BFS b = new BFS();
        //    BFSNode r = b.bfs(new BFSNode(0, 0), new BFSNode(4, 4),maze);
        //    //if(r==null)
        //    Console.WriteLine(r.x+" "+r.y+" "+r.len);

        //   while(r!=null)
        //    {
        //        Console.WriteLine(r.x + "__"+r.y);
        //        r = r.parent;
        //    }

        //}
        public BFSNode bfs(BFSNode start,BFSNode end,int [,]maze)
        {
            Queue<BFSNode> q = new Queue<BFSNode>();
            int[,] visit = new int[maze.GetLength(0), maze.GetLength(1)];//是否访问过
            q.Enqueue(start);//加入起点
            visit[start.x, start.y] = 1;//设置访问过
            Console.WriteLine(start.x + " " + start.y);
            while(q.Count>0)
            {
                BFSNode now = q.Dequeue();//当前节点
                for(int i=0;i<4;i++)//当前节点的四个方位
                {
                    BFSNode next = new BFSNode(now.x + dir[i, 0], now.y + dir[i, 1]);//下一个方向节点
                   
                    if (next.x>=0&& next.x<maze.GetLength(0)&&next.y>=0&&next.y<maze.GetLength(1)&&maze[next.x, next.y]!=1)//该值是否存在
                    {
                        next.parent = now;
                        next.len = now.len + 1;//路径加一
                        if (next.x==end.x&&next.y==end.y)
                        {        
                            return next;//返回终点
                        }
                        if (visit[next.x, next.y] == 0)
                        {
                            
                            visit[next.x, next.y] = 1;//设置为访问
                            q.Enqueue(next);//加入队列
                        }
                        
                    }
                }
                Console.WriteLine();
            }
            return null;
        }

    }

    class BFSNode
    {
        public int x;//xy坐标
        public int y;
        public BFSNode parent;//父节点
        public int len;//长度
        public BFSNode(int x,int y)
        {
            this.x = x;
            this.y = y;
            this.parent = null;
            len = 1;
        }
    }
}
