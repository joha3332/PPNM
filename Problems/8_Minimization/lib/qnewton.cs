using System;
using static System.Console;
using static System.Math;
public class qnewton{

public static double eps= 1e-10;

public static vector gradient( Func<vector,double> f, vector x){
	vector g=new vector(x.size);
	double fx=f(x);
	for(int i=0;i<x.size;i++){
		double dx=Abs(x[i])*eps;
		if(dx<Sqrt(eps)) dx=eps;
		x[i]+=dx;
		g[i]=(f(x)-fx)/dx;
		x[i]-=dx;
	}
	return g;
}//Method: gradient



public static vector sr1(Func<vector,double> f, vector x, double acc=1e-6){
	double fx=f(x);
	vector gx=gradient(f,x);
	matrix B=matrix.id(x.size);
	int nsteps=0;

	while(nsteps<999){
		nsteps++;
		vector delta_x=-B*gx;
		if(delta_x.norm()<eps*x.norm()){
			Error.WriteLine($"broyden: |delta_x|<eps*|x|");
			break;}
		if(gx.norm()<acc){
			Error.WriteLine($"broyden: |gx|<acc");		
			break;}

		double fz, lambda=1, alpha=1e-4;
		vector z, s;
		while(true){
			s=delta_x*lambda;
			z=x+s;
			fz=f(z);
			if(fz<fx+alpha*s.dot(gx)){break;} 					//Stop if step is good
			if(lambda<eps){B.setid(); break;} 	//If step is too small: reset B and stop
			lambda/=2;
		}

		vector gz=gradient(f,z);
		vector y=gz-gx;
		vector u=s-B*y;

		if(Abs(u.dot(y))>1e-6) B+= matrix.outer(u,u)/(u.dot(y));
		x=z;
		gx=gz;
		fx=fz;
	}
	WriteLine($"nsteps={nsteps}");

	return x;
	

}//Method: sr1

} //Class: qnewton
	