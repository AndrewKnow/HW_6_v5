using System;
using System.Collections.Generic;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = new[] { "Земля", "Лимония", "Марс" };

            foreach (var input in inputs)
            {
                var getPlanet = PlanetСatalog.GetPlanet(input);
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
        public Planet PreviousPlanet { get; set; }

        public Planet(string planetName, int lastName, int equatorLength, Planet previousPlanet)
        {
            PlanetName = planetName;
            SerialNumber = lastName;
            EquatorLength = equatorLength;
            PreviousPlanet = previousPlanet;
        }

    }

    class PlanetСatalog
    {

        //2.1) // не понятно как в контексте задания использовать класс Planet и его свойства...?
        //Написать класс "Каталог планет". В нем должен быть список планет - надо было заполнять как раз элементами Planet, а вот результат GetPlanet как раз анонимный тип

        static List<Planet> planets = new()
        {
            new Planet("Венера", 2, 38025, null),
            new Planet("Земля", 3, 40075, new Planet("Венера", 2, 38025, null)),
            new Planet("Марс", 4, 21344, new Planet("Земля", 3, 40075, new Planet("Венера", 2, 38025, null)))
        };

        public static (int serialNumber, int equatorLength, string error) GetPlanet(string namePlanet, PlanetValidator planetValidator)
        {


            foreach (var input in planets)
            {
                string str = namePlanet.ToLower();

                if (str == input.PlanetName.ToLower())
                {
                    return (input.SerialNumber, input.EquatorLength, null);
                }
            }

            return (0, 0, "Не удалось найти планету");

        }

    }

}
