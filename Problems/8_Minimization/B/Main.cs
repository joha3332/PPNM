using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;
using System.IO;

class main{
static System.Collections.Generic.List<double> energy,sigma,error;

static void Main(){

energy = new List<double>();
sigma = new List<double>();
error  = new List<double>();
TextReader data = Console.In;

	do{
	    string line = data.ReadLine();
	    if (line == null) break;
	    string[] values= line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
	    energy.Add(Double.Parse(values[0]));
	    sigma.Add(Double.Parse(values[1])/100);
	    error.Add(Double.Parse(values[2])/10);     
	} while (true);



int n=energy.Count;
for(int i=0;i<n;i++){
Error.WriteLine($"{energy[i]} \t {sigma[i]} \t {error[i]}");}
Error.WriteLine();Error.WriteLine();
// exporting data again due to potential problems of decimal separator.

vector point=new vector(3);
	point[0]=120;point[1]=2;point[2]=6;

point=qnewton.sr1(chi2, point,acc:1e-3);
double m= point[0];
double Gamma= point[1];
double A= point[2];
WriteLine($"mass\t= {m}");
WriteLine($"Gamma\t= {Gamma}");
WriteLine($"Sqrt(chi^2/n)={Sqrt(chi2(point)/energy.Count)}");

double energy_i, energy_dif= energy[n-1]-energy[0];
for(int i=0;i<9999;i++){
	energy_i=energy_dif*i/9999+energy[0];
	Error.WriteLine($"{energy_i} {A*BW(energy_i,m,Gamma)}");
}


}// Method: Main

static double chi2(vector x){
	double m = x[0];
	double Gamma = x[1];
	double A = x[2];

	double sum=0;
	for(int i=0;i<energy.Count;i++){
	sum += Pow( A*BW(energy[i],m,Gamma) -sigma[i],2)/error[i]/error[i];};
	return sum;
}

static double BW(double e, double m, double Gamma){
	return 1/((e-m)*(e-m)+Gamma*Gamma/4);
}

}// Class: main
