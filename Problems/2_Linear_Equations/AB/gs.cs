using System.Diagnostics;
public class gs{
public readonly matrix Q,R;

public gs(matrix A){
  	Q = (A).copy();
	int n=A.size1;
	int m=A.size2;
	Debug.Assert(n>=m);

	R= new matrix(m,m);
		for(int i=0; i<m;i++){
			R[i,i]=Q[i].norm();
			Q[i]/=R[i,i];

			for(int j=i+1; j<m;j++){
				R[i,j]=Q[i].dot(Q[j]);
				Q[j]-=Q[i]*R[i,j];
			}
		}
}

public void backsub(vector c){
	for (int i=(c.size-1);i>=0;i--){
		double s=c[i];
		for(int k=i+1;k<c.size;k++){
			s-=R[i,k]*c[k];
		}
		c[i]=s/R[i,i];
	}  	
}

public vector solve (vector b){
  	var c=Q.T*b;			
    backsub(c);
    return c;
}

public matrix inverse(){
	int n=Q.size1;
	int m=Q.size2;
	var I= new matrix(n,n);
	var A_inv= new matrix(m,n);

  	for(int i=0;i<n;i++){
  		I[i,i]=1;
  		vector xi=solve(I[i]);
  		A_inv[i]=xi;
  	}
  	return A_inv;
}
}