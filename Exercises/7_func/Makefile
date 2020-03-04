all:outAB.txt variational.svg

#AB#
outAB.txt: main.exe
	mono $< > outAB.txt

main.exe: main.cs matlib.dll
	mcs $< -out:$@ -reference:matlib.dll

#C#
variational.svg: variational.gpi outC.txt
	gnuplot $<

outC.txt: mainC.exe
	mono $< > outC.txt

mainC.exe: mainC.cs matlib.dll
	mcs $< -out:$@ -reference:matlib.dll



LIBDIR = ../matlib
SRC = $(LIBDIR)/integration/quado8.cs
math= $(LIBDIR)/math.cs

matlib.dll: $(SRC) $(math)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.dll *.exe out*