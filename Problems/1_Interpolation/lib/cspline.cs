using System;
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

	return y[i]+h*(b[i]+h*(c[i]+h*d[i]));
}

public double derivative(double z){
	int i=binary_search(z);
	double h=z-x[i];

	return b[i]+2*c[i]*h+3*d[i]*h*h;
}

//Linear intergrator
public double integral(double z){
	int i, i_max=binary_search(z);

	double area=0, h;
	for(i=0;i<i_max;i++){
		h=x[i+1]-x[i];
		area+=y[i]*h+b[i]/2*h*h+c[i]/3*h*h*h+d[i]/4*h*h*h*h;
	}
	h=z-x[i_max];
	area+=y[i_max]*h+b[i_max]/2*h*h+c[i_max]/3*h*h*h+d[i_max]/4*h*h*h*h;

	return area;

	}
}
