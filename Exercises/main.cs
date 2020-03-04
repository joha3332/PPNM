using static System.Console;
using static System.Math;
class mainGamma{
	static int Main()
	{
		double offset=1.0/64,  dx=1.0/32;

		for(double x=-5+offset;x<5;x+=dx){
			WriteLine("{0,10:f3}	{1,15:f8}",x,math.gamma(x));	
		}

		double xf=1;
		for(double x=1;x<5;x+=1){
			Error.WriteLine("{0,10:f3}	{1,15:f8}",x,xf);
			xf=xf*(x);
		}


	return 0;
	}

}