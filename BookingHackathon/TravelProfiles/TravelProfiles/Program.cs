using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Solution
{
    struct Hotel
    {
        public List<string> facilities;
        public int id;
        public int cost;
    }
    static void Main(string[] args)
    {
        int hotelNumber = int.Parse(Console.ReadLine());
        List<Hotel> hotels = new List<Hotel>();
        while (hotelNumber-- > 0)
        {
            string[] hotelRestrictions = Console.ReadLine().Split(' ');
            Hotel hotel = new Hotel();
            hotel.facilities = new List<string>();
            hotel.id = int.Parse(hotelRestrictions[0]);
            hotel.cost = int.Parse(hotelRestrictions[1]);
            for (int i = 2; i < hotelRestrictions.Length; i++)
            {
                hotel.facilities.Add(hotelRestrictions[i]);
            }
            hotels.Add(hotel);
        }
        int testNumber = int.Parse(Console.ReadLine());
        while (testNumber-- > 0)
        {
            string[] clientInput = Console.ReadLine().Split(' ');
            int clientCost = int.Parse(clientInput[0]);
            List<string> clientFacilities = new List<string>();
            for (int i = 1; i < clientInput.Length; i++)
            {
                clientFacilities.Add(clientInput[i]);
            }
            List<Hotel> goodHotels = new List<Hotel>();
            foreach (Hotel hotel in hotels)
            {
                if (clientCost >= hotel.cost)
                {
                    bool isGood = true;
                    foreach (string facility in clientFacilities)
                    {
                        if (!hotel.facilities.Contains(facility))
                        {
                            isGood = false;
                            break;
                        }
                    }
                    if (isGood)
                    {
                        goodHotels.Add(hotel);
                    }
                }
            }

            for (int i = 0; i < goodHotels.Count - 1; i++)
            {
                for (int j = i + 1; j < goodHotels.Count; j++)
                {
                    if (goodHotels[i].facilities.Count < goodHotels[j].facilities.Count)
                    {
                        Hotel tmp = goodHotels[i];
                        goodHotels[i] = goodHotels[j];
                        goodHotels[j] = tmp;
                    }
                }
            }
            for (int i = 0; i < goodHotels.Count - 1; i++)
            {
                for (int j = i + 1; j < goodHotels.Count; j++)
                {
                    if (goodHotels[i].facilities.Count == goodHotels[j].facilities.Count)
                    {
                        if (goodHotels[i].cost > goodHotels[j].cost)
                        {
                            Hotel tmp = goodHotels[i];
                            goodHotels[i] = goodHotels[j];
                            goodHotels[j] = tmp;
                        }
                    }
                }
            }

            for (int i = 0; i < goodHotels.Count - 1; i++)
            {
                for (int j = i + 1; j < goodHotels.Count; j++)
                {
                    if (goodHotels[i].facilities.Count == goodHotels[j].facilities.Count)
                    {
                        if (goodHotels[i].cost == goodHotels[j].cost)
                        {
                            if (goodHotels[i].id > goodHotels[j].id)
                            {
                                Hotel tmp = goodHotels[i];
                                goodHotels[i] = goodHotels[j];
                                goodHotels[j] = tmp;
                            }
                        }
                    }
                }
            }

            foreach(Hotel hotel in goodHotels)
            {
                Console.Write(hotel.id + " ");
            }
            Console.WriteLine();
        }
    }
}
