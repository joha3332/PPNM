All: PlotB.svg PlotB_slope.svg PlotB_integral.svg

#### Part B #####
PlotB.svg: plotB.gpi out_qspline.txt
	gnuplot $<

PlotB_slope.svg: plotB_slope.gpi out_qspline_slope.txt
	gnuplot $<

PlotB_integral.svg: plotB_integral.gpi out_qspline_integral.txt
	gnuplot $<

out_qspline.txt: mainB.exe $(INPUT)
	mono mainB.exe $(INPUT) out_qspline.txt out_qspline_slope.txt out_qspline_integral.txt

mainB.exe:	MainB.cs spline.dll
	mcs -reference:spline.dll $<

INPUT = ../input.txt

####   Matlib   ####
LIBDIR = ../../matlib
VECTOR = $(LIBDIR)/matrix/vector.cs

spline.dll: $(VECTOR) qspline.cs
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out* *.dll *.svg

