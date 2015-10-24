using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    static HashSet<char> alphabet = new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
        'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v','w','x','y','z' };
    static void Main(string[] args)
    {
        int rockNumber = int.Parse(Console.ReadLine());
        List<string> rocks = new List<string>();
        
        while (rockNumber-- > 0)
        {
            rocks.Add(Console.ReadLine());
        }
        int gemNumber = alphabet.Select(letter => rocks.All(rock => rock.Contains(letter))).Count(isGem => isGem);
        Console.WriteLine(gemNumber);
    }
}