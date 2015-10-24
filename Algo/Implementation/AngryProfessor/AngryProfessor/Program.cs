using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        for(int testIndex = 0;testIndex<testNumber;testIndex++)
        {
            int[] requirements = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int goodStudentsCount = 0;
            int[] studentsArrival = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            foreach(int arrival in studentsArrival)
            {
                if(arrival<=0)
                {
                    goodStudentsCount++;
                }
            }
            if (goodStudentsCount >= requirements[1])
                Console.WriteLine("NO");
            else
                Console.WriteLine("YES");
        }
    }
}