using System;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;


class main{
static int Main(string[] args){

	double e=0,a=0,b=0,y0=0,y1=0;
	foreach(string s in args){
		string[] ws=s.Split('=');
		if(ws[0]=="e") e=double.Parse(ws[1]);
		if(ws[0]=="y0") y0=double.Parse(ws[1]);
		if(ws[0]=="y1") y1=double.Parse(ws[1]);
		if(ws[0]=="a") a=double.Parse(ws[1]);
		if(ws[0]=="b") b=double.Parse(ws[1]);
		}
	vector ya=new vector(y0,y1);

Func<double,vector,vector>
F=delegate(double x, vector y){
	return new vector(y[1],(1-y[0]+e*y[0]*y[0]));
	};

	double h=0.01,acc=1e-5,eps=1e-5;
	int limit=9999;

double phi=0;
vector yb;

for(int i=0;i<1000;i++){
		phi=(b-a)/1000*i+a;
		yb=ode.rk23(F,a,ya,phi,acc,eps,h,limit);
		WriteLine($"{phi} {yb[0]} {yb[1]}");}
		
return 0;
}
}
