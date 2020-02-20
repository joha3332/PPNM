using System;
using static System.Math;
using static cmath;

public struct vector3d
{
    public double x, y, z;

    //constructors
    public vector3d(double a, double b, double c) { x = a; y = b; z = c; }

    public void print(string s = "")
	{
		System.Console.Write(s);
			System.Console.Write("[{0},{1},{2}]", this.x,this.y,this.z);
		System.Console.Write("\n");
	}

	//operators
	public static vector3d operator *(vector3d v, double c) { return new vector3d(c * v.x, c * v.y, c * v.z); }
    public static vector3d operator *(double c, vector3d v) { return new vector3d(c * v.x, c * v.y, c * v.z); }
    public static vector3d operator +(vector3d u, vector3d v) { return new vector3d(u.x + v.x, u.y + v.y, u.z + v.z); }
    public static vector3d operator -(vector3d u, vector3d v) { return new vector3d(u.x - v.x, u.y - v.y, u.z - v.z); }

	//methods
	public static double dot_product(vector3d u, vector3d v)
	{
		return (u.x * v.x + u.y * v.y + u.z * v.z);
	
	}

	public static vector3d vector_product(vector3d u, vector3d v)
	{
		return new vector3d(u.y * v.z - u.z * v.y,
							u.z * v.x - u.x * v.z,
							u.x * v.y - u.y * v.x);
	}

    public static double magnitude(vector3d v) { return v.x * sqrt( 1 + cmath.pow(v.y / v.x, 2) + cmath.pow(v.z / v.z, 2)); }

}
