using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Solution
{
    static void Main(string[] args)
    {
        long start = long.Parse(Console.ReadLine());
        long finish = long.Parse(Console.ReadLine());
        List<long> kaprekatNumbers = new List<long>();
        for (long i = start; i < finish + 1; i++)
        {
            long length = i.ToString().Length;
            long firstDigits = 0;
            long secondDigits = 0;

            if ((i * i).ToString().Length % 2 == 0)
            {
                firstDigits = (i * i) % (long)Math.Pow(10, length);

                secondDigits = (i * i) / (long)Math.Pow(10, (i * i).ToString().Length - length);
            }
            else
            {
                if ((i * i).ToString().Length != 1)
                {
                    if ((i * i).ToString().Length % 2 == 0)
                    {
                        firstDigits = (i * i) % (long)Math.Pow(10, (i * i).ToString().Length / 2);
                        secondDigits = (i * i) / (long)Math.Pow(10, (i * i).ToString().Length / 2);
                    }
                    else
                    {
                        firstDigits = (i * i) % (long)Math.Pow(10, (i * i).ToString().Length / 2 + 1);
                        secondDigits = (i * i) / (long)Math.Pow(10, (i * i).ToString().Length / 2 + 1);
                    }
                }
                else
                {
                    if (i == 1)
                        kaprekatNumbers.Add(i);
                }
            }
            if (secondDigits + firstDigits == i)
                kaprekatNumbers.Add(i);
        }
        if (kaprekatNumbers.Count != 0)
        {
            foreach (long i in kaprekatNumbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("INVALID RANGE");
        }
    }
}

