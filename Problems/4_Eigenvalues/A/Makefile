all:  A1_out.txt A2_out.txt  A2_plot.svg


A1_out.txt: mainA1.exe
	mono mainA1.exe > A1_out.txt  

mainA1.exe: MainA1.cs matlib.dll
	mcs MainA1.cs -reference:matlib.dll



mainA2.exe:	MainA2.cs matlib.dll
	mcs MainA2.cs -reference:matlib.dll

A2_plot.svg: a2_plot.gpi a2_data.txt
	gnuplot $<

A2_out.txt a2_data.txt: mainA2.exe
	mono mainA2.exe 1> A2_out.txt  2>a2_data.txt



####   Matlib   ####
LIBDIR = ../../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs
JACOBI = jacobi.cs
SOLVER =$(GSDIR)/gs.cs

matlib.dll: $(MATRIX) $(VECTOR) $(JACOBI)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe out* *.dll *.svg *.txt