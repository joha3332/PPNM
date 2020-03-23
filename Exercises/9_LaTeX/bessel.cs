using System;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;


class main{
static int Main(string[] args){

	double n=0,a=0,b=0,y0=0,y1=0;
	foreach(string s in args){
		string[] ws=s.Split('=');
		if(ws[0]=="n") n=double.Parse(ws[1]);
		if(ws[0]=="y0") y0=double.Parse(ws[1]);
		if(ws[0]=="y1") y1=double.Parse(ws[1]);
		if(ws[0]=="a") a=double.Parse(ws[1]);
		if(ws[0]=="b") b=double.Parse(ws[1]);
		}
	vector ya=new vector(y0,y1);

Func<double,vector,vector>
F=delegate(double x, vector y){
	return new vector(y[1],(-x*y[1]-(x*x-n*n)*y[0])/x/x);
	};

	double h=0.01,acc=1e-5,eps=1e-5;
	var xs=new List<double>();
	var ys=new List<vector>();
	int limit=9999;

ode.rk23(F,a,ya,b,acc,eps,h,limit,xlist:xs,ylist:ys);


for(int i=0;i<xs.Count;i++)
		WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
		
return 0;
}
}
