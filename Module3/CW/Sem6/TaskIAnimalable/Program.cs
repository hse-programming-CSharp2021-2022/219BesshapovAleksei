using System;

namespace TaskIAnimalable
{
    abstract class Animal : IComparable
    {
        public int Age
        {
            get;
            set;
        }
        public int CompareTo(object? animal2)
        {
            Animal newAnimal = animal2 as Animal;
            return this.Age.CompareTo(newAnimal.Age);
        }
    }
    interface IJumpable
    {
        void Jump();
    }
    interface IRunnable
    {
        void Run();
    }
    class Cocoroach : Animal, IRunnable, IComparable
    {
        public double Speed
        {
            get;
            set;
        }
        public void Run()
        {
            Console.WriteLine($"Cocoroach runs with speed of {this.Speed}");
        }
        public Cocoroach(int age, double speed)
        {
            Age = age;
            Speed = speed;
        }
        public override string ToString()
        {
            return $"Таракан: возраст {this.Age}, скорость: {this.Speed}";
        }
        /*
        public new int CompareTo(object? cocroach)
        {
            Cocoroach newCocroach = cocroach as Cocoroach;
            return newCocroach.Speed.CompareTo(this.Speed);
        }
        */
    }
    class Cangaroo : Animal, IJumpable, IComparable
    {
        public double HeightOfJump
        {
            get;
            set;
        }
        public void Jump()
        {
            Console.WriteLine($"Cangaroo jumps with height of {this.HeightOfJump}");
        }
        public Cangaroo(int age, double height)
        {
            Age = age;
            HeightOfJump = height;
        }
        public override string ToString()
        {
            return $"Кангуру: возраст {this.Age}, высота прыжка {this.HeightOfJump}";
        }
        /*
        public new int CompareTo(object? cangaroo)
        {
            Cangaroo newCangaroo = cangaroo as Cangaroo;
            return newCangaroo.HeightOfJump.CompareTo(this.HeightOfJump);
        }
        */
    }
    class Jeopardy : Animal, IRunnable, IJumpable
    {
        public double Speed
        {
            get;
            set;
        }
        public double HeightOfJump
        {
            get;
            set;
        }
        public void Run()
        {
            Console.WriteLine($"Jeopardy runs with speed of {this.Speed}");
        }
        public void Jump()
        {
            Console.WriteLine($"Jeopardy jumps with height of {this.HeightOfJump}");
        }
        public Jeopardy(int age, double speed, double height)
        {
            Age = age;
            Speed = speed;
            HeightOfJump = height;
        }
        public override string ToString()
        {
            return $"Гепард: возраст {this.Age}, скорость {this.Speed}, высота прыжка {this.HeightOfJump}"; ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Animal[] animals = new Animal[6] { new Cocoroach(random.Next(1, 5), random.NextDouble()), new Cocoroach(random.Next(1, 5), random.NextDouble()), new Cangaroo(random.Next(1, 10), random.Next(1, 3)), new Cangaroo(random.Next(1, 10), random.Next(1, 3)), new Jeopardy(random.Next(1, 8), random.Next(5, 10), random.Next(1, 2)), new Jeopardy(random.Next(1, 8), random.Next(5, 10), random.Next(1, 2))};
            Array.ForEach(animals, el => Console.WriteLine(el));
            IJumpable[] jumpers = new IJumpable[4];
            int amount = 0;
            foreach (var animal in animals)
            {
                if (animal is IJumpable)
                {
                    jumpers[amount] = (IJumpable)animal;
                    amount++;
                }
            }
            Console.WriteLine("***");
            Array.ForEach(jumpers, el => el.Jump());
            Console.WriteLine("***");
            IRunnable[] runners = new IRunnable[4];
            amount = 0;
            foreach (var animal in animals)
            {
                if (animal is IRunnable)
                {
                    runners[amount] = (IRunnable)animal;
                    amount++;
                }
            }
            Array.ForEach(runners, el => el.Run());
            Console.WriteLine("***");
            Array.Sort(animals);
            Array.ForEach(animals, el => Console.WriteLine(el));
            Console.WriteLine("***");
        }
    }
}
