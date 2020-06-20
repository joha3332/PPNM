################# Part B #################
OutB.txt: MainB.exe
	mono MainB.exe 1> $@ 2> logB.txt

MainB.exe: MainB.cs matlib.dll
	mcs MainB.cs -reference:matlib.dll
################# Lib #################
LIB = ../lib
QUAD = $(LIB)/quad.cs
OQCC = $(LIB)/OQCC.cs
QO8AV = $(LIB)/quado8.cs

matlib.dll: $(QUAD) $(OQCC) $(QO8AV)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe *.dll *.svg *.txt