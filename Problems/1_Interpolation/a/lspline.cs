using System;
using static System.Console;
using static System.Math;
using System.IO;
using System.Diagnostics;


public static class lspline{

// Linear interpolate a point z
public static double eval(vector x, vector y, double z){
	int n=x.size;
	Debug.Assert(n>1 && z>x[0] && z<x[n-1]); // Check if the interpolation point is the data range 
	
	int i=0, j=n-1;							// Find the datapoints that z lies between
		while(j-i>1){
			int m=(i+j)/2;
			if (z>x[m]) i=m; 
			else j=m;}

	return y[i]+(y[i+1]-y[i])/(x[i+1]-x[i])*(z-x[i]);		//Linear interpolation between the two points
	}

//Linear intergrator
public static double integral(vector x, vector y, double z){
	int n=x.size;
	Debug.Assert(n>1 && z>=x[0] && z<=x[n-1]);	// Check if the interpolation point is the data range			
	
	int N=999;
	double area=0;
        for(int i=0;i<N;i++){
        	double a=(z-x[0])/N*i+x[0];			// Left side
            double b=(z-x[0])/N*(i+1)+x[0];		// right side
            double ya=lspline.eval(x,y,a);		// Y for left point
            double yb=lspline.eval(x,y,b);		// Y for right point
            area=area+(ya+yb)/2*(b-a);			// Rectangle area of avarge height
        }
    return area;
	}
}