using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    public struct City
    {
        public string name;
        public HashSet<string> tags;
    }

    static bool IsGroupTagsUnique(List<CityPack> cities, HashSet<string> tags)
    {
        foreach (CityPack pack in cities)
        {
            if (tags.IsSubsetOf(pack.cities) && !tags.IsProperSubsetOf(pack.cities))
            {
                return false;
            }
        }
        return true;
    }

    static void RemoveSame(List<CityPack> cities)
    {
        List<CityPack> toRemove = new List<CityPack>();
        for (int i = 0; i < cities.Count - 1; i++)
        {
            for (int j = i + 1; j < cities.Count; j++)
            {
                if (cities[i].tags.IsSubsetOf(cities[j].tags) && !cities[i].tags.IsProperSubsetOf(cities[j].tags))
                {
                    cities[i].cities.UnionWith(cities[j].cities);
                    toRemove.Add(cities[j]);
                }
            }
        }
        foreach (CityPack s in toRemove)
        {
            cities.Remove(s);
        }
    }

    static List<CityPack> DoIntersection(List<CityPack> cities, int groupSize)
    {
        List<CityPack> answer = new List<CityPack>(cities);
        for (int i = 0; i < cities.Count - 1; i++)
        {
            for (int j = i + 1; j < cities.Count; j++)
            {
                CityPack cityPack = new CityPack();
                cityPack.tags = new HashSet<string>(cities[i].tags);
                cityPack.tags.IntersectWith(cities[j].tags);
                cityPack.cities = new HashSet<string>(cities[i].cities);
                cityPack.cities.UnionWith(cities[j].cities);
                if ((cityPack.tags.Count >= groupSize) && (IsGroupTagsUnique(cities, cityPack.cities)))
                {
                    answer.Add(cityPack);
                }
            }
        }
        return answer;
    }

    struct CityPack
    {
        public HashSet<string> cities;
        public HashSet<string> tags;
    }

    static void Main(string[] args)
    {
        List<City> cities = new List<City>();
        string line = Console.ReadLine();
        int groupSize = int.Parse(line);
        while ((line = Console.ReadLine()) != null && line != "")
        {
            City city = new City();
            city.name = line.Substring(0, line.IndexOf(":"));
            city.tags = new HashSet<string>(line.Substring(line.IndexOf(":") + 1).Split(','));
            cities.Add(city);
        }
        List<CityPack> answer = new List<CityPack>();
        for (int i = 0; i < cities.Count - 1; i++)
        {
            for (int j = i + 1; j < cities.Count; j++)
            {
                CityPack cityPack = new CityPack();
                cityPack.tags = new HashSet<string>(cities[i].tags);
                cityPack.tags.IntersectWith(cities[j].tags);
                if (cityPack.tags.Count >= groupSize)
                {
                    cityPack.cities = new HashSet<string>();
                    cityPack.cities.Add(cities[i].name);
                    cityPack.cities.Add(cities[j].name);
                    answer.Add(cityPack);
                }
            }
        }
        int length = answer.Count;
        answer = DoIntersection(answer, groupSize);
        RemoveSame(answer);
        int newLength = answer.Count;
        while (length < newLength)
        {
            length = newLength;
            answer = DoIntersection(answer, groupSize);
            RemoveSame(answer);
            newLength = answer.Count;
        }
        for (int i = 0; i < answer.Count - 1; i++)
        {
            for (int j = i + 1; j < answer.Count; j++)
            {
                if (answer[i].tags.Count < answer[j].tags.Count)
                {
                    CityPack tmp = answer[i];
                    answer[i] = answer[j];
                    answer[j] = tmp;
                }
            }
        }
        for (int i = 0; i < answer.Count - 1; i++)
        {
            for (int j = i + 1; j < answer.Count; j++)
            {
                if (answer[i].tags.Count == answer[j].tags.Count)
                {
                    List<string> arr1 = new List<string>(answer[i].cities.ToArray());
                    List<string> arr2 = new List<string>(answer[j].cities.ToArray());
                    arr1.Sort();
                    arr2.Sort();
                    int k = 0;
                    while (k < arr1.Count() && (k < arr2.Count() && (string.Compare(arr1[k], arr2[k]) <= 0)))
                    {
                        k++;
                    }

                    if ((k < arr2.Count) || (k < arr1.Count))
                    {
                        if (k < arr2.Count && k > arr1.Count)
                        {
                            CityPack tmp = answer[i];
                            answer[i] = answer[j];
                            answer[j] = tmp;
                        }
                        else
                        {
                            if (k < arr1.Count() && k < arr2.Count)
                            {
                                if (string.Compare(arr1[k], arr2[k]) > 0)
                                {
                                    CityPack tmp = answer[i];
                                    answer[i] = answer[j];
                                    answer[j] = tmp;
                                }
                            }
                        }
                    }
                }
            }
        }
        foreach (CityPack city in answer)
        {
            List<string> lst = new List<string>(city.cities);
            lst.Sort();
            for (int i = 0; i < lst.Count - 1; i++)
            {
                Console.Write(lst[i] + ",");
            }
            Console.Write(lst[lst.Count - 1] + ":");
            List<string> lst1 = new List<string>(city.tags);
            lst1.Sort();
            for (int i = 0; i < lst1.Count - 1; i++)
            {
                Console.Write(lst1[i] + ",");
            }
            Console.WriteLine(lst1[lst1.Count - 1]);
        }

    }
}

