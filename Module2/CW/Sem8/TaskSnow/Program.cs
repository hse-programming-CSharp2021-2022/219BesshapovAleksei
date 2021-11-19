using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSnow
{
    abstract class Person
    {
        bool isKickedOut;
        public bool IsKickedOut
        {
            get
            {
                return isKickedOut;
            }
            set
            {
                isKickedOut = value;
            }
        }
        public string Name
        {
            get;
            set;
        }
        public string Pocket
        {
            get;
            set;
        }
        public virtual bool GiftGiven()
        {
            return this.Pocket.Length > 0;
        }
        public virtual void Receive(string present)
        {
            if (this.Pocket.Length > 0)
            {
                this.IsKickedOut = true;
                throw new ArgumentException($"У тебя, {this.Name}, подарок уже есть, уходи");
            }
            else
            {
                this.Pocket = present;
            }
        }
        public Person(string name)
        {
            Name = name;
            IsKickedOut = false;
            Pocket = "";
        }
        public override string ToString()
        {
            return $"{this.Name}";
        }

    }
    class SnowMaiden : Person
    {
        public List<string> Presents
        {
            get;
            set;
        }
        public List<string> CreatePresents(int amount)
        {
            List<string> presents = new List<string>();
            for (int i = 0; i < amount; i++)
            {
                presents.Add(Program.GenerateName());
            }
            return presents;
        }
        public SnowMaiden(string name, int amount) : base(name)
        {
            Presents = CreatePresents(amount);
        }
    }
    class Santa : Person
    {
        List<string> sack = new List<string>();
        public List<string> Sack
        {
            get
            {
                return sack;
            }
            set
            {
                sack.Add(value.ToString());
            }
        }
        public void Request(ref SnowMaiden snowMaiden, int amount)
        {
            Random random = new Random();
            if (amount > snowMaiden.Presents.Count)
            {
                throw new ArgumentException("Столько подарков нет");
            }
            for (int i = 0; i < amount; i++)
            {
                int presentNumber = random.Next(0, snowMaiden.Presents.Count);
                this.Sack.Add(snowMaiden.Presents[presentNumber]);
                snowMaiden.Presents.RemoveAt(presentNumber);
            }
        }
        public void Give(Person person)
        {
            Random random = new Random();
            if (this.Sack.Count == 0)
            {
                throw new Exception("А подарков и нет");
            }
            person.Receive(this.Sack[random.Next(0, this.Sack.Count)]);
        }
        public override void Receive(string present)
        {
            base.Receive(present);
        }
        public Santa(string name) : base(name)
        {
            Sack = new List<string>();
        }
    }
    class Child : Person
    {
        public string AdditionalPocket
        {
            get;
            set;
        }
        public override bool GiftGiven()
        {
            return this.AdditionalPocket.Length > 0 && this.Pocket.Length > 0;
        }
        public override void Receive(string present)
        {
            if (this.AdditionalPocket.Length > 0 && this.Pocket.Length > 0)
            {
                this.IsKickedOut = true;
                throw new ArgumentException($"У тебя, {this.Name}, и так уже оба кармана заняты, уходи");
            }
            else
            {
                if (this.Pocket.Length > 0)
                {
                    this.AdditionalPocket = present;
                }
                else
                {
                    this.Pocket = present;
                }
            }
        }
        public Child(string name) : base(name)
        {
            AdditionalPocket = "";
        }
    }
    class Program
    {
        static public string GenerateName()
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            sb.Append((char)random.Next('A', 'Z' + 1));
            sb.Append((char)random.Next('A', 'Z' + 1));
            sb.Append((char)random.Next('A', 'Z' + 1));
            sb.Append(sb[1]);
            sb.Append(sb[0]);
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            Santa realSanta = new Santa("дед мороз");
            SnowMaiden realSnowMaiden = new SnowMaiden("снегурочка", 100);
            List<Person> people = new List<Person>();
            people.Add(realSanta);
            people.Add(realSnowMaiden);
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i < n + 2; i++)
            {
                people.Add(new Child(GenerateName()));
            }
            bool giftGivingGoesWithoutProblems = true;
            Random random = new Random();
            while (giftGivingGoesWithoutProblems)
            {
                bool isOnlySantaLeft = true;
                for (int i = 1; i < n + 2; i++)
                {
                    if (!people[i].IsKickedOut)
                    {
                        isOnlySantaLeft = false;
                        break;
                    }
                }
                if (people[0].IsKickedOut || people[1].IsKickedOut || isOnlySantaLeft || realSnowMaiden.Presents.Count == 0)
                {
                    string reason = isOnlySantaLeft ? "cанта остался один..." :
                        (people[0].IsKickedOut ? "cанту выгнали, он прибрал к рукам лишние подарки..." :
                        (realSnowMaiden.Presents.Count == 0? "подарков не осталось...": 
                        "cнегурочку выгнали, она забрала с собой подарки..."));
                    Console.WriteLine($"Вечеринка закончена, причина - {reason}");
                    giftGivingGoesWithoutProblems = false;
                    break;
                }
                try
                {
                    int presentsAmount = random.Next(1, 5);
                    string declesion = presentsAmount == 1? "подарок": "подарка";
                    Console.WriteLine($"{realSanta}: {realSnowMaiden}, дай мне {presentsAmount} {declesion}");
                    realSanta.Request(ref realSnowMaiden, presentsAmount);
                    double chance = random.NextDouble();
                    if (chance <= 0.1)
                    {
                        realSanta.Give(people[0]);
                        Console.WriteLine($"Подарок получил: {people[0]}");
                    }
                    else
                    {
                        int numberOfPresentReceiver = random.Next(1, n + 2);
                        realSanta.Give(people[numberOfPresentReceiver]);
                        Console.WriteLine($"Подарок получил: {people[numberOfPresentReceiver]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
