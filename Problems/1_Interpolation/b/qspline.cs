using System;
using static System.Console;
using static System.Math;
using System.IO;
using System.Diagnostics;


public class qspline{
vector x,y,b,c;

// Quadratic interpolate a point z
public qspline(vector xtable, vector ytable){

	int n=xtable.size;

	x = xtable.copy();
	y = ytable.copy();
	b = new vector(n-1);
	c = new vector(n-1);

	vector p = new vector(n-1);
	vector h = new vector(n-1);


	for(int i=0; i<n-1;i++){
		h[i]=x[i+1]-x[i];
		p[i]=(y[i+1]-y[i])/h[i];}

	c[0]=0;
	for(int i=0; i<n-2;i++){
		c[i+1]=(p[i+1]-p[i]-c[i]*h[i])/h[i+1];}


	c[n-2]/=2;
	for(int i=n-3; i>=0;i--){
		c[i]=(p[i+1]-p[i]-c[i+1]*h[i+1])/h[i];}

	
	for(int i=0; i<n-1;i++){
		b[i]=(p[i]-c[i]*h[i]);}
}

public int binary_search(double z){
	int i=0, j=x.size-1;					// Find the datapoints that z lies between
	Debug.Assert(z>=x[0] && z<=x[j]);
		while(j-i>1){
			int m=(i+j)/2;
			if (z>x[m]) i=m; 
			else j=m;}
	return i;								//return the point that z follows
}

public double eval(double z){
	int i=binary_search(z);
	double h=z-x[i];

	return y[i]+b[i]*h+c[i]*h*h;
}

public double derivative(double z){
	int i=0, j=x.size-1;							// Find the datapoints that z lies between
		while(j-i>1){
			int m=(i+j)/2;
			if (z>x[m]) i=m; 
			else j=m;}

	return b[i]+2*c[i]*(z-x[i]);
}

//Linear intergrator
public double integral(double z){
	int i=0, j=x.size-1;							// Find the datapoints that z lies between
		while(j-i>1){
			int m=(i+j)/2;
			if (z>x[m]) i=m; 
			else j=m;}
	int i_max=i;
	
	double area=0, dx;
	for(i=0;i<i_max;i++){
		dx=x[i+1]-x[i];
		area+=y[i]*dx+b[i]/2*dx*dx+c[i]/3*dx*dx*dx;
	}
	dx=z-x[i_max];
	area+=y[i_max]*dx+b[i_max]/2*dx*dx+c[i_max]/3*dx*dx*dx;

	return area;
	}
}
