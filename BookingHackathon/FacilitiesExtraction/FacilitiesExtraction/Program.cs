using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    static void Main(string[] args)
    {
        int facilitiesNumber = int.Parse(Console.ReadLine());
        List<string> facilities = new List<string>();
        while (facilitiesNumber-->0)
        {
            facilities.Add(Console.ReadLine());
        }
        string text = Console.ReadLine();
        facilities.Sort(StringComparer.Ordinal);
        foreach(string facility in facilities)
        {
            int index = text.IndexOf(facility, StringComparison.CurrentCultureIgnoreCase);
            if(index!=-1)
            {
                Console.WriteLine(facility);
            }
        }
    }
}

