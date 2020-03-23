using System;
using static System.Console;
class main{
static void Main(){
	var ma=new matrix("1 2;5 6");
	ma.print();
	var ma2=ma*ma.T;
	(ma2).print();
	WriteLine($"{ma[0].norm()}");
	WriteLine($"{ma[1].norm()}");
	WriteLine($"{ma[0,0]} {ma[0,1]}");
	WriteLine($"{ma[1,0]} {ma[1,1]}");

	matrix v1=(ma).cols(0,0);
	(v1).print();
	vector v2=ma[1];
	(v2).print();

	matrix v3=(ma2).cols(0,0);
	(v3).print();
	matrix v4=(ma2).rows(1,1);
	(v4).print();

	ma[1,1]=22;
	ma.print();
}
}
