using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
static void Main(){
 /////////////// QM-problem ///////////////
WriteLine($"/////////////// Part A - QM-problem ///////////////");
	int N=20;
	double s=1.0/(N+1);
	matrix H=new matrix(N,N);

	for(int i=0;i<N-1;i++){
		H[i,i]=-2;
		H[i,i+1]=1;
		H[i+1,i]=1;	
	}
	H[N-1,N-1]=-2;
	H=-H/s/s;

	matrix H1=H.copy();
	vector eigenvals= new vector(N);
	matrix V= new matrix(N,N);
	int sweeps=jacobi.cyclic(H1,eigenvals,V);


	H.print($"Hamilton {H.size1}x{H.size2} matrix"); WriteLine();
	WriteLine($"Number of sweeps in jacobi={sweeps}"); WriteLine();

	matrix D=(V.T*H*V);
	(D).print("Should be a diagonal matrix V.T*H*V=");WriteLine();
	eigenvals.print("Eigenvalues should equal the diagonal elements above"); WriteLine();

	matrix H2=(V*D*V.T);
	(H2).print("Check that V*D*V.T=H"); WriteLine();






	WriteLine($"k \t Calculated \t \t  Exact");
	for (int k=0; k<N/3; k++){
    	double exact = PI*PI*(k+1)*(k+1);
    	double calculated = eigenvals[k];
    	WriteLine($"{k} \t {calculated} \t {exact}");
	}

	for(int k=0;k<3;k++){
		Error.WriteLine($"{0} {0}");
		for(int i=0;i<N;i++)
			Error.WriteLine($"{(i+1.0)/(N+1)} {V[i,k]}");
		Error.WriteLine($"{1} {0}");
		Error.WriteLine();Error.WriteLine();
	}

}
}