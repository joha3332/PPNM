using System;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;

class main{

static Func<double,vector,vector> newton3body(){
	return (x, y) => {
	//Position vectors
	vector r1= new vector(y[0],y[1]);
	vector r2= new vector(y[2],y[3]);
	vector r3= new vector(y[4],y[5]);

	// Acceleration vectors
	vector a1= -(r1-r2)/Pow((r1-r2).norm(),3) - (r1-r3)/Pow((r1-r3).norm(),3);
	vector a2= -(r2-r1)/Pow((r2-r1).norm(),3) - (r2-r3)/Pow((r2-r3).norm(),3);
	vector a3= -(r3-r2)/Pow((r3-r2).norm(),3) - (r3-r1)/Pow((r3-r1).norm(),3);

	vector yd= new vector(12);
		yd[0]=y[6];
		yd[1]=y[7];
		yd[2]=y[8];
		yd[3]=y[9];
		yd[4]=y[10];
		yd[5]=y[11];
		yd[6]=a1[0];
		yd[7]=a1[1];
		yd[8]=a2[0];
		yd[9]=a2[1];
		yd[10]=a3[0];
		yd[11]=a3[1];

	return yd;
	};
}

static void Main(){
	// Inintial conditions:
	vector r1_0= new vector(0.97000436, -0.24308753);
	vector r2_0= -r1_0.copy();
	vector r3_0= new vector(0,0);
	vector v3_0= new vector(-0.93240737, -0.86473146);
	vector v2_0= v3_0.copy()/(-2.0);
	vector v1_0= v2_0.copy();
	
	vector ya = new vector(new double[] 
			{r1_0[0], r1_0[1], r2_0[0], r2_0[1], r3_0[0], r3_0[1],
			 v1_0[0], v1_0[1], v2_0[0], v2_0[1], v3_0[0], v3_0[1]});
	
	double ta = 0;
	double tb = 7.5;
	//newton3body()(ta,ya).print($"y at t={ta}: ");


	double h=1e-3, acc=1e-5, eps=1e-5;
	var ts=new List<double>();
	var ys=new List<vector>();

	vector yb=ode.rk23(newton3body(),ta,ya,tb,acc:acc,eps:eps,h:h,xlist:ts,ylist:ys);

	Error.WriteLine($"acc={acc} eps={eps}");
	Error.WriteLine($"npoints={ts.Count}");
	Error.WriteLine($"Solve the ODE up to t={tb}");

	for(int i=0;i<ts.Count;i++)
		WriteLine($"{ts[i]}\t{ys[i][0]}\t{ys[i][1]}\t{ys[i][2]}\t{ys[i][3]}\t{ys[i][4]}\t{ys[i][5]}");
} // Method:Main
} // Class:Main