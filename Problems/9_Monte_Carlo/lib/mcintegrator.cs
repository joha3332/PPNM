using System;
using static System.Console;
using static System.Math;
public class mcintegrator{

public static vector plainmc(vector a, vector b, Func<vector,double> f, int N){
	int dim=a.size;
	var rnd= new Random();

	Action<vector> randomx = delegate(vector v) {
		for(int i=0; i<dim;i++){	
			v[i]=a[i]+(b[i]-a[i])*rnd.NextDouble();}
	};


	double V=1;
	for(int i=0; i<dim;i++) {V*=b[i]-a[i];}

	double sum=0, sum2=0, fx;
	vector x= new vector(dim);

	for(int i=0; i<N;i++){
		randomx(x);
		fx=f(x);
		sum+=fx;
		sum2+=fx*fx;		
	}
	double avr=sum/N;
	double var=sum2/N-avr*avr;
	double result=avr*V;
	double error= Sqrt(var/N)*V;

	return new vector(result, error);;
}// methode: plainmc

}// class mcintegrator