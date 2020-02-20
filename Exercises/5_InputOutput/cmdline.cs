using System;
using static System.Math;
class cmdline
{
    static int Main(string[] args)
    {
        Console.WriteLine("x \t Sin(x) \t Cos(x)");

            foreach (var s in args)
            {
            double x = double.Parse(s);
            Console.WriteLine("{0} \t {1} \t {2}", x, Sin(x), Cos(x));
            }

        return 0;
    }
}
