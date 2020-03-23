using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
static void Main(){

//Original coordinates 
vector xo =new vector(new double[]{1  ,2  ,3 ,4 ,6 ,9   ,10  ,13  ,15  });
vector yo =new vector(new double[]{117,100,88,72,53,29.5,25.2,15.2,11.1});
vector dyo =yo/20;
var f= new Func<double,double>[]{t=>1,t=>t};
	for(int i=0;i<xo.size;i++) WriteLine($"{xo[i]}\t{yo[i]}\t{dyo[i]}");	
WriteLine();WriteLine();		//Linebreak


vector x=xo.copy();
vector y= new vector(x.size);
vector dy= new vector(x.size);

	for(int i=0;i<x.size;i++){
		y[i]=Log(yo[i]);
		dy[i]=dyo[i]/yo[i];		
	}

var fit= new lsfit(x,y,dy,f);

vector c=fit.c;					//Coefficients 
vector delta_c=fit.delta_c;		//Uncertienties of the coefficients

double lambda=c[1];
double dlambda=delta_c[1];

Error.WriteLine($"lambda={lambda:f5} ± {dlambda:f5} ");
double T= Log(0.5)/lambda;
double dT=Abs(dlambda/lambda/lambda);
Error.WriteLine($"Halvlife= {T:f1} ± {dT:f1} days");
if(T+dT>=3.6 && (T-dT)<=3.6) Error.WriteLine("Halvlife matches modern value of 3.6 days");
else Error.WriteLine("Halvlife does not match modern value of 3.6 days");


int N=1000;
double x_lnmin=x[0];
double x_lnmax=x[x.size-1];
vector x_fit= new vector(N+1);
vector y_lnfit= new vector(N+1);
vector y_fit= new vector(N+1);


for(int i=0;i<=N;i++){
	double xi=(x_lnmax-x_lnmin)/1000*i+x_lnmin;
	x_fit[i]=xi;
 	y_lnfit[i]=fit.eval(xi);
 	y_fit[i]=Exp(y_lnfit[i]);

	WriteLine($"{x_fit[i]:f5}	{y_fit[i]:f5} ");
}

}
}