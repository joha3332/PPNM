using System;
using static System.Math;
using static System.Console;
public class neuralnet{

public vector parameters;
static Func<double,double> f= (x)=> x*Exp(-x*x); //Activation function
static Func<double,double> f_der= (x)=> (1-2*x*x)*Exp(-x*x); //Derivative activation function
static Func<double,double> f_int= (x)=> -Exp(-x*x)/2; //Integral activation function
public int n;

//Class constructor:
public neuralnet(int nodes){
	n=nodes;
	parameters= new vector(3*n);
}

public double feed(double x){
	double value_sum=0;
	for(int i=0;i<n;i++){
		double ai=parameters[3*i];
		double bi=parameters[3*i+1];
		double wi=parameters[3*i+2];
		value_sum+=wi*f((x-ai)/bi);
	}
	return value_sum;
} //method:feed

public double feed_der(double x){
	double der_sum=0;
	for(int i=0;i<n;i++){
		double ai=parameters[3*i];
		double bi=parameters[3*i+1];
		double wi=parameters[3*i+2];
		der_sum+=wi/bi*f_der((x-ai)/bi);}
	return der_sum; } //method:feed_der

public double feed_int(double x,double x_low){
	double int_sum=0;
	for(int i=0;i<n;i++){
		double ai=parameters[3*i];
		double bi=parameters[3*i+1];
		double wi=parameters[3*i+2];
		int_sum+=wi*bi*f_int((x-ai)/bi);
		//subtracting the lower boundery of the integral
		int_sum-=wi*bi*f_int((x_low-ai)/bi);}
	return int_sum; } //method:feed_int



public void train(double[] xs, double[] ys){
	int calls=0;
	Error.WriteLine("STARTING TRAINING");

	Func<vector,double> diviation = (u) =>{

		calls++;
		parameters=u;
		double diviation_sum=0;

		for(int i=0;i<xs.Length;i++){
			diviation_sum+=(ys[i]-feed(xs[i]))*(ys[i]-feed(xs[i]));
		}

		Error.WriteLine($"Diviation = {diviation_sum/xs.Length}");
		return diviation_sum/xs.Length;

	};//func:diviation

	vector v=parameters;
	parameters=qnewton.sr1(diviation,v,1e-6);

	Error.WriteLine($"calls={calls}");
} //method:train


} //class: neuralnet