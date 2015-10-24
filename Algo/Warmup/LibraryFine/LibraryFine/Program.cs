using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        int[] returnDate = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        int[] expectedDate = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        if(returnDate[2]==expectedDate[2])
        {
            if(returnDate[1]== expectedDate[1])
            {
                if(returnDate[0]==expectedDate[0])
                {
                    Console.WriteLine("0");
                }
                else
                {
                    if (returnDate[0] < expectedDate[0])
                    {
                        Console.WriteLine(0);
                    }
                    else
                        Console.WriteLine((returnDate[0] - expectedDate[0]) * 15);
                }
            }
            else
            {
                if (returnDate[1] < expectedDate[1])
                {
                    Console.WriteLine(0);
                }
                else
                    Console.WriteLine((returnDate[1]-expectedDate[1])*500);
            }
        }
        else
        {
            if(returnDate[2] < expectedDate[2])
            {
                Console.WriteLine(0);
            }
            else
                Console.WriteLine("10000");
        }
    }
}