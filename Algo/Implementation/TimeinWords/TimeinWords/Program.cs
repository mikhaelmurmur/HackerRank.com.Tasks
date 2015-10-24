using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Solution
{
    static string IntToString(int number)
    {
        switch (number)
        {
            case 0:
                return "midnight";
                break;
            case 1:

                return "one";
                break;
            case 2:
                return "two";
                break;
            case 3:
                return "three";
                break;
            case 4:
                return "four";
                break;
            case 5:

                return "five";
                break;
            case 6:
                return "six";
                break;
            case 7:
                return "seven";
                break;
            case 8:
                return "eight";
                break;
            case 9:
                return "nine";
                break;
            case 10:
                return "ten";
                break;
            case 11:
                return "eleven";
                break;
            case 12:
                return "twelve";
                break;
            case 13:
                return "thirteen";
                break;
            case 14:
                return "fourteen";
                break;
            case 16:
                return "sixteen";
                break;
            case 17:
                return "seventeen";
                break;
            case 18:
                return "eightteen";
                break;
            case 19:
                return "nineteen";
                break;
            case 20:
                return "twenty";
                break;
            case 21:
                return "twenty one";
                break;
            case 22:
                return "twenty two";
                break;
            case 23:
                return "twenty three";
                break;
            case 24:
                return "twentu four";
                break;
            case 25:
                return "twenty five";
                break;
            case 26:
                return "twenty six";
                break;
            case 27:
                return "twenty seven";
                break;
            case 28:
                return "twenty eight";
                break;
            case 29:
                return "twenty nine";
                break;
        }
        return "0";
    }
    static void Main(string[] args)
    {
        int hours = int.Parse(Console.ReadLine());
        int minutes = int.Parse(Console.ReadLine());
        if (minutes == 0)
        {
            Console.WriteLine(IntToString(hours) + " o' clock");
        }
        else
        {
            if (minutes == 30)
            {
                Console.Write("half past ");
                if (hours > 0)
                {
                    Console.WriteLine(IntToString(hours ));
                }
                else
                {
                    Console.WriteLine(IntToString(12));
                }
            }
            else
            {
                if (minutes < 30)
                {
                    if (minutes == 15)
                    {
                        Console.WriteLine("quarter past " + IntToString(hours));
                    }
                    else
                    {
                        if (minutes == 1)
                        {
                            Console.WriteLine("one minute past " + IntToString(hours));
                        }
                        else
                        {
                            Console.WriteLine(IntToString(minutes) + " minutes past " + IntToString(hours));
                        }
                    }
                }
                else
                {
                    minutes = 60 - minutes;
                    if (hours == 12)
                    {
                        hours = 0;
                    }
                    if (minutes == 15)
                    {
                        Console.WriteLine("quarter to " + IntToString(hours + 1));
                    }
                    else
                    {
                        Console.WriteLine(IntToString(minutes) + " minutes to " + IntToString(hours + 1));
                    }

                }
            }
        }
    }
}

