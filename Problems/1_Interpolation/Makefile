All: PlotA.svg PlotB.svg PlotB_slope.svg PlotB_integral.svg PlotC.svg PlotC_slope.svg PlotC_integral.svg

PlotA.svg: plotA.gpi out_lspline.txt
	gnuplot $<

out_lspline.txt: mainA.exe input.txt
	mono mainA.exe input.txt out_lspline.txt Out_lspline_integral.txt

mainA.exe:	MainA.cs spline.dll
	mcs -reference:spline.dll $<


#### Part B #####
PlotB.svg: plotB.gpi out_qspline.txt
	gnuplot $<

PlotB_slope.svg: plotB_slope.gpi out_qspline_slope.txt
	gnuplot $<

PlotB_integral.svg: plotB_integral.gpi out_qspline_integral.txt
	gnuplot $<

out_qspline.txt: mainB.exe input.txt
	mono mainB.exe input.txt out_qspline.txt out_qspline_slope.txt out_qspline_integral.txt

mainB.exe:	MainB.cs spline.dll
	mcs -reference:spline.dll $<


#### Part C #####
PlotC.svg: plotC.gpi out_cspline.txt
	gnuplot $<

PlotC_slope.svg: plotC_slope.gpi out_cspline_slope.txt
	gnuplot $<

PlotC_integral.svg: plotC_integral.gpi out_cspline_integral.txt
	gnuplot $<

out_cspline.txt: mainC.exe input.txt
	mono mainC.exe input.txt out_cspline.txt out_cspline_slope.txt out_cspline_integral.txt

mainC.exe:	MainC.cs spline.dll
	mcs -reference:spline.dll $<


####   Matlib   ####
LIBDIR = ../matlib
VECTOR = $(LIBDIR)/matrix/vector.cs

spline.dll: $(VECTOR) lspline.cs qspline.cs cspline.cs
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out* *.dll *.svg

