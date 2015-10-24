using System;
using System.Text;

class Solution
{
    static void Main(string[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        while (testNumber-- > 0)
        {
            string smallString = Console.ReadLine();
            bool isProblem = true;
            for (int letterIndex = smallString.Length - 1; letterIndex > 0; letterIndex--)
            {
                if (smallString[letterIndex] > smallString[letterIndex - 1])
                {
                    StringBuilder biggerString = new StringBuilder(smallString);
                    int swapIndex = GetSwapIndex(letterIndex, biggerString);
                    Swap(smallString, letterIndex, biggerString, swapIndex);
                    StringBuilder resultString = GetPermutatedString(letterIndex, biggerString);
                    Console.WriteLine(resultString.ToString());
                    isProblem = false;
                    break;
                }
            }
            if (isProblem)
            {
                Console.WriteLine("no answer");
            }
        }
    }

    private static StringBuilder GetPermutatedString(int letterIndex, StringBuilder biggerString)
    {
        StringBuilder resultString = new StringBuilder();
        for (int i = 0; i < letterIndex; i++)
        {
            resultString.Append(biggerString[i]);
        }
        StringBuilder s = biggerString.Remove(0, letterIndex);
        for (int i = 0; i < s.Length; i++)
        {
            resultString.Append(s[s.Length - 1 - i]);
        }

        return resultString;
    }

    private static void Swap(string smallString, int letterIndex, StringBuilder biggerString, int swapIndex)
    {
        char tmp = smallString[swapIndex];
        biggerString[swapIndex] = biggerString[letterIndex - 1];
        biggerString[letterIndex - 1] = tmp;
    }

    private static int GetSwapIndex(int letterIndex, StringBuilder biggerString)
    {
        int swapIndex = letterIndex;
        for (int charIndex = 0; charIndex < biggerString.Length; charIndex++)
        {
            if (biggerString[letterIndex - 1] < biggerString[charIndex])
            {
                swapIndex = charIndex;
            }
        }

        return swapIndex;
    }
}