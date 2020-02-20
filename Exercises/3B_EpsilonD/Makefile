out.txt : main.exe              
	mono main.exe > out.txt 

main.exe : main.cs BoolAprox.dll             
	mcs -reference:BoolAprox.dll main.cs            

BoolAprox.dll : BoolAprox.cs
	mcs -target:library BoolAprox.cs

clean:                         
	rm -f out.txt main.exe 
