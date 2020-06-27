using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.Graphics
{
    class BackPack
    {
        //static void Main()
        //{
        //    Monster[] monsters = {
        //        new Monster(12, 24),
        //        new Monster(18, 20),
        //        new Monster(19, 20),

        //        new Monster(25, 30),

        //        new Monster(10, 23),

        //        new Monster(10, 23)
        //        };
        //    BackPack b = new BackPack();
        //    Console.WriteLine("最大价=" + b.getMaxValue(monsters, 40));;
        //}
        /// <summary>
        /// 动态规划求最大价值
        /// </summary>
        /// <param name="monsters">怪物数组</param>
        /// <param name="allTime">最大刷怪时间</param>
        /// <returns>最大金币数</returns>
        public int getMaxValue(Monster []monsters, int allTime)
        {
            int num = monsters.GetLength(0);//怪物种类
            int[,] dp = new int[num+1,allTime+1];//怪物个数
            for(int i=1;i<num+1;i++)//怪物种类数
            {
                for(int j=1;j<allTime+1;j++)//最大刷怪时间
                {
                    if(monsters[i-1].costTime<j)//打败该怪所需时间小于剩余规定时间
                    {
                        //打死第i个怪物的价值大，还是不打死第i个怪物价值大
                        if(dp[i-1,j]<(dp[i-1,j-monsters[i-1].costTime]+monsters[i-1].coin))
                        {
                            dp[i,j] = dp[i - 1, j - monsters[i - 1].costTime] + monsters[i - 1].coin;
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }
            return dp[num,allTime];
        }
    }


    class Monster
    {
        public int costTime;
        public int coin;
        public Monster()
        {

        }
        public Monster(int costTime,int coin)
        {
            this.coin = coin;
            this.costTime = costTime;
        }
    }

}
