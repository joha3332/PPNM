
out.txt : hello.exe
	mono hello.exe > out.txt

hello.exe : hello.cs
	mcs -out:hello.exe hello.cs

.PHONEY:clean 
clean:
	rm -f out.txt hello.exe
