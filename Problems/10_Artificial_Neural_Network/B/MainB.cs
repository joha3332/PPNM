using System;
using static System.Math;
using static System.Console;
class mainB{
static Func<double,double> g= (x)=>Sin(x); //Function to fit

static void Main(){
	int n=15; //hidden nodes
	var nn= new neuralnet(n);

	double x_start=0;
	double x_end=2*PI;
	int nx=25;
	var xs=new double[nx];
	var ys=new double[nx];
	
	WriteLine("Sampled points of test function:");
	for(int i=0; i<nx;i++){
		xs[i]= (x_end-x_start)/(nx-1)*i + x_start;
		ys[i]= g(xs[i]);

		WriteLine($"{xs[i]} \t {ys[i]}");
	}
	Write("\n\n");

	//initial parameters
	for(int i=0; i<n;i++){
		nn.parameters[3*i]= (x_end-x_start)/n*i + x_start;
		nn.parameters[3*i+1]= 1;
		nn.parameters[3*i+2]= 1;
	}
	nn.parameters.print("Initial parameters=");

	nn.train(xs,ys);
	nn.parameters.print("Post training parameters =");
	Write("\n\n");


	int n_interpol=100; //number of interpolated points
	double x, y, y_der, y_int;
	WriteLine("Interpolated points of test function:");
	for(int i=0; i<=n_interpol;i++){
		x=(x_end-x_start)/n_interpol*i + x_start;
		y=nn.feed(x);
		y_der=nn.feed_der(x);
		y_int=nn.feed_int(x,0);
		WriteLine($"{x} \t {y} \t {y_der} \t {y_int}");
	}


}
}