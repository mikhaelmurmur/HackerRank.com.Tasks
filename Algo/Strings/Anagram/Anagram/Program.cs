using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    static readonly HashSet<char> Alphabet = new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
        'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v','w','x','y','z' };
    private static void Main(string[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        while (testNumber-- > 0)
        {
            string anagram = Console.ReadLine();
            if (anagram.Length % 2 == 1)
            {
                Console.WriteLine(-1);
            }
            else
            {
                string firstWord = anagram.Substring(0, anagram.Length / 2);
                string secondWord = anagram.Substring(anagram.Length / 2, anagram.Length / 2);
                int difference = Alphabet.Sum(letter => Math.Abs(firstWord.Count(x => x == letter) - secondWord.Count(x => x == letter))) / 2;
                Console.WriteLine(difference);
            }

        }
    }
}
