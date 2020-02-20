out.txt : hello2.exe         # out.txt depends on bytecode executable hello.exe
	mono hello2.exe > out.txt  # run hello.exe in mono, redirect output into out.txt

hello2.exe : hello2.cs           #
	mcs -out:hello2.exe hello2.cs   # compile hello.cs, output goes to hello.exe

.PHONEY:clean           # clean is a phoney target
clean:                  # does not depend on anything
	rm -f out.txt hello2.exe 
