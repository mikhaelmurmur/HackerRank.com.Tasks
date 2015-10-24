using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        Console.WriteLine(DateTime.Parse(Console.ReadLine()).ToString().Substring(11, 8));
    }
}