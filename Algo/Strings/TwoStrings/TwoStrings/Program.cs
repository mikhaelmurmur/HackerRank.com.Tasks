using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    static readonly HashSet<char> alphabet = new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
        'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v','w','x','y','z' };
    static void Main(string[] args)
    {
        int testNumber = int.Parse(Console.ReadLine());
        while (testNumber-- > 0)
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();
            bool isSubstringAvailable = alphabet.Any(letter => firstString.Contains(letter.ToString()) && secondString.Contains(letter.ToString()));
            Console.WriteLine(isSubstringAvailable ? "YES" : "NO");
        }
    }
}