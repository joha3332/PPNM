Times_plot.svg: Times_plot.gpi Out_times.txt
	gnuplot $<
Out_times.txt: comparison.exe
	mono $< > $@
comparison.exe:	comparison.cs matlib.dll
	mcs $< -reference:matlib.dll



####   Matlib   ####
LIBDIR = ../../Problems/matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs
GS = ../../Problems/2_Linear_Equations/gs.cs
CHOLESKY = ../cholesky.cs
METHODS = ../methods.cs

matlib.dll: $(MATRIX) $(VECTOR) $(CHOLESKY) $(METHODS) $(GS)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe Out* *.dll *.svg *.log


