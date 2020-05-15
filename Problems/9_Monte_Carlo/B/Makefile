All: Out.txt Error_plot.svg

Error_plot.svg: error_plot.gpi Out.txt
	gnuplot $<

Out.txt: Main.exe
	mono $< >$@

Main.exe: Main.cs mcintegrator.dll matlib.dll
	mcs $< -r:$(call clist,$(filter %.dll,$^))

MC = ../lib/mcintegrator.cs

mcintegrator.dll: $(MC) matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:library -r:$$libs -out:$@

####   Matlib  ####
LIBDIR = ../../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs

matlib.dll: $(MATRIX) $(VECTOR)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe Out* *.dll *.log *.svg

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))