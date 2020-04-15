using System;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;

class main{


static Func<double,vector,vector> SIR(double N, double Tc, double Tr){
	return (x, y) => {
	vector yd= new vector(3);
	yd[0]=-y[1]*y[0]/N*Tc;
	yd[1]=y[1]*y[0]/N*Tc-y[1]/Tr;
	yd[2]=y[1]/Tr;
	return yd;
	};

	}

static void Main(){
	double a=0;
	vector ya=new vector(5600000-250,500,0);
	double b=200;
	double h=0.1, acc=1e-3, eps=1e-3;
	var xs=new List<double>();
	var ys=new List<vector>();

	double N=5600000;
	double Tc=0.15;
	double Tr=14;

vector y=ode.rk23(SIR(N,Tc,Tr),a,ya,b,acc:acc,eps:eps,h:h,xlist:xs,ylist:ys);

	for(int i=0;i<xs.Count;i++)
		WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]} {ys[i][2]}");
	WriteLine();WriteLine();

double Tc1=0.3;
vector y1=ode.rk23(SIR(N,Tc1,Tr),a,ya,b,acc:acc,eps:eps,h:h,xlist:xs,ylist:ys);
for(int i=0;i<xs.Count;i++)
		WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]} {ys[i][2]}");
	WriteLine();WriteLine();

double Tc2=0.6;
vector y2=ode.rk23(SIR(N,Tc2,Tr),a,ya,b,acc:acc,eps:eps,h:h,xlist:xs,ylist:ys);
for(int i=0;i<xs.Count;i++)
		WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]} {ys[i][2]}");

}
}