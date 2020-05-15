All: Out.txt Plot.svg

Plot.svg: Plot.gpi plotdata.txt higgs.txt
	gnuplot $<

Out.txt: Main.exe
	mono $< <higgs.txt 2>plotdata.txt 1>$@


Main.exe: Main.cs qnewton.dll matlib.dll
	mcs $< -r:$(call clist,$(filter %.dll,$^))


QNEWTON = ../lib/qnewton.cs

qnewton.dll: $(QNEWTON) matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:library -r:$$libs -out:$@

####   Matlib  ####
LIBDIR = ../../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs

matlib.dll: $(MATRIX) $(VECTOR)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe Out* plotdata* *.dll *.svg

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))