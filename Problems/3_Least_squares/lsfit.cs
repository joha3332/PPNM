using System;
using static System.Math;
public class lsfit{
public vector c;			//coefficients
public matrix sigma;		//covariance matrix
public Func<double,double>[] f;
public vector delta_c;		//uncertainties

public lsfit(vector x, vector y, vector dy, Func<double,double>[] fs){
	f=fs;
	int n=x.size;
	int m=fs.Length;
	matrix A= new matrix(n,m);
	vector b= new vector(n);
	for(int i=0;i<n;i++){
		b[i]=y[i]/dy[i];
		for(int k=0; k<m;k++)A[i,k]=f[k](x[i])/dy[i];
	}
	var qra=new gs(A);
	c=qra.solve(b);
	matrix A_inv=qra.inverse();
	sigma=A_inv*A_inv.T;


	vector delta= new vector(m);
	for(int i=0;i<m;i++)	delta[i]=Sqrt(sigma[i,i]);
	delta_c=delta;
}
public double eval(double x_eval){
	double y_eval=0;
	for(int i=0;i<f.Length;i++) y_eval+=c[i]*f[i](x_eval);
	return y_eval;
}


}