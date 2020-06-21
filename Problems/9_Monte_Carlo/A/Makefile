Out.txt: Main.exe
	mono $< >$@ 2>log.txt

Main.exe: Main.cs mcintegrator.dll matlib.dll
	mcs $< -r:mcintegrator.dll -r:matlib.dll

MC = ../lib/mcintegrator.cs

mcintegrator.dll: $(MC) matlib.dll
	mcs $(MC) -t:library -r:matlib.dll -out:$@

####   Matlib  ####
LIBDIR = ../../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs

matlib.dll: $(MATRIX) $(VECTOR)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe Out* log* *.dll
