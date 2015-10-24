using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        string n = Console.ReadLine();

        int[] numbers = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        int pos, neg;
        pos = neg = 0;
        foreach (int number in numbers)
        {
            if (number > 0)
                pos++;
            if (number < 0)
                neg++;
        }

        Console.WriteLine(Math.Round(((float)pos / (float)numbers.Length), 3));
        Console.WriteLine(Math.Round(((float)neg / (float)numbers.Length), 3));
        Console.WriteLine(Math.Round(((float)(numbers.Length-pos-neg) / (float)numbers.Length), 3));
    }
}