using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Solution
{
    static void Main(string[] args)
    {
        int[] restrictions = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        int rows = restrictions[0];
        int columns = restrictions[1];
        int rotationTimes = (int)restrictions[2];
        List<long[]> matrix = new List<long[]>();
        while (restrictions[0]-- > 0)
        {
            matrix.Add(Console.ReadLine().Split(' ').Select(x => Convert.ToInt64(x)).ToArray());
        }

        List<List<long>> layersList = new List<List<long>>();

        int min = Math.Min(rows, columns);
        for (int i = 0; i < min / 2; i++)
        {
            List<long> layerList = new List<long>();
            for (int j = i; j < rows - i; j++)
            {
                layerList.Add(matrix[j][i]);
            }
            for (int j = i + 1; j < columns - i; j++)
            {
                layerList.Add(matrix[rows - i - 1][j]);
            }
            for (int j = rows - i - 2; j > i - 1; j--)
            {
                layerList.Add(matrix[j][columns - i - 1]);
            }
            for (int j = columns - i - 2; j > i ; j--)
            {
                layerList.Add(matrix[i][j]);
            }

            int index = layerList.Count - rotationTimes%layerList.Count;

            for (int j = i; j < rows - i; j++)
            {
                if (index < layerList.Count)
                {
                    matrix[j][i] = layerList[index];
                    index++;
                }
                else
                {
                    index = 0;
                    matrix[j][i] = layerList[index];
                    index++;
                }
            }
            for (int j = i + 1; j < columns - i; j++)
            {

                if (index < layerList.Count)
                {
                    matrix[rows - i - 1][j] = layerList[index];
                    index++;
                }
                else
                {
                    index = 0;
                    matrix[rows - i - 1][j] = layerList[index];
                    index++;
                }
            }
            for (int j = rows - i - 2; j > i - 1; j--)
            {

                if (index < layerList.Count)
                {
                    matrix[j][columns - i - 1] = layerList[index];
                    index++;
                }
                else
                {
                    index = 0;
                    matrix[j][columns - i - 1] = layerList[index];
                    index++;
                }

            }
            for (int j = columns - i - 2; j > i ; j--)
            {
                if (index < layerList.Count)
                {
                    matrix[i][j] = layerList[index];
                    index++;
                }
                else
                {
                    index = 0;
                    matrix[i][j] = layerList[index];
                    index++;
                }
            }
        }

        foreach(long[] row in matrix)
        {
            for(int i=0;i<row.Length;i++)
            {
                Console.Write(row[i] + " ");
            }
            Console.WriteLine();
        }


    }
}

