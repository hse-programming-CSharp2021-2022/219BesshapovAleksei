using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaskPuhShiesty
{
    internal static class BadSolution
    {
        static void Main(string[] args)
        {   
            int numberOfBees = 200;
            Pot pot = new Pot(50);
            Bear bear = new Bear(pot);
            HashSet<Bee> bees = new HashSet<Bee>();
            Bee createdBee;
            for (int i = 0; i < numberOfBees; i++)
            {
                createdBee = new Bee(pot, bear);
                bees.Add(createdBee);
                var bee = createdBee;
                Task.Run(() => bee.IncrementPotFullness());
                Task.WaitAll();
            }
            Console.ReadLine();
        }
    }

    class Pot
    {
        private readonly int capacity;
        private int fullness;

        public Pot(int capacity)
        {
            this.capacity = capacity;
        }

        public void IncrementFullness()
        {
            fullness++;
            Console.WriteLine(fullness);
        }

        public bool IsFull()
        {
            return fullness == capacity;
        }

        public void MakeEmpty()
        {
            fullness = 0;
        }
    }

    class Bee
    {
        private Pot pot;
        private Bear bear;

        public Bee(Pot pot, Bear bear)
        {
            this.pot = pot;
            this.bear = bear;
        }

        public void IncrementPotFullness()
        {
            while (true)
            {
                Thread.Sleep(200);
                pot.IncrementFullness();
                if (pot.IsFull())
                {
                    Console.WriteLine("Wake up the bear!");
                    Task.Run(() => bear.WakeUp()).Wait();
                }
            }
        }
    }

    class Bear
    {
        private Pot pot;
        private bool isSleeping = true;

        public Bear(Pot pot)
        {
            this.pot = pot;
        }

        public void WakeUp()
        {
            if (isSleeping)
            {
                isSleeping = false;
                while (pot.IsFull())
                { 
                    Monitor.Wait(new object()); 
                }
                pot.MakeEmpty();
                isSleeping = true;
            }
        }
    }
}