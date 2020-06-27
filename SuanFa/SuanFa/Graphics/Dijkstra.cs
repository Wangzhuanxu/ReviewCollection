using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Graphics
{
    class Dijkstra
    {
        //static void Main()
        //{
        //    //迷宫
        //    int[,] maze = {
        //      //a   b   c   d   e   f  g
        //       { 0, 2, 1,5},
        //       { 2, 0,-1,2},
        //       { 1,-1, 0,1},
        //       { 5, 2, 1,0},
        //    };

        //    for (int i = 0; i < maze.GetLength(0); i++)
        //    {
        //        dijkstra(maze, i);
        //    }
        //}

        public static void dijkstra(int [,]maze,int start)
        {
            int n = maze.GetLength(0);//顶点个数
            int[] visit = new int[n];//未被访问点
            string[] path = new string[n];//路径点
            int[] minLen = new int[n];//最短路径
            for(int i=0;i<n;i++)
            {
                path[i] = start + "," + i;
                minLen[i] = maze[start, i];
            }
            visit[start] = 1;
            minLen[start] = 0;
            for(int i=1;i<n;i++)
            {
                int min = int.MaxValue;//距离start最小的距离
                int k = -1;//距离start最小的点的索引
                for(int j=0;j<n;j++)
                {
                    //Console.WriteLine("j=" + j + "  start=" + start+" n="+n);
                    if(visit[j]==0&&min>maze[start,j]&&maze[start,j]>=0)//寻找里start最近点的索引
                    {
                        min = maze[start, j];
                        k = j;
                    }
                }
                if(k>=0)//k是否存在
                {
                    minLen[k] = min;//设置k的最小值
                    visit[k] = 1;

                    for(int count=0;count<n;count++)
                    {
                        if(visit[count]==0&&maze[start,k]>=0&&maze[k,count]>0&& maze[start, k]+maze[k, count]<maze[start,count])
                        {

                            maze[start, count] = maze[start, k] + maze[k, count];//修改start到该点的距离
                            path[count] = path[k] + "," + count;//获取新的路径点
                        }
                    }
                }
            }

            for(int i=0;i<path.Length;i++)
            {
                Console.WriteLine(path[i] + ",len=" + minLen[i]+" i="+i);
            }
            Console.WriteLine();
        }
    }
}
