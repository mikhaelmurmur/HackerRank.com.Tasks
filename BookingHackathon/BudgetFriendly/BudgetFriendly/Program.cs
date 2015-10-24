using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    struct Hotel
    {
        public int cost;
        public double rating;
    }

    struct City
    {
        public List<Hotel> hotels;
        public int currentHotel;
    }
    
    static public double max;
    static List<City> cities = new List<City>();


    static int MyPartition(List<Hotel> list, int left, int right)
    {
        int pivot = list[left].cost;

        while (true)
        {
            while (list[left].cost < pivot)
                left++;

            while (list[right].cost > pivot)
                right--;

            if (list[right].cost == pivot && list[left].cost == pivot)
                left++;

            if (left < right)
            {
                Hotel temp = list[left];
                list[left] = list[right];
                list[right] = temp;
            }
            else
            {
                return right;
            }
        }
    }

    static void MyQuickSort(List<Hotel> list, int left, int right)
    {
        if (list == null || list.Count <= 1)
            return;

        if (left < right)
        {
            int pivotIdx = MyPartition(list, left, right);

            if (pivotIdx > 1)
                MyQuickSort(list, left, pivotIdx - 1);

            if (pivotIdx + 1 < right)
                MyQuickSort(list, pivotIdx + 1, right);
        }
    }



    static void SetRatings(int number, int money, double rating)
    {
        if (number < cities.Count)
        {
            City city = cities[number];
            foreach (Hotel hotel in city.hotels)
            {
                if ((money >= hotel.cost) && (number == cities.Count - 1))
                {
                    if (max < rating + hotel.rating)
                    {
                        max = rating + hotel.rating;
                    }

                }
                else
                {
                    if (money > hotel.cost)
                    {
                        SetRatings(number + 1, money - hotel.cost, rating + hotel.rating);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        else
        {
            if (rating > max)
            {
                max = rating;
            }
        }
    }

    

    static void Main(string[] args)
    {
        int[] restrictions = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        int cityNumber = restrictions[0];
        int money = restrictions[1];
        while (cityNumber-- > 0)
        {
            City city = new City();
            city.currentHotel = 0;
            city.hotels = new List<Hotel>();
            int hotelsNumber = int.Parse(Console.ReadLine());
            while (hotelsNumber-- > 0)
            {
                Hotel hotel = new Hotel();
                string[] hotelParametrs = Console.ReadLine().Split(' ');
                hotel.cost = int.Parse(hotelParametrs[0]);
                hotel.rating = double.Parse(hotelParametrs[1], CultureInfo.InvariantCulture);
                city.hotels.Add(hotel);
            }
            MyQuickSort(city.hotels, 0, city.hotels.Count - 1);
            cities.Add(city);
        }
        max = -1;
        SetRatings( 0, money, 0.0);
        if (max==-1)
        {
            Console.WriteLine(-1);
        }
        else
        {
            string str = Math.Round(max, 2).ToString();
            str = str.Replace(',', '.');
            Console.WriteLine(str);
        }
    }
}

