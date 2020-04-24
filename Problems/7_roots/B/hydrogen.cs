using System;
public class hydrogen{

public static double F_e(double e,double r){
	double rmin=1e-3;
	if(r<rmin) return r-r*r;

	Func<double,vector,vector> s_wave = delegate(double x,vector y){
		//return new vector(y[1],-2*(e*y[0]+y[1]/x));
		return new vector(y[1],-2*(e*y[0]+y[0]/x));
	};
	
	vector y_rmin= new vector(rmin-rmin*rmin, 1-2*rmin);
	vector y_rmax= ode.rk23(s_wave,rmin,y_rmin,r,h:0.001);
	return y_rmax[0];

}// F_e
}//class: hydrogen