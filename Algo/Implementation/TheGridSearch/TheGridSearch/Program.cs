using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Solution
{
    static bool isPatternAvailable(List<string> grid, List<string> pattern, int rowGrid, int rowPattern, int index)
    {
        if (rowPattern == pattern.Count)
        {
            return true;
        }
        if ((rowGrid < grid.Count))
        {
            if (index == -1)
            {
                index = grid[rowGrid].IndexOf(pattern[rowPattern]);
                while (index != -1)
                {
                    if (!isPatternAvailable(grid, pattern, rowGrid + 1, rowPattern + 1, index))
                    {
                        if (index != grid[rowGrid].Length - 1)
                        {
                            index = grid[rowGrid].IndexOf(pattern[rowPattern], index + 1);
                        }
                        else
                            index = -1;
                    }
                    else
                        return true;
                }
                return isPatternAvailable(grid, pattern, rowGrid + 1, 0, -1);
            }
            else
            {
                int newIndex;
                if (index != 0)
                    newIndex = grid[rowGrid].IndexOf(pattern[rowPattern], index - 1);
                else
                    newIndex = grid[rowGrid].IndexOf(pattern[rowPattern]);
                if (newIndex == index)
                {
                    if (isPatternAvailable(grid, pattern, rowGrid + 1, rowPattern + 1, index))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    static void Main(string[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        while (testNumber-- > 0)
        {
            int[] restrictions = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            List<string> grid = new List<string>();
            List<string> pattern = new List<string>();
            while (restrictions[0]-- > 0)
            {
                grid.Add(Console.ReadLine());
            }
            restrictions = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            while (restrictions[0]-- > 0)
            {
                pattern.Add(Console.ReadLine());
            }
            if (isPatternAvailable(grid,pattern,0,0,-1))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }


    }
}

