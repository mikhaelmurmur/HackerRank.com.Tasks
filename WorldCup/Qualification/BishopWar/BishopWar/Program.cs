using System;
using System.Collections.Generic;
using System.Linq;


class Solution
{
    static cell[,] GetInput(int rows, int columns)
    {
        char ch;
        cell[,] grid = new cell[10, 10];
        for (int row = 0; row < rows; row++)
        {
            string s = Console.ReadLine();
            for (int column = 0; column < columns; column++)
            {
                ch = s[column];
                if (ch == '*')
                {
                    grid[row, column].type = CellType.obstacle;
                }
                else
                {
                    if (ch == '.')
                    {
                        grid[row, column].type = CellType.empty;
                    }
                }
            }
        }
        return grid;
    }

    static List<int> SetRightDiagonals(int rows, int columns, cell[,] grid)
    {
        int diagonalsNumber = 0;
        List<int> rightDiagonals = new List<int>();
        for (int row = 0; row < rows; row++)
        {
            int column = 0;
            int tmpRow = row;
            bool isObstacle = true;
            while (tmpRow > -1)
            {
                if (grid[tmpRow, column].type == CellType.obstacle)
                {
                    isObstacle = true;
                }
                else
                {
                    if (isObstacle)
                    {
                        isObstacle = false;
                        diagonalsNumber++;
                        rightDiagonals.Add(diagonalsNumber - 1);
                    }
                    grid[tmpRow, column].rightDiagonal = diagonalsNumber - 1;
                }
                tmpRow--;
                column++;
            }
        }


        for (int column = 1; column < columns; column++)
        {
            int row = rows - 1;
            int tmpColumn = column;
            bool isObstacle = true;
            while (tmpColumn < columns)
            {
                if (grid[row, tmpColumn].type == CellType.obstacle)
                {
                    isObstacle = true;
                }
                else
                {
                    if (isObstacle)
                    {
                        isObstacle = false;
                        diagonalsNumber++;
                        rightDiagonals.Add(diagonalsNumber - 1);
                    }
                    grid[row, tmpColumn].rightDiagonal = diagonalsNumber - 1;
                }
                tmpColumn++;
                row--;
            }
        }
        return rightDiagonals;
    }

    static List<int> SetLeftDiagonals(int rows, int columns, cell[,] grid)
    {
        int diagonalsNumber = 0;
        List<int> leftDiagonals = new List<int>();
        for (int row = 0; row < rows; row++)
        {
            int column = columns - 1;
            int tmpRow = row;
            bool isObstacle = true;
            while ((tmpRow > -1)&&(column>-1))
            {
                if (grid[tmpRow, column].type == CellType.obstacle)
                {
                    isObstacle = true;
                }
                else
                {
                    if (isObstacle)
                    {
                        isObstacle = false;
                        diagonalsNumber++;
                        leftDiagonals.Add(diagonalsNumber - 1);
                    }
                    grid[tmpRow, column].leftDiagonal = diagonalsNumber - 1;
                }
                tmpRow--;
                column--;
            }
        }


        for (int column = 1; column < columns; column++)
        {
            int row = rows - 1;
            int tmpColumn = columns - column - 1;
            bool isObstacle = true;
            while ((tmpColumn > -1)&&(row>-1))
            {
                if (grid[row, tmpColumn].type == CellType.obstacle)
                {
                    isObstacle = true;
                }
                else
                {
                    if (isObstacle)
                    {
                        isObstacle = false;
                        diagonalsNumber++;
                        leftDiagonals.Add(diagonalsNumber - 1);
                    }
                    grid[row, tmpColumn].leftDiagonal = diagonalsNumber - 1;
                }
                tmpColumn--;
                row--;
            }
        }
        return leftDiagonals;
    }



    enum CellType
    {
        empty,
        obstacle
    }

    struct cell
    {
        public CellType type;
        public int rightDiagonal, leftDiagonal;
    }

    static void SolveIt(int rows, int columns, int row)
    {
        for (int column = 0; column < columns; column++)
        {
            if ((rightDiagonals.Contains(grid[row, column].rightDiagonal)) &&
                (leftDiagonals.Contains(grid[row, column].leftDiagonal)) && grid[row, column].type == CellType.empty)
            {
                if (row != rows - 1)
                {
                    rightDiagonals.Remove((grid[row, column].rightDiagonal));
                    leftDiagonals.Remove((grid[row, column].leftDiagonal));
                    if ((rightDiagonals.Count != 0) && (leftDiagonals.Count != 0))
                    {
                        SolveIt(rows, columns, row + 1);
                    }
                    rightDiagonals.Add((grid[row, column].rightDiagonal));
                    leftDiagonals.Add((grid[row, column].leftDiagonal));
                }
                else
                {
                    numberOfSolutions++;
                }
            }
        }
    }

    static List<int> rightDiagonals;
    static List<int> leftDiagonals;
    static long numberOfSolutions;
    static cell[,] grid;
    static void Main(string[] args)
    {
        numberOfSolutions = 0;
        int[] constrains = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        grid = GetInput(constrains[0], constrains[1]);
        rightDiagonals = SetRightDiagonals(constrains[0], constrains[1], grid);
        leftDiagonals = SetLeftDiagonals(constrains[0], constrains[1], grid);
        SolveIt(constrains[0], constrains[1], 0);
        Console.WriteLine(numberOfSolutions);
    }
}

