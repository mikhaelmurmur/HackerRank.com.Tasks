using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        Console.ReadLine();
        string plaintext = Console.ReadLine();
        int k = int.Parse(Console.ReadLine());
        string ciphettext = "";
        foreach(char plainchar in plaintext)
        {
            if((plainchar>='a')&&(plainchar<='z'))
            {
                char cipherChar = plainchar;
                cipherChar = (char)((int)cipherChar+k);
                while(cipherChar>'z')
                {
                    cipherChar = (char)((int)(cipherChar)-26);
                }
                ciphettext += cipherChar;
            }
            else
            {
                if ((plainchar >= 'A') && (plainchar <= 'Z'))
                {
                    char cipherChar = plainchar;
                    cipherChar = (char)((int)cipherChar + k);
                    while (cipherChar > 'Z')
                    {
                        cipherChar = (char)((int)(cipherChar) - 26);
                    }
                    ciphettext += cipherChar;
                }
                else
                {
                    ciphettext += plainchar;
                }
            }
        }
        Console.WriteLine(ciphettext);
    }
}