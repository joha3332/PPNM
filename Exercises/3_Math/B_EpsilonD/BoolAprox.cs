using System;
using static System.Math;

public static class BoolAprox
{
   public static bool boolAprox(double a, double b, double abserr = 1e-9, double relerr = 1e-9)
    {
        if (Abs(a - b) < abserr) { return true; }
        else if (Abs(a - b)/(Abs(a)+Abs(b)) < relerr/2) { return true; }
        else return false;
       
    }
}
