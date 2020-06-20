using System;
using static System.Console;
using System.Diagnostics;


class main{
static void Main(){
////////////// Part B - Elapsed time for n*n matrix ///////////////");
	
//////   Elapsed time for row by row method of first eigenvalue
	WriteLine();WriteLine();
for(int n=70;n<500;n+=50){
	var rand= new Random(1);

	matrix A= new matrix(n,n);
	vector e= new vector(n);
	matrix V= new matrix(n,n);
	
	
	for(int i=0;i<n;i++) for(int j=i;j<n;j++){
		A[i,j]=2*(rand.NextDouble()-0.5);
		A[j,i]=A[i,j];
	}

	matrix B=A.copy();
	Stopwatch row_time = new Stopwatch();
	row_time.Start();
	int reps=jacobi_row.row(B,e,1,V);
	row_time.Stop();


/////  matrix dimension n*n 		runtime			number of sweeps
	WriteLine($"{n} \t {row_time.ElapsedMilliseconds} \t {reps}");
}

/////////   Elapsed time for row by row method
	WriteLine();WriteLine();
for(int n=40;n<91;n+=10){
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


/////  matrix dimension n*n 		runtime			number of sweeps
	WriteLine($"{n} \t {row_time.ElapsedMilliseconds} \t {reps}");
	}

//Elapsed time for cyclic method

	WriteLine();WriteLine();
for(int n=40;n<301;n+=20){
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
	int sweeps=jacobi.cyclic(B,e,V)*n*(n-1)/2;
	cyclic_time.Stop();


/////   matrix dimension n*n 		runtime			number of sweeps
	WriteLine($"{n} \t {cyclic_time.ElapsedMilliseconds} \t {sweeps}");
	}
}
}