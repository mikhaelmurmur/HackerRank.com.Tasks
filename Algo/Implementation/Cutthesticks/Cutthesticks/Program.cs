using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static int GetMin(int[] arr)
    {
        int min = -1;
        foreach (int i in arr)
        {
            if (i != 0)
            {
                if (min > 0)
                {
                    if (min > i)
                        min = i;
                }
                else
                    min = i;
            }
        }
        return min;
    }
    static void Main(String[] args)
    {
        Console.ReadLine();
        int[] sticks = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        bool sticksAlive = true;
        while (sticksAlive)
        {
            sticksAlive = false;
            int countAlive = 0;
            int min = GetMin(sticks);
            if (min != -1)
            {
                for (int i = 0; i < sticks.Length; i++)
                {
                    if ((!sticksAlive) && (sticks[i] > 0))
                    {
                        sticksAlive = true;
                    }
                    if (sticks[i] > 0)
                    {
                        if (sticks[i] == 1)
                            sticks[i] = 0;
                        else
                            sticks[i] -= min;
                        countAlive++;
                    }
                }
                if (countAlive > 0)
                {
                    Console.WriteLine(countAlive);
                }
            }
        }
    }
}