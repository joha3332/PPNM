using System;
using static System.Console;
public partial class roots{

public static vector newton(Func<vector,vector> f,
	vector x, double eps=1e-3, double dx=1e-7)
{
	double n=x.size;
	vector fx=f(x),z,fz;

	while(true){
		matrix J=jacobian(f,x,fx);
		var qrJ= new gs(J);
		matrix B= qrJ.inverse();
		vector Delta_x=-B*fx; //the newton step
		
		double lambda=1;
		while(true){
			z=x+lambda*Delta_x;
			fz=f(z);
			if(fz.norm()<(1-lambda/2)*fx.norm()) break;		//stop if the step is good
			else if(lambda<1.0/32) break;		//stop if minimum stepsize is reached
			else lambda/=2;						//backtrack by making a half step
		}
		x=z;
		fx=fz;
		if(fx.norm()<eps) break; //stop if tolerance is reached
		else if(x.norm()<dx) break;

	}
	return x;
}// method Newton
}// class roots