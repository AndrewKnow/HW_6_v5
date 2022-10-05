using System;

namespace AnonTypes
{
    class Program1
    {
        static void Main(string[] args)
        {
            SolarSystem();
        }

        public static void SolarSystem()
        {
            var venusOne = new
            {
                serialNumber = 2,
                equatorLength = 38025,
                previousPlanet = string.Empty
            };

            var earth = new
            {
                serialNumber = 3,
                equatorLength = 40075,
                previousPlanet = venusOne
            };

            var mars = new
            {
                serialNumber = 4,
                equatorLength = 21344,
                previousPlanet = earth
            };

            var venusTwo = new
            {
                serialNumber = 2,
                equatorLength = 38025,
                previousPlanet = string.Empty
            };

            Console.WriteLine("Венера: " + venusOne + " эквивалентна ли Венере: " + venusOne.Equals(venusOne));
            Console.WriteLine("Земля: " + earth + " эквивалентна ли Венере: " + earth.Equals(venusOne));
            Console.WriteLine("Марс: " + mars + " эквивалентна ли Венере: " + mars.Equals(venusOne));
            Console.WriteLine("Венера: " + venusTwo + " эквивалентна ли Венере: " + venusTwo.Equals(venusOne));
        }
    }
}
