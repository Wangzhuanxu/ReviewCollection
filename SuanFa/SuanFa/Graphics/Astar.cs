using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Graphics
{
    class Grid:IComparable
    {
        //位置
        public int x;
        public int y;
        //f，g，h
        public int g;
        public int f;
        public int h;
        //parent
        public Grid parent;
        /// <summary>
        /// 比较方法
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            Grid gd = (Grid)obj;
            if(this.f>gd.f)
            {
                return 1;
            }
            else if(this.f<gd.f)
            {
                return -1;
            }
            return 0;
        }

        public Grid(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Grid node=(Grid)obj;
            if(node.x==this.x&&node.y==this.y)
            {
                return true;
            }
            return false;
        }
    }
    /// <summary>
    /// 保存地图信息
    /// </summary>
    class MapInfo
    {
        public int width;//地图宽
        public int height;//地图高
        public Grid start;//起点
        public Grid end;//终点
        public int[,] map;//地图数据
        public MapInfo(int width,int height,Grid start,Grid end,int[,] map)
        {
            this.width = width;
            this.height = height;
            this.start = start;
            this.end = end;
            this.map = map;
        }
    }

    class Astar
    {
        public List<Grid> openList = new List<Grid>();//开放列表
        public List<Grid> closeList = new List<Grid>();//关闭列表
        const int HYPOTENUSE = 14;//斜边
        const int STRAIGHT = 10;//直边
        MapInfo mapInfo;
        //static void Main()
        //{
        //    int[,] maze = {
        //        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //        { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0 },
        //        { 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
        //        { 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
        //        { 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
        //        { 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }
        //    };
        //    Grid start = new Grid(0, 0);
        //    Grid end = new Grid(maze.GetLength(0)-1, maze.GetLength(1)-6);
        //    MapInfo mi = new MapInfo(maze.GetLength(0), maze.GetLength(1), start, end, maze);
        //    Astar a = new Astar(mi);
        //    Grid node=a.Start();
        //    while(node!=null)
        //    {
        //        maze[node.x, node.y] = 2;
        //        node = node.parent;
        //    }

        //    for(int i=0;i<maze.GetLength(0);i++)
        //    {
        //        for(int j=0;j<maze.GetLength(1);j++)
        //        {
        //            Console.Write(maze[i, j] + ",");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        public Astar(MapInfo mapInfo)
        {
            this.mapInfo = mapInfo;
        }

        public Grid Start()
        {
            openList.Add(mapInfo.start);//放入起点
            
            while(openList.Count>0)//开放列表中大于0
            {
                Grid current = openList[0];//取出第一个
                if(current.Equals(mapInfo.end))
                {
                    return current;
                }
                addNodeToOpenList(current);//添加顶点
                closeList.Add(current);
                openList.Remove(current);
                openList.Sort();
                Console.WriteLine(openList.Count);
            }
            return null;
        }

        public void addNodeToOpenList(Grid current)
        {
            int x = current.x;
            int y = current.y;
            addNodeToOpenList(current, x, y-1, STRAIGHT);//上
            addNodeToOpenList(current, x-1, y, STRAIGHT);//左
            addNodeToOpenList(current, x, y+1, STRAIGHT);//下
            addNodeToOpenList(current, x + 1, y, STRAIGHT);//右
        }

        public void addNodeToOpenList(Grid current,int x,int y,int value)
        {
            if (gridIsOK(x,y)&&!isInCloseList(x,y))//格子存在,并且不包含在关闭列表中
            {
                int g = current.g + value;//计算新的g值
                Grid node = getNodeInOpenList(x, y);//查看是否在开放列表中
                if(node==null)//不包含在开放列表中
                {
                    node = new Grid(x, y);
                    node.h = calH(node, mapInfo.end);//计算h
                    node.g = g;//计算g
                    node.f = node.f + node.g;//计算f
                    node.parent = current;
                    openList.Add(node);
                }
                else
                {
                    if(node.g>g)//更新g值
                    {
                        node.g = g;
                        node.f = node.g + node.h;
                        node.parent = current;
                    }
                }
            }
        }

        /// <summary>
        /// 是否包含在开放列表中
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Grid getNodeInOpenList(int x,int y)
        {
            foreach (Grid ol in openList)
            {
                if (ol.x == x && ol.y == y)
                {
                    return ol;
                }
            }
           
            return null;
        }

        /// <summary>
        /// 关闭列表是否包含
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>false :不包含
        /// true：包含
        /// </returns>
        public bool isInCloseList(int x,int y)
        {
            foreach (Grid cl in closeList)
            {
                if(cl.x==x&&cl.y==y)
                {
                    return true;
                }
            }
            
            return false;
        }


        /// <summary>
        /// 计算H
        /// </summary>
        /// <param name="current">当前节点</param>
        /// <param name="end">终点</param>
        /// <returns></returns>
        public int calH(Grid current,Grid end)
        {
            return (Math.Abs(current.x - end.x) + Math.Abs(current.y - end.y)) * STRAIGHT;
        }

        /// <summary>
        /// 格子是否存在
        /// </summary>
        /// <returns></returns>
        public bool gridIsOK(int x,int y)
        {
            //if (x >=0 && x < mapInfo.width && y >= 0 && y < mapInfo.height)
               //Console.WriteLine("gridIsOK=" + x + " y=" + y+ " mapInfo.width="+ mapInfo.width+ " mapInfo.height="+ mapInfo.height+ " mapInfo.map[x,y]="+ mapInfo.map[x, y]);
            if (x>=0&&x<mapInfo.width&&y>=0&&y<mapInfo.height&&mapInfo.map[x,y]!=1)//该格子合法
            {
                return true;
            }
            return false;
        }
    }
}
