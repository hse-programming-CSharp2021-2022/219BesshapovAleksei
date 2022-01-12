using System;

delegate double DelegateConvertTemperature(double t);
namespace Task03
{
    class TemperatureConverterImp
    {
        public double FtoC(double f)
        {
            double c = 5 * (f - 32) / 9.0;
            Console.WriteLine($"FtoC {c}");
            return c;
        }
        public double CtoF(double c)
        {
            double f = 9 * c / 5.0 + 32;
            Console.WriteLine($"CtoF {f}");
            return f;
        }
    }
    static class StaticTempConverters
    {
        public static double CtoK(double c)
        {
            double k = c + 273.15;
            Console.WriteLine($"CtoK {k}");
            return k;
        }
        public static double CtoRa(double c)
        {
            double ra = (c + 273.15) * 1.8;
            Console.WriteLine($"CtoRa {ra}");
            return ra;
        }
        public static double CtoRe(double c)
        {
            double re = c * 0.8;
            Console.WriteLine($"CtoRe {re}");
            return re;
        }
        public static double KtoC(double k)
        {
            double c = k - 273.15;
            Console.WriteLine($"KtoC {c}");
            return c;
        }
        public static double RatoC(double ra)
        {
            double c = ra / 1.8 - 273.15;
            Console.WriteLine($"RatoC {c}");
            return c;
        }
        public static double RetoC(double re)
        {
            double c = re / 0.8;
            Console.WriteLine($"RetoC {c}");
            return c;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TemperatureConverterImp converter = new TemperatureConverterImp();
            DelegateConvertTemperature converter1 = new DelegateConvertTemperature(converter.FtoC);
            DelegateConvertTemperature converter2 = new DelegateConvertTemperature(converter.CtoF);
            Console.WriteLine(converter1(41));
            Console.WriteLine(converter2(5));
            DelegateConvertTemperature[] converters = { converter1, converter2 };
            converters[0] += converter.CtoF;
            converters[1] = new DelegateConvertTemperature(StaticTempConverters.CtoK);
            converters[1] += StaticTempConverters.CtoRa;
            converters[1] += StaticTempConverters.CtoRe;
            converters[1] += StaticTempConverters.KtoC;
            converters[1] += StaticTempConverters.RatoC;
            converters[1] += StaticTempConverters.RetoC;
            Console.WriteLine("Введите -1234321, чтобы прекратить");
            double c = double.Parse(Console.ReadLine());
            while (c != -1234321)
            {
                converters[0].Invoke(c);
                converters[1].Invoke(c);
                c = double.Parse(Console.ReadLine());
            }
        }
    }
}
