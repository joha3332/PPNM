all:  B_times_out.txt B_times_plot.svg



mainB.exe: MainB.cs matlib.dll
	mcs MainB.cs -reference:matlib.dll



B_times_plot.svg: B_times_plot.gpi B_times_out.txt
	gnuplot $<

B_times_out.txt: mainB_times.exe
	mono mainB_times.exe > B_times_out.txt  


mainB_times.exe: MainB_times.cs matlib.dll
	mcs MainB_times.cs -reference:matlib.dll

####   Matlib   ####
LIBDIR = ../../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs


matlib.dll: $(MATRIX) $(VECTOR) jacobi.cs jacobi_row.cs
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe out* *.dll *.svg *.txt
