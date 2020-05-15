using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){

// Test on Cos
Func<vector, double> f = (x)=> Cos(x[0]);
vector x_start= new vector(3.0);
double acc= 1e-6;

vector x_res = qnewton.sr1(f, x_start, acc);

WriteLine("Minimization of Cos(x)");
WriteLine($"Starting point: \t {x_start[0]}");
WriteLine($"Minimum found at \t {x_res[0]}");
WriteLine($"Function value at minimum \t {f(x_res)}");
WriteLine($"Accurecy goal: \t {acc}");
WriteLine($"Deviation from exact: \t {x_res[0]-PI}");
if(Abs(x_res[0]-PI)<acc)WriteLine("test passed");
else            WriteLine("test failed");
Write("\n\n");


// Test on Rosenbrock
Func<vector, double> R = (x)=> (1-x[0])*(1-x[0])+100*(x[1]-x[0]*x[0])*(x[1]-x[0]*x[0]);
x_start= new vector(2);
	x_start[0]=3;
	x_start[1]=3;
acc= 1e-6;

x_res = qnewton.sr1(R, x_start, acc);
vector x_exact= new vector(2);
	x_exact[0]=1;
	x_exact[1]=1;

WriteLine("Minimization of Rosenbrock");
x_start.print("Starting point:");
x_res.print($"Minimum found at");
x_exact.print($"Exact minimum at");
WriteLine($"Function value at minimum \t {R(x_res)}");
WriteLine($"Accurecy goal: \t {acc}");
WriteLine($"Deviation from exact: \t {(x_res-x_exact).norm()}");
if((x_res-x_exact).norm()<acc)WriteLine("test passed");
else            WriteLine("test failed");
Write("\n\n");


// Test on Himmelblau
Func<vector, double> H = (x)=> 
(x[0]*x[0]+x[1]-11)*(x[0]*x[0]+x[1]-11) + (x[0]+x[1]*x[1]-7)*(x[0]+x[1]*x[1]-7);
x_start= new vector(2);
	x_start[0]=-1;
	x_start[1]=-1;
acc= 1e-6;

x_res = qnewton.sr1(H, x_start, acc);
x_exact= new vector(2);
	x_exact[0]=-3.779310;
	x_exact[1]=-3.283186;

WriteLine("Minimization of Himmelblau");
x_start.print("Starting point:");
x_res.print($"Minimum found at");
x_exact.print($"Exact minimum at");
WriteLine($"Function value at minimum \t {H(x_res)}");
WriteLine($"Accurecy goal: \t {acc}");
WriteLine($"Deviation from exact: \t {(x_res-x_exact).norm()}");
if((x_res-x_exact).norm()<acc)WriteLine("test passed");
else            WriteLine("test failed");

}// Method: Main
}// Class: main
