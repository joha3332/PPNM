using System;
using static System.Console;
using static System.Math;

class mainA {
static void Main(){

WriteLine("Problem A - Test of plain Monte Carlo integrator");
WriteLine();
WriteLine("Test 1 - Integration of (sin(x))^2 from 0 to 2*PI");
	Func<vector,double> sin2 = delegate(vector x) {return Sin(x[0])*Sin(x[0]);};
	vector a= new vector(1); a[0]=(0.0);
	vector b= new vector(1); b[0]=(2*PI);
	int N=10000;
	vector res=mcintegrator.plainmc(a,b,sin2,N);
	double exact= PI;
	WriteLine("Exact value \t MC value \t error");
	WriteLine($"{exact:f5} \t {res[0]:f5} \t {res[1]:f5}");
	if(Abs(exact-res[0])<res[1]) WriteLine("test passed");
	else    WriteLine("test failed");
Write("\n\n");


WriteLine("Test 2 - Integration of sin(x)*sin(y) from 0 to PI");
	Func<vector,double> sinsin = delegate(vector x) {return Sin(x[0])*Sin(x[1]);};
	vector a2=new vector(2); a2[0]=(0.0); a2[1]=(0.0);
	vector b2=new vector(2); b2[0]=(PI); b2[1]=(PI);
	N=1000000;
	res=mcintegrator.plainmc(a2,b2,sinsin,N);
	exact= 4;

	WriteLine("Exact value \t MC value \t error");
	WriteLine($"{exact:f5} \t {res[0]:f5} \t {res[1]:f5}");
	if(Abs(exact-res[0])<res[1]) WriteLine("test passed");
	else    WriteLine("test failed");
Write("\n\n");



WriteLine("Test 3 - Integration of 1/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]))/(PI*PI*PI) from 0 to PI (in both x, y and z)");
	Func<vector,double> f4 = delegate(vector x) {return 1/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]))/(PI*PI*PI);};
	vector a4= new vector(3); a4[0]=(0);a4[1]=(0);a4[2]=(0);
	vector b4= new vector(3); b4[0]=(PI);b4[1]=(PI);b4[2]=(PI);
	N=1000000;
	res=mcintegrator.plainmc(a4,b4,f4,N);
	exact= 1.3932039296856768591842462603255;
	
	WriteLine("Exact value \t MC value \t error");
	WriteLine($"{exact:f5} \t {res[0]:f5} \t {res[1]:f5}");
	if(Abs(exact-res[0])<res[1]) WriteLine("test passed");
	else    WriteLine("test failed");
Write("\n\n");


}//method: Main
}//class: MainA