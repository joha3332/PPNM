using System;
using static System.Console;
using static System.Math;

class mainA {
static void Main(){

//WriteLine("Problem B - Error test of plain Monte Carlo integrator");
//WriteLine("N \t error estimate \t actual error");
//WriteLine();
	Func<vector,double> sinsin = delegate(vector x) {return Sin(x[0])*Sin(x[1]);};
	vector a=new vector(2); a[0]=(0.0); a[1]=(0.0);
	vector b=new vector(2); b[0]=(PI); b[1]=(PI);
	double exact= 4;
	int N;

	for(int i=10 ;i<100;i++){
	N=i*5000;
	vector res=mcintegrator.plainmc(a,b,sinsin,N);
	WriteLine($"{N} \t {res[1]:f8} \t {(Abs(exact-res[0])):f8}");
	}	



}//method: Main
}//class: MainA