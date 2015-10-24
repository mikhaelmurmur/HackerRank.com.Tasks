using System;
using System.Numerics;
class Solution
{
    static void Main(String[] args)
    {
        BigInteger number = new BigInteger(1);
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            number = BigInteger.Multiply(number, new BigInteger(i + 1));
        }
        Console.WriteLine(number.ToString());
    }
}
