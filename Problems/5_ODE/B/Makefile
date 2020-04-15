all: B_plot.svg

B_plot.svg: b_plot.gpi b_out.txt
	gnuplot $<

b_out.txt: main.exe
	mono main.exe 1> b_out.txt  2> b_log.txt

main.exe: main.cs matlib.dll
	mcs main.cs -reference:matlib.dll


####   Matlib   ####
LIBDIR = ../../matlib
VECTOR = $(LIBDIR)/matrix/vector.cs
DRIVER = ../A/driver.cs 
STEPPER = ../A/rkstep23.cs


matlib.dll: $(VECTOR) $(DRIVER) $(STEPPER)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe *.dll *.svg *.txt