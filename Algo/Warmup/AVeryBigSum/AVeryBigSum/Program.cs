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
        long[] numbers = Console.ReadLine().Split(' ').Select(x=> Convert.ToInt64(x)).ToArray();
        Console.WriteLine(numbers.Sum());
    }
}