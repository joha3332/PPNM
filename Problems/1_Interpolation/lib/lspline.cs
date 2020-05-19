using System;
using System.Diagnostics;


public class lspline{
vector x,y,a;

// Quadratic interpolate a point z
public lspline(vector xtable, vector ytable){

	int n=xtable.size;

	x = xtable.copy();
	y = ytable.copy();
	a = new vector(n-1);

	for(int i=0;i<n-1;i++)
		a[i]=(y[i+1]-y[i])/(x[i+1]-x[i]);
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

// Linear interpolate a point z
public double eval(double z){
	int i=binary_search(z);
	double h=z-x[i];

	return y[i]+a[i]*h;		//Linear interpolation between the two points
	}

//Linear intergrator
public double integral(double z){
	int n=x.size;
	Debug.Assert(n>1 && z>=x[0] && z<=x[n-1]);	// Check if the interpolation point is the data range			
	
	int i_max=binary_search(z);
	double area=0.0, dx;

	for(int i=0;i<i_max;i++){
		dx=x[i+1]-x[i];
		area+=y[i]*dx+a[i]/2*dx*dx;
	}
	dx=z-x[i_max];
	area+=y[i_max]*dx+a[i_max]/2*dx*dx;

	return area;
	}
}