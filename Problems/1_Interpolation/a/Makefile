All: PlotA.svg

PlotA.svg: plotA.gpi out_lspline.txt
	gnuplot $<

out_lspline.txt: mainA.exe $(INPUT)
	mono mainA.exe $(INPUT) out_lspline.txt Out_lspline_integral.txt

mainA.exe:	MainA.cs spline.dll
	mcs -reference:spline.dll $<

INPUT = ../input.txt

####   Matlib   ####
LIBDIR = ../../matlib
VECTOR = $(LIBDIR)/matrix/vector.cs

spline.dll: $(VECTOR) lspline.cs
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out* Out* *.dll *.svg

