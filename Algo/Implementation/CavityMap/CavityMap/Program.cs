using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    struct cell
    {
        public int col;
        public int row;
    }

    static bool isInList(int row, int col, List<cell> caves)
    {
        foreach (cell c in caves)
        {
            if (c.row == row)
                if (c.col == col)
                    return true;
        }
        return false;
    }
    static void Main(String[] args)
    {
        int[,] map = new int[100, 100];
        int n = int.Parse(Console.ReadLine());
        List<cell> caves = new List<cell>();
        for (int row = 0; row < n; row++)
        {
            string str = Console.ReadLine();
            for (int column = 0; column < n; column++)
            {
                
                map[row, column] = int.Parse(str[column].ToString());
            }
           // Console.ReadLine();
        }
        for (int row = 0; row < n; row++)
        {
            for (int column = 0; column < n; column++)
            {
                if ((row != 0) && (column != 0) && (row != n - 1) && (column != n - 1))
                {
                    if ((map[row, column] > map[row - 1, column])
                        && (map[row, column] > map[row + 1, column])
                        && (map[row, column] > map[row, column + 1])
                      && (map[row, column] > map[row, column - 1]))
                    {
                        cell c = new cell();
                        c.col = column;
                        c.row = row;
                        caves.Add(c);
                    }
                }
            }
        }

        for (int row = 0; row < n; row++)
        {
            for (int column = 0; column < n; column++)
            {
                if (!isInList(row, column, caves))
                    Console.Write(map[row, column]);
                else
                    Console.Write("X");
            }
            Console.WriteLine();
        }
    }
}