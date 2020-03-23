all: out.txt

out.txt: main.exe
	mono $< > $@

DLLS = gs.dll matlib.dll

main.exe:	Main.cs $(DLLS)
	mcs $< -reference:$(call clist,$(DLLS))

####   Matlib   ####
LIBDIR = ../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs

matlib.dll: $(MATRIX) $(VECTOR)
	mcs $^ -target:library -out:$@

SOLVERS=gs.cs

gs.dll:$(SOLVERS) matlib.dll
	mcs $(SOLVERS) -target:library -out:$@ -reference:$(lastword $^)

clean:
	rm -f *.exe out* *.dll *.svg

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))

