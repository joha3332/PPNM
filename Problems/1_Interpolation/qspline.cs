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

public double eval(double z){
	int i=0, j=x.size-1;							// Find the datapoints that z lies between
		while(j-i>1){
			int m=(i+j)/2;
			if (z>x[m]) i=m; 
			else j=m;}

	return y[i]+b[i]*(z-x[i])+c[i]*(z-x[i])*(z-x[i]);
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
