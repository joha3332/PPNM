using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

class  mainA
{
    static int Main(string[] args)
    {
	if(args.Length<3){
		Console.Error.WriteLine("too few arguments");
		return 1;
	}
        string infile = args[0];
        string outfile1 = args[1];
        string outfile2 = args[2];
        StreamReader instream = new StreamReader(infile);
        StreamWriter outstream1 = new StreamWriter(outfile1, append: false);
        StreamWriter outstream2 = new StreamWriter(outfile2, append: false);

    //Importing the data into vectors
        List<double> xlist = new List<double>();
        List<double> ylist = new List<double>();
        
        do{
            string line = instream.ReadLine();
            if (line == null) break;
            string[] values= line.Split(' ', '\t');

            xlist.Add(Double.Parse(values[0]));
            ylist.Add(Double.Parse(values[1]));       
        } while (true);

        int n= xlist.Count;
        vector x= new vector(n);
        vector y= new vector(n);

        for(int i=0; i<=(n-1); i++){
            x[i]=xlist[i];
            y[i]=ylist[i];
        }

    lspline s=new lspline(x,y);
    // The linear interpolation
        int N=999;
        for(int i=0;i<=N;i++){
            double z=(x[n-1]-x[0])/N*i+x[0];
            double yz=s.eval(z);
            outstream1.WriteLine($"{z} \t {yz}");
        }

    // Intergrating by the linear interpolation
        for(int i=0;i<=N;i++){
            double z=(x[n-1]-x[0])/N*i+x[0];
            double area_z=s.integral(z);
            outstream2.WriteLine($"{z} \t {area_z}");
        }  

        outstream1.Close();
        outstream2.Close();
        instream.Close();

        return 0;
    }
}
