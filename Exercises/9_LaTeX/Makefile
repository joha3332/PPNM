Bessel.svg: bessel.gpi outBessel0.txt outBessel1.txt outBessel2.txt bessel_checkpoints.txt Makefile
	gnuplot $<

outBessel0.txt: bessel.exe 
	mono $< n=0 y0=1 y1=0 a=1e-15 b=9 > $@
outBessel1.txt: bessel.exe
	mono $< n=1 y0=5e-6 y1=0,5 a=1e-5 b=9 > $@
outBessel2.txt: bessel.exe
	mono $< n=2 y0=125e-13 y1=25e-7 a=1e-5 b=9 > $@


bessel.exe: bessel.cs matlib.dll
	mcs -reference:matlib.dll $<


####   Matlib   ####
LIBDIR = ../matlib
VECTOR = $(LIBDIR)/matrix/matrix.cs
MATRIX = $(LIBDIR)/matrix/vector.cs
ODE = $(LIBDIR)/ode/ode.cs

matlib.dll: $(VECTOR) $(MATRIX) $(ODE)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.dll *.exe out*
