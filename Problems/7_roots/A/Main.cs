using System;
using static System.Console;
class main{
static void Main(){

int n_calls=0;

// Func<vector,vector> f = delegate(vector z){
// 		n_calls++;
// 		vector r=new vector(2);
// 		double x=z[0],y=z[1];
// 		r[0]=2*x+3+y;
// 		r[1]=2*y-2+x;
// 		return r;
// 	};

Func<vector,vector> f = delegate(vector z){
		n_calls++;
		vector r=new vector(2);
		double x=z[0],y=z[1];
		r[0]=-2*(1-x)+2*100*(y-x*x)*(-2*x);
		r[1]=100*2*(y-x*x);
		return r;
	};

WriteLine($"Minimum of  Rosenbrock's valley function, by findeing roots of gradient.");

double eps=1e-4;
vector p= new vector(2);
	p[0]=10; p[1]=10;
p.print("Start point:");

vector root= roots.newton(f,p,eps);
WriteLine($"n_calls={n_calls}");
root.print("Root of f =");
f(root).print("f(root)=");
WriteLine($"eps={eps}");
WriteLine($"f(root).norm ={f(root).norm()}");
if(f(root).norm()<eps) WriteLine("Test passed");
else WriteLine("Test failed");



}//Main method
}//class