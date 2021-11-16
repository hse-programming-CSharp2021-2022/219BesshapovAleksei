using System;
using System.Text;

namespace Var2
{
    class Creature
    {
        public string Name
        {
            get;
            set;
        }
        public int Speed
        {
            get;
            set;
        }
        public virtual string Run
        {
            get
            {
                return $"I am running with a speed of {this.Speed}.";
            }
        }
        public override string ToString()
        {
            return this.Run + $" My name is {this.Name}.";
        }
        public Creature(string name, int speed)
        {
            this.Name = name;
            this.Speed = speed;
        }
        public virtual string MakeNewStaff
        {
            get;
        }
    }
    class Dwarf : Creature
    {
        int strength;
        public int Strength
        {
            get
            {
                return strength;
            }
            set
            {
                if (value > 20 || value < 1)
                {
                    Random random = new Random();
                    strength = random.Next(1, 21);
                }
                else
                {
                    strength = value;
                }
            }
        }
        public override string Run
        {
            get
            {
                return $"I am running with a speed of {this.Speed}. My strength is {this.Strength}.";
            }
        }
        public override string MakeNewStaff
        {
            get
            {
                return "Бамбамбимбим I've created a new staff.";
            }
        }
        public Dwarf(string name, int speed, int strength) : base(name, speed)
        {
            this.Strength = strength;
        }
    }
    class Elf : Creature
    {
        int age;
        public override string Run
        {
            get
            {
                return $"I am running with a speed of {this.Speed}. My age is {this.age}.";
            }
        }
        public Elf(string name, int speed) : base(name, speed) 
        {
            Random random = new Random();
            int elfAge = random.Next(100, 201);
            this.age = elfAge;
            this.Speed += this.age / 77;
        }
    }
    class Program
    {
        public static string RandomString(int size)
        {
            StringBuilder sb = new StringBuilder();
            Random randomizer = new Random();
            for (int i = 0; i < size; i++)
            {
                if (i == 0)
                {
                    sb.Append(((char)randomizer.Next(97, 123)).ToString().ToUpper());
                }
                else
                {
                    sb.Append(((char)randomizer.Next(97, 123)).ToString());

                }
            }
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            Console.Write("Хотите воспользоваться генератором существ? y - да, все остальное - нет:");
            string answer = Console.ReadLine();
            while (answer == "y")
            {
                Console.Write("Введите количество существ:");
                int n = int.Parse(Console.ReadLine());
                Random random = new Random();
                Creature[] creatures = new Creature[n];
                for (int i = 0; i < n; i++)
                {
                    double randomNumber = random.NextDouble();
                    if (randomNumber <= 0.2)
                    {
                        creatures[i] = new Creature(RandomString(random.Next(3, 7)), random.Next(10, 19));
                    }
                    else if (randomNumber <= 0.6)
                    {
                        creatures[i] = new Dwarf(RandomString(random.Next(3, 8)), random.Next(10, 19), random.Next(-50, 51));
                    }
                    else
                    {
                        creatures[i] = new Elf(RandomString(random.Next(3, 5)), random.Next(10, 19));
                    }
                }
                foreach (Creature creature in creatures)
                {
                    Console.WriteLine(creature);
                    if (creature.GetType().ToString() == "Var2.Dwarf")
                    {
                        Console.WriteLine(creature.MakeNewStaff);
                    }
                }
                Console.Write("Хотите воспользоваться генератором существ еще раз? y - да, все остальное - нет:");
                answer = Console.ReadLine();
            }
            Console.WriteLine("ну и пока");
        }
    }
}
