using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	int calls=0;
	double a=0 , b=1, acc=1e-3, eps=1e-3;
	
	Func<double,double> f=delegate(double x){
		calls++;
		return Sqrt(x);
		};
	WriteLine($"Integral from {a} to {b} of Sqrt(x), acc={acc} eps={eps}");
	double exact=2.0/3;
	double[] q=quad.adapt4(f,a,b,acc,eps);
	double Q=q[0],err=q[1], real_err=Abs(Q-exact), tol=acc+eps*Abs(Q);
	WriteLine($"result {Q} \t calls {calls}");
	WriteLine($"exact result {exact}");
	WriteLine($"Tolerance {tol} \t Error estimate {err} \t Real error {real_err}");

	if(real_err<err && err<tol)WriteLine("test passed\n");
	else WriteLine("test failed\n");


 calls=0; a=0; b=1; acc=1e-6; eps=0;	
	f=delegate(double x){
		calls++;
		return 4*Sqrt(1-x*x);
		};
	WriteLine($"Integral from {a} to {b} of 4*Sqrt(1-x^2) dx, acc={acc} eps={eps}");
	exact=PI;
	q=quad.adapt4(f,a,b,acc,eps);
	Q=q[0]; err=q[1]; real_err=Abs(Q-exact); tol=acc+eps*Abs(Q);
	WriteLine($"result {Q} \t calls {calls}");
	WriteLine($"exact result {exact}");
	WriteLine($"Tolerance {tol} \t Error estimate {err} \t Real error {real_err}");

	if(real_err<err && err<tol)WriteLine("test passed\n");
	else WriteLine("test failed\n");	


}//Method: Main
}//class: main