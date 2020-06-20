using System;
using static System.Console;
using static System.Math;
using static BoolAprox;
class main{
	static int Main(){
		double x=1;
		double y1=1+1e-8;
		double y2=1+1e-10;
		double z1=1*(1+1e-8);
		double z2=1*(1+1e-10);

		WriteLine("Tolerance: \n abs: 1e-9 \n rel: 1e-9");
		WriteLine($"{x} approx {y1} \t {boolAprox(x,y1)}");
		WriteLine($"{x} approx {y2} \t {boolAprox(x,y2)}");
		WriteLine($"{x} approx {z1} \t {boolAprox(x,z1)}");
		WriteLine($"{x} approx {z2} \t {boolAprox(x,z2)}");
	return 0;
	}
}

