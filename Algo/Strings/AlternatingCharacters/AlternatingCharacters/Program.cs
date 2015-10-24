using System;

class Solution
{
    static void Main(string[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        while (testNumber-- > 0)
        {
            string checkLine = Console.ReadLine();
            int deleteNumber = 0;
            for (int letterIndex = 1; letterIndex < checkLine.Length; letterIndex++)
            {
                if (checkLine[letterIndex] == checkLine[letterIndex - 1])
                {
                    deleteNumber++;
                }
            }
            Console.WriteLine(deleteNumber);
        }
    }
}