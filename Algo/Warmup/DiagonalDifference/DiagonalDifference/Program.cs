using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n = Convert.ToInt32(Console.ReadLine());
        List<int[]> matrix = new List<int[]>();
        for(int i = 0;i < n;i++)
            matrix.Add(Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray());
        int sum = 0;
        int index = 0;
        foreach (int[] line in matrix)
        {
            sum += line[index];
            sum -= line[line.Length - index - 1];
            index++;
        }
        Console.WriteLine(Math.Abs(sum));
    }
}