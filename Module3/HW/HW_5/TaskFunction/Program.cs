using System;

delegate double calculate(double x);
namespace TaskFunction
{
    static class NeededFunctions
    {
        public static double Func2(double x)
        {
            return x * x - 4;
        }
        public static double Func1(double x)
        {
            return Math.Sin(x);
        }
    }
    interface IFunction
    {
        double Function(double x);
    }
    class F : IFunction
    {
        calculate calculator;
        public F(Func<double, double> function)
        {
            calculator = new calculate(function);
        }
        public double Function(double x)
        {
            return calculator(x);
        }
    }
    class G
    {
        F f1;
        F f2;
        public G(Func<double, double> func1, Func<double, double> func2)
        {
            f1 = new F(func1);
            f2 = new F(func2);
        }
        public double GF(double x0)
        {
            return f2.Function(f1.Function(x0));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            G g = new G(NeededFunctions.Func1, NeededFunctions.Func2);
            double x = 0;
            do
            {
                Console.WriteLine($"{x} --> {(g.GF(x)).ToString("f4")}");
                x += Math.PI / 16.0;
            } while (x <= Math.PI + 0.1);
        }
    }
}
