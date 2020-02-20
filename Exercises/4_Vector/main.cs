using System;
using static System.Math;
using static cmath;

class main
{
	static int Main()
	{   
		vector3d v = new vector3d(1,1,1);
		vector3d u = new vector3d(0,2,4);

        v.print("v=");
        u.print("u=");

        vector3d w1 = u + v;
        w1.print("u+v=");
        
        vector3d w2 = v + u;
        w2.print("v+u=");

        vector3d w3 = u - v;
        w3.print("u-v=");

        vector3d w4 = v - u;
        w4.print("v-u=");


        vector3d w5 = 3 * v;
        w5.print("3*v=");

        vector3d w6 = u * 3;
        w6.print("u*3=");

        double w7 = vector3d.dot_product(u, v);
        w7.print("u.v=");

        vector3d w8 = vector3d.vector_product(u, v);
        w8.print("uxv=");

        double magv = vector3d.magnitude(v);
        magv.print("|v|=");

        return 0;
	}
}
