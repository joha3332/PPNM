using static System.Console;
using static System.Math;
using static math;
class mainLngamma{
	static int Main()
	{
		complex z0= new complex(1,-1);
		complex z1= new complex(1,1);
		complex z2= new complex(2,3);
		complex z3= new complex(20,2);
		complex z4= new complex(50,2);

		WriteLine("lngamma({0}+{1}i)={2}", z0.Re, z0.Im, lngamma(z0));
		WriteLine("lngamma({0}+{1}i)={2}", z1.Re, z1.Im, lngamma(z1));
		WriteLine("lngamma({0}+{1}i)={2}", z2.Re, z2.Im, lngamma(z2));
		WriteLine("lngamma({0}+{1}i)={2}", z3.Re, z3.Im, lngamma(z3));
		WriteLine("lngamma({0}+{1}i)={2}", z4.Re, z4.Im, lngamma(z4));


	return 0;
	}

}
