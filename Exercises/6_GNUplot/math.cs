using static System.Console;
using static System.Math;
using static cmath;
public static class math{

	public static double gamma(double x)
	{
		if (x<0) return PI/Sin(PI*x)/(gamma(1-x));
		if (x<9) return gamma(x+1)/x;
		double lngamma=x*Log(x+1/(12*x-1/10/x))-x+Log(2*PI/x)/2;
		return	Exp(lngamma);
	}

	public static double erf(double x)
	{
		if (x<0) return -erf(-x);
		double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
		double t=1/(1+0.3275911*x);
		double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));
		return 1-sum*Exp(-x*x);
	}




	public static double lngamma(double x)
	{
		if (x<0) return log(PI)-log(Sin(PI*x))-lngamma(1-x);
		if (x<9) return lngamma(x+1)-log(x);
		double z=x*Log(x+1/(12*x-1/10/x))-x+Log(2*PI/x)/2;
		return z;
		
	}

	public static complex cgamma(complex x)
	{
		if (x.Re<0) return PI/sin(PI*x)/(cgamma(1-x));
		if (x.Re<9) return cgamma(x+1)/x;
		complex lngamma=x*log(x+1/(12*x-1/10/x))-x+log(2*PI/x)/2;
		return	exp(lngamma);
	}


	public static complex lngamma(complex x)
	{
		if (x.Re<0) return log(PI)-log(sin(PI*x))-lngamma(1-x);
		if (x.Re<99) return lngamma(x+1)-log(x);
		//complex z=x*log(x+1/(12*x-1/10/x))-x+log(2*PI/x)/2;
		complex z=x*log(x)-x+log(2*PI/x)/2;
		return z;
		
	}

}
