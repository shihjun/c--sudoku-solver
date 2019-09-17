using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Sudoku
    {
        public static string empty = "0";
        public static int size = 9;
        public static string[,] board_in_grid = new string[,] { 
        { "", "", "", "", "", "", "", "", ""},
        { "", "", "", "", "", "", "", "", ""},
        { "", "", "", "", "", "", "", "", ""},
        { "", "", "", "", "", "", "", "", ""},
        { "", "", "", "", "", "", "", "", ""},
        { "", "", "", "", "", "", "", "", ""},
        { "", "", "", "", "", "", "", "", ""},
        { "", "", "", "", "", "", "", "", ""},
        { "", "", "", "", "", "", "", "", ""}
        };

        public static string Solve(string board)
        {
            var result = "";
            char[] boardArray = board.ToCharArray();
            for (int idx = 0; idx < board.Length; idx++)
            {
                board_in_grid[idx / 9, idx % 9] = boardArray[idx].ToString();
            };
            if (Algorithm())
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        var num = board_in_grid[row, col];
                        result += num;
                    }
                }
                return result;
            }
            else {
                return "Unsolvable";
            }
        }



        public static bool Algorithm()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (board_in_grid[row, col] == empty)
                    {
                        for (int num = 1; num < size + 1; num++)
                        {
                            if (CheckPossibleNum(row, col, num))
                            {
                                board_in_grid[row, col] = num.ToString();
                                if (Algorithm())
                                {
                                    return true;
                                }
                                else
                                {
                                    board_in_grid[row, col] = empty;
                                }
                            }
                        }
                        return false;
                    }        
                }
            }
            return true;
        }

        public static bool CheckPossibleNum(int row, int col, int num)
        {
            return CheckRow(row, num) && CheckCol(col, num) && CheckGrid(row, col, num);
        }
    
        public static bool CheckRow(int row, int num)
        {
            for (int i = 0; i < size; i++)
            {
                if (board_in_grid[row, i] == num.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckCol(int col, int num)
        {
            for (int i = 0; i < size; i++)
            {
                if (board_in_grid[i, col] == num.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckGrid(int row, int col, int num)
        {
            var r = row - row % 3;
            var c = col - col % 3;
            for (int i = r; i < r+3; i++)
            {
                for (int j = c; j < c+3; j++)
                {
                    if (board_in_grid[i, j] == num.ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
