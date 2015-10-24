using System;

class Solution
{
    private static int GetDifference(char first, char second)
    {
        if (first >= second)
        {
            return (int)first - second;
        }
        else
        {
            return (int)second - first;
        }
    }
    static void Main(string[] args)
    {
        var testNumber = int.Parse(Console.ReadLine());
        while (testNumber-- > 0)
        {
            string funnyString = Console.ReadLine();
            bool isFunny = true;
            for (var charIndex = 0; charIndex < funnyString.Length / 2 && isFunny; charIndex++)
            {
                isFunny = GetDifference(funnyString[charIndex], funnyString[charIndex + 1]) ==
                          GetDifference(funnyString[funnyString.Length - 1 - charIndex],
                              funnyString[funnyString.Length - 2 - charIndex]);
            }
            Console.WriteLine(isFunny ? "Funny" : "Not Funny");
        }
    }
}