using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;


class main{
static void Main(){
	/// Test on random matrix ///
// WriteLine("/////////////// Part B - Elapsed time for n*n matrix ///////////////");
// WriteLine($"Elapsed time for row by row method of frst eigenvalue");
// WriteLine($"n \t runtime \t reps");
	WriteLine();WriteLine();
for(int n=40;n<200;n+=5){
	var rand= new Random(1);

	matrix A= new matrix(n,n);
	vector e= new vector(n);
	matrix V= new matrix(n,n);
	
	
	for(int i=0;i<n;i++) for(int j=i;j<n;j++){
		A[i,j]=rand.NextDouble();
		A[j,i]=A[i,j];
	}

	matrix B=A.copy();
	Stopwatch row_time = new Stopwatch();
	row_time.Start();
	int reps=jacobi_row.row(B,e,1,V);
	row_time.Stop();


	
	WriteLine($"{n} \t {row_time.ElapsedMilliseconds} \t {reps}");
}

// WriteLine($"Elapsed time for row by row method");
// WriteLine($"n \t runtime \t reps");
	WriteLine();WriteLine();
for(int n=40;n<101;n+=5){
	var rand= new Random(1);

	matrix A= new matrix(n,n);
	vector e= new vector(n);
	matrix V= new matrix(n,n);
	
	
	for(int i=0;i<n;i++) for(int j=i;j<n;j++){
		A[i,j]=rand.NextDouble();
		A[j,i]=A[i,j];
	}

	matrix B=A.copy();
	Stopwatch row_time = new Stopwatch();
	row_time.Start();
	int reps=jacobi_row.row(B,e,n,V);
	row_time.Stop();


	
	WriteLine($"{n} \t {row_time.ElapsedMilliseconds} \t {reps}");
	}

// WriteLine($"Elapsed time for cyclic method");
// WriteLine($"n \t runtime \t sweeps");
	WriteLine();WriteLine();
for(int n=40;n<200;n+=5){
	var rand= new Random(1);

	matrix A= new matrix(n,n);
	vector e= new vector(n);
	matrix V= new matrix(n,n);
	
	
	for(int i=0;i<n;i++) for(int j=i;j<n;j++){
		A[i,j]=rand.NextDouble();
		A[j,i]=A[i,j];
	}

	matrix B=A.copy();
	Stopwatch cyclic_time = new Stopwatch();
	cyclic_time.Start();
	int sweeps=jacobi.cyclic(B,e,V);
	cyclic_time.Stop();


	
	WriteLine($"{n} \t {cyclic_time.ElapsedMilliseconds} \t {sweeps}");
	}
}
}