using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Solution
{
    static void Main(string[] args)
    {
        string plainText = Console.ReadLine();
        int len = plainText.Length;
        int rows =(int) Math.Floor(Math.Sqrt(len));
        int columns = (int)Math.Ceiling(Math.Sqrt(len));
        List<string> textGrid = new List<string>();
        if(rows*columns<len)
        {
            rows ++;
        }
        for(int row=0;row<rows-1;row++)
        {
            textGrid.Add(plainText.Substring(row * columns, columns));
        }
        textGrid.Add(plainText.Substring((rows - 1) * columns));

        //foreach(string s in textGrid)
        //{
        //    Console.WriteLine(s);
        //}

        for (int column =0;column<columns;column++)
        {
            for(int row=0;row<rows;row++)
            {
                if (column < textGrid[row].Length) 
                    Console.Write(textGrid[row][column]);
            }
            Console.Write(" ");
        }
    }
}

