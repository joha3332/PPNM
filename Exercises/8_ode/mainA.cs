using System;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;


class main{
static bool approx(double a,double b, double acc=1e-6, double eps=1e-6){
	if( Abs(a-b)<acc )return true;
	if( Abs(a-b)<eps*Max(Abs(a),Abs(b)) ) return true;
	return false;
}


static Func<double,vector,vector>
F=delegate(double x, vector y){
	return new vector(y[0]*(1-y[0]));
	};

static int Main(){
	double a=0;
	vector ya=new vector(0.5);
	double b=3;
	double h=0.01,acc=1e-3,eps=1e-3;
	var xs=new List<double>();
	var ys=new List<vector>();

vector y=ode.rk23(F,a,ya,b,acc,eps,h,xlist:xs,ylist:ys);

	Error.WriteLine($"y0    ={y[0]}");
	Error.WriteLine($"Logistic(x)={1/(1+Exp(-1*b))}");
if(approx(y[0],(1/(1+Exp(-1*b))),acc,eps))
	Error.WriteLine("test passed");
else
	Error.WriteLine("test failed");
Error.WriteLine($"npoints={xs.Count}");

for(int i=0;i<xs.Count;i++)
		WriteLine($"{xs[i]} {ys[i][0]}");
		
return 0;
}
}