All: OutA.txt OutB.txt

################# Part A #################
OutA.txt: MainA.exe
	mono MainA.exe 1> $@ 2> logA.txt

MainA.exe: MainA.cs matlib.dll
	mcs MainA.cs -reference:matlib.dll

################# Part B #################
OutB.txt: MainB.exe
	mono MainB.exe 1> $@ 2> logB.txt

MainB.exe: MainB.cs matlib.dll
	mcs MainB.cs -reference:matlib.dll
################# Lib #################

matlib.dll:quad.cs OQCC.cs
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe *.dll *.svg *.txt