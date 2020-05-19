
All: OutB.txt PlotB.svg

PlotB.svg: PlotB.gpi OutB.txt
	gnuplot $<

OutB.txt: MainB.exe
	mono $< >$@ 2>log.txt

MainB.exe: MainB.cs matlib.dll
	mcs -out:$@ -reference:matlib.dll $<


####   Matlib  ####
LIBDIR = ../../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs
QNEWTON = ../../8_Minimization/lib/qnewton.cs
NEURALNET= ../lib/neuralnet.cs

matlib.dll: $(MATRIX) $(VECTOR) $(QNEWTON) $(NEURALNET)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe Out* log* *.dll *.svg 
