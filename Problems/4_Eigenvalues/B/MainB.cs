using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;


class main{
static void Main(){
	/// Test on random matrix ///
WriteLine("/////////////// Part B - test of row by row method///////////////");

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

	int reps=jacobi_row.row(B,e,n,V);
	WriteLine($"Number of repititions in jacobi={reps}"); WriteLine();
	

	matrix D=(V.T*A*V);
	(D).print("Should be a diagonal matrix V.T*B*V=");WriteLine();
	e.print("Eigenvalues should equal the diagonal elements above"); WriteLine();

	matrix A2=(V*D*V.T);
	(A2).print("Check that V*D*V.T=A"); WriteLine();



WriteLine("/////////////// Find only the higest eigen values///////////////");

	vector e1= new vector(n);
	matrix V1= new matrix(n,n);
	string order= "high";

	A.print($"random {n}x{n} matrix"); WriteLine();
	matrix C=A.copy();

	int reps1=jacobi_row.row(C,e1,2,V1,order);
	WriteLine($"Number of repititions in jacobi={reps1}"); WriteLine();
	

	matrix D1=(V1.T*A*V1);
	(D1).print("First two diagonal elements should be the two higest eigenvalues");
}
}