using System;
using static System.Console;
using static System.Math;

class  main
{
    static void Main(){

    //// Del A1 ////
    	matrix A=new matrix("2 3 4;2 4 6;1 1 2");
    	
    	var qra=new gs(A);

    	var Q=qra.Q;
    	var R=qra.R;
    	
    	WriteLine("_____________________________________");
    	WriteLine("Part A1 - decomposit A into Q*R");
    	(A).print("Matrix A=");
    	(Q).print("Matrix Q=");
    	(R).print("Matrix R=");

    	WriteLine("Check if Q.T is the inverse of Q");
    	((Q.T)*Q).print("Q.T*Q=");
    	
    	WriteLine("Check if Q*R=A");
    	matrix QR=Q*R;
    	QR.print("Q*R=");

    //// Del A2 ////
    	WriteLine("_____________________________________");
    	WriteLine("Part A2 - solve the linear equations of A*x=b");
    	vector b= new vector(1, 2, 3);

    	var x=qra.solve(b);
    	A.print("Matrix A=");
    	b.print("Vector b=");
    	x.print("Solution x=");

    	vector Ax=(A*x);
    	Ax.print("Check A*x=");

    //// Del B ////
    	WriteLine("_____________________________________");
    	WriteLine("Part B - find the inverse matrix of A");
       	var A_inv=qra.inverse();
       	A_inv.print("A_inv=");
       	
       	WriteLine("Check if A_inv is the inverse:");
       	matrix AA_inv1=A*A_inv;
       	AA_inv1.print("A*A_inv=");
       	matrix AA_inv2=A*A_inv;
       	AA_inv2.print("A_inv*A=");

    }
}










