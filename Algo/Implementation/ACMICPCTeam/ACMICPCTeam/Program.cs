
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{

    static int GetORWeight(string first, string second)
    {
        int countOfOnes = 0;
        for(int i=0;i<first.Length;i++)
        {
            if((first[i]=='1')||(second[i]=='1'))
            {
                countOfOnes++;
            }
        }
        return countOfOnes;
    }
    static void Main(string[] args)
    {
        int[] restrictions = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        List<string> participants = new List<string>();
        for (int participant = 0;participant<restrictions[0];participant++)
        {
            participants.Add(Console.ReadLine());
        }
        int max = 0;
        int maxCount = 0;
        for(int firstParticipant = 0;firstParticipant<restrictions[0]-1;firstParticipant++)
        {
            for(int secondParticipant = firstParticipant+1;secondParticipant<restrictions[0];secondParticipant++)
            {
                int weight = GetORWeight(participants[firstParticipant], participants[secondParticipant]);
                if(weight==max)
                {
                    maxCount++;
                }
                if (weight>max)
                {
                    max = weight;
                    maxCount = 1;
                }
            }
        }
        Console.WriteLine(max);
        Console.WriteLine(maxCount);
    }
}

