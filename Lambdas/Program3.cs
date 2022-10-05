using System;
using System.Collections.Generic;

namespace Lambdas
{
    class Program3
    {
        static void Main(string[] args)
        {
            var inputs = new List<string> { "Земля", "Лимония", "Марс" };

            var CallCount = 0;

            foreach (var input in inputs)
            {

                var getPlanet = PlanetСatalog.GetPlanet(input, (input) =>
                {
                    CallCount++;
                    if (CallCount == 3)
                    {
                        return true;
                    }
                    return false;
                });


                if (getPlanet.error != null)
                {
                    Console.WriteLine($"Название: {input}; Ошибка: {getPlanet.error}");
                }
                else
                {
                    Console.WriteLine($"Название: {input}; " +
                        $"Порядковый номер: {getPlanet.serialNumber}; " +
                        $"Длина экватор: {getPlanet.equatorLength}");
                }

            }


        }
    }


    class Planet
    {
        public string PlanetName { get; set; }
        public int SerialNumber { get; set; }
        public int EquatorLength { get; set; }
        public object PreviousPlanet { get; set; }

        public Planet(string planetName, int lastName, int equatorLength, object previousPlanet) //  , object previousPlanet
        {
            PlanetName = planetName;
            SerialNumber = lastName;
            EquatorLength = equatorLength;
            PreviousPlanet = previousPlanet;
        }

    }

    class PlanetСatalog
    {
        static List<Planet> planets = new()
        {
            new Planet("Венера", 2, 38025, null),
            new Planet("Земля", 3, 40075, new Planet("Венера", 2, 38025, null)),
            new Planet("Марс", 4, 21344, new Planet("Земля", 3, 40075, new Planet("Венера", 2, 38025, null)))
        };

        public delegate bool PlanetValidator(string item);

        public static (int serialNumber, int equatorLength, string error) GetPlanet(string namePlanet, PlanetValidator planetValidator)
        {

            foreach (var input in planets)
            {
                string str = namePlanet.ToLower();

                if (planetValidator(namePlanet))
                {
                    Console.WriteLine("Вы спрашиваете слишком часто");
                }

                if (str == input.PlanetName.ToLower())
                {
                    return (input.SerialNumber, input.EquatorLength, null);
                }
            }

            return (0, 0, "Не удалось найти планету");

        }

    }

}



