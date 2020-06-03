using System;
using static System.Console;
using static System.Math;

class  main
{
    static void Main(){

    //// Del A ////

        int n=3;
        matrix A=rand_matrix(n);
    	
    	var cd=new cholesky(A);

    	var L=cd.L;
    	var LT=cd.LT;
    	
    	WriteLine("_____________________________________");WriteLine();
    	WriteLine("Part A - decomposit A into L*LT");
    	(A).print("Matrix A=");WriteLine();
    	(L).print("Matrix L=");WriteLine();
    	(LT).print("Matrix LT=");WriteLine();
    	
    	WriteLine("Check if L*LT=A");
    	matrix LLT=L*LT;
    	LLT.print("L*LT=");WriteLine();
        if(A.approx(LLT)){WriteLine("L*LT=A\tTEST PASSED");}
        else {WriteLine("L*LT!=A\tTEST FAILED");}


    //// Del B ////

        vector v=rand_vector(n);
        vector b=v.copy();
        
        vector x=cd.solve(v);

        WriteLine("_____________________________________");WriteLine();
        WriteLine("Part B - Solving linear equation: A*x=b");
        A.print("Matrix A=");WriteLine();
        b.print("Vector b=");WriteLine();
        x.print("Solution x=");WriteLine();

        vector Ax=(A*x);
        Ax.print("Check A*x=");WriteLine();

        if(b.approx(Ax)){WriteLine("A*x=b   TEST PASSED");}
        else {WriteLine("A*x!=b  TEST FAILED");}

     //// Del C ////

        WriteLine("_____________________________________");WriteLine();
        WriteLine("Part C - Determinant of A");
        double D=cd.determinant();
        WriteLine($"det(A)={D}");WriteLine();

        if(n==3){
            double D_alt= A[0,0]*A[1,1]*A[2,2] + A[0,1]*A[1,2]*A[2,0]
            + A[0,2]*A[1,0]*A[2,1] - A[0,2]*A[1,1]*A[2,0]
            - A[0,1]*A[1,0]*A[2,2] - A[1,2]*A[2,1]*A[0,0];
            if(matrix.approx(D_alt,D)){WriteLine("TEST PASSED");}
            else {WriteLine("TEST FAILED");}
        }
        
    //// Del D ////

        WriteLine("_____________________________________");WriteLine();
        WriteLine("Part D - find the inverse matrix of A");
        var A_inv=cd.inverse();
        A_inv.print("A_inv=");WriteLine();
        
        WriteLine("Check if A_inv is the inverse:");WriteLine();
        matrix AA_inv1=A*A_inv;
        AA_inv1.print("A*A_inv=");WriteLine();
        matrix AA_inv2=A*A_inv;
        AA_inv2.print("A_inv*A=");WriteLine();


        matrix I= matrix.id(n);

        if(I.approx(AA_inv1) && I.approx(AA_inv2)){WriteLine("A*A_inv=I\tTEST PASSED");}
        else {WriteLine("A*A_inv=I\tTEST FAILED");}
    } //Method: Main


    // Generate a random real symmetric positive-definite matrix
    // If A is a real matrix, then A*A^t will be symmetric positive-definite
    static matrix rand_matrix(int n){
        matrix M= new matrix(n,n);
        var rand= new Random(1);
    
        for(int i=0;i<n;i++)
        for(int j=0;j<n;j++)
        M[i,j]=2*(rand.NextDouble()-0.5);
    
        M=M*M.transpose()/n;
        return M;
    } //Method: rand_matrix


    // Generate a random real vector
    static vector rand_vector(int n){
        vector v= new vector(n);
        var rand= new Random(1);
    
        for(int i=0;i<n;i++)
        v[i]=2*(rand.NextDouble()-0.5);

        return v;
    } //Method: rand_matrix

}// class: main










