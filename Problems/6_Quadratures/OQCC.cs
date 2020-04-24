using System;
using static System.Math;
using static System.Double;
public static partial class quad{

public static double[] OQCC(Func<double,double> f, double a, double b, double delta, double eps){
        Func<double,double> h = (x) => 1.0/2*(b-a)*f(1.0/2*(a+b)+1.0/2*(b-a)*x); 
        Func<double,double> g = (theta) => h(Cos(theta))*Sin(theta); 
        
        return adapt4(g, 0, PI, delta, eps);

}//method
}//class