using System;
public partial class roots{
public static matrix jacobian(Func<vector,vector> f,vector x, vector fx=null, double dx=1e-7)
{
	int n=x.size;
	matrix J= new matrix(n,n);
	if(fx==null) fx=f(x);
	for(int k=0; k<n; k++)
	{
		x[k]+=dx;
		vector df=f(x)-fx;
		x[k]-=dx;

		for(int i=0; i<n; i++) J[i,k]=df[i]/dx;
	}

	return J;
}
}//class