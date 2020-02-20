using System;
using static System.Math;
using System.IO;

class  fileio
{
    static int Main(string[] args)
    {
	if(args.Length<2){
		Console.Error.WriteLine("too few arguments");
		return 1;
	}
        string infile = args[0];
        string outfile = args[1];
        StreamReader instream = new StreamReader(infile);
        StreamWriter outstream = new StreamWriter(outfile, append: false);


        //System.IO.TextReader stdin = System.Console.In;


        outstream.WriteLine("# x \t Sin(x) \t Cos(x)");

        do
        {
            string line = instream.ReadLine();
            if (line == null) break;
            string[] words = line.Split(' ', ',', '\t');

            foreach (string s in words)
            {
                double x = double.Parse(s);
                outstream.WriteLine("{0} \t {1} \t {2}", x, Sin(x), Cos(x));
            }
        } while (true);

        outstream.Close();
        instream.Close();

        return 0;
    }
}
