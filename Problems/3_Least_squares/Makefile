all: PlotA.svg AB_out.txt PlotC.svg

PlotA.svg: PlotA.gpi data.txt
	gnuplot $<

data.txt AB_out.txt: Main.exe
	mono Main.exe 1>data.txt 2>AB_out.txt

PlotC.svg: PlotC.gpi data.txt
	gnuplot $<

Main.exe:	Main.cs lsfit.cs matlib.dll
	mcs $(filter-out %.dll,$^) -reference:matlib.dll

####   Matlib   ####
LIBDIR = ../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs
GSDIR = ../2_Linear_Equations/AB
SOLVER =$(GSDIR)/gs.cs

matlib.dll: $(MATRIX) $(VECTOR) $(SOLVER)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out* *.dll *.svg *.txt