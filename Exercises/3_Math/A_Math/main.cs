using System;
using static System.Console;
using static System.Math;
using static cmath;
class main{
	static int Main(){
		complex I = new complex(0,1);
		WriteLine($"sqrt(2)={sqrt(2)}");
		WriteLine($"exp(I)={exp(I)}");
		WriteLine($"exp(PI*I)={exp(PI*I)}");
		complex ii = I*I;
		WriteLine($"I*I={ii}");
		WriteLine($"sin(I*PI)={sin(I*PI)}");
	return 0;
	}
}
