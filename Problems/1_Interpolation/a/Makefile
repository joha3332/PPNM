PlotA.svg: PlotA.gpi out_lspline.txt out_lspline_integral.txt
	gnuplot $<

out_lspline.txt: MainA.exe $(INPUT)
	mono MainA.exe $(INPUT) out_lspline.txt out_lspline_integral.txt

MainA.exe:	MainA.cs spline.dll
	mcs -reference:spline.dll $<

INPUT = ../lib/input.txt

####   Matlib   ####
LIBDIR = ../../matlib
VECTOR = $(LIBDIR)/matrix/vector.cs
LSPLINE=../lib/lspline.cs

spline.dll: $(VECTOR) $(LSPLINE)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out* *.dll *.svg

