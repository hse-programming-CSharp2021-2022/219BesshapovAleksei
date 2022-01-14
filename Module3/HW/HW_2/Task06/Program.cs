using System;

namespace Task06
{
    class Plant
    {
        double growth;
        double photosensitivity;
        double frostresistance;
        public double Growth
        {
            get
            {
                return growth;
            }
        }
        public double Photosensitivity
        {
            get
            {
                return photosensitivity;
            }
        }
        public double Frostresistance
        {
            get
            {
                return frostresistance;
            }
            set
            {
                frostresistance = value;
            }
        }
        public Plant(double growth, double photo, double frost)
        {
            this.growth = growth;
            this.photosensitivity = photo;
            this.frostresistance = frost;
        }
        public override string ToString()
        {
            return $"Growth {this.Growth.ToString("F2")}, Photosensitivity {this.Photosensitivity.ToString("F2")}, Frostresistance {this.Frostresistance.ToString("F2")}.";
        }
    }
    class Program
    {
        static int SortByOddness(Plant plant1, Plant plant2)
        {
            if ((int)plant1.Photosensitivity % 2 != 0
                && (int)plant2.Photosensitivity % 2 == 0)
            {
                return 1;
            }
            else if ((int)plant1.Photosensitivity == (int)plant2.Photosensitivity)
            {
                return 0;
            }
            else
            {
                return -1;
            }

        }
        static void Main(string[] args)
        {
            Random randomizer = new Random();
            int n = int.Parse(Console.ReadLine());
            Plant[] plants = new Plant[n];
            for (int i = 0; i < n; i++)
            {
                plants[i] = new Plant(25 + randomizer.NextDouble() * 75,
                    randomizer.NextDouble() * 100,
                    randomizer.NextDouble() * 80);
            }
            Array.ForEach(plants, el => Console.WriteLine(el));
            Array.Sort(plants, delegate (Plant plant1, Plant plant2)
            {
                if (plant1.Growth > plant2.Growth)
                {
                    return -1;
                }
                else if (plant1.Growth < plant2.Growth)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });
            Array.ForEach(plants, el => Console.WriteLine(el));
            Array.Sort(plants, (plant1, plant2) =>
            {
                if (plant1.Frostresistance > plant2.Frostresistance)
                {
                    return 1;
                }
                else if (plant1.Frostresistance < plant2.Frostresistance)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            });
            Array.ForEach(plants, el => Console.WriteLine(el));
            Array.Sort(plants, SortByOddness);
            Array.ForEach(plants, el => Console.WriteLine(el));
            Converter<Plant, Plant> converter = plant =>
            {
                if ((int)plant.Frostresistance % 2 == 0)
                {
                    return new Plant(plant.Growth, plant.Photosensitivity, plant.Frostresistance / 3.0);
                }
                else
                {
                    return new Plant(plant.Growth, plant.Photosensitivity, plant.Frostresistance / 2.0);
                }
            };
            Plant[] convertedPlants = Array.ConvertAll(plants, converter);
            Array.ForEach(convertedPlants, el => Console.WriteLine(el));
        }
    }
}