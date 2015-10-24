using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Solution
{
    static void Main(string[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        while(testNumber-->0)
        {
            long[] giftsCount = Console.ReadLine().Split(' ').Select(x => Convert.ToInt64(x)).ToArray();
            long[] costs = Console.ReadLine().Split(' ').Select(x => Convert.ToInt64(x)).ToArray();
            if (costs[0] > costs[1] + costs[2])
            {
                Console.WriteLine(costs[1] * giftsCount[1] + (costs[1] + costs[2]) * giftsCount[0]);
            }
            else
            {
                if (costs[1] > costs[0] + costs[2])
                {
                    Console.WriteLine(costs[0] * giftsCount[0] + (costs[0] + costs[2]) * giftsCount[1]);
                }
                else
                {
                    Console.WriteLine(costs[1] * giftsCount[1] + costs[0] * giftsCount[0]);
                }
            }

        }
    }
}

