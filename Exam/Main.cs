using System;
using static System.Console;
using static System.Math;

class  main
{
    static void Main(){

    //// Del A ////
        matrix A= new matrix(3,3);
        A[0,0]=2; A[0,1]=4; A[0,2]=-3;
        A[1,0]=4; A[1,1]=14; A[1,2]=-9;
        A[2,0]=-3; A[2,1]=-9; A[2,2]=12;
    	
    	var cd1=new cholesky(A);

    	var L=cd1.L;
    	var LT=cd1.LT;
    	
    	WriteLine("_____________________________________");
    	WriteLine("Part A - decomposit A into L*LT");
    	(A).print("Matrix A=");WriteLine();
    	(L).print("Matrix L=");WriteLine();
    	(LT).print("Matrix LT=");WriteLine();
    	
    	WriteLine("Check if L*LT=A");
    	matrix LLT=L*LT;
    	LLT.print("L*LT=");
        if(A.approx(LLT)){WriteLine("L*LT=A\nTest passed");}
        else {WriteLine("L*LT!=A\nTest failed");}


    //// Del B ////
        matrix B= new matrix(3,3);
        B[0,0]=36; B[0,1]=30; B[0,2]=18;
        B[1,0]=30; B[1,1]=41; B[1,2]=23;
        B[2,0]=18; B[2,1]=23; B[2,2]=14;

        vector c= new vector(288,296,173);
        vector b=c.copy();
        b.print("Vector b=");WriteLine();
        
        var cd2=new cholesky(B);
        vector x=cd2.solve(c);

        WriteLine("_____________________________________");
        WriteLine("Part B - Solving linear equation");
        B.print("Matrix B=");WriteLine();
        b.print("Vector b=");WriteLine();
        x.print("Solution x=");WriteLine();

        vector Bx=(B*x);
        Bx.print("Check B*x=");
        if(b.approx(Bx)){WriteLine("B*x=b   Test passed");}
        else {WriteLine("B*x!=b  Test failed");}

     //// Del C ////
        WriteLine("_____________________________________");
        WriteLine("Part C - Determinant of A");
        double D=cd1.determinant();
        WriteLine($"det(A)={D}");WriteLine();
        
    //// Del D ////
        WriteLine("_____________________________________");
        WriteLine("Part D - find the inverse matrix of A");
        var A_inv=cd1.inverse();
        A_inv.print("A_inv=");WriteLine();
        
        WriteLine("Check if A_inv is the inverse:");WriteLine();
        matrix AA_inv1=A*A_inv;
        AA_inv1.print("A*A_inv=");WriteLine();
        matrix AA_inv2=A*A_inv;
        AA_inv2.print("A_inv*A=");WriteLine();

        int n=A.size1;
        matrix I= new matrix(n,n);
        for(int i=0;i<n;i++){
        for(int j=0;j<n;j++){
        if(i==j) I[i,j]=1;
        else    I[i,j]=0;
        }
        }

        if(I.approx(AA_inv1) || I.approx(AA_inv2)){WriteLine("A*A_inv=I\nTest passed");}
        else {WriteLine("A*A_inv=I\nTest failed");}


    } //Method: Main
}// class: main










