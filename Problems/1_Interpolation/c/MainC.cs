using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

class  mainC
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
        string outfile3 = args[3];
        StreamReader instream = new StreamReader(infile);
        StreamWriter outstream1 = new StreamWriter(outfile1, append: false);
        StreamWriter outstream2 = new StreamWriter(outfile2, append: false);
        StreamWriter outstream3 = new StreamWriter(outfile3, append: false);

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

	cspline s=new cspline(x,y);
    // Evaluating the spline
        int N=999;
        for(int i=0;i<=N;i++){
            double z=(x[n-1]-x[0])/N*i+x[0];
            double yz=s.eval(z);
            outstream1.WriteLine($"{z} \t {yz}");
        }

    // Evaluating the derivetives of the spline
        for(int i=0;i<=N;i++){
            double z=(x[n-1]-x[0])/N*i+x[0];
            double slope_z=s.derivative(z);
            outstream2.WriteLine($"{z} \t {slope_z}");
        }


    // Evaluating the integral of the spline
        for(int i=0;i<=N;i++){
            double z=(x[n-1]-x[0])/N*i+x[0];
            double area_z=s.integral(z);
            outstream3.WriteLine($"{z} \t {area_z}");
       }     
    
        outstream1.Close();
        outstream2.Close();
        outstream3.Close();
        instream.Close();

        return 0;
    }
}
