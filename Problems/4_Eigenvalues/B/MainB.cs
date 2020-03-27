using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;


class main{
static void Main(){
	/// Test on random matrix ///
WriteLine("/////////////// Part B - Elapsed time for n*n matrix ///////////////");
WriteLine($"Elapsed time for row by row method");
WriteLine($"n \t runtime \t reps");
	for(int n=5;n<100;n+=5){
	var rand= new Random(1);

	matrix A= new matrix(n,n);
	vector e= new vector(n);
	matrix V= new matrix(n,n);
	
	
	for(int i=0;i<n;i++) for(int j=i;j<n;j++){
		A[i,j]=rand.NextDouble();
		A[j,i]=A[i,j];
	}

	//A.print($"random {n}x{n} matrix"); WriteLine();
	matrix B=A.copy();

	Stopwatch row_time = new Stopwatch();
	row_time.Start();
	int reps=jacobi_row.row(B,e,n,V);
	//WriteLine($"Number of repititions in jacobi={reps}"); WriteLine();
	row_time.Stop();

	//matrix D=(V.T*A*V);
	//(D).print("Should be a diagonal matrix V.T*B*V=");WriteLine();
	//e.print("Eigenvalues should equal the diagonal elements above"); WriteLine();

	//matrix A2=(V*D*V.T);
	//(A2).print("Check that V*D*V.T=A"); WriteLine();

	
	WriteLine($"{n} \t {row_time.ElapsedMilliseconds} \t {reps}");
	}
}
}