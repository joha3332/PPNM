using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
static void Main(){
	/// Test on random matrix ///
WriteLine("/////////////// Part A - Test on random matrix ///////////////");
	int n=5;
	var rand= new Random(1);

	matrix A= new matrix(n,n);
	vector e= new vector(n);
	matrix V= new matrix(n,n);
	
	
	for(int i=0;i<n;i++) for(int j=i;j<n;j++){
		A[i,j]=rand.NextDouble();
		A[j,i]=A[i,j];
	}

	A.print($"random {n}x{n} matrix"); WriteLine();
	matrix B=A.copy();
	int sweeps=jacobi.cyclic(B,e,V);
	WriteLine($"Number of sweeps in jacobi={sweeps}"); WriteLine();

	matrix D=(V.T*A*V);
	(D).print("Should be a diagonal matrix V.T*B*V=");WriteLine();
	e.print("Eigenvalues should equal the diagonal elements above"); WriteLine();

	matrix A2=(V*D*V.T);
	(A2).print("Check that V*D*V.T=A"); WriteLine();

}
}