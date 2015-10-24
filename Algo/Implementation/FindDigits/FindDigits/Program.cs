using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        while (testNumber != 0)
        {
            int n = int.Parse(Console.ReadLine());
            int n_start = n;
            int count = 0;
            while (n > 0)
            {
                if ((n % 10) != 0)
                    if (n_start % (n % 10) == 0)
                    {
                        count++;
                    }
                n /= 10;
            }
            Console.WriteLine(count);
            testNumber--;
        }
    }
}