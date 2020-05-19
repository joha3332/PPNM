All: PlotB.svg 

#### Part B #####
PlotB.svg: PlotB.gpi out_qspline.txt
	gnuplot $<

out_qspline.txt: mainB.exe $(INPUT)
	mono mainB.exe $(INPUT) out_qspline.txt out_qspline_slope.txt out_qspline_integral.txt

mainB.exe:	MainB.cs spline.dll
	mcs -reference:spline.dll $<

INPUT = ../lib/input.txt

####   Matlib   ####
LIBDIR = ../../matlib
VECTOR = $(LIBDIR)/matrix/vector.cs
QSPLINE = ../lib/qspline.cs

spline.dll: $(VECTOR) $(QSPLINE)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out* *.dll *.svg

