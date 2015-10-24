using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        int[] requirements = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        int n = requirements[0];
        int testNumber = requirements[1];
        int[] roadWidths = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        while (testNumber-- > 0)
        {
            int[] testRestriction = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int min = 3;
            for (int i = testRestriction[0]; i <= testRestriction[1]; i++)
            {
                if (roadWidths[i] < min)
                    min = roadWidths[i];
            }
            Console.WriteLine(min);
        }
    }
}