All: Out.txt Plot.svg

Plot.svg: Plot.gpi plotdata.txt higgs.txt
	gnuplot $<

Out.txt: Main.exe
	mono $< <higgs.txt 2>plotdata.txt 1>$@


Main.exe: Main.cs qnewton.dll matlib.dll
	mcs $< -r:qnewton.dll -r:matlib.dll


QNEWTON = ../lib/qnewton.cs

qnewton.dll: $(QNEWTON) matlib.dll
	mcs $(QNEWTON) -t:library -r:matlib.dll -out:$@

####   Matlib  ####
LIBDIR = ../../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs

matlib.dll: $(MATRIX) $(VECTOR)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe Out* plotdata* *.dll *.svg
