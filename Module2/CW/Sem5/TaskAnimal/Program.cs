using System;

namespace TaskAnimal
{
    abstract class Animal
    {
        int age;
        string name;
        bool isTrained;
        int Age
        {
            get;
            set;
        }
        string Name
        {
            get;
            set;
        }
        bool IsTrained
        {
            get;
        }
        protected abstract string AnimalSound();
        public abstract string AnimalInfo();
    }
    class Dog : Animal
    {
        string name;
        int age;
        bool isTrained = true;
        public Dog(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        bool IsTrained
        {
            get;
        }
        string Name
        {
            get;
            set;
        }
        int Age
        {
            get;
            set;
        }
        protected override string AnimalSound()
        {
            return "bow-woo";
        }
        public override string AnimalInfo()
        {
            return $"Кличка: {this.Name}, возраст: {this.Age}, что говорит: говорит {this.AnimalSound()}, подвластна контролю? {(this.IsTrained ? "Нет" : "Да")}";
        }
    }
    class Cow : Animal
    {
        bool isTrained = true;
        string name;
        int age;
        public Cow(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        bool IsTrained
        {
            get;
        }
        string Name
        {
            get;
            set;
        }
        int Age
        {
            get;
            set;
        }
        protected override string AnimalSound()
        {
            return "moo-woo";
        }
        public override string AnimalInfo()
        {
            return $"Кличка: {this.Name}, возраст: {this.Age}, что говорит: говорит {this.AnimalSound()}, подвластна контролю? {(this.IsTrained? "Нет":"Да")}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Бобик", 10);
            Cow cow = new Cow("Мясо", 30);
            Console.WriteLine(dog.AnimalInfo());
            Console.WriteLine(cow.AnimalInfo());
        }
    }
}
