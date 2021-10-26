using System;

namespace Task01
{
    class Nangler
    {
        int n;
        decimal r;
        public Nangler(int amount=4, decimal rad=1)
        {
            n = amount;
            r = rad;
        }
        public decimal P
        {
            get
            {
                return 2 * r * (decimal)Math.Sin(Math.PI / (double)n) / (decimal)Math.Cos(Math.PI / (double)n) * n;
            }
        }
        public decimal S
        {
            get
            {
                return this.P / 2 * r;
            }
        }
        public string PolygonData()
        {
            string res = "Количество сторон: " + n.ToString() + ", радиус: " + r.ToString() + ", P: " + this.P +
                ", S: " + this.S;
            return res;
        }
    }
    class Program
    {
        static int SortByS(Nangler a, Nangler b)
        {
            if (a.S < b.S)
            {
                return 1;
            }
            else if (a.S > b.S)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Nangler[] nanglers = new Nangler[n];
            for (int i = 0; i < n; i++)
            {
                int amount = int.Parse(Console.ReadLine());
                decimal rad = decimal.Parse(Console.ReadLine());
                nanglers[i] = new Nangler(amount, rad);
            }
            decimal[] ps = new decimal[n];
            decimal[] ss = new decimal[n];
            for (int i = 0; i < n; i++)
            {
                ps[i] = nanglers[i].P;
                ss[i] = nanglers[i].S;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1}-й n - угольник: {nanglers[i].PolygonData()}");
            }
            Array.Sort(ss);
            Console.WriteLine("Минимальная площадь: " + ss[0]);
            Console.WriteLine("Максимальная: " + ss[n - 1]);
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                nanglers[i] = new Nangler(random.Next(1, 180), random.Next(1, 1000));
            }
            for (int i = 0; i < n; i++)
            {
                ps[i] = nanglers[i].P;
                ss[i] = nanglers[i].S;
            }
            Array.Sort(nanglers, SortByS);
            foreach (var item in nanglers)
            {
                Console.WriteLine(item.PolygonData());
            }
        }
    }
}
