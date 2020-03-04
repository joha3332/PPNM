using static System.Math;
using static System.Console;
class main{

const double inf=double.PositiveInfinity;
static int Main(){

	double E,A,acc,eps;
	acc=1e-6; eps=1e-6;
	System.Func<double,double> YHY;
	System.Func<double,double> YY;

	
	// YHY = delegate(double x){return (a*a*x*x-a+x*x)/2*Exp(-a*x*x);};
	// YY = delegate(double x){return Exp(-a*x*x)/2;};
	double da=1.0/32, offset=1.0/64;


	for(double a=offset;a<5;a+=da){
			YHY = delegate(double x){return (-a*a*x*x+a+x*x)/2*Exp(-a*x*x);};
			YY = delegate(double x){return Exp(-a*x*x);};

			E=quad.o8av(YHY,-inf,inf,acc,eps);
			A=quad.o8av(YY,-inf,inf,acc,eps);
			WriteLine($"{a}	{E/A}");	
		}
	
	

	return 0;
}}
