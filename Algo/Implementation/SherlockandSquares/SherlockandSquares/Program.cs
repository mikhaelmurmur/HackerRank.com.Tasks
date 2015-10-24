using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        while(testNumber>0)
        {
            int[] restrictions = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int lowSquare = (int)Math.Ceiling(Math.Sqrt(restrictions[0]));
            int highSquare = (int)Math.Floor(Math.Sqrt(restrictions[1]));
            Console.WriteLine(highSquare - lowSquare +1 );
            testNumber--;
        }
    }
}