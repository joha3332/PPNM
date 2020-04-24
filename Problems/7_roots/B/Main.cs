using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
double rmax=8;
Error.WriteLine($"rmax={rmax}");

Func<vector,vector> M = delegate(vector v){
		double e=v[0];
		double f_rmax=hydrogen.F_e(e,rmax);
		return new vector(f_rmax);
	};

vector v_start= new vector(-1.0);
vector v_root=roots.newton(M,v_start,eps:1e-4);
double energy=v_root[0];
WriteLine($"e={energy}");
Write("\n\n");
WriteLine("#r \t F_e(e,r) \t exact");
for(double r=0; r<=rmax; r+=rmax/100)
	WriteLine($"{r} \t {hydrogen.F_e(energy,r)} \t {r*Exp(-r)}");

}//Main method
}//class