all: out.txt

out.txt: main.exe
	mono $< > $@



main.exe:	Main.cs matlib.dll
	mcs $< -reference:matlib.dll

####   Matlib   ####
LIBDIR = ../Problems/matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs

matlib.dll: $(MATRIX) $(VECTOR) cholesky.cs methods.cs
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out* *.dll *.svg


