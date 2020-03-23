using System;
using static System.Console;
using static System.Math;
using System.IO;
using System.Diagnostics;


public class cspline{
vector x,y,b,c,d;

// Quadratic interpolate a point z
public cspline(vector xtable, vector ytable){

	int n=xtable.size;

	x = xtable.copy();
	y = ytable.copy();
	b = new vector(n);
	c = new vector(n-1);
	d = new vector(n-1);

	vector p = new vector(n-1);
	vector h = new vector(n-1);

	for(int i=0; i<n-1;i++){
		h[i]=x[i+1]-x[i];
		Debug.Assert(h[i]>0);
		p[i]=(y[i+1]-y[i])/h[i];
	}

	vector D = new vector(n);
	vector Q = new vector(n-1);
	vector B = new vector(n);

	D[0]	= 2;
	D[n-1]	= 2;
	Q[0]	= 1;
	B[0]	= 3*p[0];
	B[n-1]	= 3*p[n-2];


	for(int i=0; i<n-2;i++){
		D[i+1]	= 2*h[i]/h[i+1]+2;
		Q[i+1]	= h[i]/h[i+1];
		B[i+1]	= 3*(p[i]+p[i+1]*h[i]/h[i+1]);
	}

	for(int i=1; i<n;i++){
		D[i]	=D[i] -  Q[i-1]/D[i-1];
		B[i]	=B[i] -  B[i-1]/D[i-1];
	}

	b[n-1]=B[n-1]/D[n-1];
	for(int i=n-2; i>=0;i--){
		b[i]	= (B[i]-Q[i]*b[i+1])/D[i];
	}

	for(int i=0; i<n-1;i++){
		c[i]	= (-2*b[i]-b[i+1]+3*p[i])/h[i];
		d[i]	= (b[i]+b[i+1]-2*p[i])/h[i]/h[i];
	}
}

public double eval(double z){
	int n=x.size;
	Debug.Assert(z>=x[0] && z<=x[n-1]);
	int i=0, j=n-1;							// Find the datapoints that z lies between
		while(j-i>1){
			int m=(i+j)/2;
			if (z>x[m]) i=m; 
			else j=m;}

	double h=z-x[i];

	return y[i]+h*(b[i]+h*(c[i]+h*d[i]));
}

public double derivative(double z){
	double sigma=1.0/1000;
	double slope_z=(eval(z+sigma)-eval(z-sigma))/(2*sigma);

	return slope_z;
}

//Linear intergrator
public double integral(double z){
	int N=999;
	double area=0;
        for(int i=0;i<N;i++){
        	double a=(z-x[0])/N*i+x[0];			// Left side
            double b=(z-x[0])/N*(i+1)+x[0];		// right side
            double ya=eval(a);		// Y for left point
            double yb=eval(b);		// Y for right point
            area=area+(ya+yb)/2*(b-a);			// Rectangle area of avarge height
        }
    return area;

	}
}
