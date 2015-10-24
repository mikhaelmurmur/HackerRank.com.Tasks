using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    static void DepthSearch(int[] bridges, bool[] bridgesGot, int bridgeNumber)
    {
        while (!bridgesGot[bridgeNumber])
        {
            bridgesGot[bridgeNumber] = true;
            bridgeNumber = bridges[bridgeNumber]-1;
        }
    }

    static void Main(string[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        while (testNumber-- > 0)
        {
            Console.ReadLine();
            int[] bridges = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int bridgeIndex = 0;
            bool[] bridgesGot = new bool[bridges.Length];
            int numberOfIslands = 0;
            while (bridgeIndex < bridges.Length)
            {
                if (!bridgesGot[bridgeIndex])
                {
                    DepthSearch(bridges, bridgesGot, bridgeIndex);
                    numberOfIslands++;
                }
                bridgeIndex++;
            }
            Console.WriteLine(numberOfIslands-1);
        }
    }
}

