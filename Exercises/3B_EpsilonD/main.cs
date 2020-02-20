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
		System.Console.Write("{0},\n{1},\n{2},\n{3}\n",
		BoolAprox.boolAprox(x,y1),
		boolAprox(x,y2),
		boolAprox(x,z1),
		boolAprox(x,z2));
	return 0;
	}
}

