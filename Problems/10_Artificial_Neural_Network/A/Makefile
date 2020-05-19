
All: Out.txt Plot.svg

Plot.svg: Plot.gpi Out.txt
	gnuplot $<

Out.txt: Main.exe
	mono $< >$@ 2>log.txt

Main.exe: Main.cs matlib.dll
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