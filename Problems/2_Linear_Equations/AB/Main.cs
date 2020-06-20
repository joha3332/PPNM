using System;
using static System.Console;
using static System.Math;

class  main
{
    static void Main(){

    //// Del A1 ////
        int n=4, m=3;
        matrix A= new matrix(n,m);
        var rand= new Random(1);
    
    
    for(int i=0;i<n;i++){
    for(int j=0;j<m;j++){
        A[i,j]=2*(rand.NextDouble()-0.5);
    }
    }
        
        var qra1=new gs(A);

        var Q=qra1.Q;
        var R=qra1.R;
        
        WriteLine("_____________________________________");
        WriteLine("Part A1 - decomposit A into Q*R");
        (A).print("Matrix A=");WriteLine();
        (Q).print("Matrix Q=");WriteLine();
        (R).print("Matrix R=");WriteLine();

        WriteLine("Check if Q.T is the inverse of Q");
        ((Q.T)*Q).print("Q.T*Q=");WriteLine();
        
        WriteLine("Check if Q*R=A");
        matrix QR=Q*R;
        QR.print("Q*R=");
        if(A.approx(QR)){WriteLine("Q*R=A\nTest passed");}
        else {WriteLine("Q*R!=A\nTest failed");}



    //// Del A2 ////
        WriteLine("_____________________________________");
        WriteLine("Part A2 - solve the linear equations of A*x=b");

        n=4;
        A=new matrix(n,n);
        for(int i=0;i<n;i++){
        for(int j=0;j<n;j++){
        A[i,j]=2*(rand.NextDouble()-0.5);
        }
        }

        vector b= new vector(n);
        for(int i=0;i<n;i++){
        b[i]=2*(rand.NextDouble()-0.5);
        }

        var qra2=new gs(A);

        var x=qra2.solve(b);
        A.print("Matrix A=");WriteLine();
        b.print("Vector b=");WriteLine();
        x.print("Solution x=");WriteLine();

        vector Ax=(A*x);
        Ax.print("Check A*x=");
        if(b.approx(Ax)){WriteLine("A*x=b   Test passed");}
        else {WriteLine("A*x!=b  Test failed");}

    //// Del B ////
        WriteLine("_____________________________________");
        WriteLine("Part B - find the inverse matrix of A");
        var A_inv=qra2.inverse();
        A_inv.print("A_inv=");WriteLine();
        
        WriteLine("Check if A_inv is the inverse:");WriteLine();
        matrix AA_inv1=A*A_inv;
        AA_inv1.print("A*A_inv=");WriteLine();
        matrix AA_inv2=A*A_inv;
        AA_inv2.print("A_inv*A=");WriteLine();

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