All: PlotC.svg PlotC_slope.svg PlotC_integral.svg

#### Part B #####
PlotC.svg: plotC.gpi out_cspline.txt
	gnuplot $<

PlotC_slope.svg: plotC_slope.gpi out_cspline_slope.txt
	gnuplot $<

PlotC_integral.svg: plotC_integral.gpi out_cspline_integral.txt
	gnuplot $<

out_cspline.txt: mainC.exe $(INPUT)
	mono mainC.exe $(INPUT) out_cspline.txt out_cspline_slope.txt out_cspline_integral.txt

mainC.exe:	MainC.cs spline.dll
	mcs -reference:spline.dll $<

INPUT = ../input.txt

####   Matlib   ####
LIBDIR = ../../matlib
VECTOR = $(LIBDIR)/matrix/vector.cs

spline.dll: $(VECTOR) cspline.cs
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out* *.dll *.svg

