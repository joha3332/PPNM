Out.txt:main.exe
	mono $< > $@ 2>log

main.exe: main.cs matlib.dll
	mcs $< -reference:$(lastword $^)
matlib.dll: ../matrix/matrix.cs ../matrix/vector.cs gs.cs
	mcs $^ -target:library -out:$@

clean:
	rm -rf Out* *.dll *.exe log*
