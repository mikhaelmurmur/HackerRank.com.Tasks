using System;
using System.Collections.Generic;

class Solution
{
    static HashSet<char> alphabet = new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
        'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v','w','x','y','z' };
    static void Main(string[] args)
    {
        string pangram = Console.ReadLine().ToLower();
        foreach (char letter in pangram)
        {
            alphabet.Remove(letter);
        }
        Console.WriteLine(alphabet.Count == 0 ? "pangram" : "not pangram");
    }
}