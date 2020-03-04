using static System.Math;
using static System.Console;
class main{

const double inf=double.PositiveInfinity;
static int Main(){

	int ncalls=0,ierr=0;
	double q,exact,acc,eps;
	acc=1e-6; eps=1e-6;
	System.Func<double,double> f;

// A1
	exact = -4;
	WriteLine($"o8av: testing integral form 0 to 1 of: ln(x)/sqrt(x)={exact}, acc={acc}, eps={eps}");
	f = delegate(double x){ ncalls++; return Log(x)/Sqrt(x);};
	ncalls=0; q=quad.o8av(f,0,1,acc,eps);
	WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}

// A2
	exact = Sqrt(PI);
	WriteLine($"o8av: testing integral form -inf to inf of: exp(-x^2)={exact}, acc={acc}, eps={eps}");
	f = delegate(double x){ ncalls++; return Exp(-Pow(x,2));};
	ncalls=0; q=quad.o8av(f,-inf,inf,acc,eps);
	WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}

// A3
	double p=5;
	exact = 5*4*3*2*1;
	WriteLine($"o8av: testing integral form 0 to 1 of: (ln(x))^p={exact}, for p=5, acc={acc}, eps={eps}");
	f = delegate(double x){ ncalls++; return Pow(Log(1/x),p);};
	ncalls=0; q=quad.o8av(f,0,1,acc,eps);
	WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}

// B1
	exact = Sqrt(PI)/2;
	WriteLine($"o8av: testing integral form 0 to inf of: sqrt(x)*exp(-x)={exact}, acc={acc}, eps={eps}");
	f = delegate(double x){ ncalls++; return Sqrt(x)*Exp(-x);};
	ncalls=0; q=quad.o8av(f,0,inf,acc,eps);
	WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}

// B2
	exact = 0.7834305107;
	WriteLine($"o8av: testing integral form 0 to 1 of: x^x={exact}, acc={acc}, eps={eps}");
	f = delegate(double x){ ncalls++; return Pow(x,x);};
	ncalls=0; q=quad.o8av(f,0,1,acc,eps);
	WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}

// B3
	exact = PI*PI/6;
	WriteLine($"o8av: testing integral form 0 to inf of: x/(exp(x)-1)={exact}, acc={acc}, eps={eps}");
	f = delegate(double x){ ncalls++; return x/(Exp(x)-1);};
	ncalls=0; q=quad.o8av(f,0,inf,acc,eps);
	WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}


return 0;
}
}
