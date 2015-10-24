using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        while(testNumber-->0)
        {
            int[] restrictions = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int newCount = restrictions[0] / restrictions[1];
            int count = newCount;
            while (newCount>=restrictions[2])
            {
                int countTmp = newCount / restrictions[2];
                count += countTmp;
                newCount = countTmp + newCount % restrictions[2];
            }
            Console.WriteLine(count);
        }
    }
}
