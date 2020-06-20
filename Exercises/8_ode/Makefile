all: odeA.svg odeB.svg

####   Del A    ####	
odeA.svg: odeA.gpi outA.txt
	gnuplot $<

outA.txt: mainA.exe
	mono $< 1> $@ 2> log.txt

mainA.exe: mainA.cs matlib.dll
	mcs -reference:matlib.dll $<


####   Del B    ####	
odeB.svg: odeB.gpi outB1.txt outB2.txt outB3.txt
	gnuplot $<

#Del B1	
outB1.txt: mainB1.exe
	mono $< e=0 y0=1 y1=0 a=0 b=6,2831852 > $@
mainB1.exe: mainB1.cs matlib.dll
	mcs -reference:matlib.dll $<

#Del B2 og B3	
outB2.txt: mainB.exe 
	mono $< e=0 y0=1 y1=-0,5 a=0 b=6,2831852 > $@

outB3.txt: mainB.exe Makefile
	mono $< e=0,01 y0=1 y1=-0,5 a=-0 b=62,831852 > $@

mainB.exe: mainB.cs matlib.dll
	mcs -reference:matlib.dll $<


####   Matlib   ####
LIBDIR = ../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs
ODE = $(LIBDIR)/ode/ode.cs

matlib.dll: $(VECTOR) $(MATRIX) $(ODE)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.dll *.exe *.txt *.svg out*
