using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    const int EARTH_RADIUS = 6371;
    const double PI = 3.14159265359;
    struct Point
    {
        public double latitude, longitude;
    }

    static double DegreeToRadians(double degrees)
    {
        return (PI / 180.0) * degrees;
    }
    static double GetDistance(Point startPoint, Point finishPoint)
    {
        double startPointLatitude = DegreeToRadians(startPoint.latitude);
        double startPointLongitude = DegreeToRadians(startPoint.longitude);
        double finishPointLatitude = DegreeToRadians(finishPoint.latitude);
        double finishPointLongitude = DegreeToRadians(finishPoint.longitude);

        return Math.Round(Math.Acos(
            Math.Sin(startPointLatitude) * Math.Sin(finishPointLatitude) +
            Math.Cos(startPointLatitude) * Math.Cos(finishPointLatitude) *
            Math.Cos(finishPointLongitude - startPointLongitude)
            ) * EARTH_RADIUS, 2);
    }

    struct Attraction
    {
        public Point position;
        public int id;
        public double distance;
    }

    static double GetSpeed(string transport)
    {
        switch (transport)
        {
            case "metro":
                return 20.0;
            case "bike":
                return 15.0;
            case "foot":
                return 5.0;
            default:
                return 0.0;
        }
    }

    static void Main(string[] args)
    {
        int numberOfAttractions = int.Parse(Console.ReadLine());
        List<Attraction> attractions = new List<Attraction>();
        for (int attractionNumber = 0; attractionNumber < numberOfAttractions; attractionNumber++)
        {
            string[] attractionInput = Console.ReadLine().Split(' ');
            Attraction attraction = new Attraction();
            attraction.id = int.Parse(attractionInput[0]);
            attraction.position.latitude = double.Parse(attractionInput[1], CultureInfo.InvariantCulture);
            attraction.position.longitude = double.Parse(attractionInput[2], CultureInfo.InvariantCulture);
            attractions.Add(attraction);
        }

        int testNumber = int.Parse(Console.ReadLine());
        while (testNumber-- > 0)
        {
            Point travelerPosition = new Point();
            string[] restrictions = Console.ReadLine().Split(' ');
            travelerPosition.latitude = double.Parse(restrictions[0], CultureInfo.InvariantCulture);
            travelerPosition.longitude = double.Parse(restrictions[1], CultureInfo.InvariantCulture);
            double speed = GetSpeed(restrictions[2]);
            double minutes = double.Parse(restrictions[3]);
            List<Attraction> goodAttractions = new List<Attraction>();
            for (int i = 0; i < attractions.Count; i++)
            {
                Attraction attr = attractions[i];
                attr.distance = GetDistance(travelerPosition, attr.position);
                if (attr.distance / speed * 60.0 <= minutes)
                {
                    goodAttractions.Add(attr);
                }
            }

            for (int i = 0; i < goodAttractions.Count - 1; i++)
            {
                for (int j = i + 1; j < goodAttractions.Count; j++)
                {

                    if (goodAttractions[i].distance > goodAttractions[j].distance)
                    {
                        Attraction tmp = goodAttractions[i];
                        goodAttractions[i] = goodAttractions[j];
                        goodAttractions[j] = tmp;
                    }

                }
            }
            for (int i = 0; i < goodAttractions.Count - 1; i++)
            {
                for (int j = i + 1; j < goodAttractions.Count; j++)
                {
                    if (goodAttractions[i].distance == goodAttractions[j].distance)
                    {
                        if (goodAttractions[i].id > goodAttractions[j].id)
                        {
                            Attraction tmp = goodAttractions[i];
                            goodAttractions[i] = goodAttractions[j];
                            goodAttractions[j] = tmp;
                        }
                    }
                }
            }

            foreach(Attraction attr in goodAttractions)
            {
                Console.Write(attr.id+" ");
            }
            Console.WriteLine();
        }
    }
}

