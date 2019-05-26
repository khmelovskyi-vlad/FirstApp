using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = ReadCoef("a");
            var b = ReadCoef("b");
            var c = ReadCoef("c");
            var d = Math.Pow(b, 2) - 4 * a * c;
            if (d < 0)
            {
                Console.WriteLine("Error");
            }
            else if (d == 0)
            {
                var x = b / 2 * a;
                Console.WriteLine($"Result is {x}");
            }
            else
            {
                var dsqrt = Math.Sqrt(d);
                var x1 = (-b + dsqrt) / (2 * a);
                var x2 = (-b - dsqrt) / (2 * a);
                Console.WriteLine($"Result: X1={x1}, X2={x2}");
            }
            Console.Read();
        }

        static double ReadCoef(string coefName)
        {
            do
            {
                try
                {
                    Console.Write($"Enter {coefName}: ");
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        throw new OperationCanceledException();
                    }
                    var line = Console.ReadLine();
                    var keyline = $"{key.KeyChar}{line}";
                    return Convert.ToDouble(keyline, CultureInfo.InvariantCulture);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine($"Bad input {ex.Message}. Enter again or press esc to exit");
                }
            } while (true);
        }
    }
}
