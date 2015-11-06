using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    static string Reverse(string text)
    {
        if (text == null) return null;
        char[] array = text.ToCharArray();
        Array.Reverse(array);
        return new String(array);
    }


    static void Main(string[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        while (testNumber-- > 0)
        {
            string inputValue = Console.ReadLine();
            if (string.Equals(inputValue, Reverse(inputValue)))
                Console.WriteLine(-1);
            else
            {
                int stringLength = inputValue.Length;
                string reversedString = Reverse(inputValue);
                for (int letterIndex = 0; letterIndex < stringLength; letterIndex++)
                {
                    if (reversedString[letterIndex] != inputValue[letterIndex])
                    {
                        if (letterIndex + 1 == stringLength)
                        {
                            Console.WriteLine(letterIndex);
                        }
                        if (string.Equals(inputValue.Remove(letterIndex, 1), reversedString.Remove(stringLength - 1 - letterIndex, 1)))
                            Console.WriteLine(letterIndex);
                        else
                        {
                            Console.WriteLine(stringLength - 1 - letterIndex);
                        }
                        break;
                    }
                }
            }
        }
    }
}