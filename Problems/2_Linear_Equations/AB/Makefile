Out.txt: Main.exe
	mono $< > $@

Main.exe:	Main.cs matlib.dll
	mcs $< -reference:matlib.dll

####   Matlib   ####
LIBDIR = ../../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs

matlib.dll: $(MATRIX) $(VECTOR) gs.cs
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe Out* *.dll *.svg



