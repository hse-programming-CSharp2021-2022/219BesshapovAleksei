using System;

namespace Cinderella
{
    abstract class Something { }
    class Lentil : Something
    {
        double Weight
        {
            get;
        }
        public Lentil()
        {
            Random random = new Random();
            this.Weight = 2 * random.NextDouble();
        }
        public override string ToString()
        {
            return $"Lentil, volume = {this.Weight}";
        }
    }
    class Ashes : Something
    {
        double Volume
        {
            get;
        }
        public Ashes()
        {
            Random random = new Random();
            this.Volume = random.NextDouble();
        }
        public override string ToString()
        {
            return $"Ashes, volume = {this.Volume}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Random random = new Random();
            Something[] things = new Something[n];
            for (int i = 0; i < n; i++)
            {
                int choice = random.Next(0, 2);
                things[i] = choice == 0 ? new Lentil() : new Ashes();
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(things[i]);
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(things[i].GetType().ToString() == "Cinderella.Ashes" ? things[i] :"");
                Console.Write(" ");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(things[i].GetType().ToString() != "Cinderella.Ashes" ? things[i] : "");
                Console.Write(" ");
            }
        }
    }
}
