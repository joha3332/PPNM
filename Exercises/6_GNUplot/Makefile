all: Gamma.svg Erf.svg out.Lngamma.txt

Gamma.svg: Gamma.gpi out.gamma.txt out.gamma.test.txt
	gnuplot $<

out.gamma.txt out.gamma.test.txt: mainGamma.exe
	mono $< > out.gamma.txt 2> out.gamma.test.txt

mainGamma.exe: mainGamma.cs math.dll
	mcs $< -out:$@ -reference:math.dll

################################################
Erf.svg: Erf.gpi out.erf.txt out.erf.test.txt
	gnuplot $<		

out.erf.txt out.erf.test.txt: mainErf.exe
	mono $< > out.erf.txt 2> out.erf.test.txt

mainErf.exe: mainErf.cs math.dll
	mcs $< -out:$@ -reference:math.dll

################################################
out.Lngamma.txt: mainLngamma.exe
	mono $< > out.Lngamma.txt

mainLngamma.exe: mainLngamma.cs math.dll cmath.dll
	mcs $< -out:$@ -reference:math.dll -reference:cmath.dll


cmath.dll: lib/cmath.cs lib/complex.cs 
	mcs $^ -target:library -out:$@

math.dll: math.cs cmath.dll
	mcs $< -target:library -out:$@ -reference:cmath.dll

clean:
	rm -f *.dll *.exe out* *.svg
