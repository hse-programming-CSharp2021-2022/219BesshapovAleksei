using System;

namespace TaskHumans
{
    struct Person : IComparable<Person>
    {
        string name;
        string lastname;
        int age;
        public Person(string name, string lastname, string age)
        {
            this.name = name;
            this.lastname = lastname;
            bool isAgeCorrect = int.TryParse(age, out this.age);
            if (!isAgeCorrect || this.age <= 0)
            {
                throw new ArgumentOutOfRangeException("Wrong name");
            }
        }
        public int CompareTo(Person person2)
        {
            return this.age.CompareTo(person2.age);
        }
        public override string ToString()
        {
            return $"{this.name} {this.lastname}, {this.age}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();
            string[] names = new string[] { "Алексей", "Александр", "Антон", "Азамат", "Алишер", "Абдурозик", "Архип"};
            string[] lastnames = new string[] { "Петров", "Сидоров", "Попов", "Горденко", "Романов", "Полянский" };
            int size = int.Parse(Console.ReadLine());
            Person[] characters = new Person[size];
            for (int i = 0; i < size; i++)
            {
                characters[i] = new Person(names[randomizer.Next(names.Length)], lastnames[randomizer.Next(lastnames.Length)], randomizer.Next(1, 101).ToString());
            }
            Array.ForEach(characters, el => Console.WriteLine(el));
            Console.WriteLine("***");
            Array.Sort(characters);
            Array.ForEach(characters, el => Console.WriteLine(el));
            Console.WriteLine("***");
        }
    }
}
