################# Part A #################
OutA.txt: MainA.exe
	mono MainA.exe 1> $@ 2> logA.txt

MainA.exe: MainA.cs matlib.dll
	mcs MainA.cs -reference:matlib.dll

################# Lib #################
LIB = ../lib
QUAD = $(LIB)/quad.cs
OQCC = $(LIB)/OQCC.cs

matlib.dll: $(QUAD) $(OQCC)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe *.dll *.svg *.txt