using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa.RomanNumeralsConverter
{
    public delegate void DrawNumbers(int which, int size, char[,] array);//画数委托
    class RomanNumbers
    {
        #region 0
        /// <summary>
        /// 画0
        /// </summary>
        /// <param name="which">0是第几个数字</param>
        /// <param name="size">倍数</param>
        /// <param name="array">存储数据的数组</param>
        public void drawZero(int which,int size,char [,]array)
        {
            int row = getRow(size);
            int col = getCol(size, which);
            for(int i=0;i<row;i++)
            {
                for(int j=col;j<(col+3+size-1);j++)
                {
                    if(((i==0||i==row-1)&&j>col&&j<(col+size+1)))//画‘-’
                    {
                        array[i, j] = '-';
                    }
                    else if((j== col || j== (col + size + 1)) &&i>0&&i<row-1&&i!=(row/2))//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else//画空格
                    {
                        array[i, j] = ' ';
                    }
                }
            }
        }
#endregion

        #region 1
        /// <summary>
        /// 画1
        /// </summary>
        /// <param name="which">1是第几个数字</param>
        /// <param name="size">倍数</param>
        /// <param name="array">存储数据的数组</param>
        public void drawOne(int which,int size,char [,] array)
        {
            int row = getRow(size);
            int col = getCol(size, which);
            for (int i = 0; i < row; i++)
            {
                for (int j = col; j < (col + 3 + size - 1); j++)
                {
                    if (j == (col + size + 1) && i > 0 && i < row - 1&&i!=(row/2))//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else//画空格
                    {
                        array[i, j] = ' ';
                    }
                }
            }
        }
        #endregion

        #region 2
        /// <summary>
        /// 画2
        /// </summary>
        /// <param name="which">2是第几个数字</param>
        /// <param name="size">倍数</param>
        /// <param name="array">存储数据的数组</param>
        public void drawTwo(int which, int size, char[,] array)
        {
            int row = getRow(size);
            int col = getCol(size, which);
            for (int i = 0; i < row; i++)
            {
                for (int j = col; j < (col + 3 + size - 1); j++)
                {
                    if (((i == 0 || i == row - 1||i==row/2) && j > col && j < (col + size + 1)))//画‘-’
                    {
                        array[i, j] = '-';
                    }
                    else if (j == (col + size + 1) && i > 0 && i < row/2)//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else if(j==col&&i>row/2&&i<row-1)//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else//画空格
                    {
                        array[i, j] = ' ';
                    }
                }
            }
        }
        #endregion

        #region 3
        /// <summary>
        /// 画3
        /// </summary>
        /// <param name="which">3是第几个数字</param>
        /// <param name="size">倍数</param>
        /// <param name="array">存储数据的数组</param>
        public void drawThree(int which, int size, char[,] array)
        {
            int row = getRow(size);
            int col = getCol(size, which);
            for (int i = 0; i < row; i++)
            {
                for (int j = col; j < (col + 3 + size - 1); j++)
                {
                    if (((i == 0 || i == row - 1 || i == row / 2) && j > col && j < (col + size + 1)))//画‘-’
                    {
                        array[i, j] = '-';
                    }
                    else if (j == (col + size + 1) && i > 0 && i !=row / 2&& i < row - 1)//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else//画空格
                    {
                        array[i, j] = ' ';
                    }
                }
            }
        }
        #endregion

        #region 4
        /// <summary>
        /// 画4
        /// </summary>
        /// <param name="which">4是第几个数字</param>
        /// <param name="size">倍数</param>
        /// <param name="array">存储数据的数组</param>
        public void drawFour(int which, int size, char[,] array)
        {
            int row = getRow(size);
            int col = getCol(size, which);
            for (int i = 0; i < row; i++)
            {
                for (int j = col; j < (col + 3 + size - 1); j++)
                {
                    if ((( i == row / 2) && j > col && j < (col + size + 1)))//画‘-’
                    {
                        array[i, j] = '-';
                    }
                    else if ((j == (col + size + 1)|| j == col) && i > 0 && i < row / 2)//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else if (j == (col + size + 1) && i > row / 2 && i < row - 1)//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else//画空格
                    {
                        array[i, j] = ' ';
                    }
                }
            }
        }
        #endregion

        #region 5
        /// <summary>
        /// 画5
        /// </summary>
        /// <param name="which">5是第几个数字</param>
        /// <param name="size">倍数</param>
        /// <param name="array">存储数据的数组</param>
        public void drawFive(int which, int size, char[,] array)
        {
            int row = getRow(size);
            int col = getCol(size, which);
            for (int i = 0; i < row; i++)
            {
                for (int j = col; j < (col + 3 + size - 1); j++)
                {
                    if (((i == 0 || i == row - 1 || i == row / 2) && j > col && j < (col + size + 1)))//画‘-’
                    {
                        array[i, j] = '-';
                    }
                    else if (j == (col + size + 1) && i > row / 2 && i < row - 1)//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else if (j == col && i > 0 && i < row / 2)//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else//画空格
                    {
                        array[i, j] = ' ';
                    }
                }
            }
        }
        #endregion

        #region 6
        /// <summary>
        /// 画6
        /// </summary>
        /// <param name="which">6是第几个数字</param>
        /// <param name="size">倍数</param>
        /// <param name="array">存储数据的数组</param>
        public void drawSix(int which, int size, char[,] array)
        {
            int row = getRow(size);
            int col = getCol(size, which);
            for (int i = 0; i < row; i++)
            {
                for (int j = col; j < (col + 3 + size - 1); j++)
                {
                    if (((i == 0 || i == row - 1 || i == row / 2) && j > col && j < (col + size + 1)))//画‘-’
                    {
                        array[i, j] = '-';
                    }
                    else if ((j == (col + size + 1)|| j == col) && i > row / 2 && i < row - 1)//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else if (j == col && i > 0 && i < row / 2)//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else//画空格
                    {
                        array[i, j] = ' ';
                    }
                }
            }
        }
        #endregion

        #region 7
        /// <summary>
        /// 画7
        /// </summary>
        /// <param name="which">7是第几个数字</param>
        /// <param name="size">倍数</param>
        /// <param name="array">存储数据的数组</param>
        public void drawSeven(int which, int size, char[,] array)
        {
            int row = getRow(size);
            int col = getCol(size, which);
            for (int i = 0; i < row; i++)
            {
                for (int j = col; j < (col + 3 + size - 1); j++)
                {
                    if (((i == 0) && j > col && j < (col + size + 1)))//画‘-’
                    {
                        array[i, j] = '-';
                    }
                    else if (j == (col + size + 1) && i > 0 && i < row - 1 && i != (row / 2))//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else//画空格
                    {
                        array[i, j] = ' ';
                    }
                }
            }
        }
        #endregion

        #region 8
        /// <summary>
        /// 画8
        /// </summary>
        /// <param name="which">8是第几个数字</param>
        /// <param name="size">倍数</param>
        /// <param name="array">存储数据的数组</param>
        public void drawEight(int which, int size, char[,] array)
        {
            int row = getRow(size);
            int col = getCol(size, which);
            for (int i = 0; i < row; i++)
            {
                for (int j = col; j < (col + 3 + size - 1); j++)
                {
                    if (((i == 0 || i == row - 1 || i == row / 2) && j > col && j < (col + size + 1)))//画‘-’
                    {
                        array[i, j] = '-';
                    }
                    else if ((j == (col + size + 1) || j == col) && i != row / 2 && i < row - 1&&i>0)//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else//画空格
                    {
                        array[i, j] = ' ';
                    }
                }
            }
        }
        #endregion

        #region 9
        /// <summary>
        /// 画9
        /// </summary>
        /// <param name="which">9是第几个数字</param>
        /// <param name="size">倍数</param>
        /// <param name="array">存储数据的数组</param>
        public void drawNine(int which, int size, char[,] array)
        {
            int row = getRow(size);
            int col = getCol(size, which);
            for (int i = 0; i < row; i++)
            {
                for (int j = col; j < (col + 3 + size - 1); j++)
                {
                    if (((i == 0 || i == row - 1 || i == row / 2) && j > col && j < (col + size + 1)))//画‘-’
                    {
                        array[i, j] = '-';
                    }
                    else if ((j == (col + size + 1) || j == col) && i < row / 2 && i>0)//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else if (j == (col + size + 1) && i < row-1&& i > row / 2)//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else//画空格
                    {
                        array[i, j] = ' ';
                    }
                }
            }
        }
        #endregion

        #region E
        /// <summary>
        /// 画E
        /// </summary>
        /// <param name="which">E是第几个数字</param>
        /// <param name="size">倍数</param>
        /// <param name="array">存储数据的数组</param>
        public void drawE(int which, int size, char[,] array)
        {
            int row = getRow(size);
            int col = getCol(size, which);
            for (int i = 0; i < row; i++)
            {
                for (int j = col; j < (col + 3 + size - 1); j++)
                {
                    if (((i == 0 || i == row - 1 || i == row / 2) && j > col && j < (col + size + 1)))//画‘-’
                    {
                        array[i, j] = '-';
                    }
                    else if (j == (col) && i > 0 && i != row / 2 && i < row - 1)//画‘|’
                    {
                        array[i, j] = '|';
                    }
                    else//画空格
                    {
                        array[i, j] = ' ';
                    }
                }
            }
            //printArray(array);
        }

        #endregion


       //static void Main()
       //{
       //     char[,] array; //= new char[5, 33];//存储数据数组
       //     RomanNumbers rn = new RomanNumbers();//引用
       //     Dictionary<string, DrawNumbers> drawDict = new Dictionary<string, DrawNumbers>();//画数委托
       //     drawDict.Add("0", rn.drawZero);
       //     drawDict.Add("1", rn.drawOne);
       //     drawDict.Add("2", rn.drawTwo);
       //     drawDict.Add("3", rn.drawThree);
       //     drawDict.Add("4", rn.drawFour);
       //     drawDict.Add("5", rn.drawFive);
       //     drawDict.Add("6", rn.drawSix);
       //     drawDict.Add("7", rn.drawSeven);
       //     drawDict.Add("8", rn.drawEight);
       //     drawDict.Add("9", rn.drawNine);
       //     drawDict.Add("E", rn.drawE);

       //     Dictionary<string, int> numDict = new Dictionary<string, int>();//数据字典
       //     numDict.Add("I", 1);
       //     numDict.Add("V", 5);
       //     numDict.Add("X", 10);
       //     numDict.Add("L", 50);
       //     numDict.Add("C", 100);
       //     numDict.Add("D", 500);
       //     numDict.Add("M", 1000);

       //     StringBuilder sb = new StringBuilder();//输入的内容
       //     bool flag = true;//程序是否运行
       //     int size = 1;//输出数字的倍数
       //     while (flag)
       //     {
       //         sb.Clear();
       //         sb.Append(Console.ReadLine());//获取输入的内容
       //         if (sb.ToString().Contains("set size"))//设置倍数
       //         {
       //             size = int.Parse(sb.ToString().Substring(sb.ToString().Length - 1));
       //         }
       //         else if (sb.ToString().Contains("exit"))//退出循环
       //         {
       //             flag = false;
       //         }
       //         else//画数或画E
       //         {
       //             bool hasOtherCode = false;//假设不含有其他非法字符
       //             //查看输入中是否包含其他非法字符
       //             for(int i=0;i<sb.ToString().Length;i++)
       //             {
       //                 string temp = sb.ToString().Substring(i, 1);//获取单个字符
       //                  if (temp!="I" && temp != "V"&& temp != "X"&&
       //                     temp != "L" && temp != "C" && temp != "D" &&
       //                     temp != "M")
       //                 {
       //                     hasOtherCode = true;
       //                     break;
       //                 }
       //                 temp = null;//设置为null，方便垃圾回收
       //             }

       //             if(hasOtherCode)//有非法字符，画E
       //             {
       //                 int row = rn.getRow(size);
       //                 int col = rn.getCols(size, 0);
       //                 array = new char[row, col];//数组大小
       //                 drawDict["E"].Invoke(0, size, array);//画E
       //                 rn.printArray(array);
       //             }
       //             else//没有，画数字
       //             {
       //                 int num = 0;
       //                 for (int i = 0; i < sb.ToString().Length; i++)//数的个数
       //                 {
       //                     num += numDict[sb.ToString().Substring(i, 1)];
       //                 }
       //                 int row = rn.getRow(size);
       //                 int col = rn.getCols(size, num.ToString().Length - 1);
       //                 array = new char[row, col];//数组大小
       //                 for (int i = 0; i < num.ToString().Length; i++)//画出每个数字
       //                 {
       //                     drawDict[num.ToString().Substring(i, 1)].Invoke(i, size, array);
       //                 }
       //                 rn.printArray(array);
       //             }
       //         }
       //     }
       // }

       /// <summary>
       /// 数组输出
       /// </summary>
       /// <param name="array">数组</param>
       public void printArray(char [,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 获取有几行
        /// </summary>
        /// <param name="size">倍速</param>
        /// <returns>行数</returns>
        public int  getRow(int size)
        {
            return (5 + (size - 1) * 2);
        }
        /// <summary>
        /// 获取从第几列开始
        /// </summary>
        /// <param name="size">倍数</param>
        /// <param name="which">第几个数，which从0开始</param>
        /// <returns>从哪开始</returns>
        public int getCol(int size,int which)
        {
            return (3 + size-1) * which;
        }
        /// <summary>
        /// 获取数组列总数
        /// </summary>
        /// <param name="size">倍数</param>
        /// <param name="num">数的个数，从0开始</param>
        /// <returns>数组列数</returns>
        public int getCols(int size,int num)
        {
            return getCol(size, num) + 3 + size - 1;
        }
    }
}
