out.txt : hello2.exe         
	mono hello2.exe > out.txt  

hello2.exe : hello2.cs          
	mcs -out:hello2.exe hello2.cs   


clean:
	rm -f out.txt hello2.exe 
