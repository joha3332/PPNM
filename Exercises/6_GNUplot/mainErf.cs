using static System.Console;
using static System.Math;
class mainErf{
	static int Main()
	{
		double dx=1.0/32;

		for(double x=-4;x<4;x+=dx){
			WriteLine("{0,10:f3}	{1,15:f8}",x,math.erf(x));	
		}

		
		Error.WriteLine("3,5	0,999999257");
		Error.WriteLine("2,5	0,999593048");
		Error.WriteLine("1,5	0,966105146");
		Error.WriteLine("1,0	0,842700793");
		Error.WriteLine("0,5	0,520499878");
		Error.WriteLine("0,0	0,0");
		
		


	return 0;
	}

}