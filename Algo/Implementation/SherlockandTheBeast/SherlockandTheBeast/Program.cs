using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static int getPivot(int n)
    {
        while(n>0)
        {
            if(n%3==0)
            {
                break;
            }
            else
            {
                n -= 5;
            }
        }
        return n;
    }

    static void Main(String[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        for (int testIndex = 0; testIndex < testNumber; testIndex++)
        {
            int n = int.Parse(Console.ReadLine());
            int pivot = getPivot(n);
            if (pivot >= 0)
            {
                    for (int i = 0; i < pivot/3; i++)
                        Console.Write("555");
                    for (int i = 0; i < (n-pivot)/5; i++)
                        Console.Write("33333");
                    Console.WriteLine();
                
            }
            else
            {
                Console.WriteLine("-1");
            }
        }
    }
}