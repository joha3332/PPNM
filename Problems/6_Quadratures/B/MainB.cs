using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	int calls=0;
	double a=0 , b=1, acc=1e-3, eps=1e-3;
	
	Func<double,double> f=delegate(double x){
		calls++;
		return 1/Sqrt(x);
		};
	WriteLine($"Integral from {a} to {b} of 1/Sqrt(x), acc={acc} eps={eps}");
	double exact=2;
	double[] q=quad.OQCC(f,a,b,acc,eps);
	double Q=q[0],err=q[1], real_err=Abs(Q-exact), tol=acc+eps*Abs(Q);
	WriteLine($"result {Q} \t calls {calls}");
	WriteLine($"exact result {exact}");
	WriteLine($"Tolerance {tol} \t Error estimate {err} \t Real error {real_err}");

	if(real_err<err && err<tol)WriteLine("test passed\n");
	else WriteLine("test failed\n");


 calls=0; a=0; b=1; acc=1e-3; eps=1e-3;	
	f=delegate(double x){
		calls++;
		return Log(x)/Sqrt(x);
		};
	WriteLine($"Integral from {a} to {b} of Log(x)/Sqrt(x), acc={acc} eps={eps}");
	exact=-4;
	q=quad.OQCC(f,a,b,acc,eps);
	Q=q[0]; err=q[1]; real_err=Abs(Q-exact); tol=acc+eps*Abs(Q);
	WriteLine($"result {Q} \t calls {calls}");
	WriteLine($"exact result {exact}");
	WriteLine($"Tolerance {tol} \t Error estimate {err} \t Real error {real_err}");

	if(real_err<err && err<tol)WriteLine("test passed\n");
	else WriteLine("test failed\n");
WriteLine("_________________________________________________________");

 calls=0; a=0; b=1; acc=1e-16; eps=1e-16;	
	f=delegate(double x){
		calls++;
		return 4*Sqrt(1-x*x);
		};
	WriteLine($"Integral from {a} to {b} of 4*Sqrt(1-x*x), acc={acc} eps={eps}");
	exact=PI;
	double[] q_CC=quad.OQCC(f,a,b,acc,eps);
	double calls_CC=calls;
	double Q_CC=q_CC[0];
	double err_CC=q_CC[1];
	double real_err_CC=Abs(Q_CC-exact); 
	double tol_CC=acc+eps*Abs(Q_CC);

	WriteLine($"exact result {exact}");WriteLine();
	WriteLine($"By Clenshaw–Curtis method");
	WriteLine($"Result {Q_CC} \t calls {calls_CC}");
	WriteLine($"Tolerance {tol_CC} \t Error estimate {err_CC} \t Real error {real_err_CC}");
	WriteLine();

	calls=0;
	double[] q_a4=quad.adapt4(f,a,b,acc,eps);
	double calls_a4=calls;
	double Q_a4=q_a4[0];
	double err_a4=q_a4[1];
	double real_err_a4=Abs(Q_a4-exact);
	double tol_a4=acc+eps*Abs(Q_a4);

	WriteLine($"By adaptive order 4");
	WriteLine($"result {Q_a4} \t calls {calls_a4}");
	WriteLine($"Tolerance {tol_a4} \t Error estimate {err_a4} \t Real error {real_err_a4}");	
	WriteLine();

	calls=0;
	double Q_o8av = quad.o8av(f,a,b,acc,eps);
	double calls_o8av=calls;
	WriteLine($"By o8av");
	WriteLine($"result {Q_o8av} \t calls {calls_o8av}");

	WriteLine("All algorithems can calculate the value of the integral up to a machine epsilon.");
	WriteLine("However Clenshaw–Curtis requires more function evaluations, while o8av, can do with the least.");

}//Method: Main
}//class: main