using System;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;

class main{


static Func<double,vector,vector>
F=delegate(double x, vector y){
	return new vector(y[1],-y[0]);
		};

static void Main(){
	double a=0;
	vector ya=new vector(1,0);
	double b=2*PI;
	double h=0.1, acc=1e-3, eps=1e-3;
	var xs=new List<double>();
	var ys=new List<vector>();

vector y=ode.rk23(F,a,ya,b,acc:acc,eps:eps,h:h,xlist:xs,ylist:ys);

	Error.WriteLine($"acc={acc} eps={eps}");
	Error.WriteLine($"npoints={xs.Count}");
	Error.WriteLine($"a={a} y0({a})={ya[0]} y1({a})={ya[1]}");
	Error.WriteLine($"b={b}");
	Error.WriteLine($"y0 (b)={y[0]  }  y1(b)={y[1]}");
	Error.WriteLine($"Cos(b)={Cos(b)} Sin(b)={Sin(b)}");


	for(int i=0;i<xs.Count;i++)
		WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
}
}