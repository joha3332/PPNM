using System;
using static System.Math;
using System.IO;

class stdinout
{
    static int Main()
    {

        TextReader stdin = Console.In;
        TextWriter stdout = Console.Out;
        
        stdout.WriteLine("# x \t Sin(x) \t Cos(x)");

        do
        {
            string line = stdin.ReadLine();
            if (line == null) break;
            string[] s = line.Split(' ', ',', '\t');

            foreach (string s_n in s)
			{
                double x = double.Parse(s_n);
                stdout.WriteLine("{0} \t {1} \t {2}", x, Sin(x), Cos(x));
            }
        } while (true);


        return 0;
    }
}
