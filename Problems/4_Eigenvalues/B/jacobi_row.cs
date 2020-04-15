using System;
using static System.Math;

public class jacobi_row{
public static int row(matrix A, vector e, int nvalues=1, matrix V=null,string ordering="low"){
	bool changed;
	int reps=0,n=A.size1;
	for(int i=0;i<n;i++) e[i]=A[i,i];
	if(V!=null) for(int i=0;i<n;i++){
		V[i,i]=1.0;
		for(int j=i+1;j<n;j++){
			V[i,j]=0;
			V[j,i]=0;
		}
	}

	int order=1;							//Eigenvalue ordering for low to high
	string high= "high";
	if(ordering.Equals(high)){order=-1;}	//Changes ordering from high to low, if specified


	int p,q;	
	for(p=0; p<nvalues;p++)do{
		changed=false;
		for(q=p+1;q<n;q++){
			double app=e[p];
			double aqq=e[q];
			double apq=A[p,q];
			double phi=0.5*Atan2(2*apq*order,(aqq-app)*order);
			double c=Cos(phi);
			double s=Sin(phi);
			double app1=c*c*app - 2*s*c*apq + s*s*aqq;
			double aqq1=s*s*app + 2*s*c*apq + c*c*aqq;
			if(app1!=app || aqq1!=aqq){
				reps++;
				changed=true;
				e[p]=app1;
				e[q]=aqq1;
				A[p,q]=0.0;
				for(int i=0;i<p;i++){
					double aip=A[i,p];
					double aiq=A[i,q];
					A[i,p]=c*aip-s*aiq;
					A[i,q]=c*aiq+s*aip;
				}
				for(int i=p+1;i<q;i++){
					double api=A[p,i];
					double aiq=A[i,q];
					A[p,i]=c*api-s*aiq;
					A[i,q]=c*aiq+s*api;
				}
				for(int i=q+1;i<n;i++){
					double api=A[p,i];
					double aqi=A[q,i];
					A[p,i]=c*api-s*aqi;
					A[q,i]=c*aqi+s*api;
				}
				if(V!=null)for(int i=0;i<n;i++){
					double vip=V[i,p];
					double viq=V[i,q];
					V[i,p]=c*vip-s*viq;
					V[i,q]=c*viq+s*vip;							
				}
			}
		}
	 }	
	while(changed);
return reps;
}
}