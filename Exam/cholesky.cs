using static System.Math;
using static System.Console;
public partial class cholesky{
public readonly matrix L, LT;

public cholesky(matrix A){
	int n=A.size1;
	int m=A.size2;
	if(n!=m) WriteLine("A is not a square matrix");

  	L = (A).copy();
  	// Cholesky–Crout algorithm 
	for(int j=0; j<n;j++){
		for(int k=0; k<j; k++)
			L[j,j]-=L[j,k]*L[j,k];
		L[j,j]= Sqrt(L[j,j]);


		for(int i=j+1; i<n; i++){
			for(int k=0; k<j; k++)
				L[i,j]-=L[i,k]*L[j,k];
			L[i,j]/=L[j,j];
		}
	
		for(int i=0; i<j; i++)
		L[i,j]=0;						
	}

	// Calculation of LT is NOT necessary,
	// but is merly done to show all the components decomposition.
	LT= new matrix(n,n);
	for(int i=0; i<n;i++){
		for(int j=0; j<n;j++)
			LT[i,j]=L[j,i];
	}
}// Class-constructor

}//class:cholesky