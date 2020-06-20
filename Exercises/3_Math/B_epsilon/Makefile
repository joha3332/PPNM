out.txt : main.exe              
	mono main.exe > out.txt 

main.exe : main.cs;	mcs $<            

clean:                         
	rm -f out.txt main.exe 
