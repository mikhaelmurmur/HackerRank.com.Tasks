using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        while (testNumber-- > 0)
        {
            string plainLetter = Console.ReadLine();
            int difference = 0;
            for (int letterIndex = 0; letterIndex < plainLetter.Length / 2; letterIndex++)
            {
                difference +=
                    Math.Abs((int)plainLetter[letterIndex] - (int)plainLetter[plainLetter.Length - 1 - letterIndex]);
            }
            Console.WriteLine(difference);
        }
    }
}