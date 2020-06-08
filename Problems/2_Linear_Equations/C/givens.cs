using System.Diagnostics;
using static System.Math;
public class givens{
public readonly matrix G;

public givens(matrix A){
  	G = (A).copy();
	int n=A.size1;
	int m=A.size2;
	Debug.Assert(n>=m);

	double theta, xp, xq;
		for(int q=0; q<m;q++)
		for(int p=q+1; p<n;p++){
			theta=Atan2(G[p,q],G[q,q]);
			for( int k=q;k<m;k++){
				xq=G[q,k];
				xp=G[p,k];
				G[q,k]=xq*Cos(theta) + xp *Sin(theta);
				G[p,k]=-xq*Sin(theta) + xp *Cos(theta);
			}
			G[p,q]=theta;
		}
}

public vector applyQT(vector b){
	vector v=b.copy();
	double theta, vq, vp;
	for(int q=0; q<G.size2;q++)
	for(int p=q+1; p  <G.size1;p++){
		theta=G[p,q];
		vq=v[q];
		vp=v[p];
		v[q]=vq*Cos(theta)+vp*Sin(theta);
		v[p]=-vq*Sin(theta)+vp*Cos(theta);
	}
	return v;
}

public void backsub(vector c){
	for (int i=(c.size-1);i>=0;i--){
		double s=c[i];
		for(int k=i+1;k<c.size;k++){
			s-=G[i,k]*c[k];
		}
		c[i]=s/G[i,i];
	}  	
}

public vector solve(vector b){
	vector v=applyQT(b);
	backsub(v);
	return v;
}


}