using System;
using static System.Console;

class  main
{
    static void Main(){
    	WriteLine("_____________________________________");
    	WriteLine("Part C1 - decomposition of random matrix A");

        int n=5;
        matrix A=new matrix(n,n);
        var rand= new Random(1);

        // make random matrix A
        for(int i=0;i<n;i++)
        for(int j=0;j<n;j++)
            A[i,j]=2*(rand.NextDouble()-0.5);
        

    	vector b= new vector(n);
        // make random vector b
        for(int i=0;i<n;i++)
            b[i]=2*(rand.NextDouble()-0.5);

        // make the QR decomposition through givens-rotation
        var qr1=new givens(A);
        // Matrix with R in the right diagonal and givens-angels in the lower sub-diagonal
        var G=qr1.G;

        // make the QR decomposition through GS
        var qr2=new gs(A);
        var R=qr2.R;



    	A.print("Matrix A=");WriteLine();
        WriteLine("Upper triangular part of matrix G contains the elements of R.");
        WriteLine("The enteries below the diagonal of G contains givens-rotation angles.");
        G.print("Matrix G=");WriteLine();
        R.print("Matrix R=");WriteLine();
        WriteLine("The upper triangular part of G should match the elements in R achived through GS.");

        //Filter out the lower part of G
        matrix R2=G.copy();
        for(int j=0;j<G.size2;j++)
        for(int i=j+1;i<G.size1;i++)
            R2[i,j]=0;

        if(R2.approx(R)){WriteLine("Upper triangular part identical - TEST PASSED");}
        else {WriteLine("Upper triangular part not identical - TEST FAILED");}

        WriteLine("_____________________________________");
        WriteLine("Part C2 - solve the linear equations of A*x=b");WriteLine();
    	
        // solve the equation A*x=b for vector x
        var x=qr1.solve(b);

        b.print("Vector b=");WriteLine();
        x.print("Solution x=");WriteLine();

    	vector Ax=(A*x);
    	Ax.print("Check A*x=");
        if(b.approx(Ax)){WriteLine("A*x=b  -  TEST PASSED");}
        else {WriteLine("A*x!=b  -  TEST FAILED");}

    } //Method: Main
}// class: main










