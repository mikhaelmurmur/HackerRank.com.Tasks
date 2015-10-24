using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Solution
{
    class Node
    {
        public Node connectedTo;
        public int prob;
        public int number;
        public bool isChecked;
    }


    static double GetProbabilityInCycle(List<Node> cities, int cityNumber, int startIndex)
    {
        cities[cityNumber].isChecked = true;
        if (!cities[cityNumber].connectedTo.isChecked)
        {
            double result = cities[cityNumber].prob * GetProbabilityInCycle(cities, cities[cityNumber].connectedTo.number, startIndex);
            if (result > 0)
            {
                return result/100.0;
            }
            else
            {
                cities[cityNumber].isChecked = false;
                return 0;
            }
        }
        else
        {
            if (cities[cityNumber].connectedTo.number == startIndex)
                return cities[cityNumber].prob;
            else
            {
                cities[cityNumber].isChecked = false;
                return 0.0;
            }
        }
    }

    static void Main(string[] args)
    {
        int numberOfCities = int.Parse(Console.ReadLine());
        List<Node> cities = new List<Node>();
        for (int cityIndex = 0; cityIndex < numberOfCities; cityIndex++)
        {
            Node city = new Node();
            city.number = cityIndex;
            city.isChecked = false;
            cities.Add(city);
        }
        for (int cityIndex = 0; cityIndex < numberOfCities; cityIndex++)
        {
            int[] restrictions = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            cities[cityIndex].connectedTo = cities[restrictions[0] - 1];
            cities[cityIndex].prob = restrictions[1] ;
        }
        List<double> probabilities = new List<double>();
        for (int cityIndex = 0; cityIndex < numberOfCities; cityIndex++)
        {
            if (!cities[cityIndex].isChecked)
            {
                double probability = GetProbabilityInCycle(cities, cityIndex, cityIndex);
                probabilities.Add(probability);
            }
        }

        if (probabilities.Count > 0)
            Console.WriteLine(Math.Round(probabilities.Sum()/100.0, 2).ToString("F", System.Globalization.CultureInfo.InvariantCulture));
        else
            Console.WriteLine("0.00");
    }
}
