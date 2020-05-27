all: PlotA.svg B_fitoutput.txt PlotC.svg

PlotA.svg: PlotA.gpi data.txt
	gnuplot $<

data.txt B_fitoutput.txt: main.exe
	mono main.exe 1>data.txt 2>B_fitoutput.txt

PlotC.svg: PlotC.gpi data.txt
	gnuplot $<

DLLS = matlib.dll

main.exe:	Main.cs lsfit.cs $(DLLS)
	mcs $(filter-out %.dll,$^) -reference:$(DLLS)

####   Matlib   ####
LIBDIR = ../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs
GSDIR = ../2_Linear_Equations
SOLVER =$(GSDIR)/gs.cs

matlib.dll: $(MATRIX) $(VECTOR) $(SOLVER)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out* *.dll *.svg *.txt