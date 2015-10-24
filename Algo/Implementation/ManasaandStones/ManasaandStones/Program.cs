using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Solution
{
    static void Main(string[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        while(testNumber-->0)
        {
            int n = int.Parse(Console.ReadLine());
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int sum = (n-1) * a;
            List<int> sums = new List<int>();
            while (sum!=(n-1)*b)
            {
                if(!sums.Contains(sum))
                {
                    sums.Add(sum);
                }
                sum -= a;
                sum += b;
            }
            if (!sums.Contains(sum))
            {
                sums.Add(sum);
            }
            sums.Sort();
            foreach(int s in sums)
            {
                Console.Write(s.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}
