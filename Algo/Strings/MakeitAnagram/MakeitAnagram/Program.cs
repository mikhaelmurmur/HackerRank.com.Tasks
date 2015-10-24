using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    static HashSet<char> alphabet = new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
        'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v','w','x','y','z' };
    static void Main(string[] args)
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();
        int deleteNumber = (from letter in alphabet let firstIncludeNumber = first.Count(x => x == letter)
                            let secondIncludeNumber = second.Count(x => x == letter)
                            select Math.Abs(firstIncludeNumber - secondIncludeNumber)).Sum();
        Console.WriteLine(deleteNumber);
    }
}

