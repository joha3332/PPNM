all: out-cmdline.txt out-stdinout.txt  out-fileio.txt

out-cmdline.txt: cmdline.exe
	mono cmdline.exe 1 2 3 4 5 > out-cmdline.txt

out-stdinout.txt: stdinout.exe input.txt
	mono stdinout.exe < input.txt > out-stdinout.txt

out-fileio.txt: fileio.exe input.txt
	mono fileio.exe input.txt out-fileio.txt

cmdline.exe	:	cmdline.cs;	mcs $<
stdinout.exe	:	stdinout.cs;	mcs $<
fileio.exe	:	fileio.cs;	mcs $<

clean:
	rm *.exe out* input.txt

