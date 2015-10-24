using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        for(int testIndex =0;testIndex < testNumber;testIndex++)
        {
            int cycleNumber = int.Parse(Console.ReadLine());
            int height = 1;
            bool isSpring = true;
            while(cycleNumber>0)
            {
                if(isSpring)
                {
                    height *= 2;
                }
                else
                {
                    height += 1;
                }
                isSpring = !isSpring;
                cycleNumber--;
            }
            Console.WriteLine(height);
        }
    }
}