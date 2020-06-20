PlotC.svg: PlotC.gpi out_cspline.txt
	gnuplot $<


out_cspline.txt: MainC.exe $(INPUT)
	mono MainC.exe $(INPUT) out_cspline.txt out_cspline_slope.txt out_cspline_integral.txt

MainC.exe:	MainC.cs spline.dll
	mcs -reference:spline.dll $<

INPUT = ../lib/input.txt

####   Matlib   ####
LIBDIR = ../../matlib
VECTOR = $(LIBDIR)/matrix/vector.cs
CSPLINE = ../lib/cspline.cs

spline.dll: $(VECTOR) $(CSPLINE)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out* *.dll *.svg

