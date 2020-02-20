out.txt : main.exe
	mono main.exe > out.txt

main.exe: main.cs vector3d.dll
	mcs $< -reference:$(word 2,$^)

vector3d.dll : vector3d.cs cmath.cs complex.cs
	mcs -target:library vector3d.cs cmath.cs complex.cs

clean:
	rm -f out.txt main.exe
