out.txt: Main.exe
	mono $< > $@


DLLS = matlib.dll roots.dll
Main.exe:	Main.cs $(DLLS)
	mcs $< -reference:$(call clist,$(DLLS))

#### Root finder ####
roots.dll:jacobian.cs newton.cs matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:library -r:$$libs -out:$@

####   Matlib + Solver   ####
LIBDIR = ../../matlib
MATRIX = $(LIBDIR)/matrix/matrix.cs
VECTOR = $(LIBDIR)/matrix/vector.cs
GSDIR = ../../2_Linear_Equations
SOLVER =$(GSDIR)/gs.cs

matlib.dll: $(MATRIX) $(VECTOR) $(SOLVER)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe out* *.dll

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))