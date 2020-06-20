all:  B_out.txt B_times_out.txt B_times_plot.svg 


B_out.txt: MainB.exe
	mono MainB.exe > B_out.txt 

MainB.exe: MainB.cs matlib.dll
	mcs MainB.cs -reference:matlib.dll



B_times_plot.svg: B_times_plot.gpi B_times_out.txt
	gnuplot $<

B_times_out.txt: MainB_times.exe
	mono MainB_times.exe > B_times_out.txt  


MainB_times.exe: MainB_times.cs matlib.dll
	mcs MainB_times.cs -reference:matlib.dll

####   Matlib   ####
LIBDIR = ../../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs
LIB = ../lib
JACOBI = $(LIB)/jacobi.cs
JACOBI_ROW = $(LIB)/jacobi_row.cs


matlib.dll: $(MATRIX) $(VECTOR) $(JACOBI) $(JACOBI_ROW)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe *.dll *.svg *.txt *.log
