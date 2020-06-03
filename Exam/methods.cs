using static System.Math;
public partial class cholesky{

public double determinant(){
	int n=L.size1;
	double D=1;

	for(int i=0; i<n; i++)
		D*=L[i,i];
	D*=D;
	return D;
}

public void backsub(vector c){
	for (int i=(c.size-1);i>=0;i--){
		double s=c[i];
		for(int k=i+1;k<c.size;k++){
			s-=LT[i,k]*c[k];
		}
		c[i]=s/LT[i,i];
	}  	
}

public void forsub(vector c){
	for (int i=0;i<c.size;i++){
		double s=c[i];
		for(int k=0;k<=i-1;k++){
			s-=L[i,k]*c[k];
		}
		c[i]=s/L[i,i];
	}  	
}

public vector solve (vector b){			
    forsub(b); 	// Solve L*y=b via forward subsitution
    backsub(b); // Solve U*x=y via backword subsitution

    return b;
}

public matrix inverse(){
	int n=L.size1;
	var I= new matrix(n,n);
	var A_inv= new matrix(n,n);

  	for(int i=0;i<n;i++){
  		I[i,i]=1;
  		vector xi=solve(I[i]);
  		A_inv[i]=xi;
  	}
  	return A_inv;
}

}