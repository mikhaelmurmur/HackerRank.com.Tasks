using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        Dictionary<char, int> alphabet = new Dictionary<char, int>();
        string key = Console.ReadLine();
        foreach (char letter in key)
        {
            if (!alphabet.ContainsKey(letter))
            {
                alphabet.Add(letter, 0);
            }
            alphabet[letter]++;
        }
        int oddNumber = alphabet.Count(pair => pair.Value % 2 == 1);
        Console.WriteLine(oddNumber > 1 ? "NO" : "YES");
    }
}