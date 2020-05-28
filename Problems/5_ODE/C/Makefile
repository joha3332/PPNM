C_plot.svg: C_plot.gpi c_out.txt
	gnuplot $<

c_out.txt: main.exe
	mono main.exe 1> c_out.txt  2> c_log.txt

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