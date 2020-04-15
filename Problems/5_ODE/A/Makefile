all:  A_plot.svg

A_plot.svg: a_plot.gpi a_out.txt
	gnuplot $<

a_out.txt: main.exe
	mono main.exe 1> a_out.txt  2> a_log.txt

main.exe: main.cs matlib.dll
	mcs main.cs -reference:matlib.dll


####   Matlib   ####
LIBDIR = ../../matlib
VECTOR = $(LIBDIR)/matrix/vector.cs


matlib.dll: $(VECTOR) driver.cs rkstep23.cs
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe *.dll *.svg *.txt