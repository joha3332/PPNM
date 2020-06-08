OutC.txt: MainC.exe
	mono $< > $@

MainC.exe:	MainC.cs matlib.dll
	mcs $< -reference:matlib.dll

####   Matlib   ####
LIBDIR = ../../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs
GS = ../gs.cs

matlib.dll: $(MATRIX) $(VECTOR) givens.cs $(GS)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out* *.dll *.svg


